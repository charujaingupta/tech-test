using System;
using AnyCompany.Repositories;
using Moq;
using NUnit.Framework;
namespace AnyCompany.Tests
{
    [TestFixture]
    public class OrderServiceTest
    {
        private Customer CurrentCustomer { get; set; }
        private Order CurrentOrder { get; set; }

        Mock<IDataAccess<Order>> _orderDataAccess;
        Mock<IDataAccess<Customer>> _customerDataAccess;

        [OneTimeSetUp]
        public void SetupData()
        {
            _orderDataAccess = new Mock<IDataAccess<Order>>();
            _customerDataAccess = new Mock<IDataAccess<Customer>>();

            CurrentCustomer = new Customer()
            {
                CustomerId = 1,
                Name = "C",
                DateOfBirth = new DateTime(1985, 12, 03),
                Country = "UK"
            };

            CurrentOrder = new Order()
            {
                OrderId = 123,
                Amount = 300,
            };
        }

        [Test]
        public void PlaceValidOrderTest()
        {

            _customerDataAccess.Setup(x => x.Load(It.IsAny<int>())).Returns(CurrentCustomer);
            _orderDataAccess.Setup(x => x.Save(It.IsAny<Order>())).Verifiable();


            OrderService service = new OrderService(_orderDataAccess.Object, _customerDataAccess.Object);

            Assert.AreEqual(service.PlaceOrder(CurrentOrder, 1), true);
        }

        [Test]
        public void PlaceInvalidOrderTest_NoCustomer()
        {
            Customer cust = null;
            _customerDataAccess.Setup(x => x.Load(It.IsAny<int>())).Returns(cust);
            _orderDataAccess.Setup(x => x.Save(It.IsAny<Order>())).Verifiable();


            OrderService service = new OrderService(_orderDataAccess.Object, _customerDataAccess.Object);

            Assert.AreEqual(service.PlaceOrder(CurrentOrder, 1), false);

        }

        [Test]
        public void PlaceInvalidOrderTest_ZeroAmount()
        {
            Order o = CurrentOrder;
            o.Amount = 0;

            _customerDataAccess.Setup(x => x.Load(It.IsAny<int>())).Returns(CurrentCustomer);
            _orderDataAccess.Setup(x => x.Save(CurrentOrder)).Verifiable();


            OrderService service = new OrderService(_orderDataAccess.Object, _customerDataAccess.Object);

            Assert.AreEqual(service.PlaceOrder(CurrentOrder, 1), false);

        }

    }
}
