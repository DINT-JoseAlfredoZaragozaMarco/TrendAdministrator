using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
    class NuevoEditarProductoVM : ObservableObject
    {
        private Products productoActual;
        public Products ProductoActual
        {
            get { return productoActual; }
            set { SetProperty(ref productoActual, value); }
        }

        private ObservableCollection<int> sizes;
        public ObservableCollection<int> Sizes
        {
            get { return sizes; }
            set { sizes = value; }
        }

        private ObservableCollection<Suppliers> suppliers;
        public ObservableCollection<Suppliers> Suppliers
        {
            get { return suppliers; }
            set { suppliers = value; }
        }

        private ObservableCollection<string> gender;
        public ObservableCollection<string> Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private ServicioApiRest servicioApiRest;
        private ServicioAzure servicioAzure;
        private ServicioDialogo servicioDialogo;
        public RelayCommand ExplorarImagenesCommand { get; }
        public RelayCommand RealizarCambiosCommand { get; }
        public NuevoEditarProductoVM()
        {

            servicioAzure = new ServicioAzure();
            servicioDialogo = new ServicioDialogo();
            servicioApiRest = new ServicioApiRest();

            Suppliers = this.servicioApiRest.SuppliersGetAll();

            ProductoActual = WeakReferenceMessenger.Default.Send<EnviarProductoMessage>();
            if (ProductoActual == null)
            {
                ProductoActual = new Products();
            }
            else
            {
                ProductoActual.SupplierCode = Suppliers.First(n => n.IdSupplier == ProductoActual.SupplierCode.IdSupplier);
            }

            ExplorarImagenesCommand = new RelayCommand(ExploradorDeArchivos);
            RealizarCambiosCommand = new RelayCommand(AceptarCambios);

            Sizes = new ObservableCollection<int> { 38, 39, 40, 41, 42, 43, 44, 45, 46, 47};
            Gender = new ObservableCollection<string> {"Men", "Women"};
        }

        public void ExploradorDeArchivos()
        {
            string file = servicioDialogo.DialogoAbrirFichero();
            ProductoActual.Images = file != null ? servicioAzure.AlmacenarImagenEnLaNube(file) : string.Empty;
        }

        public void AceptarCambios()
        {
            if (ProductoActual.IdProduct == 0)
            {
                if (ProductoActual.Product != null)
                {
                    this.servicioApiRest.ProductsPost(ProductoActual);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Faltan campos por rellenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                this.servicioApiRest.ProductsPut(ProductoActual);
            }
        }
    }
}
