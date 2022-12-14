using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ПР9___Змейка
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Canvans canvans= new Canvans();
            Snake snake = new Snake();
            Food food= new Food();


            Console.WriteLine("\t \t \t \t PRESS ENTER");
            Console.Read();
            while (!finished)
            {
                try
                {
                    canvans.drawCanvans();

                    Console.SetCursorPosition(45, 1);
                    Console.WriteLine("SCORE: {0}", snake.score);
                    snake.Input();
                    food.drawFood();
                    snake.drawSnake();
                    snake.moveSnake();
                    snake.eat(food.foodLocation(), food);
                    snake.isDead();
                    snake.hitWall(canvans);
                }
                catch (SnakeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);

                    Console.WriteLine("Restar Game? (y/n)");
                    char c = char.Parse(Console.ReadLine());

                    switch(c)
                    {
                        case 'y':

                            snake.x = 20;
                            snake.y = 20;
                            snake.score = 0;
                            snake.snakeBody.RemoveRange(0, snake.snakeBody.Count - 1);

                            break;

                        case 'n':
                            finished = true;
                           
                            break;
                    }
                }
                
            }
        }
    }
}