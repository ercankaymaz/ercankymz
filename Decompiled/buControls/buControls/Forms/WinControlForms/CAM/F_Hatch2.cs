using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_Hatch2 : Form
{
	public camHatch Hatch = new camHatch();

	public camSpeeds Velocity = new camSpeeds();

	public camSpeedsEnable VelocityEnable = new camSpeedsEnable();

	public camDistances Distance = new camDistances();

	public camDistanceEnable DistanceEnable = new camDistanceEnable();

	public camStep Step = new camStep();

	public camStepEnable StepEnable = new camStepEnable();

	public camOffset Offset = new camOffset();

	public camOffsetEnable OffsetEnable = new camOffsetEnable();

	public LeadIn LeadIn = new LeadIn();

	public LeadOut LeadOut = new LeadOut();

	public LeadInOutEnable LeadInOutEnable = new LeadInOutEnable();

	public bool VelocityTabVisible = true;

	public bool DistanceTabVisible = true;

	public bool OffsetTabVisible = true;

	public bool StepTabVisible = true;

	public bool LeadInTabVisible = true;

	public bool LeadOutTabVisible = true;

	public bool MiscTabVisible = false;

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public bool ReadOnly = false;

	public int FormHeight = 0;

	public int FormWidth = 0;

	public DialogResult Result = DialogResult.None;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_next;

	public Button btn_pre;

	internal RadioButton radioButton_0;

	internal Panel panel_0;

	internal RadioButton radioButton_1;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal Panel panel_1;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Panel panel_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal Panel panel_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	internal Panel panel_4;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal Panel panel_5;

	internal Label label_8;

	internal NumericUpDown numericUpDown_4;

	internal Label label_9;

	internal Panel panel_6;

	internal Label label_10;

	internal NumericUpDown numericUpDown_5;

	internal Label label_11;

	internal TabPage tabPage_1;

	internal Panel panel_7;

	internal CheckBox checkBox_0;

	internal Label label_12;

	internal Label label_13;

	internal Panel panel_8;

	internal Label label_14;

	internal NumericUpDown numericUpDown_6;

	internal Label label_15;

	internal Panel panel_9;

	internal Label label_16;

	internal NumericUpDown numericUpDown_7;

	internal Label label_17;

	internal Panel panel_10;

	internal Label label_18;

	internal NumericUpDown numericUpDown_8;

	internal Label label_19;

	internal TabPage tabPage_2;

	internal Panel panel_11;

	internal Label label_20;

	internal NumericUpDown numericUpDown_9;

	internal Label label_21;

	internal Panel panel_12;

	internal Label label_22;

	internal NumericUpDown numericUpDown_10;

	internal Label label_23;

	internal Panel panel_13;

	internal Label label_24;

	internal NumericUpDown numericUpDown_11;

	internal Label label_25;

	internal Panel panel_14;

	internal Label label_26;

	internal NumericUpDown numericUpDown_12;

	internal Label label_27;

	internal Label label_28;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_1;

	internal Panel panel_15;

	internal Label label_29;

	internal NumericUpDown numericUpDown_13;

	internal Label label_30;

	internal TabPage tabPage_3;

	internal Panel panel_16;

	internal Label label_31;

	internal NumericUpDown numericUpDown_14;

	internal Label label_32;

	internal Panel panel_17;

	internal Label label_33;

	internal NumericUpDown numericUpDown_15;

	internal Label label_34;

	internal Panel panel_18;

	internal Label label_35;

	internal NumericUpDown numericUpDown_16;

	internal Label label_36;

	internal Panel panel_19;

	internal Label label_37;

	internal NumericUpDown numericUpDown_17;

	internal Label label_38;

	internal TabPage tabPage_4;

	internal Panel panel_20;

	internal Label label_39;

	internal NumericUpDown numericUpDown_18;

	internal Label label_40;

	internal Panel panel_21;

	internal Label label_41;

	internal NumericUpDown numericUpDown_19;

	internal Label label_42;

	internal Panel panel_22;

	internal Label label_43;

	internal NumericUpDown numericUpDown_20;

	internal Label label_44;

	internal Label label_45;

	internal ComboBox comboBox_1;

	internal CheckBox checkBox_2;

	internal Panel panel_23;

	internal Label label_46;

	internal NumericUpDown numericUpDown_21;

	internal Label label_47;

	internal TabPage tabPage_5;

	internal Panel panel_24;

	internal Label label_48;

	internal NumericUpDown numericUpDown_22;

	internal Label label_49;

	internal Panel panel_25;

	internal Label label_50;

	internal NumericUpDown numericUpDown_23;

	internal Label label_51;

	internal Panel panel_26;

	internal Label label_52;

	internal NumericUpDown numericUpDown_24;

	internal Label label_53;

	internal Label label_54;

	internal ComboBox comboBox_2;

	internal CheckBox checkBox_3;

	internal Panel panel_27;

	internal Label label_55;

	internal NumericUpDown numericUpDown_25;

	internal Label label_56;

	internal TabPage tabPage_6;

	internal Label label_57;

	internal Panel panel_28;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal RadioButton radioButton_2;

	internal Label label_58;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Label label_59;

	internal NumericUpDown numericUpDown_26;

	internal Label label_60;

	internal NumericUpDown numericUpDown_27;

	internal buViewer buViewer_0;

	public F_Hatch2()
	{
		Class76.smethod_367(this);
	}

	public void Init()
	{
		bool_0 = false;
		ArrayList arrayList = new ArrayList();
		if (FormHeight > 10)
		{
			base.Height = FormHeight;
		}
		if (FormWidth > 10)
		{
			base.Width = FormWidth;
		}
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		if (!MiscTabVisible && tabControl_0.TabPages.Count >= 7)
		{
			tabControl_0.TabPages.RemoveAt(6);
		}
		if (!LeadOutTabVisible && tabControl_0.TabPages.Count >= 6)
		{
			tabControl_0.TabPages.RemoveAt(5);
		}
		if (!LeadInTabVisible && tabControl_0.TabPages.Count >= 5)
		{
			tabControl_0.TabPages.RemoveAt(4);
		}
		if (!StepTabVisible && tabControl_0.TabPages.Count >= 4)
		{
			tabControl_0.TabPages.RemoveAt(3);
		}
		if (!DistanceTabVisible && tabControl_0.TabPages.Count >= 3)
		{
			tabControl_0.TabPages.RemoveAt(2);
		}
		if (!VelocityTabVisible && tabControl_0.TabPages.Count >= 2)
		{
			tabControl_0.TabPages.RemoveAt(1);
		}
		int num = 0;
		panel_6.Visible = VelocityEnable.Feed;
		if (VelocityEnable.Feed)
		{
			panel_6.Top = 6 + num * 32;
			num++;
		}
		panel_5.Visible = VelocityEnable.Plunge;
		if (VelocityEnable.Plunge)
		{
			panel_5.Top = 6 + num * 32;
			num++;
		}
		panel_4.Visible = VelocityEnable.Leave;
		if (VelocityEnable.Leave)
		{
			panel_4.Top = 6 + num * 32;
			num++;
		}
		panel_3.Visible = VelocityEnable.Finish;
		if (VelocityEnable.Finish)
		{
			panel_3.Top = 6 + num * 32;
			num++;
		}
		panel_2.Visible = VelocityEnable.Rapid;
		if (VelocityEnable.Rapid)
		{
			panel_2.Top = 6 + num * 32;
			num++;
		}
		panel_1.Visible = VelocityEnable.BackwardFeed;
		if (VelocityEnable.BackwardFeed)
		{
			panel_1.Top = 6 + num * 32;
			num++;
		}
		int num2 = 0;
		panel_10.Visible = DistanceEnable.Safe;
		if (DistanceEnable.Safe)
		{
			panel_10.Top = 6 + num2 * 32;
			num2++;
		}
		panel_8.Visible = DistanceEnable.StepUp;
		if (DistanceEnable.StepUp)
		{
			panel_8.Top = 6 + num2 * 32;
			num2++;
		}
		panel_9.Visible = DistanceEnable.Air;
		if (DistanceEnable.Air)
		{
			panel_9.Top = 6 + num2 * 32;
			num2++;
		}
		panel_7.Visible = DistanceEnable.IncrementalSafe;
		if (DistanceEnable.IncrementalSafe)
		{
			panel_7.Top = 6 + num2 * 32;
			num2++;
		}
		int num3 = 0;
		comboBox_0.Visible = StepEnable.Type;
		panel_15.Visible = StepEnable.StartValue;
		if (StepEnable.StartValue)
		{
			panel_15.Top = 40 + num3 * 32;
			num3++;
		}
		panel_14.Visible = StepEnable.EndValue;
		if (StepEnable.EndValue)
		{
			panel_14.Top = 40 + num3 * 32;
			num3++;
		}
		panel_12.Visible = StepEnable.Step;
		if (StepEnable.Step)
		{
			panel_12.Top = 40 + num3 * 32;
			num3++;
		}
		panel_11.Visible = StepEnable.Count;
		if (StepEnable.Count)
		{
			panel_11.Top = 40 + num3 * 32;
			num3++;
		}
		panel_13.Visible = StepEnable.Distance;
		if (StepEnable.Distance)
		{
			panel_13.Top = 40 + num3 * 32;
			num3++;
		}
		int num4 = 0;
		comboBox_1.Visible = LeadInOutEnable.LeadType;
		panel_23.Visible = LeadInOutEnable.Length;
		if (LeadInOutEnable.Length)
		{
			panel_23.Top = 40 + num4 * 32;
			num4++;
		}
		panel_22.Visible = LeadInOutEnable.TangentAngle;
		if (LeadInOutEnable.TangentAngle)
		{
			panel_22.Top = 40 + num4 * 32;
			num4++;
		}
		panel_21.Visible = LeadInOutEnable.ArcRadius;
		if (LeadInOutEnable.ArcRadius)
		{
			panel_21.Top = 40 + num4 * 32;
			num4++;
		}
		panel_20.Visible = LeadInOutEnable.ArcSweepAngle;
		if (LeadInOutEnable.ArcSweepAngle)
		{
			panel_20.Top = 40 + num4 * 32;
			num4++;
		}
		int num5 = 0;
		comboBox_2.Visible = LeadInOutEnable.LeadType;
		panel_27.Visible = LeadInOutEnable.Length;
		if (LeadInOutEnable.Length)
		{
			panel_27.Top = 40 + num5 * 32;
			num5++;
		}
		panel_26.Visible = LeadInOutEnable.TangentAngle;
		if (LeadInOutEnable.TangentAngle)
		{
			panel_26.Top = 40 + num5 * 32;
			num5++;
		}
		panel_25.Visible = LeadInOutEnable.ArcRadius;
		if (LeadInOutEnable.ArcRadius)
		{
			panel_25.Top = 40 + num5 * 32;
			num5++;
		}
		panel_24.Visible = LeadInOutEnable.ArcSweepAngle;
		if (LeadInOutEnable.ArcSweepAngle)
		{
			panel_24.Top = 40 + num5 * 32;
			num5++;
		}
		numericUpDown_14.Value = (decimal)Hatch.TotalWidth;
		numericUpDown_17.Value = (decimal)Hatch.OperationZ;
		numericUpDown_15.Value = (decimal)Hatch.CutStep;
		numericUpDown_16.Value = (decimal)Hatch.CutLength;
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
		{
			radioButton_4.Checked = true;
			radioButton_3.Checked = false;
			radioButton_2.Checked = false;
		}
		if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
		{
			radioButton_4.Checked = false;
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
		{
			radioButton_4.Checked = false;
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		numericUpDown_5.Value = (decimal)Velocity.Feed;
		numericUpDown_0.Value = (decimal)Velocity.BackwardFeed;
		numericUpDown_4.Value = (decimal)Velocity.Plunge;
		numericUpDown_2.Value = (decimal)Velocity.Finish;
		numericUpDown_3.Value = (decimal)Velocity.Leave;
		numericUpDown_1.Value = (decimal)Velocity.Rapid;
		numericUpDown_7.Value = (decimal)Distance.Air;
		checkBox_0.Checked = Distance.IncrementalSafe;
		numericUpDown_8.Value = (decimal)Distance.Safe;
		numericUpDown_6.Value = (decimal)Distance.StepUp;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Step.StepType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Step.StepType), ref comboBox_0);
		checkBox_1.Checked = Step.Enable;
		numericUpDown_9.Value = Step.Count;
		numericUpDown_11.Value = (decimal)Step.Distance;
		numericUpDown_12.Value = (decimal)Step.EndValue;
		numericUpDown_13.Value = (decimal)Step.StartValue;
		numericUpDown_10.Value = (decimal)Step.Step;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(LeadIn.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(LeadIn.LeadType), ref comboBox_1);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(LeadOut.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(LeadOut.LeadType), ref comboBox_2);
		checkBox_2.Checked = LeadIn.Enable;
		numericUpDown_19.Value = (decimal)LeadIn.ArcRadius;
		numericUpDown_18.Value = (decimal)LeadIn.ArcSweepAngle;
		numericUpDown_21.Value = (decimal)LeadIn.Length;
		numericUpDown_20.Value = (decimal)LeadIn.TangentAngle;
		checkBox_3.Checked = LeadOut.Enable;
		numericUpDown_23.Value = (decimal)LeadOut.ArcRadius;
		numericUpDown_22.Value = (decimal)LeadOut.ArcSweepAngle;
		numericUpDown_25.Value = (decimal)LeadOut.Length;
		numericUpDown_24.Value = (decimal)LeadOut.TangentAngle;
		Result = DialogResult.None;
		bool_0 = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == pictureBox_2.Name)
		{
			radioButton_4.Checked = true;
		}
		if (control.Name == pictureBox_1.Name)
		{
			radioButton_3.Checked = true;
		}
		if (control.Name == pictureBox_0.Name)
		{
			radioButton_2.Checked = true;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!bool_0)
			{
				return;
			}
			if (ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_600(this);
			Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Result = DialogResult.Cancel;
			Dispose();
		}
		if (control.Name == btn_pre.Name && tabControl_0.SelectedIndex > 0)
		{
			tabControl_0.SelectedIndex--;
		}
		if (control.Name == btn_next.Name && tabControl_0.SelectedIndex < tabControl_0.TabPages.Count - 1)
		{
			tabControl_0.SelectedIndex++;
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
	}

	internal void method_3(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(tabControl_0.SelectedTab.Controls, result, e.Shift);
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
