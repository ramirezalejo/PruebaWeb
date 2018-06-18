using Core.Storage;
using Core.Storage.Implement.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaWeb.Models
{
    public class DataStorageModel
    {

        public DataStorageModel(int id, IConnection connection, ICommand command)
        {
            this.Id = id;
            this.Connecion = connection;
            this.Command = command;
        }


        public int Id { get; set; }

        public IConnection Connecion { get; set; }

        public ICommand Command { get; set; }

    }
}