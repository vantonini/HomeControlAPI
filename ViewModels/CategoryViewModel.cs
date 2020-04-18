using System;
using HomeControlDAL;
using System.Collections.Generic;
using System.Reflection;

namespace ViewModels {
    public class CategoryViewModel {

        private CategoryModel _model;

        public int Id { get; set; }
        public string CategoryName { get; set; }
        

        // constructor
        public CategoryViewModel() {
            _model = new CategoryModel();
        }
        public CategoryViewModel(HomeControlContext context) {
            _model = new CategoryModel(context);
        }

        // methods
        public List<CategoryViewModel> GetAll() {
            List<CategoryViewModel> allVms = new List<CategoryViewModel>();
            try {
                List<Category> allDepartments = _model.GetAll();
                foreach (Category dept in allDepartments) {
                    CategoryViewModel deptVm = new CategoryViewModel();
                    deptVm.CategoryName = dept.CategoryName;
                    deptVm.Id = dept.Id;
                    allVms.Add(deptVm);
                } // end foreach
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return allVms;
        } // end GetAll

    }
}
