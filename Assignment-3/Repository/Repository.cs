//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using Assignment_3.Data;
//using Microsoft.EntityFrameworkCore;

//public class Repository<T> : IRepository<T> where T : class
//{
//    protected readonly ApplicationDbContext _context;

//    public Repository(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public IEnumerable<T> GetAll()
//    {
//        return _context.Set<T>().ToList();
//    }

//    public T GetById(int id)
//    {
//        return _context.Set<T>().Find(id);
//    }

//    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
//    {
//        return _context.Set<T>().Where(predicate).ToList();
//    }

//    public void Add(T entity)
//    {
//        _context.Set<T>().Add(entity);
//        _context.SaveChanges();
//    }

//    public void Update(T entity)
//    {
//        _context.Set<T>().Update(entity);
//        _context.SaveChanges();
//    }

//    public void Delete(int id)
//    {
//        var entity = _context.Set<T>().Find(id);
//        if (entity != null)
//        {
//            _context.Set<T>().Remove(entity);
//            _context.SaveChanges();
//        }
//    }
//}
