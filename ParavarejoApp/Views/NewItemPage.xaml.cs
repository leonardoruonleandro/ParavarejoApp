using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ParavarejoApp.Models;
using ParavarejoApp.ViewModels;
using ParavarejoApp.Models.ParavarejoLucroReal;

namespace ParavarejoApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public LucroRealItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}