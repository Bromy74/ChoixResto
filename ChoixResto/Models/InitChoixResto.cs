using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class InitChoixResto : DropCreateDatabaseAlways<BddContexte>
{
    protected override void Seed(BddContexte context)
    {
        context.Restos.Add(new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0123989765" });
        context.Restos.Add(new Resto { Id = 2, Nom = "Resto pinière", Telephone = "0450940774" });
        context.Restos.Add(new Resto { Id = 3, Nom = "Resto toro", Telephone = "0658583035" });

        base.Seed(context);
    }
}