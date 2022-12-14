using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР9___Змейка
{
    public class Snake
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        public List<Position> snakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }

        public Snake() 
        {
            x = 20;
            y = 20;
            score = 0;

            snakeBody = new List<Position>();
            snakeBody.Add(new Position(x, y));
        }

        public void drawSnake()
        {
            foreach (Position pos in snakeBody)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                Console.WriteLine("■");
            }
        }

        public void Input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }


        private void direction()
        {
            if(key == 'w' && dir != 'd' )
            {
                dir = 'u';
            }
            else if(key == 's' && dir != 'u' )
            {
                dir = 'd';
            }
            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
            else if(key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }
        public void moveSnake()
        {
            direction();

            if (dir == 'u')
            {
                y--;
            }
            else if(dir == 'd') 
            {
                y++;
            }
            else if (dir == 'r')
            {
                x++;
            }
            else if (dir == 'l')
            {
                x--;
            }

            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }

        public void eat(Position food, Food f)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if(head.x == food.x && head.y == food.y) 
            {
               snakeBody.Add(new Position(x,y));
                f.foodNewLocation();
                score++;
            }
        }
        public void isDead()
        {
            Position head = snakeBody[snakeBody.Count - 1];

            for(int i = 0; i < snakeBody.Count -2; i ++) 
            {
                Position sb = snakeBody[i];

                if(head.x == sb.x && head.y == sb.y)
                {
                    throw new SnakeException("Snake Died");
                }
            }
        }

        public void hitWall(Canvans canvans)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if (head.x >= canvans.Width || head.x <= 0 || head.y >= canvans.Height || head.y <= 0)
            {
                throw new SnakeException("Snake Died");
            }
        }

    }
}
