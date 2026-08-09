using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ColorHSL : GlobalId
{
	private double _hue;

	private double _saturation;

	private double _luminance;

	public Color Color
	{
		get
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (Luminance > 0.0)
			{
				if (Saturation == 0.0)
				{
					num = (num2 = (num3 = Luminance));
				}
				else
				{
					double num4 = ((!(Luminance <= 0.5)) ? (Luminance + Saturation - Luminance * Saturation) : (Luminance * (1.0 + Saturation)));
					double num5 = 2.0 * Luminance - num4;
					double[] array = new double[3]
					{
						Hue + 1.0 / 3.0,
						Hue,
						Hue - 1.0 / 3.0
					};
					double[] array2 = new double[3];
					for (int i = 0; i < 3; i++)
					{
						if (array[i] < 0.0)
						{
							array[i] += 1.0;
						}
						if (array[i] > 1.0)
						{
							array[i] -= 1.0;
						}
						if (6.0 * array[i] < 1.0)
						{
							array2[i] = num5 + (num4 - num5) * array[i] * 6.0;
						}
						else if (2.0 * array[i] < 1.0)
						{
							array2[i] = num4;
						}
						else if (3.0 * array[i] < 2.0)
						{
							array2[i] = num5 + (num4 - num5) * (2.0 / 3.0 - array[i]) * 6.0;
						}
						else
						{
							array2[i] = num5;
						}
					}
					num = array2[0];
					num2 = array2[1];
					num3 = array2[2];
				}
			}
			return Color.FromArgb((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
		}
	}

	public double Hue
	{
		get
		{
			return _hue;
		}
		set
		{
			_hue = value;
			if (_hue > 1.0)
			{
				_hue = 1.0;
			}
			else if (_hue < 0.0)
			{
				_hue = 0.0;
			}
		}
	}

	public double Saturation
	{
		get
		{
			return _saturation;
		}
		set
		{
			_saturation = value;
			if (_saturation > 1.0)
			{
				_saturation = 1.0;
			}
			else if (_saturation < 0.0)
			{
				_saturation = 0.0;
			}
		}
	}

	public double Luminance
	{
		get
		{
			return _luminance;
		}
		set
		{
			_luminance = value;
			if (_luminance > 1.0)
			{
				_luminance = 1.0;
			}
			else if (_luminance < 0.0)
			{
				_luminance = 0.0;
			}
		}
	}

	public ColorHSL()
	{
	}

	public ColorHSL(Color c)
	{
		_hue = c.GetHue() / 360f;
		_saturation = c.GetBrightness();
		_luminance = c.GetSaturation();
	}
}
