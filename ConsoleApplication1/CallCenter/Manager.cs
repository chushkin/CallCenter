using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
    public class Manager:Operator
    {
        public Manager(string id) : base(id, "Manager", true)
        {
            this._priority = 2;
        }
    }
}
