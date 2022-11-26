using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class PriQueue<TPri, Tval> : Queue<Tval> where TPri : IComparable
    {

        public void Enqueue(TPri pri, Tval val)
        {

        }

    }
}
