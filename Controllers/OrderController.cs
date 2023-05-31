using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orders_manager_asp.Data;
using orders_manager_asp.Models;

namespace orders_manager_asp.Controllers
{
    
    public class OrderController : Controller
    {

        private readonly NorthwindContext _context;

        public OrderController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Details(int Id)
        {
            Order order = _context.Orders.Where(p => p.OrderId == Id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            _context.Attach(order);
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
