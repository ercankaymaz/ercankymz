using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Meshing;

public class SizesOnCurve
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzavUSxyjvW3LHCOGB6g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzYhISA5F84UxtMrntew_003D_003D;

	public double StartSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzavUSxyjvW3LHCOGB6g_003D_003D;
		}
	}

	public double EndSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYhISA5F84UxtMrntew_003D_003D;
		}
	}

	public SizesOnCurve(double size)
	{
		if (size < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991312), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991289));
		}
		_0023_003DzavUSxyjvW3LHCOGB6g_003D_003D = (_0023_003DzYhISA5F84UxtMrntew_003D_003D = size);
	}

	public SizesOnCurve(double startSize, double endSize)
	{
		if (startSize < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991255), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991236));
		}
		if (endSize < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990954), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990931));
		}
		_0023_003DzavUSxyjvW3LHCOGB6g_003D_003D = startSize;
		_0023_003DzYhISA5F84UxtMrntew_003D_003D = endSize;
	}

	public SizesOnCurve Swap()
	{
		return new SizesOnCurve(EndSize, StartSize);
	}
}
