using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class EstadisticaEmpleadosVM : ObservableObject
    {
        
        private ServicioApiRest servicioApiRest;

        private ObservableCollection<Employees> empleados;
        public ObservableCollection<Employees> Empleados
        {
            get { return empleados; }
            set { SetProperty(ref empleados, value); }
        }

        public EstadisticaEmpleadosVM()
        {
            this.servicioApiRest = new ServicioApiRest();
            Empleados = this.servicioApiRest.EmployeesGetAll();

            CalcularPedidosGestionados();
        }

        public void CalcularPedidosGestionados()
        {
            foreach (Employees empleado in Empleados)
            {
                empleado.TotalPedidosGestionadosMes = this.servicioApiRest.OrdersGetCountManagedByEmployee(empleado.IdEmployee);
            }
        }
    }
}
