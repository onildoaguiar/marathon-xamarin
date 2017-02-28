using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsLicao3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new StudentDirectoryVM();
            lvStudents.ItemSelected += LvStudents_ItemSelected;
        }

        void LvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStudent = (Student)e.SelectedItem;
            if (selectedStudent == null)
                return;
            Navigation.PushAsync(new StudentDetailPage(selectedStudent));
            lvStudents.SelectedItem = null;
        }
    }
}
