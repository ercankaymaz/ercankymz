using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Password;

public class F_PasswordV1 : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public string Caption = "";

	public bool Caps;

	public string Value;

	public bool CheckNumeric = true;

	public bool ShowInitValue = true;

	public char PasswordChar = '*';

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

	public buTextBox textCtrl1;

	public F_PasswordV1()
	{
		Class186.smethod_445(this);
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
		if (Caption.Length > 0)
		{
			buGround_0.Text = Caption;
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
		if (Caption.Length > 0)
		{
			buGround_0.Text = Caption;
		}
		ShowDialog(owner);
	}

	internal void method_0(object sender, EventArgs e)
	{
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

	internal void method_1(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Escape)
		{
			if (e.KeyCode == Keys.Return)
			{
				method_0(buButton_0, null);
			}
			return;
		}
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

	internal void method_2(object sender, EventArgs e)
	{
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.Caption = Value;
			f_KeyPadNumV.textCtrl1.PasswordChar = '*';
			f_KeyPadNumV.PasswordChar = '*';
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.ShowDialog(Value, this);
			textCtrl1.Text = f_KeyPadNumV.Value;
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
