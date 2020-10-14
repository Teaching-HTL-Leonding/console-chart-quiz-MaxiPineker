using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChart
{
    class Item
    {
        private string _text;
        private int _value;

        public Item(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public string Text
        {
            get; set;
        }
        public int Value
        {
            get; set;
        }
    }
}
