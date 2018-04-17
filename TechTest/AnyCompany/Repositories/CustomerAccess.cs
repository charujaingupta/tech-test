using System;

namespace AnyCompany.Repositories
{
    internal class CustomerAccess : IDataAccess<Customer>
    {
        public Customer Load(int customerId)
        {
            try
            {
                return CustomerRepository.Load(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching Customer details for custId: " + customerId.ToString(), ex);
            }
        }
        public void Save(Customer val)
        {
            throw new NotImplementedException();
        }

        
    }
}
