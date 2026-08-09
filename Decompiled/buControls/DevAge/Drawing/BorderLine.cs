using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevAge.Drawing;

[Serializable]
public struct BorderLine
{
	public static readonly BorderLine NoBorder;

	public static readonly BorderLine Black1Width;

	[DefaultValue(0)]
	public float Width;

	public Color Color;

	[DefaultValue(DashStyle.Solid)]
	public DashStyle DashStyle;

	[DefaultValue(0)]
	public float Padding;

	public BorderLine(Color p_Color)
	{
		Color = p_Color;
		Width = 1f;
		DashStyle = DashStyle.Solid;
		Padding = 0f;
	}

	public BorderLine(Color p_Color, float p_Width)
	{
		Width = p_Width;
		Color = p_Color;
		DashStyle = DashStyle.Solid;
		Padding = 0f;
	}

	public BorderLine(Color p_Color, float p_Width, DashStyle dashStyle)
	{
		Width = p_Width;
		Color = p_Color;
		DashStyle = dashStyle;
		Padding = 0f;
	}

	public BorderLine(Color p_Color, float p_Width, DashStyle dashStyle, float padding)
	{
		Width = p_Width;
		Color = p_Color;
		DashStyle = dashStyle;
		Padding = padding;
	}

	public override string ToString()
	{
		return Color.ToString() + ", Width= " + Width + ", DashStyle= " + DashStyle;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj.GetType() != GetType()))
			{
				BorderLine borderLine = (BorderLine)obj;
				if (borderLine.Width != Width || !(borderLine.Color == Color) || borderLine.DashStyle != DashStyle || borderLine.Padding != Padding)
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
		return Color.GetHashCode();
	}

	public static bool operator ==(BorderLine a, BorderLine b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(BorderLine a, BorderLine b)
	{
		return !a.Equals(b);
	}

	static BorderLine()
	{
		NoBorder = new BorderLine(Color.White, 0f);
		Black1Width = new BorderLine(Color.Black, 1f);
	}
}
