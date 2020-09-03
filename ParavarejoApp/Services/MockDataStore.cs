using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParavarejoApp.Models;
using ParavarejoApp.Models.ParavarejoLucroReal;

namespace ParavarejoApp.Services
{
    public class MockDataStore : IDataStore<LucroRealItem>
    {
        readonly List<LucroRealItem> items;

        public MockDataStore()
        {
            items = new List<LucroRealItem>()
            {
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "First item", IsEditable = false },
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Value=0 },
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "Third item",  Value=0 },
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Value=0 },
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Value=0 },
                new LucroRealItem { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Value=0 }
            };
        }

        public async Task<bool> AddItemAsync(LucroRealItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(LucroRealItem item)
        {
            var oldItem = items.Where((LucroRealItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((LucroRealItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<LucroRealItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<LucroRealItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}