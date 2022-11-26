﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    internal class Program
    {
        
        static void Swap<T>(ref T left, ref T right)
        {
            T temp = right;
            right = left;
            left = temp;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //// Піддослідні студенти
            Student student1 = new()
            {
                FirstName = "Oleg",
                LastName = "Ivanov",
                BirthDay = new DateTime(1988, 2, 12),
                StudentCard = new StudentCard
                {
                    Series = "ABD",
                    Number = 98765
                }
            };
            Student student2 = new()
            {
                FirstName = "Olga",
                LastName = "Petrova",
                BirthDay = new DateTime(1992, 1, 4),
                StudentCard = new StudentCard
                {
                    Series = "ZX",
                    Number = 12345
                }
            };
            Student student3 = new()
            {
                FirstName = "Andrey",
                LastName = "Poplavskii",
                BirthDay = new DateTime(1972, 7, 22),
                StudentCard = new StudentCard
                {
                    Series = "AA",
                    Number = 56432
                }
            };

            ////-------------------------Тест методу SWAP--------------------------------------------------
            Console.WriteLine("\t\t Тест методу SWAP\n");
            Console.WriteLine($"Student 1:\n {student1} \n\n Student 2 :\n {student2}\n\n");
            Swap<Student>(ref student1, ref student2);
            Console.WriteLine($"Student 1 після swap:\n {student1} \n\n Student 2 після swap:\n {student2}");
            Console.ReadKey();
            Console.Clear();
            ////-------------------------Кінець------------------------------------------------------------

            ////-------------------------Тест кільцової черги RingQueue------------------------------------
            Console.WriteLine("\t\t Тест кільцьової черги\n");
            Console.WriteLine("Тест кільцьової черги на стрінгах");
            RingQueue<string> ringQ = new();
            ringQ.Enqueue("Tets 1");
            ringQ.Enqueue("Tets 2");
            ringQ.Enqueue("Tets 3");
            ringQ.Enqueue("Tets 4");
            ringQ.Print();
            Console.WriteLine("Робимо метод рінг 3 рази");
            ringQ.Ring();
            ringQ.Ring();
            ringQ.Ring();
            ringQ.Print();
            ////-------------------------------------------------------------------------------------------
            Console.WriteLine("\nТест кільцьової черги на студентах");
            RingQueue<Student> ringQstudent = new();
            ringQstudent.Enqueue(student1);
            ringQstudent.Enqueue(student2); 
            ringQstudent.Enqueue(student3);
            ringQstudent.Print();
            Console.WriteLine("Робимо метод рінг 2 рази");
            ringQstudent.Ring();
            ringQstudent.Ring();
            ringQstudent.Print();
            Console.ReadKey();
            Console.Clear();
            ////-------------------------Кінець------------------------------------------------------------


        }
    }
}
