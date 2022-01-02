using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    
    class Food
    {
        Random rnd = new Random();
        private bool foodOnSnake;
        public int x, y;

        public Food(List<part> parts)
        {
            

            do
            {
                foodOnSnake = false;
                x = rnd.Next(1, Console.WindowWidth - 1);
                y = rnd.Next(1, Console.WindowHeight - 1);
                foreach (part item in parts)
                {
                    if ((item.x == x || item.x + 1 == x) && (item.y == y)) { foodOnSnake = true; }   //to not draw food on snake
                }
            } while (foodOnSnake);
        }
        public Food() { }
        ~Food() { Console.WriteLine("Work"); }
        
        public void DrawFood()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ");
        }
    }
}
