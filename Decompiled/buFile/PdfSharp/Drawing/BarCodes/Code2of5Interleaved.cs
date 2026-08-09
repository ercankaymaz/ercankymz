namespace PdfSharp.Drawing.BarCodes;

public class Code2of5Interleaved : ThickThinBarCode
{
	private static bool[][] Lines = new bool[10][]
	{
		new bool[5] { false, false, true, true, false },
		new bool[5] { true, false, false, false, true },
		new bool[5] { false, true, false, false, true },
		new bool[5] { true, true, false, false, false },
		new bool[5] { false, false, true, false, true },
		new bool[5] { true, false, true, false, false },
		new bool[5] { false, true, true, false, false },
		new bool[5] { false, false, false, true, true },
		new bool[5] { true, false, false, true, false },
		new bool[5] { false, true, false, true, false }
	};

	public Code2of5Interleaved()
		: base("", XSize.Empty, CodeDirection.LeftToRight)
	{
	}

	public Code2of5Interleaved(string code)
		: base(code, XSize.Empty, CodeDirection.LeftToRight)
	{
	}

	public Code2of5Interleaved(string code, XSize size)
		: base(code, size, CodeDirection.LeftToRight)
	{
	}

	public Code2of5Interleaved(string code, XSize size, CodeDirection direction)
		: base(code, size, direction)
	{
	}

	private static bool[] ThickAndThinLines(int digit)
	{
		return Lines[digit];
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
			RenderNextPair(barCodeRenderInfo);
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

	internal override void CalcThinBarWidth(BarCodeRenderInfo info)
	{
		double num = 6.0 + WideNarrowRatio + (2.0 * WideNarrowRatio + 3.0) * (double)base.Text.Length;
		info.ThinBarWidth = base.Size.Width / num;
	}

	private void RenderStart(BarCodeRenderInfo info)
	{
		RenderBar(info, isThick: false);
		RenderGap(info, isThick: false);
		RenderBar(info, isThick: false);
		RenderGap(info, isThick: false);
	}

	private void RenderStop(BarCodeRenderInfo info)
	{
		RenderBar(info, isThick: true);
		RenderGap(info, isThick: false);
		RenderBar(info, isThick: false);
	}

	private void RenderNextPair(BarCodeRenderInfo info)
	{
		int num = int.Parse(base.Text[info.CurrPosInString].ToString());
		int num2 = int.Parse(base.Text[info.CurrPosInString + 1].ToString());
		bool[] array = Lines[num];
		bool[] array2 = Lines[num2];
		for (int i = 0; i < 5; i++)
		{
			RenderBar(info, array[i]);
			RenderGap(info, array2[i]);
		}
		info.CurrPosInString += 2;
	}

	protected override void CheckCode(string text)
	{
	}
}
