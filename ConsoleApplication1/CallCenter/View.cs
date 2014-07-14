using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CallCenter
{
	public class View
	{

		public static void Display(string value)
		{
			Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
		    Log(value);
		}

	    public static void DisplayInfoOfCall(string message)
	    {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Log(message);
	    }

	    private static void Log(string text)
	    {
            String path = string.Format("Log{0}.txt", DateTime.Now.Date.ToShortDateString());
            TextWriter tw = new StreamWriter(path,true);

            // write a line of text to the file
            tw.WriteLine(string.Format("{0} : {1}",DateTime.Now, text));
            // close the stream
            tw.Close();
	    }

	}
}
