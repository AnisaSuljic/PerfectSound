using PerfectSound.MobileUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PerfectSound.MobileUI.Views
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