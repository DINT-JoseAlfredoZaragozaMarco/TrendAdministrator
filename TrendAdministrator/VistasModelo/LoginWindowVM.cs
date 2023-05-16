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
    class LoginWindowVM : ObservableObject
    {
		private ServicioApiRest servicioApi;

		private ObservableCollection<Employees> listaEmpleados;
		public ObservableCollection<Employees> ListaEmpleados
        {
			get { return listaEmpleados; }
			set { SetProperty(ref listaEmpleados, value); }
		}

		private string usuario;
		public string Usuario
		{
			get { return usuario; }
			set { SetProperty(ref usuario, value); }
		}

        private string contraseña;
        public string Contraseña
        {
            get { return contraseña; }
            set { SetProperty(ref contraseña, value); }
        }

		private Employees empleadoActual;

		public Employees EmpleadoActual
        {
			get { return empleadoActual; }
			set { SetProperty(ref empleadoActual, value); }
		}


		public RelayCommand LoggearCommand { get; }
        public LoginWindowVM() 
		{
			EmpleadoActual = null;
            this.servicioApi = new ServicioApiRest();
			ListaEmpleados = this.servicioApi.EmployeesGetAll();

			LoggearCommand = new RelayCommand(ComprobarDatos);
		}

		public void ComprobarDatos()
		{
			foreach (Employees empleado in ListaEmpleados)
			{
                if (empleado.EmployeeName.Equals(Usuario) && empleado.EmployeePassword.Equals(Contraseña))
				{
					EmpleadoActual = empleado;
                    WeakReferenceMessenger.Default.Send(new EmpleadoLoggeadoMessage(EmpleadoActual));
                }
			}
            if (EmpleadoActual == null)
            {
                MessageBoxResult result = MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
