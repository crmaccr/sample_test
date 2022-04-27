using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using test.Data;
using test.Models;
using test.Models.ViewModels;

namespace test.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ApplicationDbContext context, ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public async Task<SelectList> CreateQualificationDropDown(object selected = null)
        {
            var allQualifications = await _context.Qualification.ToListAsync();
            var selectList = new SelectList(allQualifications, "Id", "Name", selected);
            return selectList;
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<ActionResult> Create()
        {
            var selectList = await CreateQualificationDropDown(null);
            ViewBag.Qualifications = selectList;
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVm)
        {
            if (employeeVm.DOB > DateTime.Now)
            {
                _logger.LogError("Future date is provided");
                ModelState.AddModelError("DOB", "Date Of Birth cannot be in future");
                var dropdownOptions = await CreateQualificationDropDown(employeeVm.QualificationVm.CourseId);
                ViewBag.Qualifications = dropdownOptions;
                return View(employeeVm);
            }
            if (ModelState.IsValid)
            {

                // ViewModel to Model Conversion
                var model = new Employee()
                {
                    Name = employeeVm.Name,
                    Gender = employeeVm.Gender,
                    DOB = employeeVm.DOB,
                    Salary = employeeVm.Salary,
                    EmployeeQualifications = new List<EmployeeQualification>(){
                        new EmployeeQualification{
                        QualificationId= employeeVm.QualificationVm.CourseId,
                        Marks = employeeVm.QualificationVm.Marks
                        }
                    }
                };

                _context.Employees.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            _logger.LogCritical("Some validation error maybe");
            var selectList = await CreateQualificationDropDown(employeeVm.QualificationVm.CourseId);
            ViewBag.Qualifications = selectList;
            return View(employeeVm);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
            .Include(e => e.EmployeeQualifications)
                .ThenInclude(eq => eq.Qualification)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            // converting model to viewModel
            var vm = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                DOB = employee.DOB,
                Gender = employee.Gender,
                Salary = employee.Salary,
                Entry_By = employee.Entry_By,
                EntryDate = employee.EntryDate,
                QualificationVm = new QualificationViewModel()
                {
                    CourseId = employee.EmployeeQualifications[0].QualificationId,
                    Marks = employee.EmployeeQualifications[0].Marks

                }
            };
            var selectList = await CreateQualificationDropDown(vm.QualificationVm.CourseId);
            ViewBag.Qualifications = selectList;
            return View(vm);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel employeeVm)
        {
            if (id != employeeVm.Id)
            {
                return NotFound();
            }
            if (employeeVm.DOB > DateTime.Now)
            {
                _logger.LogError("Future date is provided");
                ModelState.AddModelError("DOB", "Date Of Birth cannot be in future");
                var dropdownOptions = await CreateQualificationDropDown(employeeVm.QualificationVm.CourseId);
                ViewBag.Qualifications = dropdownOptions;
                return View(employeeVm);
            }

            var employee = await _context.Employees
            .Include(e => e.EmployeeQualifications)
            .ThenInclude(eq => eq.Qualification)
            .FirstOrDefaultAsync(e => e.Id == id);
            if (ModelState.IsValid)
            {
                // model to viewModel Conversion

                employee.Name = employeeVm.Name;
                employee.Gender = employeeVm.Gender;
                employee.DOB = employeeVm.DOB;
                employee.EmployeeQualifications = new List<EmployeeQualification>(){
                        new EmployeeQualification{
                        QualificationId= employeeVm.QualificationVm.CourseId,
                        Marks = employeeVm.QualificationVm.Marks
                        }
                    };
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var selectoptions = await CreateQualificationDropDown(employeeVm.QualificationVm.CourseId);
            ViewBag.Qualifications = selectoptions;
            return View(employeeVm);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
