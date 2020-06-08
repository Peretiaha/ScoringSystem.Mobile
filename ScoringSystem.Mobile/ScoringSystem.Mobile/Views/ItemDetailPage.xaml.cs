using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ScoringSystem.Mobile.Models;
using ScoringSystem.Mobile.ViewModels;
using System.IO;

namespace ScoringSystem.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            var ingUrl = viewModel.Item.Photo.Replace("data:image/jpeg;base64,", "");
            byte[] Base64Stream = Convert.FromBase64String(ingUrl);
            IncidentImageData.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Customer
            {
                Name =" test"
            };        

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}