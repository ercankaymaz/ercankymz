using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Header : HeaderBase
{
	private Color mBackColor;

	private RectangleBorder mBorder;

	private float mGradientAngle = 45f;

	private BackgroundColorStyle mBackgroundColorStyle = BackgroundColorStyle.Linear;

	private BackgroundLinearGradient mBackground;

	public Color BackColor
	{
		get
		{
			return mBackColor;
		}
		set
		{
			mBackColor = value;
		}
	}

	public RectangleBorder Border
	{
		get
		{
			return mBorder;
		}
		set
		{
			mBorder = value;
		}
	}

	public float GradientAngle
	{
		get
		{
			return mGradientAngle;
		}
		set
		{
			mGradientAngle = value;
		}
	}

	public BackgroundColorStyle BackgroundColorStyle
	{
		get
		{
			return mBackgroundColorStyle;
		}
		set
		{
			mBackgroundColorStyle = value;
		}
	}

	public Header()
		: this(45f)
	{
	}

	public Header(float gradientAngle)
	{
		GradientAngle = gradientAngle;
		mBackground = new BackgroundLinearGradient(Color.Empty, Color.Empty, GradientAngle);
		BackColor = Color.FromKnownColor(KnownColor.Control);
		Color p_Color = Utilities.CalculateLightDarkColor(BackColor, -0.2f);
		BorderLine borderLine = new BorderLine(p_Color, 1f);
		mBorder = new RectangleBorder(borderLine, borderLine);
	}

	public Header(Header other)
		: base(other)
	{
		BackColor = other.BackColor;
		Border = other.Border;
		GradientAngle = other.GradientAngle;
	}

	public override object Clone()
	{
		return new Header(this);
	}

	public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		backGroundArea = mBorder.GetContentRectangle(backGroundArea);
		return base.GetBackgroundContentRectangle(measure, backGroundArea);
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		SizeF backgroundExtent = base.GetBackgroundExtent(measure, contentSize);
		return mBorder.GetExtent(contentSize);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		OnDrawBackground(graphics, area);
		OnDrawBorder(graphics, area);
	}

	protected virtual void OnDrawBorder(GraphicsCache graphics, RectangleF area)
	{
		mBorder.Draw(graphics, area);
	}

	protected virtual void OnDrawBackground(GraphicsCache graphics, RectangleF area)
	{
		Color color = Utilities.CalculateLightDarkColor(BackColor, -0.2f);
		Color color2 = Utilities.CalculateLightDarkColor(BackColor, 0.5f);
		Color color3 = Utilities.CalculateMiddleColor(Color.FromKnownColor(KnownColor.Highlight), color2);
		if (Style != ControlDrawStyle.Hot)
		{
			if (Style != ControlDrawStyle.Pressed)
			{
				if (BackgroundColorStyle != BackgroundColorStyle.Linear)
				{
					if (BackgroundColorStyle != BackgroundColorStyle.Solid)
					{
						mBackground.FirstColor = Color.Empty;
						mBackground.SecondColor = Color.Empty;
					}
					else
					{
						mBackground.FirstColor = BackColor;
						mBackground.SecondColor = BackColor;
					}
				}
				else
				{
					mBackground.FirstColor = color2;
					mBackground.SecondColor = color;
				}
			}
			else
			{
				mBackground.FirstColor = color;
				mBackground.SecondColor = color2;
			}
		}
		else
		{
			mBackground.FirstColor = color3;
			mBackground.SecondColor = color3;
		}
		mBackground.Angle = GradientAngle;
		mBackground.Draw(graphics, area);
	}
}
