using MySql.Data.MySqlClient;
using System.Windows;

namespace UP_02_Glebov_Drachev.Classes
{
    public class DBConnection
    {
        private static MySqlConnection? Connection { get; set; }
        public static MySqlConnection? CreateConnection(string login, string pwd)
        {
            try
            {
                if (login != "" & pwd != "")
                {
                    Connection = new MySqlConnection($"server=127.0.0.1;database=UP02;user=root;pwd=;port=3306");
                    Connection.Open();
                    if (Query(Queries.CreateConnection(login, pwd)).HasRows)
                        return Connection;
                    else
                        MessageBox.Show("Неверный логин или пароль!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
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
        public static MySqlConnection? OpenConnection()
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
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            MySqlConnection.ClearPool(Connection);
        }
        public static MySqlDataReader Query(string sql)
        {
            return new MySqlCommand(sql, Connection).ExecuteReader();
        }
    }
}