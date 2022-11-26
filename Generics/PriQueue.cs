using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class PriQueue<TPri, Tval> : Queue where TPri : IComparable
    {
        //клас Обгортка для черги
        public class Data : IComparable
        {
            public TPri Prior { set; get; }
            public Tval Value { set; get; }

            public Data() { }

            public Data(TPri prior, Tval value) 
            { 
                this.Prior = prior;
                this.Value = value;
            }

            public TPri GetPri() { return Prior; }
            public Tval GetVal() { return Value; }

            public override string ToString()
            {
                return Value.ToString();
            }

            public int CompareTo(object obj)
            {
                Data d = obj as Data;
                if(d != null)
                    return d.Prior.CompareTo(this.Prior);
                else 
                    throw new NotImplementedException();
            }
        }

        public void Enqueue(TPri pri, Tval val)
        {
            if(Count== 0)
            {
                Data data = new(pri, val);
                base.Enqueue(data);
            }
            else 
            {
                Data data = new(pri, val);
                List<Data> temp = new List<Data>();

                foreach (Data item in this)
                {
                    temp.Add(item);
                }
                temp.Add(data);
                temp.Sort();

                this.Clear();

                foreach (Data item in temp)
                {
                    base.Enqueue(item);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("-----------------------------------------------------------");
            foreach (Data item in this)
            {
                Console.WriteLine(item.GetVal());
            }
            Console.WriteLine("-----------------------------------------------------------");

        }

    }
}
