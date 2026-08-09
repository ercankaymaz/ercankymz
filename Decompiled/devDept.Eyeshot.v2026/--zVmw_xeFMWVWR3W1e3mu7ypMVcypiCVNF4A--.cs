using System.Collections.Generic;
using devDept.Eyeshot.Entities;

internal sealed class _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D : _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D
{
	public _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D()
	{
	}

	public _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
		: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D)
	{
	}

	internal void _0023_003Dz0a2mD4XWI3cV(double _0023_003DzQpgdmPmBYnXsPKYhXQ_003D_003D)
	{
		int length = ScreenVertices.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			ScreenVertices[i, 2] = _0023_003DzQpgdmPmBYnXsPKYhXQ_003D_003D;
		}
	}
}
