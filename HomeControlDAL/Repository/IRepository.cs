using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace HomeControlDAL {
    public interface IRepository<T> {
        List<T> GetAll();
        List<T> GetByExpression(Expression<Func<T, bool>> match);
        T Add(T entity);
        int Update(T enity);
        int Delete(int i);
    }
}