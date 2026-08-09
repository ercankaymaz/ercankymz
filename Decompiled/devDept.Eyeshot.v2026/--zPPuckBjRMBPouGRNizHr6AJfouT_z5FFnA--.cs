using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

internal class _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D : SilhoWireAndTriangleData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float[,] _0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double[,] _0023_003DzyEHfeaefm2j6YGUAZ7IhouA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzcEFLt3aiIQTq;

	public _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, bool _0023_003DzpaBsULpDiecO)
		: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzpaBsULpDiecO)
	{
	}

	public void _0023_003DzT6h2a5Uo_xh_k0A373XWitc_003D(RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj)
	{
		if (_0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D != null)
		{
			_0023_003DzyEHfeaefm2j6YGUAZ7IhouA_003D = GfxSilhoData.ComputeScreenVertices(_0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D, _0023_003DzQdnFby4_003D, Transformation, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj);
		}
	}
}
