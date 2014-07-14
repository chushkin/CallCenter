using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1.CallCenter
{
    public class DataBase
    {
        private const string _DB = "staff.xml";
        private XmlWriter _writer;
        private XmlTextReader _reader;
        public bool Write(List<Employee> staff)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                _writer = XmlWriter.Create(_DB, settings);

                _writer.WriteComment("XML DataBase of employees");

                // Write an element (this one is the root).
                _writer.WriteStartElement("staff");

                foreach (var employee in staff)
                {
                    _writer.WriteStartElement("employee");
                    _writer.WriteAttributeString("id", employee.getID());
                    _writer.WriteAttributeString("position", employee.getPosition());
                    _writer.WriteAttributeString("isfree", employee.getStatus().ToString());
                    _writer.WriteEndElement();
                }

                _writer.WriteEndElement();

                // Write the XML to file and close the writer.
                _writer.Flush();
                _writer.Close();
            }

            finally
            {
                if (_writer != null)
                    _writer.Close();
            }
            return true;
        }

        public List<Employee> Loading()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                _reader = new XmlTextReader(_DB);

                while (_reader.Read())
                {
                    while (_reader.Read())
                    {
                        if (_reader.NodeType == XmlNodeType.Element && _reader.Name.Contains("employee"))
                        {
                            string id="";
                            string type="";
                            bool isFree;
                            while (_reader.MoveToNextAttribute())
                            {
                                switch (_reader.Name)
                                {
                                    case "id":
                                        id = _reader.Value;
                                        break;
                                    case "position":
                                        type = _reader.Value;
                                        break;
                                }

                            }

                            switch (type.Trim())
                            {
                                case "Operator":
                                    employees.Add(new Operator(id));
                                    break;
                                case "Manager":
                                    employees.Add(new Manager(id));
                                    break;
                                case "Senior manager":
                                    employees.Add(new SeniorManager(id));
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not found fiale");
            }
            return employees;
        }
    }
}
