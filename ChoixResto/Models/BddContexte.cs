using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class BddContexte : DbContext
{
    public DbSet<Sondage> Sondages { get; set; }
    public DbSet<Resto> Restos { get; set; }
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}