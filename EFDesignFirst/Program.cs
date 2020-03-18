using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDesignFirst
{
    class Program
    {
        private InputDetails details;

        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Design First");
            //TestPerson();
            Console.ReadKey();

            TesTOneToMany();

        }

        //static void TestPerson()
        //{
        //    using (Model1Container context = new Model1Container())
        //    {
        //        Person p = new Person()
        //        {
        //            FirstName = "Julia",
        //            LastName = "Roberts",
        //            MiddleName = "Muriel",
        //            TelephoneNumber = "0123456789"
        //        };
        //        context.People.Add(p);
        //        context.SaveChanges();
        //        var items = context.People;
        //        foreach (var item in items)
        //        {
        //         Console.WriteLine("{0} {1}", item.Id, item.FirstName);   
        //        }

        //    }
        //}

        private static void TesTOneToMany()
        {
            using (InputDetails details = new InputDetails())
            {
                Console.WriteLine("Customer name: ");
                details.CustomerName = Console.ReadLine();

                Console.WriteLine("Customer  city: ");
                details.CustomerCity = Console.ReadLine();

                Console.WriteLine("First order value: ");
                details.FirstOrderValue = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("First order date: ");
                details.FirstOrderDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Second order value: ");
                details.SecondOrderValue = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Second order date: ");
                details.SecondOrderDate = Convert.ToDateTime(Console.ReadLine());


                Console.WriteLine("One to many association");
                using (ModelOneToManyContainer context =
                    new ModelOneToManyContainer())
                {
                    Customer c = new Customer()
                    {
                        Name = details.CustomerName,
                        City = details.CustomerName
                    };
                    Order o1 = new Order()
                    {
                        TotalValue = details.FirstOrderValue,
                        Date = details.FirstOrderDate,
                        Customer = c
                    };
                    Order o2 = new Order()
                    {
                        TotalValue = details.SecondOrderValue,
                        Date = details.SecondOrderDate,
                        Customer = c
                    };
                    context.Customers.Add(c);
                    context.Orders.Add(o1);
                    context.Orders.Add(o2);
                    context.SaveChanges();
                    var items = context.Customers;
                    foreach (var x in items)
                    {
                        Console.WriteLine("Customer : {0}, {1}, {2}",
                            x.CustomerId, x.Name, x.City);
                        foreach (var ox in x.Orders)
                            Console.WriteLine("\tOrders: {0}, {1}, {2}",
                                ox.OrderId, ox.Date, ox.TotalValue);
                    }
                }
            }
        }

        private void ReadValues()
        {
            
        }
    }

    public class InputDetails : IDisposable
    {
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public DateTime FirstOrderDate { get; set; }
        public int FirstOrderValue { get; set; }
        public DateTime SecondOrderDate { get; set; }
        public int SecondOrderValue { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
