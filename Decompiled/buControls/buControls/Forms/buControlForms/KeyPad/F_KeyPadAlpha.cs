using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.KeyPad;

public class F_KeyPadAlpha : Form
{
	public bool Caps;

	public string Value;

	public bool CheckNumeric = true;

	public char PasswordChar;

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

	public buTextBox textCtrl1;

	public F_KeyPadAlpha()
	{
		Class76.smethod_588(this);
	}

	public void ShowDialog(string Value)
	{
		bool_0 = false;
		string_0 = Value;
		textCtrl1.Text = Value;
		textCtrl1.Invalidate();
		textCtrl1.Display.SelectionColor = textCtrl1.Display.BackColor;
		textCtrl1.PasswordChar = PasswordChar;
		timer_0 = new Timer();
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		timer_1 = new Timer();
		timer_1.Interval = 1500;
		timer_1.Tick += timer_1_Tick;
		ShowDialog();
	}

	public void ShowDialog(string Value, IWin32Window owner)
	{
		bool_0 = false;
		string_0 = Value;
		textCtrl1.Text = Value;
		textCtrl1.Display.SelectionColor = textCtrl1.BackColor;
		textCtrl1.PasswordChar = PasswordChar;
		timer_0 = new Timer();
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		timer_1 = new Timer();
		timer_1.Interval = 1500;
		timer_1.Tick += timer_1_Tick;
		timer_2 = new Timer();
		timer_2.Interval = 100;
		timer_2.Tick += timer_2_Tick;
		timer_2.Enabled = true;
		ShowDialog(owner);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			return;
		}
		if (textCtrl1.txt.SelectedText.Length > 0)
		{
			textCtrl1.txt.Text = "";
		}
		string text = ((buButton)sender).Tag.ToString();
		string text2 = text;
		uint num = Class76.smethod_599(text2);
		if (num > 1550717474)
		{
			if (num > 3507227459u)
			{
				if (num > 3658226030u)
				{
					if (num > 3724402957u)
					{
						if (num > 3742114125u)
						{
							if (num == 4161554600u)
							{
								if (text2 == "}")
								{
									if (!Caps)
									{
										textCtrl1.Text += "}";
									}
									else
									{
										textCtrl1.Text += "}";
									}
								}
							}
							else if (num == 4178332219u)
							{
								if (text2 == "|")
								{
									if (!Caps)
									{
										textCtrl1.Text += "|";
									}
									else
									{
										textCtrl1.Text += "|";
									}
								}
							}
							else if (num == 4262220314u && text2 == "{")
							{
								if (!Caps)
								{
									textCtrl1.Text += "{";
								}
								else
								{
									textCtrl1.Text += "{";
								}
							}
						}
						else if (num == 3725336506u)
						{
							if (text2 == "[")
							{
								if (!Caps)
								{
									textCtrl1.Text += "[";
								}
								else
								{
									textCtrl1.Text += "[";
								}
							}
						}
						else if (num == 3742114125u && text2 == "Z")
						{
							if (!Caps)
							{
								textCtrl1.Text += "z";
							}
							else
							{
								textCtrl1.Text += "Z";
							}
						}
					}
					else if (num > 3675003649u)
					{
						if (num == 3691781268u)
						{
							if (text2 == "Y")
							{
								if (!Caps)
								{
									textCtrl1.Text += "y";
								}
								else
								{
									textCtrl1.Text += "Y";
								}
							}
						}
						else if (num == 3708558887u)
						{
							if (text2 == "X")
							{
								if (!Caps)
								{
									textCtrl1.Text += "x";
								}
								else
								{
									textCtrl1.Text += "X";
								}
							}
						}
						else if (num == 3724402957u && text2 == "enter")
						{
							Value = textCtrl1.Text;
							Dispose();
						}
					}
					else if (num == 3674900481u)
					{
						if (text2 == "Ş")
						{
							if (!Caps)
							{
								textCtrl1.Text += "ş";
							}
							else
							{
								textCtrl1.Text += "Ş";
							}
						}
					}
					else if (num == 3675003649u && text2 == "^")
					{
						if (!Caps)
						{
							textCtrl1.Text += "^";
						}
						else
						{
							textCtrl1.Text += "^";
						}
					}
				}
				else if (num > 3574337935u)
				{
					if (num > 3607893173u)
					{
						if (num == 3624670792u)
						{
							if (text2 == "]")
							{
								if (!Caps)
								{
									textCtrl1.Text += "]";
								}
								else
								{
									textCtrl1.Text += "]";
								}
							}
						}
						else if (num == 3641448411u)
						{
							if (text2 == "\\")
							{
								if (!Caps)
								{
									textCtrl1.Text += "\\";
								}
								else
								{
									textCtrl1.Text += "\\";
								}
							}
						}
						else if (num == 3658226030u && text2 == "_")
						{
							if (!Caps)
							{
								textCtrl1.Text += "_";
							}
							else
							{
								textCtrl1.Text += "_";
							}
						}
					}
					else if (num == 3591115554u)
					{
						if (text2 == "S")
						{
							if (!Caps)
							{
								textCtrl1.Text += "s";
							}
							else
							{
								textCtrl1.Text += "S";
							}
						}
					}
					else if (num == 3607893173u && text2 == "R")
					{
						if (!Caps)
						{
							textCtrl1.Text += "r";
						}
						else
						{
							textCtrl1.Text += "R";
						}
					}
				}
				else if (num > 3540782697u)
				{
					if (num == 3557560316u)
					{
						if (text2 == "Q")
						{
							if (!Caps)
							{
								textCtrl1.Text += "q";
							}
							else
							{
								textCtrl1.Text += "Q";
							}
						}
					}
					else if (num == 3574337935u && text2 == "P")
					{
						if (!Caps)
						{
							textCtrl1.Text += "p";
						}
						else
						{
							textCtrl1.Text += "P";
						}
					}
				}
				else if (num == 3524005078u)
				{
					if (text2 == "W")
					{
						if (!Caps)
						{
							textCtrl1.Text += "w";
						}
						else
						{
							textCtrl1.Text += "W";
						}
					}
				}
				else if (num == 3540782697u && text2 == "V")
				{
					if (!Caps)
					{
						textCtrl1.Text += "v";
					}
					else
					{
						textCtrl1.Text += "V";
					}
				}
			}
			else if (num > 3339451269u)
			{
				if (num > 3423339364u)
				{
					if (num > 3456894602u)
					{
						if (num == 3473672221u)
						{
							if (text2 == "J")
							{
								if (!Caps)
								{
									textCtrl1.Text += "j";
								}
								else
								{
									textCtrl1.Text += "J";
								}
							}
						}
						else if (num == 3490449840u)
						{
							if (text2 == "U")
							{
								if (!Caps)
								{
									textCtrl1.Text += "u";
								}
								else
								{
									textCtrl1.Text += "U";
								}
							}
						}
						else if (num == 3507227459u && text2 == "T")
						{
							if (!Caps)
							{
								textCtrl1.Text += "t";
							}
							else
							{
								textCtrl1.Text += "T";
							}
						}
					}
					else if (num == 3440116983u)
					{
						if (text2 == "H")
						{
							if (!Caps)
							{
								textCtrl1.Text += "h";
							}
							else
							{
								textCtrl1.Text += "H";
							}
						}
					}
					else if (num == 3456894602u && text2 == "K")
					{
						if (!Caps)
						{
							textCtrl1.Text += "k";
						}
						else
						{
							textCtrl1.Text += "K";
						}
					}
				}
				else if (num > 3373006507u)
				{
					if (num == 3389784126u)
					{
						if (text2 == "O")
						{
							if (!Caps)
							{
								textCtrl1.Text += "o";
							}
							else
							{
								textCtrl1.Text += "O";
							}
						}
					}
					else if (num == 3406561745u)
					{
						if (text2 == "N")
						{
							if (!Caps)
							{
								textCtrl1.Text += "n";
							}
							else
							{
								textCtrl1.Text += "N";
							}
						}
					}
					else if (num == 3423339364u && text2 == "I")
					{
						if (!Caps)
						{
							textCtrl1.Text += "ı";
						}
						else
						{
							textCtrl1.Text += "I";
						}
					}
				}
				else if (num == 3356228888u)
				{
					if (text2 == "M")
					{
						if (!Caps)
						{
							textCtrl1.Text += "m";
						}
						else
						{
							textCtrl1.Text += "M";
						}
					}
				}
				else if (num == 3373006507u && text2 == "L")
				{
					if (!Caps)
					{
						textCtrl1.Text += "l";
					}
					else
					{
						textCtrl1.Text += "L";
					}
				}
			}
			else if (num > 3238785555u)
			{
				if (num > 3272340793u)
				{
					if (num == 3289118412u)
					{
						if (text2 == "A")
						{
							if (!Caps)
							{
								textCtrl1.Text += "a";
							}
							else
							{
								textCtrl1.Text += "A";
							}
						}
					}
					else if (num == 3322673650u)
					{
						if (text2 == "C")
						{
							if (!Caps)
							{
								textCtrl1.Text += "c";
							}
							else
							{
								textCtrl1.Text += "C";
							}
						}
					}
					else if (num == 3339451269u && text2 == "B")
					{
						if (!Caps)
						{
							textCtrl1.Text += "b";
						}
						else
						{
							textCtrl1.Text += "B";
						}
					}
				}
				else if (num == 3255563174u)
				{
					if (text2 == "G")
					{
						if (!Caps)
						{
							textCtrl1.Text += "g";
						}
						else
						{
							textCtrl1.Text += "G";
						}
					}
				}
				else if (num == 3272340793u && text2 == "F")
				{
					if (!Caps)
					{
						textCtrl1.Text += "f";
					}
					else
					{
						textCtrl1.Text += "F";
					}
				}
			}
			else if (num > 2770536920u)
			{
				if (num == 3222007936u)
				{
					if (text2 == "E")
					{
						if (!Caps)
						{
							textCtrl1.Text += "e";
						}
						else
						{
							textCtrl1.Text += "E";
						}
					}
				}
				else if (num == 3238785555u && text2 == "D")
				{
					if (!Caps)
					{
						textCtrl1.Text += "d";
					}
					else
					{
						textCtrl1.Text += "D";
					}
				}
			}
			else if (num == 1704568510)
			{
				if (text2 == "esc")
				{
					Value = string_0;
					Dispose();
				}
			}
			else if (num == 2770536920u && text2 == "caps")
			{
				if (Caps)
				{
					buButton_40.Display.BackColor = Color.LightGray;
					Caps = false;
				}
				else
				{
					buButton_40.Display.BackColor = Color.DarkOrange;
					Caps = true;
				}
			}
		}
		else if (num > 839689206)
		{
			if (num > 973910158)
			{
				if (num > 1057798253)
				{
					if (num > 1393247465)
					{
						if (num == 1493913179)
						{
							if (text2 == "Ü")
							{
								if (!Caps)
								{
									textCtrl1.Text += "ü";
								}
								else
								{
									textCtrl1.Text += "Ü";
								}
							}
						}
						else if (num == 1538531746)
						{
							if (text2 == "back" && textCtrl1.Text.Length > 0)
							{
								textCtrl1.Text = textCtrl1.Text.Substring(0, textCtrl1.Text.Length - 1);
							}
						}
						else if (num == 1550717474 && text2 == "clear")
						{
							textCtrl1.Text = "";
						}
					}
					else if (num == 1108027942)
					{
						if (text2 == "Ç")
						{
							if (!Caps)
							{
								textCtrl1.Text += "ç";
							}
							else
							{
								textCtrl1.Text += "Ç";
							}
						}
					}
					else if (num == 1393247465 && text2 == "Ö")
					{
						if (!Caps)
						{
							textCtrl1.Text += "ö";
						}
						else
						{
							textCtrl1.Text += "Ö";
						}
					}
				}
				else if (num > 1007465396)
				{
					if (num == 1024243015)
					{
						if (text2 == "8")
						{
							textCtrl1.Text += "8";
						}
					}
					else if (num == 1041020634)
					{
						if (text2 == ";")
						{
							if (!Caps)
							{
								textCtrl1.Text += ";";
							}
							else
							{
								textCtrl1.Text += ";";
							}
						}
					}
					else if (num == 1057798253 && text2 == ":")
					{
						if (!Caps)
						{
							textCtrl1.Text += ":";
						}
						else
						{
							textCtrl1.Text += ":";
						}
					}
				}
				else if (num == 990687777)
				{
					if (text2 == ">")
					{
						if (!Caps)
						{
							textCtrl1.Text += ">";
						}
						else
						{
							textCtrl1.Text += ">";
						}
					}
				}
				else if (num == 1007465396 && text2 == "9")
				{
					textCtrl1.Text += "9";
				}
			}
			else if (num > 890022063)
			{
				if (num > 923577301)
				{
					if (num == 940354920)
					{
						if (text2 == "=")
						{
							if (!Caps)
							{
								textCtrl1.Text += "=";
							}
							else
							{
								textCtrl1.Text += "=";
							}
						}
					}
					else if (num == 957132539)
					{
						if (text2 == "<")
						{
							if (!Caps)
							{
								textCtrl1.Text += "<";
							}
							else
							{
								textCtrl1.Text += "<";
							}
						}
					}
					else if (num == 973910158 && text2 == "?")
					{
						if (!Caps)
						{
							textCtrl1.Text += "?";
						}
						else
						{
							textCtrl1.Text += "?";
						}
					}
				}
				else if (num == 906799682)
				{
					if (text2 == "3")
					{
						textCtrl1.Text += "3";
					}
				}
				else if (num == 923577301 && text2 == "2")
				{
					textCtrl1.Text += "2";
				}
			}
			else if (num > 873244444)
			{
				if (num == 889918895)
				{
					if (text2 == "İ")
					{
						if (!Caps)
						{
							textCtrl1.Text += "i";
						}
						else
						{
							textCtrl1.Text += "İ";
						}
					}
				}
				else if (num == 890022063 && text2 == "0")
				{
					textCtrl1.Text += "0";
				}
			}
			else if (num == 856466825)
			{
				if (text2 == "6")
				{
					textCtrl1.Text += "6";
				}
			}
			else if (num == 873244444 && text2 == "1")
			{
				textCtrl1.Text += "1";
			}
		}
		else if (num > 671913016)
		{
			if (num > 755801111)
			{
				if (num > 789356349)
				{
					if (num == 806133968)
					{
						if (text2 == "5")
						{
							textCtrl1.Text += "5";
						}
					}
					else if (num == 822911587)
					{
						if (text2 == "4")
						{
							textCtrl1.Text += "4";
						}
					}
					else if (num == 839689206 && text2 == "7")
					{
						textCtrl1.Text += "7";
					}
				}
				else if (num == 772578730)
				{
					if (text2 == "+")
					{
						if (!Caps)
						{
							textCtrl1.Text += "+";
						}
						else
						{
							textCtrl1.Text += "+";
						}
					}
				}
				else if (num == 789356349 && text2 == "*")
				{
					if (!Caps)
					{
						textCtrl1.Text += "*";
					}
					else
					{
						textCtrl1.Text += "*";
					}
				}
			}
			else if (num > 722245873)
			{
				if (num == 739023492)
				{
					if (text2 == ")")
					{
						if (!Caps)
						{
							textCtrl1.Text += ")";
						}
						else
						{
							textCtrl1.Text += ")";
						}
					}
				}
				else if (num == 755801111 && text2 == "(")
				{
					if (!Caps)
					{
						textCtrl1.Text += "(";
					}
					else
					{
						textCtrl1.Text += "(";
					}
				}
			}
			else if (num == 705468254)
			{
				if (text2 == "/")
				{
					if (!Caps)
					{
						textCtrl1.Text += "/";
					}
					else
					{
						textCtrl1.Text += "/";
					}
				}
			}
			else if (num == 722245873 && text2 == ".")
			{
				textCtrl1.Text += ".";
			}
		}
		else if (num > 571247302)
		{
			if (num > 604802540)
			{
				if (num == 621580159)
				{
					if (text2 == " ")
					{
						if (!Caps)
						{
							textCtrl1.Text += " ";
						}
						else
						{
							textCtrl1.Text += " ";
						}
					}
				}
				else if (num == 638357778)
				{
					if (text2 == "#")
					{
						if (!Caps)
						{
							textCtrl1.Text += "#";
						}
						else
						{
							textCtrl1.Text += "#";
						}
					}
				}
				else if (num == 671913016 && text2 == "-")
				{
					if (!Caps)
					{
						textCtrl1.Text += "-";
					}
					else
					{
						textCtrl1.Text += "-";
					}
				}
			}
			else if (num == 588024921)
			{
				if (text2 == "&")
				{
					if (!Caps)
					{
						textCtrl1.Text += "&";
					}
					else
					{
						textCtrl1.Text += "&";
					}
				}
			}
			else if (num == 604802540 && text2 == "!")
			{
				if (!Caps)
				{
					textCtrl1.Text += "!";
				}
				else
				{
					textCtrl1.Text += "!";
				}
			}
		}
		else if (num > 537692064)
		{
			if (num == 554469683)
			{
				if (text2 == "$")
				{
					if (!Caps)
					{
						textCtrl1.Text += "$";
					}
					else
					{
						textCtrl1.Text += "$";
					}
				}
			}
			else if (num == 571247302 && text2 == "'")
			{
				if (!Caps)
				{
					textCtrl1.Text += "'";
				}
				else
				{
					textCtrl1.Text += "'";
				}
			}
		}
		else if (num == 453700801)
		{
			if (text2 == "Ğ")
			{
				if (!Caps)
				{
					textCtrl1.Text += "ğ";
				}
				else
				{
					textCtrl1.Text += "Ğ";
				}
			}
		}
		else if (num == 537692064 && text2 == "%")
		{
			if (!Caps)
			{
				textCtrl1.Text += "%";
			}
			else
			{
				textCtrl1.Text += "%";
			}
		}
		textCtrl1.txt.SelectionStart = textCtrl1.txt.Text.Length;
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
