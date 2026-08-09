using System;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.KeyPad;

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

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal buTextBox buTextBox_0;

	internal Button button_15;

	public F_KeyPadAlpha()
	{
		Class76.smethod_688(this);
	}

	public void ShowDialog(string Value)
	{
		bool_0 = false;
		string_0 = Value;
		buTextBox_0.Text = Value;
		buTextBox_0.Invalidate();
		buTextBox_0.Display.SelectionColor = buTextBox_0.Display.BackColor;
		buTextBox_0.PasswordChar = PasswordChar;
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
		buTextBox_0.Text = Value;
		buTextBox_0.Display.SelectionColor = buTextBox_0.BackColor;
		buTextBox_0.PasswordChar = PasswordChar;
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
		if (buTextBox_0.txt.SelectedText.Length > 0 && ((buButton)sender).Tag.ToString() != "enter")
		{
			buTextBox_0.txt.Text = "";
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
										buTextBox_0.Text += "z";
									}
									else
									{
										buTextBox_0.Text += "Z";
									}
								}
							}
							else if (num == 4160372143u && text2 == "minus")
							{
								if (buTextBox_0.Text.Length <= 0)
								{
									buTextBox_0.Text = "-";
								}
								else if (!(buTextBox_0.Text.Substring(0, 1) != "-"))
								{
									buTextBox_0.Text = buTextBox_0.Text.Replace("-", "");
								}
								else
								{
									buTextBox_0.Text = buTextBox_0.Text.Insert(0, "-");
								}
							}
						}
						else if (num == 3708558887u)
						{
							if (text2 == "X")
							{
								if (!Caps)
								{
									buTextBox_0.Text += "x";
								}
								else
								{
									buTextBox_0.Text += "X";
								}
							}
						}
						else if (num == 3724402957u && text2 == "enter")
						{
							if (CheckNumeric)
							{
								if (!buNumeric.IsNumeric(buTextBox_0.Text))
								{
									string_1 = buTextBox_0.Text;
									buTextBox_0.Text = "None numerical!!";
									timer_0.Enabled = true;
								}
								else
								{
									Value = buTextBox_0.Text;
									Dispose();
								}
							}
							else
							{
								Value = buTextBox_0.Text;
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
								buTextBox_0.Text += "_";
							}
							else
							{
								buTextBox_0.Text += "_";
							}
						}
					}
					else if (num == 3674900481u)
					{
						if (text2 == "Ş")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "ş";
							}
							else
							{
								buTextBox_0.Text += "Ş";
							}
						}
					}
					else if (num == 3691781268u && text2 == "Y")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "y";
						}
						else
						{
							buTextBox_0.Text += "Y";
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
								buTextBox_0.Text += "p";
							}
							else
							{
								buTextBox_0.Text += "P";
							}
						}
					}
					else if (num == 3591115554u)
					{
						if (text2 == "S")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "s";
							}
							else
							{
								buTextBox_0.Text += "S";
							}
						}
					}
					else if (num == 3607893173u && text2 == "R")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "r";
						}
						else
						{
							buTextBox_0.Text += "R";
						}
					}
				}
				else if (num == 3524005078u)
				{
					if (text2 == "W")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "w";
						}
						else
						{
							buTextBox_0.Text += "W";
						}
					}
				}
				else if (num == 3540782697u)
				{
					if (text2 == "V")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "v";
						}
						else
						{
							buTextBox_0.Text += "V";
						}
					}
				}
				else if (num == 3557560316u && text2 == "Q")
				{
					if (!Caps)
					{
						buTextBox_0.Text += "q";
					}
					else
					{
						buTextBox_0.Text += "Q";
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
									buTextBox_0.Text += "u";
								}
								else
								{
									buTextBox_0.Text += "U";
								}
							}
						}
						else if (num == 3507227459u && text2 == "T")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "t";
							}
							else
							{
								buTextBox_0.Text += "T";
							}
						}
					}
					else if (num == 3456894602u)
					{
						if (text2 == "K")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "k";
							}
							else
							{
								buTextBox_0.Text += "K";
							}
						}
					}
					else if (num == 3473672221u && text2 == "J")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "j";
						}
						else
						{
							buTextBox_0.Text += "J";
						}
					}
				}
				else if (num == 3406561745u)
				{
					if (text2 == "N")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "n";
						}
						else
						{
							buTextBox_0.Text += "N";
						}
					}
				}
				else if (num == 3423339364u)
				{
					if (text2 == "I")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "ı";
						}
						else
						{
							buTextBox_0.Text += "I";
						}
					}
				}
				else if (num == 3440116983u && text2 == "H")
				{
					if (!Caps)
					{
						buTextBox_0.Text += "h";
					}
					else
					{
						buTextBox_0.Text += "H";
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
							buTextBox_0.Text += "m";
						}
						else
						{
							buTextBox_0.Text += "M";
						}
					}
				}
				else if (num == 3373006507u)
				{
					if (text2 == "L")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "l";
						}
						else
						{
							buTextBox_0.Text += "L";
						}
					}
				}
				else if (num == 3389784126u && text2 == "O")
				{
					if (!Caps)
					{
						buTextBox_0.Text += "o";
					}
					else
					{
						buTextBox_0.Text += "O";
					}
				}
			}
			else if (num == 3289118412u)
			{
				if (text2 == "A")
				{
					if (!Caps)
					{
						buTextBox_0.Text += "a";
					}
					else
					{
						buTextBox_0.Text += "A";
					}
				}
			}
			else if (num == 3322673650u)
			{
				if (text2 == "C")
				{
					if (!Caps)
					{
						buTextBox_0.Text += "c";
					}
					else
					{
						buTextBox_0.Text += "C";
					}
				}
			}
			else if (num == 3339451269u && text2 == "B")
			{
				if (!Caps)
				{
					buTextBox_0.Text += "b";
				}
				else
				{
					buTextBox_0.Text += "B";
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
									buTextBox_0.Text += "g";
								}
								else
								{
									buTextBox_0.Text += "G";
								}
							}
						}
						else if (num == 3272340793u && text2 == "F")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "f";
							}
							else
							{
								buTextBox_0.Text += "F";
							}
						}
					}
					else if (num == 3238785555u)
					{
						if (text2 == "D")
						{
							if (!Caps)
							{
								buTextBox_0.Text += "d";
							}
							else
							{
								buTextBox_0.Text += "D";
							}
						}
					}
					else if (num == 3250860581u && text2 == "Space")
					{
						if (!Caps)
						{
							buTextBox_0.Text += " ";
						}
						else
						{
							buTextBox_0.Text += " ";
						}
					}
				}
				else if (num == 1550717474)
				{
					if (text2 == "clear")
					{
						buTextBox_0.Text = "";
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
						buTextBox_0.Text += "e";
					}
					else
					{
						buTextBox_0.Text += "E";
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
							buTextBox_0.Text += "ö";
						}
						else
						{
							buTextBox_0.Text += "Ö";
						}
					}
				}
				else if (num == 1493913179)
				{
					if (text2 == "Ü")
					{
						if (!Caps)
						{
							buTextBox_0.Text += "ü";
						}
						else
						{
							buTextBox_0.Text += "Ü";
						}
					}
				}
				else if (num == 1538531746 && text2 == "back" && buTextBox_0.Text.Length > 0)
				{
					buTextBox_0.Text = buTextBox_0.Text.Substring(0, buTextBox_0.Text.Length - 1);
				}
			}
			else if (num == 1007465396)
			{
				if (text2 == "9")
				{
					buTextBox_0.Text += "9";
				}
			}
			else if (num == 1024243015)
			{
				if (text2 == "8")
				{
					buTextBox_0.Text += "8";
				}
			}
			else if (num == 1108027942 && text2 == "Ç")
			{
				if (!Caps)
				{
					buTextBox_0.Text += "ç";
				}
				else
				{
					buTextBox_0.Text += "Ç";
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
						buTextBox_0.Text += "0";
					}
				}
				else if (num == 906799682)
				{
					if (text2 == "3")
					{
						buTextBox_0.Text += "3";
					}
				}
				else if (num == 923577301 && text2 == "2")
				{
					buTextBox_0.Text += "2";
				}
			}
			else if (num == 856466825)
			{
				if (text2 == "6")
				{
					buTextBox_0.Text += "6";
				}
			}
			else if (num == 873244444)
			{
				if (text2 == "1")
				{
					buTextBox_0.Text += "1";
				}
			}
			else if (num == 889918895 && text2 == "İ")
			{
				if (!Caps)
				{
					buTextBox_0.Text += "i";
				}
				else
				{
					buTextBox_0.Text += "İ";
				}
			}
		}
		else if (num > 722245873)
		{
			if (num == 806133968)
			{
				if (text2 == "5")
				{
					buTextBox_0.Text += "5";
				}
			}
			else if (num == 822911587)
			{
				if (text2 == "4")
				{
					buTextBox_0.Text += "4";
				}
			}
			else if (num == 839689206 && text2 == "7")
			{
				buTextBox_0.Text += "7";
			}
		}
		else if (num == 453700801)
		{
			if (text2 == "Ğ")
			{
				if (!Caps)
				{
					buTextBox_0.Text += "ğ";
				}
				else
				{
					buTextBox_0.Text += "Ğ";
				}
			}
		}
		else if (num == 671913016)
		{
			if (text2 == "-")
			{
				if (!Caps)
				{
					buTextBox_0.Text += "-";
				}
				else
				{
					buTextBox_0.Text += "-";
				}
			}
		}
		else if (num == 722245873 && text2 == "." && buTextBox_0.Text.IndexOf(".") < 0)
		{
			buTextBox_0.Text += ".";
		}
		buTextBox_0.txt.SelectionStart = buTextBox_0.txt.Text.Length;
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		buTextBox_0.SelectAll();
		bool_0 = true;
		timer_2.Enabled = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		buTextBox_0.Text = string_1;
		timer_0.Enabled = false;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		buTextBox_0.Text = "";
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
			method_0(button_14, null);
		}
		if (e.KeyCode == Keys.Return)
		{
			method_0(button_8, null);
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
