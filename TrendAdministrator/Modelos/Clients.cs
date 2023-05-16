using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class Clients : ObservableObject
    {
		private int id;

        [JsonProperty("id")]
        public int Id
		{
			get { return id; }
            set { SetProperty(ref id, value); }
        }

		private string username;

        [JsonProperty("username")]
        public string Username
		{
			get { return username; }
            set { SetProperty(ref username, value); }
        }

		private string email;

        [JsonProperty("email")]
        public string Email
		{
			get { return email; }
            set { SetProperty(ref email, value); }
        }

		private string clientPassword;

        [JsonProperty("clientPassword")]
        public string ClientPassword
		{
			get { return clientPassword; }
            set { SetProperty(ref clientPassword, value); }
        }

		private string phone;

        [JsonProperty("phone")]
        public string Phone
		{
			get { return phone; }
            set { SetProperty(ref phone, value); }
        }

		private string country;

        [JsonProperty("country")]
        public string Country
		{
			get { return country; }
            set { SetProperty(ref country, value); }
        }

		private string location;

        [JsonProperty("location")]
        public string Location
		{
			get { return location; }
            set { SetProperty(ref location, value); }
        }

		private string address;

        [JsonProperty("address")]
        public string Address
		{
			get { return address; }
            set { SetProperty(ref address, value); }
        }

		public Clients() { }

		public Clients(int id, string username, string email, 
					   string clientPassword, string phone, string country, 
					   string location, string address)
		{
			Id = id;
			Username = username;
			Email = email;
			ClientPassword = clientPassword;
			Phone = phone;
			Country = country;
			Location = location;
			Address = address;
		}
	}
}
