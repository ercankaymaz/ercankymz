using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarblePointerCmd : Form
{
	private string string_0 = "F_MarblePointerCmd";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buButton btn_pointerundo;

	public buGround ground_base;

	public buButton btn_close;

	public buButton btn_pointerclosedraw;

	public buButton btn_pointeraddcircle;

	public buCheckBox chk_pointerarcmode;

	public buSpin spn_pointerdiameter;

	public buButton btn_pointergostart;

	public buCheckBox chk_pointerinsidearea;

	public buButton btn_pointeraddpoint;

	public buButton btn_pointerok;

	public F_MarblePointerCmd()
	{
		Class186.smethod_195(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual != null)
			{
				LoadLanguage();
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Pointer + " " + buLangTranslate.preDef.Command;
			btn_pointerundo.Text = buLangTranslate.preDef.Undo + " " + buLangTranslate.preDef.Add;
			btn_pointerclosedraw.Text = buLangTranslate.preDef.Drawing + " " + buLangTranslate.preDef.Close;
			btn_pointeraddcircle.Text = buLangTranslate.preDef.Cirlce + " " + buLangTranslate.preDef.Add;
			btn_pointergostart.Text = buLangTranslate.preDef.Go + " " + buLangTranslate.preDef.Start;
			chk_pointerarcmode.Text = buLangTranslate.preDef.Arc + " " + buLangTranslate.preDef.Mode;
			chk_pointerinsidearea.Text = buLangTranslate.preDef.Inside + " " + buLangTranslate.preDef.Area;
			spn_pointerdiameter.Caption.Caption = buLangTranslate.preDef.Diameter;
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.Cancel;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			buSpin buSpin2 = sender as buSpin;
			if (AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
				f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
				f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
				f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString(), this);
				if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
				{
					buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
				}
				if (base.Owner != null)
				{
					base.Owner.Focus();
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
