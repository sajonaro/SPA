using Domain.Entities.BaseClasses;
using System;

namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; private set; }
        public bool IsPreferred { get; set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void NotifyAboutDiscount()
        {
            Console.WriteLine("Customer {0} was notified about a discount", Name);
        }
    }
}
