namespace OrganicStore.Models
{
    public class ConnectionMod{
        public static string getConnectionString()
        {
            var connBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true);
            var configObj = connBuilder.Build();
            string connString = configObj.GetConnectionString("UserProfile");
            return connString;
        }
    }
}
