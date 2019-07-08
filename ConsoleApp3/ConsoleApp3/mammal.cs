using System.Data.SqlClient;

namespace MyProgram
{
    class mammal:animal
    {
        public string predator;
        public mammal() : base()
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
}
