using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using SharpDX;
using devDept.Graphics;

internal sealed class _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg : IDataPerFrame
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<Vector4, float[]> _0023_003Dz_0024SrjenGt9S28G3OXJQ_003D_003D;

		internal float[] _0023_003DzDgW24Kgxq3dBSMze6GQOXkxvBFit3QM_0024YIATBdyni7RnOVckxA_003D_003D(Vector4 _0023_003Dz3gif_00241c_003D)
		{
			return new float[4] { _0023_003Dz3gif_00241c_003D.X, _0023_003Dz3gif_00241c_003D.Y, _0023_003Dz3gif_00241c_003D.Z, _0023_003Dz3gif_00241c_003D.W };
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D[] _0023_003Dz85RDWW0DIFz1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4[] _0023_003Dz1fK2GcGGTTUi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public ClipPlanesFlags _0023_003DzUqa5ZahBwV4C;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Size _0023_003Dzqi43Drs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzZ3fch5dza_0024CRK2uxSg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003Dz32GKgec08ez24iO1GoJN_0024Jo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzbZaEBGfi6pRqQLgzRWBlJI8_003D _0023_003Dzh7lnYlk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D _0023_003Dz7gYTKaY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzBZqKi9_76oEQ2QKT5OKd_P31Xknr _0023_003DziTBvd4gT_FEx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzGIlo6jT1J5yXKOS746hxfodt7rnz _0023_003DzCAYiSntwkyBK8cn_YQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3 _0023_003Dz_XLU34E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzQusP5X6k0YDE_L4IZSi73sV2mg11Iblsqg_003D_003D _0023_003DzLmTHH5_Q8vG_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003Dz7yxtDMjN_0024R0grLY3Ejh32Nz_0024Sfyy8MmIpo14K_0024w_003D _0023_003DzSQcL1HJvCFIk2E8pDQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003DzF97mX6ysdyON;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzNWHuAcLuYE2NaFLPZ0qfl9Q_003D _0023_003DzhAQ5JLY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003Dzemb5TmiWZnwc;

	public _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg(int _0023_003Dzrx4oe3HH1bqs)
	{
		_0023_003Dz85RDWW0DIFz1 = new _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D[_0023_003Dzrx4oe3HH1bqs];
		_0023_003Dz1fK2GcGGTTUi = new Vector4[6];
	}

	private ILightsData[] _0023_003DzAf4PrHPQ3w_0024BK22UxWmsdNbmykv_0024YQJGLKgkRs8_003D()
	{
		return _0023_003Dz85RDWW0DIFz1.Cast<ILightsData>().ToArray();
	}

	ILightsData[] IDataPerFrame.get_Lights()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAf4PrHPQ3w$BK22UxWmsdNbmykv$YQJGLKgkRs8=
		return this._0023_003DzAf4PrHPQ3w_0024BK22UxWmsdNbmykv_0024YQJGLKgkRs8_003D();
	}

	private Size _0023_003Dzg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w_003D_003D()
	{
		return _0023_003Dzqi43Drs_003D;
	}

	Size IDataPerFrame.get_ViewportSize()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w==
		return this._0023_003Dzg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w_003D_003D();
	}

	private bool[] _0023_003DzAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4_003D()
	{
		bool[] array = new bool[6];
		for (int i = 0; i < ((ClipPlanesFlags[])Enum.GetValues(typeof(ClipPlanesFlags))).Length; i++)
		{
			ClipPlanesFlags clipPlanesFlags = ((ClipPlanesFlags[])Enum.GetValues(typeof(ClipPlanesFlags)))[i];
			array[i] = (_0023_003DzUqa5ZahBwV4C & clipPlanesFlags) != 0;
		}
		return array;
	}

	bool[] IDataPerFrame.get_ClipPlanesEnabled()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4=
		return this._0023_003DzAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4_003D();
	}

	private float[][] _0023_003DzSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g_003D_003D()
	{
		return _0023_003Dz1fK2GcGGTTUi.Select((Vector4 _0023_003Dz3gif_00241c_003D) => new float[4] { _0023_003Dz3gif_00241c_003D.X, _0023_003Dz3gif_00241c_003D.Y, _0023_003Dz3gif_00241c_003D.Z, _0023_003Dz3gif_00241c_003D.W }).ToArray();
	}

	float[][] IDataPerFrame.get_ClipPlanes()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g==
		return this._0023_003DzSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g_003D_003D();
	}
}
