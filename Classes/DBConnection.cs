using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace UP_02_Glebov_Drachev.Classes
{
    public static class DBConnection
    {
        public static MySqlConnection? Connection;

        public static MySqlConnection? CreateConnection(string login, string pwd)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(pwd))
                {
                    Connection = new MySqlConnection("server=127.0.0.1;database=UP02;user=root;pwd=;port=3307");
                    Connection.Open();

                    using (MySqlDataReader reader = Query(Queries.CreateConnection(login, pwd)))
                    {
                        if (reader.Read())  // Проверяем, есть ли хотя бы одна строка
                        {
                            CloseConnection();
                            return Connection;
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Логин и пароль не могут быть пустыми!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить подключение к базе данных!\nОшибка: {ex.Message}",
                    "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static MySqlConnection? OpenConnection()
        {
            try
            {
                if (Connection != null && Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    return Connection;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия соединения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static void CloseConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
                MySqlConnection.ClearPool(Connection);
            }
        }

        public static MySqlDataReader Query(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            return cmd.ExecuteReader();
        }
    }
}
