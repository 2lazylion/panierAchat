using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using panierAchat.Data;
using panierAchat.Models;

namespace panierAchat.Controllers
{
    public class CredentialsController : Controller
    {
        private readonly PanierAchatContext _context;

        public CredentialsController(PanierAchatContext context)
        {
            _context = context;
        }

        // GET: Credentials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Credentials.ToListAsync());
        }

        // GET: Credentials/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credentials = await _context.Credentials
                .FirstOrDefaultAsync(m => m.CredentialsId == id);
            if (credentials == null)
            {
                return NotFound();
            }

            return View(credentials);
        }

        // GET: Credentials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Credentials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CredentialsId,Username,Password")] Credentials credentials)
        {
            if (ModelState.IsValid)
            {
                //Add scrambled password to database instead of the user input one
                string pwd = credentials.Password;
                string scrambledPwd = Utilities.ScramblePwd(pwd);
                credentials.Password = scrambledPwd;

                _context.Add(credentials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(await _context.);
        }

        // GET: Credentials/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credentials = await _context.Credentials.FindAsync(id);
            if (credentials == null)
            {
                return NotFound();
            }
            return View(credentials);
        }

        // POST: Credentials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CredentialsId,Username,Password")] Credentials credentials)
        {
            if (id != credentials.CredentialsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credentials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CredentialsExists(credentials.CredentialsId))
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
            return View(credentials);
        }

        // GET: Credentials/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credentials = await _context.Credentials
                .FirstOrDefaultAsync(m => m.CredentialsId == id);
            if (credentials == null)
            {
                return NotFound();
            }

            return View(credentials);
        }

        // POST: Credentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var credentials = await _context.Credentials.FindAsync(id);
            _context.Credentials.Remove(credentials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CredentialsExists(long id)
        {
            return _context.Credentials.Any(e => e.CredentialsId == id);
        }
    }
}
