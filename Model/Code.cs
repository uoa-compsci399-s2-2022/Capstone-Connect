﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capstone_Connect.Model
{
    public class Code
    {
        [Key]
        public int ID { get; set; }
        public string SecretCode { get; set; }
    }
}
