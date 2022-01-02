using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Colors
    {
        public ConsoleColor color;
        public string name;
        public int price;
        public Colors(ConsoleColor color, string name, int price)
        {
            this.color = color;
            this.name = name;
            this.price = price;
        }
    }
    
}
