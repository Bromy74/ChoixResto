using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Sondage
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Label { get; set; }
    public virtual List<Vote> Votes { get; set; }
}