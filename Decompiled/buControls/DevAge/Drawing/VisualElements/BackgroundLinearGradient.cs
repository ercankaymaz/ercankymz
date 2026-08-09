using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class BackgroundLinearGradient : VisualElementBase
{
	private Color mFirstColor = Color.Empty;

	private Color mSecondColor = Color.Empty;

	private float mAngle = 0f;

	private float[] mBlendFactors = null;

	private float[] mBlendPositions = null;

	public virtual Color FirstColor
	{
		get
		{
			return mFirstColor;
		}
		set
		{
			mFirstColor = value;
		}
	}

	public virtual Color SecondColor
	{
		get
		{
			return mSecondColor;
		}
		set
		{
			mSecondColor = value;
		}
	}

	public virtual float Angle
	{
		get
		{
			return mAngle;
		}
		set
		{
			mAngle = value;
		}
	}

	public virtual float[] BlendFactors
	{
		get
		{
			return mBlendFactors;
		}
		set
		{
			mBlendFactors = value;
		}
	}

	public virtual float[] BlendPositions
	{
		get
		{
			return mBlendPositions;
		}
		set
		{
			mBlendPositions = value;
		}
	}

	public BackgroundLinearGradient()
	{
	}

	public BackgroundLinearGradient(Color firstColor, Color secondColor, float angle)
	{
		FirstColor = firstColor;
		SecondColor = secondColor;
		Angle = angle;
	}

	public BackgroundLinearGradient(BackgroundLinearGradient other)
		: base(other)
	{
		FirstColor = other.FirstColor;
		SecondColor = other.SecondColor;
		Angle = other.Angle;
		BlendFactors = other.BlendFactors;
		BlendPositions = other.BlendPositions;
	}

	protected virtual bool ShouldSerializeFirstColor()
	{
		return FirstColor != Color.Empty;
	}

	protected virtual bool ShouldSerializeSecondColor()
	{
		return SecondColor != Color.Empty;
	}

	protected virtual bool ShouldSerializeAngle()
	{
		return Angle != 0f;
	}

	protected virtual bool ShouldSerializeBlendFactors()
	{
		return BlendFactors != null;
	}

	protected virtual bool ShouldSerializeBlendPositions()
	{
		return BlendPositions != null;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (!(FirstColor != Color.Empty) && !(SecondColor != Color.Empty))
		{
			return;
		}
		if (!(FirstColor == SecondColor))
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(area, FirstColor, SecondColor, Angle))
			{
				if (BlendFactors != null && BlendPositions != null && BlendFactors.Length == BlendPositions.Length)
				{
					Blend blend = new Blend();
					blend.Factors = BlendFactors;
					blend.Positions = BlendPositions;
					linearGradientBrush.Blend = blend;
				}
				graphics.Graphics.FillRectangle(linearGradientBrush, area);
				return;
			}
		}
		SolidBrush brush = graphics.BrushsCache.GetBrush(FirstColor);
		graphics.Graphics.FillRectangle(brush, area);
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		return SizeF.Empty;
	}

	public override object Clone()
	{
		return new BackgroundLinearGradient(this);
	}
}
