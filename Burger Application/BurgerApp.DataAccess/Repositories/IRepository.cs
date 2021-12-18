using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        //CRUD methods

        T GetById(int id);
        List<T> GetAll();
        List<T> GetByFilter(Func<T, bool> filter);
        int Insert(T entity);
        void Update(T entity);
        void Remove(int id);

    }
}
