using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Player
    {
        public List<Snake> items = new List<Snake>();
        public List<Colors> colors = new List<Colors>();
        Colors red = new Colors(ConsoleColor.Red, "red",50);

      
        
        public Player()
        {
            Balance = 10;
            colors.Add(red);
        }
        public int Balance { get; set; }

        public void Sell(Snake snake)
        {
            items.Remove(snake);
        }

        public void BuyColor(Colors color)
        {
            if (Balance >= color.price)
            {
                colors.Add(color);
                Balance -= color.price;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"You dont have enugh money. Your balance:{Balance}$");
                Console.ReadKey();
            }
        }
        public void RemoveColor(Colors color)
        {
            colors.Remove(color);
        }

    }
}
