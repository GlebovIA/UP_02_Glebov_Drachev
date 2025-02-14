using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace UP_02_Glebov_Drachev.Classes
{
    public class DBConnection
    {
        private static MySqlConnection Connection { get; set; }
        public static MySqlConnection CreateConnection(string login, string pwd)
        {
            try
            {
                if (login != "" & pwd != "")
                {
                    Connection = new MySqlConnection($"server= ;database=UP_02_Glebov_Drachev;user=root;pwd=");
                    return Connection;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить подключение к базе данных!");
                return null;
            }
        }
        public static void Disconnect()
        {
            Connection.Dispose();
        }
        public static MySqlConnection OpenConnection()
        {
            try
            {
                if (Connection != null)
                {
                    Connection.OpenAsync();
                    return Connection;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void CloseConnection()
        {
            Connection.Close();
            MySqlConnection.ClearPool(Connection);
        }
        public static MySqlDataReader Query(string sql)
        {
            return new MySqlCommand(sql, Connection).ExecuteReader();
        }
    }
}