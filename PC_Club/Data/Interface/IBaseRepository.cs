using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PC_Club.Data.Interface
{
        interface IBaseRepository<T> : IDisposable
            where T : class
        {
            Task<ActionResult<IEnumerable<T>>> GetAll(); // получение всех объектов
            T Get(string id); // получение одного объекта по id
            void Create(T item); // создание объекта
            void Update(T item); // обновление объекта
            void Delete(Guid id); // удаление объекта по id
            void Save();  // сохранение изменений
        }
}
