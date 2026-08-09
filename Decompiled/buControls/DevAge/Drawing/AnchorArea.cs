using System;
using System.ComponentModel;
using System.Drawing;

namespace DevAge.Drawing;

[Serializable]
public class AnchorArea : ICloneable, IComparable
{
	[DefaultValue(float.NaN)]
	public float Right = float.NaN;

	[DefaultValue(float.NaN)]
	public float Left = float.NaN;

	[DefaultValue(false)]
	public bool Center;

	[DefaultValue(float.NaN)]
	public float Top = float.NaN;

	[DefaultValue(float.NaN)]
	public float Bottom = float.NaN;

	[DefaultValue(false)]
	public bool Middle;

	public static AnchorArea Empty => new AnchorArea();

	public bool IsEmpty => !HasRight && !HasLeft && !HasTop && !HasBottom && !Middle && !Center;

	public bool HasRight => !float.IsNaN(Right);

	public bool HasLeft => !float.IsNaN(Left);

	public bool HasTop => !float.IsNaN(Top);

	public bool HasBottom => !float.IsNaN(Bottom);

	public AnchorArea()
	{
	}

	public AnchorArea(float left, float top, float right, float bottom, bool center, bool middle)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
		Center = center;
		Middle = middle;
	}

	public AnchorArea(AnchorArea other)
	{
		Right = other.Right;
		Left = other.Left;
		Bottom = other.Bottom;
		Top = other.Top;
		Center = other.Center;
		Middle = other.Middle;
	}

	public AnchorArea(ContentAlignment aligment, bool stretch)
	{
		if (Utilities.IsBottom(aligment) || stretch)
		{
			Bottom = 0f;
		}
		if (Utilities.IsLeft(aligment) || stretch)
		{
			Left = 0f;
		}
		if (Utilities.IsRight(aligment) || stretch)
		{
			Right = 0f;
		}
		if (Utilities.IsTop(aligment) || stretch)
		{
			Top = 0f;
		}
		if (Utilities.IsCenter(aligment) && !stretch)
		{
			Center = true;
		}
		if (Utilities.IsMiddle(aligment) && !stretch)
		{
			Middle = true;
		}
	}

	public override string ToString()
	{
		return "Top " + Top + ", Bottom " + Bottom + ", Right " + Right + ", Left " + Left;
	}

	public override int GetHashCode()
	{
		return (int)(Top + Bottom + Left + Right);
	}

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public object Clone()
	{
		return new AnchorArea(this);
	}

	public int CompareTo(object obj)
	{
		if (obj != null)
		{
			if (obj is AnchorArea)
			{
				AnchorArea anchorArea = (AnchorArea)obj;
				int num = Top.CompareTo(anchorArea.Top);
				int num2 = Bottom.CompareTo(anchorArea.Bottom);
				int num3 = Left.CompareTo(anchorArea.Left);
				int num4 = Right.CompareTo(anchorArea.Right);
				int num5 = Center.CompareTo(anchorArea.Center);
				int num6 = Middle.CompareTo(anchorArea.Middle);
				if (num <= 1)
				{
					if (num >= 1)
					{
						if (num2 <= 1)
						{
							if (num2 >= 1)
							{
								if (num4 <= 1)
								{
									if (num4 >= 1)
									{
										if (num3 <= 1)
										{
											if (num3 >= 1)
											{
												if (num5 <= 1)
												{
													if (num5 >= 1)
													{
														if (num6 <= 1)
														{
															if (num6 >= 1)
															{
																return 0;
															}
															return -1;
														}
														return 1;
													}
													return -1;
												}
												return 1;
											}
											return -1;
										}
										return 1;
									}
									return -1;
								}
								return 1;
							}
							return -1;
						}
						return 1;
					}
					return -1;
				}
				return 1;
			}
			throw new ArgumentException("Invalid object, AnchorArea expected");
		}
		return 1;
	}

	public static bool operator ==(AnchorArea a, AnchorArea b)
	{
		if ((object)a != b)
		{
			if ((object)a != null && (object)b != null)
			{
				return a.Equals(b);
			}
			return false;
		}
		return true;
	}

	public static bool operator !=(AnchorArea a, AnchorArea b)
	{
		return !(a == b);
	}

	public static RectangleF CalculateArea(RectangleF area, SizeF content, AnchorArea anchor)
	{
		if (!anchor.IsEmpty)
		{
			RectangleF result = default(RectangleF);
			if (!anchor.Center)
			{
				if (!anchor.HasLeft || !anchor.HasRight)
				{
					if (!anchor.HasLeft)
					{
						if (!anchor.HasRight)
						{
							result.X = area.Left;
							result.Width = content.Width;
						}
						else
						{
							result.X = area.Right - content.Width - anchor.Right;
							result.Width = content.Width;
						}
					}
					else
					{
						result.X = area.Left + anchor.Left;
						result.Width = content.Width;
					}
				}
				else
				{
					result.X = area.Left + anchor.Left;
					result.Width = area.Width - (anchor.Left + anchor.Right);
				}
			}
			else
			{
				result.X = area.X + area.Width / 2f - content.Width / 2f;
				result.Width = content.Width;
			}
			if (!anchor.Middle)
			{
				if (!anchor.HasTop || !anchor.HasBottom)
				{
					if (!anchor.HasTop)
					{
						if (!anchor.HasBottom)
						{
							result.Y = area.Top;
							result.Height = content.Height;
						}
						else
						{
							result.Y = area.Bottom - content.Height - anchor.Bottom;
							result.Height = content.Height;
						}
					}
					else
					{
						result.Y = area.Top + anchor.Top;
						result.Height = content.Height;
					}
				}
				else
				{
					result.Y = area.Top + anchor.Top;
					result.Height = area.Height - (anchor.Top + anchor.Bottom);
				}
			}
			else
			{
				result.Y = area.Y + area.Height / 2f - content.Height / 2f;
				result.Height = content.Height;
			}
			result.Intersect(area);
			return result;
		}
		return area;
	}
}
