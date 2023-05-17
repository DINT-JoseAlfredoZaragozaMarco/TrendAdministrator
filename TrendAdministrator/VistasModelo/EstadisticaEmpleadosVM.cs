using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class EstadisticaEmpleadosVM : ObservableObject
    {
        private ServicioApiRest servicioApiRest;
        public EstadisticaEmpleadosVM()
        {
            this.servicioApiRest = new ServicioApiRest();
        }
    }
}
