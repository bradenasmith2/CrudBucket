using CrudBucketMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CrudBucketMVC.Models;

namespace CrudBucketMVC.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly CrudBucketContext _context;

        public VehiclesController(CrudBucketContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var v = _context.Vehicles.AsEnumerable();
            return View(v);
        }

        [Route("/vehicles/{id:int}")]
        public IActionResult Show(int id)
        {
            var v = _context.Vehicles.Find(id);
            return View(v);
        }

        [Route("/vehicles/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Vehicle v)
        {
            _context.Vehicles.Add(v);
            _context.SaveChanges();
            return Redirect($"/vehicles/{v.Id}");
        }

        [Route("/vehicles/{id:int}/edit")]
        public IActionResult Edit(int id)
        {
            var v = _context.Vehicles.Find(id);
            return View(v);
        }

        [HttpPost]
        [Route("/vehicles/{id:int}")]
        public IActionResult Update(Vehicle v, int id)
        {
            v.Id = id;
            _context.Vehicles.Update(v);
            _context.SaveChanges();
            return Redirect($"/vehicles/{v.Id}");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var v = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(v);
            _context.SaveChanges();
            return Redirect("/vehicles");
        }
    }
}
