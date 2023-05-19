using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class GestionPedidosVM : ObservableObject
    {
        private Orders pedidoSeleccionado;

        public Orders PedidoSeleccionado
        {
            get { return pedidoSeleccionado; }
            set { SetProperty(ref pedidoSeleccionado, value);
                if (pedidoSeleccionado != null)
                {
                    if (pedidoSeleccionado.Employee != null)
                    {
                        if (pedidoSeleccionado.Employee.IdEmployee == EmpleadoActual.IdEmployee)
                        {
                            IsEmpleadoActual = true;
                        }
                        else
                        {
                            IsEmpleadoActual = false;
                        }
                    }
                }
            }
        }

        private ObservableCollection<Orders> pedidos;
        public ObservableCollection<Orders> Pedidos
        {
            get { return pedidos; }
            set { SetProperty(ref pedidos, value); }
        }

        private ObservableCollection<Employees> empleadosAComparar;
        public ObservableCollection<Employees> EmpleadosAComparar
        {
            get { return empleadosAComparar; }
            set { SetProperty(ref empleadosAComparar, value); }
        }

        private ObservableCollection<OrderDetails> detallesPedido;

        public ObservableCollection<OrderDetails> DetallesPedido
        {
            get { return detallesPedido; }
            set { SetProperty(ref detallesPedido, value); }
        }

        

        private UserControl contenidoVentana;
        public UserControl ContenidoVentana
        {
            get { return contenidoVentana; }
            set { SetProperty(ref contenidoVentana, value); }
        }

        private Employees empleadoActual;
        public Employees EmpleadoActual
        {
            get { return empleadoActual; }
            set { SetProperty(ref empleadoActual, value); }
        }
        private bool isEmpleadoActual;

        public bool IsEmpleadoActual
        {
            get { return isEmpleadoActual; }
            set { SetProperty(ref isEmpleadoActual, value); }
        }


        private ServicioApiRest servicioApiRest;
        private ServicioNavegacion servicioNavegacion;
        public RelayCommand MostrarDetallesCommand { get; }
        public RelayCommand GestionarProductoCommand { get; }
        public RelayCommand EnviarFacturaCommand { get; }
        public GestionPedidosVM()
        {
            WeakReferenceMessenger.Default.Register<EmpleadoLoggeadoMessage>(this, (r, m) =>
            {
                EmpleadoActual = m.Value;
            });

            MostrarDetallesCommand = new RelayCommand(MostrarDetalles);
            EnviarFacturaCommand = new RelayCommand(ComprobarDatos);
            GestionarProductoCommand = new RelayCommand(GestionarPedido);

            this.servicioNavegacion = new ServicioNavegacion();
            this.servicioApiRest = new ServicioApiRest();

            CargarPedidos();

            WeakReferenceMessenger.Default.Register<GestionPedidosVM, EnviarPedidoMessage>(this, (r, m) =>
            {
                if (!m.HasReceivedResponse)
                {
                    m.Reply(r.PedidoSeleccionado);
                }
            });
        }

        public void CargarPedidos()
        {
            Pedidos = this.servicioApiRest.OrdersGetAll();
        }

        public void GestionarPedido()
        {
            PedidoSeleccionado.Employee = EmpleadoActual;
            this.servicioApiRest.OrdersPut(PedidoSeleccionado);
            CargarPedidos();
        }

        public void MostrarDetalles()
        {
            ContenidoVentana = this.servicioNavegacion.CargarDetallesPedido();
        }

        public void ComprobarDatos()
        {
            bool generarFactura = true;

            foreach (OrderDetails detallePedido in PedidoSeleccionado.OrderDetails)
            {
                if (this.servicioApiRest.ProductsGetOne(detallePedido.Product.IdProduct).Stock < detallePedido.Amount)
                {
                    generarFactura = false;
                }
            }

            if (generarFactura)
            {
                foreach (OrderDetails detallePedido in PedidoSeleccionado.OrderDetails)
                {
                    Products producto = this.servicioApiRest.ProductsGetOne(detallePedido.Product.IdProduct);
                    producto.Stock -= detallePedido.Amount;
                    this.servicioApiRest.ProductsPut(producto);
                }
                GenerarFactura();
            }
            else
            {
                string productosSinStock = "";

                foreach (OrderDetails detallePedido in PedidoSeleccionado.OrderDetails)
                {
                    if ((detallePedido.Amount - this.servicioApiRest.ProductsGetOne(detallePedido.Product.IdProduct).Stock) > 0)
                    {
                        productosSinStock += detallePedido.Product.Product + " - " + (detallePedido.Amount - this.servicioApiRest.ProductsGetOne(detallePedido.Product.IdProduct).Stock) + "\n";
                    }
                }

                MessageBoxResult result = MessageBox.Show("Faltan en almacen:\n\n" + productosSinStock, "Sin unidades en el almacen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GenerarFactura()
        {
            String ruta = "./Basura";

            if (!File.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            Document
                .Create(document =>
                {
                    document.Page(page =>
                    {
                        page.Margin(1, Unit.Inch);

                        page.Header()
                            .Column(column =>
                            {
                                column.Item().AlignLeft().Row(y =>
                                {
                                    y.RelativeItem().Column(c =>
                                    {
                                        c.Item().Text("Factura").FontSize(40).Bold().FontColor("#273389");
                                        c.Item().Padding(5).Text("Trend Project.").Bold();
                                        c.Item().Padding(2).Text("C/ Cerámica, 24");
                                        c.Item().Padding(2).Text("03010 Alacant, Alicante");
                                    });
                                    y.RelativeItem().AlignRight()
                                     .Width(3.0f, Unit.Inch)
                                     .Image("./Assets/NewTrendLogoWhite.png", ImageScaling.FitArea);
                                });

                                column.Item().PaddingTop(10).Row(r =>
                                {
                                    r.RelativeItem().Text("FACTURAR A").Bold().FontColor("#273389");
                                    r.RelativeItem().Text("ENVIAR A").Bold().FontColor("#273389");
                                    r.RelativeItem().Text("Nº DE FACTURA").Bold().FontColor("#273389");
                                    r.RelativeItem().Text("ES-001");
                                });
                                column.Item().Row(r =>
                                {
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Country);
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Country);
                                    r.RelativeItem().Text("FECHA").Bold().FontColor("#273389");
                                    r.RelativeItem().Text(PedidoSeleccionado.OrderDate);
                                });
                                column.Item().Row(r =>
                                {
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Address);
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Address);
                                    r.RelativeItem().Text("Nº DE PEDIDO").Bold().FontColor("#273389");
                                    r.RelativeItem().Text(PedidoSeleccionado.IdOrder + "/2023");
                                });
                                column.Item().Row(r =>
                                {
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Location + ", " + PedidoSeleccionado.Client.Location);
                                    r.RelativeItem().Text(PedidoSeleccionado.Client.Location + ", " + PedidoSeleccionado.Client.Location);
                                    r.RelativeItem().Text("FECHA VENCIMIENTO").Bold().FontColor("#273389");
                                    r.RelativeItem().Text("31/12/2023");
                                });
                            });

                        page.Content()
                            .Column(column =>
                            {

                                column.Item().PaddingTop(20).LineHorizontal(0.03f, Unit.Inch).LineColor("#EAA630");

                                column.Item().Padding(5).Row(r =>
                                {
                                    r.RelativeItem().AlignCenter().Text("CANT.").Bold().FontColor("#273389");
                                    r.RelativeItem().AlignCenter().Text("DESCRIPCIÓN").Bold().FontColor("#273389");
                                    r.RelativeItem().AlignCenter().Text("PRECIO UNITARIO").Bold().FontColor("#273389");
                                    r.RelativeItem().AlignCenter().Text("IMPORTE").Bold().FontColor("#273389");
                                });

                                column.Item().LineHorizontal(0.03f, Unit.Inch).LineColor("#EAA630");


                                double subtotal = 0;
                                foreach (OrderDetails detallePedido in PedidoSeleccionado.OrderDetails)
                                {
                                    column.Item().Padding(5).Row(r =>
                                    {
                                        r.RelativeItem().AlignCenter().Text(detallePedido.Amount);
                                        r.RelativeItem().AlignLeft().Text(detallePedido.Product.Product);
                                        r.RelativeItem().AlignRight().Text($"{detallePedido.Product.Price:N2}");
                                        subtotal += detallePedido.Product.Price * detallePedido.Amount;
                                        r.RelativeItem().AlignRight().Text($"{detallePedido.Product.Price * detallePedido.Amount:N2}");
                                    });
                                }

                                column.Item().LineHorizontal(0.03f, Unit.Inch).LineColor("#EAA630");

                                column.Item().PaddingTop(10).Row(r =>
                                {
                                    r.RelativeItem().AlignRight().Text("Subtotal");
                                    r.RelativeItem().AlignRight().Text($"{subtotal:N2}");
                                });

                                double iva = subtotal * 0.21;
                                column.Item().Padding(3).Row(r =>
                                {
                                    r.RelativeItem().AlignRight().Text("IVA 21.0%");
                                    
                                    r.RelativeItem().AlignRight().Text($"{iva:N2}");
                                });
                                column.Item().Padding(3).Row(r =>
                                {
                                    r.RelativeItem().AlignRight().Text("TOTAL").Bold().FontColor("#273389");
                                    r.RelativeItem().AlignRight().Text($"{subtotal+iva:N2}"+"€").Bold().FontColor("#273389");
                                });
                            });
                    });
                }).GeneratePdf("./Basura/Factura" + PedidoSeleccionado.IdOrder + ".pdf");
            EnviarFactura("./Basura/Factura" + PedidoSeleccionado.IdOrder + ".pdf");
        }

        public void EnviarFactura(string ruta)
        {
            Process.Start("Email.jar", $"{ruta} {PedidoSeleccionado.Client.Email}");
            PedidoSeleccionado.Managed = true;
            this.servicioApiRest.OrdersPut(PedidoSeleccionado);
            CargarPedidos();
        }
    }
}
