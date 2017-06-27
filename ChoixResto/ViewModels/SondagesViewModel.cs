using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.ViewModels
{
    public class SondagesViewModel
    {
        public Resto Resto { get; set; }
        public SelectList Sondages { get; set; }
        public SelectList Restos { get; set; }
    }
}