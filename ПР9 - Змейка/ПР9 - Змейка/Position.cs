using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ПР9___Змейка
{
    public class Position
    {
        public int x { get; set; } 
        public int y { get; set; }

        public Position()
        {

        }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
