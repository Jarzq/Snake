using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class DynamicMenu
    {
        public List<Colors> items;
        
        public void Configure(List<Colors> list)
        {
            items = new List<Colors>();
            if (list != null)
            {
                int i = 0;
                foreach (Colors element in list)
                {
                    items.Add(element);
                    i++;
                }
            }
            
        }
        string titleText;
        public DynamicMenu(string titleText)
        {
            this.items = new List<Colors>();
            this.titleText = titleText;
        }
        
        
        public virtual void TitleText()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - titleText.Length / 2 , Console.WindowHeight / 3);
            Console.WriteLine(titleText);
        }
        
        public virtual void show(int i)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 - 10, Console.WindowHeight/2 + i);         
            Console.WriteLine("     " + items[i].name.PadRight(10) + items[i].price + "$".PadRight(5));       
        }
        public virtual int Open()
        {
            
            Console.CursorVisible = false;
            int desicion = 0;
            ConsoleKeyInfo keyChoosen;
            TitleText();
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
               
                for (int i = 0; i < items.Count; i++)
                {

                    if (i == desicion)
                        Console.BackgroundColor = items[i].color;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkCyan;


                    show(i);
                    

                }


                keyChoosen = Console.ReadKey(true);
                if (keyChoosen.Key == ConsoleKey.DownArrow && desicion < items.Count - 1)
                {
                    desicion++;

                }
                if (keyChoosen.Key == ConsoleKey.UpArrow && desicion > 0)
                {
                    desicion--;

                }
                else if (keyChoosen.Key == ConsoleKey.Escape)
                {
                    desicion = -1;
                }
            } while (keyChoosen.Key != ConsoleKey.Enter && keyChoosen.Key != ConsoleKey.Escape);


            return desicion;
        }
    }
}
