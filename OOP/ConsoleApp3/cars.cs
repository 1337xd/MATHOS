using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Cars
    {
        Guid gobj = new Guid();
        public string Type { get; set; }

        public bool Used { get; set; }

        public double Price { get; set; }

        public string EngineType { get; set; }

        public int EnginePower { get; set; }


        protected string CarID = Guid.NewGuid().ToString();

        //konstruktor primjer
        public Cars()
        {
            EnginePower = 180;
        }

    }
}