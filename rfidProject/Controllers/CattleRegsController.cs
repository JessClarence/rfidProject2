using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rfidProject.Core.IRepositories;
using rfidProject.Data;
using rfidProject.Migrations;
using rfidProject.Models;

namespace rfidProject.Controllers
{
    public class CattleRegsController : Controller
    {
        private readonly rfidProjectContext _context;
        private IUnitOfWork _unitOfWork;

        public CattleRegsController(rfidProjectContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: CattleRegs
        public async Task<IActionResult> Index()
        {
            var rfidProjectContext = _context.CattleRegs.Include(c => c.Producer).Include(c => c.SlaughterHouse);
            return View(await rfidProjectContext.ToListAsync());
        }

        // GET: CattleRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CattleRegs == null)
            {
                return NotFound();
            }

            var cattleReg = await _context.CattleRegs
                .Include(c => c.Producer)
                .Include(c => c.SlaughterHouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattleReg == null)
            {
                return NotFound();
            }

            return View(cattleReg);
        }

        // GET: CattleRegs/Create
        public IActionResult Create()
        {
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "FarmName");
            ViewData["SlaughterHouseId"] = new SelectList(_context.SlaughterHouses, "Id", "Location");
            var rfid = _unitOfWork.Rfid.GetRfids();
            var cattleReg = new CattleReg { Rfid = rfid };
            return View(cattleReg);
        }

        // POST: CattleRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegWeight,Gender,BirthDate,Breed,Age,HealthStatus,ProducerId,SlaughterHouseId,Rfid")] CattleReg cattleReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cattleReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "FarmName", cattleReg.ProducerId);
            ViewData["SlaughterHouseId"] = new SelectList(_context.SlaughterHouses, "Id", "Location", cattleReg.SlaughterHouseId);
            return View(cattleReg);
        }

        // GET: CattleRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CattleRegs == null)
            {
                return NotFound();
            }

            var cattleReg = await _context.CattleRegs.FindAsync(id);
            if (cattleReg == null)
            {
                return NotFound();
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "FarmName", cattleReg.ProducerId);
            ViewData["SlaughterHouseId"] = new SelectList(_context.SlaughterHouses, "Id", "Location", cattleReg.SlaughterHouseId);
            return View(cattleReg);
        }

        // POST: CattleRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegWeight,Gender,BirthDate,Breed,Age,HealthStatus,ProducerId,SlaughterHouseId,Rfid")] CattleReg cattleReg)
        {
            if (id != cattleReg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cattleReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CattleRegExists(cattleReg.Id))
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
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "FarmName", cattleReg.ProducerId);
            ViewData["SlaughterHouseId"] = new SelectList(_context.SlaughterHouses, "Id", "Location", cattleReg.SlaughterHouseId);
            return View(cattleReg);
        }

        // GET: CattleRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CattleRegs == null)
            {
                return NotFound();
            }

            var cattleReg = await _context.CattleRegs
                .Include(c => c.Producer)
                .Include(c => c.SlaughterHouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattleReg == null)
            {
                return NotFound();
            }

            return View(cattleReg);
        }

        // POST: CattleRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CattleRegs == null)
            {
                return Problem("Entity set 'rfidProjectContext.CattleRegs'  is null.");
            }
            var cattleReg = await _context.CattleRegs.FindAsync(id);
            if (cattleReg != null)
            {
                _context.CattleRegs.Remove(cattleReg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CattleRegExists(int id)
        {
          return (_context.CattleRegs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
