using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР9___Змейка
{
    public class Food
    {
        public Position foodPos = new Position();
        Random rnd = new Random();
        Canvans canvans= new Canvans();
        public Food() 
        {
            foodPos.x= rnd.Next(5, canvans.Width);
            foodPos.y= rnd.Next(5,canvans.Height);
        }

        public void drawFood()
        {
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.WriteLine("F");
        }

        public Position foodLocation()
        {
             return foodPos; 
        }

        public void foodNewLocation()
        {
            foodPos.x = rnd.Next(5, canvans.Width);
            foodPos.y = rnd.Next(5, canvans.Height);
        }
    }
}
