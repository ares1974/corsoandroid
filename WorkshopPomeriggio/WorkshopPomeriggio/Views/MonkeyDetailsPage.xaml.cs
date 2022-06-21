using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopPomeriggio.Models;
using WorkshopPomeriggio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkshopPomeriggio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonkeyDetailsPage : ContentPage
    {
        public MonkeyDetailsPage()
        {
            InitializeComponent();
        }


        public MonkeyDetailsPage(Monkey monkey)
        {
            InitializeComponent();
            var viewModel = new MonkeyDetailsPageViewModel(monkey);
            BindingContext = viewModel;
        }
    }
}