using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee GetById(int id);
    IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate);
    void Add(Employee entity);
    void Update(Employee entity);
    void Delete(int id);
}
