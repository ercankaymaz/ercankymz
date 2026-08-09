using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Variable;

public class F_VariableWrite : Form
{
	public FormProperties Properties = new FormProperties();

	public WatchItem Variable = new WatchItem();

	internal IContainer icontainer_0 = null;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal Label label_2;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal TextBox textBox_1;

	public F_VariableWrite()
	{
		Class76.smethod_99(this);
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
			buGeneral.GetEnumTypeValues(Variable.VarType, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Variable.VarType), ref comboBox_0);
			textBox_0.Text = Variable.Name;
			textBox_1.Text = Variable.Value.ToString();
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
		Variable.NewValue = textBox_1.Text;
		Variable.VarType = (VariableType)buGeneral.EnumValueFromInt(Variable.VarType, comboBox_0.SelectedIndex);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
