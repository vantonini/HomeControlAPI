
using System;

using System.Reflection;
using System.Collections.Generic;

namespace HomeControlDAL {
    public class TransactionModel {

        IRepository<Transaction> repository;
        StoreModel storeModel;

        public TransactionModel() {
            repository = new HomeControlRepository<Transaction>();
            storeModel = new StoreModel();
        }
        public TransactionModel(HomeControlContext context) {
            repository = new HomeControlRepository<Transaction>(context);
            storeModel = new StoreModel(context);
        }


        // methods
        public List<Transaction> GetAll() {
            List<Transaction> allElements = new List<Transaction>();

            try {

                allElements = repository.GetAll();

            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            } // end try catch

            return allElements;
        } // end GetAll

        public int Add(Transaction record) {
            try {

                // first find if that store is already in our database
                //Store recordStore = storeModel.GetByDescription(record.Store.StoreOriginalName);
                //if (recordStore == null) {
                //    //record.StoreID = storeModel.Add(record.Store);    
                //} else {
                //    record.StoreID = recordStore.Id;
                //}

                repository.Add(record);
                return record.Id;
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
        } // end Add

    }
}

