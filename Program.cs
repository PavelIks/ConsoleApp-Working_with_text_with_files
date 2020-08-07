/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = File.ReadAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\1File1.txt", Encoding.Default); //считываем в массив строк
            Array.Sort(mass); // сразу сортируем, чтобы одинаковые наименования шли подряд
            string[,] mainlist = new string[mass.Length, 2]; // организуем двумерный массив, чтобы разделить наименование и цену
            for (int i = 0; i < mass.Length; i++)
            {
                mainlist[i, 0] = mass[i].Split('*')[0];
                mainlist[i, 1] = mass[i].Split('*')[1].Replace(" руб", ""); // сразу удаляем рубли, чтобы не мешали сортировке
            }
            List<List<string>> list = new List<List<string>>(); // создаем двумерный список для уникальных записей (наименование + цена)
            for (int i = 0; i < mass.Length - 1; i++)
            {
                list.Add(new List<string>()); // добавляем в список уникальный элемент с первой ценой
                list[list.Count() - 1].Add(mainlist[i, 0]);
                list[list.Count() - 1].Add(mainlist[i, 1]);
                if (i < mass.Length - 2)
                {
                    while (list[list.Count() - 1][0] == mainlist[i + 1, 0]) // перебираем повторяющиеся с уникальным элементы
                    {
                        if (int.Parse(list[list.Count() - 1][1]) < int.Parse(mainlist[i + 1, 1])) // ищем максимальную цену для данного наименования и заменяем ее в списке
                        {
                            list[list.Count() - 1][1] = mainlist[i + 1, 1];
                        }
                        if (i < mass.Length - 2)
                        {
                            i += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else // отдельный случай предпоследнего значения, чтобы не вылетало исключение из-за индекса
                {
                    if (list[list.Count() - 1][0] == mainlist[mass.Length - 1, 0])
                    {
                        if (int.Parse(list[list.Count() - 1][1]) < int.Parse(mainlist[mass.Length - 1, 1]))
                        {
                            list[list.Count() - 1][1] = mainlist[mass.Length - 1, 1];
                        }
                    }
                }
            }
            string[] file1 = new string[list.Count()];
            string[] file2 = new string[list.Count()];
            for (int i = 0; i < list.Count; i++)
            {
                file1[i] = list[i][0];
                file2[i] = list[i][0] + "*" + list[i][1] + " руб";
            }
            File.WriteAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\1File2.txt", file1);
            File.WriteAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\1File3.txt", file2);
            Console.WriteLine("Вывод окончен!");
            Console.Read();
        }
    }
}*/


/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = File.ReadAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\2File1.txt", Encoding.Default);
            List<string> list = new List<string>();

            foreach (string str in mass)
            {
                if (Array.IndexOf(mass, str) != Array.LastIndexOf(mass, str) && list.Contains(str) == false)
                {
                    list.Add(str);
                }
            }
            File.WriteAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\2File2.txt", list);
            Console.WriteLine("Вывод окончен!");
            Console.Read();
        }
    }
}*/