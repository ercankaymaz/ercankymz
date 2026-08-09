using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestPartAdd : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public buNestingPart Part = new buNestingPart();

	public buNestingVar Settings = new buNestingVar();

	private Design design_0 = null;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Panel panel_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Button button_1;

	internal Panel panel_2;

	internal ComboBox comboBox_0;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_4;

	internal Label label_5;

	internal Panel panel_5;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	public TextBox txt_name;

	internal Label label_6;

	internal Panel panel_6;

	internal Label label_7;

	internal Label label_8;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal NumericUpDown numericUpDown_3;

	internal Label label_9;

	internal Panel panel_7;

	internal Label label_10;

	internal Label label_11;

	internal NumericUpDown numericUpDown_4;

	internal CheckBox checkBox_2;

	internal Label label_12;

	internal NumericUpDown numericUpDown_5;

	internal Label label_13;

	public F_NestPartAdd()
	{
		buFunctions.CultureSettings();
		Class186.smethod_500(this);
		timer_0.Tick += timer_0_Tick;
	}

	internal void method_0(object sender, EventArgs e)
	{
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
		numericUpDown_0.Value = Settings.AddPart.Priority;
		numericUpDown_1.Value = Settings.AddPart.Quantity;
		numericUpDown_2.Value = (decimal)Settings.AddPart.Thickness;
		numericUpDown_3.Value = Settings.AddPart.MirrorQuantity;
		numericUpDown_4.Value = (decimal)Settings.AddPart.PartDistance;
		txt_name.Text = Settings.AddPart.Name;
		numericUpDown_5.Value = (decimal)Settings.AddPart.AdditionalRotation;
		if (Settings.AddPart.MirrorAxis != DirectionXandY.XDirection)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		checkBox_0.Checked = Settings.AddPart.AddAuxEntities;
		checkBox_1.Checked = Settings.AddPart.DeleteSelectedEntities;
		checkBox_2.Checked = Settings.AddPart.DeleteSelectedAuxEntities;
		ArrayList EnumItems = new ArrayList();
		buFunctions.GetEnumTypeValues(Settings.AddPart.Rotation, ref EnumItems);
		buFunctions.ComboboxAddItem(EnumItems, Convert.ToInt32(Settings.AddPart.Rotation), ref comboBox_0);
		LoadLanguage();
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			if (panel_5.Controls.Count == 0)
			{
				panel_5.Controls.Add(design_0);
			}
		}
		timer_0.Interval = 50;
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		buNestingVar buNestingVar2 = new buNestingVar(Settings);
		buNestingVar2.Draw.PartInnerShow = Settings.AddPart.AddAuxEntities;
		buCall.buVector5_0.DrawPart(Part, buNestingVar2, ref design_0);
	}

	public void LoadLanguage()
	{
		string callMethod = "NestPartAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				label_4.Text = Captions[2];
				label_3.Text = Captions[3];
				label_1.Text = Captions[4];
				label_2.Text = Captions[5];
				checkBox_0.Text = Captions[6];
				checkBox_1.Text = Captions[7];
				button_0.Text = Captions[8];
				button_1.Text = Captions[9];
				label_9.Text = Captions[10];
				label_8.Text = Captions[11];
				radioButton_1.Text = Captions[12];
				radioButton_0.Text = Captions[13];
				checkBox_2.Text = Captions[14];
				label_7.Text = Captions[15];
				label_6.Text = Captions[15];
				label_12.Text = Captions[16];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			Settings.AddPart.Priority = (int)numericUpDown_0.Value;
			Settings.AddPart.Quantity = (int)numericUpDown_1.Value;
			Settings.AddPart.Thickness = (double)numericUpDown_2.Value;
			Settings.AddPart.AddAuxEntities = checkBox_0.Checked;
			Settings.AddPart.DeleteSelectedEntities = checkBox_1.Checked;
			Settings.AddPart.DeleteSelectedAuxEntities = checkBox_2.Checked;
			Settings.AddPart.Rotation = (nestPartRotateType)buGeneral.EnumValueFromInt(Settings.AddPart.Rotation, comboBox_0.SelectedIndex);
			Settings.AddPart.MirrorQuantity = (int)numericUpDown_3.Value;
			Settings.AddPart.PartDistance = (double)numericUpDown_4.Value;
			Settings.AddPart.AdditionalRotation = (double)numericUpDown_5.Value;
			if (!radioButton_1.Checked)
			{
				Settings.AddPart.MirrorAxis = DirectionXandY.YDirection;
			}
			else
			{
				Settings.AddPart.MirrorAxis = DirectionXandY.XDirection;
			}
			Part.PartData.AdditionalRotation = (double)numericUpDown_5.Value;
			Part.PartData.Thickness = (double)numericUpDown_2.Value;
			Part.PartData.Quantity = (int)numericUpDown_1.Value;
			Part.PartData.Priority = (int)numericUpDown_0.Value;
			Part.PartDistance = (int)numericUpDown_4.Value;
			Part.PartData.Name = txt_name.Text;
			Part.PartData.Rotation = (nestPartRotateType)buFunctions.EnumValueFromInt(Part.PartData.Rotation, comboBox_0.SelectedIndex);
			if (Part.PartData.Quantity <= 0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
				return;
			}
			if (Part.PartData.Width <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
				return;
			}
			if (Part.PartData.Height <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
				return;
			}
			if ((Part.PartData.Thickness <= 0.0) & panel_4.Visible)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
				return;
			}
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
		if (control.Name == button_1.Name)
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
	}

	internal void method_2(object sender, FormClosingEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buNestingVar buNestingVar2 = new buNestingVar(Settings);
			buNestingVar2.Draw.PartInnerShow = checkBox_0.Checked;
			buCall.buVector5_0.DrawPart(Part, buNestingVar2, ref design_0);
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
