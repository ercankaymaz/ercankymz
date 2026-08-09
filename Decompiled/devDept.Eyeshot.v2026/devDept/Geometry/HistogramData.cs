using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Geometry;

public class HistogramData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzKwa7gCXExwvsf0KoPAglxOI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzgukVc0cjf1gmA1zBbKrOJG8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz2nOMtqYeuBX2HRocw3G_0024BNA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Tuple<double, double, int>[] _0023_003DzYsuAVO0BqdGI99lrz_0024wcCh8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzQTJw_0024UKah960TMPUhA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzjYg_0024ZT2ljqD6MYDP8FR90dE_003D;

	public int TotalHits
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzKwa7gCXExwvsf0KoPAglxOI_003D;
		}
	}

	public int Larger
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzgukVc0cjf1gmA1zBbKrOJG8_003D;
		}
	}

	public int Smaller
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2nOMtqYeuBX2HRocw3G_0024BNA_003D;
		}
	}

	public Tuple<double, double, int>[] Bins
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYsuAVO0BqdGI99lrz_0024wcCh8_003D;
		}
	}

	public double Max
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D;
		}
	}

	public double Min
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQTJw_0024UKah960TMPUhA_003D_003D;
		}
	}

	public double Mean
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzjYg_0024ZT2ljqD6MYDP8FR90dE_003D;
		}
	}

	public HistogramData(int totalHits, int larger, int smaller, double max, double min, double mean, Tuple<double, double, int>[] bins)
	{
		_0023_003DzKwa7gCXExwvsf0KoPAglxOI_003D = totalHits;
		_0023_003DzgukVc0cjf1gmA1zBbKrOJG8_003D = larger;
		_0023_003Dz2nOMtqYeuBX2HRocw3G_0024BNA_003D = smaller;
		if (TotalHits > 0)
		{
			_0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D = max;
			_0023_003DzQTJw_0024UKah960TMPUhA_003D_003D = min;
			_0023_003DzjYg_0024ZT2ljqD6MYDP8FR90dE_003D = mean;
			_0023_003DzYsuAVO0BqdGI99lrz_0024wcCh8_003D = bins;
		}
	}
}
