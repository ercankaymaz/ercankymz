using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_CamCommon : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public camSpeeds Velocity = new camSpeeds();

	public camSpeedsEnable VelocityEnable = new camSpeedsEnable();

	public camDistances Distance = new camDistances();

	public camDistanceEnable DistanceEnable = new camDistanceEnable();

	public camStep Step = new camStep();

	public camStepEnable StepEnable = new camStepEnable();

	public camOffset Offset = new camOffset();

	public camOffsetEnable OffsetEnable = new camOffsetEnable();

	public camOperation Operation = new camOperation();

	public camOperationEnable OperationEnable = new camOperationEnable();

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

	public bool OperationTabVisible = true;

	public bool ToolTabVisible = false;

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public bool ReadOnly = false;

	public int FormHeight = 0;

	public int FormWidth = 0;

	public DialogResult Result = DialogResult.None;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabPage tabPage_5;

	public Button btn_pre;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Panel panel_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	internal Panel panel_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal Panel panel_4;

	internal Label label_8;

	internal NumericUpDown numericUpDown_4;

	internal Label label_9;

	internal Panel panel_5;

	internal Label label_10;

	internal NumericUpDown numericUpDown_5;

	internal Label label_11;

	internal Panel panel_6;

	internal Label label_12;

	internal NumericUpDown numericUpDown_6;

	internal Label label_13;

	internal Panel panel_7;

	internal Label label_14;

	internal Label label_15;

	internal Panel panel_8;

	internal Label label_16;

	internal NumericUpDown numericUpDown_7;

	internal Label label_17;

	internal Panel panel_9;

	internal Label label_18;

	internal NumericUpDown numericUpDown_8;

	internal Label label_19;

	internal CheckBox checkBox_0;

	internal Panel panel_10;

	internal Label label_20;

	internal NumericUpDown numericUpDown_9;

	internal Label label_21;

	internal Panel panel_11;

	internal Label label_22;

	internal NumericUpDown numericUpDown_10;

	internal Label label_23;

	internal Panel panel_12;

	internal Label label_24;

	internal NumericUpDown numericUpDown_11;

	internal Label label_25;

	internal Panel panel_13;

	internal Label label_26;

	internal NumericUpDown numericUpDown_12;

	internal Label label_27;

	internal Label label_28;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_1;

	internal Panel panel_14;

	internal Label label_29;

	internal NumericUpDown numericUpDown_13;

	internal Label label_30;

	internal Label label_31;

	internal ComboBox comboBox_1;

	internal Panel panel_15;

	internal Label label_32;

	internal NumericUpDown numericUpDown_14;

	internal Label label_33;

	internal Panel panel_16;

	internal Label label_34;

	internal NumericUpDown numericUpDown_15;

	internal Label label_35;

	internal Panel panel_17;

	internal Label label_36;

	internal NumericUpDown numericUpDown_16;

	internal Label label_37;

	internal TabPage tabPage_6;

	internal Panel panel_18;

	internal Label label_38;

	internal NumericUpDown numericUpDown_17;

	internal Label label_39;

	internal Panel panel_19;

	internal Label label_40;

	internal NumericUpDown numericUpDown_18;

	internal Label label_41;

	internal Panel panel_20;

	internal Label label_42;

	internal NumericUpDown numericUpDown_19;

	internal Label label_43;

	internal Label label_44;

	internal ComboBox comboBox_2;

	internal CheckBox checkBox_2;

	internal Panel panel_21;

	internal Label label_45;

	internal NumericUpDown numericUpDown_20;

	internal Label label_46;

	internal Panel panel_22;

	internal Label label_47;

	internal NumericUpDown numericUpDown_21;

	internal Label label_48;

	internal CheckBox checkBox_3;

	internal Panel panel_23;

	internal Label label_49;

	internal NumericUpDown numericUpDown_22;

	internal Label label_50;

	internal Panel panel_24;

	internal Label label_51;

	internal NumericUpDown numericUpDown_23;

	internal Label label_52;

	internal Panel panel_25;

	internal Label label_53;

	internal NumericUpDown numericUpDown_24;

	internal Label label_54;

	internal Panel panel_26;

	internal ComboBox comboBox_3;

	internal Label label_55;

	internal Label label_56;

	internal Panel panel_27;

	internal ComboBox comboBox_4;

	internal Label label_57;

	internal Label label_58;

	internal Panel panel_28;

	internal ComboBox comboBox_5;

	internal Label label_59;

	internal Label label_60;

	internal Panel panel_29;

	internal Label label_61;

	internal NumericUpDown numericUpDown_25;

	internal Label label_62;

	internal CheckBox checkBox_4;

	public Button btn_next;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	internal Panel panel_30;

	internal ComboBox comboBox_6;

	internal Label label_63;

	internal Label label_64;

	internal Panel panel_31;

	internal Label label_65;

	internal NumericUpDown numericUpDown_26;

	internal Label label_66;

	public F_CamCommon()
	{
		Class76.smethod_494(this);
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
		if (!MiscTabVisible && tabControl_0.TabPages.Count >= 9)
		{
			tabControl_0.TabPages.RemoveAt(8);
		}
		if (!ToolTabVisible && tabControl_0.TabPages.Count >= 8)
		{
			tabControl_0.TabPages.RemoveAt(7);
		}
		if (!LeadOutTabVisible && tabControl_0.TabPages.Count >= 7)
		{
			tabControl_0.TabPages.RemoveAt(6);
		}
		if (!LeadInTabVisible && tabControl_0.TabPages.Count >= 6)
		{
			tabControl_0.TabPages.RemoveAt(5);
		}
		if (!OffsetTabVisible && tabControl_0.TabPages.Count >= 5)
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
		if (!OperationTabVisible && tabControl_0.TabPages.Count >= 1)
		{
			tabControl_0.TabPages.RemoveAt(0);
		}
		int num = 0;
		panel_31.Visible = OperationEnable.Height;
		if (OperationEnable.Height)
		{
			panel_31.Top = 6 + num * 32;
			num++;
		}
		label_64.Visible = OperationEnable.Direction;
		if (OperationEnable.Direction)
		{
			label_64.Top = 6 + num * 32;
			num++;
		}
		int num2 = 0;
		panel_1.Visible = VelocityEnable.Feed;
		if (VelocityEnable.Feed)
		{
			panel_1.Top = 6 + num2 * 32;
			num2++;
		}
		panel_0.Visible = VelocityEnable.Plunge;
		if (VelocityEnable.Plunge)
		{
			panel_0.Top = 6 + num2 * 32;
			num2++;
		}
		panel_5.Visible = VelocityEnable.Leave;
		if (VelocityEnable.Leave)
		{
			panel_5.Top = 6 + num2 * 32;
			num2++;
		}
		panel_4.Visible = VelocityEnable.Finish;
		if (VelocityEnable.Finish)
		{
			panel_4.Top = 6 + num2 * 32;
			num2++;
		}
		panel_3.Visible = VelocityEnable.Rapid;
		if (VelocityEnable.Rapid)
		{
			panel_3.Top = 6 + num2 * 32;
			num2++;
		}
		panel_2.Visible = VelocityEnable.BackwardFeed;
		if (VelocityEnable.BackwardFeed)
		{
			panel_2.Top = 6 + num2 * 32;
			num2++;
		}
		int num3 = 0;
		panel_6.Visible = DistanceEnable.Safe;
		if (DistanceEnable.Safe)
		{
			panel_6.Top = 6 + num3 * 32;
			num3++;
		}
		panel_8.Visible = DistanceEnable.StepUp;
		if (DistanceEnable.StepUp)
		{
			panel_8.Top = 6 + num3 * 32;
			num3++;
		}
		panel_9.Visible = DistanceEnable.Air;
		if (DistanceEnable.Air)
		{
			panel_9.Top = 6 + num3 * 32;
			num3++;
		}
		panel_7.Visible = DistanceEnable.IncrementalSafe;
		if (DistanceEnable.IncrementalSafe)
		{
			panel_7.Top = 6 + num3 * 32;
			num3++;
		}
		int num4 = 0;
		comboBox_0.Visible = StepEnable.Type;
		panel_10.Visible = StepEnable.StartValue;
		if (StepEnable.StartValue)
		{
			panel_10.Top = 40 + num4 * 32;
			num4++;
		}
		panel_13.Visible = StepEnable.EndValue;
		if (StepEnable.EndValue)
		{
			panel_13.Top = 40 + num4 * 32;
			num4++;
		}
		panel_11.Visible = StepEnable.Step;
		if (StepEnable.Step)
		{
			panel_11.Top = 40 + num4 * 32;
			num4++;
		}
		panel_29.Visible = StepEnable.Count;
		if (StepEnable.Count)
		{
			panel_29.Top = 40 + num4 * 32;
			num4++;
		}
		panel_12.Visible = StepEnable.Distance;
		if (StepEnable.Distance)
		{
			panel_12.Top = 40 + num4 * 32;
			num4++;
		}
		int num5 = 0;
		panel_22.Visible = OffsetEnable.Offset;
		if (OffsetEnable.Offset)
		{
			panel_22.Top = 40 + num5 * 32;
			num5++;
		}
		panel_25.Visible = OffsetEnable.OverlapDistance;
		if (OffsetEnable.OverlapDistance)
		{
			panel_25.Top = 40 + num5 * 32;
			num5++;
		}
		panel_24.Visible = OffsetEnable.OffsetCount;
		if (OffsetEnable.OffsetCount)
		{
			panel_24.Top = 40 + num5 * 32;
			num5++;
		}
		panel_23.Visible = OffsetEnable.AdditionalOffset;
		if (OffsetEnable.AdditionalOffset)
		{
			panel_23.Top = 40 + num5 * 32;
			num5++;
		}
		panel_28.Visible = OffsetEnable.Flow;
		if (OffsetEnable.Flow)
		{
			panel_28.Top = 40 + num5 * 32;
			num5++;
		}
		panel_27.Visible = OffsetEnable.Corner;
		if (OffsetEnable.Corner)
		{
			panel_27.Top = 40 + num5 * 32;
			num5++;
		}
		panel_26.Visible = OffsetEnable.OpenContour;
		if (OffsetEnable.OpenContour)
		{
			panel_26.Top = 40 + num5 * 32;
			num5++;
		}
		int num6 = 0;
		comboBox_1.Visible = LeadInOutEnable.LeadType;
		panel_14.Visible = LeadInOutEnable.Length;
		if (LeadInOutEnable.Length)
		{
			panel_14.Top = 40 + num6 * 32;
			num6++;
		}
		panel_17.Visible = LeadInOutEnable.TangentAngle;
		if (LeadInOutEnable.TangentAngle)
		{
			panel_17.Top = 40 + num6 * 32;
			num6++;
		}
		panel_16.Visible = LeadInOutEnable.ArcRadius;
		if (LeadInOutEnable.ArcRadius)
		{
			panel_16.Top = 40 + num6 * 32;
			num6++;
		}
		panel_15.Visible = LeadInOutEnable.ArcSweepAngle;
		if (LeadInOutEnable.ArcSweepAngle)
		{
			panel_15.Top = 40 + num6 * 32;
			num6++;
		}
		int num7 = 0;
		comboBox_2.Visible = LeadInOutEnable.LeadType;
		panel_21.Visible = LeadInOutEnable.Length;
		if (LeadInOutEnable.Length)
		{
			panel_21.Top = 40 + num7 * 32;
			num7++;
		}
		panel_20.Visible = LeadInOutEnable.TangentAngle;
		if (LeadInOutEnable.TangentAngle)
		{
			panel_20.Top = 40 + num7 * 32;
			num7++;
		}
		panel_19.Visible = LeadInOutEnable.ArcRadius;
		if (LeadInOutEnable.ArcRadius)
		{
			panel_19.Top = 40 + num7 * 32;
			num7++;
		}
		panel_18.Visible = LeadInOutEnable.ArcSweepAngle;
		if (LeadInOutEnable.ArcSweepAngle)
		{
			panel_18.Top = 40 + num7 * 32;
			num7++;
		}
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Operation.Direction, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Operation.Direction), ref comboBox_6);
		numericUpDown_26.Value = (decimal)Operation.Height;
		numericUpDown_0.Value = (decimal)Velocity.Feed;
		numericUpDown_2.Value = (decimal)Velocity.BackwardFeed;
		numericUpDown_1.Value = (decimal)Velocity.Plunge;
		numericUpDown_4.Value = (decimal)Velocity.Finish;
		numericUpDown_5.Value = (decimal)Velocity.Leave;
		numericUpDown_3.Value = (decimal)Velocity.Rapid;
		numericUpDown_8.Value = (decimal)Distance.Air;
		checkBox_4.Checked = Distance.IncrementalSafe;
		numericUpDown_6.Value = (decimal)Distance.Safe;
		numericUpDown_7.Value = (decimal)Distance.StepUp;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Step.StepType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Step.StepType), ref comboBox_0);
		checkBox_0.Checked = Step.Enable;
		numericUpDown_25.Value = Step.Count;
		numericUpDown_11.Value = (decimal)Step.Distance;
		numericUpDown_12.Value = (decimal)Step.EndValue;
		numericUpDown_9.Value = (decimal)Step.StartValue;
		numericUpDown_10.Value = (decimal)Step.Step;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Offset.ClosedContour, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Offset.ClosedContour), ref comboBox_5);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Offset.Corner, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Offset.Corner), ref comboBox_4);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Offset.OpenContourOld, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Offset.OpenContourOld), ref comboBox_3);
		checkBox_3.Checked = Offset.Enable;
		numericUpDown_22.Value = (decimal)Offset.AdditionalOffset;
		numericUpDown_21.Value = (decimal)Offset.Offset;
		numericUpDown_23.Value = Offset.OffsetCount;
		numericUpDown_24.Value = (decimal)Offset.OverlapDistance;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(LeadIn.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(LeadIn.LeadType), ref comboBox_1);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(LeadOut.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(LeadOut.LeadType), ref comboBox_2);
		checkBox_1.Checked = LeadIn.Enable;
		numericUpDown_15.Value = (decimal)LeadIn.ArcRadius;
		numericUpDown_14.Value = (decimal)LeadIn.ArcSweepAngle;
		numericUpDown_13.Value = (decimal)LeadIn.Length;
		numericUpDown_16.Value = (decimal)LeadIn.TangentAngle;
		checkBox_2.Checked = LeadOut.Enable;
		numericUpDown_18.Value = (decimal)LeadOut.ArcRadius;
		numericUpDown_17.Value = (decimal)LeadOut.ArcSweepAngle;
		numericUpDown_20.Value = (decimal)LeadOut.Length;
		numericUpDown_19.Value = (decimal)LeadOut.TangentAngle;
		Result = DialogResult.None;
		bool_0 = true;
	}

	internal void method_0(object sender, EventArgs e)
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
			Class76.smethod_10(this);
			Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
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

	internal void method_1(object sender, FormClosingEventArgs e)
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
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				if (sender.GetType() == typeof(TextBox))
				{
					TextBox textBox = new TextBox();
					textBox = (TextBox)sender;
					buControlCommands.ShowKeyPad(this, textBox);
				}
				if (sender.GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = new NumericUpDown();
					numericUpDown = (NumericUpDown)sender;
					buControlCommands.ShowKeyPad(this, numericUpDown);
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
