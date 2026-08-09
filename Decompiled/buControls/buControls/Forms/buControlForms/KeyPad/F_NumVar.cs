using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.KeyPad;

public class F_NumVar : Form
{
	public DialogResult Result = DialogResult.None;

	public static List<string> Captions = new List<string>();

	public double Value;

	private IContainer icontainer_0 = null;

	public buGround buGround1;

	public buButton buButton10;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buButton buButton_8;

	internal buButton buButton_9;

	internal buButton buButton_10;

	internal buButton buButton_11;

	internal buButton buButton_12;

	internal buButton buButton_13;

	internal buButton buButton_14;

	internal buTextBox buTextBox_0;

	internal buButton buButton_15;

	public TextBox txt_AxisVal;

	public F_NumVar()
	{
		Class76.smethod_50(this);
	}

	public void Init()
	{
		Class76.smethod_347(this);
		try
		{
			txt_AxisVal.Focus();
			txt_AxisVal.SelectionStart = txt_AxisVal.Text.Length;
			txt_AxisVal.SelectionLength = 0;
		}
		catch (Exception)
		{
		}
		Result = DialogResult.None;
	}

	public void ShowDialog(string Value, IWin32Window owner)
	{
		txt_AxisVal.Text = Value;
		ShowDialog(owner);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		try
		{
			string text = txt_AxisVal.Text;
			int selectionStart = txt_AxisVal.SelectionStart;
			string text2 = text.Substring(0, selectionStart);
			string text3 = text.Substring(selectionStart, text.Length - selectionStart);
			text = text2 + control.Tag.ToString() + text3;
			txt_AxisVal.Text = text;
			txt_AxisVal.Focus();
			txt_AxisVal.SelectionStart = selectionStart + 1;
			txt_AxisVal.SelectionLength = 0;
		}
		catch (Exception)
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Value = double.Parse(txt_AxisVal.Text);
		Result = DialogResult.Cancel;
		base.Visible = false;
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Value = double.Parse(txt_AxisVal.Text);
		}
		catch (Exception)
		{
			Value = 0.0;
		}
		Result = DialogResult.OK;
		base.Visible = false;
	}

	internal void method_3(object sender, EventArgs e)
	{
		txt_AxisVal.ResetText();
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			string text = txt_AxisVal.Text;
			int selectionStart = txt_AxisVal.SelectionStart;
			string text2 = text.Remove(selectionStart - 1, 1);
			txt_AxisVal.Text = text2;
			txt_AxisVal.Focus();
			txt_AxisVal.SelectionStart = selectionStart - 1;
			txt_AxisVal.SelectionLength = 0;
		}
		catch (Exception)
		{
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			string text = txt_AxisVal.Text;
			int num = text.IndexOf(".", 0, text.Length - 1);
			if (num == -1)
			{
				string text2 = txt_AxisVal.Text;
				int selectionStart = txt_AxisVal.SelectionStart;
				string text3 = text2.Substring(0, selectionStart);
				string text4 = text2.Substring(selectionStart, text2.Length - selectionStart);
				text2 = text3 + buButton_0.Tag.ToString() + text4;
				txt_AxisVal.Text = text2;
				txt_AxisVal.Focus();
				txt_AxisVal.SelectionStart = selectionStart + 1;
				txt_AxisVal.SelectionLength = 0;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		try
		{
			int selectionStart = txt_AxisVal.SelectionStart;
			_ = txt_AxisVal.Text;
			double num = double.Parse(txt_AxisVal.Text);
			txt_AxisVal.Text = (num * -1.0).ToString();
			txt_AxisVal.Focus();
			txt_AxisVal.SelectionStart = selectionStart + 1;
			txt_AxisVal.SelectionLength = 0;
		}
		catch (Exception)
		{
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
