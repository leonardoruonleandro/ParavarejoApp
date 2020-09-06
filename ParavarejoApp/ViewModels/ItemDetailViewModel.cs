using ParavarejoApp.Models.Extensions.ParavarejoApp.Extensions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ParavarejoApp.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ParavarejoApp.Models.ParavarejoLucroReal;
using System.Collections.Generic;

namespace ParavarejoApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _itemId;
        private double _percentualValue;
        private double _currenceValue;
        private string _description;
        private bool _hasPercentual;
        private bool _isEditable;

        public ItemDetailViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public Command LoadItemsCommand { get; }

        public List<LucroRealItem> Items { get; }

        public string Id { get; private set; }

        public double PercentualValue
        {
            get => _percentualValue;
            set
            {
                SetProperty(ref _percentualValue, value);
                Services.Services.GetInstance().LucroRealModel.CalculateLucroReal(Items);
            }
        }

        public double CurrenceValue
        {
            get => _currenceValue;
            set
            {
                SetProperty(ref _currenceValue, value);
                Services.Services.GetInstance().LucroRealModel.CalculateLucroReal(Items);
            }
        }

        public string Description
        {
            get => _description;
            private set => SetProperty(ref _description, value);
        }

        public bool HasPercentual
        {
            get => _hasPercentual;
            private set => SetProperty(ref _hasPercentual, value);
        }

        public bool IsEditable
        {
            get => _isEditable;
            private set => SetProperty(ref _isEditable, value);
        }

        public string ItemId
        {
            get { return _itemId; }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                PercentualValue = item.PercentualValue;
                CurrenceValue = item.CurrenceValue;
                Description = item.Variable.GetDescription();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                Services.Services.GetInstance().LucroRealModel.CalculateLucroReal(Items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
