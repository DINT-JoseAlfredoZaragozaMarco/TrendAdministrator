using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class ReabastecerProductosVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;
        private Products productoActual;
        public Products ProductoActual
        {
            get { return productoActual; }
            set { SetProperty(ref productoActual, value); }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { SetProperty(ref cantidad, value); }
        }

        public RelayCommand RestarUnidadCommand { get; }
        public RelayCommand SumarUnidadCommand { get; }
        public RelayCommand AceptarCambiosCommand { get; }

        public ReabastecerProductosVM()
        {

            ProductoActual = WeakReferenceMessenger.Default.Send<EnviarProductoMessage>();
            Cantidad = 0;

            RestarUnidadCommand = new RelayCommand(RestarUnidad);
            SumarUnidadCommand = new RelayCommand(SumarUnidad);
            AceptarCambiosCommand = new RelayCommand(AceptarCambios);

            this.servicioApiRest = new ServicioApiRest();
        }

        public void RestarUnidad()
        {
            if (Cantidad > 0)
            {
                Cantidad--;
            }
        }

        public void SumarUnidad()
        {
            Cantidad++;
        }

        public void AceptarCambios()
        {
            if (Cantidad > 0)
            {
                ProductoActual.Stock += Cantidad;
                this.servicioApiRest.ProductsPut(ProductoActual);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No estás solicitando ninguna unidad", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
