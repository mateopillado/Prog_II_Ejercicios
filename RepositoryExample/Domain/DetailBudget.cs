﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class DetailBudget
    {
        public Product Product { get; set; }

        public int Cant {  get; set; }

        public double Price { get; set; }


        public double SubTotal() { return Cant * Price; }




    }
}