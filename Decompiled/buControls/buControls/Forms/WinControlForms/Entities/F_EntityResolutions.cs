using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Entities;

public class F_EntityResolutions : Form
{
	public FormProperties Properties = new FormProperties();

	public EntitiesResolution Resolutions = new EntitiesResolution();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal ComboBox comboBox_0;

	internal Label label_4;

	internal Panel panel_1;

	internal Label label_5;

	internal ComboBox comboBox_1;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal NumericUpDown numericUpDown_4;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_2;

	internal Label label_10;

	internal ComboBox comboBox_2;

	internal Label label_11;

	internal NumericUpDown numericUpDown_6;

	internal Label label_12;

	internal NumericUpDown numericUpDown_7;

	internal Label label_13;

	internal Label label_14;

	internal NumericUpDown numericUpDown_8;

	internal Panel panel_3;

	internal Label label_15;

	internal NumericUpDown numericUpDown_9;

	internal Label label_16;

	internal ComboBox comboBox_3;

	internal Label label_17;

	internal NumericUpDown numericUpDown_10;

	internal Label label_18;

	internal NumericUpDown numericUpDown_11;

	internal Label label_19;

	internal Label label_20;

	internal NumericUpDown numericUpDown_12;

	internal Panel panel_4;

	internal Label label_21;

	internal NumericUpDown numericUpDown_13;

	internal Label label_22;

	internal ComboBox comboBox_4;

	internal Label label_23;

	internal NumericUpDown numericUpDown_14;

	internal Label label_24;

	internal NumericUpDown numericUpDown_15;

	internal Label label_25;

	internal Label label_26;

	internal NumericUpDown numericUpDown_16;

	internal Panel panel_5;

	internal Label label_27;

	internal NumericUpDown numericUpDown_17;

	internal Label label_28;

	internal ComboBox comboBox_5;

	internal Label label_29;

	internal NumericUpDown numericUpDown_18;

	internal Label label_30;

	internal NumericUpDown numericUpDown_19;

	internal Label label_31;

	internal Label label_32;

	internal NumericUpDown numericUpDown_20;

	internal Panel panel_6;

	internal Label label_33;

	internal ComboBox comboBox_6;

	internal Label label_34;

	internal NumericUpDown numericUpDown_21;

	internal Label label_35;

	internal NumericUpDown numericUpDown_22;

	internal Label label_36;

	internal Label label_37;

	internal NumericUpDown numericUpDown_23;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_EntityResolutions()
	{
		Class76.smethod_4(this);
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
		base.AutoScaleMode = Properties.ScaleFromMode;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.ArcResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.ArcResolution.ResolutionTypes), ref comboBox_4);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.CircleResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.CircleResolution.ResolutionTypes), ref comboBox_3);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.EllipseResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.EllipseResolution.ResolutionTypes), ref comboBox_5);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.LineResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.LineResolution.ResolutionTypes), ref comboBox_0);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.PolylineResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.PolylineResolution.ResolutionTypes), ref comboBox_1);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.OtherResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.OtherResolution.ResolutionTypes), ref comboBox_6);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Resolutions.CurveResolution.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Resolutions.CurveResolution.ResolutionTypes), ref comboBox_2);
		numericUpDown_15.Value = Resolutions.ArcResolution.GeometricCount;
		numericUpDown_16.Value = (decimal)Resolutions.ArcResolution.GeometricLength;
		numericUpDown_13.Value = (decimal)Resolutions.ArcResolution.LnRatio;
		numericUpDown_14.Value = Resolutions.ArcResolution.MinPointCount;
		numericUpDown_11.Value = Resolutions.CircleResolution.GeometricCount;
		numericUpDown_12.Value = (decimal)Resolutions.CircleResolution.GeometricLength;
		numericUpDown_9.Value = (decimal)Resolutions.CircleResolution.LnRatio;
		numericUpDown_10.Value = Resolutions.CircleResolution.MinPointCount;
		numericUpDown_19.Value = Resolutions.EllipseResolution.GeometricCount;
		numericUpDown_20.Value = (decimal)Resolutions.EllipseResolution.GeometricLength;
		numericUpDown_17.Value = (decimal)Resolutions.EllipseResolution.LnRatio;
		numericUpDown_18.Value = Resolutions.EllipseResolution.MinPointCount;
		numericUpDown_0.Value = Resolutions.LineResolution.GeometricCount;
		numericUpDown_1.Value = (decimal)Resolutions.LineResolution.GeometricLength;
		numericUpDown_2.Value = Resolutions.LineResolution.MinPointCount;
		numericUpDown_4.Value = Resolutions.PolylineResolution.GeometricCount;
		numericUpDown_5.Value = (decimal)Resolutions.PolylineResolution.GeometricLength;
		numericUpDown_3.Value = Resolutions.PolylineResolution.MinPointCount;
		numericUpDown_7.Value = Resolutions.CurveResolution.GeometricCount;
		numericUpDown_8.Value = (decimal)Resolutions.CurveResolution.GeometricLength;
		numericUpDown_6.Value = (decimal)Resolutions.CurveResolution.dt;
		numericUpDown_22.Value = Resolutions.OtherResolution.GeometricCount;
		numericUpDown_23.Value = (decimal)Resolutions.OtherResolution.GeometricLength;
		numericUpDown_21.Value = Resolutions.OtherResolution.MinPointCount;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_130(this);
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
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_45(this);
			Properties.Result = DialogResult.OK;
			Dispose();
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
