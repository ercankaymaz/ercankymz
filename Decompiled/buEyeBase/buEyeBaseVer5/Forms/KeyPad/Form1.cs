using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns71;

namespace buEyeBaseVer5.Forms.KeyPad;

public class Form1 : Form
{
	private double double_0 = 0.0;

	private string string_0 = "";

	private IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal TextBox textBox_0;

	public Form1()
	{
		Class186.smethod_715(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class186.smethod_296(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		string text = ((Button)sender).Text;
		if (!char.IsDigit(text[0]) && !(text == "."))
		{
			string text2 = text;
			string text3 = text2;
			switch (Class186.smethod_578(text3))
			{
			case 1172297281u:
				if (text3 == "MC")
				{
					double_0 = 0.0;
					return;
				}
				break;
			case 501192521u:
				if (text3 == "M+")
				{
					double_0 += Class186.smethod_626(textBox_0.Text, this);
					return;
				}
				break;
			case 534747759u:
				if (text3 == "M-")
				{
					double_0 -= Class186.smethod_626(textBox_0.Text, this);
					return;
				}
				break;
			case 775983274u:
				if (text3 == "⌫")
				{
					if (textBox_0.Text.Length > 0)
					{
						textBox_0.Text = textBox_0.Text.Substring(0, textBox_0.Text.Length - 1);
					}
					string_0 = textBox_0.Text;
					return;
				}
				break;
			case 887077758u:
				if (text3 == "MR")
				{
					textBox_0.Text = double_0.ToString();
					return;
				}
				break;
			case 940354920u:
				if (text3 == "=")
				{
					try
					{
						double num = Class186.smethod_626(textBox_0.Text, this);
						listBox_0.Items.Insert(0, textBox_0.Text + " = " + num);
						textBox_0.Text = num.ToString();
						string_0 = textBox_0.Text;
						return;
					}
					catch
					{
						textBox_0.Text = "Error";
						return;
					}
				}
				break;
			case 3322673650u:
				if (text3 == "C")
				{
					textBox_0.Text = "0";
					string_0 = "";
					return;
				}
				break;
			}
			textBox_0.Text += text;
			string_0 = textBox_0.Text;
		}
		else
		{
			if (textBox_0.Text == "0")
			{
				textBox_0.Text = "";
			}
			textBox_0.Text += text;
			string_0 = textBox_0.Text;
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
