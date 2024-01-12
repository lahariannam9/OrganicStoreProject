using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrganicStore.Models;
using System.Collections.Generic;

namespace OrganicStore.Controllers
{
    public class ProductController : Controller
    {
        public bool product(int count, string name)
        {
            SqlConnection conn = new SqlConnection(ConnectionMod.getConnectionString());
            Console.WriteLine(name + " " + count);
            string query = $"SELECT stock FROM fruitsInventory WHERE name = '{name}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            int stockNumber = result != null ? Convert.ToInt32(result) : 0;
            if(count < stockNumber)
            {
                int newStock = stockNumber - 1;
                string query2 = $"UPDATE fruitsInventory SET stock = {newStock} WHERE name = '{name}'";
                // string query3 = "insert into cartTable(name, productCount) values('" + name + "', '" + count + "')";
                //string query3 = $"INSERT INTO cartTable (name, productCount) VALUES ('" + name + "', '" + 1 + "') ON DUPLICATE KEY UPDATE productCount = productCount + 1";
                string query3 = $@"
    MERGE INTO cartTable AS target
    USING (SELECT '{name}' AS name) AS source
    ON target.name = source.name
    WHEN MATCHED THEN
        UPDATE SET target.productCount= target.productCount + 1
    WHEN NOT MATCHED THEN
        INSERT (name, productCount) VALUES (source.name, 1);";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                SqlCommand cmd3 = new SqlCommand(query3, conn);
                int rows = cmd2.ExecuteNonQuery();
                int rows2 = cmd3.ExecuteNonQuery();
                return true;
            }
            return false;                     
        }
    }
}
