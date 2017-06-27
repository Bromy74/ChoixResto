using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class AccueilController : Controller
{
    private IDal dal;

    public AccueilController() : this(new Dal())
    {
    }

    public AccueilController(IDal dalIoc)
    {
        dal = dalIoc;
    }

    public ActionResult Tuto()
    {
        return View();
    }

    public ActionResult Tuto2()
    {
        return View();
    }

    public ActionResult Tuto3()
    {
        return View();
    }

    public ActionResult Index()
    {
        var context = new BddContexte();

        var vm = new SondagesViewModel()
        {
            Resto = new Resto(),
            Sondages = new SelectList(context.Sondages.AsEnumerable(), "Id", "Label")
        };

        return View(vm);
    }


    [HttpPost]
    [MultipleButton(Name = "action", Argument = "Access")]
    [ActionName("Index")]
    public ActionResult IndexPostNew(int survey)
    {
        return RedirectToAction("Index", "Vote", new { id = survey });
    }

    [HttpPost]
    [MultipleButton(Name = "action", Argument = "New")]
    [ActionName("Index")]
    public ActionResult IndexPost(string newsurverylabel)
    {
        int idSondage = dal.CreerUnSondage(newsurverylabel);

        return RedirectToAction("Index", "Vote", new { id = idSondage });
    }
}