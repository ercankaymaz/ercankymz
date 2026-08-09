using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCommandsV1 : Form
{
	private string string_0 = "F_MarbleCommandsV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public bool DryRunEnable = false;

	public double DryRunOffsetZ = 0.0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buButton btn_addmaterial;

	public buButton btn_deletephoto;

	public buGround ground_base;

	public buButton btn_close;

	public buButton btn_importphoto;

	public buButton btn_deletematerial;

	public buButton btn_materialcontour;

	public buButton btn_drawing;

	public buCheckBox chk_Dryrun;

	public buSpin spn_dryrunoffset;

	public buButton btn_draw;

	public buSpin spn_goposy;

	public buSpin spn_goposx;

	public F_MarbleCommandsV1()
	{
		Class186.smethod_781(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			LoadLanguage();
			if (buEyeVars.parVisual != null && (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce))
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					controlCollection = ground_base.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					PropertiesForm.VisualUpdated = true;
				}
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
		chk_Dryrun.Check = DryRunEnable;
		spn_dryrunoffset.Value = DryRunOffsetZ;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Command;
			btn_addmaterial.Text = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Add;
			btn_deletematerial.Text = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Delete;
			btn_materialcontour.Text = buLangTranslate.preDef.Material + " " + buLangTranslate.preDef.Contour;
			btn_deletephoto.Text = buLangTranslate.preDef.Photo + " " + buLangTranslate.preDef.Delete;
			btn_importphoto.Text = buLangTranslate.preDef.Photo + " " + buLangTranslate.preDef.Import;
			btn_drawing.Text = buLangTranslate.preDef.Drawing + " " + buLangTranslate.preDef.Menu;
			btn_draw.Text = buLangTranslate.preDef.Draw;
			chk_Dryrun.Text = buLangTranslate.preDef.DryRun;
			spn_dryrunoffset.Caption.Caption = "Z " + buLangTranslate.preDef.Offset;
			spn_goposx.Caption.Caption = "X " + buLangTranslate.preDef.Position;
			spn_goposy.Caption.Caption = "Y " + buLangTranslate.preDef.Position;
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		DryRunEnable = chk_Dryrun.Check;
		DryRunOffsetZ = spn_dryrunoffset.Value;
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
		if (base.Owner != null)
		{
			base.Owner.Focus();
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
		if (base.Owner != null)
		{
			base.Owner.Focus();
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
