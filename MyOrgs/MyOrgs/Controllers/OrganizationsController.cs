using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyOrgs.Data;
using MyOrgs.Models;

namespace MyOrgs.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organization.ToListAsync());
        }

        // GET: Organizations
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            return View(await _context.Organization.ToListAsync());
        }

        // GET: Organizations/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization
                .FirstOrDefaultAsync(m => m.OrgID == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("OrgID,orgName,orgDesc")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        // GET: Organizations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("OrgID,orgName,orgDesc")] Organization organization)
        {
            if (id != organization.OrgID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrgID))
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

            return View(organization);
        }

        // GET: Organizations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization
                .FirstOrDefaultAsync(m => m.OrgID == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }



        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organization = await _context.Organization.FindAsync(id);
            _context.Organization.Remove(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Organizatoins/Join
        [Authorize]
        public async Task<IActionResult> Join(int? id)
        {
            ViewBag.OrgID = id;
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization
                .FirstOrDefaultAsync(m => m.OrgID == id);
            if (organization == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Organizations/Join/5
        [HttpPost, ActionName("Join")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Join([Bind("Org,User")] OrgMembership orgMembership)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(orgMembership);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(JoinConfirmation));
                }
                catch(Exception)
                {
                    return RedirectToAction(nameof(JoinError));
                }
            }
            return View(orgMembership);
        }

        //GET: Organizations/Leave/5
        [Authorize]
        public async Task<IActionResult> Leave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgMembership = await _context.OrgMembership
                .FirstOrDefaultAsync(m => (m.Org == id && m.User == User.Identity.Name));
            if (orgMembership == null)
            {
                return RedirectToAction(nameof(LeaveError));
            }

            return View(orgMembership);
        }

        //GET: Organizations/JoinConfirmation
        [Authorize]
        public IActionResult JoinConfirmation()
        {
            return View();
        }

        //GET: Organizations/LeaveConfirmed
        [HttpPost, ActionName("Leave")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> LeaveConfirmed(int id)
        {
            var orgMembership = await _context.OrgMembership.FindAsync(id, User.Identity.Name);
            _context.OrgMembership.Remove(orgMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LeaveConfirmation));
        }

        //GET: Organizations/LeaveError
        public IActionResult LeaveError()
        {
            return View();
        }

        //GET: Organizations/LeaveError
        public IActionResult JoinError()
        {
            return View();
        }

        //GET: Organizations/LeaveConfirmation
        public IActionResult LeaveConfirmation()
        {
            return View();
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organization.Any(e => e.OrgID == id);
        }
    }
}
