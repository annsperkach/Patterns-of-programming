using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using Lab2;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Car> cars = new List<Car>
            {
            new Car {    CarId = 1,             //1
                         CarBrand = "BMW",
                         CarType = "cuv",
                         CarYear = 2019,
                         CarCost = "3200"},

            new Car {    CarId = 2,             //2
                         CarBrand = "Honda",
                         CarType = "van",
                         CarYear = 2012,
                         CarCost = "1150"},

            new Car {    CarId = 3,             //3
                         CarBrand = "Toyota",
                         CarType = "van",
                         CarYear = 2020,
                         CarCost = "3500"},

            new Car {    CarId = 4,             //4
                         CarBrand = "BMW",
                         CarType = "cuv",
                         CarYear = 2022,
                         CarCost = "4000"},

            new Car {    CarId = 5,             //5
                         CarBrand = "BMW",
                         CarType = "van",
                         CarYear = 2019,
                         CarCost = "2000"},

            new Car {    CarId = 6,             //6
                         CarBrand = "Honda",
                         CarType = "van",
                         CarYear = 2015,
                         CarCost = "1700"},
            };
            List<Client> clients = new List<Client>
            {
                new Client(1, "Bruno", "Pomidorro", "address3"),
                new Client(2, "Marina", "Rachello", "address2"),
                new Client(3, "Porco", "Rocco", "address1"),
            }; 

            List<Agreement> agreements = new List<Agreement>
            {
            new Agreement(1, 3, new DateTime(2022,3,24), new DateTime(2022,4,15),5),
            new Agreement(2, 3, new DateTime(2019,6,13), new DateTime(2019,9,20),2),
            new Agreement(3, 2, new DateTime(2022,4,1), new DateTime(2022,4,30),2),
            new Agreement(4, 2, new DateTime(2021,9,2), new DateTime(2021,9,15),1),
            new Agreement(5, 3, new DateTime(2021,3,25), new DateTime(2021,4,12),3),
            new Agreement(6, 1, new DateTime(2022,3,24), new DateTime(2022,4,15),2),
            };

            //writing our data in the xml file
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("CarClientAgreement.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CarClientAgreement");

                writer.WriteStartElement("Cars");
                foreach (Car car in cars)
                {
                    writer.WriteStartElement("car");
                    writer.WriteElementString("id", car.CarId.ToString());
                    writer.WriteElementString("brand", car.CarBrand);
                    writer.WriteElementString("type", car.CarType);
                    writer.WriteElementString("year", car.CarYear.ToString());
                    writer.WriteElementString("cost", car.CarCost.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteStartElement("Clients");
                foreach (Client cl in clients)
                {
                    writer.WriteStartElement("client");
                    writer.WriteElementString("Id", cl.ClientId.ToString());
                    writer.WriteElementString("firstName", cl.ClientFirstName);
                    writer.WriteElementString("lastName", cl.ClientLastName);
                    writer.WriteElementString("address", cl.ClientAddress);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteStartElement("Agreements");
                foreach (Agreement agr in agreements)
                {
                    writer.WriteStartElement("agreement");
                    writer.WriteElementString("id", agr.AgreementId.ToString());
                    writer.WriteElementString("clientID", agr.ClientsId.ToString());
                    writer.WriteElementString("issueDate", agr.IssueDate.ToString());
                    writer.WriteElementString("returnDate", agr.ReturnDate.ToString());
                    writer.WriteElementString("carsID", agr.CarsId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            XDocument xmlDoc = XDocument.Load("CarClientAgreement.xml");
            OutputXmlFile();
            LinqRequests();
            addClientElementsToXML(xmlDoc);

            Console.ReadKey();
        }

        //linq to xml requests

        //output the xml file
        static void OutputXmlFile()   //1
        {
            XDocument xmlDoc = XDocument.Load("CarClientAgreement.xml");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Clients:");
            Console.ResetColor();

            foreach (XElement clientelement in xmlDoc.Element("CarClientAgreement").Element("Clients").Elements("client"))
            {
                XElement clId = clientelement.Element("Id");
                XElement firstName1 = clientelement.Element("firstName");
                XElement lastName1 = clientelement.Element("lastName");
                XElement address = clientelement.Element("address");

                if (clId != null && firstName1.Value != null && lastName1.Value != null && address != null)
                {
                    Console.WriteLine($"ID: {clId.Value}, Name: {firstName1.Value} {lastName1.Value}\nAddress: {address.Value}\n");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cars:");
            Console.ResetColor();

            foreach (XElement carElement in xmlDoc.Element("CarClientAgreement").Element("Cars").Elements("car"))
            {
                XElement cID = carElement.Element("id");
                XElement cYear = carElement.Element("year");
                XElement cBrand = carElement.Element("brand");
                XElement cType = carElement.Element("type");
                XElement cCost = carElement.Element("cost");

                if (cID != null && cYear != null && cBrand != null && cType != null)
                {
                    Console.WriteLine($"ID: {cID.Value}\nBrand: {cBrand.Value}, Year of production: {cYear.Value}\n" +
                        $"Type: {cType.Value}$, Cost: {cCost.Value}$,\n");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Agreements:");
            Console.ResetColor();

            foreach (XElement carElement in xmlDoc.Element("CarClientAgreement").Element("Agreements").Elements("agreement"))
            {
                XElement aID = carElement.Element("id");
                XElement acliId = carElement.Element("clientID");
                XElement aIssue = carElement.Element("issueDate");
                XElement aReturn = carElement.Element("returnDate");
                XElement acarId = carElement.Element("carsID");

                if (aID != null && aIssue != null && acliId != null && acarId != null && aReturn != null)
                {
                    Console.WriteLine($"Id: {aID.Value},\nClient id: {acliId.Value},\nIssue date: {aIssue.Value}\n " +
                        $"Car id: {acarId.Value},\nThe end of egreement: {aReturn.Value}\n");
                }
            }
        }

        static void LinqRequests()
        {
            XDocument xmlDoc = XDocument.Load("CarClientAgreement.xml");
            IEnumerable<XElement> clientXml = xmlDoc.Element("CarClientAgreement").Element("Clients").Elements("client");
            IEnumerable<XElement> carXml = xmlDoc.Element("CarClientAgreement").Element("Cars").Elements("car");
            IEnumerable<XElement> agreementXml = xmlDoc.Element("CarClientAgreement").Element("Agreements").Elements("agreement");

            //2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCircumstance that year > 2017 and sorting descending:");                                     
            Console.ResetColor();

            var q2 = from p in carXml
                              where (int)p.Element("year") > 2017
                              orderby (int)p.Element("year") descending
                              select p;
            foreach (var p in q2)
            {
                Console.WriteLine($"Year: {p.Element("year").Value} Id: {p.Element("id").Value} Brand: {p.Element("brand").Value} Type: {p.Element("type").Value}");
            }
            Console.WriteLine();

            //3
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nwhose name is Bruno and id less than 2");                           
            Console.ResetColor();
            var q3 = from x in clientXml
                     where x.Element("firstName").Value == "Bruno" && ((int)x.Element("Id") < 2)
                     select x;
            foreach (var x in q3)
                Console.WriteLine($"Id: {x.Element("Id").Value} Name: {x.Element("firstName").Value} {x.Element("lastName").Value}");
            Console.WriteLine();

            //4
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSorting using expansion methods");
            Console.ResetColor();
            var q4 = carXml.Where((x) =>
            {
                return (int)x.Element("id") > 1 && ((int)x.Element("year") < 2018 || x.Element("type").Value == "van");
            }).OrderByDescending(x => (int)x.Element("year")).ThenByDescending(x => (int)x.Element("id"));
            foreach (var x in q4) 
            { Console.WriteLine($"Id: {x.Element("id").Value} Year: {x.Element("year").Value }" +
                $"Brand: {x.Element("brand").Value} Type: {x.Element("type").Value} Cost: {x.Element("cost").Value}"); 
            }
            Console.WriteLine();

            //5
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPartitioning Operators");
            Console.WriteLine("Using SkipWhile и TakeWhile");
            Console.ResetColor();
            var q5 = carXml.SkipWhile(x => ((int)x.Element("id") < 4)).TakeWhile(x => (int)x.Element("id") <= 6);
            foreach (var x in q5)
            {
                Console.WriteLine($"Id: {x.Element("id").Value} Year: {x.Element("year").Value} " +
                  $"Brand: {x.Element("brand").Value} Type: {x.Element("type").Value} Cost: {x.Element("cost").Value}");
            }
            Console.WriteLine();

            //6
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nJoin");
            Console.WriteLine("Inner Join using Where");
            Console.ResetColor();
            var q6 = from x in carXml
                     from y in agreementXml
                     where x.Element("id").Value == y.Element("carsID").Value
                     select new { CarId = y.Element("id").Value, carBrand = x.Element("brand").Value, cIssueDate = y.Element("issueDate").Value };
            foreach (var x in q6)
                Console.WriteLine(x);

            //7
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInner Join using Join");
            Console.ResetColor();
            var q7 = from x in clientXml
                     join y in agreementXml on x.Element("Id").Value equals y.Element("clientID").Value
                     select new { v1 = x.Element("firstName").Value + " " + x.Element("lastName").Value, v2 = y.Element("issueDate").Value, v3 = y.Element("returnDate").Value };
            foreach (var x in q7)
                Console.WriteLine(x);

            //8
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGroup Join");
            Console.ResetColor();
            var q8 = from x in carXml
                     join y in agreementXml on x.Element("id").Value equals y.Element("carsID").Value into temp
                      select new { v1 = x.Element("brand").Value, v2 = x.Element("id").Value, d2Group = temp };
            foreach (var x in q8)
            {
                Console.WriteLine();
                Console.WriteLine($"CarBrand = {x.v1}, CarId = {x.v2}");
                foreach (var t in x.d2Group)
                    Console.WriteLine(t);
            }

            //9
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFunction of aggregation");
            Console.WriteLine("Count - amount of elements");
            Console.ResetColor();
            Console.WriteLine(carXml.Count());

            //10
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCount - amount with the condition");
            Console.ResetColor();
            Console.WriteLine(carXml.Count(x => (int)x.Element("id") > 1));

            //11
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData conversion");
            Console.WriteLine("Result turns in massive");
            Console.ResetColor();
            var q11 = (from x in clientXml select x).ToArray();
            Console.WriteLine(q11.GetType().Name);
            foreach (var x in q11)
                Console.WriteLine(x);

            //12
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nResult turns in Lookup");
            Console.ResetColor();
            var q12 = (from x in clientXml select x).ToLookup(x => x.Element("Id").Value);
            Console.WriteLine(q12.GetType().Name);
            foreach (var x in q12)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x)
                    Console.WriteLine(" " + y);
            }

            //13
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGetting the item");
            Console.WriteLine("The first element of the sample");
            Console.ResetColor();
            var q13 = (from x in clientXml select x).First(x => (int)x.Element("Id") == 1);
            Console.WriteLine(q13);

            //14
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem in the specified position");
            Console.ResetColor();
            var q14 = (from x in carXml select x).ElementAt(2);
            Console.WriteLine(q14);

            //15
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sequence generation");
            Console.WriteLine("Range");
            Console.ResetColor();
            foreach (var x in Enumerable.Range(2, 5))
                Console.WriteLine(x);

        }

        //the ability to add new clients
        static void addClientElementsToXML(XDocument xmlDoc)
        {
            Console.WriteLine("Input an ID of new client: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool original = false;
            do
            {
                var selectedstorages = from p in xmlDoc.Descendants("clients")
                                       where p.Element("Id").Value.Contains(id.ToString())
                                       select p;
                if (selectedstorages.Count() != 0)
                {
                    Console.WriteLine("Client with that ID is already exist. Try again: ");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                else original = true;
            } while (original == false);

            Console.WriteLine("Input your Name: ");
            string clientFirstName = Console.ReadLine();

            Console.WriteLine("Input your Last Name: ");
            string clientLastName = Console.ReadLine();

            xmlDoc.Element("CarClientAgreement").Element("Clients").Add(
                    new XElement("client",
                    new XElement("Id", id.ToString()),
                    new XElement("firstName", clientFirstName),
                    new XElement("lastName", clientLastName)
                )
            );
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The new Client has been successfully added.");
            Console.ResetColor();

            xmlDoc.Save("CarClientAgreement.xml");
        }
    }
}
