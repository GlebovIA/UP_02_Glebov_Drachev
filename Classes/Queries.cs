using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Classes
{
    public class Queries
    {
        public static string CreateConnection(string login, string password) => $"Select * from Users where login = '{login}' and password = '{password}'";
    }
}
