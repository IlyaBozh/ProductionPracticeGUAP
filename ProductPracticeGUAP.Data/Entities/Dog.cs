using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPracticeGUAP.Data.Entities
{
    internal class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public double Weight { get; set; }
        public Owner Owner { get; set; }
    }
}
