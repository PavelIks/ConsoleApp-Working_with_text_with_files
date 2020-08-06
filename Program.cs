using System;
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
            string[] mass = File.ReadAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\File1.txt", Encoding.Default); //считываем в массив строк
            Array.Sort(mass); // сразу сортируем, чтобы одинаковые наименования шли подряд
            string[,] mainlist = new string[mass.Length, 2]; // организуем двумерный массив, чтобы разделить наименование и цену
            for (int i = 0; i < mass.Length; i++)
            {
                mainlist[i, 0] = mass[i].Split('*')[0];
                mainlist[i, 1] = mass[i].Split('*')[1].Replace("руб", ""); // сразу удаляем рубли, чтобы не мешали сортировке
            }
            List<List<string>> lst = new List<List<string>>(); // создаем двумерный список для уникальных записей (наименование + цена)
            for (int i = 0; i < mass.Length - 1; i++)
            {
                lst.Add(new List<string>()); // добавляем в список уникальный элемент с первой ценой
                lst[lst.Count() - 1].Add(mainlist[i, 0]);
                lst[lst.Count() - 1].Add(mainlist[i, 1]);
                if (i < mass.Length - 2)
                {
                    while (lst[lst.Count() - 1][0] == mainlist[i + 1, 0]) // перебираем повторяющиеся с уникальным элементы
                    {
                        if (int.Parse(lst[lst.Count() - 1][1]) < int.Parse(mainlist[i + 1, 1])) // ищем максимальную цену для данного наименования и заменяем ее в списке
                        {
                            lst[lst.Count() - 1][1] = mainlist[i + 1, 1];
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
                    if (lst[lst.Count() - 1][0] == mainlist[mass.Length - 1, 0])
                    {
                        if (int.Parse(lst[lst.Count() - 1][1]) < int.Parse(mainlist[mass.Length - 1, 1]))
                        {
                            lst[lst.Count() - 1][1] = mainlist[mass.Length - 1, 1];
                        }
                    }
                }
            }
            string[] namelist1 = new string[lst.Count()];
            string[] finalist = new string[lst.Count()];
            for (int k = 0; k < lst.Count; k++)
            {
                namelist1[k] = lst[k][0];
                finalist[k] = lst[k][0] + "*" + lst[k][1] + "руб";
            }
            File.WriteAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\File2.txt", namelist1);
            File.WriteAllLines(@"C:\Users\Pavlo\source\repos\WorkWithText\bin\Debug\File3.txt", finalist);
            Console.WriteLine("Вывод окончен");
            Console.Read();
        }
    }
}