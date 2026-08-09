using System;
using System.Diagnostics;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D : _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dz5Ez4PotpLPPYMKiUUXfDS3pqGw5N;

	public _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(Point3D[] _0023_003DzrdSL0CI_003D, bool _0023_003DzcaGByDs7xCqDXTICQFdDcOs_003D = false)
		: base(_0023_003DzrdSL0CI_003D)
	{
		if (Machining._0023_003DzySfSteI_003D(_0023_003DzrdSL0CI_003D) || Machining._0023_003Dz6QH8iAk_003D(_0023_003DzrdSL0CI_003D))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995469));
		}
		_0023_003Dz5Ez4PotpLPPYMKiUUXfDS3pqGw5N = _0023_003DzcaGByDs7xCqDXTICQFdDcOs_003D;
	}

	public _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzl_0024MIsC0_003D)
		: base(_0023_003Dzl_0024MIsC0_003D)
	{
	}

	public override bool _0023_003Dz9h5MY_A_003D(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		if (_0023_003Dz5Ez4PotpLPPYMKiUUXfDS3pqGw5N)
		{
			return base._0023_003Dz9h5MY_A_003D(_0023_003DzrdSL0CI_003D);
		}
		return false;
	}

	public override object Clone()
	{
		return new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(this);
	}
}
