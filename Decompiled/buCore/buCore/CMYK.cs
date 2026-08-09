using System.Drawing;

namespace buCore;

public class CMYK
{
	public double C = 0.0;

	public double M = 0.0;

	public double Y = 0.0;

	public double K = 0.0;

	public static CMYK RGBtoCMYK(Color c)
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

	public static Color CMYKtoRGB(CMYK _cmyk)
	{
		int red = Round(255.0 - 255.0 * _cmyk.C);
		int green = Round(255.0 - 255.0 * _cmyk.M);
		int blue = Round(255.0 - 255.0 * _cmyk.Y);
		return Color.FromArgb(red, green, blue);
	}

	public static int Round(double val)
	{
		int num = (int)val;
		int num2 = (int)(val * 100.0);
		if (num2 % 100 >= 50)
		{
			num++;
		}
		return num;
	}
}
