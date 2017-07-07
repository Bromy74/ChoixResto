using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDal : IDisposable
{
    void CreerRestaurant(string nom, string telephone, int size);
    void ModifierRestaurant(int id, string nom, string telephone, int size);
    List<Resto> ObtientTousLesRestaurants();
    bool RestaurantExiste(string nom);
    int AjouterUtilisateur(string nom, string motDePasse);
    Utilisateur Authentifier(string nom, string motDePasse);
    Utilisateur ObtenirUtilisateur(int id);
    Utilisateur ObtenirUtilisateur(string idStr);
    Booking GetBooking(int id);
    int CreerUnSondage();
    int CreerUnSondage(string label);
    void AjouterVote(int idSondage, int idResto, int idUtilisateur);
    List<Resultats> ObtenirLesResultats(int idSondage);
    bool ADejaVote(int idSondage, string idStr);
    int CreerBooking(int Restochoisi, int Nbpeople, DateTime Date, int Orga);
    Resto GetResto(int id);
    List<Booking> ObtientTousLesBookings();
    List<Booking> ObtientTousLesBookings(int idresto, DateTime date);
    List<Utilisateur> ObtientTousLesUtilisateurs();


}