using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.KeyPad;

public class F_KeyPadCharV1 : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public string Caption = "";

	public bool Caps;

	public string Value;

	public bool CheckNumeric = true;

	public bool ShowInitValue = true;

	public char PasswordChar;

	public double MaxValue = 0.0;

	public double MinValue = 0.0;

	private bool bool_0 = false;

	private string string_0 = "";

	private string string_1 = "";

	private Timer timer_0 = new Timer();

	private Timer timer_1 = new Timer();

	private Timer timer_2 = new Timer();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

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

	public buTextBox textCtrl1;

	internal buButton buButton_15;

	internal buButton buButton_16;

	internal buButton buButton_17;

	internal buButton buButton_18;

	internal buButton buButton_19;

	internal buButton buButton_20;

	internal buButton buButton_21;

	internal buButton buButton_22;

	internal buButton buButton_23;

	internal buButton buButton_24;

	internal buButton buButton_25;

	internal buButton buButton_26;

	internal buButton buButton_27;

	internal buButton buButton_28;

	internal buButton buButton_29;

	internal buButton buButton_30;

	internal buButton buButton_31;

	internal buButton buButton_32;

	internal buButton buButton_33;

	internal buButton buButton_34;

	internal buButton buButton_35;

	internal buButton buButton_36;

	internal buButton buButton_37;

	internal buButton buButton_38;

	internal buButton buButton_39;

	internal buButton buButton_40;

	internal buButton buButton_41;

	internal buButton buButton_42;

	internal buButton buButton_43;

	internal buButton buButton_44;

	internal buButton buButton_45;

	internal buButton buButton_46;

	internal buButton buButton_47;

	internal buButton buButton_48;

	internal buButton buButton_49;

	internal buButton buButton_50;

	internal buButton buButton_51;

	internal buButton buButton_52;

	internal buButton buButton_53;

	internal buButton buButton_54;

	internal buButton buButton_55;

	internal buButton buButton_56;

	internal buButton buButton_57;

	internal buButton buButton_58;

	internal buButton buButton_59;

	internal buButton buButton_60;

	internal buButton buButton_61;

	internal buButton buButton_62;

	internal buButton buButton_63;

	internal buButton buButton_64;

	internal buButton buButton_65;

	internal buButton buButton_66;

	internal buButton buButton_67;

	internal buButton buButton_68;

	internal buButton buButton_69;

	internal buButton buButton_70;

	internal buButton buButton_71;

	internal buButton buButton_72;

	public F_KeyPadCharV1()
	{
		Class186.smethod_773(this);
		timer_0 = new Timer();
		timer_0.Tick += timer_0_Tick;
		timer_1 = new Timer();
		timer_1.Tick += timer_1_Tick;
		timer_2 = new Timer();
		timer_2.Tick += timer_2_Tick;
	}

	public void ShowDialog(string Value)
	{
		bool_0 = false;
		string_0 = Value;
		textCtrl1.Text = Value;
		textCtrl1.Invalidate();
		textCtrl1.Display.SelectionColor = textCtrl1.Display.BackColor;
		textCtrl1.PasswordChar = PasswordChar;
		timer_0.Interval = 1000;
		timer_1.Interval = 1500;
		timer_2.Interval = 100;
		timer_2.Enabled = true;
		if (Caption.Length <= 0)
		{
			buGround_0.Text = "Value";
			if (ShowInitValue)
			{
				buGround_0.Text = buGround_0.Text + " - [ " + Value + " ]";
			}
		}
		else
		{
			buGround_0.Text = Caption;
			if (ShowInitValue)
			{
				buGround_0.Text = buGround_0.Text + " - [ " + Value + " ]";
			}
		}
		ShowDialog();
	}

	public void ShowDialog(string Value, IWin32Window owner)
	{
		bool_0 = false;
		string_0 = Value;
		textCtrl1.Text = Value;
		textCtrl1.Display.SelectionColor = textCtrl1.BackColor;
		textCtrl1.PasswordChar = PasswordChar;
		timer_0.Interval = 1000;
		timer_1.Interval = 1500;
		timer_2.Interval = 100;
		timer_2.Enabled = true;
		if (Caption.Length <= 0)
		{
			buGround_0.Text = "Value";
			if (ShowInitValue)
			{
				buGround_0.Text = buGround_0.Text + " - [ " + Value + " ]";
			}
		}
		else
		{
			buGround_0.Text = Caption;
			if (ShowInitValue)
			{
				buGround_0.Text = buGround_0.Text + " - [ " + Value + " ]";
			}
		}
		ShowDialog(owner);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (!(((buButton)sender).Tag.ToString() == "esc"))
		{
			if (!bool_0)
			{
				return;
			}
			if (textCtrl1.txt.SelectedText.Length > 0 && ((buButton)sender).Tag.ToString() != "enter")
			{
				textCtrl1.txt.Text = "";
			}
			if (!(((buButton)sender).Tag.ToString() == "caps"))
			{
				if (!(((buButton)sender).Tag.ToString() == "back"))
				{
					if (!(((buButton)sender).Tag.ToString() == "enter"))
					{
						if (!Caps)
						{
							textCtrl1.Text += ((buButton)sender).Tag.ToString().ToLower();
						}
						else
						{
							textCtrl1.Text += ((buButton)sender).Tag.ToString();
						}
						textCtrl1.txt.SelectionStart = textCtrl1.txt.Text.Length;
						return;
					}
					Value = textCtrl1.Text;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						Close();
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						base.Visible = false;
					}
				}
				else if (textCtrl1.Text.Length > 0)
				{
					textCtrl1.Text = textCtrl1.Text.Substring(0, textCtrl1.Text.Length - 1);
				}
			}
			else
			{
				Caps = !Caps;
			}
		}
		else
		{
			Value = string_0;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Close();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		textCtrl1.SelectAll();
		bool_0 = true;
		timer_2.Enabled = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		textCtrl1.Text = string_1;
		timer_0.Enabled = false;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		textCtrl1.Text = "";
		timer_1.Enabled = false;
	}

	internal void method_1(object sender, MouseEventArgs e)
	{
		timer_1.Enabled = true;
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		timer_1.Enabled = false;
	}

	internal void method_3(object sender, EventArgs e)
	{
		timer_1.Enabled = false;
	}

	internal void method_4(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			method_0(buButton_11, null);
		}
		if (e.KeyCode == Keys.Return)
		{
			method_0(buButton_12, null);
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
