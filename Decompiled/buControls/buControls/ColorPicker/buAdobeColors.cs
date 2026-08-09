using System.Drawing;
using ns27;

namespace buControls.ColorPicker;

public class buAdobeColors
{
	public class HSL
	{
		private double double_0;

		private double double_1;

		private double double_2;

		public double H
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
				double_0 = ((!(double_0 <= 1.0)) ? 1.0 : ((double_0 >= 0.0) ? double_0 : 0.0));
			}
		}

		public double S
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
				double_1 = ((!(double_1 <= 1.0)) ? 1.0 : ((double_1 >= 0.0) ? double_1 : 0.0));
			}
		}

		public double L
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
				double_2 = ((!(double_2 <= 1.0)) ? 1.0 : ((double_2 >= 0.0) ? double_2 : 0.0));
			}
		}

		public HSL()
		{
			double_0 = 0.0;
			double_1 = 0.0;
			double_2 = 0.0;
		}
	}

	public class CMYK
	{
		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		public double C
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
				double_0 = ((!(double_0 <= 1.0)) ? 1.0 : ((double_0 >= 0.0) ? double_0 : 0.0));
			}
		}

		public double M
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
				double_1 = ((!(double_1 <= 1.0)) ? 1.0 : ((double_1 >= 0.0) ? double_1 : 0.0));
			}
		}

		public double Y
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
				double_2 = ((!(double_2 <= 1.0)) ? 1.0 : ((double_2 >= 0.0) ? double_2 : 0.0));
			}
		}

		public double K
		{
			get
			{
				return double_3;
			}
			set
			{
				double_3 = value;
				double_3 = ((!(double_3 <= 1.0)) ? 1.0 : ((double_3 >= 0.0) ? double_3 : 0.0));
			}
		}

		public CMYK()
		{
			double_0 = 0.0;
			double_1 = 0.0;
			double_2 = 0.0;
			double_3 = 0.0;
		}
	}

	public static Color SetBrightness(Color c, double brightness)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.L = brightness;
		return HSL_to_RGB(hSL);
	}

	public static Color ModifyBrightness(Color c, double brightness)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.L *= brightness;
		return HSL_to_RGB(hSL);
	}

	public static Color SetSaturation(Color c, double Saturation)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.S = Saturation;
		return HSL_to_RGB(hSL);
	}

	public static Color ModifySaturation(Color c, double Saturation)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.S *= Saturation;
		return HSL_to_RGB(hSL);
	}

	public static Color SetHue(Color c, double Hue)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.H = Hue;
		return HSL_to_RGB(hSL);
	}

	public static Color ModifyHue(Color c, double Hue)
	{
		HSL hSL = RGB_to_HSL(c);
		hSL.H *= Hue;
		return HSL_to_RGB(hSL);
	}

	public static Color HSL_to_RGB(HSL hsl)
	{
		int num = Class76.smethod_664(hsl.L * 255.0);
		int num2 = Class76.smethod_664((1.0 - hsl.S) * (hsl.L / 1.0) * 255.0);
		double num3 = (double)(num - num2) / 255.0;
		int blue;
		if (hsl.H < 0.0 || !(hsl.H <= 1.0 / 6.0))
		{
			if (!(hsl.H <= 1.0 / 3.0))
			{
				if (!(hsl.H <= 0.5))
				{
					if (!(hsl.H <= 2.0 / 3.0))
					{
						if (!(hsl.H <= 5.0 / 6.0))
						{
							if (!(hsl.H <= 1.0))
							{
								return Color.FromArgb(0, 0, 0);
							}
							blue = Class76.smethod_664((0.0 - (hsl.H - 5.0 / 6.0) * num3) * 1530.0 + (double)num);
							return Color.FromArgb(num, num2, blue);
						}
						blue = Class76.smethod_664((hsl.H - 2.0 / 3.0) * num3 * 1530.0 + (double)num2);
						return Color.FromArgb(blue, num2, num);
					}
					blue = Class76.smethod_664((0.0 - (hsl.H - 0.5) * num3) * 1530.0 + (double)num);
					return Color.FromArgb(num2, blue, num);
				}
				blue = Class76.smethod_664((hsl.H - 1.0 / 3.0) * num3 * 1530.0 + (double)num2);
				return Color.FromArgb(num2, num, blue);
			}
			blue = Class76.smethod_664((0.0 - (hsl.H - 1.0 / 6.0) * num3) * 1530.0 + (double)num);
			return Color.FromArgb(blue, num, num2);
		}
		blue = Class76.smethod_664((hsl.H - 0.0) * num3 * 1530.0 + (double)num2);
		return Color.FromArgb(num, blue, num2);
	}

	public static HSL RGB_to_HSL(Color c)
	{
		HSL hSL = new HSL();
		int num;
		int num2;
		if (c.R <= c.G)
		{
			num = c.G;
			num2 = c.R;
		}
		else
		{
			num = c.R;
			num2 = c.G;
		}
		if (c.B <= num)
		{
			if (c.B < num2)
			{
				num2 = c.B;
			}
		}
		else
		{
			num = c.B;
		}
		int num3 = num - num2;
		hSL.L = (double)num / 255.0;
		if (num != 0)
		{
			hSL.S = (double)num3 / (double)num;
		}
		else
		{
			hSL.S = 0.0;
		}
		double num4 = ((num3 == 0) ? 0.0 : (60.0 / (double)num3));
		if (num != c.R)
		{
			if (num != c.G)
			{
				if (num != c.B)
				{
					hSL.H = 0.0;
				}
				else
				{
					hSL.H = (240.0 + num4 * (double)(c.R - c.G)) / 360.0;
				}
			}
			else
			{
				hSL.H = (120.0 + num4 * (double)(c.B - c.R)) / 360.0;
			}
		}
		else if (c.G >= c.B)
		{
			hSL.H = num4 * (double)(c.G - c.B) / 360.0;
		}
		else
		{
			hSL.H = (360.0 + num4 * (double)(c.G - c.B)) / 360.0;
		}
		return hSL;
	}

	public static CMYK RGB_to_CMYK(Color c)
	{
		CMYK cMYK = new CMYK();
		double num = 1.0;
		cMYK.C = (double)(255 - c.R) / 255.0;
		if (num > cMYK.C)
		{
			num = cMYK.C;
		}
		cMYK.M = (double)(255 - c.G) / 255.0;
		if (num > cMYK.M)
		{
			num = cMYK.M;
		}
		cMYK.Y = (double)(255 - c.B) / 255.0;
		if (num > cMYK.Y)
		{
			num = cMYK.Y;
		}
		if (num > 0.0)
		{
			cMYK.K = num;
		}
		return cMYK;
	}

	public static Color CMYK_to_RGB(CMYK _cmyk)
	{
		int red = Class76.smethod_664(255.0 - 255.0 * _cmyk.C);
		int green = Class76.smethod_664(255.0 - 255.0 * _cmyk.M);
		int blue = Class76.smethod_664(255.0 - 255.0 * _cmyk.Y);
		return Color.FromArgb(red, green, blue);
	}
}
