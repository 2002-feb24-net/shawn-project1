using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using ProjectOne.Data;

namespace ProjectOne.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ProjectOneContext _context;
        private readonly IProductRepo _pcontext;
        private readonly ICustomerRepo _ccontext;

        public OrdersController(ProjectOneContext context, IProductRepo pcontext, ICustomerRepo ccontext)
        {
            _context = context;
            _pcontext = pcontext;
            _ccontext = ccontext;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var TempVariable = from m in _context.Orders
                               select m;
            TempVariable = TempVariable.Where(s => s.Cart.Equals(2));

            if (!String.IsNullOrEmpty(searchString))
            {
                TempVariable = TempVariable.Where(s => s.Store.Equals(searchString));
            }

            var tot1 = TempVariable.Where(x => x.Store == "Dallas").ToList();
            decimal dtot1 = 0;
            foreach (var item in tot1)
            {
                dtot1 += item.Total;
            }
            var tot2 = TempVariable.Where(x => x.Store == "Memphis").ToList();
            decimal dtot2 = 0;
            foreach (var item in tot2)
            {
                dtot2 += item.Total;
            }
            var tot3 = TempVariable.Where(x => x.Store == "Phoenix").ToList();
            decimal dtot3 = 0;
            foreach (var item in tot3)
            {
                dtot3 += item.Total;
            }
            ViewBag.storetot1 = dtot1;
            ViewBag.storetot2 = dtot2;
            ViewBag.storetot3 = dtot3;
            return View(await TempVariable.ToListAsync());
        }

        public async Task<IActionResult> CustomerOrders(string searchString)
        {
            var TempVariable = from m in _context.Orders
                               select m;
            TempVariable = TempVariable.Where(s => s.Cart.Equals(2));

            if (!String.IsNullOrEmpty(searchString))
            {
                TempVariable = TempVariable.Where(s => s.Customer.Equals(searchString));
            }
            var tot1 = TempVariable.Where(x => x.Customer == searchString).ToList();
            decimal dtot1 = 0;
            foreach (var item in tot1)
            {
                dtot1 += item.Total;
            }
            ViewBag.utot1 = dtot1;
            return View(await TempVariable.ToListAsync());
        }


        public async Task<IActionResult> Cart(string searchString)
        {
            var TempVariable = from m in _context.Orders
                               select m;
            TempVariable = TempVariable.Where(s => s.Cart.Equals(1));

            ViewBag.User = searchString;

           // if (!String.IsNullOrEmpty(searchString))
          //  {
                TempVariable = TempVariable.Where(s => s.Customer.Equals(searchString));
           // }
            
            TempData["ID"] = searchString;

            decimal tt1 = 0;

            foreach (var item in TempVariable)
            {
                tt1 += (item.Price * item.Quantity);
            }

            ViewBag.CartTot = tt1;



            return View(await TempVariable.ToListAsync());
        }


        public async Task<IActionResult> Checkout()
        {

            string temp = Convert.ToString(TempData["ID"]);

            var cartItems = _context.Orders.Where(x => x.Cart == 1).ToList();
            var cartItems2 = _context.Orders.Where(x => x.Customer == temp).ToList();


            foreach (var item in cartItems2)
            {                 
                item.Cart++;
                item.DateAndTime = DateTime.Now;
                _context.Update(item);
                await _context.SaveChangesAsync();
            }


            return View();
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.CustomerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {

            ViewData["Cart"] = new SelectList("1");
            ViewData["Customer"] = new SelectList(_context.Customers, "FirstName", "FirstName");
            ViewData["Item"] = new SelectList(_context.Products, "Item", "Item");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Price,Quantity,DateAndTime,Cart,Store,Customer")] Orders orders)
        {
            Products prod = _pcontext.FindByName(orders.Item);
            Customers cust = _ccontext.FindByName(orders.Customer);
           
            if (prod.Stock < orders.Quantity)
            {

                return View("OutOfStock");
            }


            if (ModelState.IsValid)
            {

                orders.Cart = 1;

                prod.Stock -= orders.Quantity;
                _pcontext.Update(prod);
                orders.Store = cust.Store;
                orders.Price = prod.Price;
                orders.Total = orders.Price * orders.Quantity;
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Cart));
            }
            ViewData["Customer"] = new SelectList(_context.Customers, "FirstName", "FirstName", orders.Customer);
            return View("Cart");
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["Customer"] = new SelectList(_context.Customers, "FirstName", "FirstName", orders.Customer);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Price,Quantity,DateAndTime,Cart,Store,Customer")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer"] = new SelectList(_context.Customers, "FirstName", "FirstName", orders.Customer);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.CustomerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}