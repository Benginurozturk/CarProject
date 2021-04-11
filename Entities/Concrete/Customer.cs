﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public int FindexScore { get; set; }
    }

}
