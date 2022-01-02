using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class StaticMenu
    {
            private string[] elementy = new string[0];

            public void Configure(string[] elementyMenu)
            {
                if (elementyMenu != null)
                {
                    elementy = elementyMenu;
                }

            }
            public int Open()
            {
                Console.CursorVisible = false;
                int wybrany = 0;
                ConsoleKeyInfo klawisz;
                do
                {
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < elementy.Length; i++)
                    {
                        if (i == wybrany)
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        else
                            Console.BackgroundColor = ConsoleColor.DarkCyan;


                        Console.WriteLine(elementy[i].PadRight(25));
                    }

                    klawisz = Console.ReadKey(true);
                    if (klawisz.Key == ConsoleKey.DownArrow && wybrany < elementy.Length - 1)
                    {
                        wybrany++;

                    }
                    if (klawisz.Key == ConsoleKey.UpArrow && wybrany > 0)
                    {
                        wybrany--;

                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        wybrany = -1;
                    }
                } while (klawisz.Key != ConsoleKey.Enter && klawisz.Key != ConsoleKey.Escape);


                return wybrany;
            }
    }
}
