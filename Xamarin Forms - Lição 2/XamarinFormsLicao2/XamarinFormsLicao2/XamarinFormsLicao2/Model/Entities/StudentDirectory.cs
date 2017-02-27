using System.Collections.ObjectModel;

namespace XamarinFormsLicao2
{
    public class StudentDirectory
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
    }
}
