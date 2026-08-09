using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.KeyPad;

public class F_Keyboard : Form
{
	public DialogResult Result = DialogResult.None;

	public static List<string> Captions = new List<string>();

	public string Value;

	private IContainer icontainer_0 = null;

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

	internal buCheckBox buCheckBox_0;

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

	internal buButton buButton_73;

	internal buButton buButton_74;

	internal buButton buButton_75;

	internal buButton buButton_76;

	internal buButton buButton_77;

	internal buButton buButton_78;

	internal buButton buButton_79;

	internal buButton buButton_80;

	internal buButton buButton_81;

	internal buGround buGround_0;

	public TextBox txt_input;

	public F_Keyboard()
	{
		Class76.smethod_216(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class76.smethod_788(this);
		Result = DialogResult.None;
		Value = "";
	}

	public void ShowDialog(string Value, IWin32Window owner)
	{
		txt_input.Text = Value;
		ShowDialog(owner);
	}

	public void ClickKey(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		try
		{
			string text = txt_input.Text;
			int selectionStart = txt_input.SelectionStart;
			string text2 = text.Substring(0, selectionStart);
			string text3 = text.Substring(selectionStart, text.Length - selectionStart);
			text = text2 + control.Text + text3;
			txt_input.Text = text;
			txt_input.Focus();
			txt_input.SelectionStart = selectionStart + 1;
			txt_input.SelectionLength = 0;
		}
		catch (Exception)
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Value = txt_input.Text;
		Result = DialogResult.Cancel;
		Close();
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			SendKeys.Send("{BACKSPACE}");
		}
		catch (Exception)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		try
		{
			Value = txt_input.Text;
		}
		catch (Exception)
		{
		}
		Close();
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			SendKeys.Send("{RIGHT}");
		}
		catch (Exception)
		{
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			SendKeys.Send("{LEFT}");
		}
		catch (Exception)
		{
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		try
		{
			SendKeys.Send(" ");
		}
		catch (Exception)
		{
		}
	}

	internal void method_7(object object_0, bool bool_0)
	{
		SendKeys.Send("{CAPSLOCK}");
		if (buCheckBox_0.Check)
		{
			buButton_0.Text = "Q";
			buButton_1.Text = "A";
			buButton_2.Text = "Z";
			buButton_3.Text = "X";
			buButton_4.Text = "S";
			buButton_5.Text = "W";
			buButton_6.Text = "C";
			buButton_7.Text = "D";
			buButton_8.Text = "E";
			buButton_9.Text = "V";
			buButton_10.Text = "F";
			buButton_11.Text = "R";
			buButton_12.Text = "B";
			buButton_13.Text = "G";
			buButton_14.Text = "T";
			buButton_15.Text = "N";
			buButton_16.Text = "H";
			buButton_17.Text = "Y";
			buButton_18.Text = "M";
			buButton_19.Text = "J";
			buButton_20.Text = "U";
			buButton_21.Text = "Ö";
			buButton_22.Text = "K";
			buButton_23.Text = "I";
			buButton_24.Text = "Ç";
			buButton_25.Text = "L";
			buButton_26.Text = "O";
			buButton_28.Text = "Ş";
			buButton_29.Text = "P";
			buButton_30.Text = "İ";
			buButton_31.Text = "Ğ";
			buButton_33.Text = "Ü";
		}
		else
		{
			buButton_0.Text = "q";
			buButton_1.Text = "a";
			buButton_2.Text = "z";
			buButton_3.Text = "x";
			buButton_4.Text = "s";
			buButton_5.Text = "w";
			buButton_6.Text = "c";
			buButton_7.Text = "d";
			buButton_8.Text = "e";
			buButton_9.Text = "v";
			buButton_10.Text = "f";
			buButton_11.Text = "r";
			buButton_12.Text = "b";
			buButton_13.Text = "g";
			buButton_14.Text = "t";
			buButton_15.Text = "n";
			buButton_16.Text = "h";
			buButton_17.Text = "y";
			buButton_18.Text = "m";
			buButton_19.Text = "j";
			buButton_20.Text = "u";
			buButton_21.Text = "ö";
			buButton_22.Text = "k";
			buButton_23.Text = "ı";
			buButton_24.Text = "ç";
			buButton_25.Text = "l";
			buButton_26.Text = "o";
			buButton_28.Text = "ş";
			buButton_29.Text = "p";
			buButton_30.Text = "i";
			buButton_31.Text = "ğ";
			buButton_33.Text = "ü";
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
