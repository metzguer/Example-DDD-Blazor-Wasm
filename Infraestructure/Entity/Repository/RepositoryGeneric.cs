using Domain.Interfaces.Generic;
using Infraestructure.Entity.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Repository
{
    public class RepositoryGeneric<T> : InterfaceGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptionsBuilder<ContextBase> _optionsBuilder;
        public RepositoryGeneric()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextBase>();
        }
        public async Task AddItem(T Entity)
        {
            using ( var db = new ContextBase(_optionsBuilder.Options) ) {
                await db.Set<T>().AddAsync(Entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<T>> AllItems()
        {
            using (var db = new ContextBase(_optionsBuilder.Options))
            {
                return await db.Set<T>().AsNoTracking().ToListAsync(); 
            }
        }

        public async Task Delete(T Entity)
        {
            using (var db = new ContextBase(_optionsBuilder.Options))
            {
                db.Set<T>().Remove(Entity);
                await db.SaveChangesAsync();
            }
        }
         
        public async Task<T> GetItemById(long id)
        {
            using (var db = new ContextBase(_optionsBuilder.Options))
            {
               return await db.Set<T>().FindAsync(id); 
            }
        }

        public async Task UpdateItem(T Entity)
        {
            using (var db = new ContextBase(_optionsBuilder.Options))
            {
                db.Set<T>().Update(Entity);
                await db.SaveChangesAsync();
            }
        }

        //Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose) {
            if (!isDispose) return;
        }
        ~RepositoryGeneric() {
            Dispose(false);
        }
    }
}
