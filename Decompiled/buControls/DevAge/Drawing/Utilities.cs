using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevAge.Drawing;

public static class Utilities
{
	private static ImageAttributes imageAttributes_0;

	public static void DrawRoundedRectangle(Graphics g, RoundedRectangle roundRect, Pen pen)
	{
		int num = (int)pen.Width;
		Rectangle rect = new Rectangle(roundRect.Rectangle.X + num / 2, roundRect.Rectangle.Y + num / 2, roundRect.Rectangle.Width - num, roundRect.Rectangle.Height - num);
		g.DrawPath(pen, new RoundedRectangle(rect, roundRect.RoundValue).ToGraphicsPath());
	}

	public static void FillRoundedRectangle(Graphics g, RoundedRectangle roundRect, Brush brush)
	{
		Rectangle rect = new Rectangle(roundRect.Rectangle.X, roundRect.Rectangle.Y, roundRect.Rectangle.Width - 1, roundRect.Rectangle.Height - 1);
		g.FillRegion(brush, new Region(new RoundedRectangle(rect, roundRect.RoundValue).ToGraphicsPath()));
	}

	public static void DrawGradient3DBorder(Graphics g, Rectangle p_HeaderRectangle, Color p_BackColor, Color p_DarkColor, Color p_LightColor, int p_DarkGradientNumber, int p_LightGradientNumber, Gradient3DBorderStyle p_Style)
	{
		Color p_EndColor;
		int p_NumberOfGradients;
		Color p_EndColor2;
		int p_NumberOfGradients2;
		if (p_Style != Gradient3DBorderStyle.Raised)
		{
			p_EndColor = p_DarkColor;
			p_NumberOfGradients = p_DarkGradientNumber;
			p_EndColor2 = p_LightColor;
			p_NumberOfGradients2 = p_LightGradientNumber;
		}
		else
		{
			p_EndColor = p_LightColor;
			p_NumberOfGradients = p_LightGradientNumber;
			p_EndColor2 = p_DarkColor;
			p_NumberOfGradients2 = p_DarkGradientNumber;
		}
		Color[] array = CalculateColorGradient(p_BackColor, p_EndColor, p_NumberOfGradients);
		using (Pen pen = new Pen(array[0]))
		{
			for (int i = 0; i < array.Length; i++)
			{
				pen.Color = array[array.Length - (i + 1)];
				g.DrawLine(pen, p_HeaderRectangle.Left + i, p_HeaderRectangle.Top + i, p_HeaderRectangle.Right - (i + 1), p_HeaderRectangle.Top + i);
				g.DrawLine(pen, p_HeaderRectangle.Left + i, p_HeaderRectangle.Top + i, p_HeaderRectangle.Left + i, p_HeaderRectangle.Bottom - (i + 1));
			}
		}
		Color[] array2 = CalculateColorGradient(p_BackColor, p_EndColor2, p_NumberOfGradients2);
		using Pen pen2 = new Pen(array2[0]);
		for (int j = 0; j < array2.Length; j++)
		{
			pen2.Color = array2[array2.Length - (j + 1)];
			g.DrawLine(pen2, p_HeaderRectangle.Left + j, p_HeaderRectangle.Bottom - (j + 1), p_HeaderRectangle.Right - (j + 1), p_HeaderRectangle.Bottom - (j + 1));
			g.DrawLine(pen2, p_HeaderRectangle.Right - (j + 1), p_HeaderRectangle.Top + j, p_HeaderRectangle.Right - (j + 1), p_HeaderRectangle.Bottom - (j + 1));
		}
	}

	public static Color[] CalculateColorGradient(Color p_StartColor, Color p_EndColor, int p_NumberOfGradients)
	{
		if (p_NumberOfGradients >= 2)
		{
			Color[] array = new Color[p_NumberOfGradients];
			array[0] = p_StartColor;
			array[-1] = p_EndColor;
			float num = (float)(p_EndColor.A - p_StartColor.A) / (float)p_NumberOfGradients;
			float num2 = (float)(p_EndColor.R - p_StartColor.R) / (float)p_NumberOfGradients;
			float num3 = (float)(p_EndColor.G - p_StartColor.G) / (float)p_NumberOfGradients;
			float num4 = (float)(p_EndColor.B - p_StartColor.B) / (float)p_NumberOfGradients;
			for (int i = 1; i < array.Length - 1; i++)
			{
				array[i] = Color.FromArgb((int)((float)(int)p_StartColor.A + num * (float)i), (int)((float)(int)p_StartColor.R + num2 * (float)i), (int)((float)(int)p_StartColor.G + num3 * (float)i), (int)((float)(int)p_StartColor.B + num4 * (float)i));
			}
			return array;
		}
		throw new ArgumentException("Invalid Number of gradients, must be 2 or more");
	}

	public static Color CalculateMiddleColor(Color p_StartColor, Color p_EndColor)
	{
		return CalculateColorGradient(p_StartColor, p_EndColor, 3)[1];
	}

	public static Color CalculateLightDarkColor(Color source, float light)
	{
		if (light != 0f)
		{
			if (light <= 1f && !(light < -1f))
			{
				float num;
				float num2;
				float num3;
				if (!(light < 0f))
				{
					num = (float)(255 - source.R) / 100f;
					num2 = (float)(255 - source.G) / 100f;
					num3 = (float)(255 - source.B) / 100f;
				}
				else
				{
					num = (float)(int)source.R / 100f;
					num2 = (float)(int)source.G / 100f;
					num3 = (float)(int)source.B / 100f;
				}
				int num4 = source.R + (int)(num * light * 100f);
				int num5 = source.G + (int)(num2 * light * 100f);
				int num6 = source.B + (int)(num3 * light * 100f);
				if (num4 <= 255)
				{
					if (num4 < 0)
					{
						num4 = 0;
					}
				}
				else
				{
					num4 = 255;
				}
				if (num5 <= 255)
				{
					if (num5 < 0)
					{
						num5 = 0;
					}
				}
				else
				{
					num5 = 255;
				}
				if (num6 <= 255)
				{
					if (num6 < 0)
					{
						num6 = 0;
					}
				}
				else
				{
					num6 = 255;
				}
				return Color.FromArgb(source.A, num4, num5, num6);
			}
			throw new ArgumentException("Must be between 1 and -1", "light");
		}
		return source;
	}

	public static ContentAlignment StringFormatToContentAlignment(StringFormat p_StringFormat)
	{
		if (!IsBottom(p_StringFormat) || !IsLeft(p_StringFormat))
		{
			if (!IsBottom(p_StringFormat) || !IsRight(p_StringFormat))
			{
				if (!IsBottom(p_StringFormat) || !IsCenter(p_StringFormat))
				{
					if (!IsTop(p_StringFormat) || !IsLeft(p_StringFormat))
					{
						if (!IsTop(p_StringFormat) || !IsRight(p_StringFormat))
						{
							if (!IsTop(p_StringFormat) || !IsCenter(p_StringFormat))
							{
								if (!IsMiddle(p_StringFormat) || !IsLeft(p_StringFormat))
								{
									if (!IsMiddle(p_StringFormat) || !IsRight(p_StringFormat))
									{
										return ContentAlignment.MiddleCenter;
									}
									return ContentAlignment.MiddleRight;
								}
								return ContentAlignment.MiddleLeft;
							}
							return ContentAlignment.TopCenter;
						}
						return ContentAlignment.TopRight;
					}
					return ContentAlignment.TopLeft;
				}
				return ContentAlignment.BottomCenter;
			}
			return ContentAlignment.BottomRight;
		}
		return ContentAlignment.BottomLeft;
	}

	public static void ApplyContentAlignmentToStringFormat(ContentAlignment pAlignment, StringFormat stringFormat)
	{
		if (!IsBottom(pAlignment))
		{
			if (!IsMiddle(pAlignment))
			{
				stringFormat.LineAlignment = StringAlignment.Near;
			}
			else
			{
				stringFormat.LineAlignment = StringAlignment.Center;
			}
		}
		else
		{
			stringFormat.LineAlignment = StringAlignment.Far;
		}
		if (!IsRight(pAlignment))
		{
			if (!IsCenter(pAlignment))
			{
				stringFormat.Alignment = StringAlignment.Near;
			}
			else
			{
				stringFormat.Alignment = StringAlignment.Center;
			}
		}
		else
		{
			stringFormat.Alignment = StringAlignment.Far;
		}
	}

	public static bool IsBottom(ContentAlignment a)
	{
		return a == ContentAlignment.BottomCenter || a == ContentAlignment.BottomLeft || a == ContentAlignment.BottomRight;
	}

	public static bool IsTop(ContentAlignment a)
	{
		return a == ContentAlignment.TopCenter || a == ContentAlignment.TopLeft || a == ContentAlignment.TopRight;
	}

	public static bool IsMiddle(ContentAlignment a)
	{
		return a == ContentAlignment.MiddleCenter || a == ContentAlignment.MiddleLeft || a == ContentAlignment.MiddleRight;
	}

	public static bool IsCenter(ContentAlignment a)
	{
		return a == ContentAlignment.BottomCenter || a == ContentAlignment.MiddleCenter || a == ContentAlignment.TopCenter;
	}

	public static bool IsLeft(ContentAlignment a)
	{
		return a == ContentAlignment.BottomLeft || a == ContentAlignment.MiddleLeft || a == ContentAlignment.TopLeft;
	}

	public static bool IsRight(ContentAlignment a)
	{
		return a == ContentAlignment.BottomRight || a == ContentAlignment.MiddleRight || a == ContentAlignment.TopRight;
	}

	public static bool IsBottom(StringFormat a)
	{
		return a.LineAlignment == StringAlignment.Far;
	}

	public static bool IsTop(StringFormat a)
	{
		return a.LineAlignment == StringAlignment.Near;
	}

	public static bool IsMiddle(StringFormat a)
	{
		return a.LineAlignment == StringAlignment.Center;
	}

	public static bool IsCenter(StringFormat a)
	{
		return a.Alignment == StringAlignment.Center;
	}

	public static bool IsLeft(StringFormat a)
	{
		return a.Alignment == StringAlignment.Near;
	}

	public static bool IsRight(StringFormat a)
	{
		return a.Alignment == StringAlignment.Far;
	}

	public static byte[] ImageToBytes(Image img, ImageFormat imgFormat)
	{
		if (img != null)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				img.Save(memoryStream, imgFormat);
				result = memoryStream.ToArray();
			}
			return result;
		}
		return new byte[0];
	}

	public static Image BytesToImage(byte[] bytes)
	{
		if (bytes != null && bytes.Length != 0)
		{
			Image result;
			using (MemoryStream stream = new MemoryStream(bytes))
			{
				result = Image.FromStream(stream);
			}
			return result;
		}
		return null;
	}

	public static Image CreateDisabledImage(Image image, Color background)
	{
		if (image != null)
		{
			Size size = image.Size;
			if (imageAttributes_0 == null)
			{
				ColorMatrix colorMatrix = new ColorMatrix(new float[5][]
				{
					new float[5] { 0.2125f, 0.2125f, 0.2125f, 0f, 0f },
					new float[5] { 0.2577f, 0.2577f, 0.2577f, 0f, 0f },
					new float[5] { 0.0361f, 0.0361f, 0.0361f, 0f, 0f },
					new float[5] { 0f, 0f, 0f, 1f, 0f },
					new float[5] { 0.38f, 0.38f, 0.38f, 0f, 1f }
				});
				imageAttributes_0 = new ImageAttributes();
				imageAttributes_0.ClearColorKey();
				imageAttributes_0.SetColorMatrix(colorMatrix);
			}
			Bitmap bitmap = new Bitmap(image.Width, image.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttributes_0);
			}
			return bitmap;
		}
		return null;
	}

	public static SizeF CheckMeasure(SizeF measureSize, SizeF minSize, SizeF maxSize)
	{
		if (!(minSize.Width <= 0f) && measureSize.Width < minSize.Width)
		{
			measureSize.Width = minSize.Width;
		}
		if (!(minSize.Height <= 0f) && measureSize.Height < minSize.Height)
		{
			measureSize.Height = minSize.Height;
		}
		if (!(maxSize.Width <= 0f) && measureSize.Width > maxSize.Width)
		{
			measureSize.Width = maxSize.Width;
		}
		if (!(maxSize.Height <= 0f) && measureSize.Height > maxSize.Height)
		{
			measureSize.Height = maxSize.Height;
		}
		return measureSize;
	}

	public static Size SizeFToSize(SizeF sizef)
	{
		return new Size((int)Math.Ceiling(sizef.Width), (int)Math.Ceiling(sizef.Height));
	}
}
