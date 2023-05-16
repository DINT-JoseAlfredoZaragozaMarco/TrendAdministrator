using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class OrderDetailsPK : ObservableObject
    {
		private int idOrder;

        [JsonProperty("idOrder")]
        public int IdOrder
		{
			get { return idOrder; }
			set { SetProperty(ref idOrder, value); }
		}

		private int idProduct;

        [JsonProperty("idProduct")]
        public int IdProduct
		{
			get { return idProduct; }
			set { SetProperty(ref idProduct, value); }
		}

		public OrderDetailsPK() { }

		public OrderDetailsPK(int idOrder, int idProduct)
		{
			IdOrder = idOrder;
			IdProduct = idProduct;
		}
    }
}
