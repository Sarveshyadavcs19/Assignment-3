using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;

public class EmpSalariesController : Controller
{
    private readonly IEmpSalaryRepository _empSalaryRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmpSalariesController(IEmpSalaryRepository empSalaryRepository, IEmployeeRepository employeeRepository)
    {
        _empSalaryRepository = empSalaryRepository;
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index()
    {
        var salaries = _empSalaryRepository.GetAll();
        return View(salaries);
    }

    public IActionResult Create()
    {
        ViewBag.Employees = _employeeRepository.GetAll();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmpSalary empSalary)
    {
        if (!ModelState.IsValid)
        {
            _empSalaryRepository.Add(empSalary);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Employees = _employeeRepository.GetAll();
        return View(empSalary);
    }

    public IActionResult Edit(int id)
    {
        var salary = _empSalaryRepository.GetById(id);

        if (salary == null)
        {
            return NotFound();
        }

        ViewBag.Employees = _employeeRepository.GetAll();
        return View(salary);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EmpSalary empSalary)
    {
        if (id != empSalary.SalaryId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            _empSalaryRepository.Update(empSalary);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Employees = _employeeRepository.GetAll();
        return View(empSalary);
    }

    public IActionResult Details(int id)
    {
        var salary = _empSalaryRepository.GetById(id);

        if (salary == null)
        {
            return NotFound();
        }

        return View(salary);
    }

    public IActionResult Delete(int id)
    {
        var salary = _empSalaryRepository.GetById(id);

        if (salary == null)
        {
            return NotFound();
        }

        return View(salary);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _empSalaryRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
