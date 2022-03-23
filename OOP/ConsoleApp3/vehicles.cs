using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Vechicle : Cars
    {
        public int Kilometers { get; set; }

        public void DisplayOfCarID()
        {
            Console.WriteLine(CarID);
        }
        public virtual void TraveledKM()
        {
            if (Used == true)
            {
                Console.WriteLine("Kilometers Traveled:");
            }
        }
    }
}