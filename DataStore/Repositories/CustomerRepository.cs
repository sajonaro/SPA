namespace DataStore.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Domain.Entities;
    using Domain.Contracts;

    public class CustomerRepository :  IRepository<Customer> 
    {
        public int AddNew(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate)
        {
            return new Customer[]
                       {
                           new Customer("john"){ Id = 1}, 
                           new Customer("matt"){ Id = 2}, 
                           new Customer("ivan"){ Id = 3}, 
                       };
        }

        public Customer Get(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
