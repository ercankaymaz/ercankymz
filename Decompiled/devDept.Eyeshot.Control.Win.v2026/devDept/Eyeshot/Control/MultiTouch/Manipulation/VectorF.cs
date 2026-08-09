using System;
using System.Diagnostics;
using System.Drawing;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public struct VectorF(float x, float y)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzbei4D4M_003D = x;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzV4PZTJs_003D = y;

	public float X
	{
		get
		{
			return _0023_003Dzbei4D4M_003D;
		}
		set
		{
			_0023_003Dzbei4D4M_003D = value;
		}
	}

	public float Y
	{
		get
		{
			return _0023_003DzV4PZTJs_003D;
		}
		set
		{
			_0023_003DzV4PZTJs_003D = value;
		}
	}

	public float Magnitude => (float)Math.Sqrt(_0023_003Dzbei4D4M_003D * _0023_003Dzbei4D4M_003D + _0023_003DzV4PZTJs_003D * _0023_003DzV4PZTJs_003D);

	public VectorF Direction => new VectorF(Math.Sign(_0023_003Dzbei4D4M_003D), Math.Sign(_0023_003DzV4PZTJs_003D));

	public override string ToString()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621271) + _0023_003Dzbei4D4M_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587155) + _0023_003DzV4PZTJs_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621295);
	}

	public override bool Equals(object obj)
	{
		VectorF vectorF;
		try
		{
			vectorF = (VectorF)obj;
		}
		catch
		{
			return false;
		}
		if (obj != null && vectorF._0023_003Dzbei4D4M_003D == _0023_003Dzbei4D4M_003D)
		{
			return vectorF._0023_003DzV4PZTJs_003D == _0023_003DzV4PZTJs_003D;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _0023_003Dzbei4D4M_003D.GetHashCode() ^ _0023_003DzV4PZTJs_003D.GetHashCode();
	}

	public static implicit operator Size(VectorF vector)
	{
		return new Size((int)vector.X, (int)vector.Y);
	}

	public static implicit operator SizeF(VectorF vector)
	{
		return new SizeF(vector.X, vector.Y);
	}

	public static implicit operator VectorF(Size size)
	{
		return new VectorF(size.Width, size.Height);
	}

	public static implicit operator VectorF(SizeF size)
	{
		return new VectorF(size.Width, size.Height);
	}

	public static VectorF operator *(VectorF vector, float value)
	{
		return new VectorF(vector._0023_003Dzbei4D4M_003D * value, vector._0023_003DzV4PZTJs_003D * value);
	}

	public static VectorF operator /(VectorF vector, float value)
	{
		return vector * (1f / value);
	}

	public static VectorF operator +(VectorF vector, float value)
	{
		return new VectorF(vector._0023_003Dzbei4D4M_003D + value, vector._0023_003DzV4PZTJs_003D + value);
	}

	public static VectorF operator -(VectorF vector, float value)
	{
		return vector + (0f - value);
	}

	public static VectorF operator +(VectorF v1, VectorF v2)
	{
		return new VectorF(v1._0023_003Dzbei4D4M_003D + v2._0023_003Dzbei4D4M_003D, v1._0023_003DzV4PZTJs_003D + v2._0023_003DzV4PZTJs_003D);
	}

	public static VectorF operator -(VectorF v1, VectorF v2)
	{
		return new VectorF(v1._0023_003Dzbei4D4M_003D - v2._0023_003Dzbei4D4M_003D, v1._0023_003DzV4PZTJs_003D - v2._0023_003DzV4PZTJs_003D);
	}
}
