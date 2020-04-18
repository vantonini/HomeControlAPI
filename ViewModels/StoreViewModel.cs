using System;
using HomeControlDAL;
using System.Collections.Generic;
using System.Reflection;

namespace ViewModels {
    public class StoreViewModel {

        private StoreModel _model;

        public int Id { get; set; }
        public string StoreOriginalName { get; set; }
        public string StoreModifiedName { get; set; }
        public int? CategoryID { get; set; }
        public double Value { get; set; }

       

        // constructor
        public StoreViewModel() {
            _model = new StoreModel();
        }
        public StoreViewModel(HomeControlContext context) {
            _model = new StoreModel(context);
        }

        // methods
        public List<StoreViewModel> GetAll() {
            List<StoreViewModel> allVms = new List<StoreViewModel>();
            try {
                List<Store> allElements = _model.GetAll();
                foreach (Store element in allElements) {
                    StoreViewModel elementVm = new StoreViewModel();
                    elementVm.Id = element.Id;
                    elementVm.StoreOriginalName = element.StoreOriginalName;
                    elementVm.StoreModifiedName = element.StoreModifiedName;
                    elementVm.CategoryID = element.CategoryID;
                    
                    allVms.Add(elementVm);
                } // end foreach
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return allVms;
        } // end GetAll

        public void GetByDescription(string description) {
            Id = -1;
            try {
                Store selectedStore = new Store();
                selectedStore =  _model.GetByDescription(description);
                if (selectedStore != null) {
                    Id = selectedStore.Id;
                    StoreOriginalName = selectedStore.StoreOriginalName;
                    StoreModifiedName = selectedStore.StoreModifiedName;
                    CategoryID = selectedStore.CategoryID;
                    
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            
        }
        

        public void Add() {
            Id = -1;
            try {
                Store store = new Store();
                store.StoreOriginalName = StoreOriginalName;
                store.StoreModifiedName= StoreModifiedName;
                store.CategoryID = CategoryID;
                Id = _model.Add(store);
                
                
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
        } // end Add


    }
}
