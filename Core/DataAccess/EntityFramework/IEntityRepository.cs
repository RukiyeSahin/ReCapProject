using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{   //TEMEL OPERASYONLARIN İMZASI BURADA
    //class:T bir referans tip olmalı
    //IEntity: T IEntity veya IEntity den referans alan bir class olmalı
    //new(): newlwnwbilen bir şey olmalı burada IEntity'nin önünü kestik
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); //Bunu böyle yapmamızın sebebi içine verilene göre filtreleme yapar yani tektek id ye göre getir şeklinde ayrı ayrı metod yazmamıza gerek yok
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
