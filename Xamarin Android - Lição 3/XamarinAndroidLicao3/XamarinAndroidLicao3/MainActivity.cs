using Android.App;
using Android.Widget;
using Android.OS;

namespace XamarinAndroidLicao3
{
    [Activity(Label = "ListView Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            EmployeeList employeeList = new EmployeeList();
            var employees = employeeList.GetEmployees(20);

            ListView lvEmployees = FindViewById<ListView>(Resource.Id.lvEmployees);
            EmployeeAdapter adapter = new EmployeeAdapter(employees);
            lvEmployees.Adapter = adapter;

        }
    }
}

