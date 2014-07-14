using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
    public abstract class Employee : IComparable
    {
	    protected string _id { get; set; }
        protected bool _isFree{get;set;}
	    protected string _position { get; set; }
        protected int _priority { get; set; }

        protected int _timeToCall = 15;// seconds for answer

	    public Employee(string id, string position, bool status)
	    {
			this._id = id;
			this._position = position;
			this._isFree = status;
	    }

	    public bool getStatus()
	    {
		    return this._isFree;
	    }
		public void setStatus(bool status)
		{
			this._isFree = status;
		}

	    public string getPosition()
	    {
		    return this._position;
	    }

        public string getID()
        {
            return this._id;
        }

        public override string ToString()
	    {
		    return String.Format(" {0} {1} ", _position, _id);
	    }

        public abstract void getCall();

        public int CompareTo(object obj)
        {
            var otherEmployee = (Employee)obj;
            return this._priority.CompareTo(otherEmployee._priority);
        }
    }
}
