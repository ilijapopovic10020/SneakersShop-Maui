﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Models
{
    public class GetCitiesModel : BaseModel
    {
        public string? Name { get; set; }
        public string? ZipCode { get; set; }
    }
}
