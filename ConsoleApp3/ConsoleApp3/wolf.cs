using System.Data.SqlClient;

namespace MyProgram
{
    class wolf:mammal
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
}
