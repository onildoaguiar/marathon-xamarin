using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinFormsAzure
{
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        public ObservableBaseObject()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {

        };

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {

            if (PropertyChanged == null)
                return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
