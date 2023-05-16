using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TrendAdministrator.Vistas;

namespace TrendAdministrator.Servicios
{
    class ServicioNavegacion
    {
        public ServicioNavegacion() { }

        public UserControl CargarListaPedidos()
        {
            return new GestionPedidos();
        }

        public UserControl CargarEstadisticaEmpleados()
        {
            return new EstadisticaEmpleados();
        }

        public UserControl CargarGestionEmpleados()
        {
            return new GestionEmpleados();
        }

        public UserControl CargarGestionProductos()
        {
            return new GestionProductos();
        }

        public UserControl CargarDetallesPedido()
        {
            return new DetallesPedido();
        }

        public bool? CargarNuevoEditarProducto()
        {
            NuevoEditarProducto nuevoEditarProducto = new NuevoEditarProducto();
            return nuevoEditarProducto.ShowDialog();
        }

        public bool? CargarReabastecerProducto()
        {
            ReabastecerProductoWindow reabastecerProductoWindow = new ReabastecerProductoWindow();
            return reabastecerProductoWindow.ShowDialog();
        }

        public bool? CargarNuevoEditarEmpleado()
        {
            NuevoEditarEmpleado nuevoEditarEmpleado = new NuevoEditarEmpleado();
            return nuevoEditarEmpleado.ShowDialog();
        }

        public bool? CargarLogin()
        {
            LoginWindow loginWindow = new LoginWindow();
            return loginWindow.ShowDialog();
        }
    }
}
