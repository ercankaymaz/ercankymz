using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_PerfoCombiItems : Form
{
	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public List<PerfoCombiItem> Perfo = new List<PerfoCombiItem>();

	public DiemakerPerfoPropSettings PerfoPropVar = new DiemakerPerfoPropSettings();

	public BendingJob Job = new BendingJob();

	public string strPerfo = "Perfo";

	public string strRemove = "Do You Want to Remove";

	public bool ShowAddRemove = true;

	public bool ShowPerfoCombiList = true;

	[CompilerGenerated]
	private ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler_0;

	public static List<string> Captions = new List<string>();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_6;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckedListBox checkedListBox_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Label label_7;

	internal ComboBox comboBox_0;

	internal Label label_8;

	internal PictureBox pictureBox_0;

	internal Button button_4;

	internal ImageList imageList_0;

	internal Button button_5;

	internal Button button_6;

	public event ApplyCommandWithBoolEventHandler ApplyPressed
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler = applyCommandWithBoolEventHandler_0;
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler2;
			do
			{
				applyCommandWithBoolEventHandler2 = applyCommandWithBoolEventHandler;
				ApplyCommandWithBoolEventHandler value2 = (ApplyCommandWithBoolEventHandler)Delegate.Combine(applyCommandWithBoolEventHandler2, value);
				applyCommandWithBoolEventHandler = Interlocked.CompareExchange(ref applyCommandWithBoolEventHandler_0, value2, applyCommandWithBoolEventHandler2);
			}
			while ((object)applyCommandWithBoolEventHandler != applyCommandWithBoolEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler = applyCommandWithBoolEventHandler_0;
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler2;
			do
			{
				applyCommandWithBoolEventHandler2 = applyCommandWithBoolEventHandler;
				ApplyCommandWithBoolEventHandler value2 = (ApplyCommandWithBoolEventHandler)Delegate.Remove(applyCommandWithBoolEventHandler2, value);
				applyCommandWithBoolEventHandler = Interlocked.CompareExchange(ref applyCommandWithBoolEventHandler_0, value2, applyCommandWithBoolEventHandler2);
			}
			while ((object)applyCommandWithBoolEventHandler != applyCommandWithBoolEventHandler2);
		}
	}

	public F_PerfoCombiItems()
	{
		Class76.smethod_249(this);
	}

	public void Init()
	{
		bool_0 = false;
		checkedListBox_0.Items.Clear();
		for (int i = 0; i <= Perfo.Count - 1; i++)
		{
			checkedListBox_0.Items.Add(i + 1 + "-" + strPerfo + " - " + Perfo[i].PerfoType, Perfo[i].Enable);
		}
		if (Perfo.Count <= 1)
		{
			numericUpDown_5.Enabled = false;
			numericUpDown_6.Enabled = false;
			button_2.Enabled = false;
			button_3.Enabled = false;
		}
		else
		{
			numericUpDown_5.Enabled = true;
			numericUpDown_6.Enabled = true;
			button_2.Enabled = true;
			button_3.Enabled = true;
		}
		numericUpDown_4.Value = (decimal)PerfoPropVar.EndOffset;
		numericUpDown_6.Value = (decimal)PerfoPropVar.EndPosition;
		numericUpDown_1.Value = (decimal)PerfoPropVar.FamaleWidth;
		numericUpDown_0.Value = (decimal)PerfoPropVar.MaleWidth;
		numericUpDown_2.Value = (decimal)PerfoPropVar.PerfoHeight;
		numericUpDown_3.Value = (decimal)PerfoPropVar.StartOffset;
		numericUpDown_5.Value = (decimal)PerfoPropVar.StartPosition;
		checkBox_1.Checked = PerfoPropVar.MultiPerfo;
		numericUpDown_5.Enabled = PerfoPropVar.MultiPerfo;
		numericUpDown_6.Enabled = PerfoPropVar.MultiPerfo;
		button_2.Enabled = PerfoPropVar.MultiPerfo;
		button_3.Enabled = PerfoPropVar.MultiPerfo;
		if (Perfo.Count > 0)
		{
			numericUpDown_4.Value = (decimal)Perfo[0].EndOffset;
			numericUpDown_6.Value = (decimal)Perfo[0].EndPoint;
			numericUpDown_1.Value = (decimal)Perfo[0].FemaleWidth;
			numericUpDown_0.Value = (decimal)Perfo[0].MaleWidth;
			numericUpDown_3.Value = (decimal)Perfo[0].StartOffset;
			numericUpDown_5.Value = (decimal)Perfo[0].StartPoint;
			numericUpDown_2.Value = (decimal)Perfo[0].PerfoHeight;
			checkBox_0.Checked = Perfo[0].Enable;
			comboBox_0.SelectedIndex = Convert.ToInt32(Perfo[0].PerfoType);
		}
		if (Perfo.Count == 0)
		{
			checkBox_0.Checked = false;
		}
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(DiemakerPerfoType.MaleMale, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(DiemakerPerfoType.MaleMale), ref comboBox_0);
		comboBox_0.SelectedIndex = Convert.ToInt32(PerfoPropVar.PerfoType);
		button_2.Visible = ShowAddRemove;
		button_3.Visible = ShowAddRemove;
		button_2.Visible = ShowPerfoCombiList;
		button_3.Visible = ShowPerfoCombiList;
		checkBox_1.Visible = ShowPerfoCombiList;
		checkedListBox_0.Visible = ShowPerfoCombiList;
		if (!ShowPerfoCombiList)
		{
			base.Width = 260;
		}
		else
		{
			base.Width = 580;
		}
		Result = DialogResult.Cancel;
		pictureBox_0.Image = imageList_0.Images[comboBox_0.SelectedIndex];
		bool_0 = true;
		if (checkedListBox_0.Items.Count > 0)
		{
			checkedListBox_0.SelectedIndex = 0;
		}
		Class76.smethod_120(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
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

	internal void method_1(object sender, EventArgs e)
	{
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		PerfoPropVar.EndOffset = (double)numericUpDown_4.Value;
		PerfoPropVar.EndPosition = (double)numericUpDown_6.Value;
		PerfoPropVar.FamaleWidth = (double)numericUpDown_1.Value;
		PerfoPropVar.MaleWidth = (double)numericUpDown_0.Value;
		PerfoPropVar.PerfoHeight = (double)numericUpDown_2.Value;
		PerfoPropVar.StartOffset = (double)numericUpDown_3.Value;
		PerfoPropVar.StartPosition = (double)numericUpDown_5.Value;
		PerfoPropVar.MultiPerfo = checkBox_1.Checked;
		PerfoPropVar.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(PerfoPropVar.PerfoType, comboBox_0.SelectedIndex);
		if (!PerfoPropVar.MultiPerfo)
		{
			Perfo.Clear();
			if (checkBox_0.Checked)
			{
				PerfoCombiItem perfoCombiItem = new PerfoCombiItem();
				perfoCombiItem.Enable = checkBox_0.Checked;
				perfoCombiItem.EndOffset = (double)numericUpDown_4.Value;
				perfoCombiItem.EndPoint = Job.Information.CalculatedLength;
				perfoCombiItem.FemaleWidth = (double)numericUpDown_1.Value;
				perfoCombiItem.MaleWidth = (double)numericUpDown_0.Value;
				perfoCombiItem.PerfoHeight = (double)numericUpDown_2.Value;
				perfoCombiItem.StartOffset = (double)numericUpDown_3.Value;
				perfoCombiItem.StartPoint = 0.0;
				perfoCombiItem.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(perfoCombiItem.PerfoType, comboBox_0.SelectedIndex);
				Perfo.Add(perfoCombiItem);
			}
		}
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: false);
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		Result = DialogResult.OK;
	}

	internal void method_3(object sender, EventArgs e)
	{
		PerfoPropVar.EndOffset = (double)numericUpDown_4.Value;
		PerfoPropVar.EndPosition = (double)numericUpDown_6.Value;
		PerfoPropVar.FamaleWidth = (double)numericUpDown_1.Value;
		PerfoPropVar.MaleWidth = (double)numericUpDown_0.Value;
		PerfoPropVar.PerfoHeight = (double)numericUpDown_2.Value;
		PerfoPropVar.StartOffset = (double)numericUpDown_3.Value;
		PerfoPropVar.StartPosition = (double)numericUpDown_5.Value;
		PerfoPropVar.MultiPerfo = checkBox_1.Checked;
		PerfoCombiItem perfoCombiItem = new PerfoCombiItem();
		perfoCombiItem.Enable = checkBox_0.Checked;
		perfoCombiItem.EndOffset = (double)numericUpDown_4.Value;
		perfoCombiItem.EndPoint = (double)numericUpDown_6.Value;
		perfoCombiItem.FemaleWidth = (double)numericUpDown_1.Value;
		perfoCombiItem.MaleWidth = (double)numericUpDown_0.Value;
		perfoCombiItem.PerfoHeight = (double)numericUpDown_2.Value;
		perfoCombiItem.StartOffset = (double)numericUpDown_3.Value;
		perfoCombiItem.StartPoint = (double)numericUpDown_5.Value;
		perfoCombiItem.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(perfoCombiItem.PerfoType, comboBox_0.SelectedIndex);
		Perfo.Add(perfoCombiItem);
		checkedListBox_0.Items.Clear();
		for (int i = 0; i <= Perfo.Count - 1; i++)
		{
			checkedListBox_0.Items.Add(i + 1 + "-" + strPerfo + " - " + perfoCombiItem.PerfoType, Perfo[i].Enable);
		}
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: false);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Perfo.Count - 1) & bool_0) && buString.MessageBoxQuestion(strRemove) == DialogResult.Yes)
		{
			Perfo.RemoveAt(checkedListBox_0.SelectedIndex);
			Init();
			if (applyCommandWithBoolEventHandler_0 != null)
			{
				applyCommandWithBoolEventHandler_0(Data: false);
			}
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (bool_0)
		{
			if (!checkBox_1.Checked)
			{
				numericUpDown_5.Enabled = false;
				numericUpDown_6.Enabled = false;
				button_2.Enabled = false;
				button_3.Enabled = false;
			}
			else
			{
				numericUpDown_5.Enabled = true;
				numericUpDown_6.Enabled = true;
				button_2.Enabled = true;
				button_3.Enabled = true;
			}
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Perfo.Count - 1) & bool_0)
		{
			numericUpDown_4.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].EndOffset;
			numericUpDown_6.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].EndPoint;
			numericUpDown_1.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].FemaleWidth;
			numericUpDown_0.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].MaleWidth;
			numericUpDown_3.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].StartOffset;
			numericUpDown_5.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].StartPoint;
			numericUpDown_2.Value = (decimal)Perfo[checkedListBox_0.SelectedIndex].PerfoHeight;
			checkBox_0.Checked = Perfo[checkedListBox_0.SelectedIndex].Enable;
			comboBox_0.SelectedIndex = Convert.ToInt32(Perfo[checkedListBox_0.SelectedIndex].PerfoType);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Perfo.Count - 1) & bool_0)
		{
			Perfo[checkedListBox_0.SelectedIndex].EndOffset = (double)numericUpDown_4.Value;
			Perfo[checkedListBox_0.SelectedIndex].EndPoint = (double)numericUpDown_6.Value;
			Perfo[checkedListBox_0.SelectedIndex].FemaleWidth = (double)numericUpDown_1.Value;
			Perfo[checkedListBox_0.SelectedIndex].MaleWidth = (double)numericUpDown_0.Value;
			Perfo[checkedListBox_0.SelectedIndex].StartOffset = (double)numericUpDown_3.Value;
			Perfo[checkedListBox_0.SelectedIndex].StartPoint = (double)numericUpDown_5.Value;
			Perfo[checkedListBox_0.SelectedIndex].PerfoHeight = (double)numericUpDown_2.Value;
			Perfo[checkedListBox_0.SelectedIndex].Enable = checkBox_0.Checked;
			Perfo[checkedListBox_0.SelectedIndex].PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(Perfo[checkedListBox_0.SelectedIndex].PerfoType, comboBox_0.SelectedIndex);
			if (applyCommandWithBoolEventHandler_0 != null)
			{
				applyCommandWithBoolEventHandler_0(Data: false);
			}
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (bool_0)
		{
			pictureBox_0.Image = imageList_0.Images[comboBox_0.SelectedIndex];
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		PerfoPropVar.EndOffset = (double)numericUpDown_4.Value;
		PerfoPropVar.EndPosition = (double)numericUpDown_6.Value;
		PerfoPropVar.FamaleWidth = (double)numericUpDown_1.Value;
		PerfoPropVar.MaleWidth = (double)numericUpDown_0.Value;
		PerfoPropVar.PerfoHeight = (double)numericUpDown_2.Value;
		PerfoPropVar.StartOffset = (double)numericUpDown_3.Value;
		PerfoPropVar.StartPosition = (double)numericUpDown_5.Value;
		PerfoPropVar.MultiPerfo = checkBox_1.Checked;
		PerfoPropVar.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(PerfoPropVar.PerfoType, comboBox_0.SelectedIndex);
		if (!PerfoPropVar.MultiPerfo)
		{
			Perfo.Clear();
			if (checkBox_0.Checked)
			{
				PerfoCombiItem perfoCombiItem = new PerfoCombiItem();
				perfoCombiItem.Enable = checkBox_0.Checked;
				perfoCombiItem.EndOffset = (double)numericUpDown_4.Value;
				perfoCombiItem.EndPoint = Job.Information.CalculatedLength;
				perfoCombiItem.FemaleWidth = (double)numericUpDown_1.Value;
				perfoCombiItem.MaleWidth = (double)numericUpDown_0.Value;
				perfoCombiItem.PerfoHeight = (double)numericUpDown_2.Value;
				perfoCombiItem.StartOffset = (double)numericUpDown_3.Value;
				perfoCombiItem.StartPoint = 0.0;
				perfoCombiItem.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(perfoCombiItem.PerfoType, comboBox_0.SelectedIndex);
				Perfo.Add(perfoCombiItem);
			}
		}
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: false);
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
		PerfoPropVar.EndOffset = (double)numericUpDown_4.Value;
		PerfoPropVar.EndPosition = (double)numericUpDown_6.Value;
		PerfoPropVar.FamaleWidth = (double)numericUpDown_1.Value;
		PerfoPropVar.MaleWidth = (double)numericUpDown_0.Value;
		PerfoPropVar.PerfoHeight = (double)numericUpDown_2.Value;
		PerfoPropVar.StartOffset = (double)numericUpDown_3.Value;
		PerfoPropVar.StartPosition = (double)numericUpDown_5.Value;
		PerfoPropVar.MultiPerfo = checkBox_1.Checked;
		PerfoPropVar.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(PerfoPropVar.PerfoType, comboBox_0.SelectedIndex);
		if (!PerfoPropVar.MultiPerfo)
		{
			Perfo.Clear();
			if (checkBox_0.Checked)
			{
				PerfoCombiItem perfoCombiItem = new PerfoCombiItem();
				perfoCombiItem.Enable = checkBox_0.Checked;
				perfoCombiItem.EndOffset = (double)numericUpDown_4.Value;
				perfoCombiItem.EndPoint = Job.Information.CalculatedLength;
				perfoCombiItem.FemaleWidth = (double)numericUpDown_1.Value;
				perfoCombiItem.MaleWidth = (double)numericUpDown_0.Value;
				perfoCombiItem.PerfoHeight = (double)numericUpDown_2.Value;
				perfoCombiItem.StartOffset = (double)numericUpDown_3.Value;
				perfoCombiItem.StartPoint = 0.0;
				perfoCombiItem.PerfoType = (DiemakerPerfoType)buGeneral.EnumValueFromInt(perfoCombiItem.PerfoType, comboBox_0.SelectedIndex);
				Perfo.Add(perfoCombiItem);
			}
		}
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: true);
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
