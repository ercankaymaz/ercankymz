using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.ColorPicker;

public class buColorPicker : UserControl
{
	private Color color_0 = Color.Black;

	[CompilerGenerated]
	private colorChangedEventHandler colorChangedEventHandler_0;

	private buAdobeColors.HSL hsl_0;

	private Color color_1;

	private buAdobeColors.CMYK cmyk_0;

	private IContainer icontainer_0 = null;

	internal buColorVerticalSlider buColorVerticalSlider_0;

	internal buColorBox buColorBox_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal TextBox textBox_2;

	internal TextBox textBox_3;

	internal TextBox textBox_4;

	internal TextBox textBox_5;

	internal TextBox textBox_6;

	internal TextBox textBox_7;

	internal buColorComboBox buColorComboBox_0;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal PictureBox pictureBox_4;

	internal PictureBox pictureBox_5;

	internal PictureBox pictureBox_6;

	internal PictureBox pictureBox_7;

	internal PictureBox pictureBox_8;

	internal PictureBox pictureBox_9;

	internal PictureBox pictureBox_10;

	internal PictureBox pictureBox_11;

	internal PictureBox pictureBox_12;

	internal PictureBox pictureBox_13;

	internal PictureBox pictureBox_14;

	internal PictureBox pictureBox_15;

	internal PictureBox pictureBox_16;

	internal PictureBox pictureBox_17;

	internal PictureBox pictureBox_18;

	internal PictureBox pictureBox_19;

	internal PictureBox pictureBox_20;

	internal PictureBox pictureBox_21;

	internal PictureBox pictureBox_22;

	internal PictureBox pictureBox_23;

	internal PictureBox pictureBox_24;

	internal PictureBox pictureBox_25;

	internal PictureBox pictureBox_26;

	internal PictureBox pictureBox_27;

	internal PictureBox pictureBox_28;

	internal PictureBox pictureBox_29;

	internal PictureBox pictureBox_30;

	internal PictureBox pictureBox_31;

	internal PictureBox pictureBox_32;

	internal PictureBox pictureBox_33;

	internal PictureBox pictureBox_34;

	internal PictureBox pictureBox_35;

	internal PictureBox pictureBox_36;

	internal PictureBox pictureBox_37;

	internal PictureBox pictureBox_38;

	internal PictureBox pictureBox_39;

	internal PictureBox pictureBox_40;

	internal PictureBox pictureBox_41;

	internal PictureBox pictureBox_42;

	internal PictureBox pictureBox_43;

	internal PictureBox pictureBox_44;

	internal PictureBox pictureBox_45;

	internal PictureBox pictureBox_46;

	internal PictureBox pictureBox_47;

	internal Label label_5;

	internal Label label_6;

	[Category("Appearance")]
	[DefaultValue(typeof(Color), "0, 0, 0")]
	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			buColorComboBox_0.Color = color_0;
			method_13(color_0);
			label_5.BackColor = color_0;
			label_6.BackColor = color_0;
		}
	}

	public event colorChangedEventHandler ColorChanged
	{
		[CompilerGenerated]
		add
		{
			colorChangedEventHandler colorChangedEventHandler2 = colorChangedEventHandler_0;
			colorChangedEventHandler colorChangedEventHandler3;
			do
			{
				colorChangedEventHandler3 = colorChangedEventHandler2;
				colorChangedEventHandler value2 = (colorChangedEventHandler)Delegate.Combine(colorChangedEventHandler3, value);
				colorChangedEventHandler2 = Interlocked.CompareExchange(ref colorChangedEventHandler_0, value2, colorChangedEventHandler3);
			}
			while ((object)colorChangedEventHandler2 != colorChangedEventHandler3);
		}
		[CompilerGenerated]
		remove
		{
			colorChangedEventHandler colorChangedEventHandler2 = colorChangedEventHandler_0;
			colorChangedEventHandler colorChangedEventHandler3;
			do
			{
				colorChangedEventHandler3 = colorChangedEventHandler2;
				colorChangedEventHandler value2 = (colorChangedEventHandler)Delegate.Remove(colorChangedEventHandler3, value);
				colorChangedEventHandler2 = Interlocked.CompareExchange(ref colorChangedEventHandler_0, value2, colorChangedEventHandler3);
			}
			while ((object)colorChangedEventHandler2 != colorChangedEventHandler3);
		}
	}

	public buColorPicker()
	{
		Class76.smethod_653(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		hsl_0 = buColorBox_0.HSL;
		color_1 = buAdobeColors.HSL_to_RGB(hsl_0);
		cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
		textBox_7.Text = color_1.R.ToString();
		textBox_6.Text = color_1.G.ToString();
		textBox_5.Text = color_1.B.ToString();
		textBox_4.Text = Class76.smethod_530(cmyk_0.C * 100.0, this).ToString();
		textBox_3.Text = Class76.smethod_530(cmyk_0.M * 100.0, this).ToString();
		textBox_2.Text = Class76.smethod_530(cmyk_0.Y * 100.0, this).ToString();
		textBox_1.Text = Class76.smethod_530(cmyk_0.K * 100.0, this).ToString();
		textBox_7.Update();
		textBox_6.Update();
		textBox_5.Update();
		textBox_4.Update();
		textBox_3.Update();
		textBox_2.Update();
		textBox_1.Update();
		buColorVerticalSlider_0.HSL = hsl_0;
		label_5.BackColor = color_1;
		label_5.Update();
		Class76.smethod_576(this, color_1);
		if (colorChangedEventHandler_0 != null)
		{
			colorChangedEventHandler_0(this, color_1);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		hsl_0 = buColorVerticalSlider_0.HSL;
		color_1 = buAdobeColors.HSL_to_RGB(hsl_0);
		cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
		textBox_7.Text = color_1.R.ToString();
		textBox_6.Text = color_1.G.ToString();
		textBox_5.Text = color_1.B.ToString();
		textBox_4.Text = Class76.smethod_530(cmyk_0.C * 100.0, this).ToString();
		textBox_3.Text = Class76.smethod_530(cmyk_0.M * 100.0, this).ToString();
		textBox_2.Text = Class76.smethod_530(cmyk_0.Y * 100.0, this).ToString();
		textBox_1.Text = Class76.smethod_530(cmyk_0.K * 100.0, this).ToString();
		textBox_7.Update();
		textBox_6.Update();
		textBox_5.Update();
		textBox_4.Update();
		textBox_3.Update();
		textBox_2.Update();
		textBox_1.Update();
		buColorBox_0.HSL = hsl_0;
		label_5.BackColor = color_1;
		label_5.Update();
		Class76.smethod_576(this, color_1);
		if (colorChangedEventHandler_0 != null)
		{
			colorChangedEventHandler_0(this, color_1);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (radioButton_2.Checked)
		{
			buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Red;
			buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Red;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (radioButton_1.Checked)
		{
			buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Green;
			buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Green;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (radioButton_0.Checked)
		{
			buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Blue;
			buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Blue;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		string text = textBox_7.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 255)
				{
					color_1 = Color.FromArgb(num, color_1.G, color_1.B);
				}
				else
				{
					MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
					color_1 = Color.FromArgb(255, color_1.G, color_1.B);
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				color_1 = Color.FromArgb(0, color_1.G, color_1.B);
			}
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Red must be a number value between 0 and 255");
			method_14();
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		string text = textBox_6.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 255)
				{
					color_1 = Color.FromArgb(color_1.R, num, color_1.B);
				}
				else
				{
					MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
					textBox_6.Text = "255";
					color_1 = Color.FromArgb(color_1.R, 255, color_1.B);
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				textBox_6.Text = "0";
				color_1 = Color.FromArgb(color_1.R, 0, color_1.B);
			}
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Green must be a number value between 0 and 255");
			method_14();
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		string text = textBox_5.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 255)
				{
					color_1 = Color.FromArgb(color_1.R, color_1.G, num);
				}
				else
				{
					MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
					textBox_5.Text = "255";
					color_1 = Color.FromArgb(color_1.R, color_1.G, 255);
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				textBox_5.Text = "0";
				color_1 = Color.FromArgb(color_1.R, color_1.G, 0);
			}
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Blue must be a number value between 0 and 255");
			method_14();
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		string text = textBox_0.Text.ToUpper();
		bool flag = false;
		if (text.Length <= 0)
		{
			flag = true;
		}
		string text2 = text;
		foreach (char c in text2)
		{
			if (!char.IsNumber(c) && (c < 'A' || c > 'F'))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			color_1 = Class76.smethod_561(this, text);
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Hex must be a hex value between 0x000000 and 0xFFFFFF");
			Class76.smethod_576(this, color_1);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		string text = textBox_4.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 100)
				{
					cmyk_0.C = (double)num / 100.0;
				}
				else
				{
					MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
					cmyk_0.C = 1.0;
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				cmyk_0.C = 0.0;
			}
			color_1 = buAdobeColors.CMYK_to_RGB(cmyk_0);
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Cyan must be a number value between 0 and 100");
			method_14();
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
		string text = textBox_3.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 100)
				{
					cmyk_0.M = (double)num / 100.0;
				}
				else
				{
					MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
					textBox_3.Text = "100";
					cmyk_0.M = 1.0;
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				textBox_3.Text = "0";
				cmyk_0.M = 0.0;
			}
			color_1 = buAdobeColors.CMYK_to_RGB(cmyk_0);
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Magenta must be a number value between 0 and 100");
			method_14();
		}
	}

	internal void method_11(object sender, EventArgs e)
	{
		string text = textBox_2.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 100)
				{
					cmyk_0.Y = (double)num / 100.0;
				}
				else
				{
					MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
					textBox_2.Text = "100";
					cmyk_0.Y = 1.0;
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				textBox_2.Text = "0";
				cmyk_0.Y = 0.0;
			}
			color_1 = buAdobeColors.CMYK_to_RGB(cmyk_0);
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Yellow must be a number value between 0 and 100");
			method_14();
		}
	}

	internal void method_12(object sender, EventArgs e)
	{
		string text = textBox_1.Text;
		bool flag = false;
		if (text.Length > 0)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				if (!char.IsNumber(c))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			int num = int.Parse(text);
			if (num >= 0)
			{
				if (num <= 100)
				{
					cmyk_0.K = (double)num / 100.0;
				}
				else
				{
					MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
					textBox_1.Text = "100";
					cmyk_0.K = 1.0;
				}
			}
			else
			{
				MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				textBox_1.Text = "0";
				cmyk_0.K = 0.0;
			}
			color_1 = buAdobeColors.CMYK_to_RGB(cmyk_0);
			hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
			buColorBox_0.HSL = hsl_0;
			buColorVerticalSlider_0.HSL = hsl_0;
			label_5.BackColor = color_1;
			method_14();
		}
		else
		{
			MessageBox.Show("Key must be a number value between 0 and 100");
			method_14();
		}
	}

	private void method_13(Color color_2)
	{
		color_1 = color_2;
		hsl_0 = buAdobeColors.RGB_to_HSL(color_1);
		buColorBox_0.HSL = hsl_0;
		buColorVerticalSlider_0.HSL = hsl_0;
		cmyk_0 = buAdobeColors.RGB_to_CMYK(color_1);
		textBox_7.Text = color_1.R.ToString();
		textBox_6.Text = color_1.G.ToString();
		textBox_5.Text = color_1.B.ToString();
		textBox_4.Text = Class76.smethod_530(cmyk_0.C * 100.0, this).ToString();
		textBox_3.Text = Class76.smethod_530(cmyk_0.M * 100.0, this).ToString();
		textBox_2.Text = Class76.smethod_530(cmyk_0.Y * 100.0, this).ToString();
		textBox_1.Text = Class76.smethod_530(cmyk_0.K * 100.0, this).ToString();
		textBox_7.Update();
		textBox_6.Update();
		textBox_5.Update();
		textBox_4.Update();
		textBox_3.Update();
		textBox_2.Update();
		textBox_1.Update();
	}

	private void method_14()
	{
		textBox_4.Text = Class76.smethod_530(cmyk_0.C * 100.0, this).ToString();
		textBox_3.Text = Class76.smethod_530(cmyk_0.M * 100.0, this).ToString();
		textBox_2.Text = Class76.smethod_530(cmyk_0.Y * 100.0, this).ToString();
		textBox_1.Text = Class76.smethod_530(cmyk_0.K * 100.0, this).ToString();
		textBox_7.Text = color_1.R.ToString();
		textBox_6.Text = color_1.G.ToString();
		textBox_5.Text = color_1.B.ToString();
		textBox_7.Update();
		textBox_6.Update();
		textBox_5.Update();
		textBox_4.Update();
		textBox_3.Update();
		textBox_2.Update();
		textBox_1.Update();
		Class76.smethod_576(this, color_1);
	}

	internal void method_15(object sender, EventArgs e)
	{
		pictureBox_47.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_46.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_45.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_44.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_43.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_42.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_28.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_29.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_30.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_31.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_32.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_41.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_33.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_34.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_21.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_22.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_23.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_40.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_24.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_25.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_26.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_27.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_14.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_39.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_38.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_15.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_37.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_36.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_35.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_16.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_17.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_18.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_19.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_20.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_7.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_8.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_9.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_10.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_11.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_12.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_13.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_0.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_1.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_2.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_3.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_4.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_5.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_6.BorderStyle = BorderStyle.FixedSingle;
		PictureBox pictureBox = new PictureBox();
		pictureBox = (PictureBox)sender;
		pictureBox.BorderStyle = BorderStyle.Fixed3D;
		if (colorChangedEventHandler_0 != null)
		{
			if (pictureBox.BackColor.IsKnownColor)
			{
				buColorComboBox_0.Color = pictureBox.BackColor;
			}
			label_6.BackColor = pictureBox.BackColor;
			colorChangedEventHandler_0(this, pictureBox.BackColor);
		}
	}

	internal void method_16(object object_0, Color color_2)
	{
		if (colorChangedEventHandler_0 != null)
		{
			label_6.BackColor = color_2;
			colorChangedEventHandler_0(this, color_2);
		}
	}

	internal void method_17(object sender, EventArgs e)
	{
		if (colorChangedEventHandler_0 != null)
		{
			colorChangedEventHandler_0(this, label_5.BackColor);
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
