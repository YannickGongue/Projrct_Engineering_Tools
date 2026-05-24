using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EngineeringToolsCV_1.Views
{
    public class AppSetting
    {
        private Configuration Config;
        private string SectionName;
        public AppSetting()
        {
            Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SectionName = "connectionStrings";
        }

        public string GetConnectionString(string key)
        {
            return Config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void saveConnectionString(string Key, string value)
        {
            Config.ConnectionStrings.ConnectionStrings[Key].ConnectionString = value;
            Config.ConnectionStrings.ConnectionStrings[Key].ProviderName="System.Data.SqlClient";
            Config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(SectionName);
        }
    }
}
