using System.Diagnostics;
using devDept.Geometry;
using devDept.Serialization;

internal sealed class _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D : IndexTriangle
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzKAXXKpk_003D;

	public _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D(int _0023_003DzCu0z7Go_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
		: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D)
	{
		_0023_003DzKAXXKpk_003D = _0023_003DzCu0z7Go_003D;
	}

	protected _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D(_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D _0023_003DzySgeilxprQOK)
		: base(_0023_003DzySgeilxprQOK)
	{
		_0023_003DzKAXXKpk_003D = _0023_003DzySgeilxprQOK._0023_003DzZpBiVcbHFG6Q();
	}

	public int _0023_003DzZpBiVcbHFG6Q()
	{
		return _0023_003DzKAXXKpk_003D;
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new FemIndexTriangleExSurrogate(this);
	}
}
