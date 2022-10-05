using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabLinq
{
    class Program
    {
        public class Car
        {
            public int CarId;
            public string CarBrand;
            public string CarType;
            public int CarYear;
            public string PledgeAmount;
            public string CarCost;
            public Car(int carId, string carBrand, string carType, int carYear, string pledgeAmount, string carCost)
            {
                this.CarId = carId;
                this.CarBrand = carBrand;
                this.CarType = carType;
                this.CarYear = carYear;
                this.PledgeAmount = pledgeAmount;
                this.CarCost = carCost;
            }

            public override string ToString()
            {
                return string.Format($"(CarId={this.CarId}; CarBrand={this.CarBrand}; CarType={this.CarType}; " +
                    $"CarYear={this.CarYear}; PledgeAmount={this.PledgeAmount}; CarCost={this.CarCost})");
            }
            /*public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"\nCarId={this.CarId};\t\t\t\t\tCarBrand={this.CarBrand};\t\t\tCarType={this.CarType}");
                sb.AppendLine($"CarYear={this.CarYear};\t\t\tPledgeAmount={this.PledgeAmount}");
                sb.AppendLine($"CarCost={this.CarCost}");
                Console.WriteLine();
                return sb.ToString();
            }*/
        }
        public class DataEqualityComparer : IEqualityComparer<Car>
            {
                public bool Equals(Car x, Car y)
                {
                    bool result = false;
                    if (x.CarId == y.CarId && x.CarBrand == y.CarBrand && x.CarType == y.CarType
                        && x.CarYear == y.CarYear && x.PledgeAmount == y.PledgeAmount
                        && x.CarCost == y.CarCost)
                        result = true;
                    return result;
                }
                public int GetHashCode(Car obj)
                {
                    return obj.CarId;
                }
            }
        

            static List<Car> d1 = new List<Car>()
            {
                new Car(1, "BMW", "cuv", 2019, "1000", "3200"),
                new Car(2, "Honda", "van", 2012, "550", "1150"),
                new Car(3, "Toyota", "van", 2022, "2000", "4000"),
                new Car(4, "BMW", "cuv", 2020, "1200", "3500"),
                new Car(5, "BMW", "van", 2019, "850", "2000"),
                new Car(6, "Honda", "van", 2015, "400", "1700")
            };

            static List<Car> d1_for_distinct = new List<Car>()
            {
                new Car(1, "BMW", "cuv", 2019, "1000", "3200"),
                new Car(1, "BMW", "cuv", 2020, "1200", "3500"),
                new Car(1, "Honda", "van", 2012, "550", "1150"),
                new Car(2, "Toyota", "van", 2012, "550", "1150"),
                new Car(2, "Honda", "van", 2012, "550", "1150"),
                new Car(3, "Toyota", "van", 2022, "1900", "3900")
            };

            static List<Car> d1_2 = new List<Car>()
            {
                new Car(1, "Honda", "cuv", 2019, "1000", "3200"),
                new Car(2, "Honda", "van", 2012, "550", "1150"),
                new Car(3, "Toyota", "van", 2022, "2000", "4000"),
            };
        /*
            public static void PrintCar(Car car)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"CarId={car.CarId};\tCarBrand={car.CarBrand}");
                sb.AppendLine($"CarType={car.CarType};\tCarYear={car.CarYear}");
                sb.AppendLine($"CarCost={car.CarCost};\tPledgeAmount={car.PledgeAmount}");
                Console.WriteLine(sb);
                Console.WriteLine();
            }
        */
        public class Client
        {
            public int ClientId;
            public string ClientFirstName;
            public string ClientLastName;
            public string ClientAddress;
            public string ClientPhoneNumber;

            public Client(int clientId, string firstName, string lastName, string address, string phoneNumber)
            {
                this.ClientId = clientId;
                this.ClientFirstName = firstName;
                this.ClientLastName = lastName;
                this.ClientAddress = address;
                this.ClientPhoneNumber = phoneNumber;
            }
        }
      
        public class Agreement: Client
        {
            public int AgreementId;
            public int CarsId;
            public DateTime IssueDate;
            public DateTime ReturnDate;
            public Agreement(int id, int clientId, string firstName, string lastName, string address, string phoneNumber , DateTime issueDate, DateTime returnDate, int carsId) : base (clientId, firstName, lastName, address, phoneNumber)
            {
                this.AgreementId = id;
                this.ClientId = clientId;
                this.ClientFirstName = firstName;
                this.ClientLastName = lastName;
                this.ClientAddress = address;
                this.ClientPhoneNumber = phoneNumber;
                this.IssueDate = issueDate;
                this.ReturnDate = returnDate;
                this.CarsId = carsId;
            }

            public string PrintClient()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Id of Agreement={this.AgreementId};\tClient Id={this.ClientId}");
                sb.AppendLine($"Client Name={this.ClientFirstName};\tClient Surname={this.ClientLastName}");
                sb.AppendLine($"Client Address={this.ClientAddress};\tClientPhoneNumber={this.ClientPhoneNumber}");
                sb.AppendLine($"Issue Date={this.IssueDate};\tReturn Date={this.ReturnDate}");
                sb.AppendLine($"Car Id={this.CarsId}");
                Console.WriteLine();
                return sb.ToString();
            }
        }

        static List<Agreement> d2 = new List<Agreement>()
        {
            new Agreement(1, 3, "Porco", "Rocco", "address1", "097637344", new DateTime(2022,3,24), new DateTime(2022,4,15),5),
            new Agreement(2, 3, "Porco", "Rocco", "address1", "097637344", new DateTime(2019,6,13), new DateTime(2019,9,20),2),
            new Agreement(3, 2, "Marina", "Rachello", "address2", "096478737", new DateTime(2022,4,1), new DateTime(2022,4,30),2),
            new Agreement(4, 2, "Marina", "Rachello", "address2", "096478737", new DateTime(2021,9,2), new DateTime(2021,9,15),1),
            new Agreement(5, 3, "Porco", "Rocco", "address1", "097637344", new DateTime(2021,3,25), new DateTime(2021,4,12),3),
            new Agreement(6, 1, "Bruno", "Pomidorro", "address3", "097346443", new DateTime(2022,3,24), new DateTime(2022,4,15),2),
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Simple requests");
            Console.WriteLine("Simple selection of items");
            var q1 = from x in d1
                     select x;
            foreach (var x in q1)
                Console.WriteLine(x);

            Console.WriteLine("\nSampling a single field (projection)");
            var q2 = from x in d1
                     select x.CarCost;
            foreach (var x in q2)
                Console.WriteLine(x);

            Console.WriteLine("\nCreate a new anonymous object");
            var q3 = from x in d1
                     select new { id = x.CarId, brand = x.CarBrand, year = x.CarYear };
            var t = new { id = 2, brand = "", year = 2003 };
            foreach (var x in q3)
            {
                t = x;
                Console.WriteLine(x);
            }

            Console.WriteLine("\nCircumstances:");
            var q4 = from x in d1
                     where x.CarId > 1 && (x.CarYear > 2018 || x.CarBrand == "BMW")
                     select x;
            foreach (var x in q4)
                Console.WriteLine(x);

            Console.WriteLine("\nSort");
            var q5 = from x in d1
                     where x.CarId > 1 && (x.CarYear < 2018 || x.CarType == "van")
                     orderby x.CarId descending
                     select x;
            foreach (var x in q5)
                Console.WriteLine(x);

            Console.WriteLine("\nSorting using expansion methods");
            var q6 = d1.Where((x) =>
            {
                return x.CarId > 1 && (x.CarYear < 2018 || x.CarType == "van");
            }).OrderByDescending(x => x.CarYear).ThenByDescending(x => x.CarId);
            foreach (var x in q6)
                Console.WriteLine(x);

            Console.WriteLine("\nPartitioning Operators");
            Console.WriteLine("Using SkipWhile и TakeWhile");
            var q7 = d1.SkipWhile(x => (x.CarId < 4)).TakeWhile(x => x.CarId <= 6);
            foreach (var x in q7)
                Console.WriteLine(x.CarId);

            Console.WriteLine("\nJoin");
            Console.WriteLine("Inner Join using Where");
            var q8 = from x in d1
                      from y in d2
                      where x.CarId == y.CarsId
                      select new { CarId = y.CarsId, carBrand = x.CarBrand, clientName = y.ClientFirstName };
            foreach (var x in q8)
                Console.WriteLine(x);

            Console.WriteLine("\nInner Join using Join");
            var q9 = from x in d1
                      join y in d2 on x.CarId equals y.CarsId
                      select new { v1 = y.ClientFirstName, v2 = y.ClientLastName, v3 = x.CarType, v4 = x.CarYear };
            foreach (var x in q9)
                Console.WriteLine(x);
            
            Console.WriteLine("\nInner Join (save the object)");
            var q10 = from x in d1
                      join y in d2 on x.CarId equals y.CarsId
                      select new { v1 = y.AgreementId, v2 = y.ClientFirstName, d2Group = x.ToString() };
            foreach (var x in q10)
                Console.WriteLine(x);

            //Choose all elements from d2 and if it's connected with d1 (outer join)
            //In temp put the whole group, then we sort out its elements separately

            Console.WriteLine("\nGroup Join");
            var q11 = from x in d1
                      join y in d2 on x.CarId equals y.CarsId into temp
                      select new { v1 = x.CarBrand, v2=x.CarId, d2Group = temp };
            foreach (var x in q11)
            {
                Console.WriteLine();
                Console.WriteLine($"CarBrand = {x.v1}, CarId = {x.v2}");
                foreach (var y in x.d2Group)
                Console.WriteLine(y);
            }

            Console.WriteLine("\nCross Join и Group Join");
            var q12 = from x in d1
                      join y in d2 on x.CarId equals y.CarsId into temp
                      from te in temp
                      select new { v1 = x.CarBrand, v2 = te.ClientFirstName, cnt = temp.Count() };
            foreach (var x in q12)
                Console.WriteLine(x);

            Console.WriteLine("\nUsing Join for folded keys");
            var q13 = from x in d1
                      join y in d1_for_distinct on new { x.CarId, x.CarYear } equals new { y.CarId, y.CarYear } into details
                      from d in details
                      select d;
            foreach (var x in q13)
                Console.WriteLine(x);

            Console.WriteLine("\nActions on sets");
            Console.WriteLine("Distinct - for values");
            var q14 = (from x in d1 select x.CarBrand).Distinct();
            foreach (var x in q13)
                Console.WriteLine(x);

            Console.WriteLine("\nDistinct - for objects");
            var q15 = (from x in d1_for_distinct select x).Distinct(new DataEqualityComparer());
            foreach (var x in q15)
                Console.WriteLine(x);

            Console.WriteLine("\nUnion - merging with the exception of duplicates");
            int[] i1 = new int[] { 1, 2, 6, 4 };
            int[] i1_1 = new int[] { 6, 3, 4, 1 };
            int[] i2 = new int[] { 2, 3, 4, 6 };
            foreach (var x in i1.Union(i2))
                Console.WriteLine(x);

            Console.WriteLine("\nUnion - association for objects");
            foreach (var x in d1.Union(d1_for_distinct))
                Console.WriteLine(x);

            Console.WriteLine("\nUnion - aggregation for objects excluding duplicates 1");
            foreach (var x in d1.Union(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);

            Console.WriteLine("\nConcat - merging without excluding duplicates");
            foreach (var x in i1.Concat(i2))
                Console.WriteLine(x);

            Console.WriteLine("\nSequenceEqual - check the coincidence and order");
            Console.WriteLine(i1.SequenceEqual(i1));
            Console.WriteLine(i1.SequenceEqual(i2));

            Console.WriteLine("\nIntersection of sets");
            foreach (var x in i1.Intersect(i2))
                Console.WriteLine(x);

            Console.WriteLine("\nIntersection of sets for objects");
            foreach (var x in d1.Intersect(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);

            Console.WriteLine("\nExcept ");
            foreach (var x in i1.Except(i2))
                Console.WriteLine(x);

            Console.WriteLine("\nExcept - for objects");
            foreach (var x in d1.Except(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);

            Console.WriteLine("\nFunction of aggregation");
            Console.WriteLine("Count - amount of elements");
            Console.WriteLine(d1.Count());

            Console.WriteLine("\nCount - amount with the condition");
            Console.WriteLine(d1.Count(x => x.CarId > 1));

            Console.WriteLine("\nAggregate the values");
            var qa1 = d1.Aggregate(new Car(0, "", "", 0, "", ""), (total, next) =>
            {
                if (next.CarId > 1) total.CarId += next.CarId;
                return total;
            });
            Console.WriteLine(qa1);

            var q16 = from x in d1.Union(d1_2)
                      group x by x.CarYear into g
                      select new { Key = g.Key, Values = g };
            foreach (var x in q16)
            {
                Console.WriteLine("\nGroup by year: " + x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }

            Console.WriteLine("\nGroup by aggregation function");
            var q17 = from x in d1.Union(d1_2)
                      group x by x.CarYear into g
                      select new
                      {
                          Key = g.Key,
                          Values = g,
                          cnt = g.Count(),
                          cnt1 =
                      g.Count(x => x.CarId > 1),
                          sum = g.Sum(x => x.CarId),
                          min = g.Min(x => x.CarId)
                      };
            foreach (var x in q17)
            {
                Console.WriteLine(x);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }

            Console.WriteLine("\nGroup - Any");
            var q18 = from x in d1.Union(d1_2)
                      group x by x.CarYear into g
                      where g.Any(x => x.CarId > 3)
                      select new { Key = g.Key, Values = g };
            foreach (var x in q18)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }

            Console.WriteLine("\nGroup - All");
            var q19 = from x in d1.Union(d1_2)
                      group x by x.CarYear into g
                      where g.All(x => x.CarId > 1)
                      select new { Key = g.Key, Values = g };
            foreach (var x in q19)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }

            Console.WriteLine("\nData conversion");
            Console.WriteLine("Result turns in massive");
            var e3 = (from x in d1 select x).ToArray();
            Console.WriteLine(e3.GetType().Name);
            foreach (var x in e3)
                Console.WriteLine(x);

            Console.WriteLine("\nResult turns in Dictionary");
            var e4 = (from x in d1 select x).ToDictionary(x => x.CarId);
            Console.WriteLine(e4.GetType().Name);
            foreach (var x in e4)
                Console.WriteLine(x);

            Console.WriteLine("\nResult turns in Lookup");
            var e5 = (from x in d1_for_distinct select x).ToLookup(x => x.CarId);
            Console.WriteLine(e5.GetType().Name);
            foreach (var x in e5)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x)
                    Console.WriteLine(" " + y);
            }

            Console.WriteLine("\nGetting the item");
            Console.WriteLine("The first element of the sample");
            var f1 = (from x in d2 select x).First(x => x.ClientId == 1);
            Console.WriteLine(f1.PrintClient());

            Console.WriteLine("\nThe first element of the sample or on default");
            var f2 = (from x in d2 select x).FirstOrDefault(x => x.ClientId == 9);
            Console.WriteLine(f2 == null ? "null" : f2.ToString());

            Console.WriteLine("\nItem in the specified position");
            var f3 = (from x in d2 select x).ElementAt(2);
            Console.WriteLine(f3.PrintClient());

            Console.WriteLine("Sequence generation");
            Console.WriteLine("Range");
            foreach (var x in Enumerable.Range(2, 5))
                Console.WriteLine(x);
            Console.WriteLine("Repeat");
            foreach (var x in Enumerable.Repeat<int>(8, 5))
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}