using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class OrderDetails : ObservableObject
    {

		private OrderDetailsPK orderDetailsPK;

        [JsonProperty("ordersdetailsPK")]
        public OrderDetailsPK OrderDetailsPK
        {
			get { return orderDetailsPK; }
			set { SetProperty(ref orderDetailsPK, value); }
		}

		private Products product;

        [JsonProperty("products")]
        public Products Product
		{
			get { return product; }
			set { SetProperty(ref product, value); }
		}

		private int amount;

        [JsonProperty("amount")]
        public int Amount
		{
			get { return amount; }
			set { SetProperty(ref amount, value); }
		}

		public OrderDetails() { }

		public OrderDetails(OrderDetailsPK orderDetailsPK, Products idProduct, int amount)
		{
            OrderDetailsPK = orderDetailsPK;
            Product = idProduct;
			Amount = amount;
		}
    }
}
