using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyProgram
{
    class WWDB
    {
        private SqlConnection conn;
        /// <summary>
        /// Конструктор, проверяющий, установлено ли соединение
        /// </summary>
        public WWDB()
        {
            if (conn == null || conn.State == System.Data.ConnectionState.Closed)
            {
                Connect();
            }
            else
            {
                Console.WriteLine("Already connected");
            }
        }
        /// <summary>
        /// Метод, устанавливающий соединение с БД
        /// </summary>
        public void Connect()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\Users\Unknown\Documents\Visual Studio 2017\Projects\ConsoleApp3\ConsoleApp3\DBmain.mdf;Integrated Security=True");
            conn.Open();
        }
        /// <summary>
        /// Метод, прерывающий соединение с БД
        /// </summary>
        public void StopConnect()
        {
            conn.Close();
            conn.Dispose();
        }
        /// <summary>
        /// Метод, формирующий список объектов методом считывания данных из базы данных
        /// </summary>
        /// <returns></returns>
        public List<animal> GetList()
        {
            var anims = new List<animal>();
            using (SqlCommand command = new SqlCommand(@"SELECT Id, type, color, weight, predator FROM [DB_animals]", conn))
            {
                using (var reader = command.ExecuteReader())
                {
                    animal a = null;
                    while (reader.Read())
                    {
                        if (reader["type"].ToString() == "Wolf")
                        {
                            a = new wolf();
                        }
                        if (reader["type"].ToString() == "Dog")
                        {
                            a = new dog();
                        }
                        a.Serialize(reader);
                        anims.Add(a);
                    }
                }
            }
            return anims;
        }
    }
}
