using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSellWebApp.Models;

namespace TicketSellWebApp.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<TicketSellWebApp.Models.User> User { get; set; }

        public DbSet<TicketSellWebApp.Models.Ticket> Ticket { get; set; }

        public DbSet<TicketSellWebApp.Models.Show> Show { get; set; }
    }
}
