using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst.SelfReferenceCodeFirst
{
    class TestProgram
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Test self reference");
            //TestSelfReference();

            //Console.WriteLine("Test self Vertical splitting");
            //TestVerticalSplitting();

            //Console.WriteLine("Test splitting");
            //TestSplitting();

            //Console.WriteLine("Test mostenire tip");
            //TestMostenireTip();

            Console.WriteLine("Test mostenire ierarhica");
            TestMostenireIerarhica();

            Console.ReadKey();
        }

        private static void TestMostenireIerarhica()
        {
            using (var context = new EmployeeContext())
            {
                var fte = new FullTimeEmployee
                {
                    FirstName = "Jane",
                    LastName =
                        "Doe",
                    Salary = 71500M
                };
                context.Employees.Add(fte);
                fte = new FullTimeEmployee
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Salary = 62500M
                };
                context.Employees.Add(fte);
                var hourly = new HourlyEmployee
                {
                    FirstName = "Tom",
                    LastName =
                        "Jones",
                    Wage = 8.75M
                };
                context.Employees.Add(hourly);
                context.SaveChanges();

                Console.WriteLine("--- All Employees ---");
                foreach (var emp in context.Employees)
                {
                    bool fullTime = emp is HourlyEmployee ? false : true;
                    Console.WriteLine("{0} {1} ({2})", emp.FirstName, emp.LastName,
                        fullTime ? "Full Time" : "Hourly");
                }
                Console.WriteLine("--- Full Time ---");
                foreach (var fullTimeEmployee in context.Employees.OfType<FullTimeEmployee>())
                {
                    Console.WriteLine("{0} {1}", fullTimeEmployee.FirstName, fullTimeEmployee.LastName);
                }
                Console.WriteLine("--- Hourly ---");
                foreach (var hourlyEmployee in context.Employees.OfType<HourlyEmployee>())
                {
                    Console.WriteLine("{0} {1}", hourlyEmployee.FirstName,
                        hourlyEmployee.LastName);
                }

            }
        }

        private static void TestMostenireTip()
        {
            using (var context = new BusinessContext())
            {
                var business = new Business
                {
                    Name = "Corner Dry Cleaning",
                    LicenseNumber = "100x1"
                };
                context.BusinessSet.Add(business);
                var retail = new Retail
                {
                    Name = "Shop and Save",
                    LicenseNumber =
                        "200C",
                    Address = "101 Main",
                    City = "Anytown",
                    State = "TX",
                    ZIPCode = "76106"
                };
                context.BusinessSet.Add(retail);
                var web = new eCommerce
                {
                    Name = "BuyNow.com",
                    LicenseNumber =
                        "300AB",
                    URL = "www.buynow.com"
                };
                context.BusinessSet.Add(web);
                context.SaveChanges();

                Console.WriteLine("\n--- All Businesses ---");
                foreach (var b in context.BusinessSet)
                {
                    Console.WriteLine("{0} (#{1})", b.Name, b.LicenseNumber);
                }
                Console.WriteLine("\n--- Retail Businesses ---");
                foreach (var r in context.BusinessSet.OfType<Retail>())
                {
                    Console.WriteLine("{0} (#{1})", r.Name, r.LicenseNumber);
                    Console.WriteLine("{0}", r.Address);
                    Console.WriteLine("{0}, {1} {2}", r.City, r.State, r.ZIPCode);
                }
                Console.WriteLine("\n--- eCommerce Businesses ---");
                foreach (var e in context.BusinessSet.OfType<eCommerce>())
                {
                    Console.WriteLine("{0} (#{1})", e.Name, e.LicenseNumber);
                    Console.WriteLine("Online address is: {0}", e.URL);
                }
            }

        }

        private static void TestSelfReference()
        {
            using (var context = new SelfReferenceModel())
            {
                var self = new SelfReference();
                Console.WriteLine("Self referencing test");
                Console.WriteLine("Name: ");
                self.Name = Console.ReadLine();


                context.SelfReferences.Add(self);
                context.SaveChanges();

                var items = context.SelfReferences.ToList();
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name);
                    foreach (var reference in item.References)
                    {
                        Console.WriteLine("reference: {0}", reference.Name);
                    }
                }
            }
        }

        private static void TestVerticalSplitting()
        {
            using (var context = new ProductContext())
            {
                var product = new Product
                {
                    SKU = 147,
                    Description = "Expandable Hydration Pack",
                    Price = 19.97M,
                    ImageURL = "/pack147.jpg"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 178,
                    Description = "Rugged Ranger Duffel Bag",
                    Price = 39.97M,
                    ImageURL = "/pack178.jpg"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 186,
                    Description = "Range Field Pack",
                    Price = 98.97M,
                    ImageURL = "/noimage.jp"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 202,
                    Description = "Small Deployment Back Pack",
                    Price = 29.97M,
                    ImageURL = "/pack202.jpg"
                };
                context.Products.Add(product);
                context.SaveChanges();

                foreach (var p in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description,
                        p.Price.ToString("C"), p.ImageURL);
                }
            }
        }

        private static void TestSplitting()
        {
            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];
            using (var context = new PhotographContext())
            {
                var photo = new Photograph
                {
                    Title = "My Dog",
                    ThumbnailBits = thumbBits
                };
                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits =
                        fullBits
                };
                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();
            }
            using (var context = new PhotographContext())
            {
                foreach (var photo in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes",
                        photo.Title, photo.ThumbnailBits.Length);
                    // explicitly load the "expensive" entity,
                    context.Entry(photo)
                        .Reference(p => p.PhotographFullImage).Load();
                    Console.WriteLine("Full Image Size: {0} bytes",
                        photo.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }
    }
}
