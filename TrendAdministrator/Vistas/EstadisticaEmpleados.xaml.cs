using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrendAdministrator.VistasModelo;

namespace TrendAdministrator.Vistas
{
    /// <summary>
    /// Lógica de interacción para EstadisticaEmpleados.xaml
    /// </summary>
    public partial class EstadisticaEmpleados : UserControl
    {
        private EstadisticaEmpleadosVM vm;
        public EstadisticaEmpleados()
        {
            InitializeComponent();
            this.vm = new EstadisticaEmpleadosVM();
            this.DataContext = vm;
        }
    }
}
