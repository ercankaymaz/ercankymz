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

public class F_BroachItems : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public List<BroachItem> Broachs = new List<BroachItem>();

	public string strBridge = "Broach";

	public string strRemove = "Do You Want to Remove";

	public bool ShowAddRemove = true;

	[CompilerGenerated]
	private ApplyCommandEventHandler applyCommandEventHandler_0;

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal CheckedListBox checkedListBox_0;

	internal Label label_4;

	internal ComboBox comboBox_0;

	internal Button button_6;

	internal Button button_7;

	public event ApplyCommandEventHandler ApplyPressed
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandEventHandler applyCommandEventHandler = applyCommandEventHandler_0;
			ApplyCommandEventHandler applyCommandEventHandler2;
			do
			{
				applyCommandEventHandler2 = applyCommandEventHandler;
				ApplyCommandEventHandler value2 = (ApplyCommandEventHandler)Delegate.Combine(applyCommandEventHandler2, value);
				applyCommandEventHandler = Interlocked.CompareExchange(ref applyCommandEventHandler_0, value2, applyCommandEventHandler2);
			}
			while ((object)applyCommandEventHandler != applyCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandEventHandler applyCommandEventHandler = applyCommandEventHandler_0;
			ApplyCommandEventHandler applyCommandEventHandler2;
			do
			{
				applyCommandEventHandler2 = applyCommandEventHandler;
				ApplyCommandEventHandler value2 = (ApplyCommandEventHandler)Delegate.Remove(applyCommandEventHandler2, value);
				applyCommandEventHandler = Interlocked.CompareExchange(ref applyCommandEventHandler_0, value2, applyCommandEventHandler2);
			}
			while ((object)applyCommandEventHandler != applyCommandEventHandler2);
		}
	}

	public F_BroachItems()
	{
		Class76.smethod_209(this);
	}

	public void Init()
	{
		bool_0 = false;
		checkedListBox_0.Items.Clear();
		for (int i = 0; i <= Broachs.Count - 1; i++)
		{
			checkedListBox_0.Items.Add(i + 1 + "-" + strBridge, Broachs[i].Enable);
		}
		BroachItem broachItem = new BroachItem();
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(broachItem.Direction, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(broachItem.Direction), ref comboBox_0);
		button_6.Visible = ShowAddRemove;
		button_7.Visible = ShowAddRemove;
		Result = DialogResult.Cancel;
		bool_0 = true;
		if (checkedListBox_0.Items.Count > 0)
		{
			checkedListBox_0.SelectedIndex = 0;
		}
		Class76.smethod_793(this);
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
		for (int i = 0; i <= Broachs.Count - 1; i++)
		{
			Broachs[i].Enable = true;
			checkedListBox_0.SetItemCheckState(i, CheckState.Checked);
		}
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		for (int i = 0; i <= Broachs.Count - 1; i++)
		{
			Broachs[i].Enable = false;
			checkedListBox_0.SetItemCheckState(i, CheckState.Unchecked);
		}
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		for (int i = 0; i <= Broachs.Count - 1; i++)
		{
			Broachs[i].Width = (double)numericUpDown_3.Value;
			Broachs[i].Depth = (double)numericUpDown_2.Value;
		}
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Broachs.Count - 1))
		{
			Broachs[checkedListBox_0.SelectedIndex].Width = (double)numericUpDown_3.Value;
			Broachs[checkedListBox_0.SelectedIndex].Depth = (double)numericUpDown_2.Value;
			Broachs[checkedListBox_0.SelectedIndex].Offset = (double)numericUpDown_1.Value;
			Broachs[checkedListBox_0.SelectedIndex].ExtractXPosition = (double)numericUpDown_0.Value;
			Broachs[checkedListBox_0.SelectedIndex].Direction = (DiemakerBroachDirection)buGeneral.EnumValueFromInt(Broachs[checkedListBox_0.SelectedIndex].Direction, comboBox_0.SelectedIndex);
			bool itemChecked = checkedListBox_0.GetItemChecked(checkedListBox_0.SelectedIndex);
			Broachs[checkedListBox_0.SelectedIndex].Enable = itemChecked;
		}
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
		}
		for (int i = 0; i <= checkedListBox_0.Items.Count - 1; i++)
		{
			bool itemChecked = checkedListBox_0.GetItemChecked(i);
			Broachs[i].Enable = itemChecked;
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Broachs.Count - 1) & bool_0)
		{
			numericUpDown_3.Value = (decimal)Broachs[checkedListBox_0.SelectedIndex].Width;
			numericUpDown_2.Value = (decimal)Broachs[checkedListBox_0.SelectedIndex].Depth;
			numericUpDown_1.Value = (decimal)Broachs[checkedListBox_0.SelectedIndex].Offset;
			numericUpDown_0.Value = (decimal)Broachs[checkedListBox_0.SelectedIndex].ExtractXPosition;
			comboBox_0.SelectedIndex = Convert.ToInt32(Broachs[checkedListBox_0.SelectedIndex].Direction);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		BroachItem item = new BroachItem();
		Broachs.Add(item);
		Init();
	}

	internal void method_9(object sender, EventArgs e)
	{
		if (((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Broachs.Count - 1) & bool_0) && buString.MessageBoxQuestion(strRemove) == DialogResult.Yes)
		{
			Broachs.RemoveAt(checkedListBox_0.SelectedIndex);
			Init();
			if (applyCommandEventHandler_0 != null)
			{
				applyCommandEventHandler_0();
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
