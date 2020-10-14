using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace ConsoleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();

            string line = Console.ReadLine();
            string[] text = line.Split('\t');
            var firstIndex = Array.IndexOf(text, args[0]);
            var secondIndex = Array.IndexOf(text, args[1]);
            line = Console.ReadLine();

            line = Console.ReadLine();

            while (!String.IsNullOrEmpty(line))
            {
                items.Add(new Item(line.Split('\t')[firstIndex], int.Parse(line.Split('\t')[secondIndex])));
                line = Console.ReadLine();
            }

            if (items.Count < 1) return;
            ChartController controller = args.Length == 3
                ? new ChartController(int.Parse(args[2]))
                : new ChartController();

            controller.Print(items.GroupBy(d => d.Text));
        }

    }
}
