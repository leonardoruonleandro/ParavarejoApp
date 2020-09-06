using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.PreçoDeCompra, true, false)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.CreditoICMS, true, true )  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.CreditoPISCofins, true, true)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.AcrescimoIPI, true, true)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.PreçoDeCusto, false, false)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.PreçoDeVenda, true, false)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.DebitoICMS, true, true)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.DebitoPISCofins, true, true)  ,
                new LucroRealItem(Guid.NewGuid().ToString(), LucroRealVariable.LucroBruto, false, true)  ,
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