using System;
using System.Diagnostics;

internal class _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D : IComparable<_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D>, IEquatable<_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dz2QVVx8s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dz7uX3t_0024g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzBJFJHwk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003Dz40R7bAU_003D;

	public _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D()
		: this(0.0, 0.0, 0)
	{
	}

	public _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
		: this(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, 0)
	{
	}

	public _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, int _0023_003Dz7uX3t_0024g_003D)
	{
		this._0023_003DzBJFJHwk_003D = _0023_003DzBJFJHwk_003D;
		this._0023_003Dz40R7bAU_003D = _0023_003Dz40R7bAU_003D;
		this._0023_003Dz7uX3t_0024g_003D = _0023_003Dz7uX3t_0024g_003D;
	}

	public int _0023_003DzOq3xSxQ_003D()
	{
		return _0023_003Dz2QVVx8s_003D;
	}

	public void _0023_003Dzbtz8t3g_003D(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz2QVVx8s_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public double _0023_003DzR216mFc_003D()
	{
		return _0023_003DzBJFJHwk_003D;
	}

	public void _0023_003Dz8vQIrOc_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzBJFJHwk_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public double _0023_003DzqJqZpJk_003D()
	{
		return _0023_003Dz40R7bAU_003D;
	}

	public void _0023_003DzsMht64A_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz40R7bAU_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public int _0023_003Dz8F8_002454umdoK7()
	{
		return _0023_003Dz7uX3t_0024g_003D;
	}

	public void _0023_003DzebfWBK1CW3R8(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz7uX3t_0024g_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static bool operator ==(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz1v6oPQk_003D)
	{
		if ((object)_0023_003DzjbqS1qE_003D == _0023_003Dz1v6oPQk_003D)
		{
			return true;
		}
		if ((object)_0023_003DzjbqS1qE_003D == null || (object)_0023_003Dz1v6oPQk_003D == null)
		{
			return false;
		}
		return _0023_003DzjbqS1qE_003D.Equals(_0023_003Dz1v6oPQk_003D);
	}

	public static bool operator !=(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz1v6oPQk_003D)
	{
		return !(_0023_003DzjbqS1qE_003D == _0023_003Dz1v6oPQk_003D);
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null)
		{
			return false;
		}
		if (!(_0023_003DzCX9Hbao_003D is _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2))
		{
			return false;
		}
		if (_0023_003DzBJFJHwk_003D == _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003DzBJFJHwk_003D)
		{
			return _0023_003Dz40R7bAU_003D == _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003Dz40R7bAU_003D;
		}
		return false;
	}

	public bool Equals(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzB68dg9Q_003D)
	{
		if ((object)_0023_003DzB68dg9Q_003D == null)
		{
			return false;
		}
		if (_0023_003DzBJFJHwk_003D == _0023_003DzB68dg9Q_003D._0023_003DzBJFJHwk_003D)
		{
			return _0023_003Dz40R7bAU_003D == _0023_003DzB68dg9Q_003D._0023_003Dz40R7bAU_003D;
		}
		return false;
	}

	public int CompareTo(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzl_0024MIsC0_003D)
	{
		if (_0023_003DzBJFJHwk_003D == _0023_003Dzl_0024MIsC0_003D._0023_003DzBJFJHwk_003D && _0023_003Dz40R7bAU_003D == _0023_003Dzl_0024MIsC0_003D._0023_003Dz40R7bAU_003D)
		{
			return 0;
		}
		if (!(_0023_003DzBJFJHwk_003D < _0023_003Dzl_0024MIsC0_003D._0023_003DzBJFJHwk_003D) && (_0023_003DzBJFJHwk_003D != _0023_003Dzl_0024MIsC0_003D._0023_003DzBJFJHwk_003D || !(_0023_003Dz40R7bAU_003D < _0023_003Dzl_0024MIsC0_003D._0023_003Dz40R7bAU_003D)))
		{
			return 1;
		}
		return -1;
	}

	public override int GetHashCode()
	{
		return (589 + _0023_003DzBJFJHwk_003D.GetHashCode()) * 31 + _0023_003Dz40R7bAU_003D.GetHashCode();
	}
}
