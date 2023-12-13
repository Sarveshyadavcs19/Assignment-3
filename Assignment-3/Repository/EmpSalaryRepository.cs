using Assignment_3.Data;
using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class EmpSalaryRepository : IEmpSalaryRepository
{
    private readonly ApplicationDbContext _context;

    public EmpSalaryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<EmpSalary> GetAll()
    {
        return _context.EmpSalaries.ToList();
    }

    public EmpSalary GetById(int id)
    {
        return _context.EmpSalaries.Find(id);
    }

    public IEnumerable<EmpSalary> Find(Expression<Func<EmpSalary, bool>> predicate)
    {
        return _context.EmpSalaries.Where(predicate).ToList();
    }

    public void Add(EmpSalary entity)
    {
        _context.EmpSalaries.Add(entity);
        _context.SaveChanges();
    }

    public void Update(EmpSalary entity)
    {
        _context.EmpSalaries.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.EmpSalaries.Find(id);
        if (entity != null)
        {
            _context.EmpSalaries.Remove(entity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<EmpSalary> GetSalariesForRecentMonth()
    {
        var currentDate = DateTime.Now;
        return _context.EmpSalaries
            .Where(s => s.CreditDate.Month == currentDate.Month && s.CreditDate.Year == currentDate.Year)
            .ToList();
    }

    public IEnumerable<EmpSalary> GetSalariesForEmployee(int empId)
    {
        return _context.EmpSalaries.Where(s => s.EmpId == empId).ToList();
    }
}
