using System;

using UIKit;

namespace XamariniOSLicao1
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
			double caixa, banco, contasaReceber, pagamentoaCredito, pagamentoaFornecedores, aluguel, capitalContabil;
			btnCalcular.TouchUpInside+=delegate
			{					
				try{
					caixa = double.Parse(txtCaixa.Text);
					banco = double.Parse(txtBanco.Text);
					contasaReceber = double.Parse(txtContasaReceber.Text);
					pagamentoaCredito = double.Parse(txtPagamentoaCredito.Text);
					pagamentoaFornecedores = double.Parse(txtPagamentoaFornecedores.Text);
					aluguel = double.Parse(txtAluguel.Text);
					capitalContabil = (caixa + banco + contasaReceber) - (pagamentoaCredito + pagamentoaFornecedores + aluguel);
					txtCapitalContabil.Text = capitalContabil.ToString();
				}
				catch (Exception ex) 
				{
					MessageBox("Error", (ex.Message));
				}
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}

		private void MessageBox(string title, string message) 
		{
			using (UIAlertView alerta = new UIAlertView()) 
			{
				alerta.Title = title;
				alerta.Message = message;
				alerta.AddButton("Aceitar");
				alerta.Show();
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
