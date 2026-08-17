using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersDeliveryProj.Data;
using OrdersDeliveryProj.Models;

namespace OrdersDeliveryProj.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(AppDbContext context, ILogger<OrdersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Заказы/Создание
        public IActionResult Create()
        {
            return View(new CreateOrderViewModel());
        }

        // POST: Заказы/Создание
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Генерируем уникальный номер заказа
                    var orderNumber = GenerateOrderNumber();

                    var order = new Order
                    {
                        OrderNumber = orderNumber,
                        SenderCity = model.SenderCity,
                        SenderAddress = model.SenderAddress,
                        RecipientCity = model.RecipientCity,
                        RecipientAddress = model.RecipientAddress,
                        Weight = model.Weight,
                        PickupDate = model.PickupDate,
                        CreatedDate = DateTime.UtcNow
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Заказ {orderNumber} успешно создан");
                    return RedirectToAction(nameof(Details), new { id = order.Id });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка при создании заказа");
                    ModelState.AddModelError(string.Empty, "При создании заказа произошла ошибка");
                }
            }

            return View(model);
        }

        // GET: Заказы/Список
        public async Task<IActionResult> List()
        {
            try
            {
                var orders = await _context.Orders
                    .OrderByDescending(o => o.CreatedDate)
                    .Select(o => new OrderListViewModel
                    {
                        Id = o.Id,
                        OrderNumber = o.OrderNumber,
                        SenderCity = o.SenderCity,
                        RecipientCity = o.RecipientCity,
                        Weight = o.Weight,
                        PickupDate = o.PickupDate,
                        CreatedDate = o.CreatedDate
                    })
                    .ToListAsync();

                return View(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка заказов");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        // GET: Заказы/Детали/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return NotFound();
                }

                var viewModel = new OrderDetailViewModel
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    SenderCity = order.SenderCity,
                    SenderAddress = order.SenderAddress,
                    RecipientCity = order.RecipientCity,
                    RecipientAddress = order.RecipientAddress,
                    Weight = order.Weight,
                    PickupDate = order.PickupDate,
                    CreatedDate = order.CreatedDate
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении деталей заказа");
                return RedirectToAction(nameof(List));
            }
        }

        // Приватный метод для генерации уникального номера заказа
        private string GenerateOrderNumber()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var random = new Random().Next(1000, 9999);
            return $"ORD-{timestamp}-{random}";
        }
    }
}
