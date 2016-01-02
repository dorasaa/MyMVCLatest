using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCLatest.Models
{
    public class GenericsTest<T>
    {
        public static bool AreEqual(T a, T b)
        {
            return a.Equals(b);

        }
    }

    public class customer
{
        public string fname { get; set; }
        public string lname { get; set; }

        public override string ToString()
        {
            //return base.ToString();

            return this.lname + ", " +this.fname;
        }

}
}