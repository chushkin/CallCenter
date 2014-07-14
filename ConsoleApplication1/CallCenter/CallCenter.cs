using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
    public class CallCenter:Application
    {
        private bool close = false;
        private List<Employee> _operators { get; set; }

        public CallCenter()
        {
            this._operators = new List<Employee>();
            onCreate();
            Control();
        }

        public void Start()
        {
            this._operators = new List<Employee>();
            this._operators = new DataBase().Loading();
            this._operators.Sort();
            bool exit = false;
            while (!exit)
            {
                View.DisplayInfoOfCall("Сontrol of the Call Center");
                View.Display("call - to call");
                View.Display("all - get the full list of operators");
                View.Display("free - get a list of free operators");
                View.Display("busy - get a list of busy operators");
                //View.Display("end call - end call to the id");
                View.Display("exit - go to the main menu");

                switch (Console.ReadLine())
                {
                    case "exit":
                        exit = true;
                        break;
                    case "all":
                        foreach (var employee in _operators)
                        {
                            View.DisplayInfoOfCall(employee + " status: " + employee.getStatus());
                        }
                        break;
                    case "free":
                        foreach (var employee in _operators)
                        {
                            if (employee.getStatus())
                            View.DisplayInfoOfCall(employee + " status: " + employee.getStatus());
                        }
                        break;
                    case "busy":
                        foreach (var employee in _operators)
                        {
                            if (!employee.getStatus())
                                View.DisplayInfoOfCall(employee + " status: " + employee.getStatus());
                        }
                        break;
                    case "call":
                        var freeEmployee = getFree();
                        if (freeEmployee != null)
                        {
                            new Thread(freeEmployee.getCall).Start();
                        }
                        else
                        {
                            View.Display("--> Sorry! All operators are busy. Try again later.");
                        }
                        break;
                }

            }
        }

        public void Restart()
		{
            Stop();
            View.Display("!Restart!");
            Start();
		}

		public void Stop()
		{
		    foreach (var employee in this._operators)
		    {
                if(!employee.getStatus())
                    employee.setStatus(true);
		    }
		}

        private Employee getFree()
        {
            foreach (var employee in this._operators)
            {
                if (employee.getStatus())
                    return employee;
            }
            return null;
        }

        private void onCreate()
        {
            View.Display("Before starting simulation you should configure number of operators:");
            View.Display("Enter the number of operators:");
            addEmployees("operator",Convert.ToInt32(Console.ReadLine()));
            View.Display("Enter the number of managers:");
            addEmployees("manager", Convert.ToInt32(Console.ReadLine()));
            View.Display("Enter the number of senior managers:");
            addEmployees("senior manager", Convert.ToInt32(Console.ReadLine()));
            new DataBase().Write(this._operators);
        }

        private void addEmployees(string typeEmployee, int num)
        {
            switch (typeEmployee)
            {
                case "operator":
                    for (int i = 0; i < num; i++)
                    {
                        _operators.Add(new Operator(""+_operators.Count+1));
                    }
                    break;
                case "manager":
                    for (int i = 0; i < num; i++)
                    {
                        _operators.Add(new Manager("" + _operators.Count + 1));
                    }
                    break;
                case "senior manager":
                    for (int i = 0; i < num; i++)
                    {
                        _operators.Add(new SeniorManager("" + _operators.Count + 1));
                    }
                    break;
            }
        }

        private void Control()
        {
            while (!close)
            {
                View.DisplayInfoOfCall("+++++++++++++++++++++++++++");
                View.Display("Сontrol of the application:");
                View.Display("start - to start");
                View.Display("restart");
                View.Display("stop");
                View.Display("exit");
                
                switch (Console.ReadLine())
                {
                    case "exit":
                        close = true;
                        break;
                    case "start":
                        Start();
                        break;
                    case "restart":
                        Restart();
                        break;
                    case "stop":
                        Stop();
                        break;
                }
            }
        }

    }
}
