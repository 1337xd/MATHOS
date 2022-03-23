using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Auto : Vechicle
    {
        public override void TraveledKM()
        {
            if (Used == false)
            {
                Console.WriteLine("Brand new vehicle");
            }
        }
    }
}
