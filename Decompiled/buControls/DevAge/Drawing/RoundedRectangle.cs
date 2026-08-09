using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevAge.Drawing;

[Serializable]
public struct RoundedRectangle(Rectangle rect, double roundValue)
{
	private Rectangle mRectangle = rect;

	private double mRoundValue = roundValue;

	public Rectangle Rectangle
	{
		get
		{
			return mRectangle;
		}
		set
		{
			mRectangle = value;
		}
	}

	public double RoundValue
	{
		get
		{
			return mRoundValue;
		}
		set
		{
			if (!(mRoundValue >= 0.0) || mRoundValue > 1.0)
			{
				throw new ApplicationException("Invalid value, must be a value from 0 to 1");
			}
			mRoundValue = value;
		}
	}

	public GraphicsPath ToGraphicsPath()
	{
		if (!mRectangle.IsEmpty)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (mRoundValue != 0.0)
			{
				int x = mRectangle.X;
				int y = mRectangle.Y;
				int num = 0;
				int num2 = 0;
				if (mRectangle.Height >= mRectangle.Width)
				{
					num = (int)((double)mRectangle.Width * mRoundValue);
					num2 = num * 2;
				}
				else
				{
					num = (int)((double)mRectangle.Height * mRoundValue);
					num2 = num * 2;
				}
				graphicsPath.AddLine(num + x, y, mRectangle.Width - num + x, y);
				graphicsPath.AddArc(mRectangle.Width - num2 + x, y, num2, num2, 270f, 90f);
				graphicsPath.AddLine(mRectangle.Width + x, num + y, mRectangle.Width + x, mRectangle.Height - num + y);
				graphicsPath.AddArc(mRectangle.Width - num2 + x, mRectangle.Height - num2 + y, num2, num2, 0f, 90f);
				graphicsPath.AddLine(mRectangle.Width - num + x, mRectangle.Height + y, num + x, mRectangle.Height + y);
				graphicsPath.AddArc(x, mRectangle.Height - num2 + y, num2, num2, 90f, 90f);
				graphicsPath.AddLine(x, mRectangle.Height - num + y, x, num + y);
				graphicsPath.AddArc(x, y, num2, num2, 180f, 90f);
			}
			else
			{
				graphicsPath.AddRectangle(mRectangle);
			}
			return graphicsPath;
		}
		return new GraphicsPath();
	}
}
