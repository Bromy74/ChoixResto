﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data.Entity.Validation;

public class Dal : IDal
{
    private BddContexte bdd;

    public Dal()
    {
        bdd = new BddContexte();
    }

    public List<Resto> ObtientTousLesRestaurants()
    {
        return bdd.Restos.ToList();
    }

    public void CreerRestaurant(string nom, string telephone, int size)
    {
        bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone, Size = size });
        bdd.SaveChanges();
    }

    public void ModifierRestaurant(int id, string nom, string telephone, int size)
    {
        Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
        if (restoTrouve != null)
        {
            restoTrouve.Nom = nom;
            restoTrouve.Telephone = telephone;
            restoTrouve.Size = size;
            bdd.SaveChanges();
        }
    }

    public bool RestaurantExiste(string nom)
    {
        return bdd.Restos.Any(resto => string.Compare(resto.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
    }

    public int AjouterUtilisateur(string nom, string motDePasse)
    {
        string motDePasseEncode = EncodeMD5(motDePasse);
        Utilisateur utilisateur = new Utilisateur { Prenom = nom, MotDePasse = motDePasseEncode };
        bdd.Utilisateurs.Add(utilisateur);
        bdd.SaveChanges();
        return utilisateur.Id;
    }

    public Utilisateur Authentifier(string nom, string motDePasse)
    {
        string motDePasseEncode = EncodeMD5(motDePasse);
        return bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == motDePasseEncode);
    }

    public Utilisateur ObtenirUtilisateur(int id)
    {
        return bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
    }


    public Utilisateur ObtenirUtilisateur(string idString)
    {
        int id;
        if (int.TryParse(idString, out id))
            return ObtenirUtilisateur(id);
        return null;
    }

    //public Utilisateur ObtenirUtilisateur(string idStr)
    //{
    //    switch (idStr)
    //    {
    //        case "Chrome":
    //            return CreeOuRecupere("Nico", "1234");
    //        case "IE":
    //            return CreeOuRecupere("Jérémie", "1234");
    //        case "Firefox":
    //            return CreeOuRecupere("Delphine", "1234");
    //        default:
    //            return CreeOuRecupere("Timéo", "1234");
    //    }
    //}

    //private Utilisateur CreeOuRecupere(string nom, string motDePasse)
    //{
    //    Utilisateur utilisateur = Authentifier(nom, motDePasse);
    //    if (utilisateur == null)
    //    {
    //        int id = AjouterUtilisateur(nom, motDePasse);
    //        return ObtenirUtilisateur(id);
    //    }
    //    return utilisateur;
    //}

    //public int CreerUnSondage(string Label)
    public int CreerUnSondage()
    {
        Sondage sondage = new Sondage { Date = DateTime.Now};
        //Sondage sondage = new Sondage { Date = DateTime.Now, Label = Label };

        bdd.Sondages.Add(sondage);
        bdd.SaveChanges();
        return sondage.Id;
    }

    public int CreerUnSondage(string label)
    {
        Sondage sondage = new Sondage { Date = DateTime.Now, Label = label };
        //Sondage sondage = new Sondage { Date = DateTime.Now, Label = Label };

        bdd.Sondages.Add(sondage);
        bdd.SaveChanges();
        return sondage.Id;
    }

    public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
    {
        Vote vote = new Vote
        {
            Resto = bdd.Restos.First(r => r.Id == idResto),
            Utilisateur = bdd.Utilisateurs.First(u => u.Id == idUtilisateur)
        };
        Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
        if (sondage.Votes == null)
            sondage.Votes = new List<Vote>();
        sondage.Votes.Add(vote);
        bdd.SaveChanges();
    }

    public List<Resultats> ObtenirLesResultats(int idSondage)
    {
        List<Resto> restaurants = ObtientTousLesRestaurants();
        List<Resultats> resultats = new List<Resultats>();
        Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
        foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
        {
            int idRestaurant = grouping.Key;
            Resto resto = restaurants.First(r => r.Id == idRestaurant);
            int nombreDeVotes = grouping.Count();
            resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
        }
        return resultats;
    }

    public bool ADejaVote(int idSondage, string idStr)
    {
        int id;
        if (int.TryParse(idStr, out id))
        {
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            if (sondage.Votes == null)
                return false;
            return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == id);
        }
        return false;
    }

    //public bool ADejaVote(int idSondage, string idStr)
    //{
    //    Utilisateur utilisateur = ObtenirUtilisateur(idStr);
    //    if (utilisateur != null)
    //    {
    //        Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
    //        if (sondage.Votes == null)
    //            return false;
    //        return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == utilisateur.Id);
    //    }
    //    return false;
    //}

    public void Dispose()
    {
        bdd.Dispose();
    }

    private string EncodeMD5(string motDePasse)
    {
        string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
        return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
    }

    public int CreerBooking(int Restochoisi, int Nbpeople, DateTime Date, int Orga)
    {
        Booking booking = new Booking { Restochoisi = Restochoisi, Nbpeople = Nbpeople, Date = Date, Orga = Orga };

        bdd.Bookings.Add(booking);
        bdd.SaveChanges();
        return booking.Id;
    }

    public Resto GetResto(int id)
    {
        return bdd.Restos.First(r => r.Id == id);
    }

    public Utilisateur UserById(int id)
    {
        return bdd.Utilisateurs.First(r => r.Id == id);
    }

    public Booking GetBooking(int id)
    {
        return bdd.Bookings.First(r => r.Id == id);
    }
    
    public List<Booking> ObtientTousLesBookings()
    {
        if (bdd.Bookings.Any())
            return bdd.Bookings.ToList();
        else return null;
    }

    public List<Booking> ObtientTousLesBookings(int idresto, DateTime date)
    {
        List<Booking> bookingsIntermediaire = new List<Booking>();
        List<Booking> bookings = new List<Booking>();
        foreach(var b in bdd.Bookings.ToList())
        {
            if (b.Restochoisi==idresto)
                bookingsIntermediaire.Add(b);
        }
        foreach(var b in bookingsIntermediaire)
        {
            if (b.Date.Date == date.Date)
                bookings.Add(b);
        }
        return bookings;

    }

    public List<Utilisateur> ObtientTousLesUtilisateurs()
    {
        return bdd.Utilisateurs.ToList();
    }

}

