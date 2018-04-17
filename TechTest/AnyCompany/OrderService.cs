using AnyCompany.Repositories;
using AnyCompany.Utility;
namespace AnyCompany
{
    public class OrderService : IService
    {

        IDataAccess<Order> _orderRepository;
        IDataAccess<Customer> _customerRepository;

        public OrderService(IDataAccess<Order> orderRepository, IDataAccess<Customer> custRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = custRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            if (order.Amount == 0) return false;

            Customer customer = _customerRepository.Load(customerId);

            if (customer == null) return false;

            order.VAT = Vat.Get(customer.Country);

            _orderRepository.Save(order);

            return true;
        }
    }
}
