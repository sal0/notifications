using AltaSoft.Notifications.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Context
{
    internal class MainContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
