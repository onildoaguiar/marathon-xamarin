// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamariniOSLicao1
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnCalcular { get; set; }

		[Outlet]
		UIKit.UITextField txtAluguel { get; set; }

		[Outlet]
		UIKit.UITextField txtBanco { get; set; }

		[Outlet]
		UIKit.UITextField txtCaixa { get; set; }

		[Outlet]
		UIKit.UITextField txtCapitalContabil { get; set; }

		[Outlet]
		UIKit.UITextField txtContasaReceber { get; set; }

		[Outlet]
		UIKit.UITextField txtPagamentoaCredito { get; set; }

		[Outlet]
		UIKit.UITextField txtPagamentoaFornecedores { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtCaixa != null) {
				txtCaixa.Dispose ();
				txtCaixa = null;
			}

			if (txtBanco != null) {
				txtBanco.Dispose ();
				txtBanco = null;
			}

			if (txtContasaReceber != null) {
				txtContasaReceber.Dispose ();
				txtContasaReceber = null;
			}

			if (txtPagamentoaCredito != null) {
				txtPagamentoaCredito.Dispose ();
				txtPagamentoaCredito = null;
			}

			if (txtPagamentoaFornecedores != null) {
				txtPagamentoaFornecedores.Dispose ();
				txtPagamentoaFornecedores = null;
			}

			if (txtAluguel != null) {
				txtAluguel.Dispose ();
				txtAluguel = null;
			}

			if (txtCapitalContabil != null) {
				txtCapitalContabil.Dispose ();
				txtCapitalContabil = null;
			}

			if (btnCalcular != null) {
				btnCalcular.Dispose ();
				btnCalcular = null;
			}
		}
	}
}
