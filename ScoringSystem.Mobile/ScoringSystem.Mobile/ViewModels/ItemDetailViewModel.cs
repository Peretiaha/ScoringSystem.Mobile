using System;

using ScoringSystem.Mobile.Models;

namespace ScoringSystem.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Customer Item { get; set; }
        public ItemDetailViewModel(Customer item = null)
        {
            Title = item?.Name +" "+ item?.LastName;
            Item = item;
            item.Photo = "" + item.Photo;
        }
    }
}
