using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyProgram
{
    /// <summary>
    /// Базовый класс, содержащий в себе набор основных переменных, набор свойств и виртуальную функцию
    /// </summary>
    class animal
    {
        public int id;
        public string color;
        public string type;
        public int weight;
        public animal()
        {
            id = 0;
            color = "";
            type = "";
            weight = 0;
        }
        public animal(string c, string t, int w)
        {
            this.color = c;
            this.type = t;
            this.weight = w;
        }
        public string animal_color
        {
            get { return color; }
            set { color = value; }
        }
        public string animal_type
        {
            get { return type; }
            set { type = value; }
        }
        public int animal_weight
        {
            get { return weight; }
            set { weight = value; }
        }
        /// <summary>
        /// Виртуальная функция, формирующая строку с информацией о сущности
        /// </summary>
        /// <returns></returns>
        public virtual string info()
        {
            return $"Id: {id}    Type: {type}    Color: {color}    Weight: {weight}";
        }
        /// <summary>
        /// Виртуальная функция, сериализующая данные из базы данных
        /// </summary>
        /// <param name="reader"></param>
        public virtual void Serialize(SqlDataReader reader)
        {
            id = Convert.ToInt32(reader["Id"]);
            color = reader["color"].ToString();
            type = reader["type"].ToString();
            weight = Convert.ToInt32(reader["weight"]);
        }
    }

    class mammal : animal
    {
        public string predator;
        public mammal():base()
        {
            predator = "";
        }
        public mammal(string c, string t, int w, string p) : base(c, t, w)
        {
            this.predator = p;
        }
        public string mammal_color
        {
            get { return color; }
            set { color = value; }
        }
        public string mammal_type
        {
            get { return type; }
            set { type = value; }
        }
        public int mammal_weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string mammal_predator
        {
            get { return predator; }
            set { predator = value; }
        }
        /// <summary>
        /// Переопределённая виртуальная функция, добавляет при выводе параметр "Predator"
        /// </summary>
        /// <returns></returns>
        public override string info()
        {
            return base.info() + $"     Predator: {predator}";
        }
        /// <summary>
        /// Переопределённая виртуальная функция, добавляет к сериализации параметр "Predator"
        /// </summary>
        /// <param name="reader"></param>
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
            predator = reader["predator"].ToString();
        }
    }

    class wolf : mammal
    {
        public wolf() : base() { }
        public wolf(string c, string t, int w, string p) : base(c, t, w, p) { }
        public string wolf_color
        {
            get { return color; }
            set { color = value; }
        }
        public string wolf_type
        {
            get { return type; }
            set { type = value; }
        }
        public int wolf_weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string wolf_predator
        {
            get { return predator; }
            set { predator = value; }
        }
        public override string info()
        {
            return base.info();
        }
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
        }
    }

    class dog : mammal
    {
        public dog() : base() { }
        public dog(string c, string t, int w, string p) : base(c, t, w, p) { }
        public string dog_color
        {
            get { return color; }
            set { color = value; }
        }
        public string dog_type
        {
            get { return type; }
            set { type = value; }
        }
        public int dog_weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string dog_predator
        {
            get { return predator; }
            set { predator = value; }
        }
        public override string info()
        {
            return base.info();
        }
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
        }
    }
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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var wwdb = new WWDB();
                foreach (animal a in wwdb.GetList())
                {
                    Console.WriteLine(a.info());
                }
                wwdb.StopConnect();
                Console.ReadLine();
            }
            catch(SqlException sqle)
            {
                Console.WriteLine("\nОшибка при работе с базой данных. Проверьте корректность кода.\n" + sqle.ToString());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nСистемная ошибка. Проверьте корректность кода.\n" + e.ToString());
                Console.ReadLine();
            }
        }
    }
}