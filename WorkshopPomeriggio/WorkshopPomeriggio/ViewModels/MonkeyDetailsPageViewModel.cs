using System;
using System.Collections.Generic;
using System.Text;
using WorkshopPomeriggio.Models;

namespace WorkshopPomeriggio.ViewModels
{
    public class MonkeyDetailsPageViewModel : BaseViewModel
    {

        private Monkey monkey;
        
        public Monkey SelectedMonkey
        {
            get { return monkey; }
            set {
                if (monkey == value) return;
                monkey = value;
                OnPropertyChanged();
            }
        }

        public MonkeyDetailsPageViewModel(Monkey monkey)
        {
            SelectedMonkey = monkey;
            Title = $"{monkey.Name} Details Page";
        }
    }
}
