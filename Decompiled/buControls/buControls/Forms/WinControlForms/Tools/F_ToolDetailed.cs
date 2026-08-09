using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDetailed : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public ToolBase Tool = new ToolBase();

	public bool DataTabVisible = true;

	public bool GeometryTabVisible = true;

	public bool CamTabVisible = true;

	public bool PositionTabVisible = false;

	public bool AuxTabVisible = true;

	public ToolAreaVisible ToolVarVisible = new ToolAreaVisible();

	public bool ShowHelps = true;

	public bool ShowNextButton = false;

	public bool ShowPreButton = false;

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

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal PictureBox pictureBox_0;

	internal ComboBox comboBox_0;

	internal TabPage tabPage_4;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Label label_2;

	internal Panel panel_1;

	internal CheckBox checkBox_0;

	internal Label label_3;

	internal Label label_4;

	internal Panel panel_2;

	internal CheckBox checkBox_1;

	internal Label label_5;

	internal Label label_6;

	internal Panel panel_3;

	internal ComboBox comboBox_1;

	internal Label label_7;

	internal Label label_8;

	internal Panel panel_4;

	internal Label label_9;

	internal Label label_10;

	internal Panel panel_5;

	internal Label label_11;

	internal NumericUpDown numericUpDown_0;

	internal Label label_12;

	internal Panel panel_6;

	internal Label label_13;

	internal NumericUpDown numericUpDown_1;

	internal Label label_14;

	internal Panel panel_7;

	internal Label label_15;

	internal NumericUpDown numericUpDown_2;

	internal Label label_16;

	internal Panel panel_8;

	internal Label label_17;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_18;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_9;

	internal Label label_19;

	internal NumericUpDown numericUpDown_6;

	internal Label label_20;

	internal Panel panel_10;

	internal Label label_21;

	internal NumericUpDown numericUpDown_7;

	internal Label label_22;

	internal Panel panel_11;

	internal Label label_23;

	internal NumericUpDown numericUpDown_8;

	internal Label label_24;

	internal Panel panel_12;

	internal Label label_25;

	internal NumericUpDown numericUpDown_9;

	internal Label label_26;

	internal Panel panel_13;

	internal Label label_27;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal Label label_28;

	internal NumericUpDown numericUpDown_12;

	internal Panel panel_14;

	internal Label label_29;

	internal NumericUpDown numericUpDown_13;

	internal NumericUpDown numericUpDown_14;

	internal Label label_30;

	internal NumericUpDown numericUpDown_15;

	internal Panel panel_15;

	internal Label label_31;

	internal NumericUpDown numericUpDown_16;

	internal NumericUpDown numericUpDown_17;

	internal Label label_32;

	internal NumericUpDown numericUpDown_18;

	internal Panel panel_16;

	internal Label label_33;

	internal NumericUpDown numericUpDown_19;

	internal NumericUpDown numericUpDown_20;

	internal Label label_34;

	internal NumericUpDown numericUpDown_21;

	internal Panel panel_17;

	internal Label label_35;

	internal NumericUpDown numericUpDown_22;

	internal Label label_36;

	internal ImageList imageList_2;

	public Button btn_cancel;

	public Button btn_ok;

	internal TextBox textBox_1;

	public Button btn_next;

	public Button btn_pre;

	internal Panel panel_18;

	internal Label label_37;

	internal Label label_38;

	internal Label label_39;

	internal Panel panel_19;

	internal Label label_40;

	internal Label label_41;

	internal Label label_42;

	internal Panel panel_20;

	internal Label label_43;

	internal Label label_44;

	internal Label label_45;

	internal Panel panel_21;

	internal Label label_46;

	internal Panel panel_22;

	internal ComboBox comboBox_2;

	internal Label label_47;

	internal Panel panel_23;

	internal Label label_48;

	internal NumericUpDown numericUpDown_23;

	internal Panel panel_24;

	internal Label label_49;

	internal NumericUpDown numericUpDown_24;

	internal Panel panel_25;

	internal Label label_50;

	internal NumericUpDown numericUpDown_25;

	internal Panel panel_26;

	internal Label label_51;

	internal NumericUpDown numericUpDown_26;

	internal Panel panel_27;

	internal Label label_52;

	internal NumericUpDown numericUpDown_27;

	internal NumericUpDown numericUpDown_28;

	internal TextBox textBox_2;

	internal Label label_53;

	internal Label label_54;

	internal Label label_55;

	internal Label label_56;

	internal Label label_57;

	internal Label label_58;

	internal Label label_59;

	public F_ToolDetailed()
	{
		Class76.smethod_607(this);
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
		if (!AuxTabVisible && tabControl_0.TabPages.Count >= 5)
		{
			tabControl_0.TabPages.RemoveAt(4);
		}
		if (!PositionTabVisible && tabControl_0.TabPages.Count >= 4)
		{
			tabControl_0.TabPages.RemoveAt(3);
		}
		if (!CamTabVisible && tabControl_0.TabPages.Count >= 3)
		{
			tabControl_0.TabPages.RemoveAt(2);
		}
		if (!GeometryTabVisible && tabControl_0.TabPages.Count >= 2)
		{
			tabControl_0.TabPages.RemoveAt(1);
		}
		if (!DataTabVisible && tabControl_0.TabPages.Count >= 1)
		{
			tabControl_0.TabPages.RemoveAt(0);
		}
		int num = 0;
		panel_0.Visible = ToolVarVisible.Name;
		if (ToolVarVisible.Name)
		{
			panel_0.Top = 6 + num * 32;
			num++;
		}
		panel_7.Visible = ToolVarVisible.No;
		if (ToolVarVisible.No)
		{
			panel_7.Top = 6 + num * 32;
			num++;
		}
		panel_6.Visible = ToolVarVisible.Sector;
		if (ToolVarVisible.Sector)
		{
			panel_6.Top = 6 + num * 32;
			num++;
		}
		panel_5.Visible = ToolVarVisible.HeightOffsetIndex;
		if (ToolVarVisible.HeightOffsetIndex)
		{
			panel_5.Top = 6 + num * 32;
			num++;
		}
		panel_4.Visible = ToolVarVisible.Tag;
		if (ToolVarVisible.Name)
		{
			panel_4.Top = 6 + num * 32;
			num++;
		}
		panel_3.Visible = ToolVarVisible.Purpose;
		if (ToolVarVisible.Purpose)
		{
			panel_3.Top = 6 + num * 32;
			num++;
		}
		panel_2.Visible = ToolVarVisible.Clone;
		if (ToolVarVisible.Clone)
		{
			panel_2.Top = 6 + num * 32;
			num++;
		}
		panel_1.Visible = ToolVarVisible.Broken;
		if (ToolVarVisible.Broken)
		{
			panel_1.Top = 6 + num * 32;
			num++;
		}
		int num2 = 0;
		panel_12.Visible = ToolVarVisible.Diameter;
		if (ToolVarVisible.Diameter)
		{
			panel_12.Top = 6 + num2 * 32;
			num2++;
		}
		panel_10.Visible = ToolVarVisible.Length;
		if (ToolVarVisible.Length)
		{
			panel_10.Top = 6 + num2 * 32;
			num2++;
		}
		panel_11.Visible = ToolVarVisible.Thickness;
		if (ToolVarVisible.Thickness)
		{
			panel_11.Top = 6 + num2 * 32;
			num2++;
		}
		panel_9.Visible = ToolVarVisible.MinLength;
		if (ToolVarVisible.MinLength)
		{
			panel_9.Top = 6 + num2 * 32;
			num2++;
		}
		panel_8.Visible = ToolVarVisible.VectorDirection;
		if (ToolVarVisible.VectorDirection)
		{
			panel_8.Top = 6 + num2 * 32;
			num2++;
		}
		panel_20.Visible = ToolVarVisible.SolidColor;
		if (ToolVarVisible.SolidColor)
		{
			panel_20.Top = 6 + num2 * 32;
			num2++;
		}
		panel_18.Visible = ToolVarVisible.CamColor;
		if (ToolVarVisible.CamColor)
		{
			panel_18.Top = 6 + num2 * 32;
			num2++;
		}
		panel_19.Visible = ToolVarVisible.UpperCamColor;
		if (ToolVarVisible.UpperCamColor)
		{
			panel_19.Top = 6 + num2 * 32;
			num2++;
		}
		int num3 = 0;
		panel_27.Visible = ToolVarVisible.Stepover;
		if (ToolVarVisible.Stepover)
		{
			panel_27.Top = 6 + num3 * 32;
			num3++;
		}
		panel_26.Visible = ToolVarVisible.OperationHeight;
		if (ToolVarVisible.OperationHeight)
		{
			panel_26.Top = 6 + num3 * 32;
			num3++;
		}
		panel_25.Visible = ToolVarVisible.FeedSpeed;
		if (ToolVarVisible.FeedSpeed)
		{
			panel_25.Top = 6 + num3 * 32;
			num3++;
		}
		panel_24.Visible = ToolVarVisible.PlungeSpeed;
		if (ToolVarVisible.PlungeSpeed)
		{
			panel_24.Top = 6 + num3 * 32;
			num3++;
		}
		panel_23.Visible = ToolVarVisible.SpindleSpeed;
		if (ToolVarVisible.SpindleSpeed)
		{
			panel_23.Top = 6 + num3 * 32;
			num3++;
		}
		panel_22.Visible = ToolVarVisible.SpindleDirection;
		if (ToolVarVisible.SpindleDirection)
		{
			panel_22.Top = 6 + num3 * 32;
			num3++;
		}
		panel_21.Visible = ToolVarVisible.OperationHeigthForSecond;
		if (ToolVarVisible.OperationHeigthForSecond)
		{
			panel_21.Top = 6 + num3 * 32;
			num3++;
		}
		int num4 = 0;
		panel_17.Visible = ToolVarVisible.AngularPosition;
		if (ToolVarVisible.AngularPosition)
		{
			panel_17.Top = 40 + num4 * 32;
			num4++;
		}
		panel_15.Visible = ToolVarVisible.SetPositionXYZ;
		if (ToolVarVisible.SetPositionXYZ)
		{
			panel_15.Top = 40 + num4 * 32;
			num4++;
		}
		panel_16.Visible = ToolVarVisible.SetPositionABC;
		if (ToolVarVisible.SetPositionABC)
		{
			panel_16.Top = 40 + num4 * 32;
			num4++;
		}
		panel_14.Visible = ToolVarVisible.OffsetXYZ;
		if (ToolVarVisible.OffsetXYZ)
		{
			panel_14.Top = 40 + num4 * 32;
			num4++;
		}
		panel_13.Visible = ToolVarVisible.OffsetABC;
		if (ToolVarVisible.OffsetABC)
		{
			panel_13.Top = 40 + num4 * 32;
			num4++;
		}
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Geometry.GeometryType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Geometry.GeometryType), ref comboBox_0);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Purpose, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Purpose), ref comboBox_1);
		numericUpDown_2.Value = Tool.Data.No;
		numericUpDown_1.Value = Tool.Data.Sector;
		numericUpDown_0.Value = Tool.Data.HeightOffsetIndex;
		textBox_1.Text = Tool.Data.Name;
		textBox_2.Text = Tool.Data.Tag;
		checkBox_0.Checked = Tool.Data.Broken;
		checkBox_1.Checked = Tool.Data.Clone;
		numericUpDown_9.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_7.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_8.Value = (decimal)Tool.Geometry.Thickness;
		numericUpDown_6.Value = (decimal)Tool.Geometry.MinLength;
		numericUpDown_5.Value = (decimal)Tool.Geometry.PlaneDirection.X;
		numericUpDown_4.Value = (decimal)Tool.Geometry.PlaneDirection.Y;
		numericUpDown_3.Value = (decimal)Tool.Geometry.PlaneDirection.Z;
		label_43.BackColor = Tool.Display.Solid.SkinColor;
		label_37.BackColor = Tool.Display.CamColor;
		label_40.BackColor = Tool.Display.UpperCamColor;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.CamData.SpindleDirection, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.CamData.SpindleDirection), ref comboBox_2);
		numericUpDown_28.Value = (decimal)Tool.CamData.Stepover;
		numericUpDown_26.Value = (decimal)Tool.CamData.OperationHeight;
		numericUpDown_25.Value = (decimal)Tool.CamData.FeedSpeed;
		numericUpDown_24.Value = (decimal)Tool.CamData.PlungeSpeed;
		numericUpDown_23.Value = (decimal)Tool.CamData.SpindleSpeed;
		numericUpDown_27.Value = (decimal)Tool.CamData.OperationHeigthForSecond;
		numericUpDown_22.Value = (decimal)Tool.Positions.AngularPosition;
		numericUpDown_18.Value = (decimal)Tool.Positions.Position.X;
		numericUpDown_17.Value = (decimal)Tool.Positions.Position.Y;
		numericUpDown_16.Value = (decimal)Tool.Positions.Position.Z;
		numericUpDown_21.Value = (decimal)Tool.Positions.Position.A;
		numericUpDown_20.Value = (decimal)Tool.Positions.Position.B;
		numericUpDown_19.Value = (decimal)Tool.Positions.Position.C;
		numericUpDown_15.Value = (decimal)Tool.Positions.Offset.X;
		numericUpDown_14.Value = (decimal)Tool.Positions.Offset.Y;
		numericUpDown_13.Value = (decimal)Tool.Positions.Offset.Z;
		numericUpDown_12.Value = (decimal)Tool.Positions.Offset.A;
		numericUpDown_11.Value = (decimal)Tool.Positions.Offset.B;
		numericUpDown_10.Value = (decimal)Tool.Positions.Offset.C;
		Result = DialogResult.None;
		bool_0 = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 67)
			{
				Text = Captions[0];
				tabPage_0.Text = Captions[1];
				label_1.Text = Captions[2];
				label_15.Text = Captions[3];
				label_13.Text = Captions[4];
				label_11.Text = Captions[5];
				label_9.Text = Captions[6];
				label_7.Text = Captions[7];
				label_5.Text = Captions[8];
				label_3.Text = Captions[9];
				label_2.Text = Captions[10];
				label_16.Text = Captions[11];
				label_14.Text = Captions[12];
				label_12.Text = Captions[13];
				label_10.Text = Captions[14];
				label_8.Text = Captions[15];
				label_6.Text = Captions[16];
				label_4.Text = Captions[17];
				tabPage_1.Text = Captions[18];
				label_25.Text = Captions[19];
				label_21.Text = Captions[20];
				label_23.Text = Captions[21];
				label_19.Text = Captions[22];
				label_18.Text = Captions[23];
				label_44.Text = Captions[24];
				label_38.Text = Captions[25];
				label_41.Text = Captions[26];
				label_26.Text = Captions[27];
				label_22.Text = Captions[28];
				label_24.Text = Captions[29];
				label_20.Text = Captions[30];
				label_17.Text = Captions[31];
				label_45.Text = Captions[32];
				label_39.Text = Captions[33];
				label_42.Text = Captions[34];
				tabPage_2.Text = Captions[35];
				label_52.Text = Captions[36];
				label_51.Text = Captions[37];
				label_50.Text = Captions[38];
				label_49.Text = Captions[39];
				label_48.Text = Captions[40];
				label_47.Text = Captions[41];
				label_46.Text = Captions[42];
				label_59.Text = Captions[43];
				label_58.Text = Captions[44];
				label_57.Text = Captions[45];
				label_56.Text = Captions[46];
				label_55.Text = Captions[47];
				label_54.Text = Captions[48];
				label_53.Text = Captions[49];
				tabPage_4.Text = Captions[50];
				label_35.Text = Captions[51];
				label_32.Text = Captions[52];
				label_34.Text = Captions[53];
				label_30.Text = Captions[54];
				label_28.Text = Captions[55];
				label_36.Text = Captions[56];
				label_31.Text = Captions[57];
				label_33.Text = Captions[58];
				label_29.Text = Captions[59];
				label_27.Text = Captions[60];
				textBox_0.Text = Captions[61];
				label_0.Text = Captions[62];
				btn_ok.Text = Captions[63];
				btn_cancel.Text = Captions[64];
				btn_pre.Text = Captions[65];
				btn_next.Text = Captions[66];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!bool_0)
		{
			return;
		}
		if (control.Name == btn_ok.Name)
		{
			Class76.smethod_581(this);
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
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
	}

	internal void method_1(object sender, KeyEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		pictureBox_0.Image = null;
		if (!((comboBox_0.SelectedIndex >= 0) & (comboBox_0.SelectedIndex <= imageList_1.Images.Count - 2)))
		{
			pictureBox_0.Image = imageList_1.Images[0];
		}
		else
		{
			pictureBox_0.Image = imageList_1.Images[comboBox_0.SelectedIndex + 1];
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_43.Name)
		{
			Color cColor = label_43.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				label_43.BackColor = cColor;
			}
		}
		if (control.Name == label_37.Name)
		{
			Color cColor2 = label_37.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				label_37.BackColor = cColor2;
			}
		}
		if (control.Name == label_40.Name)
		{
			Color cColor3 = label_40.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				label_40.BackColor = cColor3;
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
