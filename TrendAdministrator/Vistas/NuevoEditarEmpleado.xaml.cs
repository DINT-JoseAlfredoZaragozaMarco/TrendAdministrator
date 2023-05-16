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
using System.Windows.Shapes;
using TrendAdministrator.VistasModelo;

namespace TrendAdministrator.Vistas
{
    /// <summary>
    /// Lógica de interacción para NuevoEditarEmpleado.xaml
    /// </summary>
    public partial class NuevoEditarEmpleado : Window
    {
        private NuevoEditarEmpleadoVM vm;
        public NuevoEditarEmpleado()
        {
            InitializeComponent();
            this.vm = new NuevoEditarEmpleadoVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
