using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class Suppliers : ObservableObject
    {
		private int idSupplier;

        [JsonProperty("idSupplier")]
        public int IdSupplier
		{
			get { return idSupplier; }
            set { SetProperty(ref idSupplier, value); }
        }

		private string company;

        [JsonProperty("company")]
        public string Company
		{
			get { return company; }
            set { SetProperty(ref company, value); }
        }

		private string phone;

        [JsonProperty("phone")]
        public string Phone
		{
			get { return phone; }
            set { SetProperty(ref phone, value); }
        }

		private string manager;

        [JsonProperty("manager")]
        public string Manager
		{
			get { return manager; }
            set { SetProperty(ref manager, value); }
        }

		public Suppliers() { }

		public Suppliers(int idSupplier, string company, string phone,
						 string manager)
		{
			IdSupplier = idSupplier;
			Company = company;
			Phone = phone;
            Manager = manager;
		}
	}
}
