using System.Net;

namespace ChoosingSortingAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> unsortedList = new() { 8, 6, 7, 9, 5, 3, 1, 2, 4 };
            Console.WriteLine("Input data:");
            unsortedList.ForEach(x => { Console.Write($"{x} "); });


            // Использование быстрой сортировки
            var quickSorter = new DataSorter(new QuickSort());
            quickSorter.SortData(unsortedList);
            Console.WriteLine();
            PrintList("Fast sort:", unsortedList);

            // Использование пузырьковой сортировки
            var bubbleSorter = new DataSorter(new BubbleSort());
            bubbleSorter.SortData(unsortedList);
            PrintList("Bubble sort:", unsortedList);
            Console.ReadLine();
        }

        static void PrintList(string message, List<int> list)
        {
            Console.WriteLine(message);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }

    // Интерфейс стратегии
    public interface ISortAlgorithm
    {
        void Sort(List<int> list);
    }

    // Конкретная стратегия: Быстрая сортировка
    public class QuickSort : ISortAlgorithm
    {
        public void Sort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return;
            }

            int pivotIndex = list.Count / 2;
            int pivotValue = list[pivotIndex];
            list.RemoveAt(pivotIndex);

            List<int> left = new();
            List<int> right = new();

            foreach (var item in list)
            {
                if (item < pivotValue)
                {
                    left.Add(item);
                }
                else
                {
                    right.Add(item);
                }
            }

            Sort(left);
            Sort(right);

            list.Clear();
            list.AddRange(left);
            list.Add(pivotValue);
            list.AddRange(right);
        }
    }

    // Конкретная стратегия: Пузырьковая сортировка
    public class BubbleSort : ISortAlgorithm
    {
        public void Sort(List<int> list)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        Swap(list, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        private void Swap(List<int> list, int indexA, int indexB)
        {
            int temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
    // Контекст
    public class DataSorter
    {
        private readonly ISortAlgorithm _sortAlgorithm;

        public DataSorter(ISortAlgorithm sortAlgorithm)
        {
            _sortAlgorithm = sortAlgorithm;
        }

        public void SortData(List<int> data)
        {
            _sortAlgorithm.Sort(data);
        }
    }

}
