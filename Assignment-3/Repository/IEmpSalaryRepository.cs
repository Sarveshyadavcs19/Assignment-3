using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IEmpSalaryRepository
{
    IEnumerable<EmpSalary> GetAll();
    EmpSalary GetById(int id);
    IEnumerable<EmpSalary> Find(Expression<Func<EmpSalary, bool>> predicate);
    void Add(EmpSalary entity);
    void Update(EmpSalary entity);
    void Delete(int id);
}
