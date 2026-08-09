using System.Diagnostics;

namespace devDept.Eyeshot.Control.Mouse3D;

public class TranslationVector
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8GBMuoM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJU0R6e0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmZWYhFQ_003D;

	public int X
	{
		get
		{
			return _0023_003Dz8GBMuoM_003D;
		}
		set
		{
			_0023_003Dz8GBMuoM_003D = value;
		}
	}

	public int Y
	{
		get
		{
			return _0023_003DzJU0R6e0_003D;
		}
		set
		{
			_0023_003DzJU0R6e0_003D = value;
		}
	}

	public int Z
	{
		get
		{
			return _0023_003DzmZWYhFQ_003D;
		}
		set
		{
			_0023_003DzmZWYhFQ_003D = value;
		}
	}

	public TranslationVector(int x, int y, int z)
	{
		_0023_003Dz8GBMuoM_003D = x;
		_0023_003DzJU0R6e0_003D = y;
		_0023_003DzmZWYhFQ_003D = z;
	}

	public TranslationVector(byte xl, byte xh, byte yl, byte yh, byte zl, byte zh)
	{
		_0023_003Dz8GBMuoM_003D = xl + (short)(xh << 8);
		_0023_003DzJU0R6e0_003D = yl + (short)(yh << 8);
		_0023_003DzmZWYhFQ_003D = zl + (short)(zh << 8);
	}
}
