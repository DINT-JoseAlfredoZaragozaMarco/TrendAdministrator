﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Modelos;

namespace TrendAdministrator.Servicios
{
    class ServicioApiRest
    {

        // Productos

        public ObservableCollection<Products> ProductsGetAll()
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("products", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Products>>(response.Content);
        }

        public void ProductsPost(Products product)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("products", Method.Post);

            string data = JsonConvert.SerializeObject(product);
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
        }

        public void ProductsPut(Products product)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("products", Method.Put);

            string data = JsonConvert.SerializeObject(product);
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
        }

        public void ProductsDelete(int id)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("products/" + id, Method.Delete);
            RestResponse response = client.Execute(request);
        }

        // Proveedores

        public ObservableCollection<Suppliers> SuppliersGetAll()
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("suppliers", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Suppliers>>(response.Content);
        }


        // Empleados

        public ObservableCollection<Employees> EmployeesGetAll()
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("employees", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Employees>>(response.Content);
        }

        public void EmployeesPost(Employees employee)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("employees", Method.Post);

            string data = JsonConvert.SerializeObject(employee);
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
        }

        public void EmployeesPut(Employees employee)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("employees", Method.Put);

            string data = JsonConvert.SerializeObject(employee);
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
        }

        public void EmployeesDelete(int id)
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("employees/" + id, Method.Delete);
            RestResponse response = client.Execute(request);
        }

        // Pedidos

        public ObservableCollection<Orders> OrdersGetAll()
        {
            RestClient client = new RestClient(Properties.Settings.Default.Endpoint);
            RestRequest request = new RestRequest("orders", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Orders>>(response.Content);
        }
    }
}