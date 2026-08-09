using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMaterialList : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public marbleCamPars Settings = new marbleCamPars();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_matsawstraightcutstep;

	public buButton btn_ok;

	public buSpin spn_matsawplungespeed;

	public buSpin spn_matsawstraightcuttingsspeed;

	public buButton btn_cancel;

	public buSpin spn_matsawcircularcutstep;

	public buSpin spn_matmillingcutspeed;

	public buSpin spn_matmillingplungespeed;

	public buSpin spn_matmillingfirstcutspeed;

	public buSpin spn_matmillingcutstep;

	public buSpin spn_matmillingheaddrillspeed;

	public buSpin spn_matmillingheadcutspeed;

	public buSpin spn_matmillingheadplungespeed;

	public buSpin spn_matmillingheadfirstcutspeed;

	public buSpin spn_matmillingheadcutstep;

	public buSpin spn_matsawcircularcutspeed;

	public buSpin spn_matsawstraightcutfirststep;

	public buSpin spn_matsawstraightcutfirstspeed;

	public buSpin spn_matmillingfirstcutstep;

	public buSpin spn_matsawcircularcutfirststep;

	public buSpin spn_matsawcircularcutfirstspeed;

	public buSpin spn_matmillingdrillspeed;

	public buSpin spn_matmillingheadfirstcutstep;

	internal buListBox buListBox_0;

	public buTab buTab_command_settings;

	public TabPage tabPage_saw;

	public TabPage tabPage_mlling;

	internal TabPage tabPage_0;

	public buSpin spn_porositydegree;

	public buSpin spn_unitvalumeweight;

	public buSpin spn_density;

	public buSpin spn_monshardness;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal buTextBox buTextBox_0;

	internal PictureBox pictureBox_0;

	internal buTextBox buTextBox_1;

	public buButton btn_save;

	public buButton btn_open;

	public F_MarbleMaterialList()
	{
		Class186.smethod_210(this);
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
		Class186.smethod_671(this);
		Class186.smethod_182(this);
		for (int i = 0; i <= buListBox_0.Items.Count - 1; i++)
		{
			if (buListBox_0.Items[i].ToString().Trim() == Settings.MaterialName)
			{
				buListBox_0.SelectedIndex = i;
				break;
			}
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_375(this);
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
		Settings.SawForwardCircularStepDownDistance = spn_matsawcircularcutstep.Value;
		Settings.SawForwardCircularCuttingVelocity = spn_matsawcircularcutspeed.Value;
		Settings.SawForwardCircularFirstCuttingVelocity = spn_matsawcircularcutfirstspeed.Value;
		Settings.SawForwardCircularStepFirstDownDistance = spn_matsawcircularcutfirststep.Value;
		Settings.SawForwardCuttingVelocity = spn_matsawstraightcuttingsspeed.Value;
		Settings.SawForwardStepDownDistance = spn_matsawstraightcutstep.Value;
		Settings.SawForwardFirstCuttingVelocity = spn_matsawstraightcutfirstspeed.Value;
		Settings.SawForwardStepFirstDownDistance = spn_matsawstraightcutfirststep.Value;
		Settings.SawPlungeVelocity = spn_matsawplungespeed.Value;
		Settings.MillingCuttingVelocity = spn_matmillingcutspeed.Value;
		Settings.MillingStepDown = spn_matmillingcutstep.Value;
		Settings.MillingFirstCuttingVelocity = spn_matmillingfirstcutspeed.Value;
		Settings.MillingFirstStepDown = spn_matmillingfirstcutstep.Value;
		Settings.MillingPlungeVelocity = spn_matmillingplungespeed.Value;
		Settings.MillingDrillVelocity = spn_matmillingdrillspeed.Value;
		Settings.MillingHeadCuttingVelocity = spn_matmillingheadcutspeed.Value;
		Settings.MillingHeadStepDown = spn_matmillingheadcutstep.Value;
		Settings.MillingHeadFirstCuttingVelocity = spn_matmillingheadfirstcutspeed.Value;
		Settings.MillingHeadFirstStepDown = spn_matmillingheadfirstcutstep.Value;
		Settings.MillingHeadDrillVelocity = spn_matmillingheaddrillspeed.Value;
		Settings.MillingHeadPlungeVelocity = spn_matmillingheadplungespeed.Value;
		Settings.MaterialMonsHardness = spn_monshardness.Value;
		Settings.MaterialDensity = spn_density.Value;
		Settings.MaterialUnitVolumeWeight = spn_unitvalumeweight.Value;
		Settings.MaterialPorosity = spn_porositydegree.Value;
		Settings.MaterialName = buTextBox_1.Text;
		if (!radioButton_4.Checked)
		{
			if (!radioButton_1.Checked)
			{
				if (!radioButton_3.Checked)
				{
					if (!radioButton_2.Checked)
					{
						Settings.MaterialHardness = MarbleMaterialHardness.VeryHard;
					}
					else
					{
						Settings.MaterialHardness = MarbleMaterialHardness.Hard;
					}
				}
				else
				{
					Settings.MaterialHardness = MarbleMaterialHardness.Medium;
				}
			}
			else
			{
				Settings.MaterialHardness = MarbleMaterialHardness.Soft;
			}
		}
		else
		{
			Settings.MaterialHardness = MarbleMaterialHardness.VerySoft;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
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
			if (control.Name == btn_save.Name)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = AppPath.Materials;
				saveFileDialog.Filter = "Marble Material Files (*.bumarblemats) |*.bumarblemats";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					Apply();
					ArrayList arrayList = new ArrayList();
					arrayList.AddRange(Settings.ToDefAll("", 0, SerilizationMode5.MultiLine));
					buFile5.SaveToFile(arrayList, saveFileDialog.FileName);
					Class186.smethod_182(this);
				}
			}
			if (control.Name == btn_open.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = AppPath.Materials;
				openFileDialog.Filter = "Marble Material Files (*.bumarblemats) |*.bumarblemats";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					PropertiesForm.Inited = false;
					List<string> StringList = new List<string>();
					buFile5.OpenFromFile(openFileDialog.FileName, ref StringList);
					buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Settings);
					Class186.smethod_671(this);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buSpin buSpin2 = sender as buSpin;
			buSpin2.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
			buSpin2.SelectAll();
		}
	}

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		FileInfo fileInfo = new FileInfo(AppPath.Materials + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + ".bumarblemats");
		if (!fileInfo.Exists)
		{
			return;
		}
		PropertiesForm.Inited = false;
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
		buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, Settings);
		Class186.smethod_671(this);
		fileInfo = new FileInfo(AppPath.Materials + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + ".jpg");
		pictureBox_0.Image = null;
		if (!fileInfo.Exists)
		{
			fileInfo = new FileInfo(AppPath.Materials + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + ".png");
			if (!fileInfo.Exists)
			{
				fileInfo = new FileInfo(AppPath.Materials + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + ".bmp");
				if (fileInfo.Exists)
				{
					pictureBox_0.Image = Image.FromFile(fileInfo.FullName);
				}
			}
			else
			{
				pictureBox_0.Image = Image.FromFile(fileInfo.FullName);
			}
		}
		else
		{
			pictureBox_0.Image = Image.FromFile(fileInfo.FullName);
		}
		PropertiesForm.Inited = false;
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
