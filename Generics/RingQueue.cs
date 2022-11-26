using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class RingQueue<Tval> : Queue<Tval>
    {
        public void Ring()
        {
            if (Count > 1)
            {
                Tval temp = Dequeue();
                Enqueue(temp);
            }
        }

       public void Print()
       {
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");
        }


    }
}
