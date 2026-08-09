using System.Collections.Generic;
using devDept.Geometry;

internal sealed class _0023_003DzP2xU3RkFOv3JEcISlX9sc62XVJ_xmxNZfKT00tM_003D : IEqualityComparer<IndexLine>
{
	public bool Equals(IndexLine _0023_003DzBJFJHwk_003D, IndexLine _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D.V1 != _0023_003Dz40R7bAU_003D.V1 || _0023_003DzBJFJHwk_003D.V2 != _0023_003Dz40R7bAU_003D.V2)
		{
			if (_0023_003DzBJFJHwk_003D.V1 == _0023_003Dz40R7bAU_003D.V2)
			{
				return _0023_003DzBJFJHwk_003D.V2 == _0023_003Dz40R7bAU_003D.V1;
			}
			return false;
		}
		return true;
	}

	public int GetHashCode(IndexLine _0023_003DzUBZd570_003D)
	{
		return _0023_003DzUBZd570_003D.V1.GetHashCode() ^ _0023_003DzUBZd570_003D.V2.GetHashCode();
	}
}
