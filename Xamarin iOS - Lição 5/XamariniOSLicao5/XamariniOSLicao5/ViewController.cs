using SQLite;
using System;
using System.IO;
using UIKit;

namespace XamariniOSLicao5
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);
            conn.CreateTable<Informcao>();

            /*
            btnGuardar.TouchUpInside += delegate
            {
                try
                {
                    var Insertar = new Informcao();
                    Insertar.IngresosMexico = 5555;
                    Insertar.IngresosColombia = 6655;
                    Insertar.EgresosMexico = 3355;
                    Insertar.EgresosColombia = 4455;
                    conn.Insert(Insertar);
                    MessageBox("Salvo com sucesso!", "SQLite");
                }
                catch (Exception ex)
                {
                    MessageBox("Error", ex.Message);
                }
            };

            btnEnviar.TouchUpInside += delegate
            {
                ServicioWindows.Service ServicioSQLServer = new ServicioWindows.Service();
                ServicioLinux.ServicioWEB ServicioMySQL = new ServicioLinux.ServicioWEB();
                UIActionSheet Visor = new UIActionSheet();
                try
                {
                    var clientes = from s in conn.Table<Informcao>()
                                   select s;
                    foreach (var fila in clientes)
                    {
                        Visor.Add((fila.IngresosMexico.ToString()));
                        Visor.Add((fila.IngresosColombia.ToString()));
                        Visor.Add((fila.EgresosMexico.ToString()));
                        Visor.Add((fila.EgresosColombia.ToString()));
                        ServicioSQLServer.InsertarenSQLServer(fila.IngresosMexico,
                                                              fila.EgresosMexico,
                                                              fila.IngresosColombia,
                                                              fila.EgresosColombia);
                        ServicioMySQL.InsertarenMySQLServer(fila.IngresosMexico,
                                      fila.EgresosMexico,
                                      fila.IngresosColombia,
                                      fila.EgresosColombia);
                    }
                    Visor.Title = "Informação do SQLite";
                    Visor.Style = UIActionSheetStyle.BlackOpaque;
                    Visor.ShowInView(this.View);

                }
                catch (Exception ex)
                {
                    MessageBox("Error", ex.Message);
                }
            };
            */
        }

        private void MessageBox(string title, string message)
        {
            using (UIAlertView Alerta = new UIAlertView())
            {
                Alerta.Title = title;
                Alerta.Message = message;
                Alerta.AddButton("OK");
                Alerta.Show();
            }
        }
    }

    public class Informcao
    {
        public double IngresosMexico { get; set; }
        public double IngresosColombia { get; set; }
        public double EgresosMexico { get; set; }
        public double EgresosColombia { get; set; }
    }

}
