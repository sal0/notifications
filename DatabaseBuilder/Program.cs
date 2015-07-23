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

                    // Test Providers
                    var provider1 = new Provider { Name = "SendGrid", RegDate = DateTime.Now };
                    var provider2 = new Provider { Name = "SMS", RegDate = DateTime.Now };
                    var provider3 = new Provider { Name = "SignalR", RegDate = DateTime.Now };

                    // Test Applications
                    var application = db.Applications.Add(new Application { SecretKey = "test", Username = "EZ", Password = "123", RegDate = DateTime.Now });

                    // Test Users
                    var user = db.Users.Add(new User { FirstName = "Ezeki", FullName = "Ezeki Zibzibadze", ExternalUserId = "1", MobileNumber = "995593159115", Email = "ez@jok.io", ApplicationId = application.Id, RegDate = DateTime.Now });

                    // Test Messages
                    db.Messages.Add(new Message { Provider = provider1, UserId = user.Id, Content = "Test1", RegDate = DateTime.Now });
                    db.Messages.Add(new Message { Provider = provider2, UserId = user.Id, Content = "Test2", RegDate = DateTime.Now });
                    db.Messages.Add(new Message { Provider = provider3, UserId = user.Id, Content = "Test3", RegDate = DateTime.Now });

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
