using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class ManipulationDeltaEventArgs : ManipulationCompletedEventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SizeF _0023_003DzYrH0lnAnV79bsBplX_0024Y9ooo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzB4h1ZDk1yKi22N0xL31l5Zk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzo65hSH_0024nqymi90ryJP6fGzQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzz9lLO4OaMCFzbmWYMZq_00248g4_003D;

	public SizeF TranslationDelta
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYrH0lnAnV79bsBplX_0024Y9ooo_003D;
		}
	}

	public float ScaleDelta
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzB4h1ZDk1yKi22N0xL31l5Zk_003D;
		}
	}

	public float ExpansionDelta
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzo65hSH_0024nqymi90ryJP6fGzQ_003D;
		}
	}

	public float RotationDelta
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzz9lLO4OaMCFzbmWYMZq_00248g4_003D;
		}
	}

	public ManipulationDeltaEventArgs(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta, float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
		: base(x, y, cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation)
	{
		_0023_003DzzurMOAyiwpTq(new SizeF(translationDeltaX, translationDeltaY));
		_0023_003DzAdjhHvkHvcDz(scaleDelta);
		_0023_003Dzttlo4leDiUSb(expansionDelta);
		_0023_003DzmYdLVsPZ8GTu(rotationDelta);
	}

	private void _0023_003DzzurMOAyiwpTq(SizeF _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzYrH0lnAnV79bsBplX_0024Y9ooo_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzAdjhHvkHvcDz(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzB4h1ZDk1yKi22N0xL31l5Zk_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dzttlo4leDiUSb(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzo65hSH_0024nqymi90ryJP6fGzQ_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzmYdLVsPZ8GTu(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzz9lLO4OaMCFzbmWYMZq_00248g4_003D = _0023_003DzsLHxXyo_003D;
	}
}
