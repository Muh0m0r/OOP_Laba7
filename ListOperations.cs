using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba7
{
    internal class ListOperations
    {   
        public double GetFirstOverAverageValue(LinkedList<double> list) 
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Список порожній.");

            double average = list.Average();

            foreach (double currentNodeValue in list)
            {
                if (currentNodeValue > average)
                {
                    return currentNodeValue;
                }
            }
            throw new InvalidOperationException("У списку немає елемента, більшого за середнє значення.");
        }

        public double GetSumOfElementsBiggerThan(LinkedList<double> list, double sampleElement)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Список порожній.");

            double sum = 0;

            foreach (double currentNodeValue in list) 
            { 
                if (currentNodeValue > sampleElement)
                {
                    sum += currentNodeValue;
                }
            }

            return sum;
        }

        public LinkedList<double> CreateLinkedListUnderAverage(LinkedList<double> originalList)
        {
            if (originalList == null || originalList.Count == 0)
                throw new InvalidOperationException("Список порожній.");

            LinkedList<double> resultList = new LinkedList<double>();
            double originalAverage = originalList.Average();

            foreach (double currentNodeValue in originalList)
            {
                if (currentNodeValue < originalAverage)
                {
                    resultList.AddLast(currentNodeValue);
                }
            }

            return resultList;

        }

        public LinkedList<double> DeleteEvenNodes(LinkedList<double> originalList) 
        {
            if (originalList == null || originalList.Count == 0)
                throw new InvalidOperationException("Список порожній.");

            LinkedListNode<double> current = originalList.First;
            int index = 0;

            while (current != null)
            {
                LinkedListNode<double> next = current.Next;
                if (index % 2 != 0)
                {
                    originalList.Remove(current);
                }
                index++;
                current = next;
            }

            return originalList;
        }

        public LinkedList<double> CreateList()
        {
            var list = new LinkedList<double>();
            Console.WriteLine("\nВведіть значення для списку (нечислове значення — завершити введення списку):");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    list.AddLast(value);
                }
                else
                {
                    break;
                }
            }
            return list;
        }

        public double GetNodeValueByIndex(LinkedList<double> list, int index)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Список порожній.");
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс поза межами списку.");

            var current = list.First;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public LinkedList<double> DeleteNodeByIndex(LinkedList<double> list, int index)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Список порожній.");
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс поза межами списку.");

            var current = list.First;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            list.Remove(current);
            return list;
        }
    }
}
