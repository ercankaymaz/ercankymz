using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_Hatch : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public camParameters camPars = new camParameters();

	public camParametersEnable camParsEnable = new camParametersEnable();

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

	internal Panel panel_2;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_3;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_4;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_5;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_6;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal TabPage tabPage_1;

	internal Panel panel_7;

	internal CheckBox checkBox_0;

	internal Label label_6;

	internal Panel panel_8;

	internal Label label_7;

	internal NumericUpDown numericUpDown_6;

	internal Panel panel_9;

	internal Label label_8;

	internal NumericUpDown numericUpDown_7;

	internal Panel panel_10;

	internal Label label_9;

	internal NumericUpDown numericUpDown_8;

	internal TabPage tabPage_2;

	internal Panel panel_11;

	internal Label label_10;

	internal NumericUpDown numericUpDown_9;

	internal Panel panel_12;

	internal Label label_11;

	internal NumericUpDown numericUpDown_10;

	internal Panel panel_13;

	internal Label label_12;

	internal NumericUpDown numericUpDown_11;

	internal Panel panel_14;

	internal Label label_13;

	internal NumericUpDown numericUpDown_12;

	internal Label label_14;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_1;

	internal Panel panel_15;

	internal Label label_15;

	internal NumericUpDown numericUpDown_13;

	internal TabPage tabPage_3;

	internal Panel panel_16;

	internal Label label_16;

	internal NumericUpDown numericUpDown_14;

	internal Panel panel_17;

	internal Label label_17;

	internal NumericUpDown numericUpDown_15;

	internal Panel panel_18;

	internal Label label_18;

	internal NumericUpDown numericUpDown_16;

	internal Panel panel_19;

	internal Label label_19;

	internal NumericUpDown numericUpDown_17;

	internal TabPage tabPage_4;

	internal Label label_20;

	internal Panel panel_20;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal RadioButton radioButton_2;

	internal Label label_21;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Label label_22;

	internal NumericUpDown numericUpDown_18;

	internal Label label_23;

	internal NumericUpDown numericUpDown_19;

	internal Panel panel_21;

	internal Label label_24;

	internal NumericUpDown numericUpDown_20;

	internal Label label_25;

	internal NumericUpDown numericUpDown_21;

	internal Panel panel_22;

	public F_Hatch()
	{
		Class76.smethod_18(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		ArrayList arrayList = new ArrayList();
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
		LoadLanguage();
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
		int Count = 0;
		buControlCommands.SetVisiblityOfPanel(ref panel_6, camParsEnable.SpeedsEnable.Feed, 32, 6, ref Count);
		buControlCommands.SetVisiblityOfPanel(ref panel_5, camParsEnable.SpeedsEnable.Plunge, 32, 6, ref Count);
		buControlCommands.SetVisiblityOfPanel(ref panel_4, camParsEnable.SpeedsEnable.Leave, 32, 6, ref Count);
		buControlCommands.SetVisiblityOfPanel(ref panel_3, camParsEnable.SpeedsEnable.Finish, 32, 6, ref Count);
		buControlCommands.SetVisiblityOfPanel(ref panel_2, camParsEnable.SpeedsEnable.Rapid, 32, 6, ref Count);
		buControlCommands.SetVisiblityOfPanel(ref panel_1, camParsEnable.SpeedsEnable.BackwardFeed, 32, 6, ref Count);
		int Count2 = 0;
		buControlCommands.SetVisiblityOfPanel(ref panel_10, camParsEnable.DistancesEnable.Safe, 32, 6, ref Count2);
		buControlCommands.SetVisiblityOfPanel(ref panel_8, camParsEnable.DistancesEnable.StepUp, 32, 6, ref Count2);
		buControlCommands.SetVisiblityOfPanel(ref panel_9, camParsEnable.DistancesEnable.Air, 32, 6, ref Count2);
		buControlCommands.SetVisiblityOfPanel(ref panel_7, camParsEnable.DistancesEnable.IncrementalSafe, 32, 6, ref Count2);
		int Count3 = 0;
		buControlCommands.SetVisiblityOfPanel(ref panel_15, camParsEnable.StepsEnable.StartValue, 32, 40, ref Count3);
		buControlCommands.SetVisiblityOfPanel(ref panel_14, camParsEnable.StepsEnable.EndValue, 32, 40, ref Count3);
		buControlCommands.SetVisiblityOfPanel(ref panel_12, camParsEnable.StepsEnable.Step, 32, 40, ref Count3);
		buControlCommands.SetVisiblityOfPanel(ref panel_11, camParsEnable.StepsEnable.Count, 32, 40, ref Count3);
		buControlCommands.SetVisiblityOfPanel(ref panel_13, camParsEnable.StepsEnable.Distance, 32, 40, ref Count3);
		comboBox_0.Visible = camParsEnable.StepsEnable.Type;
		numericUpDown_14.Value = (decimal)camPars.Hatch.TotalWidth;
		numericUpDown_17.Value = (decimal)camPars.Hatch.OperationZ;
		numericUpDown_15.Value = (decimal)camPars.Hatch.CutStep;
		numericUpDown_16.Value = (decimal)camPars.Hatch.CutLength;
		numericUpDown_21.Value = (decimal)camPars.Hatch.CornerPoint.X;
		numericUpDown_20.Value = (decimal)camPars.Hatch.CornerPoint.Y;
		if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
		{
			radioButton_4.Checked = true;
			radioButton_3.Checked = false;
			radioButton_2.Checked = false;
		}
		if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
		{
			radioButton_4.Checked = false;
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
		{
			radioButton_4.Checked = false;
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		numericUpDown_5.Value = (decimal)camPars.Speeds.Feed;
		numericUpDown_0.Value = (decimal)camPars.Speeds.BackwardFeed;
		numericUpDown_4.Value = (decimal)camPars.Speeds.Plunge;
		numericUpDown_2.Value = (decimal)camPars.Speeds.Finish;
		numericUpDown_3.Value = (decimal)camPars.Speeds.Leave;
		numericUpDown_1.Value = (decimal)camPars.Speeds.Rapid;
		numericUpDown_7.Value = (decimal)camPars.Distances.Air;
		checkBox_0.Checked = camPars.Distances.IncrementalSafe;
		numericUpDown_8.Value = (decimal)camPars.Distances.Safe;
		numericUpDown_6.Value = (decimal)camPars.Distances.StepUp;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.Steps.StepType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.Steps.StepType), ref comboBox_0);
		checkBox_1.Checked = camPars.Steps.Enable;
		numericUpDown_9.Value = camPars.Steps.Count;
		numericUpDown_11.Value = (decimal)camPars.Steps.Distance;
		numericUpDown_12.Value = (decimal)camPars.Steps.EndValue;
		numericUpDown_13.Value = (decimal)camPars.Steps.StartValue;
		numericUpDown_10.Value = (decimal)camPars.Steps.Step;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 55)
			{
				Text = Captions[0];
				tabPage_3.Text = Captions[0];
				tabPage_0.Text = Captions[1];
				tabPage_1.Text = Captions[2];
				tabPage_2.Text = Captions[4];
				tabPage_4.Text = Captions[22];
				label_19.Text = Captions[6];
				label_18.Text = Captions[28];
				label_17.Text = Captions[29];
				label_25.Text = Captions[55];
				label_20.Text = Captions[31];
				label_21.Text = Captions[34];
				radioButton_0.Text = Captions[32];
				radioButton_1.Text = Captions[33];
				radioButton_4.Text = Captions[35];
				radioButton_3.Text = Captions[36];
				radioButton_2.Text = Captions[37];
				btn_next.Text = Captions[23];
				btn_pre.Text = Captions[22];
				btn_ok.Text = Captions[24];
				btn_cancel.Text = Captions[25];
				label_5.Text = Captions[38];
				label_4.Text = Captions[39];
				label_3.Text = Captions[40];
				label_2.Text = Captions[41];
				label_1.Text = Captions[42];
				label_0.Text = Captions[43];
				label_9.Text = Captions[44];
				label_7.Text = Captions[45];
				label_8.Text = Captions[46];
				label_6.Text = Captions[47];
				checkBox_1.Text = Captions[48];
				label_14.Text = Captions[49];
				label_15.Text = Captions[50];
				label_13.Text = Captions[51];
				label_12.Text = Captions[52];
				label_11.Text = Captions[53];
				label_10.Text = Captions[54];
			}
		}
		catch (Exception)
		{
		}
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
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_319(this);
			Properties.Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
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
