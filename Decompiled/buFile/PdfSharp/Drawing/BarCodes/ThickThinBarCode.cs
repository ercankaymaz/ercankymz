using System;

namespace PdfSharp.Drawing.BarCodes;

public abstract class ThickThinBarCode : BarCode
{
	private double _wideNarrowRatio = 2.6;

	public override double WideNarrowRatio
	{
		get
		{
			return _wideNarrowRatio;
		}
		set
		{
			if (value > 3.0 || value < 2.0)
			{
				throw new ArgumentOutOfRangeException("value", BcgSR.Invalid2of5Relation);
			}
			_wideNarrowRatio = value;
		}
	}

	public ThickThinBarCode(string code, XSize size, CodeDirection direction)
		: base(code, size, direction)
	{
	}

	internal override void InitRendering(BarCodeRenderInfo info)
	{
		base.InitRendering(info);
		CalcThinBarWidth(info);
		info.BarHeight = base.Size.Height;
		if (base.TextLocation != TextLocation.None)
		{
			info.BarHeight *= 0.8;
		}
		switch (base.Direction)
		{
		case CodeDirection.RightToLeft:
			info.Gfx.RotateAtTransform(180.0, info.Position);
			break;
		case CodeDirection.TopToBottom:
			info.Gfx.RotateAtTransform(90.0, info.Position);
			break;
		case CodeDirection.BottomToTop:
			info.Gfx.RotateAtTransform(-90.0, info.Position);
			break;
		}
	}

	internal void RenderBar(BarCodeRenderInfo info, bool isThick)
	{
		double barWidth = GetBarWidth(info, isThick);
		double num = base.Size.Height;
		double x = info.CurrPos.X;
		double num2 = info.CurrPos.Y;
		switch (base.TextLocation)
		{
		case TextLocation.AboveEmbedded:
			num -= info.Gfx.MeasureString(base.Text, info.Font).Height;
			num2 += info.Gfx.MeasureString(base.Text, info.Font).Height;
			break;
		case TextLocation.BelowEmbedded:
			num -= info.Gfx.MeasureString(base.Text, info.Font).Height;
			break;
		}
		XRect rect = new XRect(x, num2, barWidth, num);
		info.Gfx.DrawRectangle(info.Brush, rect);
		info.CurrPos.X += barWidth;
	}

	internal void RenderGap(BarCodeRenderInfo info, bool isThick)
	{
		info.CurrPos.X += GetBarWidth(info, isThick);
	}

	internal void RenderTurboBit(BarCodeRenderInfo info, bool startBit)
	{
		if (startBit)
		{
			info.CurrPos.X -= 0.5 + GetBarWidth(info, isThick: true);
		}
		else
		{
			info.CurrPos.X += 0.5;
		}
		RenderBar(info, isThick: true);
		if (startBit)
		{
			info.CurrPos.X += 0.5;
		}
	}

	internal void RenderText(BarCodeRenderInfo info)
	{
		if (info.Font == null)
		{
			info.Font = new XFont("Courier New", base.Size.Height / 6.0);
		}
		XPoint location = info.Position + CodeBase.CalcDistance(base.Anchor, AnchorType.TopLeft, base.Size);
		switch (base.TextLocation)
		{
		case TextLocation.Above:
			location = new XPoint(location.X, location.Y - info.Gfx.MeasureString(base.Text, info.Font).Height);
			info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(location, base.Size), XStringFormats.TopCenter);
			break;
		case TextLocation.AboveEmbedded:
			info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(location, base.Size), XStringFormats.TopCenter);
			break;
		case TextLocation.Below:
			location = new XPoint(location.X, info.Gfx.MeasureString(base.Text, info.Font).Height + location.Y);
			info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(location, base.Size), XStringFormats.BottomCenter);
			break;
		case TextLocation.BelowEmbedded:
			info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(location, base.Size), XStringFormats.BottomCenter);
			break;
		}
	}

	internal double GetBarWidth(BarCodeRenderInfo info, bool isThick)
	{
		if (isThick)
		{
			return info.ThinBarWidth * _wideNarrowRatio;
		}
		return info.ThinBarWidth;
	}

	internal abstract void CalcThinBarWidth(BarCodeRenderInfo info);
}
