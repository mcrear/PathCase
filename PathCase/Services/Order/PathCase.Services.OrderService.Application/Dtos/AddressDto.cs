﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.Application.Dtos
{
    public class AddressDto
    {
        public string Province { get;  set; }
        public string District { get;  set; }
        public string Street { get;  set; }
        public string ZipCode { get;  set; }
        public string Description { get;  set; }
    }
}
