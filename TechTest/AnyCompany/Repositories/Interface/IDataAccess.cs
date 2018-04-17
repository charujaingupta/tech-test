using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Repositories
{
    public interface IDataAccess<T>
    {
        void Save(T val);

        T Load(int id);
    }
}
