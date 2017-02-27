using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray2D
{
    class Chose
    {
        private int id;

        public Chose(int id)
        { this.id = id; }

        public override String ToString()
        { return this.id.ToString(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Chose[,] arrayChose = new Chose[4,4];

            arrayChose[2, 2] = new Chose(22);

            foreach (Chose chose in arrayChose)
                if (chose != null)
                    Console.WriteLine(chose.ToString());
                else
                    Console.WriteLine("null");

#if DEBUG
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
#endif
        }
    }
}
