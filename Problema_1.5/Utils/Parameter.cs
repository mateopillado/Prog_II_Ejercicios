using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Utils
{
    public class Parameter
    {

        public string name { get; set; }
        public object value { get; set; }

        public Parameter(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
