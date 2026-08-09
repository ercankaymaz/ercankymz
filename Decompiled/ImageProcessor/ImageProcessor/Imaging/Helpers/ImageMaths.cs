using System;
using System.Drawing;
using ImageProcessor.Imaging.Colors;

namespace ImageProcessor.Imaging.Helpers;

public static class ImageMaths
{
	public static RectangleF CenteredRectangle(Rectangle parent, Rectangle child)
	{
		float x = (float)(parent.Width - child.Width) / 2f;
		float y = (float)(parent.Height - child.Height) / 2f;
		int width = child.Width;
		int height = child.Height;
		return new RectangleF(x, y, width, height);
	}

	public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
	{
		if (value.CompareTo(min) < 0)
		{
			return min;
		}
		if (value.CompareTo(max) > 0)
		{
			return max;
		}
		return value;
	}

	public static bool InRange<T>(T value, T min, T max, bool include = true) where T : IComparable<T>
	{
		if (include)
		{
			return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
		}
		return value.CompareTo(min) > 0 && value.CompareTo(max) < 0;
	}

	public static double DegreesToRadians(double angleInDegrees)
	{
		return angleInDegrees * (Math.PI / 180.0);
	}

	public static Rectangle GetBoundingRectangle(Point topLeft, Point bottomRight)
	{
		return new Rectangle(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
	}

	public static Rectangle GetBoundingRotatedRectangle(int width, int height, float angleInDegrees)
	{
		double num = DegreesToRadians(angleInDegrees);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		double value = (double)height * num2 + (double)width * num3;
		double value2 = (double)width * num2 + (double)height * num3;
		num2 = Math.Sin(0.0 - num);
		num3 = Math.Cos(0.0 - num);
		double value3 = (double)height * num2 + (double)width * num3;
		double value4 = (double)width * num2 + (double)height * num3;
		return new Rectangle(0, 0, Convert.ToInt32(Math.Max(Math.Abs(value), Math.Abs(value3))), Convert.ToInt32(Math.Max(Math.Abs(value2), Math.Abs(value4))));
	}

	public static Rectangle GetFilteredBoundingRectangle(Image bitmap, byte componentValue, RgbaComponent channel = RgbaComponent.B)
	{
		int width = bitmap.Width;
		int height = bitmap.Height;
		Point topLeft = default(Point);
		Point bottomRight = default(Point);
		Func<FastBitmap, int, int, byte, bool> delegateFunc;
		switch (channel)
		{
		case RgbaComponent.R:
			delegateFunc = (FastBitmap fastBitmap2, int x, int y, byte b) => fastBitmap2.GetPixel(x, y).R != b;
			break;
		case RgbaComponent.G:
			delegateFunc = (FastBitmap fastBitmap2, int x, int y, byte b) => fastBitmap2.GetPixel(x, y).G != b;
			break;
		case RgbaComponent.A:
			delegateFunc = (FastBitmap fastBitmap2, int x, int y, byte b) => fastBitmap2.GetPixel(x, y).A != b;
			break;
		default:
			delegateFunc = (FastBitmap fastBitmap2, int x, int y, byte b) => fastBitmap2.GetPixel(x, y).B != b;
			break;
		}
		using (FastBitmap fastBitmap = new FastBitmap(bitmap))
		{
			topLeft.Y = getMinY(fastBitmap);
			topLeft.X = getMinX(fastBitmap);
			bottomRight.Y = getMaxY(fastBitmap) + 1;
			bottomRight.X = getMaxX(fastBitmap) + 1;
		}
		return GetBoundingRectangle(topLeft, bottomRight);
		int getMaxX(FastBitmap arg)
		{
			for (int num = width - 1; num > -1; num--)
			{
				for (int i = 0; i < height; i++)
				{
					if (delegateFunc(arg, num, i, componentValue))
					{
						return num;
					}
				}
			}
			return height;
		}
		int getMaxY(FastBitmap arg)
		{
			for (int num = height - 1; num > -1; num--)
			{
				for (int i = 0; i < width; i++)
				{
					if (delegateFunc(arg, i, num, componentValue))
					{
						return num;
					}
				}
			}
			return height;
		}
		int getMinX(FastBitmap arg)
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (delegateFunc(arg, i, j, componentValue))
					{
						return i;
					}
				}
			}
			return 0;
		}
		int getMinY(FastBitmap arg)
		{
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (delegateFunc(arg, j, i, componentValue))
					{
						return i;
					}
				}
			}
			return 0;
		}
	}

	public static Point RotatePoint(Point pointToRotate, double angleInDegrees, Point? centerPoint = null)
	{
		Point point = centerPoint ?? Point.Empty;
		double num = DegreesToRadians(angleInDegrees);
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		return new Point
		{
			X = (int)(num2 * (double)(pointToRotate.X - point.X) - num3 * (double)(pointToRotate.Y - point.Y) + (double)point.X),
			Y = (int)(num3 * (double)(pointToRotate.X - point.X) + num2 * (double)(pointToRotate.Y - point.Y) + (double)point.Y)
		};
	}

	public static Point[] ToPoints(Rectangle rectangle)
	{
		return new Point[4]
		{
			new Point(rectangle.Left, rectangle.Top),
			new Point(rectangle.Right, rectangle.Top),
			new Point(rectangle.Right, rectangle.Bottom),
			new Point(rectangle.Left, rectangle.Bottom)
		};
	}

	public static float ZoomAfterRotation(int imageWidth, int imageHeight, float angleInDegrees)
	{
		Rectangle boundingRotatedRectangle = GetBoundingRotatedRectangle(imageWidth, imageHeight, angleInDegrees);
		return Math.Max((float)boundingRotatedRectangle.Width / (float)imageWidth, (float)boundingRotatedRectangle.Height / (float)imageHeight);
	}
}
