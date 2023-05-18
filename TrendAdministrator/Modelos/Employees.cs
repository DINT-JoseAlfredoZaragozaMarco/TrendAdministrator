using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class Employees : ObservableObject
    {
		private int idEmployee;

        [JsonProperty("idEmployee")]
        public int IdEmployee
		{
			get { return idEmployee; }
            set { SetProperty(ref idEmployee, value); }
        }

		private int totalPedidosGestionadosMes;
		[JsonIgnore]
		public int TotalPedidosGestionadosMes
        {
			get { return totalPedidosGestionadosMes; }
			set { SetProperty(ref totalPedidosGestionadosMes, value); }
		}


		private string employeeName;

        [JsonProperty("employeeName")]
        public string EmployeeName
		{
			get { return employeeName; }
            set { SetProperty(ref employeeName, value); }
        }

		private string surnames;

        [JsonProperty("surnames")]
        public string Surnames
		{
			get { return surnames; }
            set { SetProperty(ref surnames, value); }
        }

		private string email;

        [JsonProperty("email")]
        public string Email
		{
			get { return email; }
            set { SetProperty(ref email, value); }
        }

		private string employeePassword;

        [JsonProperty("employeePassword")]
        public string EmployeePassword
		{
			get { return employeePassword; }
            set { SetProperty(ref employeePassword, value); }
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

		public Employees() 
		{
			IdEmployee = 0;
			TotalPedidosGestionadosMes = 0;
		}

		public Employees(int idEmployee, string employeeName, string surnames, 
						 string email, string employeePassword, string phone, 
						 string country, string location, string address)
		{
			TotalPedidosGestionadosMes = 0;
			IdEmployee = idEmployee;
			EmployeeName = employeeName;
			Surnames = surnames;
			Email = email;
			EmployeePassword = employeePassword;
			Phone = phone;
			Country = country;
			Location = location;
			Address = address;
		}
	}
}
