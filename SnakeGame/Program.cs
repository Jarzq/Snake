using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Shop shop = new Shop();
            Food food = new Food();
            StaticMenu mainMenu = new StaticMenu();
            

            mainMenu.Configure(new string[] { "Play", "Shop", "Show balance","Highscore", "Exit" });
            int decision;

            do
            {
                decision = mainMenu.Open();
                if(decision==0)
                {
                    
                    game.LoadGameScreen();
                    game.Setup(game.ColorMenu());                   
                    game.Start();
                }

                if(decision == 1)
                {
                    ClearScreen();                    
                    game.UpdatePlayer(shop.ShopMenu());
                }
                if (decision == 2)
                {
                    game.ShowPlayerBalance();
                  
                }
                if (decision == 3)
                {
                    game.Showhighscore();

                }
                ClearScreen();
            } while (decision != 4);
            
            
        }
        public static void ClearScreen()
        {
            Console.ResetColor();
            Console.Clear();

        }
    }
}
