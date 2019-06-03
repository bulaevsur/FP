using System;
using System.Collections.Generic;
using System.IO;

namespace MyProgram
{
    /// <summary>
    /// Базовый класс, содержащий в себе набор основных переменных, набор свойств и виртуальную функцию
    /// </summary>
    class animal
    {
        public string color;
        public  string type;
        public int weight;
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
        /// <summary>
        /// Виртуальная функция, формирующая строку с информацией о сущности
        /// </summary>
        /// <returns></returns>
        public virtual string info()
        {
            return $"Цвет: {color} Тип: {type} Вес: {weight}";
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
        /// <summary>
        /// Переопределённая виртуальная функция, добавляет при выводе параметр "Хищник"
        /// </summary>
        /// <returns></returns>
        public override string info()
        {
            return base.info() + $" Хищник: {predator}";
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
            return base.info();
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
            return base.info();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mam = new mammal("Неизвестен", "Семейство собачьих", 0, "Неизвестно");
            var wof = new wolf("Серый", "Дикий", 35, "Да");
            var gav = new dog("Белый", "Лабрадор", 25, "Нет");
            var lst = new List<animal>() { mam, wof, gav };
            foreach(var s in lst)
            {
                Console.WriteLine(s.info());
            }
            Console.ReadLine();
        }
    }
}