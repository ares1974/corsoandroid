using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkshopPomeriggio.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace WorkshopPomeriggio.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public ICommand GetMonkeysAsyncCommand {get;set;}
        public ICommand GetNearestMonkeyAsyncCommand { get; set; }

        
        public MainPageViewModel()
        {
            Title = "Main Page";
            GetMonkeysAsyncCommand = new Command(
                async () =>
                {
                    await GetMonkeysAsync();
                }
            );

            var level = Battery.ChargeLevel * 100;
            var state = Battery.ChargeLevel * 100;

            GetNearestMonkeyAsyncCommand = new Command(async () => await FindNearest());
        }

        private async Task FindNearest()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if(location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest { DesiredAccuracy = GeolocationAccuracy.Medium,Timeout = TimeSpan.FromSeconds(30)});
            }
            
            var nearestMonkey = MonkeysList
                                .OrderBy(monkey=> 
                                            location.CalculateDistance(new Location(monkey.Latitude,monkey.Longitude),
                                            DistanceUnits.Kilometers))
                                .FirstOrDefault();
            await Application.Current.MainPage.DisplayAlert("Nearest Monkey", nearestMonkey.Name, "OK");
            await Map.OpenAsync(nearestMonkey.Latitude, nearestMonkey.Longitude);
        }

        public ObservableCollection<Monkey> MonkeysList { get; } = new ObservableCollection<Monkey>();




        async Task GetMonkeysAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");
                var monkeys = JsonConvert.DeserializeObject<List<Monkey>>(json);
                MonkeysList.Clear();
                foreach (var monkey in monkeys)
                {
                    MonkeysList.Add(monkey);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsLoading = false;
            }
        }





        
    }
}
