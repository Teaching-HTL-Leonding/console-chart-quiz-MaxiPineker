using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChart
{
    class ChartController
    {
        private int _length;

        public ChartController(int length = 0)
        {
            _length = length;
        }

        public ChartController()
        {
        }

        public int MaxValue
        {
            get; set;
        }
        public void Print(IEnumerable<IGrouping<string, Item>> enumerable)
        {
            List<Item> result = GroupList(enumerable);

            MaxValue = result.First().Value;
            if (_length == 0) _length = result.Count;

            var count = 0;
            foreach (Item line in result)
            {
                if (count >= _length) return;
                Console.Write($"{line.Text,-50}|\t");
                PrintBars(line.Value);
                Console.WriteLine();
                count++;
            }
        }

        private static List<Item> GroupList(IEnumerable<IGrouping<string, Item>> enumerable)
        {
            List<Item> result = enumerable
                .Select(
                    entry => new Item(
                        entry.Key,
                        entry.Sum(e => e.Value)
                    )).OrderByDescending(r => r.Value).ToList();
            ;
            return result;
        }
        public int CalculatePercentage(int value)
        {
            return (int)Math.Round((double) value / MaxValue * 100);
        }

        public void PrintBars(int value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(new string(' ', CalculatePercentage(value)));
            Console.ResetColor();
        }
    }
}
