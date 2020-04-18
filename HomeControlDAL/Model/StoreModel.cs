
using System;

using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace HomeControlDAL {
    public class StoreModel {

        IRepository<Store> repository;

        public StoreModel() {
            repository = new HomeControlRepository<Store>();
        }
        public StoreModel(HomeControlContext context) {
            repository = new HomeControlRepository<Store>(context);
        }


        // methods
        public List<Store> GetAll() {
            List<Store> allStores = new List<Store>();

            try {

                allStores = repository.GetAll();

            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            } // end try catch

            return allStores;
        } // end GetAll


        public Store GetByDescription(string name) {
            List<Store> selectedStores = null;

            try {
                selectedStores = repository.GetByExpression(store   => store.StoreOriginalName == name);
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            } // end try catch

            return selectedStores.FirstOrDefault();
        }


        public int Add(Store newStore) {
            try {
                repository.Add(newStore);
            }
            catch (Exception ex) {
                Console.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            } // end try catch

            return newStore.Id;
        } // end of Add


    }
}
