using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Modelos
{
    class Products : ObservableObject
    {
        private int idProduct;

        [JsonProperty("idProduct")]
        public int IdProduct
        {
            get { return idProduct; }
            set { SetProperty(ref idProduct, value); }
        }

        private string product;

        [JsonProperty("product")]
        public string Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        private int stock;

        [JsonProperty("stock")]
        public int Stock
        {
            get { return stock; }
            set { SetProperty(ref stock, value); }
        }

        private string brand;

        [JsonProperty("brand")]
        public string Brand
        {
            get { return brand; }
            set { SetProperty(ref brand, value); }
        }

        private int totalVendido;

        [JsonIgnore]
        public int TotalVendido
        {
            get { return totalVendido; }
            set { SetProperty(ref totalVendido, value); }
        }

        private string productType;

        [JsonProperty("productType")]
        public string ProductType
        {
            get { return productType; }
            set { SetProperty(ref productType, value); }
        }

        private float price;

        [JsonProperty("price")]
        public float Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int size;

        [JsonProperty("size")]
        public int Size
        {
            get { return size; }
            set { SetProperty(ref size, value); }
        }

        private string gender;

        [JsonProperty("gender")]
        public string Gender
        {
            get { return gender; }
            set { SetProperty(ref gender, value); }
        }

        private Suppliers supplierCode;

        [JsonProperty("supplierCode")]
        public Suppliers SupplierCode
        {
            get { return supplierCode; }
            set { SetProperty(ref supplierCode, value); }
        }

        private string images;

        [JsonProperty("images")]
        public string Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }

        public Products() 
        {
            IdProduct = 0;
            Stock = 0;
            TotalVendido = 0;
            SupplierCode = new Suppliers();
        }

        public Products(int id, string product, int stock, string brand,
                        float price, int size, string gender,
                        Suppliers supplierCode, string images)
        {
            IdProduct = id;
            Product = product;
            Stock = stock;
            Brand = brand;
            Price = price;
            Size = size;
            Gender = gender;
            SupplierCode = supplierCode;
            Images = images;
            TotalVendido = 0;
        }

        public Products(string product, string brand,
                        float price, int size, string gender,
                        Suppliers supplierCode, string images)
        {
            IdProduct = 0;
            Product = product;
            Stock = 0;
            Brand = brand;
            Price = price;
            Size = size;
            Gender = gender;
            SupplierCode = supplierCode;
            Images = images;
            TotalVendido = 0;
        }
    }
}
