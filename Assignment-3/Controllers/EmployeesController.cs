using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmpSalaryRepository _empSalaryRepository;

    public EmployeesController(IEmployeeRepository employeeRepository, IEmpSalaryRepository empSalaryRepository)
    {
        _employeeRepository = employeeRepository;
        _empSalaryRepository = empSalaryRepository;
    }

    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAll();
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            _employeeRepository.Add(employee);
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    public IActionResult Edit(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Employee employee)
    {
        if (id != employee.EmpId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction(nameof(Index));
        }

        return View(employee);
    }

    public IActionResult Details(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    public IActionResult Delete(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _employeeRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Reports()
    {
        var averageSalary = _empSalaryRepository.GetAll().Average(e => e.Salary);

        var employeesGroupedByCity = _employeeRepository
            .GetAll()
            .GroupBy(e => e.City)
            .Select(g => new CityGroup { City = g.Key, EmployeeCount = g.Count() })
            .ToList();

        var lowestSalariesInRecentMonth = _empSalaryRepository
            .GetSalariesForRecentMonth()
            .OrderBy(s => s.Salary)
            .Take(5)
            .ToList();

        ViewData["AverageSalary"] = averageSalary;
        ViewData["EmployeesGroupedByCity"] = employeesGroupedByCity;
        ViewData["LowestSalariesInRecentMonth"] = lowestSalariesInRecentMonth;

        return View();
    }

}
