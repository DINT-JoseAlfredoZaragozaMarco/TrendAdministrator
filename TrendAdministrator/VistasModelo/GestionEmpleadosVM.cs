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
    class GestionEmpleadosVM : ObservableObject
    {
        private ServicioNavegacion servicioNavegacion;
        private ServicioApiRest servicioApiRest;
        private Employees empleadoSeleccionado;
        public Employees EmpleadoSeleccionado
        {
            get { return empleadoSeleccionado; }
            set { SetProperty(ref empleadoSeleccionado, value); }
        }

        private ObservableCollection<Employees> empleados;
        public ObservableCollection<Employees> Empleados
        {
            get { return empleados; }
            set { SetProperty(ref empleados, value); }
        }

        public RelayCommand EliminarEmpleadoCommand { get; }
        public RelayCommand ActualizarEmpleadoCommand { get; }
        public RelayCommand NuevoEmpleadoCommand { get; }

        public GestionEmpleadosVM()
        {
            WeakReferenceMessenger.Default.Register<GestionEmpleadosVM, EnviarEmpleadoMessage>(this, (r, m) =>
            {
                if (!m.HasReceivedResponse)
                {
                    m.Reply(r.EmpleadoSeleccionado);
                }
            });

            this.servicioApiRest = new ServicioApiRest();
            this.servicioNavegacion = new ServicioNavegacion();

            NuevoEmpleadoCommand = new RelayCommand(NuevoEmpleado);
            ActualizarEmpleadoCommand = new RelayCommand(ActualizarEmpleado);
            EliminarEmpleadoCommand = new RelayCommand(EliminarEmpleado);

            CargarEmpleados();
        }

        public void NuevoEmpleado()
        {
            EmpleadoSeleccionado = new Employees();
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarEmpleado();
            if ((bool)resultado)
            {
                CargarEmpleados();
            }
        }

        public void ActualizarEmpleado()
        {
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarEmpleado();
            if ((bool)resultado)
            {
                CargarEmpleados();
            }
        }

        public void EliminarEmpleado()
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de dar de baja a este empleado?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.servicioApiRest.EmployeesDelete(EmpleadoSeleccionado.IdEmployee);
                CargarEmpleados();
            }
        }

        public void CargarEmpleados()
        {
            Empleados = this.servicioApiRest.EmployeesGetAll();
        }
    }
}
