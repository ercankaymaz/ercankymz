using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using buClass;

namespace buCore;

public class buImage
{
	public buImage()
	{
		if (!buVector.smethod_0("buImage"))
		{
			throw new RegisterException("buImage");
		}
	}

	public static Color InvertColor(Color BaseColor)
	{
		buVector.smethod_0("buImage");
		return Color.FromArgb(255 - BaseColor.R, 255 - BaseColor.G, 255 - BaseColor.B);
	}

	public static Color InvertColorNoGray(Color BaseColor)
	{
		byte red = (byte)(~BaseColor.R);
		byte green = (byte)(~BaseColor.G);
		byte blue = (byte)(~BaseColor.B);
		Color result = Color.FromArgb(BaseColor.A, red, green, blue);
		int num = Math.Abs(Convert.ToInt32(BaseColor.R) - Convert.ToInt32(result.R));
		int num2 = Math.Abs(Convert.ToInt32(BaseColor.G) - Convert.ToInt32(result.G));
		int num3 = Math.Abs(Convert.ToInt32(BaseColor.B) - Convert.ToInt32(result.B));
		if (num < 2 && num2 < 2 && num3 < 2)
		{
			result = Color.Black;
		}
		return result;
	}

	public static void GetKnowColorToList(ref List<Color> ColorList)
	{
		ColorList.Clear();
		string[] names = Enum.GetNames(typeof(KnownColor));
		foreach (string name in names)
		{
			Color item = Color.FromName(name);
			ColorList.Add(item);
		}
	}

	public static Color ColorFromBool(bool State, Color TrueColor, Color FalseColor)
	{
		buVector.smethod_0("");
		if (!State)
		{
			return FalseColor;
		}
		return TrueColor;
	}

	public static void GetPopularKnowColorToList(ref List<Color> ColorList)
	{
		ColorList.Clear();
		ColorList.Add(Color.Red);
		ColorList.Add(Color.Blue);
		ColorList.Add(Color.Green);
		ColorList.Add(Color.Gold);
		ColorList.Add(Color.DarkOrange);
		ColorList.Add(Color.Cyan);
		ColorList.Add(Color.Brown);
		ColorList.Add(Color.Lime);
		ColorList.Add(Color.Magenta);
		ColorList.Add(Color.Linen);
		ColorList.Add(Color.Tan);
		ColorList.Add(Color.Pink);
		ColorList.Add(Color.AliceBlue);
		ColorList.Add(Color.Turquoise);
		ColorList.Add(Color.Purple);
		ColorList.Add(Color.DarkBlue);
		ColorList.Add(Color.Beige);
		ColorList.Add(Color.RosyBrown);
		ColorList.Add(Color.LightSalmon);
		ColorList.Add(Color.AntiqueWhite);
		ColorList.Add(Color.LightSeaGreen);
		ColorList.Add(Color.Aqua);
		ColorList.Add(Color.LightSkyBlue);
		ColorList.Add(Color.Aquamarine);
		ColorList.Add(Color.Azure);
		ColorList.Add(Color.LightSteelBlue);
		ColorList.Add(Color.LightYellow);
		ColorList.Add(Color.Bisque);
		ColorList.Add(Color.LimeGreen);
		ColorList.Add(Color.BlanchedAlmond);
		ColorList.Add(Color.BlueViolet);
		ColorList.Add(Color.Maroon);
		ColorList.Add(Color.MediumAquamarine);
		ColorList.Add(Color.BurlyWood);
		ColorList.Add(Color.MediumBlue);
		ColorList.Add(Color.CadetBlue);
		ColorList.Add(Color.MediumOrchid);
		ColorList.Add(Color.Chartreuse);
		ColorList.Add(Color.MediumPurple);
		ColorList.Add(Color.Chocolate);
		ColorList.Add(Color.MediumSeaGreen);
		ColorList.Add(Color.Coral);
		ColorList.Add(Color.MediumSlateBlue);
		ColorList.Add(Color.CornflowerBlue);
		ColorList.Add(Color.MediumSpringGreen);
		ColorList.Add(Color.Cornsilk);
		ColorList.Add(Color.MediumTurquoise);
		ColorList.Add(Color.Crimson);
		ColorList.Add(Color.MediumVioletRed);
		ColorList.Add(Color.MidnightBlue);
		ColorList.Add(Color.MintCream);
		ColorList.Add(Color.DarkCyan);
		ColorList.Add(Color.MistyRose);
		ColorList.Add(Color.DarkGoldenrod);
		ColorList.Add(Color.Moccasin);
		ColorList.Add(Color.NavajoWhite);
		ColorList.Add(Color.DarkGreen);
		ColorList.Add(Color.Navy);
		ColorList.Add(Color.DarkKhaki);
		ColorList.Add(Color.OldLace);
		ColorList.Add(Color.DarkMagenta);
		ColorList.Add(Color.Olive);
		ColorList.Add(Color.DarkOliveGreen);
		ColorList.Add(Color.OliveDrab);
		ColorList.Add(Color.Orange);
		ColorList.Add(Color.DarkOrchid);
		ColorList.Add(Color.OrangeRed);
		ColorList.Add(Color.DarkRed);
		ColorList.Add(Color.Orchid);
		ColorList.Add(Color.DarkSalmon);
		ColorList.Add(Color.PaleGoldenrod);
		ColorList.Add(Color.DarkSeaGreen);
		ColorList.Add(Color.PaleGreen);
		ColorList.Add(Color.DarkSlateBlue);
		ColorList.Add(Color.PaleTurquoise);
		ColorList.Add(Color.PaleVioletRed);
		ColorList.Add(Color.DarkTurquoise);
		ColorList.Add(Color.PapayaWhip);
		ColorList.Add(Color.DarkViolet);
		ColorList.Add(Color.PeachPuff);
		ColorList.Add(Color.DeepPink);
		ColorList.Add(Color.Peru);
		ColorList.Add(Color.DeepSkyBlue);
		ColorList.Add(Color.Plum);
		ColorList.Add(Color.DodgerBlue);
		ColorList.Add(Color.PowderBlue);
		ColorList.Add(Color.Firebrick);
		ColorList.Add(Color.FloralWhite);
		ColorList.Add(Color.ForestGreen);
		ColorList.Add(Color.Fuchsia);
		ColorList.Add(Color.RoyalBlue);
		ColorList.Add(Color.Gainsboro);
		ColorList.Add(Color.SaddleBrown);
		ColorList.Add(Color.GhostWhite);
		ColorList.Add(Color.Salmon);
		ColorList.Add(Color.SandyBrown);
		ColorList.Add(Color.Goldenrod);
		ColorList.Add(Color.SeaGreen);
		ColorList.Add(Color.SeaShell);
		ColorList.Add(Color.Sienna);
		ColorList.Add(Color.GreenYellow);
		ColorList.Add(Color.Silver);
		ColorList.Add(Color.Honeydew);
		ColorList.Add(Color.SkyBlue);
		ColorList.Add(Color.HotPink);
		ColorList.Add(Color.SlateBlue);
		ColorList.Add(Color.IndianRed);
		ColorList.Add(Color.Indigo);
		ColorList.Add(Color.Snow);
		ColorList.Add(Color.Ivory);
		ColorList.Add(Color.SpringGreen);
		ColorList.Add(Color.Khaki);
		ColorList.Add(Color.SteelBlue);
		ColorList.Add(Color.Lavender);
		ColorList.Add(Color.LavenderBlush);
		ColorList.Add(Color.Teal);
		ColorList.Add(Color.Thistle);
		ColorList.Add(Color.LemonChiffon);
		ColorList.Add(Color.Tomato);
		ColorList.Add(Color.LightBlue);
		ColorList.Add(Color.LightCoral);
		ColorList.Add(Color.Violet);
		ColorList.Add(Color.LightCyan);
		ColorList.Add(Color.Wheat);
		ColorList.Add(Color.LightGoldenrodYellow);
		ColorList.Add(Color.LightGreen);
		ColorList.Add(Color.WhiteSmoke);
		ColorList.Add(Color.Yellow);
		ColorList.Add(Color.LightPink);
		ColorList.Add(Color.YellowGreen);
	}

	public static void GetKnowColorToList(ref List<Color> ColorList, List<Color> Exceptions)
	{
		ColorList.Clear();
		string[] names = Enum.GetNames(typeof(KnownColor));
		foreach (string name in names)
		{
			bool flag = true;
			Color color = Color.FromName(name);
			for (int j = 0; j <= Exceptions.Count - 1; j++)
			{
				if (Exceptions[j] == color)
				{
					flag = false;
				}
			}
			if (flag)
			{
				ColorList.Add(color);
			}
		}
	}

	public static string GetColorKnownName(Color clr)
	{
		if (!clr.IsKnownColor)
		{
			return clr.ToString().Replace("Color", "");
		}
		return clr.ToKnownColor().ToString();
	}

	public static Color ColorToneChange(Color BaseColor, double factor)
	{
		double num = (((double)(int)BaseColor.R * factor <= 255.0) ? ((double)(int)BaseColor.R * factor) : 255.0);
		double num2 = (((double)(int)BaseColor.G * factor <= 255.0) ? ((double)(int)BaseColor.G * factor) : 255.0);
		double num3 = (((double)(int)BaseColor.B * factor <= 255.0) ? ((double)(int)BaseColor.B * factor) : 255.0);
		return Color.FromArgb(BaseColor.A, (int)num, (int)num2, (int)num3);
	}

	public static void GetImageSizeWithFilename(string FileName, ref int Width, ref int Height)
	{
		Image image = Image.FromFile(FileName);
		Width = image.Width;
		Height = image.Height;
	}

	public static Bitmap ResizeImage(Image image, int width, int height)
	{
		Rectangle destRect = new Rectangle(0, 0, width, height);
		Bitmap bitmap = new Bitmap(width, height);
		bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			using ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
			graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
		}
		return bitmap;
	}

	public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
	{
		Bitmap bitmap = new Bitmap(width, height);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.DrawImage(bmp, 0, 0, width, height);
		}
		return bitmap;
	}

	public static Bitmap CropBitmap(Bitmap bmp, int x, int y, int width, int height)
	{
		Rectangle srcRect = new Rectangle(x, y, width, height);
		Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
		return bitmap;
	}

	public static Bitmap Rotate(Bitmap OriginalImage, double Angle)
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

	public static bool isColorSimilar(Color BaseColor, Color SimilarColor, double Limit)
	{
		double num = Convert.ToDouble(BaseColor.R);
		double num2 = Convert.ToDouble(BaseColor.G);
		double num3 = Convert.ToDouble(BaseColor.B);
		double num4 = Math.Pow(Convert.ToDouble(SimilarColor.R) - num, 2.0);
		double num5 = Math.Pow(Convert.ToDouble(SimilarColor.G) - num2, 2.0);
		double num6 = Math.Pow(Convert.ToDouble(SimilarColor.B) - num3, 2.0);
		double num7 = Math.Sqrt(num6 + num5 + num4);
		if (num7 != 0.0)
		{
			if (!(num7 < Limit))
			{
				return false;
			}
			Limit = num7;
			return true;
		}
		return true;
	}

	public static bool isColorSAme(Color BaseColor, Color refColor)
	{
		if (BaseColor.A != refColor.A || BaseColor.R != refColor.R || BaseColor.G != refColor.G || BaseColor.B != refColor.B)
		{
			return false;
		}
		return true;
	}
}
