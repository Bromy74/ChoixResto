using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AccueilViewModel
{
    [Display(Name = "Le message")]
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public Resto Resto { get; set; }
    //public string Login { get; set; }
}