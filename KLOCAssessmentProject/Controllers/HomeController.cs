using KLOCAssessmentProject.Models;
using KLOCAssessmentProject.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace KLOCAssessmentProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository<Customer> _dataRepository;

        public HomeController(IDataRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to my Assessment Project for KLOC.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "My contact details.";

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

        public IActionResult Customers()
        {
            return View(new CustomersViewModel() { Customers = _dataRepository.GetAll().ToArray() });
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }

        // Bind Customer in order to prevent overposting attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerID,FirstName,LastName,Address1,Address2,Town,County,Postcode,Age,EmailAddress")]Customer cust)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.Add(cust);
                return RedirectToAction(nameof(Customers));
            }
            return View(cust);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer Cust = _dataRepository.Get(id.Value);

            if (Cust == null)
            {
                return NotFound();
            }

            return View(Cust);
        }

        // Bind Customer in order to prevent overposting attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("CustomerID,FirstName,LastName,Address1,Address2,Town,County,Postcode,Age,EmailAddress")]Customer cust)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.Update(_dataRepository.Get(cust.CustomerID), cust);
                return RedirectToAction(nameof(Customers));
            }
            return View(cust);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer Cust = _dataRepository.Get(id.Value);

            if (Cust == null)
            {
                return NotFound();
            }

            return View(Cust);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer Cust = _dataRepository.Get(id.Value);

            if (Cust == null)
            {
                return NotFound();
            }

            return View(Cust);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataRepository.Delete(id);

            return RedirectToAction(nameof(Customers));
        }
    }
}