using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.ViewModels
{
    public class BookingViewModel
    {
        public Booking booking { get; set; }
        public SelectList Restos { get; set; }
        public SelectList Utilisateurs { get; set; }
    }
}