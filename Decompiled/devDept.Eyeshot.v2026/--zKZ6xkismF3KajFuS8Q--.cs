using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzKZ6xkismF3KajFuS8Q_003D_003D : IComparer<_0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Curve _0023_003DzlhS8HxeSpLWK;

	public _0023_003DzKZ6xkismF3KajFuS8Q_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE)
	{
		_0023_003DzlhS8HxeSpLWK = _0023_003Dz8fpRyMu9aKjE;
	}

	public int Compare(_0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D _0023_003DzBJFJHwk_003D, _0023_003Dzw2IRp8aR85UjyKjkgPf_Jq4_003D _0023_003Dz40R7bAU_003D)
	{
		_0023_003DzlhS8HxeSpLWK.Project(new Point3D(_0023_003DzBJFJHwk_003D._0023_003DzpdeSbFA_003D._0023_003DzR216mFc_003D(), _0023_003DzBJFJHwk_003D._0023_003DzpdeSbFA_003D._0023_003DzqJqZpJk_003D()), out var t);
		_0023_003DzlhS8HxeSpLWK.Project(new Point3D(_0023_003Dz40R7bAU_003D._0023_003DzpdeSbFA_003D._0023_003DzR216mFc_003D(), _0023_003Dz40R7bAU_003D._0023_003DzpdeSbFA_003D._0023_003DzqJqZpJk_003D()), out var t2);
		if (t < t2)
		{
			return -1;
		}
		if (t > t2)
		{
			return 1;
		}
		return 0;
	}
}
