using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class StudentCard : IComparable, ICloneable
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object x)
        {
            StudentCard sc = (StudentCard)x;
            if (sc != null)
            {
                return (Series + Number.ToString()).CompareTo(sc.Series + sc.Number.ToString());
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Series + " " + Number;
        }
    }

    internal class Student : IComparable, ICloneable
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public StudentCard StudentCard { get; set; }
                
        public static IComparer FromBirthDate { get { return new DateComparer(); } }

        public override string ToString()
        {
            return $"{LastName.PadRight(15)} {FirstName.PadRight(10)} {BirthDay.ToShortDateString()} {StudentCard}";
        }

        public int CompareTo(object obj)
        {
            Student student = obj as Student;
            if (student != null)
            {
                return LastName.CompareTo(student.LastName);
            }
            else
                throw new NotImplementedException();
        }

        public object Clone()
        {
            Student temp = (Student)this.MemberwiseClone();
            temp.StudentCard = (StudentCard)StudentCard.Clone();
            return temp;
        }

        public override int GetHashCode()
        {
            return $"{LastName} {FirstName}".GetHashCode();

        }
        
        class DateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Student && y is Student)
                {
                    return (x as Student).BirthDay.CompareTo((y as Student).BirthDay);
                }
                throw new NotImplementedException();
            }
        }


        class StudentCardComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Student && y is Student)
                {
                    return (x as Student).StudentCard.CompareTo((y as Student).StudentCard);
                }
                throw new NotImplementedException();
            }
        }
    }
}
