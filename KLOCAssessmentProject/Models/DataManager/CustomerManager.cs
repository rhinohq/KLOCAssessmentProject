using KLOCAssessmentProject.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace KLOCAssessmentProject.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer>
    {
        private readonly CustomerContext _customerContext;

        public CustomerManager(CustomerContext context)
        {
            _customerContext = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerContext.Customers.AsEnumerable();
        }

        public Customer Get(int ID)
        {
            return _customerContext.Customers
                .FirstOrDefault(e => e.CustomerID == ID);
        }

        public void Add(Customer Entity)
        {
            _customerContext.Customers.Add(Entity);
            _customerContext.SaveChanges();
        }

        public void Update(Customer Customer, Customer Entity)
        {
            Customer.FirstName = Entity.FirstName;
            Customer.LastName = Entity.LastName;
            Customer.Address1 = Entity.Address1;
            Customer.Address2 = Entity.Address2;
            Customer.Town = Entity.Town;
            Customer.County = Entity.County;
            Customer.Postcode = Entity.Postcode;
            Customer.Age = Entity.Age;
            Customer.EmailAddress = Entity.EmailAddress;

            _customerContext.SaveChanges();
        }

        public void Delete(int ID)
        {
            var custTBD = _customerContext.Customers.FirstOrDefault(x => x.CustomerID == ID);

            if (custTBD != null)
            {
                _customerContext.Customers.Remove(custTBD);
                _customerContext.SaveChanges();
            }
        }

        public void Delete(Customer Customer)
        {
            _customerContext.Customers.Remove(Customer);
            _customerContext.SaveChanges();
        }
    }
}