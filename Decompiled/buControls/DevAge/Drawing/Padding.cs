using System;
using System.Drawing;

namespace DevAge.Drawing;

[Serializable]
public struct Padding
{
	public static Padding Empty;

	public float Left;

	public float Right;

	public float Top;

	public float Bottom;

	public bool IsEmpty => Left == 0f && Right == 0f && Top == 0f && Bottom == 0f;

	public Padding(float all)
	{
		Left = all;
		Right = all;
		Top = all;
		Bottom = all;
	}

	public Padding(float left, float right, float top, float bottom)
	{
		Left = left;
		Right = right;
		Top = top;
		Bottom = bottom;
	}

	public RectangleF GetContentRectangle(RectangleF backGroundArea)
	{
		if (!IsEmpty)
		{
			return new RectangleF(backGroundArea.X + Left, backGroundArea.Y + Top, backGroundArea.Width - (Left + Right), backGroundArea.Height - (Top + Bottom));
		}
		return backGroundArea;
	}

	public SizeF GetExtent(SizeF contentSize)
	{
		if (!IsEmpty)
		{
			return new SizeF(contentSize.Width + (Left + Right), contentSize.Height + (Top + Bottom));
		}
		return contentSize;
	}

	public override string ToString()
	{
		return "Left:" + Left + ",Right:" + Right + ",Top:" + Top + ",Bottom:" + Bottom;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj.GetType() != GetType()))
			{
				Padding padding = (Padding)obj;
				if (padding.Top != Top || padding.Bottom != Bottom || padding.Right != Right || padding.Left != Left)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Top.GetHashCode();
	}

	public static bool operator ==(Padding a, Padding b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Padding a, Padding b)
	{
		return !a.Equals(b);
	}

	static Padding()
	{
		Empty = default(Padding);
	}
}
