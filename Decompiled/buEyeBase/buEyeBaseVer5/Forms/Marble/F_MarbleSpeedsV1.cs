using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSpeedsV1 : Form
{
	private string string_0 = "F_MarbleSpeedsV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public bool ShowSpindle = true;

	public bool ShowSaw = true;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buPanel pnl_base;

	public buLabel lbl_operationspeed;

	public buLabel lbl_spindlespeed;

	public buTrack track_operationspeed;

	public buTrack track_Spindlespeed;

	public buTrack track_quickspeed;

	public buLabel lbl_quickspeed;

	public buLabel lbl_sawspeed;

	public buTrack track_sawspeed;

	public buButton btn_spindle;

	public buButton btn_saw;

	public buSpin spn_sawspeed;

	public buSpin spn_spindlespeed;

	public buButton btn_sawminus;

	public buButton btn_sawplus;

	public buButton btn_spindleminus;

	public buButton btn_spindleplus;

	public buLabel lbl_sawdia;

	public buButton btn_toolmillinheadset;

	public buButton btn_toolmillinset;

	public buButton btn_toolsawset;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	public buLabel lbl_millingheadlen;

	public buLabel lbl_millingheaddia;

	public buLabel lbl_millinglen;

	public buLabel lbl_millingdia;

	public buLabel lbl_sawtickness;

	public F_MarbleSpeedsV1()
	{
		Class186.smethod_3(this);
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
					controlCollection = pnl_base.Controls;
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
		track_Spindlespeed.Visible = ShowSpindle;
		spn_spindlespeed.Visible = ShowSpindle;
		lbl_spindlespeed.Visible = ShowSpindle;
		btn_spindle.Visible = ShowSpindle;
		btn_spindleminus.Visible = ShowSpindle;
		btn_spindleplus.Visible = ShowSpindle;
		track_sawspeed.Visible = ShowSaw;
		spn_sawspeed.Visible = ShowSaw;
		lbl_sawspeed.Visible = ShowSaw;
		btn_saw.Visible = ShowSaw;
		btn_sawminus.Visible = ShowSaw;
		btn_sawplus.Visible = ShowSaw;
		if (!ShowSaw & ShowSpindle)
		{
			track_Spindlespeed.Top = track_sawspeed.Top;
			spn_spindlespeed.Top = spn_sawspeed.Top;
			lbl_spindlespeed.Top = lbl_sawspeed.Top;
			btn_spindle.Top = btn_saw.Top;
			btn_spindleminus.Top = btn_sawminus.Top;
			btn_spindleplus.Top = btn_sawplus.Top;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			lbl_operationspeed.Text = buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Speed;
			lbl_quickspeed.Text = buLangTranslate.preDef.Quick + " " + buLangTranslate.preDef.Speed;
			lbl_sawspeed.Text = buLangTranslate.preDef.Saw;
			lbl_spindlespeed.Text = buLangTranslate.preDef.Spindle;
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
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			}
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
