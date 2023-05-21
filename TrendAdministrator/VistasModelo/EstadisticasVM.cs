using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class EstadisticasVM : ObservableObject
    {
        private ServicioNavegacion servicioNavegacion;
        private UserControl contenidoVentana;

        public UserControl ContenidoVentana
        {
            get { return contenidoVentana; }
            set { SetProperty(ref contenidoVentana, value); }
        }

        private int ventanaSeleccionada;

        public int VentanaSeleccionada
        {
            get { return ventanaSeleccionada; }
            set { SetProperty(ref ventanaSeleccionada, value); }
        }

        public RelayCommand AvanzarVentanaCommand { get; }
        public RelayCommand RetrocederVentanaCommand { get; }
        public EstadisticasVM()
        {
            this.servicioNavegacion = new ServicioNavegacion();
            VentanaSeleccionada = 0;

            RetrocederVentanaCommand = new RelayCommand(RetrocederVentana);
            AvanzarVentanaCommand = new RelayCommand(AvanzarVentana);

            CambiarVentana();
        }

        public void RetrocederVentana()
        {
            if (VentanaSeleccionada > 0)
            {
                VentanaSeleccionada--;
                CambiarVentana();
            }
        }
        public void AvanzarVentana()
        {
            if (VentanaSeleccionada < 1)
            {
                VentanaSeleccionada++;
                CambiarVentana();
            }
        }

        public void CambiarVentana()
        {
            if (VentanaSeleccionada == 0)
            {
                ContenidoVentana = this.servicioNavegacion.CargarEstadisticaEmpleados();
            }
            else
            {
                ContenidoVentana = this.servicioNavegacion.CargarEstadisticasPorMarca();
            }
        }
    }
}
