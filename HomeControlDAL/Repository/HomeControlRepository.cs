using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


namespace HomeControlDAL {
    public class HomeControlRepository<T> : IRepository<T> where T : HomeControlEntity {

        private HomeControlContext _db = null;
        // constructor
        public HomeControlRepository(HomeControlContext context = null) {
            _db = context != null ? context : new HomeControlContext();
            
        }

        // methods
        public List<T> GetAll() {
            return _db.Set<T>().ToList();
        } // end GetAll

        public List<T> GetByExpression(Expression<Func<T, bool>> match) {
            return _db.Set<T>().Where(match).ToList();
        } // end GetByExpression

        public T Add(T entity) {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        } // end Add

        public int Update(T updatedEntity) {
            int operationStatus = -1;

            try {
                HomeControlEntity currentEntity = GetByExpression(ent => ent.Id == updatedEntity.Id).FirstOrDefault();
                //_db.Entry(currentEntity).OriginalValues["Timer"] = updatedEntity.Timer;
                _db.Entry(currentEntity).CurrentValues.SetValues(updatedEntity);

                if (_db.SaveChanges() == 1)
                    operationStatus = 1;
            }
            catch (DbUpdateConcurrencyException dbx) {
                operationStatus = 0;
                Console.WriteLine("Problem in " + MethodBase.GetCurrentMethod().Name + dbx.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + MethodBase.GetCurrentMethod().Name + ex.Message);
            }
            return operationStatus;
        } // end Update

        public int Delete(int id) {
            T currentEntity = GetByExpression(ent => ent.Id == id).FirstOrDefault();
            _db.Set<T>().Remove(currentEntity);
            return _db.SaveChanges();
        } // end Delete

    }
}
