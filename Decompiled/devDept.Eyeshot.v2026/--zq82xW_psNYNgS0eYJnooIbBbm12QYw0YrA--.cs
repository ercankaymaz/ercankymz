using System.Diagnostics;
using devDept.Geometry;
using devDept.Serialization;

internal sealed class _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D : IndexLine
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzKAXXKpk_003D;

	public _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D(int _0023_003DzCu0z7Go_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
		: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D)
	{
		_0023_003DzKAXXKpk_003D = _0023_003DzCu0z7Go_003D;
	}

	public int _0023_003DzZpBiVcbHFG6Q()
	{
		return _0023_003DzKAXXKpk_003D;
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new FemIndexLineExSurrogate(this);
	}
}
