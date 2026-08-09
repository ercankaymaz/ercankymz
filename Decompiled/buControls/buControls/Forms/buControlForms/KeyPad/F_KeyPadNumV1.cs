using System;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.KeyPad;

public class F_KeyPadNumV1 : Form
{
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

	public F_KeyPadNumV1()
	{
		Class76.smethod_39(this);
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
			string text = ((buButton)sender).Tag.ToString();
			string text2 = text;
			uint num = Class76.smethod_599(text2);
			if (num > 3272340793u)
			{
				if (num > 3507227459u)
				{
					if (num > 3607893173u)
					{
						if (num > 3691781268u)
						{
							if (num > 3724402957u)
							{
								if (num == 3742114125u)
								{
									if (text2 == "Z")
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
								else if (num == 4160372143u && text2 == "minus")
								{
									if (textCtrl1.Text.Length <= 0)
									{
										textCtrl1.Text = "-";
									}
									else if (!(textCtrl1.Text.Substring(0, 1) != "-"))
									{
										textCtrl1.Text = textCtrl1.Text.Replace("-", "");
									}
									else
									{
										textCtrl1.Text = textCtrl1.Text.Insert(0, "-");
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
								if (CheckNumeric)
								{
									if (!buNumeric.IsNumeric(textCtrl1.Text))
									{
										string_1 = textCtrl1.Text;
										textCtrl1.Text = "None numerical!!";
										timer_0.Enabled = true;
									}
									else
									{
										Value = textCtrl1.Text;
										Dispose();
									}
								}
								else
								{
									Value = textCtrl1.Text;
									Dispose();
								}
							}
						}
						else if (num == 3658226030u)
						{
							if (text2 == "_")
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
						else if (num == 3691781268u && text2 == "Y")
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
					else if (num > 3557560316u)
					{
						if (num == 3574337935u)
						{
							if (text2 == "P")
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
					else if (num == 3540782697u)
					{
						if (text2 == "V")
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
					else if (num == 3557560316u && text2 == "Q")
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
				else if (num > 3389784126u)
				{
					if (num > 3440116983u)
					{
						if (num > 3473672221u)
						{
							if (num == 3490449840u)
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
						else if (num == 3456894602u)
						{
							if (text2 == "K")
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
						else if (num == 3473672221u && text2 == "J")
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
					else if (num == 3423339364u)
					{
						if (text2 == "I")
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
					else if (num == 3440116983u && text2 == "H")
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
				else if (num > 3339451269u)
				{
					if (num == 3356228888u)
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
					else if (num == 3373006507u)
					{
						if (text2 == "L")
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
					else if (num == 3389784126u && text2 == "O")
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
				else if (num == 3289118412u)
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
			else if (num > 923577301)
			{
				if (num > 1538531746)
				{
					if (num > 3222007936u)
					{
						if (num > 3250860581u)
						{
							if (num == 3255563174u)
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
						else if (num == 3238785555u)
						{
							if (text2 == "D")
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
						else if (num == 3250860581u && text2 == "Space")
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
					else if (num == 1550717474)
					{
						if (text2 == "clear")
						{
							textCtrl1.Text = "";
						}
					}
					else if (num == 1704568510)
					{
						if (text2 == "esc")
						{
							Value = string_0;
							Close();
						}
					}
					else if (num == 3222007936u && text2 == "E")
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
				else if (num > 1108027942)
				{
					if (num == 1393247465)
					{
						if (text2 == "Ö")
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
					else if (num == 1493913179)
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
					else if (num == 1538531746 && text2 == "back" && textCtrl1.Text.Length > 0)
					{
						textCtrl1.Text = textCtrl1.Text.Substring(0, textCtrl1.Text.Length - 1);
					}
				}
				else if (num == 1007465396)
				{
					if (text2 == "9")
					{
						textCtrl1.Text += "9";
					}
				}
				else if (num == 1024243015)
				{
					if (text2 == "8")
					{
						textCtrl1.Text += "8";
					}
				}
				else if (num == 1108027942 && text2 == "Ç")
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
			else if (num > 839689206)
			{
				if (num > 889918895)
				{
					if (num == 890022063)
					{
						if (text2 == "0")
						{
							textCtrl1.Text += "0";
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
				else if (num == 856466825)
				{
					if (text2 == "6")
					{
						textCtrl1.Text += "6";
					}
				}
				else if (num == 873244444)
				{
					if (text2 == "1")
					{
						textCtrl1.Text += "1";
					}
				}
				else if (num == 889918895 && text2 == "İ")
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
			else if (num > 722245873)
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
			else if (num == 671913016)
			{
				if (text2 == "-")
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
			else if (num == 722245873 && text2 == "." && textCtrl1.Text.IndexOf(".") < 0)
			{
				textCtrl1.Text += ".";
			}
			textCtrl1.txt.SelectionStart = textCtrl1.txt.Text.Length;
		}
		else
		{
			Value = string_0;
			Close();
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
