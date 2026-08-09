using System.Diagnostics;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public class AmbientOcclusionSettings
{
	internal enum _0023_003DzVZPmwzuJewLS
	{

	}

	public enum aoQuality
	{
		Low,
		Standard,
		Auto
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzVZPmwzuJewLS _0023_003DzsmRyu9M_003D;

	public bool Enabled;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz375j3d248T0g;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz2DVVtlA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static readonly float _0023_003Dz2t_v6DnM8indvXOkrg_003D_003D = 0.97f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static readonly int _0023_003Dz0lpxPEmp4iKm = 6;

	public float Radius
	{
		get
		{
			return _0023_003Dz375j3d248T0g;
		}
		set
		{
			if (value <= 0f)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651100));
			}
			_0023_003Dz375j3d248T0g = value;
		}
	}

	public float Strength
	{
		get
		{
			return _0023_003Dz2DVVtlA_003D;
		}
		set
		{
			if (value <= 0f)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651397));
			}
			_0023_003Dz2DVVtlA_003D = value;
		}
	}

	public AmbientOcclusionSettings(aoQuality quality, RenderContextBase renderContext)
	{
		if (quality == aoQuality.Auto)
		{
			quality = ((renderContext.Vendor != RenderContextBase.vendorName.Intel) ? aoQuality.Standard : aoQuality.Low);
		}
		Enabled = _0023_003DzlAUaJg4N2d6h();
		Radius = _0023_003DzUHa35AI_003D(quality);
		Strength = _0023_003DzfFcDuZw_003D(quality);
		_0023_003DzsmRyu9M_003D = _0023_003DzoiZyf6g_003D(quality);
	}

	internal static bool _0023_003DzlAUaJg4N2d6h()
	{
		return true;
	}

	internal static float _0023_003DzUHa35AI_003D(aoQuality _0023_003Dzi8OTyx4_003D)
	{
		if (_0023_003Dzi8OTyx4_003D != aoQuality.Low)
		{
			return 0.125f;
		}
		return 0.06f;
	}

	internal static float _0023_003DzfFcDuZw_003D(aoQuality _0023_003Dzi8OTyx4_003D)
	{
		if (_0023_003Dzi8OTyx4_003D != aoQuality.Low)
		{
			return 0.72f;
		}
		return 0.76f;
	}

	internal static _0023_003DzVZPmwzuJewLS _0023_003DzoiZyf6g_003D(aoQuality _0023_003Dzi8OTyx4_003D)
	{
		if (_0023_003Dzi8OTyx4_003D != aoQuality.Low)
		{
			return (_0023_003DzVZPmwzuJewLS)0;
		}
		return (_0023_003DzVZPmwzuJewLS)1;
	}
}
