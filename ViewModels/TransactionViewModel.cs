using System;
using HomeControlDAL;
using System.Collections.Generic;
using System.Reflection;

namespace ViewModels {
    public class TransactionViewModel {

        private TransactionModel _model;

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set;  }
        public string StoreOriginalName { get; set; }
        public string StoreModifiedName { get; set; }
        public int? StoreID { get; set; }
        public int? CategoryID { get; set; }
        public double Value { get; set; }


        // constructor
        public TransactionViewModel() {
            _model = new TransactionModel();
        }
        public TransactionViewModel(HomeControlContext context) {
            _model = new TransactionModel(context);
        }

        // methods
        public List<TransactionViewModel> GetAll() {
            List<TransactionViewModel> allVms = new List<TransactionViewModel>();
            try {
                List<Transaction> allElements = _model.GetAll();
                foreach (Transaction element in allElements) {
                    TransactionViewModel elementVM = new TransactionViewModel();
                    elementVM.Id = element.Id;
                    elementVM.TransactionType = element.TransactionType;
                    elementVM.CategoryID = element.CategoryID;
                    elementVM.StoreOriginalName = element.Store.StoreOriginalName;
                    elementVM.StoreModifiedName = element.Store.StoreModifiedName;
                    elementVM.Value= element.Value;                  
                    allVms.Add(elementVM);
                } // end foreach
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return allVms;
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
