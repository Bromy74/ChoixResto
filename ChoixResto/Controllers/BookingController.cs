using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{

    [Authorize]
    public class BookingController : Controller
    {
        private IDal dal;

        public BookingController()
            : this(new Dal())
        {

        }

        private BookingController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Booking


        public ActionResult Index()
        {
            var context = new BddContexte();

            var vm = new BookingViewModel()
            {
                Restos = new SelectList(context.Restos.AsEnumerable(), "Id", "Nom"),
                Utilisateurs = new SelectList(context.Utilisateurs.AsEnumerable(), "Id", "Prenom")

            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(int restochoisi, int nbpeople, DateTime datepicker, int orga)

        {
            var context = new BddContexte();

            var vm = new BookingViewModel()
            {
                Restos = new SelectList(context.Restos.AsEnumerable(), "Id", "Nom"),
                Utilisateurs = new SelectList(context.Utilisateurs.AsEnumerable(), "Id", "Prenom")

            };

            //ViewBag.result = restochoisi + " " + nbpeople + " " + datepicker + " " + orga;
            //dal.RestoById(restochoisi)
            int id = dal.CreerBooking(restochoisi, nbpeople, datepicker, orga);
            return View(vm);
        }

        public ActionResult All()
        {
            var context = new BddContexte();

            var vm = new BookingViewModel()
            {
                Restos = new SelectList(context.Restos.AsEnumerable(), "Id", "Nom"),
                Utilisateurs = new SelectList(context.Utilisateurs.AsEnumerable(), "Id", "Prenom"),
                ListeDesBookings = dal.ObtientTousLesBookings(),
                ListeDesRestos = dal.ObtientTousLesRestaurants(),
                ListeDesUtilisateurs = dal.ObtientTousLesUtilisateurs()
            };

            return View(vm);
        }


    }
}