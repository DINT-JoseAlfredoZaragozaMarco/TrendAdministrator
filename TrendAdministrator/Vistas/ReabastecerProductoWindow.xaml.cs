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
    /// Lógica de interacción para ReabastecerProductoWindow.xaml
    /// </summary>
    public partial class ReabastecerProductoWindow : Window
    {
        private ReabastecerProductosVM vm;
        public ReabastecerProductoWindow()
        {
            InitializeComponent();
            this.vm = new ReabastecerProductosVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
