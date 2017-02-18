using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace XamarinAndroidLicao4
{
    [Activity(Label = "Capital")]
    public class Capital : Activity
    {
        double defaultValue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Capital);

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);

            var elementos = from s in conn.Table<Informacao>() select s;
            foreach (var fila in elementos)
            {
                Toast.MakeText(this, fila.ReceitasBrasil.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.ReceitasMexico.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.DespesasBrasil.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.DespesasMexico.ToString(), ToastLength.Short).Show();
            }

            Button btnSair = FindViewById<Button>(Resource.Id.btnSair);
            EditText txtCapitalBrasil = FindViewById<EditText>(Resource.Id.txtCapitalBrasil);
            EditText txtCapitalMexico = FindViewById<EditText>(Resource.Id.txtCapitalMexico);
            ImageView imgBrasil = FindViewById<ImageView>(Resource.Id.bandeiraBrasil);
            ImageView imgMexico = FindViewById<ImageView>(Resource.Id.bandeiraMexico);

            btnSair.Click += delegate
            {
                try
                {
                    Process.KillProcess(Process.MyPid());
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };

            try
            {
                txtCapitalBrasil.Text = Intent.GetDoubleExtra("capitalBrasil", defaultValue).ToString();
                txtCapitalMexico.Text = Intent.GetDoubleExtra("capitalMexico", defaultValue).ToString();
                imgBrasil.SetImageResource(Resource.Drawable.bandeira_brasil);
                imgMexico.SetImageResource(Resource.Drawable.bandeira_mexico);


            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }
    }
}


