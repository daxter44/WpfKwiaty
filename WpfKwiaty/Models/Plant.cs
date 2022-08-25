﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKwiaty.Models
{
    public class Plant
    {
        public int id { get; set; }
        public string name { get; set; }  
        public DateTime dateOfBirth { get; set; }
        public string type { get; set; }
    }
}
