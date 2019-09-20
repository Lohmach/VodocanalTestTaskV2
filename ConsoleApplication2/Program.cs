using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VodokanalTestTask
{
    class Clodes
    {
        public int Id;
    }

    class Outerwear : Clodes
    {
        public string name;
        public int size;
        public int height;
    }

    class Footwear : Clodes
    {
        public string name;
        public int size;
    }

    struct BD
    {
        public List<Outerwear> table_1;
        public List<Footwear> table_2;
    }

    class Program
    {
        static string[] type_outerwear = { "куртка утеплённая", "куртка для руководителя", "жилет защитный" };
        static string[] type_footwear = { "ботинки кирзовые", "ботинки мужские утеплённые" };

        static int id_counter = 0;


        static void Main(string[] args)
        {
            List<Outerwear> BD_table1 = new List<Outerwear>();
            List<Footwear> BD_table2 = new List<Footwear>();


            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                init(BD_table1, BD_table2, rnd);

            }
            Console.WriteLine("Вывод всех элементов");
            write_all(BD_table1, BD_table2);
            Console.WriteLine("___________________________________________");


            Console.WriteLine("Вывод элемента с id = 3");
            writer(found_for_id(3, BD_table1, BD_table2)[0]);
            Console.WriteLine("___________________________________________");

            Console.WriteLine("Вывод элементов c size > 40, сортировка по возрастанию");
            List<object> sortSize = found_for_size(40, BD_table1, BD_table2);
            for(int i = 0; i < sortSize.Count; i++) { writer(sortSize[i]); }
            Console.WriteLine("___________________________________________");

            Console.WriteLine("Вывод элементов по имени \"жилет защитный\", сортировка по убыванию размера:");
            List<object> sort_name1 = found_for_name("жилет защитный", BD_table1, BD_table2);
            for (int i = 0; i < sort_name1.Count; i++) { writer(sort_name1[i]); }
            Console.WriteLine("___________________________________________");

            Console.WriteLine("Вывод элементов по имени \"ботинки кирзовые\", сортировка по убыванию размера:");
            List<object> sort_name2 = found_for_name("ботинки кирзовые", BD_table1, BD_table2);
            for (int i = 0; i < sort_name2.Count; i++) { writer(sort_name2[i]); }
            Console.WriteLine("___________________________________________");

            Console.WriteLine("Вывод элементов c height > 170, сортировка по убыванию ID");
            List<object> sortHeight = found_for_height(170, BD_table1, BD_table2);
            for (int i = 0; i < sortHeight.Count; i++) { writer(sortHeight[i]); }
            Console.WriteLine("___________________________________________");

            Console.WriteLine("\nНажмите любую кнопку, что бы закрыть консоль");
            Console.ReadKey();
        }



        static void init(List<Outerwear> table1, List<Footwear> table2, Random rnd)
        {
            if (rnd.Next(0, 101) % 2 == 1)
            {
                table1.Add(create_out(rnd));
            }

            else
            {
                table2.Add(create_foot(rnd));
            }
        }
        
        static Outerwear create_out(Random rnd)
        {
            Outerwear a = new Outerwear();
            a.Id = id_counter;
            id_counter++;
            a.name = type_outerwear[rnd.Next(0, 3)];
            a.size = rnd.Next(30, 50);
            a.height = rnd.Next(150, 200);
            return a;

        }
        
        static Footwear create_foot(Random rnd)
        {
            Footwear b = new Footwear();
            b.Id = id_counter;
            id_counter++;
            b.name = type_footwear[rnd.Next(0, 2)];
            b.size = rnd.Next(30, 50);
            return b;

        }
        
        static void write_all(List<Outerwear> table1, List<Footwear> table2) //вывод всех экземпляров
        {
            for (int i = 0; i < table1.Count; i++)
            {
                Console.WriteLine("Id: {0}",table1[i].Id);
                Console.WriteLine("Название: {0}",table1[i].name);
                Console.WriteLine("Размер: {0}", table1[i].size);
                Console.WriteLine("Рост: {0}", table1[i].height);
                Console.WriteLine();
            }
            for (int i = 0; i < table2.Count; i++)
            {
                Console.WriteLine("Id: {0}", table2[i].Id);
                Console.WriteLine("Название: {0}", table2[i].name);
                Console.WriteLine("Размер: {0}", table2[i].size);
                Console.WriteLine();
            }
        }
        
        static void writer(object a) //вывод одного элемента с приведением типа
        {
            if (a is Outerwear)
            {
                Outerwear out_a = (Outerwear)a;
                Console.WriteLine("Id: {0}", out_a.Id);
                Console.WriteLine("Название: {0}", out_a.name);
                Console.WriteLine("Размер: {0}", out_a.size);
                Console.WriteLine("Рост: {0}",out_a.height);
                Console.WriteLine();
            }
        
            if (a is Footwear)
            {
                Footwear foot_a = (Footwear)a;
                Console.WriteLine("Id: {0}", foot_a.Id);
                Console.WriteLine("Название: {0}", foot_a.name);
                Console.WriteLine("Размер: {0}", foot_a.size);
                Console.WriteLine();
            }
        }

        static List<object> found_for_id (int id, List<Outerwear> table1, List<Footwear> table2) //поиск по ID 
        {
            List<object> a = new List<object>();
            var clodes = from i in table1
                         where (i.Id == id)
                         select i;
            var clodes1 = from j in table2
                     where (j.Id == id)
                     select j;
            foreach (var k in clodes)  a.Add(k); 
            foreach (var k in clodes1) a.Add(k);

            return a;
        }

        static List<object> found_for_size(int size, List<Outerwear> table1, List<Footwear> table2) //поиск по размеру 
        {
            List<object> a = new List<object>();
            var clodes = from i in table1
                         where (i.size > size) // ставим нужное нам условие
                         orderby i.size //упорядочиваем по возрастанию, если нужно, то можно менять тип сортировки
                         select i;
            var clodes1 = from j in table2
                          where (j.size > size)
                          orderby j.size
                          select j;
            foreach (var k in clodes) a.Add((object)k);
            foreach (var k in clodes1) a.Add((object)k);

            return a;
        }

        static List<object> found_for_name( string name, List<Outerwear> table1, List<Footwear> table2) //поиск по названию 
        {
            List<object> a = new List<object>();
            var clodes = from i in table1
                         where i.name == name // ставим нужное нам условие
                         orderby i.size descending //сортировка по убыванию размера
                         select i;

            var clodes1 = from j in table2
                          where (j.name == name)
                          orderby j.size descending //сортировка по убыванию размера
                          select j;
            foreach (var k in clodes) a.Add((object)k);
            foreach (var k in clodes1) a.Add((object)k);

            return a;
        }

        static List<object> found_for_height(int heigth, List<Outerwear> table1, List<Footwear> table2) //поиск по росту 
        {
            List<object> a = new List<object>();
            var clodes = from i in table1
                         where i.height > heigth // ставим нужное нам условие
                         orderby i.Id descending //сортировка по убыванию ID
                         select i;

            foreach (var k in clodes) a.Add((object)k);

            return a;
        }
    }
}
