using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;

namespace TrendAdministrator.VistasModelo
{
    class DetallesPedidoVM : ObservableObject
    {
        private ObservableCollection<OrderDetails> detallesPedido;

        public ObservableCollection<OrderDetails> DetallesPedido
        {
            get { return detallesPedido; }
            set { SetProperty(ref detallesPedido, value); }
        }

        private Orders pedidoActual;

        public Orders PedidoActual
        {
            get { return pedidoActual; }
            set { SetProperty(ref pedidoActual, value); }
        }

        public DetallesPedidoVM()
        {
            PedidoActual = WeakReferenceMessenger.Default.Send<EnviarPedidoMessage>();
            DetallesPedido = PedidoActual.OrderDetails;
        }
    }
}
