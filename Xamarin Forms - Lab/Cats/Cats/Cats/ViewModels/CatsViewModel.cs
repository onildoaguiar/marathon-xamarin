using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool Busy;

        public CatsViewModel()
        {
            GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
            Cats = new ObservableCollection<Cat>();
        }

        public Command GetCatsCommand { get; set; }

        async Task GetCats()
        {
            if (!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetCats();
                    Cats.Clear();
                    foreach (var Cat in Items)
                    {
                        Cats.Add(Cat);
                    }
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

                if (Error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", Error.Message, "OK");
                }

                return;
            }
        }

        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetCatsCommand.ChangeCanExecute();
            }
        }

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = null) =>
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<Cat> Cats { get; set; }
    }
}
