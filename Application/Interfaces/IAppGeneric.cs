using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppGeneric<T> where T : class
    {
        Task AddItem(T Entity);
        Task UpdateItem(T Entity);
        Task Delete(T Entity);
        Task<T> GetItemById(long id);
        Task<List<T>> AllItems();
    }
}
