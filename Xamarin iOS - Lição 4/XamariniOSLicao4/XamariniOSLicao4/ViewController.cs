using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using Foundation;

namespace XamariniOSLicao4
{
	public partial class ViewController : UIViewController
	{
		private List<Dados> Lista;

		public ViewController(IntPtr handle) : base(handle)
		{
			Lista = DadosLista();
		}
		public List<Dados> DadosLista()
		{
			var InformacaoLista = new List<Dados>() {
				new Dados ("Salvador, Brasil", -12.9016148, -38.4898474),
				new Dados ("Rio de Janeiro, Brasil", -22.9111721, -43.5884176),
				new Dados ("São Paulo, Brasil", -23.6821604, -46.8754826)
			};
			return InformacaoLista;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Image.Image = UIImage.FromFile("xamarin_logo.png");
			string htmlString =
					"<HTML><BODY BGCOLOR=WHITE><p><center><h2>Oi Web</h2></center></p></body></html>";
			Web.LoadHtmlString(htmlString, new NSUrl
				("./", true));
			Selector.ValueChanged += (s, e) =>
			{
				switch (Selector.SelectedSegment)
				{
					case 0:
						Map.MapType = MKMapType.Standard;
						break;
					case 1:
						Map.MapType = MKMapType.Satellite;
						break;
					case 2:
						Map.MapType = MKMapType.Hybrid;
						break;
				}
			};
			Lista.ForEach(x => Map.AddAnnotation(new MKPointAnnotation()
			{
				Title = x.Titulo,
				Coordinate = new CLLocationCoordinate2D()
				{
					Latitude = x.Latitude,
					Longitude = x.Longitude
				}
			}));
			var salvador = new CLLocationCoordinate2D(-12.9016148, -38.4898474);
			var rioDeJaneiro = new CLLocationCoordinate2D(-22.9111721, -43.5884176);
			var saoPaulo = new CLLocationCoordinate2D(-23.6821604, -46.8754826);
			var info = new NSDictionary();

            var origemDestino = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(salvador, info)),
				Destination = new MKMapItem(new MKPlacemark(rioDeJaneiro, info)),
			};

            var origemDestino2 = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(rioDeJaneiro, info)),
				Destination = new MKMapItem(new MKPlacemark(saoPaulo, info)),
			};

            var rotaSalvadorRioDeJaneiro = new MKDirections(origemDestino);
			rotaSalvadorRioDeJaneiro.CalculateDirections((response, error) =>
			{
				if (error == null)
				{
					var rota = response.Routes[0];
					var linha = new MKPolylineRenderer(rota.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = UIColor.Red,
					};
					Map.OverlayRenderer = (Res, Err) => linha;
					Map.AddOverlay(rota.Polyline, MKOverlayLevel.AboveRoads);
				}
			});

            var rotaRioDeJaneiroSaoPaulo = new MKDirections(origemDestino2);
			rotaRioDeJaneiroSaoPaulo.CalculateDirections((response, error) =>
			{
				if (error == null)
				{
					var rota = response.Routes[0];
					var linha = new MKPolylineRenderer(rota.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = UIColor.Blue,
					};
					Map.OverlayRenderer = (Res, Err) => linha;
					Map.AddOverlay(rota.Polyline, MKOverlayLevel.AboveRoads);
				}
			});
		}
		private void MessageBox(string Title, string message)
		{
			using (UIAlertView Alerta = new UIAlertView())
			{
				Alerta.Title = Title;
				Alerta.Message = message;
				Alerta.AddButton("OK");
				Alerta.Show();
			}
		}
	}

	public class Dados
	{
		public Dados(string titulo, double latitude, double longitude)
		{
			Titulo = titulo;
			Latitude = latitude;
			Longitude = longitude;
		}
		public string Titulo
		{
			get;
			set;
		}
		public double Latitude
		{
			get;
			set;
		}
		public double Longitude
		{
			get;
			set;
		}
	}
}
