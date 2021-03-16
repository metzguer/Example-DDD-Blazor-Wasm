using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface InterfaceGeneric<T> where T : class 
    {
        Task AddItem(T Entity);
        Task UpdateItem(T Entity);
        Task Delete(T Entity);
        Task<T> GetItemById(long id);
        Task<List<T>> AllItems();
    }
}
