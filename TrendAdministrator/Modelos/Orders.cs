using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class Orders : ObservableObject
    {
		private int idOrder;

        [JsonProperty("idOrder")]
        public int IdOrder
		{
			get { return idOrder; }
            set { SetProperty(ref idOrder, value); }
        }

		private Clients client;

        [JsonProperty("idClient")]
        public Clients Client
		{
			get { return client; }
            set { SetProperty(ref client, value); }
        }

		private Employees employee;

        [JsonProperty("idEmployee")]
        public Employees Employee
		{
			get { return employee; }
            set { SetProperty(ref employee, value); }
        }

		private bool managed;

        [JsonProperty("managed")]
        public bool Managed
		{
			get { return managed; }
            set { SetProperty(ref managed, value); }
        }

		private string orderDate;

        [JsonProperty("orderDate")]
        public string OrderDate
		{
			get { return orderDate; }
            set { SetProperty(ref orderDate, value); }
        }

		private ObservableCollection<OrderDetails> orderDetails;

        [JsonProperty("ordersdetailsCollection")]
        public ObservableCollection<OrderDetails> OrderDetails
        {
			get { return orderDetails; }
			set { SetProperty(ref orderDetails, value); }
		}


		public Orders() { }

		public Orders(int idOrder, Clients client,
                      Employees employee, bool managed, string orderDate, ObservableCollection<OrderDetails> orderDetails)
		{
			IdOrder = idOrder;
			Client = client;
			Employee = employee;
			Managed = managed;
			OrderDate = orderDate;
			OrderDetails = orderDetails;
		}
	}
}
