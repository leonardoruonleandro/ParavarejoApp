using System.ComponentModel;
using Xamarin.Forms;
using ParavarejoApp.ViewModels;

namespace ParavarejoApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}