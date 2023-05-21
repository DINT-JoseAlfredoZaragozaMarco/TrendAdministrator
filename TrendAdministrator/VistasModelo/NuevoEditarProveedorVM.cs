using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class NuevoEditarProveedorVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;

        private Suppliers proveedorActual;
        public Suppliers ProveedorActual
        {
            get { return proveedorActual; }
            set { proveedorActual = value; }
        }

        public RelayCommand AceptarCambiosCommand { get; }
        public NuevoEditarProveedorVM()
        {
            ProveedorActual = WeakReferenceMessenger.Default.Send<EnviarProveedorMessage>();
            if (ProveedorActual == null)
            {
                ProveedorActual = new Suppliers();
            }

            this.servicioApiRest = new ServicioApiRest();

            AceptarCambiosCommand = new RelayCommand(AceptarCambios);
        }

        public void AceptarCambios()
        {
            if (ProveedorActual.IdSupplier == 0)
            {
                this.servicioApiRest.SupplierPost(ProveedorActual);
            }
            else
            {
                this.servicioApiRest.SupplierPut(ProveedorActual);
            }
        }
    }
}
