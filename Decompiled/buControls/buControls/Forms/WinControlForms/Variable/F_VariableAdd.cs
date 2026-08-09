using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Variable;

public class F_VariableAdd : Form
{
	public FormProperties Properties = new FormProperties();

	public List<WatchItem> Variables = new List<WatchItem>();

	public string SelectedVariables = "";

	public VariableType VarType = VariableType.LREAL;

	internal IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal TextBox textBox_0;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal Label label_1;

	internal ComboBox comboBox_0;

	public F_VariableAdd()
	{
		Class76.smethod_246(this);
	}

	public void Init()
	{
		try
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
			buGeneral.GetEnumTypeValues(VarType, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(VarType), ref comboBox_0);
			Class76.smethod_343(this);
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		SelectedVariables = "";
		if (listBox_0.SelectedIndex >= 0 && listBox_0.Text.Length > 0)
		{
			SelectedVariables = listBox_0.Text;
		}
		VarType = (VariableType)buGeneral.EnumValueFromInt(VarType, comboBox_0.SelectedIndex);
		if (SelectedVariables.Length != 0)
		{
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		else
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

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		try
		{
			if (textBox_0.Text.Length != 0)
			{
				listBox_0.Items.Clear();
				for (int i = 0; i <= Variables.Count - 1; i++)
				{
					if (Variables[i].Name.ToLower().IndexOf(textBox_0.Text.ToLower()) >= 0)
					{
						listBox_0.Items.Add(Variables[i]);
					}
				}
			}
			else
			{
				Class76.smethod_343(this);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
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
