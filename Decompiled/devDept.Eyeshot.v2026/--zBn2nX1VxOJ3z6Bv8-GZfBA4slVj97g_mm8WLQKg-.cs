using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D : Surface
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003Dz7hXUtT7ffWX8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzwZjB5_0024kmWLTS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzhXoXCKX2qGGs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzL_Qv_0024EzJSgtd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzdVfRw54_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzGs8Ckd8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003DzfJdUwUS3T7T9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point2D _0023_003DzMW_0024k_Ek_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003Dzj9kq7RRev6fS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzWQkHZg1gwsuM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003Dz4HORVLMTh3sl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzcEtgsKPBRsl2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector2D _0023_003DzxmoHVeQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Size2D _0023_003DzQYemG2g_0024x8w3zBVjMQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D _0023_003DzF7v9r2A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D _0023_003Dz8dK2uhU_003D;

	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D()
	{
	}

	public _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D(_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzySgeilxprQOK)
		: this()
	{
		_0023_003DzB68dg9Q_003D = _0023_003DzySgeilxprQOK._0023_003DzB68dg9Q_003D;
		_0023_003DziP9fFuA_003D = (double[])_0023_003DzySgeilxprQOK._0023_003DziP9fFuA_003D.Clone();
		q = _0023_003DzySgeilxprQOK.q;
		V = (double[])_0023_003DzySgeilxprQOK.V.Clone();
		Pw = new Point4D[_0023_003DzySgeilxprQOK.Pw.GetLength(0), _0023_003DzySgeilxprQOK.Pw.GetLength(1)];
		for (int i = 0; i < Pw.GetLength(0); i++)
		{
			for (int j = 0; j < Pw.GetLength(1); j++)
			{
				Pw[i, j] = (Point4D)_0023_003DzySgeilxprQOK.Pw[i, j].Clone();
			}
		}
		_0023_003DzCq59RVw_003D = _0023_003DzySgeilxprQOK._0023_003DzCq59RVw_003D;
		_0023_003Dzoa6bboA_003D = _0023_003DzySgeilxprQOK._0023_003Dzoa6bboA_003D;
		_0023_003Dz1c2CfcL6J3Hu = _0023_003DzySgeilxprQOK._0023_003Dz1c2CfcL6J3Hu;
		_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = _0023_003DzySgeilxprQOK._0023_003DzjuYKWBBXI34x4GCzLw_003D_003D;
	}

	public override object Clone()
	{
		return new _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D(this);
	}

	public bool _0023_003Dz8WVqzxw7BhZD19zKSk8S2jg_003D(double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz0mZ4_0024fFWxsTX, out _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzpNUGTDJpdp7L, out _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzSeQxWSWveqlL)
	{
		if (_0023_003DzqGVCgrBynBx__0zpNyyIoDq1UDfHNc80x4V1z5BRniPJF0BHLg_003D_003D._0023_003DzQrARryI_003D(this, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0mZ4_0024fFWxsTX))
		{
			_0023_003DzpNUGTDJpdp7L = null;
			_0023_003DzSeQxWSWveqlL = null;
			return false;
		}
		bool _0023_003DzznNob5FrfbeE = !_0023_003DzGs8Ckd8_003D;
		_0023_003DzqGVCgrBynBx__0zpNyyIoDq1UDfHNc80x4V1z5BRniPJF0BHLg_003D_003D._0023_003Dzy_0024uREk2ktPM6(this, out _0023_003DzpNUGTDJpdp7L, out _0023_003DzSeQxWSWveqlL, _0023_003DzznNob5FrfbeE);
		return true;
	}
}
