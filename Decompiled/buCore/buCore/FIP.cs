using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ns54;

namespace buCore;

public class FIP
{
	public double[,] LPF1()
	{
		return new double[3, 3]
		{
			{ 0.1111, 0.1111, 0.1111 },
			{ 0.1111, 0.1111, 0.1111 },
			{ 0.1111, 0.1111, 0.1111 }
		};
	}

	public double[,] LPF2()
	{
		return new double[3, 3]
		{
			{ 0.1, 0.1, 0.1 },
			{ 0.1, 0.2, 0.1 },
			{ 0.1, 0.1, 0.1 }
		};
	}

	public double[,] LPF3()
	{
		return new double[3, 3]
		{
			{ 0.0625, 0.125, 0.0625 },
			{ 0.125, 0.25, 0.125 },
			{ 0.0625, 0.125, 0.0625 }
		};
	}

	public double[,] LPF4()
	{
		return new double[5, 5]
		{
			{ 0.00366, 0.01465, 0.02564, 0.01465, 0.00366 },
			{ 0.01465, 0.05861, 0.09524, 0.05861, 0.01465 },
			{ 0.02564, 0.09524, 0.15018, 0.09524, 0.02564 },
			{ 0.01465, 0.05861, 0.09524, 0.05861, 0.01465 },
			{ 0.00366, 0.01465, 0.02564, 0.01465, 0.00366 }
		};
	}

	public int[,] HPF1()
	{
		return new int[3, 3]
		{
			{ -1, -1, -1 },
			{ -1, 9, -1 },
			{ -1, -1, -1 }
		};
	}

	public int[,] HPF2()
	{
		return new int[3, 3]
		{
			{ 0, -1, 0 },
			{ -1, 5, -1 },
			{ 0, -1, 0 }
		};
	}

	public int[,] HPF3()
	{
		return new int[3, 3]
		{
			{ 1, -2, 1 },
			{ -2, 5, -2 },
			{ 1, -2, 1 }
		};
	}

	public int[,] HPF4()
	{
		return new int[5, 5]
		{
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, 25, -1, -1 },
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, -1 }
		};
	}

	public int[,] LaplaceF1()
	{
		return new int[3, 3]
		{
			{ -1, -1, -1 },
			{ -1, 8, -1 },
			{ -1, -1, -1 }
		};
	}

	public int[,] LaplaceF2()
	{
		return new int[3, 3]
		{
			{ 0, -1, 0 },
			{ -1, 4, -1 },
			{ 0, -1, 0 }
		};
	}

	public int[,] LaplaceF3()
	{
		return new int[3, 3]
		{
			{ 1, -2, 1 },
			{ -2, 4, -2 },
			{ 1, -2, 1 }
		};
	}

	public int[,] LaplaceF4()
	{
		return new int[5, 5]
		{
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, 24, -1, -1 },
			{ -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, -1 }
		};
	}

	public double[,] GF1()
	{
		return new double[3, 3]
		{
			{ 0.0625, 0.125, 0.0625 },
			{ 0.125, 0.25, 0.125 },
			{ 0.0625, 0.125, 0.0625 }
		};
	}

	public double[,] GF2()
	{
		return new double[5, 5]
		{
			{ 0.0192, 0.0192, 0.0385, 0.0192, 0.01921 },
			{ 0.0192, 0.0385, 0.0769, 0.0385, 0.0192 },
			{ 0.0385, 0.0769, 0.1538, 0.0769, 0.0385 },
			{ 0.0192, 0.0385, 0.0769, 0.0385, 0.0192 },
			{ 0.0192, 0.0192, 0.0385, 0.0192, 0.0192 }
		};
	}

	public double[,] GF3()
	{
		return new double[7, 7]
		{
			{ 0.00714, 0.00714, 0.01429, 0.01429, 0.01429, 0.00714, 0.00714 },
			{ 0.00714, 0.01429, 0.01429, 0.02857, 0.01429, 0.01429, 0.00714 },
			{ 0.01429, 0.01429, 0.02857, 0.05714, 0.02857, 0.01429, 0.01429 },
			{ 0.01429, 0.02857, 0.05714, 0.11429, 0.05714, 0.02857, 0.01429 },
			{ 0.01429, 0.01429, 0.02857, 0.05714, 0.02857, 0.01429, 0.01429 },
			{ 0.00714, 0.01429, 0.01429, 0.02857, 0.01429, 0.01429, 0.00714 },
			{ 0.00714, 0.00714, 0.01429, 0.01429, 0.01429, 0.00714, 0.00714 }
		};
	}

	public Bitmap Resize(Bitmap OriginalImage, int Width, int Height)
	{
		if (Width > 0 && Height > 0)
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			double num = Convert.ToDouble(OriginalImage.Width) / Convert.ToDouble(Width);
			double num2 = Convert.ToDouble(OriginalImage.Height) / Convert.ToDouble(Height);
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					int num3 = (int)((double)i * num);
					int num4 = (int)((double)j * num2);
					if (num3 >= OriginalImage.Width)
					{
						num3 = OriginalImage.Width - 1;
					}
					if (num4 >= OriginalImage.Height)
					{
						num4 = OriginalImage.Height - 1;
					}
					Color pixel = OriginalImage.GetPixel(num3, num4);
					bitmap.SetPixel(i, j, pixel);
				}
			}
			return bitmap;
		}
		throw new Exception("Output image width and height must be positive");
	}

	public Bitmap Resize2(Bitmap OriginalImage, int Width, int Height)
	{
		if (Width > 0 && Height > 0)
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			double num = Convert.ToDouble(OriginalImage.Width) / Convert.ToDouble(Width);
			double num2 = Convert.ToDouble(OriginalImage.Height) / Convert.ToDouble(Height);
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					int num3 = (int)((double)i * num);
					int num4 = (int)((double)j * num2);
					if (num3 >= OriginalImage.Width)
					{
						num3 = OriginalImage.Width - 1;
					}
					if (num4 >= OriginalImage.Height)
					{
						num4 = OriginalImage.Height - 1;
					}
					double num5 = (double)i * num % (double)num3;
					double num6 = (double)j * num2 % (double)num4;
					if (double.IsNaN(num5))
					{
						num5 = 0.0;
					}
					if (double.IsNaN(num6))
					{
						num6 = 0.0;
					}
					int num7 = num3 + 1;
					int num8 = num4 + 1;
					if (num7 >= OriginalImage.Width)
					{
						num7 = num3;
					}
					if (num8 >= OriginalImage.Height)
					{
						num8 = num4;
					}
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					Color pixel = OriginalImage.GetPixel(num3, num4);
					Color pixel2 = OriginalImage.GetPixel(num7, num4);
					Color pixel3 = OriginalImage.GetPixel(num3, num8);
					Color pixel4 = OriginalImage.GetPixel(num7, num8);
					double num12 = (1.0 - num5) * (double)(int)pixel.R + num5 * (double)(int)pixel2.R;
					double num13 = (1.0 - num5) * (double)(int)pixel3.R + num5 * (double)(int)pixel4.R;
					double num14 = (1.0 - num6) * num12 + num6 * num13;
					num9 = (int)num14;
					if (num9 > 255)
					{
						num9 = 255;
					}
					if (num9 < 0)
					{
						num9 = 0;
					}
					double num15 = (1.0 - num5) * (double)(int)pixel.G + num5 * (double)(int)pixel2.G;
					double num16 = (1.0 - num5) * (double)(int)pixel3.G + num5 * (double)(int)pixel4.G;
					double num17 = (1.0 - num6) * num15 + num6 * num16;
					num10 = (int)num17;
					if (num10 > 255)
					{
						num10 = 255;
					}
					if (num10 < 0)
					{
						num10 = 0;
					}
					double num18 = (1.0 - num5) * (double)(int)pixel.B + num5 * (double)(int)pixel2.B;
					double num19 = (1.0 - num5) * (double)(int)pixel3.B + num5 * (double)(int)pixel4.B;
					double num20 = (1.0 - num6) * num18 + num6 * num19;
					num11 = (int)num20;
					if (num11 > 255)
					{
						num11 = 255;
					}
					if (num11 < 0)
					{
						num11 = 0;
					}
					bitmap.SetPixel(i, j, Color.FromArgb(255, num9, num10, num11));
				}
			}
			return bitmap;
		}
		throw new Exception("Output image width and height must be positive");
	}

	public Bitmap Rotate(Bitmap OriginalImage, double Angle)
	{
		Angle %= 360.0;
		double num = OriginalImage.Width / 2;
		double num2 = OriginalImage.Height / 2;
		double num3 = Math.PI;
		double num4 = Angle * num3 / 180.0;
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				int num5 = (int)(Math.Cos(num4) * ((double)i - num) - Math.Sin(num4) * ((double)j - num2) + num);
				int num6 = (int)(Math.Sin(num4) * ((double)i - num) + Math.Cos(num4) * ((double)j - num2) + num2);
				Color color = default(Color);
				if (num5 >= 0 && num5 < OriginalImage.Width && num6 >= 0 && num6 < OriginalImage.Height)
				{
					color = OriginalImage.GetPixel(num5, num6);
					bitmap.SetPixel(i, j, color);
				}
			}
		}
		return bitmap;
	}

	public Bitmap Rotate(Bitmap OriginalImage, double Angle, int xCenter, int yCenter)
	{
		Angle %= 360.0;
		if (xCenter >= 0 && xCenter <= OriginalImage.Width && yCenter >= 0 && yCenter <= OriginalImage.Height)
		{
			double num = Convert.ToDouble(xCenter);
			double num2 = Convert.ToDouble(yCenter);
			double num3 = Math.PI;
			double num4 = Angle * num3 / 180.0;
			Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					int num5 = (int)(Math.Cos(num4) * ((double)i - num) - Math.Sin(num4) * ((double)j - num2) + num);
					int num6 = (int)(Math.Sin(num4) * ((double)i - num) + Math.Cos(num4) * ((double)j - num2) + num2);
					Color color = default(Color);
					if (num5 >= 0 && num5 < OriginalImage.Width && num6 >= 0 && num6 < OriginalImage.Height)
					{
						color = OriginalImage.GetPixel(num5, num6);
						bitmap.SetPixel(i, j, color);
					}
				}
			}
			return bitmap;
		}
		throw new Exception("The center of rotation point must be in range of image dimensions");
	}

	public double[] rgb2hsv(Color pixel)
	{
		double[] array = new double[3];
		double num = (int)Math.Min(Math.Min(pixel.R, pixel.G), pixel.B);
		double num2 = (int)Math.Max(Math.Max(pixel.R, pixel.G), pixel.B);
		double num3 = num2 - num;
		array[2] = 100.0 * num2 / 255.0;
		if (num2 != 0.0)
		{
			array[1] = num3 / num2;
		}
		else
		{
			array[1] = 0.0;
		}
		if (num3 != 0.0)
		{
			if ((int)num2 != pixel.R)
			{
				if ((int)num2 != pixel.G)
				{
					array[0] = 60.0 * (Convert.ToDouble(pixel.R - pixel.G) / num3 + 4.0);
				}
				else
				{
					array[0] = 60.0 * (Convert.ToDouble(pixel.B - pixel.R) / num3 + 2.0);
				}
			}
			else
			{
				array[0] = 60.0 * (Convert.ToDouble(pixel.G - pixel.B) / num3 % 6.0);
			}
		}
		else
		{
			array[0] = 0.0;
		}
		return array;
	}

	public Color hsv2rgb(double[] hsv)
	{
		Color color = default(Color);
		double num = hsv[1] / 100.0 * (hsv[2] / 100.0);
		double num2 = hsv[2] / 100.0 - num;
		double num3 = num * (1.0 - Math.Abs(hsv[0] / 60.0 % 2.0 - 1.0));
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		if (!(hsv[0] < 60.0))
		{
			if (!(hsv[0] < 120.0))
			{
				if (!(hsv[0] < 180.0))
				{
					if (!(hsv[0] < 240.0))
					{
						if (!(hsv[0] < 300.0))
						{
							if (hsv[0] < 360.0)
							{
								num4 = num;
								num5 = 0.0;
								num6 = num3;
							}
						}
						else
						{
							num4 = num3;
							num5 = 0.0;
							num6 = num;
						}
					}
					else
					{
						num4 = 0.0;
						num5 = num3;
						num6 = num;
					}
				}
				else
				{
					num4 = 0.0;
					num5 = num;
					num6 = num3;
				}
			}
			else
			{
				num4 = num3;
				num5 = num;
				num6 = 0.0;
			}
		}
		else
		{
			num4 = num;
			num5 = num3;
			num6 = 0.0;
		}
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		num7 = (int)((num4 + num2) * 255.0);
		num8 = (int)((num5 + num2) * 255.0);
		num9 = (int)((num6 + num2) * 255.0);
		if (num7 > 255)
		{
			num7 = 255;
		}
		if (num7 < 0)
		{
			num7 = 0;
		}
		if (num8 > 255)
		{
			num8 = 255;
		}
		if (num8 < 0)
		{
			num8 = 0;
		}
		if (num9 > 255)
		{
			num9 = 255;
		}
		if (num9 < 0)
		{
			num9 = 0;
		}
		return Color.FromArgb(255, num7, num8, num9);
	}

	public double[] rgb2cmyk(Color pixel)
	{
		double num = Convert.ToDouble(pixel.R) / 255.0;
		double num2 = Convert.ToDouble(pixel.G) / 255.0;
		double num3 = Convert.ToDouble(pixel.B) / 255.0;
		double num4 = 1.0 - Math.Max(Math.Max(num, num3), num2);
		double num5 = (1.0 - num - num4) / (1.0 - num4);
		double num6 = (1.0 - num2 - num4) / (1.0 - num4);
		double num7 = (1.0 - num3 - num4) / (1.0 - num4);
		return new double[4] { num5, num6, num7, num4 };
	}

	public Color cmyk2rgb(double[] cmyk)
	{
		Color color = default(Color);
		double num = 255.0 * (1.0 - cmyk[0]) * (1.0 - cmyk[3]);
		double num2 = 255.0 * (1.0 - cmyk[1]) * (1.0 - cmyk[3]);
		double num3 = 255.0 * (1.0 - cmyk[2]) * (1.0 - cmyk[3]);
		int num4 = (int)num;
		int num5 = (int)num2;
		int num6 = (int)num3;
		if (num4 > 255)
		{
			num4 = 255;
		}
		if (num4 < 0)
		{
			num4 = 0;
		}
		if (num5 > 255)
		{
			num5 = 255;
		}
		if (num5 < 0)
		{
			num5 = 0;
		}
		if (num6 > 255)
		{
			num6 = 255;
		}
		if (num6 < 0)
		{
			num6 = 0;
		}
		return Color.FromArgb(255, num4, num5, num6);
	}

	public Color color2greyscale(Color pixel)
	{
		int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
		return Color.FromArgb(255, num, num, num);
	}

	public Bitmap[] CMYKLayers(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		Bitmap bitmap2 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		Bitmap bitmap3 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		Bitmap bitmap4 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				double[] array = rgb2cmyk(pixel);
				double num = array[0];
				double num2 = array[1];
				double num3 = array[2];
				double num4 = array[3];
				Color color = cmyk2rgb(new double[4] { num, 0.0, 0.0, 0.0 });
				Color color2 = cmyk2rgb(new double[4] { 0.0, num2, 0.0, 0.0 });
				Color color3 = cmyk2rgb(new double[4] { 0.0, 0.0, num3, 0.0 });
				Color color4 = cmyk2rgb(new double[4] { 0.0, 0.0, 0.0, num4 });
				bitmap.SetPixel(i, j, color);
				bitmap2.SetPixel(i, j, color2);
				bitmap3.SetPixel(i, j, color3);
				bitmap4.SetPixel(i, j, color4);
			}
		}
		return new Bitmap[4] { bitmap, bitmap2, bitmap3, bitmap4 };
	}

	public Complex[,] DFT(Bitmap OriginalImage)
	{
		Complex[,] array = new Complex[OriginalImage.Width, OriginalImage.Height];
		Bitmap bitmap = ToGreyscale(OriginalImage);
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Complex complex = 0;
				for (int k = 0; k < height; k++)
				{
					for (int l = 0; l < width; l++)
					{
						double num = Convert.ToDouble(bitmap.GetPixel(l, k).R);
						Complex complex2 = new Complex(0.0, 1.0);
						double num2 = (double)(i * l) / Convert.ToDouble(width) + (double)(j * k) / Convert.ToDouble(height);
						Complex complex3 = Complex.Exp(-complex2 * 2 * Math.PI * num2);
						complex += num * complex3;
					}
				}
				array[i, j] = complex / Math.Sqrt(width * height);
			}
		}
		return array;
	}

	public Complex[,] SDFT(Bitmap OriginalImage)
	{
		Complex[,] array = new Complex[OriginalImage.Width, OriginalImage.Height];
		Bitmap bitmap_ = ToGreyscale(OriginalImage);
		double[,] array2 = Class156.smethod_55(bitmap_, this);
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Complex complex = 0;
				for (int k = 0; k < height; k++)
				{
					for (int l = 0; l < width; l++)
					{
						double num = array2[l, k];
						Complex complex2 = new Complex(0.0, 1.0);
						double num2 = (double)(i * l) / Convert.ToDouble(width) + (double)(j * k) / Convert.ToDouble(height);
						Complex complex3 = Complex.Exp(-complex2 * 2 * Math.PI * num2);
						complex += num * complex3;
					}
				}
				array[i, j] = complex / Math.Sqrt(width * height);
			}
		}
		return array;
	}

	public Complex[,] SDFT(double[,] Data)
	{
		Complex[,] array = new Complex[Data.GetLength(0), Data.GetLength(1)];
		Data = Class156.smethod_40(this, Data);
		int length = Data.GetLength(0);
		int length2 = Data.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				Complex complex = 0;
				for (int k = 0; k < length2; k++)
				{
					for (int l = 0; l < length; l++)
					{
						double num = Data[l, k];
						Complex complex2 = new Complex(0.0, 1.0);
						double num2 = (double)(i * l) / Convert.ToDouble(length) + (double)(j * k) / Convert.ToDouble(length2);
						Complex complex3 = Complex.Exp(-complex2 * 2 * Math.PI * num2);
						complex += num * complex3;
					}
				}
				array[i, j] = complex / Math.Sqrt(Convert.ToDouble(length) * Convert.ToDouble(length2));
			}
		}
		return array;
	}

	public Complex[,] DFT(double[,] Data)
	{
		Complex[,] array = new Complex[Data.GetLength(0), Data.GetLength(1)];
		int length = Data.GetLength(0);
		int length2 = Data.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				Complex complex = 0;
				for (int k = 0; k < length2; k++)
				{
					for (int l = 0; l < length; l++)
					{
						double num = Data[l, k];
						Complex complex2 = new Complex(0.0, 1.0);
						double num2 = (double)(i * l) / Convert.ToDouble(length) + (double)(j * k) / Convert.ToDouble(length2);
						Complex complex3 = Complex.Exp(-complex2 * 2 * Math.PI * num2);
						complex += num * complex3;
					}
				}
				array[i, j] = complex / Math.Sqrt(Convert.ToDouble(length) * Convert.ToDouble(length2));
			}
		}
		return array;
	}

	public Bitmap iDFT(Complex[,] Spectrum)
	{
		Bitmap bitmap = new Bitmap(Spectrum.GetLength(0), Spectrum.GetLength(1));
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				double num = Convert.ToDouble(i);
				double num2 = Convert.ToDouble(j);
				Complex complex = new Complex(0.0, 1.0);
				Complex complex2 = 0;
				for (int k = 0; k < Spectrum.GetLength(0); k++)
				{
					for (int l = 0; l < Spectrum.GetLength(1); l++)
					{
						double num3 = Convert.ToDouble(k);
						double num4 = Convert.ToDouble(l);
						double num5 = num3 * num / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
						Complex complex3 = Complex.Exp(complex * 2 * Math.PI * num5);
						complex2 += Spectrum[k, l] * complex3;
					}
				}
				int num6 = (int)(complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1))));
				if (num6 > 255)
				{
					num6 = 255;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num6, num6, num6));
			}
		}
		return bitmap;
	}

	public double[,] iDFT2(Complex[,] Spectrum)
	{
		double[,] array = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				double num = Convert.ToDouble(i);
				double num2 = Convert.ToDouble(j);
				Complex complex = new Complex(0.0, 1.0);
				Complex complex2 = 0;
				for (int k = 0; k < Spectrum.GetLength(0); k++)
				{
					for (int l = 0; l < Spectrum.GetLength(1); l++)
					{
						double num3 = Convert.ToDouble(k);
						double num4 = Convert.ToDouble(l);
						double num5 = num3 * num / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
						Complex complex3 = Complex.Exp(complex * 2 * Math.PI * num5);
						complex2 += Spectrum[k, l] * complex3;
					}
				}
				array[i, j] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
			}
		}
		return array;
	}

	public double[,] iSDFT2(Complex[,] Spectrum)
	{
		double[,] array = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				double num = Convert.ToDouble(i);
				double num2 = Convert.ToDouble(j);
				Complex complex = new Complex(0.0, 1.0);
				Complex complex2 = 0;
				for (int k = 0; k < Spectrum.GetLength(0); k++)
				{
					for (int l = 0; l < Spectrum.GetLength(1); l++)
					{
						double num3 = Convert.ToDouble(k);
						double num4 = Convert.ToDouble(l);
						double num5 = num3 * num / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
						Complex complex3 = Complex.Exp(complex * 2 * Math.PI * num5);
						complex2 += Spectrum[k, l] * complex3;
					}
				}
				array[i, j] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
			}
		}
		return Class156.smethod_40(this, array);
	}

	public Bitmap iSDFT(Complex[,] Spectrum)
	{
		double[,] array = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				double num = Convert.ToDouble(i);
				double num2 = Convert.ToDouble(j);
				Complex complex = new Complex(0.0, 1.0);
				Complex complex2 = 0;
				for (int k = 0; k < Spectrum.GetLength(0); k++)
				{
					for (int l = 0; l < Spectrum.GetLength(1); l++)
					{
						double num3 = Convert.ToDouble(k);
						double num4 = Convert.ToDouble(l);
						double num5 = num3 * num / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
						Complex complex3 = Complex.Exp(complex * 2 * Math.PI * num5);
						complex2 += Spectrum[k, l] * complex3;
					}
				}
				array[i, j] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
			}
		}
		return Matrix2Image(array);
	}

	public Bitmap Matrix2Image(double[,] Matrix)
	{
		Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
		for (int i = 0; i < Matrix.GetLength(0); i++)
		{
			for (int j = 0; j < Matrix.GetLength(1); j++)
			{
				int num = (int)Matrix[i, j];
				if (num > 255)
				{
					num = 255;
				}
				if (num < 0)
				{
					num = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num, num, num));
			}
		}
		return bitmap;
	}

	public Bitmap Matrix2Image(int[,] Matrix)
	{
		Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
		for (int i = 0; i < Matrix.GetLength(0); i++)
		{
			for (int j = 0; j < Matrix.GetLength(1); j++)
			{
				int num = Matrix[i, j];
				if (num > 255)
				{
					num = 255;
				}
				if (num < 0)
				{
					num = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num, num, num));
			}
		}
		return bitmap;
	}

	public double[,] Magnitude(Complex[,] Spectrum)
	{
		double[,] array = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				array[i, j] = Spectrum[i, j].Magnitude;
			}
		}
		return array;
	}

	public double[,] Phase(Complex[,] Spectrum)
	{
		double[,] array = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
		for (int i = 0; i < Spectrum.GetLength(0); i++)
		{
			for (int j = 0; j < Spectrum.GetLength(1); j++)
			{
				array[i, j] = Spectrum[i, j].Phase;
			}
		}
		return array;
	}

	public Bitmap Matrix2ImageLog(double[,] Matrix)
	{
		Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
		double num = Matrix.Cast<double>().Max();
		for (int i = 0; i < Matrix.GetLength(0); i++)
		{
			for (int j = 0; j < Matrix.GetLength(1); j++)
			{
				double num2 = 255.0 / Math.Log10(1.0 + num);
				int num3 = (int)(num2 * Math.Log10(1.0 + Matrix[i, j]));
				Color color = Color.FromArgb(255, num3, num3, num3);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap Matrix2ImageMax(double[,] Matrix)
	{
		Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
		double num = Matrix.Cast<double>().Max();
		for (int i = 0; i < Matrix.GetLength(0); i++)
		{
			for (int j = 0; j < Matrix.GetLength(1); j++)
			{
				int num2 = (int)(Matrix[i, j] / num);
				if (num2 > 255)
				{
					num2 = 255;
				}
				Color color = Color.FromArgb(255, num2, num2, num2);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public int[,,] RGBMatrix(Bitmap OriginalImage)
	{
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		int[,,] array = new int[3, width, height];
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				array[0, i, j] = pixel.R;
				array[1, i, j] = pixel.G;
				array[2, i, j] = pixel.B;
			}
		}
		return array;
	}

	public int[,] RMatrix(Bitmap OriginalImage)
	{
		int[,,] array = RGBMatrix(OriginalImage);
		int[,] array2 = new int[OriginalImage.Width, OriginalImage.Height];
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				array2[i, j] = array[0, i, j];
			}
		}
		return array2;
	}

	public int[,] GMatrix(Bitmap OriginalImage)
	{
		int[,,] array = RGBMatrix(OriginalImage);
		int[,] array2 = new int[OriginalImage.Width, OriginalImage.Height];
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				array2[i, j] = array[1, i, j];
			}
		}
		return array2;
	}

	public int[,] BMatrix(Bitmap OriginalImage)
	{
		int[,,] array = RGBMatrix(OriginalImage);
		int[,] array2 = new int[OriginalImage.Width, OriginalImage.Height];
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				array2[i, j] = array[2, i, j];
			}
		}
		return array2;
	}

	public Bitmap[] RGBLayers(Bitmap OriginalImage)
	{
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		Bitmap bitmap = new Bitmap(width, height);
		Bitmap bitmap2 = new Bitmap(width, height);
		Bitmap bitmap3 = new Bitmap(width, height);
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				bitmap.SetPixel(i, j, Color.FromArgb(255, pixel.R, 0, 0));
				bitmap2.SetPixel(i, j, Color.FromArgb(255, 0, pixel.G, 0));
				bitmap3.SetPixel(i, j, Color.FromArgb(255, 0, 0, pixel.B));
			}
		}
		return new Bitmap[3] { bitmap, bitmap2, bitmap3 };
	}

	public Bitmap LogaritmicScaling(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		int[,] source = RMatrix(OriginalImage);
		int[,] source2 = GMatrix(OriginalImage);
		int[,] source3 = BMatrix(OriginalImage);
		double num = Convert.ToDouble(source.Cast<int>().Max());
		double num2 = Convert.ToDouble(source2.Cast<int>().Max());
		double num3 = Convert.ToDouble(source3.Cast<int>().Max());
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				double num4 = 255.0 / Math.Log10(1.0 + num);
				int red = (int)(num4 * Math.Log10(1 + OriginalImage.GetPixel(i, j).R));
				double num5 = 255.0 / Math.Log10(1.0 + num2);
				int green = (int)(num5 * Math.Log10(1 + OriginalImage.GetPixel(i, j).G));
				double num6 = 255.0 / Math.Log10(1.0 + num3);
				int blue = (int)(num6 * Math.Log10(1 + OriginalImage.GetPixel(i, j).B));
				Color color = Color.FromArgb(255, red, green, blue);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ToGreyscale(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				Color color = Color.FromArgb(255, num, num, num);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ToGreyscaleAVG(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (pixel.R + pixel.G + pixel.B) / 3;
				Color color = Color.FromArgb(255, num, num, num);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ToGreyscaleLightness(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (Math.Max(pixel.R, Math.Max(pixel.G, pixel.B)) + Math.Min(pixel.R, Math.Min(pixel.G, pixel.B))) / 2;
				Color color = Color.FromArgb(255, num, num, num);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap InverseImage(Bitmap OriginalImage, int threshold)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (threshold >= 1 && threshold <= 254)
		{
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					Color pixel = OriginalImage.GetPixel(i, j);
					int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
					int num2 = Math.Abs(threshold - num);
					int num3 = 0;
					if (num >= threshold)
					{
						num3 = threshold - num2;
					}
					if (num < threshold)
					{
						num3 = threshold + num2;
					}
					if (num3 > 255)
					{
						num3 = 255;
					}
					if (num3 < 0)
					{
						num3 = 0;
					}
					Color color = Color.FromArgb(255, num3, num3, num3);
					bitmap.SetPixel(i, j, color);
				}
			}
			return bitmap;
		}
		throw new Exception("Threshold value must be in range from 1 to 254");
	}

	public Bitmap NegativeImageGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				int num2 = 255 - num;
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				Color color = Color.FromArgb(255, num2, num2, num2);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap NegativeImageColor(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int r = pixel.R;
				int num = 255 - r;
				int g = pixel.G;
				int num2 = 255 - g;
				int b = pixel.B;
				int num3 = 255 - b;
				if (num > 255)
				{
					num = 255;
				}
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 > 255)
				{
					num3 = 255;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				Color color = Color.FromArgb(255, num, num2, num3);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap AddImages(Bitmap Left, Bitmap Right)
	{
		if (Left.Width == Right.Width)
		{
			if (Left.Height == Right.Height)
			{
				Bitmap bitmap = new Bitmap(Left.Width, Left.Height);
				for (int i = 0; i < Left.Width; i++)
				{
					for (int j = 0; j < Left.Height; j++)
					{
						Color pixel = Left.GetPixel(i, j);
						Color pixel2 = Right.GetPixel(i, j);
						int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
						int num2 = (int)((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
						int num3 = num + num2;
						if (num3 > 255)
						{
							num3 = 255;
						}
						if (num3 < 0)
						{
							num3 = 0;
						}
						Color color = Color.FromArgb(255, num3, num3, num3);
						bitmap.SetPixel(i, j, color);
					}
				}
				return bitmap;
			}
			throw new Exception("Images dimension must be equal.");
		}
		throw new Exception("Images dimension must be equal.");
	}

	public Bitmap SubtractImages(Bitmap Left, Bitmap Right)
	{
		if (Left.Width == Right.Width)
		{
			if (Left.Height == Right.Height)
			{
				Bitmap bitmap = new Bitmap(Left.Width, Left.Height);
				for (int i = 0; i < Left.Width; i++)
				{
					for (int j = 0; j < Left.Height; j++)
					{
						Color pixel = Left.GetPixel(i, j);
						Color pixel2 = Right.GetPixel(i, j);
						int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
						int num2 = (int)((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
						int num3 = num - num2;
						if (num3 > 255)
						{
							num3 = 255;
						}
						if (num3 < 0)
						{
							num3 = 0;
						}
						Color color = Color.FromArgb(255, num3, num3, num3);
						bitmap.SetPixel(i, j, color);
					}
				}
				return bitmap;
			}
			throw new Exception("Images dimension must be equal.");
		}
		throw new Exception("Images dimension must be equal.");
	}

	public Bitmap ToBlackwhite(Bitmap OriginalImage, int threshold)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (threshold >= 1 && threshold <= 254)
		{
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					Color pixel = OriginalImage.GetPixel(i, j);
					int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
					num = ((num > threshold) ? 255 : 0);
					Color color = Color.FromArgb(255, num, num, num);
					bitmap.SetPixel(i, j, color);
				}
			}
			return bitmap;
		}
		throw new Exception("Threshold value must be in range from 1 to 254");
	}

	public Bitmap ToBlackwhiteInverse(Bitmap OriginalImage, int threshold)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (threshold >= 1 && threshold <= 254)
		{
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					Color pixel = OriginalImage.GetPixel(i, j);
					int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
					num = ((num <= threshold) ? 255 : 0);
					Color color = Color.FromArgb(255, num, num, num);
					bitmap.SetPixel(i, j, color);
				}
			}
			return bitmap;
		}
		throw new Exception("Threshold value must be in range from 1 to 254");
	}

	public int[] Histogram(Bitmap OriginalImage)
	{
		int[] array = new int[256];
		for (int i = 0; i < 256; i++)
		{
			array[i] = 0;
		}
		for (int j = 0; j < OriginalImage.Width; j++)
		{
			for (int k = 0; k < OriginalImage.Height; k++)
			{
				Color pixel = OriginalImage.GetPixel(j, k);
				int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				array[num]++;
			}
		}
		return array;
	}

	public int[,] RGBHistogram(Bitmap OriginalImage)
	{
		int[,] array = new int[3, 256];
		for (int i = 0; i < 256; i++)
		{
			array[0, i] = 0;
			array[1, i] = 0;
			array[2, i] = 0;
		}
		for (int j = 0; j < OriginalImage.Width; j++)
		{
			for (int k = 0; k < OriginalImage.Height; k++)
			{
				Color pixel = OriginalImage.GetPixel(j, k);
				array[0, pixel.R]++;
				array[1, pixel.G]++;
				array[2, pixel.B]++;
			}
		}
		return array;
	}

	public int MinBrightness(Bitmap OriginalImage)
	{
		int num = 255;
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num2 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public int MaxBrightness(Bitmap OriginalImage)
	{
		int num = 0;
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num2 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public Bitmap ContrastStretching(Bitmap OriginalImage)
	{
		int num = 0;
		int num2 = 255;
		int num3 = MinBrightness(OriginalImage);
		int num4 = MaxBrightness(OriginalImage);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num5 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				double num6 = Convert.ToDouble(num5 - num3) / Convert.ToDouble(num4 - num3) * (double)(num2 - num) + (double)num;
				int num7 = (int)num6;
				OriginalImage.SetPixel(i, j, Color.FromArgb(255, num7, num7, num7));
			}
		}
		return OriginalImage;
	}

	public Bitmap ContrastStretching(Bitmap OriginalImage, int RMinSet, int RMaxSet)
	{
		if (RMinSet < RMaxSet)
		{
			if (RMinSet >= 0)
			{
				if (RMaxSet <= 255)
				{
					int num = MinBrightness(OriginalImage);
					int num2 = MaxBrightness(OriginalImage);
					for (int i = 0; i < OriginalImage.Width; i++)
					{
						for (int j = 0; j < OriginalImage.Height; j++)
						{
							Color pixel = OriginalImage.GetPixel(i, j);
							int num3 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
							double num4 = Convert.ToDouble(num3 - num) / Convert.ToDouble(num2 - num) * (double)(RMaxSet - RMinSet) + (double)RMinSet;
							int num5 = (int)num4;
							OriginalImage.SetPixel(i, j, Color.FromArgb(255, num5, num5, num5));
						}
					}
					return OriginalImage;
				}
				throw new Exception("Maximum available brightness value must be positive lower or equal 255");
			}
			throw new Exception("Minimum available brightness value must be positive or zero");
		}
		throw new Exception("Minimum available brightness value must be lower then maximum available brightness value");
	}

	public Bitmap HistogramShift(Bitmap OriginalImage, int offset)
	{
		if (offset >= 1 && offset <= 254)
		{
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					Color pixel = OriginalImage.GetPixel(i, j);
					int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
					int num2 = num + offset;
					OriginalImage.SetPixel(i, j, Color.FromArgb(255, num2, num2, num2));
				}
			}
			return OriginalImage;
		}
		throw new Exception("Offset value must be in range from 1 to 254");
	}

	public Bitmap HistoramEqualization(Bitmap OriginalImage)
	{
		int[] array = Histogram(OriginalImage);
		int num = OriginalImage.Width * OriginalImage.Height;
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num2 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				double num3 = 0.0;
				for (int k = 0; k < num2 + 1; k++)
				{
					num3 += Convert.ToDouble(array[k]) / (double)num;
				}
				int num4 = Convert.ToInt16(Math.Floor(255.0 * num3));
				OriginalImage.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
			}
		}
		return OriginalImage;
	}

	public Bitmap ImageFilterGS(Bitmap OriginalImage, int[,] Filter)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							int[,] array = new int[Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num5 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
									array[num2, num3] = (int)num5;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += array[m, n] * Filter[m, n];
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageFilterGS(Bitmap OriginalImage, int[,] Filter, double Coef)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							int[,] array = new int[Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num5 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
									array[num2, num3] = (int)num5;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += array[m, n] * Filter[m, n];
								}
							}
							num4 = (int)(Convert.ToDouble(num4) / Coef);
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageFilterGS(Bitmap OriginalImage, double[,] Filter)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							double[,] array = new double[Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num5 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
									array[num2, num3] = num5;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += (int)(array[m, n] * Filter[m, n]);
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageFilterColor(Bitmap OriginalImage, int[,] Filter)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							int[,,] array = new int[3, Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num7 = Convert.ToDouble(pixel.R);
									double num8 = Convert.ToDouble(pixel.G);
									double num9 = Convert.ToDouble(pixel.B);
									array[0, num2, num3] = (int)num7;
									array[1, num2, num3] = (int)num8;
									array[2, num2, num3] = (int)num9;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += array[0, m, n] * Filter[m, n];
									num5 += array[1, m, n] * Filter[m, n];
									num6 += array[2, m, n] * Filter[m, n];
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							if (num5 > 255)
							{
								num5 = 255;
							}
							if (num5 < 0)
							{
								num5 = 0;
							}
							if (num6 > 255)
							{
								num6 = 255;
							}
							if (num6 < 0)
							{
								num6 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num5, num6));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageFilterColor(Bitmap OriginalImage, int[,] Filter, double Coef)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							int[,,] array = new int[3, Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num7 = Convert.ToDouble(pixel.R);
									double num8 = Convert.ToDouble(pixel.G);
									double num9 = Convert.ToDouble(pixel.B);
									array[0, num2, num3] = (int)num7;
									array[1, num2, num3] = (int)num8;
									array[2, num2, num3] = (int)num9;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += array[0, m, n] * Filter[m, n];
									num5 += array[1, m, n] * Filter[m, n];
									num6 += array[2, m, n] * Filter[m, n];
								}
							}
							num4 = (int)(Convert.ToDouble(num4) / Coef);
							num5 = (int)(Convert.ToDouble(num5) / Coef);
							num6 = (int)(Convert.ToDouble(num6) / Coef);
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							if (num5 > 255)
							{
								num5 = 255;
							}
							if (num5 < 0)
							{
								num5 = 0;
							}
							if (num6 > 255)
							{
								num6 = 255;
							}
							if (num6 < 0)
							{
								num6 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num5, num6));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageFilterColor(Bitmap OriginalImage, double[,] Filter)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Filter.GetLength(0) == Filter.GetLength(1))
		{
			if (Filter.GetLength(0) % 2 != 0)
			{
				if (Filter.GetLength(0) >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							double[,,] array = new double[3, Filter.GetLength(0), Filter.GetLength(0)];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num7 = Convert.ToDouble(pixel.R);
									double num8 = Convert.ToDouble(pixel.G);
									double num9 = Convert.ToDouble(pixel.B);
									array[0, num2, num3] = (int)num7;
									array[1, num2, num3] = (int)num8;
									array[2, num2, num3] = (int)num9;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							for (int m = 0; m < Filter.GetLength(0); m++)
							{
								for (int n = 0; n < Filter.GetLength(0); n++)
								{
									num4 += (int)(array[0, m, n] * Filter[m, n]);
									num5 += (int)(array[1, m, n] * Filter[m, n]);
									num6 += (int)(array[2, m, n] * Filter[m, n]);
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							if (num5 > 255)
							{
								num5 = 255;
							}
							if (num5 < 0)
							{
								num5 = 0;
							}
							if (num6 > 255)
							{
								num6 = 255;
							}
							if (num6 < 0)
							{
								num6 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num5, num6));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Filter mask must be square.");
	}

	public Bitmap ImageSobelFilterGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 1; i < OriginalImage.Width - 1; i++)
		{
			for (int j = 1; j < OriginalImage.Height - 1; j++)
			{
				Color pixel = OriginalImage.GetPixel(i - 1, j - 1);
				Color pixel2 = OriginalImage.GetPixel(i, j - 1);
				Color pixel3 = OriginalImage.GetPixel(i + 1, j - 1);
				Color pixel4 = OriginalImage.GetPixel(i - 1, j);
				Color pixel5 = OriginalImage.GetPixel(i, j);
				Color pixel6 = OriginalImage.GetPixel(i + 1, j);
				Color pixel7 = OriginalImage.GetPixel(i - 1, j + 1);
				Color pixel8 = OriginalImage.GetPixel(i, j + 1);
				Color pixel9 = OriginalImage.GetPixel(i + 1, j + 1);
				double num = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				double num2 = Convert.ToDouble((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
				double num3 = Convert.ToDouble((double)(int)pixel3.R * 0.3 + (double)(int)pixel3.G * 0.59 + (double)(int)pixel3.B * 0.11);
				double num4 = Convert.ToDouble((double)(int)pixel4.R * 0.3 + (double)(int)pixel4.G * 0.59 + (double)(int)pixel4.B * 0.11);
				Convert.ToDouble((double)(int)pixel5.R * 0.3 + (double)(int)pixel5.G * 0.59 + (double)(int)pixel5.B * 0.11);
				double num5 = Convert.ToDouble((double)(int)pixel6.R * 0.3 + (double)(int)pixel6.G * 0.59 + (double)(int)pixel6.B * 0.11);
				double num6 = Convert.ToDouble((double)(int)pixel7.R * 0.3 + (double)(int)pixel7.G * 0.59 + (double)(int)pixel7.B * 0.11);
				double num7 = Convert.ToDouble((double)(int)pixel8.R * 0.3 + (double)(int)pixel8.G * 0.59 + (double)(int)pixel8.B * 0.11);
				double num8 = Convert.ToDouble((double)(int)pixel9.R * 0.3 + (double)(int)pixel9.G * 0.59 + (double)(int)pixel9.B * 0.11);
				int value = (int)(num + (num2 + num2) + num3 - num6 - (num7 + num7) - num8);
				int value2 = (int)(num3 + (num5 + num5) + num8 - num - (num4 + num4) - num6);
				int num9 = Math.Abs(value) + Math.Abs(value2);
				if (num9 > 255)
				{
					num9 = 255;
				}
				if (num9 < 0)
				{
					num9 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num9, num9, num9));
			}
		}
		return bitmap;
	}

	public Bitmap ImageSobelFilterColor(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 1; i < OriginalImage.Width - 1; i++)
		{
			for (int j = 1; j < OriginalImage.Height - 1; j++)
			{
				Color pixel = OriginalImage.GetPixel(i - 1, j - 1);
				Color pixel2 = OriginalImage.GetPixel(i, j - 1);
				Color pixel3 = OriginalImage.GetPixel(i + 1, j - 1);
				Color pixel4 = OriginalImage.GetPixel(i - 1, j);
				Color pixel5 = OriginalImage.GetPixel(i, j);
				Color pixel6 = OriginalImage.GetPixel(i + 1, j);
				Color pixel7 = OriginalImage.GetPixel(i - 1, j + 1);
				Color pixel8 = OriginalImage.GetPixel(i, j + 1);
				Color pixel9 = OriginalImage.GetPixel(i + 1, j + 1);
				double num = Convert.ToDouble(pixel.R);
				double num2 = Convert.ToDouble(pixel2.R);
				double num3 = Convert.ToDouble(pixel3.R);
				double num4 = Convert.ToDouble(pixel4.R);
				Convert.ToDouble(pixel5.R);
				double num5 = Convert.ToDouble(pixel6.R);
				double num6 = Convert.ToDouble(pixel7.R);
				double num7 = Convert.ToDouble(pixel8.R);
				double num8 = Convert.ToDouble(pixel9.R);
				double num9 = Convert.ToDouble(pixel.G);
				double num10 = Convert.ToDouble(pixel2.G);
				double num11 = Convert.ToDouble(pixel3.G);
				double num12 = Convert.ToDouble(pixel4.G);
				Convert.ToDouble(pixel5.G);
				double num13 = Convert.ToDouble(pixel6.G);
				double num14 = Convert.ToDouble(pixel7.G);
				double num15 = Convert.ToDouble(pixel8.G);
				double num16 = Convert.ToDouble(pixel9.G);
				double num17 = Convert.ToDouble(pixel.B);
				double num18 = Convert.ToDouble(pixel2.B);
				double num19 = Convert.ToDouble(pixel3.B);
				double num20 = Convert.ToDouble(pixel4.B);
				Convert.ToDouble(pixel5.B);
				double num21 = Convert.ToDouble(pixel6.B);
				double num22 = Convert.ToDouble(pixel7.B);
				double num23 = Convert.ToDouble(pixel8.B);
				double num24 = Convert.ToDouble(pixel9.B);
				int value = (int)(num + (num2 + num2) + num3 - num6 - (num7 + num7) - num8);
				int value2 = (int)(num3 + (num5 + num5) + num8 - num - (num4 + num4) - num6);
				int num25 = Math.Abs(value) + Math.Abs(value2);
				if (num25 > 255)
				{
					num25 = 255;
				}
				if (num25 < 0)
				{
					num25 = 0;
				}
				int value3 = (int)(num9 + (num10 + num10) + num11 - num14 - (num15 + num15) - num16);
				int value4 = (int)(num11 + (num13 + num13) + num16 - num9 - (num12 + num12) - num14);
				int num26 = Math.Abs(value3) + Math.Abs(value4);
				if (num26 > 255)
				{
					num26 = 255;
				}
				if (num26 < 0)
				{
					num26 = 0;
				}
				int value5 = (int)(num17 + (num18 + num18) + num19 - num22 - (num23 + num23) - num24);
				int value6 = (int)(num19 + (num21 + num21) + num24 - num17 - (num20 + num20) - num22);
				int num27 = Math.Abs(value5) + Math.Abs(value6);
				if (num27 > 255)
				{
					num27 = 255;
				}
				if (num27 < 0)
				{
					num27 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num25, num26, num27));
			}
		}
		return bitmap;
	}

	public Bitmap ImagePrewittFilterGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 1; i < OriginalImage.Width - 1; i++)
		{
			for (int j = 1; j < OriginalImage.Height - 1; j++)
			{
				Color pixel = OriginalImage.GetPixel(i - 1, j - 1);
				Color pixel2 = OriginalImage.GetPixel(i, j - 1);
				Color pixel3 = OriginalImage.GetPixel(i + 1, j - 1);
				Color pixel4 = OriginalImage.GetPixel(i - 1, j);
				Color pixel5 = OriginalImage.GetPixel(i, j);
				Color pixel6 = OriginalImage.GetPixel(i + 1, j);
				Color pixel7 = OriginalImage.GetPixel(i - 1, j + 1);
				Color pixel8 = OriginalImage.GetPixel(i, j + 1);
				Color pixel9 = OriginalImage.GetPixel(i + 1, j + 1);
				double num = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				double num2 = Convert.ToDouble((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
				double num3 = Convert.ToDouble((double)(int)pixel3.R * 0.3 + (double)(int)pixel3.G * 0.59 + (double)(int)pixel3.B * 0.11);
				double num4 = Convert.ToDouble((double)(int)pixel4.R * 0.3 + (double)(int)pixel4.G * 0.59 + (double)(int)pixel4.B * 0.11);
				Convert.ToDouble((double)(int)pixel5.R * 0.3 + (double)(int)pixel5.G * 0.59 + (double)(int)pixel5.B * 0.11);
				double num5 = Convert.ToDouble((double)(int)pixel6.R * 0.3 + (double)(int)pixel6.G * 0.59 + (double)(int)pixel6.B * 0.11);
				double num6 = Convert.ToDouble((double)(int)pixel7.R * 0.3 + (double)(int)pixel7.G * 0.59 + (double)(int)pixel7.B * 0.11);
				double num7 = Convert.ToDouble((double)(int)pixel8.R * 0.3 + (double)(int)pixel8.G * 0.59 + (double)(int)pixel8.B * 0.11);
				double num8 = Convert.ToDouble((double)(int)pixel9.R * 0.3 + (double)(int)pixel9.G * 0.59 + (double)(int)pixel9.B * 0.11);
				int value = (int)(num + num2 + num3 - num6 - num7 - num8);
				int value2 = (int)(num - num3 + num4 - num5 + num6 - num8);
				int num9 = Math.Abs(value) + Math.Abs(value2);
				if (num9 > 255)
				{
					num9 = 255;
				}
				if (num9 < 0)
				{
					num9 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num9, num9, num9));
			}
		}
		return bitmap;
	}

	public Bitmap ImagePrewittFilterColor(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 1; i < OriginalImage.Width - 1; i++)
		{
			for (int j = 1; j < OriginalImage.Height - 1; j++)
			{
				Color pixel = OriginalImage.GetPixel(i - 1, j - 1);
				Color pixel2 = OriginalImage.GetPixel(i, j - 1);
				Color pixel3 = OriginalImage.GetPixel(i + 1, j - 1);
				Color pixel4 = OriginalImage.GetPixel(i - 1, j);
				Color pixel5 = OriginalImage.GetPixel(i, j);
				Color pixel6 = OriginalImage.GetPixel(i + 1, j);
				Color pixel7 = OriginalImage.GetPixel(i - 1, j + 1);
				Color pixel8 = OriginalImage.GetPixel(i, j + 1);
				Color pixel9 = OriginalImage.GetPixel(i + 1, j + 1);
				double num = Convert.ToDouble(pixel.R);
				double num2 = Convert.ToDouble(pixel2.R);
				double num3 = Convert.ToDouble(pixel3.R);
				double num4 = Convert.ToDouble(pixel4.R);
				Convert.ToDouble(pixel5.R);
				double num5 = Convert.ToDouble(pixel6.R);
				double num6 = Convert.ToDouble(pixel7.R);
				double num7 = Convert.ToDouble(pixel8.R);
				double num8 = Convert.ToDouble(pixel9.R);
				double num9 = Convert.ToDouble(pixel.G);
				double num10 = Convert.ToDouble(pixel2.G);
				double num11 = Convert.ToDouble(pixel3.G);
				double num12 = Convert.ToDouble(pixel4.G);
				Convert.ToDouble(pixel5.G);
				double num13 = Convert.ToDouble(pixel6.G);
				double num14 = Convert.ToDouble(pixel7.G);
				double num15 = Convert.ToDouble(pixel8.G);
				double num16 = Convert.ToDouble(pixel9.G);
				double num17 = Convert.ToDouble(pixel.B);
				double num18 = Convert.ToDouble(pixel2.B);
				double num19 = Convert.ToDouble(pixel3.B);
				double num20 = Convert.ToDouble(pixel4.B);
				Convert.ToDouble(pixel5.B);
				double num21 = Convert.ToDouble(pixel6.B);
				double num22 = Convert.ToDouble(pixel7.B);
				double num23 = Convert.ToDouble(pixel8.B);
				double num24 = Convert.ToDouble(pixel9.B);
				int value = (int)(num + num2 + num3 - num6 - num7 - num8);
				int value2 = (int)(num - num3 + num4 - num5 + num6 - num8);
				int num25 = Math.Abs(value) + Math.Abs(value2);
				if (num25 > 255)
				{
					num25 = 255;
				}
				if (num25 < 0)
				{
					num25 = 0;
				}
				int value3 = (int)(num9 + num10 + num11 - num14 - num15 - num16);
				int value4 = (int)(num9 - num11 + num12 - num13 + num14 - num16);
				int num26 = Math.Abs(value3) + Math.Abs(value4);
				if (num26 > 255)
				{
					num26 = 255;
				}
				if (num26 < 0)
				{
					num26 = 0;
				}
				int value5 = (int)(num17 + num18 + num19 - num22 - num23 - num24);
				int value6 = (int)(num17 - num19 + num20 - num21 + num22 - num24);
				int num27 = Math.Abs(value5) + Math.Abs(value6);
				if (num27 > 255)
				{
					num27 = 255;
				}
				if (num27 < 0)
				{
					num27 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num25, num26, num27));
			}
		}
		return bitmap;
	}

	public Bitmap ImageMedianFilterGS(Bitmap OriginalImage, int size)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				int num = (int)Math.Floor(Convert.ToDouble(size / 2));
				for (int i = num; i < OriginalImage.Width - num; i++)
				{
					for (int j = num; j < OriginalImage.Height - num; j++)
					{
						int[] array = new int[size * size];
						int num2 = 0;
						int num3 = 0;
						for (int k = i - num; k < i + num + 1; k++)
						{
							for (int l = j - num; l < j + num + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num4 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
								array[num2] = (int)num4;
								num2++;
							}
						}
						Array.Sort(array);
						decimal num5 = default(decimal);
						int num6 = array.Length;
						int num7 = num6 / 2;
						num5 = ((num6 % 2 == 0) ? (((decimal)array[num7] + (decimal)array[num7 + 1]) / 2m) : ((decimal)array[num7]));
						num3 = (int)num5;
						if (num3 > 255)
						{
							num3 = 255;
						}
						if (num3 < 0)
						{
							num3 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num3, num3, num3));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter mask dimesion must be greater or equal 3.");
		}
		throw new Exception("Median filter dimesion must be odd.");
	}

	public Bitmap ImageMedianFilterColor(Bitmap OriginalImage, int size)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				int num = (int)Math.Floor(Convert.ToDouble(size / 2));
				for (int i = num; i < OriginalImage.Width - num; i++)
				{
					for (int j = num; j < OriginalImage.Height - num; j++)
					{
						int[] array = new int[size * size];
						int[] array2 = new int[size * size];
						int[] array3 = new int[size * size];
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						for (int k = i - num; k < i + num + 1; k++)
						{
							for (int l = j - num; l < j + num + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num6 = Convert.ToDouble(pixel.R);
								double num7 = Convert.ToDouble(pixel.G);
								double num8 = Convert.ToDouble(pixel.B);
								array[num2] = (int)num6;
								array2[num2] = (int)num7;
								array3[num2] = (int)num8;
								num2++;
							}
						}
						Array.Sort(array);
						Array.Sort(array3);
						Array.Sort(array2);
						decimal num9 = default(decimal);
						decimal num10 = default(decimal);
						decimal num11 = default(decimal);
						int num12 = array.Length;
						int num13 = num12 / 2;
						num9 = ((num12 % 2 == 0) ? (((decimal)array[num13] + (decimal)array[num13 + 1]) / 2m) : ((decimal)array[num13]));
						num10 = ((num12 % 2 == 0) ? (((decimal)array2[num13] + (decimal)array2[num13 + 1]) / 2m) : ((decimal)array2[num13]));
						num11 = ((num12 % 2 == 0) ? (((decimal)array3[num13] + (decimal)array3[num13 + 1]) / 2m) : ((decimal)array3[num13]));
						num3 = (int)num9;
						if (num3 > 255)
						{
							num3 = 255;
						}
						if (num3 < 0)
						{
							num3 = 0;
						}
						num4 = (int)num10;
						if (num4 > 255)
						{
							num4 = 255;
						}
						if (num4 < 0)
						{
							num4 = 0;
						}
						num5 = (int)num11;
						if (num5 > 255)
						{
							num5 = 255;
						}
						if (num5 < 0)
						{
							num5 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num3, num4, num5));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter mask dimesion must be greater or equal 3.");
		}
		throw new Exception("Median filter dimesion must be odd.");
	}

	public Bitmap ImageErosionFilterGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		int num = 3;
		int num2 = (int)Math.Floor(Convert.ToDouble(1));
		for (int i = num2; i < OriginalImage.Width - num2; i++)
		{
			for (int j = num2; j < OriginalImage.Height - num2; j++)
			{
				int[,] array = new int[num, num];
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				for (int k = i - num2; k < i + num2 + 1; k++)
				{
					for (int l = j - num2; l < j + num2 + 1; l++)
					{
						Color pixel = OriginalImage.GetPixel(k, l);
						double num6 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
						array[num4, num3] = (int)num6;
						num3++;
					}
					num4++;
					num3 = 0;
				}
				int[] array2 = new int[num * num - 1];
				int num7 = 0;
				for (int m = 0; m < array.GetLength(0); m++)
				{
					for (int n = 0; n < array.GetLength(1); n++)
					{
						if (m != num2 || n != num2)
						{
							array2[num7] = array[m, n];
							num7++;
						}
					}
				}
				num5 = array2.Min();
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num5, num5));
			}
		}
		return bitmap;
	}

	public Bitmap ImageErosionFilterGS(Bitmap OriginalImage, int size)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				int num = (int)Math.Floor(Convert.ToDouble(size / 2));
				for (int i = num; i < OriginalImage.Width - num; i++)
				{
					for (int j = num; j < OriginalImage.Height - num; j++)
					{
						int[,] array = new int[size, size];
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						for (int k = i - num; k < i + num + 1; k++)
						{
							for (int l = j - num; l < j + num + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num5 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
								array[num3, num2] = (int)num5;
								num2++;
							}
							num3++;
							num2 = 0;
						}
						int[] array2 = new int[size * size - 1];
						int num6 = 0;
						for (int m = 0; m < array.GetLength(0); m++)
						{
							for (int n = 0; n < array.GetLength(1); n++)
							{
								if (m != num || n != num)
								{
									array2[num6] = array[m, n];
									num6++;
								}
							}
						}
						num4 = array2.Min();
						if (num4 > 255)
						{
							num4 = 255;
						}
						if (num4 < 0)
						{
							num4 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter mask dimesion must be greater or equal 3.");
		}
		throw new Exception("Filter filter dimesion must be odd.");
	}

	public Bitmap ImageDilatationFilterGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		int num = 3;
		int num2 = (int)Math.Floor(Convert.ToDouble(1));
		for (int i = num2; i < OriginalImage.Width - num2; i++)
		{
			for (int j = num2; j < OriginalImage.Height - num2; j++)
			{
				int[,] array = new int[num, num];
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				for (int k = i - num2; k < i + num2 + 1; k++)
				{
					for (int l = j - num2; l < j + num2 + 1; l++)
					{
						Color pixel = OriginalImage.GetPixel(k, l);
						double num6 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
						array[num4, num3] = (int)num6;
						num3++;
					}
					num4++;
					num3 = 0;
				}
				int[] array2 = new int[num * num - 1];
				int num7 = 0;
				for (int m = 0; m < array.GetLength(0); m++)
				{
					for (int n = 0; n < array.GetLength(1); n++)
					{
						if (m != num2 || n != num2)
						{
							array2[num7] = array[m, n];
							num7++;
						}
					}
				}
				num5 = array2.Max();
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num5, num5));
			}
		}
		return bitmap;
	}

	public Bitmap ImageDilatationFilterGS(Bitmap OriginalImage, int size)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				int num = (int)Math.Floor(Convert.ToDouble(size / 2));
				for (int i = num; i < OriginalImage.Width - num; i++)
				{
					for (int j = num; j < OriginalImage.Height - num; j++)
					{
						int[,] array = new int[size, size];
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						for (int k = i - num; k < i + num + 1; k++)
						{
							for (int l = j - num; l < j + num + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num5 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
								array[num3, num2] = (int)num5;
								num2++;
							}
							num3++;
							num2 = 0;
						}
						int[] array2 = new int[size * size - 1];
						int num6 = 0;
						for (int m = 0; m < array.GetLength(0); m++)
						{
							for (int n = 0; n < array.GetLength(1); n++)
							{
								if (m != num || n != num)
								{
									array2[num6] = array[m, n];
									num6++;
								}
							}
						}
						num4 = array2.Max();
						if (num4 > 255)
						{
							num4 = 255;
						}
						if (num4 < 0)
						{
							num4 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num4, num4));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter mask dimesion must be greater or equal 3.");
		}
		throw new Exception("Filter filter dimesion must be odd.");
	}

	public Bitmap ImageSDROMFilterGS(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		int[] array = new int[4] { 20, 40, 60, 80 };
		int num = 3;
		int num2 = (int)Math.Floor(Convert.ToDouble(1));
		for (int i = num2; i < OriginalImage.Width - num2; i++)
		{
			for (int j = num2; j < OriginalImage.Height - num2; j++)
			{
				int[,] array2 = new int[num, num];
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				Color pixel = OriginalImage.GetPixel(i, j);
				int num6 = (int)Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				for (int k = i - num2; k < i + num2 + 1; k++)
				{
					for (int l = j - num2; l < j + num2 + 1; l++)
					{
						Color pixel2 = OriginalImage.GetPixel(k, l);
						double num7 = Convert.ToDouble((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
						array2[num4, num3] = (int)num7;
						num3++;
					}
					num4++;
					num3 = 0;
				}
				int[] array3 = new int[num * num - 1];
				int num8 = 0;
				for (int m = 0; m < array2.GetLength(0); m++)
				{
					for (int n = 0; n < array2.GetLength(1); n++)
					{
						if (m != num2 || n != num2)
						{
							array3[num8] = array2[m, n];
							num8++;
						}
					}
				}
				Array.Sort(array3);
				int num9 = 0;
				int num10 = array3.Length;
				int num11 = num10 / 2 - 1;
				double num12 = Convert.ToDouble(array3[num11]);
				double num13 = Convert.ToDouble(array3[num11 + 1]);
				double num14 = (num12 + num13) / 2.0;
				num9 = (int)num14;
				int[] array4 = new int[num11 + 1];
				for (int num15 = 0; num15 < num11; num15++)
				{
					if (num6 > num9)
					{
						array4[num15] = num6 - array3[array3.GetLength(0) - 1 - num15];
					}
					else
					{
						array4[num15] = array3[num15] - num6;
					}
				}
				num5 = num6;
				for (int num16 = 0; num16 < num11; num16++)
				{
					if (array4[num16] > array[num16])
					{
						num5 = num9;
						break;
					}
				}
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num5, num5));
			}
		}
		return bitmap;
	}

	public Bitmap ImageSDROMFilterGS(Bitmap OriginalImage, int size, int[] thresholds)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				if (thresholds.GetLength(0) == (size * size - 1) / 2)
				{
					for (int i = 0; i < thresholds.GetLength(0) - 1; i++)
					{
						if (thresholds[i] >= thresholds[i + 1])
						{
							throw new Exception("Each next element of thresholds list must be greater then previous one.");
						}
					}
					int num = (int)Math.Floor(Convert.ToDouble(size / 2));
					for (int j = num; j < OriginalImage.Width - num; j++)
					{
						for (int k = num; k < OriginalImage.Height - num; k++)
						{
							int[,] array = new int[size, size];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							Color pixel = OriginalImage.GetPixel(j, k);
							int num5 = (int)Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
							for (int l = j - num; l < j + num + 1; l++)
							{
								for (int m = k - num; m < k + num + 1; m++)
								{
									Color pixel2 = OriginalImage.GetPixel(l, m);
									double num6 = Convert.ToDouble((double)(int)pixel2.R * 0.3 + (double)(int)pixel2.G * 0.59 + (double)(int)pixel2.B * 0.11);
									array[num3, num2] = (int)num6;
									num2++;
								}
								num3++;
								num2 = 0;
							}
							int[] array2 = new int[size * size - 1];
							int num7 = 0;
							for (int n = 0; n < array.GetLength(0); n++)
							{
								for (int num8 = 0; num8 < array.GetLength(1); num8++)
								{
									if (n != num || num8 != num)
									{
										array2[num7] = array[n, num8];
										num7++;
									}
								}
							}
							Array.Sort(array2);
							int num9 = 0;
							int num10 = array2.Length;
							int num11 = num10 / 2 - 1;
							double num12 = Convert.ToDouble(array2[num11]);
							double num13 = Convert.ToDouble(array2[num11 + 1]);
							double num14 = (num12 + num13) / 2.0;
							num9 = (int)num14;
							int[] array3 = new int[num11 + 1];
							for (int num15 = 0; num15 < num11; num15++)
							{
								if (num5 > num9)
								{
									array3[num15] = num5 - array2[array2.GetLength(0) - 1 - num15];
								}
								else
								{
									array3[num15] = array2[num15] - num5;
								}
							}
							num4 = num5;
							for (int num16 = 0; num16 < num11; num16++)
							{
								if (array3[num16] > thresholds[num16])
								{
									num4 = num9;
									break;
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							bitmap.SetPixel(j, k, Color.FromArgb(255, num4, num4, num4));
						}
					}
					return bitmap;
				}
				throw new Exception("Thresholds list size must be " + (size * size - 1) / 2 + " for used mask dimension");
			}
			throw new Exception("SDROM filter dimesion must be positive greater or equal 3.");
		}
		throw new Exception("SDROM filter dimesion must be odd.");
	}

	public Bitmap ImageSDROMFilterColor(Bitmap OriginalImage)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		int[] array = new int[4] { 20, 40, 60, 80 };
		int num = 3;
		int num2 = (int)Math.Floor(Convert.ToDouble(1));
		for (int i = num2; i < OriginalImage.Width - num2; i++)
		{
			for (int j = num2; j < OriginalImage.Height - num2; j++)
			{
				int[,] array2 = new int[num, num];
				int[,] array3 = new int[num, num];
				int[,] array4 = new int[num, num];
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				Color pixel = OriginalImage.GetPixel(i, j);
				int r = pixel.R;
				int g = pixel.G;
				int b = pixel.B;
				for (int k = i - num2; k < i + num2 + 1; k++)
				{
					for (int l = j - num2; l < j + num2 + 1; l++)
					{
						Color pixel2 = OriginalImage.GetPixel(k, l);
						double num8 = Convert.ToDouble(pixel2.R);
						double num9 = Convert.ToDouble(pixel2.G);
						double num10 = Convert.ToDouble(pixel2.B);
						array2[num4, num3] = (int)num8;
						array3[num4, num3] = (int)num9;
						array4[num4, num3] = (int)num10;
						num3++;
					}
					num4++;
					num3 = 0;
				}
				int[] array5 = new int[num * num - 1];
				int[] array6 = new int[num * num - 1];
				int[] array7 = new int[num * num - 1];
				int num11 = 0;
				for (int m = 0; m < array2.GetLength(0); m++)
				{
					for (int n = 0; n < array2.GetLength(1); n++)
					{
						if (m != num2 || n != num2)
						{
							array5[num11] = array2[m, n];
							array6[num11] = array3[m, n];
							array7[num11] = array4[m, n];
							num11++;
						}
					}
				}
				Array.Sort(array5);
				Array.Sort(array6);
				Array.Sort(array7);
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = array5.Length;
				int num16 = num15 / 2 - 1;
				double num17 = Convert.ToDouble(array5[num16]);
				double num18 = Convert.ToDouble(array5[num16 + 1]);
				double num19 = (num17 + num18) / 2.0;
				num12 = (int)num19;
				num17 = Convert.ToDouble(array6[num16]);
				num18 = Convert.ToDouble(array6[num16 + 1]);
				num19 = (num17 + num18) / 2.0;
				num13 = (int)num19;
				num17 = Convert.ToDouble(array7[num16]);
				num18 = Convert.ToDouble(array7[num16 + 1]);
				num19 = (num17 + num18) / 2.0;
				num14 = (int)num19;
				int[] array8 = new int[num16 + 1];
				int[] array9 = new int[num16 + 1];
				int[] array10 = new int[num16 + 1];
				for (int num20 = 0; num20 < num16; num20++)
				{
					if (r > num12)
					{
						array8[num20] = r - array5[array5.GetLength(0) - 1 - num20];
					}
					else
					{
						array8[num20] = array5[num20] - r;
					}
					if (g > num13)
					{
						array9[num20] = g - array6[array6.GetLength(0) - 1 - num20];
					}
					else
					{
						array9[num20] = array6[num20] - g;
					}
					if (b > num14)
					{
						array10[num20] = b - array7[array7.GetLength(0) - 1 - num20];
					}
					else
					{
						array10[num20] = array7[num20] - b;
					}
				}
				num5 = r;
				for (int num21 = 0; num21 < num16; num21++)
				{
					if (array8[num21] > array[num21])
					{
						num5 = num12;
						break;
					}
				}
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				num6 = g;
				for (int num22 = 0; num22 < num16; num22++)
				{
					if (array9[num22] > array[num22])
					{
						num6 = num13;
						break;
					}
				}
				if (num6 > 255)
				{
					num6 = 255;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				num7 = b;
				for (int num23 = 0; num23 < num16; num23++)
				{
					if (array10[num23] > array[num23])
					{
						num7 = num14;
						break;
					}
				}
				if (num7 > 255)
				{
					num7 = 255;
				}
				if (num7 < 0)
				{
					num7 = 0;
				}
				bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num6, num7));
			}
		}
		return bitmap;
	}

	public Bitmap ImageSDROMFilterColor(Bitmap OriginalImage, int size, int[] thresholds)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (size % 2 != 0)
		{
			if (size >= 3)
			{
				if (thresholds.GetLength(0) == (size * size - 1) / 2)
				{
					for (int i = 0; i < thresholds.GetLength(0) - 1; i++)
					{
						if (thresholds[i] >= thresholds[i + 1])
						{
							throw new Exception("Each next element of thresholds list must be greater then previous one.");
						}
					}
					int num = (int)Math.Floor(Convert.ToDouble(size / 2));
					for (int j = num; j < OriginalImage.Width - num; j++)
					{
						for (int k = num; k < OriginalImage.Height - num; k++)
						{
							int[,] array = new int[size, size];
							int[,] array2 = new int[size, size];
							int[,] array3 = new int[size, size];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							Color pixel = OriginalImage.GetPixel(j, k);
							int r = pixel.R;
							int g = pixel.G;
							int b = pixel.B;
							for (int l = j - num; l < j + num + 1; l++)
							{
								for (int m = k - num; m < k + num + 1; m++)
								{
									Color pixel2 = OriginalImage.GetPixel(l, m);
									double num7 = Convert.ToDouble(pixel2.R);
									double num8 = Convert.ToDouble(pixel2.G);
									double num9 = Convert.ToDouble(pixel2.B);
									array[num3, num2] = (int)num7;
									array2[num3, num2] = (int)num8;
									array3[num3, num2] = (int)num9;
									num2++;
								}
								num3++;
								num2 = 0;
							}
							int[] array4 = new int[size * size - 1];
							int[] array5 = new int[size * size - 1];
							int[] array6 = new int[size * size - 1];
							int num10 = 0;
							for (int n = 0; n < array.GetLength(0); n++)
							{
								for (int num11 = 0; num11 < array.GetLength(1); num11++)
								{
									if (n != num || num11 != num)
									{
										array4[num10] = array[n, num11];
										array5[num10] = array2[n, num11];
										array6[num10] = array3[n, num11];
										num10++;
									}
								}
							}
							Array.Sort(array4);
							Array.Sort(array5);
							Array.Sort(array6);
							int num12 = 0;
							int num13 = 0;
							int num14 = 0;
							int num15 = array4.Length;
							int num16 = num15 / 2 - 1;
							double num17 = Convert.ToDouble(array4[num16]);
							double num18 = Convert.ToDouble(array4[num16 + 1]);
							double num19 = (num17 + num18) / 2.0;
							num12 = (int)num19;
							num17 = Convert.ToDouble(array5[num16]);
							num18 = Convert.ToDouble(array5[num16 + 1]);
							num19 = (num17 + num18) / 2.0;
							num13 = (int)num19;
							num17 = Convert.ToDouble(array6[num16]);
							num18 = Convert.ToDouble(array6[num16 + 1]);
							num19 = (num17 + num18) / 2.0;
							num14 = (int)num19;
							int[] array7 = new int[num16 + 1];
							int[] array8 = new int[num16 + 1];
							int[] array9 = new int[num16 + 1];
							for (int num20 = 0; num20 < num16; num20++)
							{
								if (r > num12)
								{
									array7[num20] = r - array4[array4.GetLength(0) - 1 - num20];
								}
								else
								{
									array7[num20] = array4[num20] - r;
								}
								if (g > num13)
								{
									array8[num20] = g - array5[array5.GetLength(0) - 1 - num20];
								}
								else
								{
									array8[num20] = array5[num20] - g;
								}
								if (b > num14)
								{
									array9[num20] = b - array6[array6.GetLength(0) - 1 - num20];
								}
								else
								{
									array9[num20] = array6[num20] - b;
								}
							}
							num4 = r;
							for (int num21 = 0; num21 < num16; num21++)
							{
								if (array7[num21] > thresholds[num21])
								{
									num4 = num12;
									break;
								}
							}
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							num5 = g;
							for (int num22 = 0; num22 < num16; num22++)
							{
								if (array8[num22] > thresholds[num22])
								{
									num5 = num13;
									break;
								}
							}
							if (num5 > 255)
							{
								num5 = 255;
							}
							if (num5 < 0)
							{
								num5 = 0;
							}
							num6 = b;
							for (int num23 = 0; num23 < num16; num23++)
							{
								if (array9[num23] > thresholds[num23])
								{
									num6 = num14;
									break;
								}
							}
							if (num6 > 255)
							{
								num6 = 255;
							}
							if (num6 < 0)
							{
								num6 = 0;
							}
							bitmap.SetPixel(j, k, Color.FromArgb(255, num4, num5, num6));
						}
					}
					return bitmap;
				}
				throw new Exception("Thresholds list size must be " + (size * size - 1) / 2 + " for used mask dimension");
			}
			throw new Exception("SDROM filter dimesion must be positive greater or equal 3.");
		}
		throw new Exception("SDROM filter dimesion must be odd.");
	}

	public Bitmap ImageOpenGS(Bitmap OriginalImage)
	{
		return ImageDilatationFilterGS(ImageErosionFilterGS(OriginalImage));
	}

	public Bitmap ImageOpenGS(Bitmap OriginalImage, int size)
	{
		return ImageDilatationFilterGS(ImageErosionFilterGS(OriginalImage, size), size);
	}

	public Bitmap ImageCloseGS(Bitmap OriginalImage)
	{
		return ImageErosionFilterGS(ImageDilatationFilterGS(OriginalImage));
	}

	public Bitmap ImageCloseGS(Bitmap OriginalImage, int size)
	{
		return ImageErosionFilterGS(ImageDilatationFilterGS(OriginalImage, size), size);
	}

	public Bitmap ColorFiltration(Bitmap OriginalImage, string color)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (!(color != "Magenta") || !(color != "Yellow") || !(color != "Cyan") || !(color != "Magenta-Yellow") || !(color != "Cyan-Magenta") || !(color != "Yellow-Cyan"))
		{
			for (int i = 0; i < OriginalImage.Width; i++)
			{
				for (int j = 0; j < OriginalImage.Height; j++)
				{
					Color pixel = OriginalImage.GetPixel(i, j);
					int r = pixel.R;
					int g = pixel.G;
					int b = pixel.B;
					bitmap.SetPixel(i, j, color switch
					{
						"Magenta" => Color.FromArgb(255, r, 0, b), 
						"Yellow" => Color.FromArgb(255, r, g, 0), 
						"Cyan" => Color.FromArgb(255, 0, g, b), 
						"Magenta-Yellow" => Color.FromArgb(255, r, 0, 0), 
						"Yellow-Cyan" => Color.FromArgb(255, 0, g, 0), 
						"Cyan-Magenta" => Color.FromArgb(255, 0, 0, b), 
						_ => Color.FromArgb(255, r, g, b), 
					});
				}
			}
			return bitmap;
		}
		throw new Exception("Available color filters are: Magenta, Yellow, Cyan, Magenta-Yellow, Cyan-Magenta, Yellow-Cyan");
	}

	public Bitmap GammaCorrection(Bitmap OriginalImage, double Gamma)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (int)(255.0 * Math.Pow(Convert.ToDouble(pixel.R) / 255.0, Gamma));
				int num2 = (int)(255.0 * Math.Pow(Convert.ToDouble(pixel.G) / 255.0, Gamma));
				int num3 = (int)(255.0 * Math.Pow(Convert.ToDouble(pixel.B) / 255.0, Gamma));
				if (num > 255)
				{
					num = 255;
				}
				if (num < 0)
				{
					num = 0;
				}
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 > 255)
				{
					num3 = 255;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				Color color = Color.FromArgb(255, num, num2, num3);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap GammaCorrectionGS(Bitmap OriginalImage, double Gamma)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int value = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				value = (int)(255.0 * Math.Pow(Convert.ToDouble(value) / 255.0, Gamma));
				if (value > 255)
				{
					value = 255;
				}
				if (value < 0)
				{
					value = 0;
				}
				Color color = Color.FromArgb(255, value, value, value);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap Sepia(Bitmap OriginalImage, double Coef)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				int num = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
				int num2 = (int)((double)num + 2.0 * Coef);
				int num3 = (int)((double)num + Coef);
				int num4 = num;
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 > 255)
				{
					num3 = 255;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > 255)
				{
					num4 = 255;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				Color color = Color.FromArgb(255, num2, num3, num4);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ColorAccent(Bitmap OriginalImage, double h, double range)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		double num = (h - range / 2.0 + 360.0) % 360.0;
		double num2 = (h + range / 2.0 + 360.0) % 360.0;
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				Color pixel = OriginalImage.GetPixel(i, j);
				double[] array = rgb2hsv(pixel);
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				if (!(num <= num2))
				{
					if (array[0] > num2 && !(array[0] >= num))
					{
						int num6 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
						num3 = num6;
						num4 = num6;
						num5 = num6;
					}
					else
					{
						num3 = pixel.R;
						num4 = pixel.G;
						num5 = pixel.B;
					}
				}
				else if (array[0] > num2 || !(array[0] >= num))
				{
					int num7 = (int)((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
					num3 = num7;
					num4 = num7;
					num5 = num7;
				}
				else
				{
					num3 = pixel.R;
					num4 = pixel.G;
					num5 = pixel.B;
				}
				if (num3 > 255)
				{
					num3 = 255;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > 255)
				{
					num4 = 255;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				Color color = Color.FromArgb(255, num3, num4, num5);
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ImageKuwaharaFilterGS(Bitmap OriginalImage, int FilterSize)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (FilterSize % 2 != 0)
		{
			if (FilterSize >= 3)
			{
				int num = 2 * FilterSize - 1;
				int num2 = (int)Math.Floor(Convert.ToDouble(num / 2));
				for (int i = num2; i < OriginalImage.Width - num2; i++)
				{
					for (int j = num2; j < OriginalImage.Height - num2; j++)
					{
						int[,] array = new int[num, num];
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						OriginalImage.GetPixel(i, j);
						for (int k = i - num2; k < i + num2 + 1; k++)
						{
							for (int l = j - num2; l < j + num2 + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num6 = Convert.ToDouble((double)(int)pixel.R * 0.3 + (double)(int)pixel.G * 0.59 + (double)(int)pixel.B * 0.11);
								array[num4, num3] = (int)num6;
								num3++;
							}
							num4++;
							num3 = 0;
						}
						int[] array2 = new int[FilterSize * FilterSize];
						int[] array3 = new int[FilterSize * FilterSize];
						int[] array4 = new int[FilterSize * FilterSize];
						int[] array5 = new int[FilterSize * FilterSize];
						int num7 = 0;
						for (int m = 0; m < FilterSize; m++)
						{
							for (int n = 0; n < FilterSize; n++)
							{
								array2[num7] = array[m, n];
								num7++;
							}
						}
						int num8 = 0;
						for (int num9 = 0; num9 < FilterSize; num9++)
						{
							for (int num10 = FilterSize - 1; num10 < array.GetLength(1); num10++)
							{
								array3[num8] = array[num9, num10];
								num8++;
							}
						}
						int num11 = 0;
						for (int num12 = FilterSize - 1; num12 < array.GetLength(0); num12++)
						{
							for (int num13 = 0; num13 < FilterSize; num13++)
							{
								array4[num11] = array[num12, num13];
								num11++;
							}
						}
						int num14 = 0;
						for (int num15 = FilterSize - 1; num15 < array.GetLength(0); num15++)
						{
							for (int num16 = FilterSize - 1; num16 < array.GetLength(1); num16++)
							{
								array5[num14] = array[num15, num16];
								num14++;
							}
						}
						double[] array6 = new double[4];
						double[] array7 = new double[4];
						for (int num17 = 0; num17 < FilterSize * FilterSize; num17++)
						{
							array6[0] += Convert.ToDouble(array2[num17]) / (double)(FilterSize * FilterSize);
							array6[1] += Convert.ToDouble(array3[num17]) / (double)(FilterSize * FilterSize);
							array6[2] += Convert.ToDouble(array4[num17]) / (double)(FilterSize * FilterSize);
							array6[3] += Convert.ToDouble(array5[num17]) / (double)(FilterSize * FilterSize);
						}
						for (int num18 = 0; num18 < FilterSize * FilterSize; num18++)
						{
							array7[0] += Math.Pow(Convert.ToDouble(array2[num18]) - array6[0], 2.0) / (double)(FilterSize * FilterSize);
							array7[1] += Math.Pow(Convert.ToDouble(array3[num18]) - array6[1], 2.0) / (double)(FilterSize * FilterSize);
							array7[2] += Math.Pow(Convert.ToDouble(array4[num18]) - array6[2], 2.0) / (double)(FilterSize * FilterSize);
							array7[3] += Math.Pow(Convert.ToDouble(array5[num18]) - array6[3], 2.0) / (double)(FilterSize * FilterSize);
						}
						int num19 = Array.IndexOf(array7, array7.Min());
						num5 = (int)array6[num19];
						if (num5 > 255)
						{
							num5 = 255;
						}
						if (num5 < 0)
						{
							num5 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num5, num5));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter size must be positive greater then 2.");
		}
		throw new Exception("Filter size must be odd.");
	}

	public Bitmap ImageKuwaharaFilterColor(Bitmap OriginalImage, int FilterSize)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (FilterSize % 2 != 0)
		{
			if (FilterSize >= 3)
			{
				int num = 2 * FilterSize - 1;
				int num2 = (int)Math.Floor(Convert.ToDouble(num / 2));
				for (int i = num2; i < OriginalImage.Width - num2; i++)
				{
					for (int j = num2; j < OriginalImage.Height - num2; j++)
					{
						int[,,] array = new int[3, num, num];
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						OriginalImage.GetPixel(i, j);
						for (int k = i - num2; k < i + num2 + 1; k++)
						{
							for (int l = j - num2; l < j + num2 + 1; l++)
							{
								Color pixel = OriginalImage.GetPixel(k, l);
								double num8 = Convert.ToDouble(pixel.R);
								double num9 = Convert.ToDouble(pixel.G);
								double num10 = Convert.ToDouble(pixel.B);
								array[0, num4, num3] = (int)num8;
								array[1, num4, num3] = (int)num9;
								array[2, num4, num3] = (int)num10;
								num3++;
							}
							num4++;
							num3 = 0;
						}
						int[,] array2 = new int[3, FilterSize * FilterSize];
						int[,] array3 = new int[3, FilterSize * FilterSize];
						int[,] array4 = new int[3, FilterSize * FilterSize];
						int[,] array5 = new int[3, FilterSize * FilterSize];
						int num11 = 0;
						for (int m = 0; m < FilterSize; m++)
						{
							for (int n = 0; n < FilterSize; n++)
							{
								array2[0, num11] = array[0, m, n];
								array2[1, num11] = array[1, m, n];
								array2[2, num11] = array[2, m, n];
								num11++;
							}
						}
						int num12 = 0;
						for (int num13 = 0; num13 < FilterSize; num13++)
						{
							for (int num14 = FilterSize - 1; num14 < array.GetLength(1); num14++)
							{
								array3[0, num12] = array[0, num13, num14];
								array3[1, num12] = array[1, num13, num14];
								array3[2, num12] = array[2, num13, num14];
								num12++;
							}
						}
						int num15 = 0;
						for (int num16 = FilterSize - 1; num16 < array.GetLength(0); num16++)
						{
							for (int num17 = 0; num17 < FilterSize; num17++)
							{
								array4[0, num15] = array[0, num16, num17];
								array4[1, num15] = array[1, num16, num17];
								array4[2, num15] = array[2, num16, num17];
								num15++;
							}
						}
						int num18 = 0;
						for (int num19 = FilterSize - 1; num19 < array.GetLength(0); num19++)
						{
							for (int num20 = FilterSize - 1; num20 < array.GetLength(1); num20++)
							{
								array5[0, num18] = array[0, num19, num20];
								array5[1, num18] = array[1, num19, num20];
								array5[2, num18] = array[2, num19, num20];
								num18++;
							}
						}
						double[] array6 = new double[4];
						double[] array7 = new double[4];
						double[] array8 = new double[4];
						double[] array9 = new double[4];
						double[] array10 = new double[4];
						double[] array11 = new double[4];
						for (int num21 = 0; num21 < FilterSize * FilterSize; num21++)
						{
							array6[0] += Convert.ToDouble(array2[0, num21]) / (double)(FilterSize * FilterSize);
							array6[1] += Convert.ToDouble(array3[0, num21]) / (double)(FilterSize * FilterSize);
							array6[2] += Convert.ToDouble(array4[0, num21]) / (double)(FilterSize * FilterSize);
							array6[3] += Convert.ToDouble(array5[0, num21]) / (double)(FilterSize * FilterSize);
							array7[0] += Convert.ToDouble(array2[1, num21]) / (double)(FilterSize * FilterSize);
							array7[1] += Convert.ToDouble(array3[1, num21]) / (double)(FilterSize * FilterSize);
							array7[2] += Convert.ToDouble(array4[1, num21]) / (double)(FilterSize * FilterSize);
							array7[3] += Convert.ToDouble(array5[1, num21]) / (double)(FilterSize * FilterSize);
							array8[0] += Convert.ToDouble(array2[2, num21]) / (double)(FilterSize * FilterSize);
							array8[1] += Convert.ToDouble(array3[2, num21]) / (double)(FilterSize * FilterSize);
							array8[2] += Convert.ToDouble(array4[2, num21]) / (double)(FilterSize * FilterSize);
							array8[3] += Convert.ToDouble(array5[2, num21]) / (double)(FilterSize * FilterSize);
						}
						for (int num22 = 0; num22 < FilterSize * FilterSize; num22++)
						{
							array9[0] += Math.Pow(Convert.ToDouble(array2[0, num22]) - array6[0], 2.0) / (double)(FilterSize * FilterSize);
							array9[1] += Math.Pow(Convert.ToDouble(array3[0, num22]) - array6[1], 2.0) / (double)(FilterSize * FilterSize);
							array9[2] += Math.Pow(Convert.ToDouble(array4[0, num22]) - array6[2], 2.0) / (double)(FilterSize * FilterSize);
							array9[3] += Math.Pow(Convert.ToDouble(array5[0, num22]) - array6[3], 2.0) / (double)(FilterSize * FilterSize);
							array10[0] += Math.Pow(Convert.ToDouble(array2[1, num22]) - array7[0], 2.0) / (double)(FilterSize * FilterSize);
							array10[1] += Math.Pow(Convert.ToDouble(array3[1, num22]) - array7[1], 2.0) / (double)(FilterSize * FilterSize);
							array10[2] += Math.Pow(Convert.ToDouble(array4[1, num22]) - array7[2], 2.0) / (double)(FilterSize * FilterSize);
							array10[3] += Math.Pow(Convert.ToDouble(array5[1, num22]) - array7[3], 2.0) / (double)(FilterSize * FilterSize);
							array11[0] += Math.Pow(Convert.ToDouble(array2[2, num22]) - array8[0], 2.0) / (double)(FilterSize * FilterSize);
							array11[1] += Math.Pow(Convert.ToDouble(array3[2, num22]) - array8[1], 2.0) / (double)(FilterSize * FilterSize);
							array11[2] += Math.Pow(Convert.ToDouble(array4[2, num22]) - array8[2], 2.0) / (double)(FilterSize * FilterSize);
							array11[3] += Math.Pow(Convert.ToDouble(array5[2, num22]) - array8[3], 2.0) / (double)(FilterSize * FilterSize);
						}
						int num23 = Array.IndexOf(array9, array9.Min());
						int num24 = Array.IndexOf(array10, array10.Min());
						int num25 = Array.IndexOf(array11, array11.Min());
						num5 = (int)array6[num23];
						if (num5 > 255)
						{
							num5 = 255;
						}
						if (num5 < 0)
						{
							num5 = 0;
						}
						num6 = (int)array7[num24];
						if (num6 > 255)
						{
							num6 = 255;
						}
						if (num6 < 0)
						{
							num6 = 0;
						}
						num7 = (int)array8[num25];
						if (num7 > 255)
						{
							num7 = 255;
						}
						if (num7 < 0)
						{
							num7 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num5, num6, num7));
					}
				}
				return bitmap;
			}
			throw new Exception("Filter size must be positive greater then 2.");
		}
		throw new Exception("Filter size must be odd.");
	}

	public Bitmap TiltShift(Bitmap OriginalImage)
	{
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		Bitmap bitmap = new Bitmap(width, height);
		int num = height / 2;
		int num2 = num + num / 2;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				if (j < num || j > num2)
				{
					if (j >= num)
					{
						if (j <= num2)
						{
							continue;
						}
						double num3 = 0.1 + 5.9 * Convert.ToDouble(j - num2) / Convert.ToDouble(num);
						List<double> list = new List<double>();
						for (int k = 0; k < 1000; k++)
						{
							double num4 = Convert.ToDouble(k);
							double num5 = 1.0 / (Math.Sqrt(Math.PI * 2.0) * num3) * Math.Exp((0.0 - num4) * num4 / (2.0 * num3 * num3));
							if (num5 < 0.003)
							{
								break;
							}
							list.Add(num5);
						}
						double num6 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).R);
						double num7 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).G);
						double num8 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).B);
						double num9 = list[0];
						for (int l = 1; l < list.Count; l++)
						{
							num9 += 2.0 * list[l];
						}
						for (int m = 1; m < list.Count; m++)
						{
							int num10 = j - m;
							int num11 = j + m;
							if (num10 >= 0)
							{
								if (num11 < height)
								{
									num6 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num10).R) + Convert.ToDouble(OriginalImage.GetPixel(i, num11).R));
									num7 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num10).G) + Convert.ToDouble(OriginalImage.GetPixel(i, num11).G));
									num8 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num10).B) + Convert.ToDouble(OriginalImage.GetPixel(i, num11).B));
								}
								else
								{
									num11 = num11 + m - height + 1;
								}
							}
							else
							{
								num10 = Math.Abs(num10);
							}
						}
						int num12 = (int)(num6 / num9);
						int num13 = (int)(num7 / num9);
						int num14 = (int)(num8 / num9);
						if (num12 > 255)
						{
							num12 = 255;
						}
						if (num12 < 0)
						{
							num12 = 0;
						}
						if (num13 > 255)
						{
							num13 = 255;
						}
						if (num13 < 0)
						{
							num13 = 0;
						}
						if (num14 > 255)
						{
							num14 = 255;
						}
						if (num14 < 0)
						{
							num14 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num12, num13, num14));
						continue;
					}
					double num15 = 0.1 + 5.9 * Convert.ToDouble(num - j) / Convert.ToDouble(num);
					List<double> list2 = new List<double>();
					for (int n = 0; n < 1000; n++)
					{
						double num16 = Convert.ToDouble(n);
						double num17 = 1.0 / (Math.Sqrt(Math.PI * 2.0) * num15) * Math.Exp((0.0 - num16) * num16 / (2.0 * num15 * num15));
						if (num17 < 0.003)
						{
							break;
						}
						list2.Add(num17);
					}
					double num18 = list2[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).R);
					double num19 = list2[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).G);
					double num20 = list2[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).B);
					double num21 = list2[0];
					for (int num22 = 1; num22 < list2.Count; num22++)
					{
						num21 += 2.0 * list2[num22];
					}
					for (int num23 = 1; num23 < list2.Count; num23++)
					{
						int num24 = j - num23;
						int num25 = j + num23;
						if (num24 >= 0)
						{
							if (num25 < height)
							{
								num18 += list2[num23] * (Convert.ToDouble(OriginalImage.GetPixel(i, num24).R) + Convert.ToDouble(OriginalImage.GetPixel(i, num25).R));
								num19 += list2[num23] * (Convert.ToDouble(OriginalImage.GetPixel(i, num24).G) + Convert.ToDouble(OriginalImage.GetPixel(i, num25).G));
								num20 += list2[num23] * (Convert.ToDouble(OriginalImage.GetPixel(i, num24).B) + Convert.ToDouble(OriginalImage.GetPixel(i, num25).B));
							}
							else
							{
								num25 = num25 + num23 - height + 1;
							}
						}
						else
						{
							num24 = Math.Abs(num24);
						}
					}
					int num26 = (int)(num18 / num21);
					int num27 = (int)(num19 / num21);
					int num28 = (int)(num20 / num21);
					if (num26 > 255)
					{
						num26 = 255;
					}
					if (num26 < 0)
					{
						num26 = 0;
					}
					if (num27 > 255)
					{
						num27 = 255;
					}
					if (num27 < 0)
					{
						num27 = 0;
					}
					if (num28 > 255)
					{
						num28 = 255;
					}
					if (num28 < 0)
					{
						num28 = 0;
					}
					bitmap.SetPixel(i, j, Color.FromArgb(255, num26, num27, num28));
				}
				else
				{
					bitmap.SetPixel(i, j, OriginalImage.GetPixel(i, j));
				}
			}
		}
		return bitmap;
	}

	public Bitmap Blurring(Bitmap OriginalImage, int X, int Y, double r)
	{
		int width = OriginalImage.Width;
		int height = OriginalImage.Height;
		if (X >= 0 && X < width && Y >= 0 && Y < height)
		{
			Bitmap bitmap = new Bitmap(width, height);
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					double num = Math.Abs(Convert.ToDouble(i) - Convert.ToDouble(X));
					double num2 = Math.Abs(Convert.ToDouble(j) - Convert.ToDouble(Y));
					double num3 = Math.Sqrt(num * num + num2 * num2);
					if (!(num3 <= r))
					{
						double num4 = 0.1 + 5.9 * Convert.ToDouble(num3) / Convert.ToDouble(2.0 * r);
						List<double> list = new List<double>();
						for (int k = 0; k < 1000; k++)
						{
							double num5 = Convert.ToDouble(k);
							double num6 = 1.0 / (Math.Sqrt(Math.PI * 2.0) * num4) * Math.Exp((0.0 - num5) * num5 / (2.0 * num4 * num4));
							if (num6 < 0.003)
							{
								break;
							}
							list.Add(num6);
						}
						double num7 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).R);
						double num8 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).G);
						double num9 = list[0] * Convert.ToDouble(OriginalImage.GetPixel(i, j).B);
						double num10 = list[0];
						for (int l = 1; l < list.Count; l++)
						{
							num10 += 2.0 * list[l];
						}
						for (int m = 1; m < list.Count; m++)
						{
							int num11 = j - m;
							int num12 = j + m;
							if (num11 >= 0)
							{
								if (num12 < height)
								{
									num7 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num11).R) + Convert.ToDouble(OriginalImage.GetPixel(i, num12).R));
									num8 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num11).G) + Convert.ToDouble(OriginalImage.GetPixel(i, num12).G));
									num9 += list[m] * (Convert.ToDouble(OriginalImage.GetPixel(i, num11).B) + Convert.ToDouble(OriginalImage.GetPixel(i, num12).B));
								}
								else
								{
									num12 = num12 + m - height + 1;
								}
							}
							else
							{
								num11 = Math.Abs(num11);
							}
						}
						int num13 = (int)(num7 / num10);
						int num14 = (int)(num8 / num10);
						int num15 = (int)(num9 / num10);
						if (num13 > 255)
						{
							num13 = 255;
						}
						if (num13 < 0)
						{
							num13 = 0;
						}
						if (num14 > 255)
						{
							num14 = 255;
						}
						if (num14 < 0)
						{
							num14 = 0;
						}
						if (num15 > 255)
						{
							num15 = 255;
						}
						if (num15 < 0)
						{
							num15 = 0;
						}
						bitmap.SetPixel(i, j, Color.FromArgb(255, num13, num14, num15));
					}
					else
					{
						bitmap.SetPixel(i, j, OriginalImage.GetPixel(i, j));
					}
				}
			}
			return bitmap;
		}
		throw new Exception("Center of sharp region must be in dimensions of image");
	}

	public Bitmap OilPaint(Bitmap OriginalImage, int R, int Level)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		if (Level >= 1 && Level <= 255)
		{
			if (R % 2 != 0)
			{
				if (R >= 3)
				{
					int num = (int)Math.Floor(Convert.ToDouble(R / 2));
					for (int i = num; i < OriginalImage.Width - num; i++)
					{
						for (int j = num; j < OriginalImage.Height - num; j++)
						{
							double[,,] array = new double[3, R, R];
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							for (int k = i - num; k < i + num + 1; k++)
							{
								for (int l = j - num; l < j + num + 1; l++)
								{
									Color pixel = OriginalImage.GetPixel(k, l);
									double num7 = Convert.ToDouble(pixel.R);
									double num8 = Convert.ToDouble(pixel.G);
									double num9 = Convert.ToDouble(pixel.B);
									array[0, num2, num3] = (int)num7;
									array[1, num2, num3] = (int)num8;
									array[2, num2, num3] = (int)num9;
									num3++;
								}
								num2++;
								num3 = 0;
							}
							int[] array2 = new int[256];
							int[] array3 = new int[256];
							int[] array4 = new int[256];
							int[] array5 = new int[256];
							for (int m = 0; m < R; m++)
							{
								for (int n = 0; n < R; n++)
								{
									int num10 = (int)((array[0, m, n] + array[1, m, n] + array[2, m, n]) / 3.0 * Convert.ToDouble(Level) / 255.0);
									array5[num10]++;
									array2[num10] += (int)array[0, m, n];
									array3[num10] += (int)array[1, m, n];
									array4[num10] += (int)array[2, m, n];
								}
							}
							int num11 = 0;
							int num12 = 0;
							for (int num13 = 0; num13 < 256; num13++)
							{
								if (array5[num13] > num11)
								{
									num11 = array5[num13];
									num12 = num13;
								}
							}
							num4 = array2[num12] / num11;
							num5 = array3[num12] / num11;
							num6 = array4[num12] / num11;
							if (num4 > 255)
							{
								num4 = 255;
							}
							if (num4 < 0)
							{
								num4 = 0;
							}
							if (num5 > 255)
							{
								num5 = 255;
							}
							if (num5 < 0)
							{
								num5 = 0;
							}
							if (num6 > 255)
							{
								num6 = 255;
							}
							if (num6 < 0)
							{
								num6 = 0;
							}
							bitmap.SetPixel(i, j, Color.FromArgb(255, num4, num5, num6));
						}
					}
					return bitmap;
				}
				throw new Exception("Filter mask dimesion must be greater or equal 3.");
			}
			throw new Exception("Filter mask dimesion must be odd.");
		}
		throw new Exception("Available intensity levels must be between 1 and 255");
	}

	public Bitmap Cartoon(Bitmap OriginalImage, int R, int Level, int InverseThreshold)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		Bitmap bitmap2 = OilPaint(OriginalImage, R, Level);
		Bitmap bitmap3 = ToBlackwhiteInverse(ImageSobelFilterGS(OriginalImage), InverseThreshold);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				if (bitmap3.GetPixel(i, j).R != byte.MaxValue)
				{
					bitmap.SetPixel(i, j, bitmap3.GetPixel(i, j));
				}
				else
				{
					bitmap.SetPixel(i, j, bitmap2.GetPixel(i, j));
				}
			}
		}
		return bitmap;
	}

	public Bitmap Cartoon(Bitmap OriginalImage, int R, int Level, int InverseThreshold, int[,] EdgeFilter)
	{
		Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
		Bitmap bitmap2 = OilPaint(OriginalImage, R, Level);
		Bitmap bitmap3 = ToBlackwhiteInverse(ImageFilterGS(OriginalImage, EdgeFilter), InverseThreshold);
		for (int i = 0; i < OriginalImage.Width; i++)
		{
			for (int j = 0; j < OriginalImage.Height; j++)
			{
				if (bitmap3.GetPixel(i, j).R != byte.MaxValue)
				{
					bitmap.SetPixel(i, j, bitmap3.GetPixel(i, j));
				}
				else
				{
					bitmap.SetPixel(i, j, bitmap2.GetPixel(i, j));
				}
			}
		}
		return bitmap;
	}

	public Bitmap SketchCharcoal(Bitmap OriginalImage)
	{
		Bitmap originalImage = ImageMedianFilterGS(OriginalImage, 5);
		originalImage = ImageSobelFilterGS(originalImage);
		originalImage = InverseImage(originalImage, 80);
		return ImageMedianFilterGS(originalImage, 5);
	}

	public Bitmap Sketch(Bitmap OriginalImage)
	{
		Bitmap originalImage = OriginalImage;
		originalImage = ImageFilterGS(originalImage, LaplaceF1());
		originalImage = ToBlackwhiteInverse(originalImage, 35);
		return ImageSDROMFilterGS(originalImage);
	}
}
