using System.Data.SqlClient;

namespace MyProgram
{
    class dog:mammal
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
}
