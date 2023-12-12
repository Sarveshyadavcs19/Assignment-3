using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using System;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
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
        if (ModelState.IsValid)
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

        if (ModelState.IsValid)
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
}
