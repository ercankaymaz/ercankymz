using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevAge.Drawing;

[Serializable]
public struct RectangleBorder : ICloneable, IBorder
{
	public static readonly RectangleBorder NoBorder;

	public static readonly RectangleBorder RectangleBlack1Width;

	public BorderLine Top;

	public BorderLine Bottom;

	public BorderLine Left;

	public BorderLine Right;

	public RectangleBorder(BorderLine p_Border)
	{
		Top = p_Border;
		Bottom = p_Border;
		Left = p_Border;
		Right = p_Border;
	}

	public RectangleBorder(BorderLine p_Right, BorderLine p_Bottom)
	{
		Right = p_Right;
		Bottom = p_Bottom;
		Top = new BorderLine(Color.White, 0f);
		Left = new BorderLine(Color.White, 0f);
	}

	public RectangleBorder(BorderLine p_Top, BorderLine p_Bottom, BorderLine p_Left, BorderLine p_Right)
	{
		Top = p_Top;
		Bottom = p_Bottom;
		Left = p_Left;
		Right = p_Right;
	}

	public RectangleBorder SetColor(Color p_Color)
	{
		Top = new BorderLine(p_Color, Top.Width, Top.DashStyle, Top.Padding);
		Bottom = new BorderLine(p_Color, Bottom.Width, Bottom.DashStyle, Bottom.Padding);
		Left = new BorderLine(p_Color, Left.Width, Left.DashStyle, Left.Padding);
		Right = new BorderLine(p_Color, Right.Width, Right.DashStyle, Right.Padding);
		return this;
	}

	public RectangleBorder SetDashStyle(DashStyle dashStyle)
	{
		Top = new BorderLine(Top.Color, Top.Width, dashStyle, Top.Padding);
		Bottom = new BorderLine(Bottom.Color, Bottom.Width, dashStyle, Bottom.Padding);
		Left = new BorderLine(Left.Color, Left.Width, dashStyle, Left.Padding);
		Right = new BorderLine(Right.Color, Right.Width, dashStyle, Right.Padding);
		return this;
	}

	public RectangleBorder SetWidth(int p_Width)
	{
		Top = new BorderLine(Top.Color, p_Width, Top.DashStyle, Top.Padding);
		Bottom = new BorderLine(Bottom.Color, p_Width, Bottom.DashStyle, Bottom.Padding);
		Left = new BorderLine(Left.Color, p_Width, Left.DashStyle, Left.Padding);
		Right = new BorderLine(Right.Color, p_Width, Right.DashStyle, Right.Padding);
		return this;
	}

	public RectangleBorder SetPadding(int padding)
	{
		Top = new BorderLine(Top.Color, Top.Width, Top.DashStyle, padding);
		Bottom = new BorderLine(Bottom.Color, Bottom.Width, Bottom.DashStyle, padding);
		Left = new BorderLine(Left.Color, Left.Width, Left.DashStyle, padding);
		Right = new BorderLine(Right.Color, Right.Width, Right.DashStyle, padding);
		return this;
	}

	public override string ToString()
	{
		return "Top:" + Top.ToString() + " Bottom:" + Bottom.ToString() + " Left:" + Left.ToString() + " Right:" + Right.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj.GetType() != GetType()))
			{
				RectangleBorder rectangleBorder = (RectangleBorder)obj;
				if (!(rectangleBorder.Left == Left) || !(rectangleBorder.Bottom == Bottom) || !(rectangleBorder.Top == Top) || !(rectangleBorder.Right == Right))
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
		return Left.GetHashCode();
	}

	public static bool operator ==(RectangleBorder a, RectangleBorder b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(RectangleBorder a, RectangleBorder b)
	{
		return !a.Equals(b);
	}

	public static RectangleBorder CreateInsetBorder(int p_width, Color p_ShadowColor, Color p_LightColor)
	{
		RectangleBorder result = new RectangleBorder(new BorderLine(Color.White));
		result.Top = new BorderLine(p_ShadowColor, p_width);
		result.Left = new BorderLine(p_ShadowColor, p_width);
		result.Bottom = new BorderLine(p_LightColor, p_width);
		result.Right = new BorderLine(p_LightColor, p_width);
		return result;
	}

	public static RectangleBorder CreateRaisedBorder(int p_width, Color p_ShadowColor, Color p_LightColor)
	{
		RectangleBorder result = new RectangleBorder(new BorderLine(Color.White));
		result.Top = new BorderLine(p_LightColor, p_width);
		result.Left = new BorderLine(p_LightColor, p_width);
		result.Bottom = new BorderLine(p_ShadowColor, p_width);
		result.Right = new BorderLine(p_ShadowColor, p_width);
		return result;
	}

	public RectangleF GetContentRectangle(RectangleF backGroundArea)
	{
		backGroundArea.Y += Top.Width + Top.Padding;
		backGroundArea.X += Left.Width + Left.Padding;
		backGroundArea.Width -= Left.Width + Right.Width + Left.Padding + Right.Padding;
		backGroundArea.Height -= Top.Width + Bottom.Width + Top.Padding + Bottom.Padding;
		return backGroundArea;
	}

	public SizeF GetExtent(SizeF contentSize)
	{
		contentSize.Width += Left.Width + Right.Width + Left.Padding + Right.Padding;
		contentSize.Height += Top.Width + Bottom.Width + Top.Padding + Bottom.Padding;
		return contentSize;
	}

	public void Draw(GraphicsCache graphics, RectangleF rectangle)
	{
		RectangleBorder rectangleBorder = this;
		rectangle = new RectangleF(rectangle.X + Left.Padding, rectangle.Y + Top.Padding, rectangle.Width - (Left.Padding + Right.Padding), rectangle.Height - (Top.Padding + Bottom.Padding));
		if (!(rectangle.Width > 0f) || rectangle.Height <= 0f)
		{
			return;
		}
		PensCache pensCache = graphics.PensCache;
		if (rectangleBorder.Left.Width > 0f)
		{
			Pen pen = pensCache.GetPen(rectangleBorder.Left.Color, rectangleBorder.Left.Width, rectangleBorder.Left.DashStyle);
			float x;
			float y;
			if (!(rectangleBorder.Left.Width > 1f))
			{
				x = rectangle.X;
				y = rectangle.Bottom - 1f;
			}
			else
			{
				x = rectangle.X + rectangleBorder.Left.Width / 2f;
				y = rectangle.Bottom;
			}
			graphics.Graphics.DrawLine(pen, new PointF(x, rectangle.Y), new PointF(x, y));
		}
		if (rectangleBorder.Right.Width > 0f)
		{
			Pen pen2 = pensCache.GetPen(rectangleBorder.Right.Color, rectangleBorder.Right.Width, rectangleBorder.Right.DashStyle);
			float x2;
			float y2;
			if (!(rectangleBorder.Right.Width > 1f))
			{
				x2 = rectangle.Right - 1f;
				y2 = rectangle.Bottom - 1f;
			}
			else
			{
				x2 = rectangle.Right - rectangleBorder.Right.Width / 2f;
				y2 = rectangle.Bottom;
			}
			graphics.Graphics.DrawLine(pen2, new PointF(x2, rectangle.Y), new PointF(x2, y2));
		}
		if (rectangleBorder.Top.Width > 0f)
		{
			Pen pen3 = pensCache.GetPen(rectangleBorder.Top.Color, rectangleBorder.Top.Width, rectangleBorder.Top.DashStyle);
			float y3;
			float x3;
			if (!(rectangleBorder.Top.Width > 1f))
			{
				y3 = rectangle.Y;
				x3 = rectangle.Right - 1f;
			}
			else
			{
				y3 = rectangle.Y + rectangleBorder.Top.Width / 2f;
				x3 = rectangle.Right;
			}
			graphics.Graphics.DrawLine(pen3, new PointF(rectangle.X, y3), new PointF(x3, y3));
		}
		if (rectangleBorder.Bottom.Width > 0f)
		{
			Pen pen4 = pensCache.GetPen(rectangleBorder.Bottom.Color, rectangleBorder.Bottom.Width, rectangleBorder.Bottom.DashStyle);
			float y4;
			float x4;
			if (!(rectangleBorder.Bottom.Width > 1f))
			{
				y4 = rectangle.Bottom - 1f;
				x4 = rectangle.Right - 1f;
			}
			else
			{
				y4 = rectangle.Bottom - rectangleBorder.Bottom.Width / 2f;
				x4 = rectangle.Right;
			}
			graphics.Graphics.DrawLine(pen4, new PointF(rectangle.X, y4), new PointF(x4, y4));
		}
	}

	public RectanglePartType GetPointPartType(RectangleF area, PointF point, out float distanceFromBorder)
	{
		if (area.Contains(point))
		{
			RectangleF contentRectangle = GetContentRectangle(area);
			if (!contentRectangle.Contains(point))
			{
				if (point.X < area.Left || !(point.X < contentRectangle.Left))
				{
					if (point.X >= area.Right || !(point.X >= contentRectangle.Right))
					{
						if (point.Y < area.Top || !(point.Y < contentRectangle.Top))
						{
							if (point.Y >= area.Bottom || !(point.Y >= contentRectangle.Bottom))
							{
								distanceFromBorder = -1f;
								return RectanglePartType.None;
							}
							distanceFromBorder = area.Bottom - point.Y;
							return RectanglePartType.BottomBorder;
						}
						distanceFromBorder = point.Y - area.Top;
						return RectanglePartType.TopBorder;
					}
					distanceFromBorder = area.Right - point.X;
					return RectanglePartType.RightBorder;
				}
				distanceFromBorder = point.X - area.Left;
				return RectanglePartType.LeftBorder;
			}
			distanceFromBorder = -1f;
			return RectanglePartType.ContentArea;
		}
		distanceFromBorder = -1f;
		return RectanglePartType.None;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	static RectangleBorder()
	{
		NoBorder = new RectangleBorder(BorderLine.NoBorder);
		RectangleBlack1Width = new RectangleBorder(new BorderLine(Color.Black, 1f));
	}
}
