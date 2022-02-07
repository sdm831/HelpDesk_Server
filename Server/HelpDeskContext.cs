using Server.Models;
using System.Data.Entity;

namespace Server
{
    internal class HelpDeskContext : DbContext
    {
        public HelpDeskContext()
            : base("HelpDesk_DB")
        {
            
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
