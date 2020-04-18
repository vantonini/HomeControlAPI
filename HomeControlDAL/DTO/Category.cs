using System;

namespace HomeControlDAL {
    public class Category : HomeControlEntity {
        public Category() {

            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;

        }

        public string CategoryName { get; set; }

    }
}
