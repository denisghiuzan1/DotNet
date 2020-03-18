using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ModelDesignFirst.SelfReferenceCodeFirst;

namespace ModelDesignFirst
{
    internal class Program
    {
        //private static void Main(string[] args)
        //{
        //    //Console.WriteLine("Test Model Designer First");
        //    //TestPerson();
        //    //TestOneToMany();
        //    //TestManyToMany();

        //    //TestSelfReference();

        //    //TestVerticalSplitting();
        //    //TestSplitting();
        //    TestProgram.TestMostenireTip();
        //    Console.ReadKey();
        //}

        

        private static void TestPerson()
        {
            using (var context = new TestPersonEntities())
            {
                var p = new Person();
                Console.WriteLine("First name: ");
                p.FirstName = Console.ReadLine();
                Console.WriteLine("Last name:");
                p.LastName = Console.ReadLine();
                Console.WriteLine("Middle Name:");
                p.MiddleName = Console.ReadLine();
                Console.WriteLine("Telephone number:");
                p.TelephoneNumber = Console.ReadLine();

                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        private static void TestOneToMany()
        {
            Console.WriteLine("One to many association");
            using (var context =
                new TestPersonEntities())
            {
                var c = new Customer();
                Console.WriteLine("Customer name:");
                c.Name = Console.ReadLine();
                Console.WriteLine("Customer city:");
                c.City = Console.ReadLine();

                var o1 = new Order();
                Console.WriteLine("Order value:");
                o1.TotalValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Order Date:");
                o1.Date = Convert.ToDateTime(Console.ReadLine());
                o1.Customer = c;

                var o2 = new Order();
                Console.WriteLine("Order value:");
                o2.TotalValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Order Date:");
                o2.Date = Convert.ToDateTime(Console.ReadLine());
                o2.Customer = c;

                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var customer in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                        customer.Id, customer.Name, customer.City);
                    foreach (var order in customer.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                            order.Id, order.Date, order.TotalValue);
                }
            }
        }

        private static void TestManyToMany()
        {
            Console.WriteLine("Many to many association");
            using (var context =
                new TestPersonEntities())
            {
                var artist = new Artist();
                var album = new Album();

                Console.WriteLine("Artist first name:");
                artist.FirstName = Console.ReadLine();
                Console.WriteLine("Artist last name:");
                artist.LastName = Console.ReadLine();
                Console.WriteLine("Artist first name:");

                Console.WriteLine("Album name:");
                album.AlbumName = Console.ReadLine();
                album.Artists = new List<Artist> {artist};

                artist.Albums = new List<Album> {album};

                context.Artists.Add(artist);
                context.Albums.Add(album);
                context.SaveChanges();
                var items = context.Artists;
                
                foreach (var item in items)
                {
                    Console.WriteLine("Customer : {0}, {1}",
                        item.Id, item.FirstName);
                    foreach (var al in artist.Albums)
                        Console.WriteLine("\tOrders: {0}, {1}",
                            al.Id, al.AlbumName);
                }
            }
        }
    }
}