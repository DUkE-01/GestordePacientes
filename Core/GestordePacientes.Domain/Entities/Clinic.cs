﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordePacientes.Core.Domain.Entities
{
    public class Clinic
    { 
            public int IdClinic { get; set; }  
            public string? Name { get; set; }  
            public string? Address { get; set; }  
            public string? PhoneNumber { get; set; }  
 
    }
}
