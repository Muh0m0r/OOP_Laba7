using OOP_Laba7;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        LinkedList<double> list = null;
        ListOperations operations = new ListOperations();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Створити новий список");
            Console.WriteLine("2. Вийти");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    list = operations.CreateList();
                    PrintList(list);
                    ListInteractionMenu(ref list, operations);
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ListInteractionMenu(ref LinkedList<double> list, ListOperations operations)
    {
        while (true)
        {
            Console.WriteLine("\nМеню роботи зі списком:");
            Console.WriteLine("1. Знайти перший елемент > середнього");
            Console.WriteLine("2. Знайти суму елементів > заданого");
            Console.WriteLine("3. Отримати новий список зі значень < середнього");
            Console.WriteLine("4. Видалити елементи на парних позиціях");
            Console.WriteLine("5. Отримати елемент за індексом");
            Console.WriteLine("6. Видалити елемент за індексом");
            Console.WriteLine("7. Видалити список та повернутись назад");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        double result = operations.GetFirstOverAverageValue(list);
                        Console.WriteLine($"Перший елемент більший за середнє значення = {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    double threshold;
                    while (true)
                    {
                        Console.Write("Введіть значення порогу: ");
                        string input = Console.ReadLine();
                        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out threshold))
                            break;
                        Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                    }
                    try
                    {
                        double sum = operations.GetSumOfElementsBiggerThan(list, threshold);
                        Console.WriteLine($"Сума елементів більших за {threshold} = {sum}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        list = operations.CreateLinkedListUnderAverage(list);
                        Console.WriteLine("Оновлений список (елементи менші за середнє значення оригіналу):");
                        PrintList(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "4":
                    try
                    {
                        list = operations.DeleteEvenNodes(list);
                        Console.WriteLine("Список після видалення елементів на парних позиціях:");
                        PrintList(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "5":
                    try
                    {
                        int idx;
                        while (true)
                        {
                            Console.Write("Введіть індекс елемента: ");
                            string input = Console.ReadLine();
                            if (int.TryParse(input, out idx) && idx >= 0)
                                break;
                            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                        }
                        double element = operations.GetNodeValueByIndex(list, idx);
                        Console.WriteLine($"Елемент за індексом {idx}: {element}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "6":
                    try
                    {
                        int idxToDelete;
                        while (true)
                        {
                            Console.Write("Введіть індекс елемента для видалення: ");
                            string input = Console.ReadLine();
                            if (int.TryParse(input, out idxToDelete) && idxToDelete >= 0)
                                break;
                            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                        }
                        list = operations.DeleteNodeByIndex(list, idxToDelete);
                        Console.WriteLine($"Елемент за індексом {idxToDelete} видалено.");
                        PrintList(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "7":
                    list = null;
                    return;

                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            } 
        }
    }

    static void PrintList(LinkedList<double> list)
    {
        if (list == null || list.Count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }

        Console.Write("Список: [");
        Console.Write(string.Join("; ", list.Select(x => x.ToString("F2", CultureInfo.InvariantCulture))));
        Console.WriteLine("]");
    }
}
