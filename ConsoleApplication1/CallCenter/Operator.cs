using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
    public class Operator:Employee
    {
		
	    public Operator(string id):base(id, "Operator", true){}

        public Operator(string id, string position, bool status) : base(id, position, status)
        {
            this._priority = 1;
        }

        public override void getCall()
        {
            View.DisplayInfoOfCall("Hello! I’m " + ToString());
            this._isFree = false;
            int contTime = 0;
            
            while (!getStatus())
            {
                
                if(contTime==this._timeToCall)
                    this._isFree = true;
              
                Thread.Sleep(TimeSpan.FromSeconds(1));
                ++contTime;
                
            }
            
            View.DisplayInfoOfCall(ToString() + " ended a call.");
        }
    }
}
