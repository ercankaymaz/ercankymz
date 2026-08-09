using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ns22;
using ns27;

namespace buMutliTextbox;

public class HotkeysEditorForm : Form
{
	internal BindingList<Class59> bindingList_0 = new BindingList<Class59>();

	private IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Label label_0;

	internal Button button_4;

	internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	public HotkeysEditorForm(HotkeysMapping hotkeys)
	{
		Class76.smethod_296(this);
		method_1(hotkeys);
		dataGridView_0.DataSource = bindingList_0;
	}

	private int method_0(Keys keys_0, Keys keys_1)
	{
		int num = ((int)(keys_0 & (Keys.F16 | Keys.F17))).CompareTo((int)(keys_1 & (Keys.F16 | Keys.F17)));
		if (num == 0)
		{
			num = keys_0.CompareTo(keys_1);
		}
		return num;
	}

	private void method_1(HotkeysMapping hotkeysMapping_0)
	{
		List<Keys> list = new List<Keys>(hotkeysMapping_0.Keys);
		list.Sort(method_0);
		bindingList_0.Clear();
		foreach (Keys item in list)
		{
			bindingList_0.Add(new Class59(item, hotkeysMapping_0[item]));
		}
	}

	public HotkeysMapping GetHotkeys()
	{
		HotkeysMapping hotkeysMapping = new HotkeysMapping();
		foreach (Class59 item in bindingList_0)
		{
			hotkeysMapping[Class76.smethod_28(item)] = item.method_2();
		}
		return hotkeysMapping;
	}

	internal void method_2(object sender, EventArgs e)
	{
		bindingList_0.Add(new Class59(Keys.None, FCTBAction.None));
	}

	internal void method_3(object sender, DataGridViewRowsAddedEventArgs e)
	{
		DataGridViewComboBoxCell dataGridViewComboBoxCell = dataGridView_0[0, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count == 0)
		{
			string[] array = new string[8] { "", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt" };
			foreach (string item in array)
			{
				dataGridViewComboBoxCell.Items.Add(item);
			}
		}
		dataGridViewComboBoxCell = dataGridView_0[1, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count == 0)
		{
			foreach (object value in Enum.GetValues(typeof(Keys)))
			{
				dataGridViewComboBoxCell.Items.Add(value);
			}
		}
		dataGridViewComboBoxCell = dataGridView_0[2, e.RowIndex] as DataGridViewComboBoxCell;
		if (dataGridViewComboBoxCell.Items.Count != 0)
		{
			return;
		}
		foreach (object value2 in Enum.GetValues(typeof(FCTBAction)))
		{
			dataGridViewComboBoxCell.Items.Add(value2);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		HotkeysMapping hotkeysMapping = new HotkeysMapping();
		hotkeysMapping.InitDefault();
		method_1(hotkeysMapping);
	}

	internal void method_5(object sender, EventArgs e)
	{
		for (int num = dataGridView_0.RowCount - 1; num >= 0; num--)
		{
			if (dataGridView_0.Rows[num].Selected)
			{
				dataGridView_0.Rows.RemoveAt(num);
			}
		}
	}

	internal void method_6(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			string text = Class76.smethod_495(this);
			if (!string.IsNullOrEmpty(text) && MessageBox.Show("Some actions are not assigned!\r\nActions: " + text + "\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			{
				e.Cancel = true;
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
