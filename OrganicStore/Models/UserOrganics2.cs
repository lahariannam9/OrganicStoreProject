using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicStore.Models
{
    [Table("UserOrganics", Schema = "configuration")]
    public class UserOrganics2
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string username { get; set; }
        [Required]
        [MaxLength(50)]
        public string email { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }

         public int saveUserDetails()
         {
            SqlConnection conn = new SqlConnection(ConnectionMod.getConnectionString());
            string query = "insert into UserOrganics2(username, email, password) values('" + username + "', '" + email + "','" + password + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return 1;

        }
        /* public int validateUserDetails()
         {
             SqlConnection conn = new SqlConnection(ConnectionMod.getConnectionString());
             string query = "SELECT COUNT(*) FROM UserOrganics2 WHERE username = '{username}' AND password = '{password}'";
             SqlCommand cmd = new SqlCommand(query, conn);
             conn.Open();
             int rowsAffected = (int)cmd.ExecuteScalar();
             conn.Close();
             return rowsAffected;

         }

         public class User
 {
     public int UserId { get; set; }
     public string Username { get; set; }
     // Other user properties...

     public virtual Cart Cart { get; set; }
     public virtual ICollection<Order> Orders { get; set; }
 }
  */

    }
}