using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ParavarejoApp.Models;
using ParavarejoApp.Models.ParavarejoLucroReal;
using Xamarin.Forms;

namespace ParavarejoApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private LucroRealVariable variable;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return LucroRealVariable.None != variable;
        }

        public LucroRealVariable Variable
        {
            get => variable;
            set => SetProperty(ref variable, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            LucroRealItem newItem = new LucroRealItem(Guid.NewGuid().ToString(), Variable, true, true);

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
