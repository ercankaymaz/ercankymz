using devDept.Geometry;

namespace devDept.Serialization;

internal class FemIndexTriangleExSurrogate : IndexTriangleSurrogate
{
	public int ElementIndex;

	public FemIndexTriangleExSurrogate(_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D femTriangle)
		: base(femTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D(ElementIndex, V1, V2, V3);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D2 = indexLine as _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D;
		ElementIndex = _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D2._0023_003DzZpBiVcbHFG6Q();
		base.CopyDataFromObject((IndexLine)_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D2);
	}
}
