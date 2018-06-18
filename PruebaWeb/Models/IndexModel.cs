using Core.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaWeb.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            CategoriesList = new List<Category>();
            ProductsList = new List<Product>();
            ProductSelected = new Product();
            DataStorageList = new List<DataStorageModel>();
        }

        public List<Category> CategoriesList { get; set; }

        public List<Product> ProductsList { get; set; }

        public List<DataStorageModel> DataStorageList { get; set; }

        public Product ProductSelected { get; set; }

        public int IdDataStorageSelected { get; set; }
    }
}