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
    /// Lógica de interacción para DetallesPedido.xaml
    /// </summary>
    public partial class DetallesPedido : UserControl
    {
        private DetallesPedidoVM vm;
        public DetallesPedido()
        {
            InitializeComponent();
            this.vm = new DetallesPedidoVM();
            this.DataContext = vm;
        }
    }
}
