using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
	public class SeniorManager:Operator
	{
	    public SeniorManager(string id) : base(id, "Senior manager", true)
	    {
	        this._priority = 3;
	    }
	}
}
