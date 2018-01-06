using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.CatsUI.Models
{
    public enum Gender {
        Male,
        Female
    }

    public class Owner
    {
        public string Name { get; set; }        
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
