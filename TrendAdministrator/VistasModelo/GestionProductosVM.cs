using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class GestionProductosVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;
        private ServicioNavegacion servicioNavegacion;
        private Products productoSeleccionado;
        public Products ProductoSeleccionado
        {
            get { return productoSeleccionado; }
            set { SetProperty(ref productoSeleccionado, value); }
        }

        private ObservableCollection<Products> productos;
        public ObservableCollection<Products> Productos
        {
            get { return productos; }
            set { SetProperty(ref productos, value); }
        }

        public RelayCommand EliminarProductoCommand { get; }
        public RelayCommand EditarProductoCommand { get; }
        public RelayCommand NuevoProductoCommand { get; }
        public RelayCommand ReabastecerProductoCommand { get; }

        public GestionProductosVM()
        {
            this.servicioApiRest = new ServicioApiRest();
            this.servicioNavegacion = new ServicioNavegacion();

            EliminarProductoCommand = new RelayCommand(EliminarProducto);
            EditarProductoCommand = new RelayCommand(EditarProducto);
            NuevoProductoCommand = new RelayCommand(NuevoProducto);
            ReabastecerProductoCommand = new RelayCommand(ReabastecerProducto);

            CargarProductos();

            WeakReferenceMessenger.Default.Register<GestionProductosVM, EnviarProductoMessage>(this, (r, m) =>
            {
                if (!m.HasReceivedResponse)
                {
                    m.Reply(r.ProductoSeleccionado);
                }
            });

        }

        public void EliminarProducto()
        {

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.servicioApiRest.ProductsDelete(ProductoSeleccionado.IdProduct);
                CargarProductos();
            }
        }

        public void NuevoProducto()
        {
            ProductoSeleccionado = new Products();
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarProducto();
            if ((bool)resultado)
            {
                CargarProductos();
            }
            ProductoSeleccionado = null;
        }

        public void EditarProducto()
        {
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarProducto();
            if ((bool)resultado)
            {
                CargarProductos();
            }
            ProductoSeleccionado = null;
        }

        public void CargarProductos()
        {
            Productos = this.servicioApiRest.ProductsGetAll();
        }

        public void ReabastecerProducto()
        {
            bool? resultado = this.servicioNavegacion.CargarReabastecerProducto();
            if ((bool)resultado)
            {
                CargarProductos();
            }
        }
    }
}
