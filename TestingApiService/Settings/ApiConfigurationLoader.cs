﻿namespace TestingApiService.Settings
{
    public class ApiConfigurationLoader
    {
        public static void LoadConfiguration()
        {
            ApiSettings.PauseBetweenFailures = 3;
            ApiSettings.ClientTimeoutSeconds = 15;
            ApiSettings.BaseUrl = "http://localhost:3000/";
            ApiSettings.MaxRetryAttempts = 3;
            ApiSettings.EnableBDDLogging = true;
            ApiSettings.EnableToastMessages = true;
            ApiSettings.MysqlConnectionString = "Server=mariadb; database=testingapi; UID=root; password=root";
            ApiSettings.PostreeSqlConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=testingapi";
        }

    }
}
