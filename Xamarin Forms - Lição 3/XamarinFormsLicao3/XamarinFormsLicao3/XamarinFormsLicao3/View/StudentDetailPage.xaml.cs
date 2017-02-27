using Xamarin.Forms;

namespace XamarinFormsLicao3
{

    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage(Student selectedStudent)
        {
            InitializeComponent();
            this.BindingContext = selectedStudent;
        }
    }

}
