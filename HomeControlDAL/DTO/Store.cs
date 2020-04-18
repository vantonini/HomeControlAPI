using System;

namespace HomeControlDAL {
    public class Store : HomeControlEntity {
        public Store() { 
            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;

        }
        public string StoreOriginalName { get; set; }
        public string StoreModifiedName { get; set; }
        public int? CategoryID { get; set; }
        
        public virtual Transaction Transaction { get; set; }
        //public virtual Category Category { get; set; }


    }
}

