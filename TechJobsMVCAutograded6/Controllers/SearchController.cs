using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;
public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }
    public IActionResult Results(string searchType, string searchTerm)
    {
        ViewBag.columns = ListController.ColumnChoices;
        
        List<Job> jobs = new List<Job>();   
        //string searchTerm = Console.ReadLine();

        if (searchTerm == null  || searchTerm == "all")
        {
            jobs = JobData.FindAll();
            ViewBag.jobs = jobs;
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobs;
        }

        return View("index");
    }
    // TODO #3 - Create an action method to process a search request and render the updated search views.
}

