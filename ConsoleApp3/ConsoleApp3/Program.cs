using System;
using System.Data.SqlClient;

namespace MyProgram
{
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