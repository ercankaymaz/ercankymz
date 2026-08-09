using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_MarbleSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public marbleOperation Operation = new marbleOperation();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal CheckBox checkBox_0;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_8;

	internal Label label_10;

	internal NumericUpDown numericUpDown_9;

	internal CheckBox checkBox_1;

	internal Label label_11;

	internal Label label_12;

	internal NumericUpDown numericUpDown_10;

	internal Label label_13;

	internal NumericUpDown numericUpDown_11;

	internal Label label_14;

	internal NumericUpDown numericUpDown_12;

	internal Label label_15;

	internal NumericUpDown numericUpDown_13;

	internal Label label_16;

	internal NumericUpDown numericUpDown_14;

	internal Label label_17;

	internal NumericUpDown numericUpDown_15;

	internal CheckBox checkBox_2;

	internal Label label_18;

	internal CheckBox checkBox_3;

	internal Label label_19;

	internal CheckBox checkBox_4;

	internal Label label_20;

	internal TabPage tabPage_2;

	internal NumericUpDown numericUpDown_16;

	internal Label label_21;

	internal NumericUpDown numericUpDown_17;

	internal Label label_22;

	internal Label label_23;

	internal NumericUpDown numericUpDown_18;

	internal Label label_24;

	internal NumericUpDown numericUpDown_19;

	internal Label label_25;

	internal NumericUpDown numericUpDown_20;

	internal NumericUpDown numericUpDown_21;

	internal Label label_26;

	internal Label label_27;

	internal NumericUpDown numericUpDown_22;

	internal NumericUpDown numericUpDown_23;

	internal Label label_28;

	internal Label label_29;

	internal NumericUpDown numericUpDown_24;

	internal TabPage tabPage_3;

	internal NumericUpDown numericUpDown_25;

	internal Label label_30;

	internal NumericUpDown numericUpDown_26;

	internal Label label_31;

	internal NumericUpDown numericUpDown_27;

	internal Label label_32;

	internal NumericUpDown numericUpDown_28;

	internal Label label_33;

	internal NumericUpDown numericUpDown_29;

	internal Label label_34;

	internal NumericUpDown numericUpDown_30;

	internal Label label_35;

	internal NumericUpDown numericUpDown_31;

	internal Label label_36;

	internal NumericUpDown numericUpDown_32;

	internal Label label_37;

	internal NumericUpDown numericUpDown_33;

	internal Label label_38;

	internal NumericUpDown numericUpDown_34;

	internal Label label_39;

	internal NumericUpDown numericUpDown_35;

	internal Label label_40;

	internal NumericUpDown numericUpDown_36;

	internal Label label_41;

	internal NumericUpDown numericUpDown_37;

	internal Label label_42;

	public F_MarbleSettings()
	{
		Class76.smethod_5(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if ((Properties.Result != DialogResult.OK) & (Properties.Result != DialogResult.Ignore))
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
		numericUpDown_5.Value = (decimal)Operation.WaterJet5AxisCRtForA1;
		numericUpDown_7.Value = (decimal)Operation.WaterJet5AxisCRtForA10;
		numericUpDown_8.Value = (decimal)Operation.WaterJet5AxisCRtForA20;
		numericUpDown_6.Value = (decimal)Operation.WaterJet5AxisCRtForA30;
		numericUpDown_4.Value = (decimal)Operation.WaterJet5AxisCRtForA40;
		numericUpDown_2.Value = (decimal)Operation.WaterJet5AxisCRtForA45;
		numericUpDown_1.Value = (decimal)Operation.WaterJet5AxisCRtForA50;
		numericUpDown_0.Value = (decimal)Operation.WaterJet5AxisCOffsetStartEnd;
		numericUpDown_3.Value = (decimal)Operation.WaterJet5AxisCOffsetMiddle;
		checkBox_0.Checked = Operation.WaterJet5AxisConcaveCalculation;
		numericUpDown_17.Value = (decimal)Operation.WaterJet5AxisARtForA0;
		numericUpDown_21.Value = (decimal)Operation.WaterJet5AxisARtForA1;
		numericUpDown_16.Value = (decimal)Operation.WaterJet5AxisARtForA5;
		numericUpDown_23.Value = (decimal)Operation.WaterJet5AxisARtForA10;
		numericUpDown_24.Value = (decimal)Operation.WaterJet5AxisARtForA20;
		numericUpDown_22.Value = (decimal)Operation.WaterJet5AxisARtForA30;
		numericUpDown_20.Value = (decimal)Operation.WaterJet5AxisARtForA40;
		numericUpDown_19.Value = (decimal)Operation.WaterJet5AxisARtForA45;
		numericUpDown_18.Value = (decimal)Operation.WaterJet5AxisARtForA50;
		numericUpDown_37.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle60;
		numericUpDown_36.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle70;
		numericUpDown_35.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle80;
		numericUpDown_34.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle90;
		numericUpDown_33.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle100;
		numericUpDown_32.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle110;
		numericUpDown_31.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle120;
		numericUpDown_30.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle130;
		numericUpDown_29.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle140;
		numericUpDown_28.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle150;
		numericUpDown_27.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle160;
		numericUpDown_26.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle170;
		numericUpDown_25.Value = (decimal)Operation.WaterJet5AxisARatioCornerAngle180;
		numericUpDown_12.Value = (decimal)Operation.WaterJetLeadInInsideAngle;
		numericUpDown_13.Value = (decimal)Operation.WaterJetLeadInLength;
		numericUpDown_10.Value = (decimal)Operation.WaterJetLeadOutInsideAngle;
		numericUpDown_11.Value = (decimal)Operation.WaterJetLeadOutLength;
		numericUpDown_15.Value = (decimal)Operation.WaterJetLeadInOutsideAngle;
		numericUpDown_14.Value = (decimal)Operation.WaterJetLeadOutOutsideAngle;
		numericUpDown_9.Value = (decimal)Operation.SurfaceReadDevideLength;
		checkBox_1.Checked = Operation.ApplySurfaceReadData;
		checkBox_3.Checked = Operation.BreakEntitiesByMouseClickForMilling;
		checkBox_4.Checked = Operation.BreakEntitiesByMouseClickForSaw;
		checkBox_2.Checked = Operation.BreakEntitiesByMouseClickForWaterJet;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class76.smethod_479(this);
	}

	public void ControlUpdate()
	{
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
			Class76.smethod_518(this);
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
