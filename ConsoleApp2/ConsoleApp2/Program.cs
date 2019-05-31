using System;
using System.Collections.Generic;
using System.IO;

namespace MyProgram
{
    class animal
    {
        public string color;
        public  string type;
        public int weight;
        public string s;
        public animal() { }
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
        public virtual string info()
        {
            return s = $"Цвет: {color} Тип: {type} Вес: {weight}";
        }
    }

    class mammal : animal
    {
        public string predator;
        public mammal() { }
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
        public override string info()
        {
            return s = $"Цвет: {color} Тип: {type} Вес: {weight} Хищник: {predator}";
        }
    }

    class wolf : mammal
    {
        public wolf() { }
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
            return s = $"Цвет: {color} Тип: {type} Вес: {weight} Хищник: {predator}";
        }
    }

    class dog : mammal
    {
        public dog() { }
        public dog (string c, string t, int w, string p) : base(c, t, w, p) { }
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
            return s = $"Цвет: {color} Тип: {type} Вес: {weight} Хищник: {predator}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<animal> lst = new List<animal>();
            mammal mam = new mammal("Неизвестен", "Семейство собачьих", 0, "Неизвестно");
            wolf wof = new wolf("Серый", "Дикий", 35, "Да");
            dog gav = new dog("Белый", "Лабрадор", 25, "Нет");
            lst.Add(mam);
            lst.Add(wof);
            lst.Add(gav);
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].info());
            }
            Console.ReadLine();
        }
    }
}