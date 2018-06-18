using Core.Storage.Implement.DataBase;
using PruebaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Core.Storage.Implement;
using Core.Storage;
using Core.Storage.Implement.File;
using Core.Storage.Entities;

namespace PruebaWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataStorageModel currentDataStorage;
        

        private List<DataStorageModel> CreateDataStorageList()
        {
            string connectionSetting = "SQLConnection";
            string inMemorySetting = "InMemoryRegionName";
            string pathFileSetting = "PathFile";

            IConnection sqlConnection = new SqlConnection(new System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings[connectionSetting]));
            IConnection inMemoryConnection = new InMemoryConnection(ConfigurationManager.AppSettings[inMemorySetting]);
            IConnection csvConnection = new CsvFileConnection(ConfigurationManager.AppSettings[pathFileSetting]);
            IConnection jsonConnection = new JsonFileConnection(ConfigurationManager.AppSettings[pathFileSetting]);
            IConnection xmlConnection = new XmlFileConnection(ConfigurationManager.AppSettings[pathFileSetting]);

            return new List<DataStorageModel>()
            {
                new DataStorageModel(1, sqlConnection, new DbCommand(sqlConnection as DbConnection)),
                new DataStorageModel(2, inMemoryConnection, new InMemoryCommand(inMemoryConnection as InMemoryConnection)),
                new DataStorageModel(3, csvConnection, new FileCommand(csvConnection as CsvFileConnection)),
                new DataStorageModel(4, jsonConnection, new FileCommand(jsonConnection as JsonFileConnection)),
                new DataStorageModel(5, xmlConnection, new FileCommand(xmlConnection as XmlFileConnection))
            };
        }


        private List<Category> GetAllCategories()
        {
            return currentDataStorage.Command.GetEntities<Category>();
        }

        private List<Product> GetAllProducts()
        {
            return currentDataStorage.Command.GetEntities<Product>();
        }

        private void LoadStorage(int idDataStorage)
        {
            currentDataStorage = CreateDataStorageList().FirstOrDefault(p => p.Id == idDataStorage);
        }

        private IndexModel LoadData(IndexModel model)
        {

            model.DataStorageList = CreateDataStorageList();
            if (currentDataStorage == null)
                currentDataStorage = model.DataStorageList.First();
            model.CategoriesList = GetAllCategories();
            model.ProductsList = GetAllProducts();
            return model;
        }

        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            model = LoadData(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            LoadStorage(model.IdDataStorageSelected);
            currentDataStorage.Command.InsertEntity(model.ProductSelected);
            model = LoadData(model);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}