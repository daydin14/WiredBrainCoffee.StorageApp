using WiredBrainCoffee.StorageApp.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : IEntity {

        private readonly List<T> _items = new ();

        public IEnumerable<T> GetAll() {
            return _items.ToList();
        }

        public T GetByID(int id) {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item) {
            item.Id = _items.Count + 1;
            _items.Add (item);
        }

        public void Save() { 
            // Everything is saved already in the List<T>
        }

        public void Remove(T item) {
            _items.Remove(item);
        }
    }
}
