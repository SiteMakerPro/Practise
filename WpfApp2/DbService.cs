using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2
{
    internal class DbService
    {
        // Строка подключения к базе данных MySQL
        // Содержит все параметры: сервер (у вас такой же), БД (tompsons_studN - N номер по журналу - 01, 04, 13...), логин (как имя БД), пароль (ваш) и кодировку
        public static string connectionString = "server=tompsons.beget.tech;user=tompsons_stud07;database=tompsons_stud07;password=54GDRmnscS;CharSet=utf8mb4;";

        // Метод для создания и открытия подключения к БД
        public static MySqlConnection GetConnection()
        {
            // Новый объект подключения с использованием строки подключения
            MySqlConnection connection = new MySqlConnection(connectionString);
            // Открываем соединение с базой данных
            connection.Open();
            // Возвращаем готовое подключение
            return connection;
        }

        // Универсальный метод для выполнения SQL-запросов, которые НЕ возвращают данные
        // (INSERT, UPDATE, DELETE) с использованием параметров для безопасности
        public static int ExecuteNonQueryWithParameters(string query, Dictionary<string, object> parameters)
        {
            // Количество затронутых строк
            int rowsAffected = 0;
            // using обеспечивает автоматическое закрытие соединения и команды
            using (MySqlConnection connection = GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Добавляем параметры в команду для защиты от SQL-инъекций
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                // Выполняем запрос и получаем количество обработанных строк
                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        // Универсальный метод для получения данных с возможностью преобразования
        public static List<T> GetData<T>(string query, Func<MySqlDataReader, T> mapFunction)
        {
            // Список для хранения результата
            List<T> data = new List<T>();
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Читаем построчно, пока есть данные
                    while (reader.Read())
                    {
                        // Преобразуем текущую строку в объект типа T с помощью переданной функции
                        data.Add(mapFunction(reader));
                    }
                }
            }
            return data;
        }

        // Метод для выполнения скалярных запросов (возвращающих одно значение)
        // Например: SELECT COUNT(*) FROM table
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            object result = null;
            using (MySqlConnection connection = GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                result = command.ExecuteScalar();
            }
            return result;
        }

        // Метод для аутентификации пользователя по логину и паролю
        public static Models.users AuthenticateUser(string login, string password)
        {
            try
            {
                string query = "SELECT * FROM users WHERE login = @login AND password = @password";

                using (MySqlConnection connection = GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Models.users
                            {
                                IdU = reader.GetInt32("IdU"),
                                IdR = reader.GetInt32("IdR"),
                                Login = reader.GetString("Login"),
                                Password = reader.GetString("Password"),
                                Lastname = reader.GetString("Lastname"),
                                Firstname = reader.GetString("Firstname"),
                                Patronymic = reader.GetString("Patronymic"),
                                Phone = reader.GetString("Phone"),
                                Email = reader.GetString("Email")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка аутентификации: {ex.Message}");
            }

            return null;
        }

        // Метод для регистрации нового пользователя
        public static bool RegisterUser(Models.users newUser)
        {
            try
            {
                // Проверка существующего логина
                string checkQuery = "SELECT COUNT(*) FROM users WHERE login = @login";
                using (MySqlConnection connection = GetConnection())
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@login", newUser.Login);
                    long count = (long)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return false;
                    }
                }

                // Регистрация нового пользователя
                string insertQuery = @"INSERT INTO users (IdR, login, password, lastname, firstname, patronymic, phone, email) 
                                   VALUES (@role, @login, @password, @lastname, @firstname, @patronymic, @phone, @email)";

                var parameters = new Dictionary<string, object>
                {
                    ["@role"] = 2,
                    ["@login"] = newUser.Login,
                    ["@password"] = newUser.Password,
                    ["@lastname"] = "",
                    ["@firstname"] = "",
                    ["@patronymic"] = "",
                    ["@phone"] = "",
                    ["@email"] = ""
                };

                ExecuteNonQueryWithParameters(insertQuery, parameters);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }

        // Метод для получения всех пользователей из БД
        public static List<users> GetAllUsers()
        {
            string query = "SELECT * FROM users ORDER BY IdU";

            // Используем универсальный метод GetData с лямбда-выражением для создания объектов User
            return GetData(query, reader => new users
            {
                IdU = reader.GetInt32("IdU"),
                IdR = reader.GetInt32("IdR"),
                Lastname = reader.GetString("Lastname"),
                Firstname = reader.GetString("Firstname"),
                Patronymic = reader.GetString("Patronymic"),
                Phone = reader.GetString("Phone"),
                Email = reader.GetString("Email")
            });
        }

        public static List<goods> GetAllGoods()
        {
            string query = "SELECT * FROM goods ORDER BY IdG";

            // Используем универсальный метод GetData с лямбда-выражением для создания объектов User
            return GetData(query, reader => new goods
            {
                IdG = reader.GetInt32("IdG"),
                Name = reader.GetString("Name"),
                IdCa = reader.GetInt32("IdCa"),
                Price = reader.GetDecimal("Price"),
                Img = reader.IsDBNull(reader.GetOrdinal("Img")) ? null : (byte[])reader["Img"]
            });
        }

        public static List<categories> GetAllCategories()
        {
            string query = "SELECT * FROM categories ORDER BY IdCa";

            return GetData(query, reader => new categories
            {
                IdCa = reader.GetInt32("IdCa"),
                Name = reader.GetString("Name")
            });
        }

        // Метод для обновления данных пользователя
        public static bool UpdateEmployee(users user)
        {
            try
            {
                string query = @"UPDATE users 
                            SET IdR = @idR, 
                                Lastname = @lastname, 
                                Firstname = @firstname, 
                                Patronymic = @patronymic, 
                                Phone = @email 
                            WHERE IdU = @id";

                var parameters = new Dictionary<string, object>
                {
                    ["@id"] = user.IdU,
                    ["@idR"] = user.IdR,
                    ["@lastname"] = user.Lastname,
                    ["@firstname"] = user.Firstname,
                    ["@patronymic"] = user.Patronymic,
                    ["@phone"] = user.Phone,
                    ["@email"] = user.Login,
                };

                ExecuteNonQueryWithParameters(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления пользователя: {ex.Message}");
                return false;
            }
        }

        //// Метод для удаления пользователя по ID
        //public static bool DeleteUser(int userId)
        //{
        //    try
        //    {
        //        string query = "DELETE FROM users WHERE id = @id";
        //        var parameters = new Dictionary<string, object>
        //        {
        //            ["@id"] = userId
        //        };

        //        ExecuteNonQueryWithParameters(query, parameters);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}");
        //        return false;
        //    }
        //}

        //public static List<News> GetAllNews()
        //{
        //    string query = "SELECT * FROM news ORDER BY id DESC";
        //    return GetData(query, reader => new News
        //    {
        //        Id = reader.GetInt32("id"),
        //        Title = reader.GetString("title"),
        //        Description = reader.GetString("description"),
        //        ImagePath = reader.GetString("image_path")
        //    });
        //}

        //public static bool AddNews(News news)
        //{
        //    try
        //    {
        //        string query = @"INSERT INTO news (title, description, image_path) 
        //                    VALUES (@title, @description, @image_path)";

        //        var parameters = new Dictionary<string, object>
        //        {
        //            ["@title"] = news.Title,
        //            ["@description"] = news.Description,
        //            ["@image_path"] = news.ImagePath
        //        };

        //        ExecuteNonQueryWithParameters(query, parameters);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка добавления новости: {ex.Message}");
        //        return false;
        //    }
        //}

        //public static bool UpdateNews(News news)
        //{
        //    try
        //    {
        //        string query = @"UPDATE news 
        //                    SET title = @title, 
        //                        description = @description, 
        //                        image_path = @image_path 
        //                    WHERE id = @id";

        //        var parameters = new Dictionary<string, object>
        //        {
        //            ["@id"] = news.Id,
        //            ["@title"] = news.Title,
        //            ["@description"] = news.Description,
        //            ["@image_path"] = news.ImagePath
        //        };

        //        ExecuteNonQueryWithParameters(query, parameters);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка обновления новости: {ex.Message}");
        //        return false;
        //    }
        //}

        //public static bool DeleteNews(int newsId)
        //{
        //    try
        //    {
        //        string query = "DELETE FROM news WHERE id = @id";
        //        var parameters = new Dictionary<string, object>
        //        {
        //            ["@id"] = newsId
        //        };

        //        ExecuteNonQueryWithParameters(query, parameters);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка удаления новости: {ex.Message}");
        //        return false;
        //    }
        //}
    }
}
