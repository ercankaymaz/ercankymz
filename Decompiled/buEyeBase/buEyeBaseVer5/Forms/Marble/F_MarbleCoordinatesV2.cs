using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCoordinatesV2 : Form
{
	private string string_0 = "F_MarbleCoordinatesV2";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public buLabel lbl_machine;

	public buLabel lbl_part;

	public buLabel lbl_c;

	public buLabel lbl_machinec;

	public buLabel lbl_partc;

	public buLabel lbl_a;

	public buLabel lbl_machinea;

	public buLabel lbl_parta;

	public buLabel lbl_z;

	public buLabel lbl_machinez;

	public buLabel lbl_partz;

	public buLabel lbl_y;

	public buLabel lbl_machiney;

	public buLabel lbl_party;

	public buLabel lbl_x;

	public buLabel lbl_machinex;

	public buLabel lbl_partx;

	public buPanel pnl_base;

	public buLabel lbl_toolname;

	public buLabel lbl_spindlespeed;

	public buTrack track_spidle;

	public buLabel lbl_operationspeed;

	public buTrack track_operationspeed;

	public buTrack track_quickspeed;

	public buLabel lbl_quickspeed;

	public buSeparator buSeparator1;

	public buSpin spn_toolno;

	public PictureBox pic_tool;

	public buSpin spn_toolthickness;

	public buSpin spn_tooldiameter;

	public buButton btn_pause;

	public buButton btn_reset;

	public buButton btn_start;

	public buProgressBar progress_spindleCurrent;

	public ImageList IC48Tool;

	public F_MarbleCoordinatesV2()
	{
		Class186.smethod_661(this);
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
				lbl_x.Display.Border.Visible = false;
				lbl_x.Display.BackColor = Color.Transparent;
				lbl_y.Display.Border.Visible = false;
				lbl_y.Display.BackColor = Color.Transparent;
				lbl_z.Display.Border.Visible = false;
				lbl_z.Display.BackColor = Color.Transparent;
				lbl_a.Display.Border.Visible = false;
				lbl_a.Display.BackColor = Color.Transparent;
				lbl_c.Display.Border.Visible = false;
				lbl_c.Display.BackColor = Color.Transparent;
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
			lbl_machine.Text = buLangTranslate.preDef.Machine;
			lbl_part.Text = buLangTranslate.preDef.Part;
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
		MarbleTempVars.PartCoordShowModeChanged = true;
	}

	internal void method_2(object sender, EventArgs e)
	{
		MarbleTempVars.MachineCoordShowModeChanged = true;
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
