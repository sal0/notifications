using AltaSoft.Notifications.DAL;
using AltaSoft.Notifications.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MainDbContext>());

                using (var db = new MainDbContext())
                {
                    Console.WriteLine("Location: {0}, Database: {1}", db.Database.Connection.DataSource, db.Database.Connection.Database);

                    db.Providers.Add(new Provider { Name = "SendGrid", RegDate = DateTime.Now });
                    db.Providers.Add(new Provider { Name = "SMS", RegDate = DateTime.Now });
                    db.Providers.Add(new Provider { Name = "SignalR", RegDate = DateTime.Now });

                    db.SaveChanges();

                    Console.WriteLine();
                    Console.WriteLine("Database Generated - Successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error Message:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Error Details:");
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
