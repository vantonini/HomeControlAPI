using System;
using HomeControlDAL;
using System.Collections.Generic;
using System.Reflection;

namespace ViewModels {
    public class TransactionViewModel {

        private TransactionModel _model;
        private StoreModel _storeModel;

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? TransactionType { get; set;  }
        public string StoreOriginalName { get; set; }
        public string StoreModifiedName { get; set; }
        public int? StoreID { get; set; }
        public int? CategoryID { get; set; }
        public double Value { get; set; }


        // constructor
        public TransactionViewModel() {
            _model = new TransactionModel();
            _storeModel = new StoreModel();
        }
        public TransactionViewModel(HomeControlContext context) {
            _model = new TransactionModel(context);
            _storeModel = new StoreModel(context);
        }

        // methods
        public List<TransactionViewModel> GetAll() {
            List<TransactionViewModel> allTVms = new List<TransactionViewModel>();
            List<Store> allS = _storeModel.GetAll();
            try {
                List<Transaction> allElements = _model.GetAll();
                foreach (Transaction element in allElements) {
                    TransactionViewModel elementVM = new TransactionViewModel();
                    Store store = allS.Find(el => el.Id == element.StoreID);
                    elementVM.Id = element.Id;
                    elementVM.TransactionDate = element.TransactionDate;
                    elementVM.TransactionType = element.TransactionType;
                    elementVM.CategoryID = element.CategoryID;
                    elementVM.StoreID = store.Id;
                    elementVM.StoreOriginalName = store.StoreOriginalName;
                    elementVM.StoreModifiedName = store.StoreModifiedName;
                    elementVM.Value= element.Value;
                    allTVms.Add(elementVM);
                } // end foreach
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return allTVms;
        } // end GetAll

        public void Add() {
            Id = -1;
            try {
                Transaction transaction = new Transaction();
                StoreViewModel storeVM = new StoreViewModel();
                storeVM.GetByDescription(StoreOriginalName);
                // if this store doesn't exist, it adds
                if (storeVM.Id == -1) {
                    storeVM.StoreOriginalName = StoreOriginalName;
                    storeVM.StoreModifiedName = StoreModifiedName;
                    storeVM.CategoryID = CategoryID;
                    storeVM.Add();
                }
                transaction.TransactionDate = TransactionDate;
                transaction.StoreID = storeVM.Id;
                    
                transaction.Value = Value;
                transaction.CategoryID = CategoryID;
                _model.Add(transaction);
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
        } // end Add


    }
}
