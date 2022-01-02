using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Game
    {
        protected Snake snakeHead;
        List<part> parts;
        Player player = new Player();
        int lenght,highscore=0;
        ConsoleColor color;
        protected bool End, leftDirection, rightDirection, downDirection, upDirection;



        public Game()
        {
            Console.CursorVisible = false;
        }
        public virtual void LoadGameScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string title = "----- WELCOME IN SNAKE GAME ------";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, Console.WindowHeight / 4);
            Console.WriteLine(title);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 3);
            Console.WriteLine("Loading...");
            Thread.Sleep(2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 3);
            Console.WriteLine("CHOOSE COLOR");         
            
        }

        

        internal void UpdatePlayer(Colors color)
        {
            player.BuyColor(color);         
        }

        public virtual void Setup(ConsoleColor colorChosen)
        {
            this.snakeHead = new SnakeHead(30, 20);
            parts = new List<part>();
            color = colorChosen;
            lenght = 2;
            rightDirection = true;
            leftDirection = false;
            downDirection = false;
            upDirection = false;
            parts.Add(new part(26, 20, color));
            parts.Add(new part(28, 20, color));
            


        }

        public virtual void Start()
            {
            
            End = false;
            Food food = new Food(parts);

            //Border border = new Border();


            while (!End)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                if (snakeHead.Collision(parts)) 
                { 
                    player.Balance += lenght - 2; 
                    if (lenght-2 > highscore) { highscore = lenght - 2; }                  
                    break; 
                }

                snakeHead.DrawSnake();
                food.DrawFood();
                ShowScore();
                
               


               

                if ((snakeHead.x == food.x  || snakeHead.x+1 == food.x) && snakeHead.y ==  food.y )
                {
                    lenght++;
                    parts.Add(new part(snakeHead.x, snakeHead.y,color));
                    food = null;
                    food = new Food(parts);
                }


                if (Console.KeyAvailable)
                {
                    var klawisz = Console.ReadKey(true);
                    Keyboard(klawisz);
                    
                }
                if(!Console.KeyAvailable)
                {
                    if (downDirection) { snakeHead.y++; }
                    if (upDirection) { snakeHead.y--; }
                    if (leftDirection) { snakeHead.x-=2; }
                    if (rightDirection) { snakeHead.x+=2; }

           
                    foreach (part item in parts)
                    {
                        item.DrawSnake();
                    }

                    if (parts.Count >= lenght)
                    {
                        parts.Remove(parts[0]);
                        lenght--;
                    }
                    lenght++;
                    parts.Add(new part(snakeHead.x, snakeHead.y, color));


                }

                Thread.Sleep(30);


            }

            ShowEndScreen();
           
            
        }

        protected virtual void Keyboard(ConsoleKeyInfo Key)
        {
            var k = Key.Key;
            if (k == ConsoleKey.Escape) End = true;
            if (k == ConsoleKey.F1) HelpScreen();
            if (k == ConsoleKey.DownArrow && !upDirection) { downDirection = true; upDirection = false; leftDirection = false; rightDirection = false; }
            if (k == ConsoleKey.UpArrow && !downDirection) { downDirection = false; upDirection = true; leftDirection = false; rightDirection = false; }
            if (k == ConsoleKey.LeftArrow && !rightDirection) { downDirection = false; upDirection = false; leftDirection =true; rightDirection = false; }
            if (k == ConsoleKey.RightArrow && !leftDirection) { downDirection = false; upDirection = false; leftDirection = false; rightDirection = true; }
        }
        public virtual void ShowScore()
        {
            string text = $"Score:{lenght-2}";
            Console.SetCursorPosition(Console.WindowWidth - text.Length - 1, 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }
        public virtual void ShowEndScreen()
        {
            string title = "----- You Lost -----";
            string scoreText = $"Your Score: {lenght - 2}";
            string highscoreText = $"Your Highscore: {highscore}";

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, Console.WindowHeight / 4);
            Console.WriteLine(title);
            Console.SetCursorPosition(Console.WindowWidth / 2 - scoreText.Length / 2, Console.WindowHeight / 3);
            Console.WriteLine(scoreText);
            Console.SetCursorPosition(Console.WindowWidth / 2 - highscoreText.Length / 2, Console.WindowHeight / 2 - 2);
            Console.WriteLine(highscoreText);

            Console.ReadKey();
        }
        public virtual void HelpScreen()
        {
            Console.Clear();
            Console.WriteLine("Use Up Arrow to turn up");
            Console.WriteLine("Use Down Arrow to turn down");
            Console.WriteLine("Use Left Arrow to turn left");
            Console.WriteLine("Use Rght Arrow to turn right");
            Console.ReadKey();
        }
        public virtual void testScreen()
        {
           
        }

        DynamicMenu colorMenu = new DynamicMenu("Choose color. If you want more colors, go to the shop");
        public ConsoleColor ColorMenu()
        {
            
            colorMenu.Configure(player.colors);
            int decision;

            do
            {
                decision = colorMenu.Open();
                return player.colors[decision].color;

            } while (decision != 3);
        }

        internal void Showhighscore()
        {
            Console.Clear();
            string text = $"Your highscore: {highscore}";
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 3);
            Console.WriteLine(text);
            Console.ReadKey();
        }
        public void ShowPlayerBalance()
        {
            Console.Clear();
            string text = $"Your Balance: {player.Balance}$";
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length/2, Console.WindowHeight / 3);          
            Console.WriteLine(text);
            Console.ReadKey();
        }
       
       

    }
}
