using System;

namespace PdfSharp.Drawing.BarCodes;

public class Code3of9Standard : ThickThinBarCode
{
	private static readonly bool[][] Lines = new bool[44][]
	{
		new bool[9] { false, false, false, true, true, false, true, false, false },
		new bool[9] { true, false, false, true, false, false, false, false, true },
		new bool[9] { false, false, true, true, false, false, false, false, true },
		new bool[9] { true, false, true, true, false, false, false, false, false },
		new bool[9] { false, false, false, true, true, false, false, false, true },
		new bool[9] { true, false, false, true, true, false, false, false, false },
		new bool[9] { false, false, true, true, true, false, false, false, false },
		new bool[9] { false, false, false, true, false, false, true, false, true },
		new bool[9] { true, false, false, true, false, false, true, false, false },
		new bool[9] { false, false, true, true, false, false, true, false, false },
		new bool[9] { true, false, false, false, false, true, false, false, true },
		new bool[9] { false, false, true, false, false, true, false, false, true },
		new bool[9] { true, false, true, false, false, true, false, false, false },
		new bool[9] { false, false, false, false, true, true, false, false, true },
		new bool[9] { true, false, false, false, true, true, false, false, false },
		new bool[9] { false, false, true, false, true, true, false, false, false },
		new bool[9] { false, false, false, false, false, true, true, false, true },
		new bool[9] { true, false, false, false, false, true, true, false, false },
		new bool[9] { false, false, true, false, false, true, true, false, false },
		new bool[9] { false, false, false, false, true, true, true, false, false },
		new bool[9] { true, false, false, false, false, false, false, true, true },
		new bool[9] { false, false, true, false, false, false, false, true, true },
		new bool[9] { true, false, true, false, false, false, false, true, false },
		new bool[9] { false, false, false, false, true, false, false, true, true },
		new bool[9] { true, false, false, false, true, false, false, true, false },
		new bool[9] { false, false, true, false, true, false, false, true, false },
		new bool[9] { false, false, false, false, false, false, true, true, true },
		new bool[9] { true, false, false, false, false, false, true, true, false },
		new bool[9] { false, false, true, false, false, false, true, true, false },
		new bool[9] { false, false, false, false, true, false, true, true, false },
		new bool[9] { true, true, false, false, false, false, false, false, true },
		new bool[9] { false, true, true, false, false, false, false, false, true },
		new bool[9] { true, true, true, false, false, false, false, false, false },
		new bool[9] { false, true, false, false, true, false, false, false, true },
		new bool[9] { true, true, false, false, true, false, false, false, false },
		new bool[9] { false, true, true, false, true, false, false, false, false },
		new bool[9] { false, true, false, false, false, false, true, false, true },
		new bool[9] { true, true, false, false, false, false, true, false, false },
		new bool[9] { false, true, true, false, false, false, true, false, false },
		new bool[9] { false, true, false, true, false, true, false, false, false },
		new bool[9] { false, true, false, true, false, false, false, true, false },
		new bool[9] { false, true, false, false, false, true, false, true, false },
		new bool[9] { false, false, false, true, false, true, false, true, false },
		new bool[9] { false, true, false, false, true, false, true, false, false }
	};

	public Code3of9Standard()
		: base("", XSize.Empty, CodeDirection.LeftToRight)
	{
	}

	public Code3of9Standard(string code)
		: base(code, XSize.Empty, CodeDirection.LeftToRight)
	{
	}

	public Code3of9Standard(string code, XSize size)
		: base(code, size, CodeDirection.LeftToRight)
	{
	}

	public Code3of9Standard(string code, XSize size, CodeDirection direction)
		: base(code, size, direction)
	{
	}

	private static bool[] ThickThinLines(char ch)
	{
		return Lines["0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*".IndexOf(ch)];
	}

	internal override void CalcThinBarWidth(BarCodeRenderInfo info)
	{
		double num = 13.0 + 6.0 * WideNarrowRatio + (3.0 * WideNarrowRatio + 7.0) * (double)base.Text.Length;
		info.ThinBarWidth = base.Size.Width / num;
	}

	protected override void CheckCode(string text)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		if (text.Length == 0)
		{
			throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
		}
		foreach (char value in text)
		{
			if ("0123456789ABCDEFGHIJKLMNOP'QRSTUVWXYZ-. $/+%*".IndexOf(value) < 0)
			{
				throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
			}
		}
	}

	protected internal override void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position)
	{
		XGraphicsState state = gfx.Save();
		BarCodeRenderInfo barCodeRenderInfo = new BarCodeRenderInfo(gfx, brush, font, position);
		InitRendering(barCodeRenderInfo);
		barCodeRenderInfo.CurrPosInString = 0;
		barCodeRenderInfo.CurrPos = position - CodeBase.CalcDistance(AnchorType.TopLeft, base.Anchor, base.Size);
		if (TurboBit)
		{
			RenderTurboBit(barCodeRenderInfo, startBit: true);
		}
		RenderStart(barCodeRenderInfo);
		while (barCodeRenderInfo.CurrPosInString < base.Text.Length)
		{
			RenderNextChar(barCodeRenderInfo);
			RenderGap(barCodeRenderInfo, isThick: false);
		}
		RenderStop(barCodeRenderInfo);
		if (TurboBit)
		{
			RenderTurboBit(barCodeRenderInfo, startBit: false);
		}
		if (base.TextLocation != TextLocation.None)
		{
			RenderText(barCodeRenderInfo);
		}
		gfx.Restore(state);
	}

	private void RenderNextChar(BarCodeRenderInfo info)
	{
		RenderChar(info, base.Text[info.CurrPosInString]);
		info.CurrPosInString++;
	}

	private void RenderChar(BarCodeRenderInfo info, char ch)
	{
		bool[] array = ThickThinLines(ch);
		for (int i = 0; i < 9; i += 2)
		{
			RenderBar(info, array[i]);
			if (i < 8)
			{
				RenderGap(info, array[i + 1]);
			}
		}
	}

	private void RenderStart(BarCodeRenderInfo info)
	{
		RenderChar(info, '*');
		RenderGap(info, isThick: false);
	}

	private void RenderStop(BarCodeRenderInfo info)
	{
		RenderChar(info, '*');
	}
}
