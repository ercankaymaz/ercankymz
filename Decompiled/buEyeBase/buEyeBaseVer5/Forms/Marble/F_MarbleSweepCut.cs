using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.buEntities;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSweepCut : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleSweepPars varSweep = new marbleSweepPars();

	public List<buEntity> SweepZFormEntities = new List<buEntity>();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_followoffset;

	public buSpin spn_targetz;

	public buCheckBox chk_circular;

	public buSpin spn_rampheight;

	public buCheckBox chk_linear;

	public buCheckBox chk_none;

	public buSpin spn_rampwidth;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	internal ImageList imageList_1;

	public buSpin spn_safedistance;

	public buButton btn_selectfile;

	public buCheckBox chk_fromfile;

	public buSpin spn_width;

	public buSpin spn_widthstep;

	public F_MarbleSweepCut()
	{
		Class186.smethod_241(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		spn_rampheight.Value = varSweep.SweepRampHeight;
		spn_rampwidth.Value = varSweep.SweepRampWidth;
		spn_targetz.Value = varSweep.SweepTargetZ;
		spn_width.Value = varSweep.SweepWidth;
		spn_followoffset.Value = varSweep.SweepFollowOffset;
		spn_safedistance.Value = varSweep.SafeDistance;
		spn_widthstep.Value = varSweep.SweepYStep;
		if (varSweep.SawRampType != CamZRampType.None)
		{
			if (varSweep.SawRampType != CamZRampType.Linear)
			{
				if (varSweep.SawRampType != CamZRampType.FromFile)
				{
					chk_circular.Check = true;
					chk_linear.Check = false;
					chk_none.Check = false;
					chk_fromfile.Check = false;
				}
				else
				{
					chk_circular.Check = false;
					chk_linear.Check = false;
					chk_none.Check = false;
					chk_fromfile.Check = true;
				}
			}
			else
			{
				chk_circular.Check = false;
				chk_linear.Check = true;
				chk_none.Check = false;
				chk_fromfile.Check = false;
			}
		}
		else
		{
			chk_circular.Check = false;
			chk_linear.Check = false;
			chk_none.Check = true;
			chk_fromfile.Check = false;
		}
		Class186.smethod_678(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_selectfile.Name)
			{
				F_AddFromFile f_AddFromFile = new F_AddFromFile();
				f_AddFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				f_AddFromFile.StartPosition = FormStartPosition.CenterParent;
				f_AddFromFile.Path = buMarbleCalc.varMarbleRunSettings.pathFromFileSweepForm;
				f_AddFromFile.KeepRatio = true;
				f_AddFromFile.ExtensionList.Clear();
				f_AddFromFile.ExtensionList.Add(".dxf");
				f_AddFromFile.ExtensionList.Add(".dwg");
				f_AddFromFile.ExtensionList.Add(".bucad5");
				f_AddFromFile.MoveEntities = false;
				f_AddFromFile.Init();
				f_AddFromFile.ShowDialog();
				if (f_AddFromFile.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				SweepZFormEntities.Clear();
				buMarbleCalc.varMarbleRunSettings.pathFromFileSweepForm = f_AddFromFile.Path;
				for (int i = 0; i <= f_AddFromFile.viewport.Entities.Count - 1; i++)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(f_AddFromFile.viewport.Entities[i], ref copiedEntity);
					SweepZFormEntities.Add(copiedEntity);
				}
			}
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_24(this);
				Properties.Result = DialogResult.OK;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_cancel.Name)
			{
				Properties.Result = DialogResult.Cancel;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
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
				f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
				if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
				{
					buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			buCheckBox buCheckBox2 = sender as buCheckBox;
			if (buCheckBox2.Name == chk_circular.Name)
			{
				chk_circular.Check = true;
				chk_linear.Check = false;
				chk_none.Check = false;
				chk_fromfile.Check = false;
			}
			if (buCheckBox2.Name == chk_linear.Name)
			{
				chk_none.Check = false;
				chk_circular.Check = false;
				chk_linear.Check = true;
				chk_fromfile.Check = false;
			}
			if (buCheckBox2.Name == chk_none.Name)
			{
				chk_linear.Check = false;
				chk_circular.Check = false;
				chk_none.Check = true;
				chk_fromfile.Check = false;
			}
			if (buCheckBox2.Name == chk_fromfile.Name)
			{
				chk_linear.Check = false;
				chk_circular.Check = false;
				chk_none.Check = false;
				chk_fromfile.Check = true;
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
