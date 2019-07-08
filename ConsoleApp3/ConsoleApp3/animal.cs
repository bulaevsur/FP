using System;
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
}
