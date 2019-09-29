using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkEmployeeManagment.Domain.Interfaces.Basic_Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetElementsOfRepository();
        T GetElement(int id);
        void Create(T article);
        void Update(T article);
        void Delete(int id);
    }
}
