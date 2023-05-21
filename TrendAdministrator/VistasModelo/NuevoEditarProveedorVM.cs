using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;

namespace TrendAdministrator.VistasModelo
{
    class NuevoEditarProveedorVM : ObservableObject
    {
        private Suppliers proveedorActual;

        public Suppliers ProveedorActual
        {
            get { return proveedorActual; }
            set { proveedorActual = value; }
        }

        public NuevoEditarProveedorVM()
        {
            ProveedorActual = WeakReferenceMessenger.Default.Send<EnviarProveedorMessage>();
            if (ProveedorActual == null)
            {
                ProveedorActual = new Suppliers();
            }


        }
    }
}
