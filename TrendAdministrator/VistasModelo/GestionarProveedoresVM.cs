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
    class GestionarProveedoresVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;
        private ServicioNavegacion servicioNavegacion;

        private ObservableCollection<Suppliers> proveedores;
        public ObservableCollection<Suppliers> Proveedores
        {
            get { return proveedores; }
            set { SetProperty(ref proveedores, value); }
        }

        private Suppliers proveedorSeleccionado;

        public Suppliers ProveedorSeleccionado
        {
            get { return proveedorSeleccionado; }
            set { SetProperty(ref proveedorSeleccionado, value); }
        }

        public RelayCommand NuevoProveedorCommand { get; }
        public RelayCommand EditarProveedorCommand { get; }
        public RelayCommand EliminarProveedorCommand { get; }
        public GestionarProveedoresVM()
        {
            this.servicioApiRest = new ServicioApiRest();
            this.servicioNavegacion = new ServicioNavegacion();

            NuevoProveedorCommand = new RelayCommand(AñadirProveedor);
            EditarProveedorCommand = new RelayCommand(EditarProveedor);

            CargarProveedores();

            WeakReferenceMessenger.Default.Register<GestionarProveedoresVM, EnviarProveedorMessage>(this, (r, m) =>
            {
                if (!m.HasReceivedResponse)
                {
                    m.Reply(r.ProveedorSeleccionado);
                }
            });
        }

        public void CargarProveedores()
        {
            Proveedores = this.servicioApiRest.SuppliersGetAll();
        }

        public void AñadirProveedor()
        {
            ProveedorSeleccionado = new Suppliers();
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarProveedor();
            if ((bool)resultado)
            {
                CargarProveedores();
            }
        }

        public void EditarProveedor()
        {
            bool? resultado = this.servicioNavegacion.CargarNuevoEditarProveedor();
            if ((bool)resultado)
            {
                CargarProveedores();
            }
        }
    }
}
