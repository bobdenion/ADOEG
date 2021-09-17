using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEG
{
    class CollLINQEg
    {
        public static void main ()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var results = (from i in numbers
                           where i % 2 == 0
                           select i).ToList();
            Console.WriteLine("Even Numbers");
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine("Even Numbers using Method Syntax");
            //var res = numbers.Where(x => x % 2 == 0).Select(x =>).OrderBy(x => x);
            //foreach(var item in res)
            //{
            //    Console.WriteLine(item);
            //}

           
            List<string> names = new List<string>();
            names.Add("Ted");
            names.Add("Bob");
            names.Add("Jim");
            names.Add("Sally");
            names.Add("Lily");
            var data = (from i in names
                        where i.StartsWith('T')
                        select i).ToList();
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            var r = names.Where(i => i.StartsWith('T')).Select(i => i);
            foreach(var item in r)
            {
                Console.WriteLine(r);
            }
           

        }
    }
}
