using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class NuevoEditarEmpleadoVM : ObservableObject
    {
        private ServicioApiRest servicioApi;

		private Employees empleadoActual;
		public Employees EmpleadoActual
        {
			get { return empleadoActual; }
			set { SetProperty(ref empleadoActual, value); }
		}

        public RelayCommand AceptarCambiosCommand { get; }

		public NuevoEditarEmpleadoVM() 
		{
            EmpleadoActual = WeakReferenceMessenger.Default.Send<EnviarEmpleadoMessage>();
            if (EmpleadoActual == null)
            {
                EmpleadoActual = new Employees();
            }

            this.servicioApi = new ServicioApiRest();
            AceptarCambiosCommand = new RelayCommand(AceptarCambios);
        }

        public void AceptarCambios()
        {
            if (EmpleadoActual.IdEmployee == 0)
            {
                if (EmpleadoActual.EmployeeName != null)
                {
                    this.servicioApi.EmployeesPost(EmpleadoActual);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Faltan campos por rellenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                this.servicioApi.EmployeesPut(EmpleadoActual);
            }
        }
    }
}
