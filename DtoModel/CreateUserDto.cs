using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateOnly Dateofbirth { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
