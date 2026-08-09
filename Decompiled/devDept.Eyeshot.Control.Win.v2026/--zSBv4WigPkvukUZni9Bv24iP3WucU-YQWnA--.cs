using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX;
using devDept.Geometry;
using devDept.Graphics;

internal struct _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D : _0023_003DzxlkUGOHLNznjaogT7e4XpG7_0024jwSH
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dz3H8zn1o3bgUt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003DzQRU_vpOXGgqZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dzm3_sUXCbDN_7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003DzXGtLFE6smDJY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dzi1e8L0WJl_Qe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dzz8QxsNxE2sqU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dzrz3HG9wpQRcy8qIuOQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzAb_0imxENGIHzLhTmQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzBZnAvZv8nMAvCrbE5A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzgF_0024eocoobLjg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DztEZdLXRj7Ygl;

	[SpecialName]
	public int _0023_003DzL2jAKGI_003D()
	{
		return Marshal.SizeOf(this);
	}

	public void _0023_003DzshPEPAc_003D(_0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003DzcHHD1CU_003D)
	{
		_0023_003Dz3H8zn1o3bgUt = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[0];
		_0023_003DzQRU_vpOXGgqZ = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[1];
		_0023_003Dzm3_sUXCbDN_7 = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[2];
		_0023_003DzXGtLFE6smDJY = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[3];
		_0023_003Dzi1e8L0WJl_Qe = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[4];
		_0023_003Dzz8QxsNxE2sqU = _0023_003DzcHHD1CU_003D._0023_003Dz1fK2GcGGTTUi[5];
		for (int i = 0; i < 4; i++)
		{
			_0023_003Dzrz3HG9wpQRcy8qIuOQ_003D_003D[i] = (FlagsHelper.IsSet(_0023_003DzcHHD1CU_003D._0023_003DzUqa5ZahBwV4C, (ClipPlanesFlags)(1 << i)) ? 1 : 0);
		}
		_0023_003DzAb_0imxENGIHzLhTmQ_003D_003D = (FlagsHelper.IsSet(_0023_003DzcHHD1CU_003D._0023_003DzUqa5ZahBwV4C, ClipPlanesFlags.Five) ? 1 : 0);
		_0023_003DzBZnAvZv8nMAvCrbE5A_003D_003D = (FlagsHelper.IsSet(_0023_003DzcHHD1CU_003D._0023_003DzUqa5ZahBwV4C, ClipPlanesFlags.Six) ? 1 : 0);
		_0023_003DzgF_0024eocoobLjg = _0023_003DzcHHD1CU_003D._0023_003Dzqi43Drs_003D.Width;
		_0023_003DztEZdLXRj7Ygl = _0023_003DzcHHD1CU_003D._0023_003Dzqi43Drs_003D.Height;
	}
}
