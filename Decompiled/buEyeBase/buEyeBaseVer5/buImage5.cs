using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5;

public class buImage5
{
	public static List<Color> ColorList = new List<Color>
	{
		Color.Blue,
		Color.Green,
		Color.Cyan,
		Color.Magenta,
		Color.Yellow,
		Color.Pink,
		Color.Brown,
		Color.Lime,
		Color.Orange,
		Color.Khaki,
		Color.Linen,
		Color.Firebrick,
		Color.IndianRed,
		Color.LightSalmon,
		Color.Gold,
		Color.YellowGreen,
		Color.PaleGreen,
		Color.Turquoise,
		Color.LightCyan,
		Color.Teal,
		Color.SteelBlue,
		Color.Navy,
		Color.Orchid,
		Color.DeepPink,
		Color.Coral,
		Color.DarkKhaki,
		Color.FloralWhite,
		Color.MediumAquamarine,
		Color.Peru
	};

	public static List<Color> ColorList50UnPopular = new List<Color>
	{
		Color.SteelBlue,
		Color.Lavender,
		Color.CadetBlue,
		Color.CornflowerBlue,
		Color.Crimson,
		Color.DarkGoldenrod,
		Color.DarkMagenta,
		Color.DarkSalmon,
		Color.DarkSlateBlue,
		Color.DeepSkyBlue,
		Color.FloralWhite,
		Color.HotPink,
		Color.Khaki,
		Color.Coral,
		Color.LemonChiffon,
		Color.LightSteelBlue,
		Color.Maroon,
		Color.MediumOrchid,
		Color.MediumSeaGreen,
		Color.MistyRose,
		Color.Olive,
		Color.PaleGreen,
		Color.PaleTurquoise,
		Color.PeachPuff,
		Color.Peru,
		Color.Plum,
		Color.PowderBlue,
		Color.RosyBrown,
		Color.RoyalBlue,
		Color.Sienna,
		Color.SlateGray,
		Color.Tan,
		Color.Teal,
		Color.Thistle,
		Color.Tomato,
		Color.Violet,
		Color.Wheat,
		Color.YellowGreen,
		Color.OliveDrab,
		Color.OldLace,
		Color.LightYellow,
		Color.Honeydew,
		Color.LawnGreen,
		Color.LimeGreen,
		Color.LightSalmon,
		Color.Indigo,
		Color.DarkGray,
		Color.Firebrick,
		Color.MediumPurple,
		Color.MediumVioletRed,
		Color.AliceBlue
	};

	public buImage5()
	{
		if (!buVector5.smethod_0("buImage5"))
		{
			throw new RegisterException("buImage5");
		}
	}

	public static Bitmap CropBitmap(Bitmap bmp, int x, int y, int width, int height)
	{
		Rectangle srcRect = new Rectangle(x, y, width, height);
		Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
		return bitmap;
	}

	public static Bitmap CropBitmap(Image bmp, int x, int y, int width, int height)
	{
		Rectangle srcRect = new Rectangle(x, y, width, height);
		Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
		return bitmap;
	}

	public static Color ColorFromBool(bool State, Color TrueColor, Color FalseColor)
	{
		if (!State)
		{
			return FalseColor;
		}
		return TrueColor;
	}

	public static Color InvertColor(Color BaseColor)
	{
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

	public static string GetColorKnownName(Color clr)
	{
		if (!clr.IsKnownColor)
		{
			return clr.ToString();
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
				double num7 = (num - (double)i) * (num - (double)i);
				double num8 = (num2 - (double)j) * (num2 - (double)j);
				double num9 = Math.Sqrt(num7 + num8);
				num5 = Convert.ToInt32(num + Math.Cos(num4) * num9);
				num6 = Convert.ToInt32(num2 + Math.Sin(num4) * num9);
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

	public static Image RotateImage(Image bmp, double angle)
	{
		float num = bmp.Height;
		float num2 = bmp.Width;
		int num3 = Convert.ToInt32(Math.Floor(Math.Sqrt(num * num + num2 * num2)));
		Bitmap bitmap = new Bitmap(num3, num3);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.TranslateTransform((float)bitmap.Width / 2f, (float)bitmap.Height / 2f);
			graphics.RotateTransform((float)angle);
			graphics.TranslateTransform((0f - (float)bitmap.Width) / 2f, (0f - (float)bitmap.Height) / 2f);
			graphics.DrawImage(bmp, ((float)num3 - num2) / 2f, ((float)num3 - num) / 2f, num2, num);
		}
		return bitmap;
	}

	public static Bitmap RotateImage(Bitmap bmp, double angle)
	{
		float num = bmp.Height;
		float num2 = bmp.Width;
		int num3 = Convert.ToInt32(Math.Floor(Math.Sqrt(num * num + num2 * num2)));
		Bitmap bitmap = new Bitmap((int)num2, (int)num);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.TranslateTransform((float)bitmap.Width / 2f, (float)bitmap.Height / 2f);
			graphics.RotateTransform((float)angle);
			graphics.TranslateTransform((0f - (float)bitmap.Width) / 2f, (0f - (float)bitmap.Height) / 2f);
			graphics.DrawImage(bmp, ((float)num3 - num2) / 2f, ((float)num3 - num) / 2f, num2, num);
		}
		return bitmap;
	}

	public static bool isColorSame(Color BaseColor, Color SimilarColor)
	{
		if (BaseColor.R != SimilarColor.R || BaseColor.G != SimilarColor.G || BaseColor.B != SimilarColor.B || BaseColor.A != SimilarColor.A)
		{
			return false;
		}
		return true;
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

	public static Color Darken(Color c, float level)
	{
		return Color.FromArgb(c.A, (int)((float)(int)c.R / level), (int)((float)(int)c.G / level), (int)((float)(int)c.B / level));
	}

	public static void SetSimilarColor(Color BaseColor, ref Color SimilarColor, int Limit)
	{
		Convert.ToDouble(BaseColor.R);
		Convert.ToDouble(BaseColor.G);
		Convert.ToDouble(BaseColor.B);
		int num = BaseColor.R + Limit;
		int num2 = BaseColor.G + Limit;
		int num3 = BaseColor.B + Limit;
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
		num = 160;
		SimilarColor = Color.FromArgb(BaseColor.A, 160, num2, num3);
	}

	public static string ColorToString(Color clr, ColorConvertType Type)
	{
		try
		{
			if (!clr.IsKnownColor)
			{
				if (!clr.IsNamedColor)
				{
					if (Type != ColorConvertType.Html)
					{
						return clr.ToString();
					}
					return ColorTranslator.ToHtml(clr);
				}
				return clr.ToString();
			}
			return clr.ToString();
		}
		catch (Exception)
		{
			return "Black";
		}
	}

	public static Color StringToColor(string Code, ColorConvertType Type)
	{
		Color color = default(Color);
		color = Color.Black;
		try
		{
			string[] array = null;
			array = Code.Split(',');
			if (array.Length < 4)
			{
				if (Type != ColorConvertType.Html)
				{
					Code = Code.Replace("Color", "");
					Code = Code.Replace("[", "");
					Code = Code.Replace("]", "");
					Code = Code.Replace(":", "");
					Code = Code.Trim();
					return ColorTranslator.FromHtml(Code);
				}
				return ColorTranslator.FromHtml(Code);
			}
			array[0] = array[0].Replace("[", "");
			array[3] = array[3].Replace("]", "");
			int alpha = Convert.ToInt32(array[0].Substring(array[0].IndexOf('=') + 1));
			int red = Convert.ToInt32(array[1].Substring(array[1].IndexOf('=') + 1));
			int green = Convert.ToInt32(array[2].Substring(array[2].IndexOf('=') + 1));
			int blue = Convert.ToInt32(array[3].Substring(array[3].IndexOf('=') + 1));
			Color color2 = default(Color);
			return Color.FromArgb(alpha, red, green, blue);
		}
		catch (Exception)
		{
			return Color.Black;
		}
	}

	public static void GetScreenShot(Form frm, ref Bitmap SSBmp)
	{
		SSBmp = new Bitmap(frm.Bounds.Width, frm.Bounds.Height);
		Graphics graphics = Graphics.FromImage(SSBmp);
		graphics.CopyFromScreen(frm.Left, frm.Top, 0, 0, new Size(frm.Width, frm.Height), CopyPixelOperation.SourceCopy);
	}

	public static void GetScreenShot(int Left, int Top, int Width, int Height, ref Bitmap SSBmp)
	{
		SSBmp = new Bitmap(Width, Height);
		Graphics graphics = Graphics.FromImage(SSBmp);
		graphics.CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);
	}

	public static void GetScreenShotAndSaveFile(int Left, int Top, int Width, int Height, bool AutoSave, string FileName, string FileFolder)
	{
		Bitmap bitmap = new Bitmap(Width, Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);
		if (!AutoSave)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = FileFolder;
			saveFileDialog.Filter = "Image File (*.png,*.jpeg)|*.png;*.jpg|PNG File (*.png)|*.png|Jepg File (*.jpg)|*.jpg";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				bitmap.Save(saveFileDialog.FileName);
			}
		}
		else
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(FileFolder);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			bitmap.Save(FileFolder + "\\" + FileName);
		}
		bitmap = null;
		graphics = null;
	}

	public static Color GetColorFrom50ListByIndex(int index)
	{
		int num = index % 50;
		if (num >= 50)
		{
			num = 0;
		}
		return ColorList50UnPopular[num];
	}

	public static byte[] ImageToByteArray(Image imageIn)
	{
		using MemoryStream memoryStream = new MemoryStream();
		imageIn.Save(memoryStream, imageIn.RawFormat);
		return memoryStream.ToArray();
	}

	public static void OpenImageAsStream(string FileName, ref Image image)
	{
		try
		{
			Bitmap bitmap;
			using (FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
			{
				Image image2 = Image.FromStream(stream);
				bitmap = new Bitmap(image2);
				image2.Dispose();
			}
			image = bitmap;
		}
		catch (Exception)
		{
		}
	}

	public static Image OpenImageAsStream(string FileName)
	{
		try
		{
			Bitmap result;
			using (FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
			{
				Image image = Image.FromStream(stream);
				result = new Bitmap(image);
				image.Dispose();
			}
			return result;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void OpenImageAsStream(string FileName, ref Bitmap image)
	{
		try
		{
			Bitmap bitmap;
			using (FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
			{
				Image image2 = Image.FromStream(stream);
				bitmap = new Bitmap(image2);
				image2.Dispose();
			}
			image = bitmap;
		}
		catch (Exception)
		{
		}
	}
}
