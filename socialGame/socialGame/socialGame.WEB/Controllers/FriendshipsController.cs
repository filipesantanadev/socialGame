using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using socialGame.BLL;
using socialGame.DAL;

namespace socialGame.WEB.Controllers
{
    public class FriendshipsController : Controller
    {
        private readonly socialGameDBContext _context;

        public FriendshipsController(socialGameDBContext context)
        {
            _context = context;
        }

        // GET: Friendships
        public async Task<IActionResult> Index()
        {
            var socialGameDBContext = _context.Friendships.Include(f => f.UserA).Include(f => f.UserB);
            return View(await socialGameDBContext.ToListAsync());
        }

        // GET: Friendships/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendships
                .Include(f => f.UserA)
                .Include(f => f.UserB)
                .FirstOrDefaultAsync(m => m.UserIdA == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // GET: Friendships/Create
        public IActionResult Create()
        {
            ViewData["UserIdA"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserIdB"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Friendships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdA,UserIdB")] Friendship friendship)
        {
            if (ModelState.IsValid)
            {
                friendship.UserIdA = Guid.NewGuid();
                _context.Add(friendship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserIdA"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdA);
            ViewData["UserIdB"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdB);
            return View(friendship);
        }

        // GET: Friendships/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendships.FindAsync(id);
            if (friendship == null)
            {
                return NotFound();
            }
            ViewData["UserIdA"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdA);
            ViewData["UserIdB"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdB);
            return View(friendship);
        }

        // POST: Friendships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserIdA,UserIdB")] Friendship friendship)
        {
            if (id != friendship.UserIdA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendshipExists(friendship.UserIdA))
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
            ViewData["UserIdA"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdA);
            ViewData["UserIdB"] = new SelectList(_context.Users, "Id", "Id", friendship.UserIdB);
            return View(friendship);
        }

        // GET: Friendships/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendships
                .Include(f => f.UserA)
                .Include(f => f.UserB)
                .FirstOrDefaultAsync(m => m.UserIdA == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // POST: Friendships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var friendship = await _context.Friendships.FindAsync(id);
            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendshipExists(Guid id)
        {
            return _context.Friendships.Any(e => e.UserIdA == id);
        }
    }
}
