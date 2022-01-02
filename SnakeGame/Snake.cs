using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    abstract class Snake
    {
       

        public virtual string Name { get; set; } = "Default";

        public int x, y;
        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Snake() { }

        public abstract void DrawSnake();

        public bool Collision(List<part> parts)
        {
            for(int i=0;i<parts.Count-1;i++)
            {
                if ((parts[i].x == x || parts[i].x + 1 == x) && (parts[i].y == y)) { return true; }
            }
            if(x >= Console.WindowWidth || x < 0 || y <0 || y > Console.WindowHeight) { return true; }

            return false;
        }

        
    }

    class SnakeHead:Snake
    {
        private ConsoleColor color = ConsoleColor.Green;
        public SnakeHead(int x, int y) : base(x, y) {}
        public override void DrawSnake()
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.WriteLine("  ");
        }
    }

    class part : Snake
    {
        private ConsoleColor color = ConsoleColor.Green;
        public override string Name { get; set; } = "Part";
        public part(int x, int y, ConsoleColor color) : base(x, y) { this.color = color; }

        public override void DrawSnake()
        {

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.WriteLine("  ");
           
        }
    }

    
}
