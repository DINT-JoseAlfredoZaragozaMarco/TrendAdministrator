using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para GestionEmpleados.xaml
    /// </summary>
    public partial class GestionEmpleados : UserControl
    {
        private GestionEmpleadosVM vm;
        public GestionEmpleados()
        {
            InitializeComponent();
            vm = new GestionEmpleadosVM();
            this.DataContext = vm;
        }
    }
}
