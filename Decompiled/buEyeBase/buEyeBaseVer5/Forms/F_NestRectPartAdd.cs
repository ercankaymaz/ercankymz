using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestRectPartAdd : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public buNestingPart Part = new buNestingPart();

	public buNestingVar Settings = new buNestingVar();

	public bool ShowItemNo = false;

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_1;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_2;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_2;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_3;

	internal Label label_13;

	internal Panel panel_4;

	internal Label label_14;

	internal TextBox textBox_1;

	internal Panel panel_5;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Panel panel_6;

	internal Label label_15;

	internal Label label_16;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_7;

	internal ComboBox comboBox_0;

	internal Label label_17;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal NumericUpDown numericUpDown_5;

	public F_NestRectPartAdd()
	{
		buFunctions.CultureSettings();
		Class186.smethod_58(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Init()
	{
		Result = DialogResult.None;
		panel_0.Visible = ShowItemNo;
		ArrayList EnumItems = new ArrayList();
		buFunctions.GetEnumTypeValues(Part.PartData.Rotation, ref EnumItems);
		buFunctions.ComboboxAddItem(EnumItems, Convert.ToInt32(Part.PartData.Rotation), ref comboBox_0);
		numericUpDown_2.Value = (decimal)Settings.AddPart.Height;
		numericUpDown_3.Value = (decimal)Settings.AddPart.Width;
		numericUpDown_4.Value = Settings.AddPart.Priority;
		numericUpDown_0.Value = Settings.AddPart.Quantity;
		numericUpDown_1.Value = (decimal)Settings.AddPart.Thickness;
		textBox_1.Text = Settings.AddPart.Name;
		numericUpDown_5.Value = (decimal)Settings.AddPart.AdditionalRotation;
		LoadLanguage();
	}

	public void LoadLanguage()
	{
		string callMethod = "NestRectPartAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 10)
			{
				Text = Captions[0];
				label_14.Text = Captions[1];
				label_6.Text = Captions[2];
				label_3.Text = Captions[3];
				label_16.Text = Captions[4];
				label_18.Text = Captions[5];
				button_0.Text = Captions[6];
				button_1.Text = Captions[7];
				label_12.Text = Captions[8];
				label_9.Text = Captions[9];
				label_1.Text = Captions[10];
				label_20.Text = Captions[11];
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
			Settings.AddPart.Priority = (int)numericUpDown_4.Value;
			Settings.AddPart.Quantity = (int)numericUpDown_0.Value;
			Settings.AddPart.Thickness = (double)numericUpDown_1.Value;
			Settings.AddPart.Rotation = (nestPartRotateType)buGeneral.EnumValueFromInt(Settings.AddPart.Rotation, comboBox_0.SelectedIndex);
			Settings.AddPart.Width = (double)numericUpDown_3.Value;
			Settings.AddPart.Height = (double)numericUpDown_2.Value;
			Settings.AddPart.AdditionalRotation = (double)numericUpDown_5.Value;
			Part = new buNestingPart();
			Part.PartData.AdditionalRotation = (double)numericUpDown_5.Value;
			Part.PartData.Width = (double)numericUpDown_3.Value;
			Part.PartData.Height = (double)numericUpDown_2.Value;
			Part.PartData.Thickness = (double)numericUpDown_1.Value;
			Part.PartData.Quantity = (int)numericUpDown_0.Value;
			Part.Remain = (int)numericUpDown_0.Value;
			Part.PartData.Priority = (int)numericUpDown_4.Value;
			Part.PartData.Name = textBox_1.Text;
			Part.PartData.ItemNo = textBox_0.Text;
			Part.PartData.Rotation = (nestPartRotateType)buGeneral.EnumValueFromInt(Part.PartData.Rotation, comboBox_0.SelectedIndex);
			buEntity rectangleEntity = null;
			buCall.buVector5_0.DrawRectangle(new Point3D(), Part.PartData.Width, Part.PartData.Height, Plane.XY, ref rectangleEntity);
			Part.EntitiesGroup = new buEntitiesGroup();
			Part.EntitiesGroup.Outside.Entities.Add(rectangleEntity);
			Part.EntitiesGroup.Outside.Points = new List<Point3D>();
			buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Outside.Entities, ref Part.EntitiesGroup.Outside.Points);
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
			if ((Part.PartData.Thickness <= 0.0) & panel_2.Visible)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
				return;
			}
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
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
