using Assignment_3.Data;
using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        return _context.Employees.Find(id);
    }

    public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
    {
        return _context.Employees.Where(predicate).ToList();
    }

    public void Add(Employee entity)
    {
        _context.Employees.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Employee entity)
    {
        _context.Employees.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Employees.Find(id);
        if (entity != null)
        {
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }
    }
}
