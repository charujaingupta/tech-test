using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public interface IService
    {
        bool PlaceOrder(Order order, int customerId);
    }
}
