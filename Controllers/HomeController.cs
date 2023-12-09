using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqEruption.Models;

namespace LinqEruption.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        List<Eruption> eruptions = new List<Eruption>()
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };

        ViewBag.lartesiaMbi1 = eruptions.Where(item => item.ElevationInMeters > 1000).Where(e=>e.Year>1000).OrderBy(e=>e.Volcano).ToList() ;
        List<Eruption> pas1= eruptions.Where(e=>e.Year> 1000 ).OrderByDescending(e=>e.Volcano).ToList();
        ViewBag.Stratovolcano = eruptions.Where(a=>a.Type == "Stratovolcano").OrderByDescending(e=>e.Year).ToList();
        List<Eruption> startWithL = eruptions.Where(a=> a.Type.StartsWith("Str")).ToList();
        int vitiMeIVjeter =eruptions.Min(e=>e.Year);
        bool aEshteNeListe = eruptions.Any(e=>e.Volcano=="Etna");
        Eruption iFundit = eruptions.Last(e=>e.Type== "Stratovolcano");
        Eruption iPari = eruptions.FirstOrDefault(e=>e.Type== "Stratovolcano");
        int nrVolcano = eruptions.Count(e=>e.Year>1000);
        ViewBag.vullkan3 = eruptions.Where(e=>e.Type== "Stratovolcano").Take(3).ToList();
       
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
