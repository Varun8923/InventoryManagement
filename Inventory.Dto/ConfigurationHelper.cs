using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Dto
{
    public class ConfigurationHelpers
    {
        // private readonly IConfiguration _configuration;

        //public ConfigurationHelpers(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        string DefaultConnection = "Server=.\\MSSQLSERVER01;Database=InventoryManagement;Trusted_Connection=True;MultipleActiveResultSets=True;";
        public string GetSetting(string key)
        {
            return DefaultConnection;
        }
    }
}
