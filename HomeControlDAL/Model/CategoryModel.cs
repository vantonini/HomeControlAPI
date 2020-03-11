
using System;

using System.Reflection;
using System.Collections.Generic;

namespace HomeControlDAL {
    public class CategoryModel {

        IRepository<Category> repository;

        public CategoryModel() {
            repository = new HomeControlRepository<Category>();
        }


        // methods
        public List<Category> GetAll() {
            List<Category> allDepartments = new List<Category>();

            try {
                allDepartments = repository.GetAll();

            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            } // end try catch

            return allDepartments;
        } // end GetAll

    }
}
