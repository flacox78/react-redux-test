﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.CatsUI.Models
{
    public enum PetType
    {
        Cat,
        Dog,
        Fish
    }

    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
    }
}
