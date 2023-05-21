using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class EstadisitcaVentasPorMarcasVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;

        private ObservableCollection<Products> productos;
        public ObservableCollection<Products> Productos
        {
            get { return productos; }
            set { SetProperty(ref productos, value); }
        }
        public EstadisitcaVentasPorMarcasVM()
        {
            this.servicioApiRest = new ServicioApiRest();
            Productos = this.servicioApiRest.ProductsGetAll();
            CalcularPedidosVendidosPorMarca();
        }

        public void CalcularPedidosVendidosPorMarca()
        {
            foreach (Orders pedido in this.servicioApiRest.OrdersGetAll())
            {
                if (pedido.Managed)
                {
                    foreach (OrderDetails detallePedido in pedido.OrderDetails)
                    {
                        foreach (Products producto in Productos)
                        {
                            if (detallePedido.Product.IdProduct == producto.IdProduct)
                            {
                                producto.TotalVendido += detallePedido.Amount;
                            }
                        }
                    }
                }
            }
        }
    }
}
