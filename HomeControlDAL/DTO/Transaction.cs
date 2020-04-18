using System;

namespace HomeControlDAL {
    public class Transaction : HomeControlEntity {
        public Transaction() {
            
            //this.Store = new Store();
            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;

        }
        public DateTime TransactionDate { get; set; }
        public int? TransactionType { get; set; }
        public int StoreID { get; set; }
        public int? CategoryID { get; set; }
        public double Value { get; set; }

        public virtual Store Store { get; set; }
        //public virtual Category Category { get; set; }
    }
}
