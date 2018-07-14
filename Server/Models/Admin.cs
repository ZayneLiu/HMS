using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Admin
    {
        public string Username { get; set; }
        public string Pwd { get; set; }

        public static Admin GetAdminByID(string username)
        {
            var command = new SqlCommand("select * from Admin where Username=@Username");
            command.Parameters.AddWithValue("@Username", username);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            return new Admin()
            {
                Username = row["Username"].Value.ToString(),
                Pwd = row["Pwd"].Value.ToString()
            };
        }
    }
}
