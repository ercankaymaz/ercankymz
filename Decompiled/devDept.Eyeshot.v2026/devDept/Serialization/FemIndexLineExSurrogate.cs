using devDept.Geometry;

namespace devDept.Serialization;

internal class FemIndexLineExSurrogate : IndexLineSurrogate
{
	public int ElementIndex;

	internal FemIndexLineExSurrogate(_0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D femLine)
		: base(femLine)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D(ElementIndex, V1, V2);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		_0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D2 = indexLine as _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D;
		ElementIndex = _0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D2._0023_003DzZpBiVcbHFG6Q();
		base.CopyDataFromObject((IndexLine)_0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D2);
	}
}
