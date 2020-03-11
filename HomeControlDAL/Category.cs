using System;

namespace HomeControlDAL {
    public class Category : HomeControlEntity {
        public Category() {
            //Employees = new HashSet<Employees>();
        }

        public string CategoryName { get; set; }

        //public virtual ICollection<Employees> Employees { get; set; }

    }
}
