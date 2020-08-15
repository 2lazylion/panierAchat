using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panierAchat.Data;
using panierAchat.Models;

namespace panierAchat.Controllers
{
    public class ShippingOrdersController : Controller
    {
        private readonly PanierAchatContext _context;
        
        public ShippingOrder panier;

        public ShippingOrdersController(PanierAchatContext context)
        {
            _context = context;

            // creer le panier TODO: mettre le "customer" dans le panier
            panier = new ShippingOrder();
            

            //TODO: obtenir le "customer"
            int customerId = 1;
            Customer customer = _context.Customer.Where(m => m.CustomerId == customerId).FirstOrDefault<Customer>();

            
            
            panier.Customer = customer;

            // set le panier a 0$
            panier.Total = 0;

            //
            _context.Add(panier);
            _context.SaveChanges(); // ERR: Microsoft.Data.SqlClient.SqlException (0x80131904): Cannot insert explicit value for identity column in table 'ShippingOrder' when IDENTITY_INSERT is set to OFF.
        }

        // GET: ShippingOrders
        public  async Task<IActionResult> Index()
        {
            //cherche le panier dans la bd TODO: chercher avec le id creer pour cette session
            ShippingOrder shippingOrder = await _context.ShippingOrder
                .FirstOrDefaultAsync(m => m.ShippingOrderId == 1);

            // si le "shippingOrder" n'existe pas, retourne NotFound.
            if (shippingOrder == null)
            {
                return NotFound();
            }
            return View(shippingOrder);
            //return View(await _context.ShippingOrder.ToListAsync());
        }

        // GET: ShippingOrders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingOrder = await _context.ShippingOrder
                .FirstOrDefaultAsync(m => m.ShippingOrderId == id);
            if (shippingOrder == null)
            {
                return NotFound();
            }

            return View(shippingOrder);
        }

        // GET: ShippingOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: ShippingOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShippingOrderId,Total")] ShippingOrder shippingOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippingOrder);
        }

        // GET: ShippingOrders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingOrder = await _context.ShippingOrder.FindAsync(id);
            if (shippingOrder == null)
            {
                return NotFound();
            }
            return View(shippingOrder);
        }

        // POST: ShippingOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ShippingOrderId,Total")] ShippingOrder shippingOrder)
        {
            if (id != shippingOrder.ShippingOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingOrderExists(shippingOrder.ShippingOrderId))
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
            return View(shippingOrder);
        }

        // GET: ShippingOrders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingOrder = await _context.ShippingOrder
                .FirstOrDefaultAsync(m => m.ShippingOrderId == id);
            if (shippingOrder == null)
            {
                return NotFound();
            }

            return View(shippingOrder);
        }

        // POST: ShippingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var shippingOrder = await _context.ShippingOrder.FindAsync(id);
            _context.ShippingOrder.Remove(shippingOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingOrderExists(long id)
        {
            return _context.ShippingOrder.Any(e => e.ShippingOrderId == id);
        }

        // prends le id du produit selectionnee, creer un orderline et le rajoute dans la liste du panier
        // PUT: ShippingOrders/AddOrderline/5
        
        public async Task<IActionResult> AddOrderline(long productId)
        {
            
            // instancie le orderline
            Orderline orderline = new Orderline();

            //cherche le panier dans la bd TODO: chercher avec le id creer pour cette session
            ShippingOrder shippingOrder = await _context.ShippingOrder
                .FirstOrDefaultAsync(m => m.ShippingOrderId == 1);

            // si le "shippingOrder" n'existe pas, retourne NotFound.
            if (shippingOrder == null)
            {
                return NotFound();
            }

            orderline.ShippingOrder = shippingOrder;

            // cherche le produit dans la bd
            Product product = await _context.Product.FindAsync(productId);

            // if le "orderline" n'existe pas, retourne NotFound.
            if (product == null)
            {
                return NotFound();
            }

            orderline.Product = product;

            //TODO: incrementer la quantite a chaque click
            orderline.Quantite = 1;

            // rajoute le orderline dans le panier
            shippingOrder.Orderlines.Add(orderline);

            // changer le total du panier
            shippingOrder.Total += product.PrixUnitaire;

            // sauvegarde le changement
            _context.Update(shippingOrder);
            await _context.SaveChangesAsync();
            
            // retourne a la liste des produits
            return RedirectToAction(nameof(Index),"Products");
        }
    }
}
