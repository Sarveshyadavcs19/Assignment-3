using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        // You might want to pass a list of employees to the view for selecting the associated employee.
        // var employees = _employeeRepository.GetAll();
        // ViewBag.Employees = new SelectList(employees, "EmpId", "EmpName");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmpSalary salary)
    {
        if (ModelState.IsValid)
        {
            _empSalaryRepository.Add(salary);
            return RedirectToAction(nameof(Index));
        }

        // You might want to pass a list of employees to the view for selecting the associated employee.
        // var employees = _employeeRepository.GetAll();
        // ViewBag.Employees = new SelectList(employees, "EmpId", "EmpName");

        return View(salary);
    }

    public IActionResult Edit(int id)
    {
        var salary = _empSalaryRepository.GetById(id);

        if (salary == null)
        {
            return NotFound();
        }

        // You might want to pass a list of employees to the view for selecting the associated employee.
        // var employees = _employeeRepository.GetAll();
        // ViewBag.Employees = new SelectList(employees, "EmpId", "EmpName", salary.EmpId);

        return View(salary);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EmpSalary salary)
    {
        if (id != salary.SalaryId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _empSalaryRepository.Update(salary);
            return RedirectToAction(nameof(Index));
        }

        // You might want to pass a list of employees to the view for selecting the associated employee.
        // var employees = _employeeRepository.GetAll();
        // ViewBag.Employees = new SelectList(employees, "EmpId", "EmpName", salary.EmpId);

        return View(salary);
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
