using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaoVanUyBTH2.Models.Process;
using CaoVanUyBTH2.Models;
using CaoVanUyBTH2.Data;

namespace CaoVanUyBTH2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public EmployeeController (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Employees.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Employee std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(std);
            
        }
         //GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if(id==null)
            {
                //return NotFound
                return View("NotFound");
            }
            //tìm dữ liệu tring database theo id
            var employee = await _context.Employees.FindAsync(id);
            if (employee ==null)
            {
                return View("NotFound");
            }
            //trả về view kèm dữ liệu
            return View(employee);
        }

        //POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id, [Bind("EmployeeID,EmployeeName,EmployeeAge")] Employee std)
        {
            if(id != std.EmployeeID)
            {
                return View("NotFound");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(std);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(std.EmployeeID))
                    {
                       return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }

        // Get: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return View("NotFound");
            }
            var std =  await _context.Employees
            .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (std == null)
            {
                return View("NotFound");
            }

            return View(std);
        }

        //POST: Product/Delete/5
           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]

           public async Task<IActionResult> DeleteConfirmed(string id)
           {
            var std = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           } 

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    
    }
}