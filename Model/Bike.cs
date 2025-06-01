using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bike
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public int Userid { get; set; }
        public User User { get; set; }
    }
}
