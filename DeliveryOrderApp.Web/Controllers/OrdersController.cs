using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryOrderApp.Web.Data;
using DeliveryOrderApp.Web.Models;

namespace DeliveryOrderApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .OrderByDescending(o => o.PickupDate)
                .ToListAsync();
            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View(new Order { PickupDate = DateTime.Today.AddDays(1) });
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (order.PickupDate.Date < DateTime.Today)
            {
                ModelState.AddModelError("PickupDate",
                    "Дата забора не может быть раньше сегодняшнего дня");
            }

            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();
                _context.Add(order);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Заказ {order.Id} успешно создан";
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            return View(order);
        }
    }
}