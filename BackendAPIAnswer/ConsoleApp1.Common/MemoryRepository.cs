using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Common
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();

        public MemoryRepository()
        {
            Init();
        }

        public async Task<ToDoItem> GetAsync(long id)
        {
            _dic.TryGetValue(id, out var item);
            return item;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            List<ToDoItem> allItems = new List<ToDoItem>();
            foreach (long singleID in _dic.Keys)
            {
                _dic.TryGetValue(singleID, out var item);
                allItems.Add(item);
            }
            return allItems;
        }

        public async Task UpsertAsync(ToDoItem model)
        {
            _dic[model.Id] = model;
        }

        private void Init()
        {
            for (var i = 0; i < 2; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i,
                    Name = $"test item {i}",
                    IsComplete = false,
                };
                _dic[item.Id] = item;
            }
        }
    }
}
