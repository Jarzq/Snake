using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Shop
    {
        public static string shopText = "Buy skins for your snake!";

        public List<Colors> items = new List<Colors>();


        Colors pink = new Colors(ConsoleColor.Magenta, "pink", 10);
        Colors blue = new Colors(ConsoleColor.Blue, "blue",20);
        Colors red = new Colors(ConsoleColor.Red, "red", 50);      
        Colors gray = new Colors(ConsoleColor.DarkGray, "gray",70);
        Colors black = new Colors(ConsoleColor.Black, "black",80);
        Colors green = new Colors(ConsoleColor.Green, "green",99);
      
        
        

        DynamicMenu shopMenu = new DynamicMenu(shopText);
        public Shop()
        {
            SetColorsToShop();
        }
        public void SetColorsToShop()
        {
            items.Add(pink);
            items.Add(blue);
            items.Add(red);
            items.Add(gray);
            items.Add(black);
            items.Add(green);
            
        }

        public Colors ShopMenu()
        {
            
            shopMenu.Configure(items);
            int decision;

            do
            {
                decision = shopMenu.Open();
             
                return items[decision];

            } while (decision != 3);
            
        }

        
        
    }
}
