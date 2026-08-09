using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzV2oSLtcAc39qqlMrcWLrfkiOffeoj3MRlQjciWdrVNGT : _0023_003DznhE6nBcx_00243RtCTZj99SXz6_0024_scowomsqk_dL6AvwMiBpqsE4hA_003D_003D
{
	public _0023_003DzV2oSLtcAc39qqlMrcWLrfkiOffeoj3MRlQjciWdrVNGT(_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y, _0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY, Segment2D _0023_003DzFDJdA7A_003D = null)
		: base(_0023_003DzsiQjbwmUNI0y, _0023_003DzSElTn3BlQAJY, _0023_003DzFDJdA7A_003D)
	{
		if (_0023_003DzsiQjbwmUNI0y._0023_003Dz40R7bAU_003D != _0023_003DzSElTn3BlQAJY._0023_003Dz40R7bAU_003D)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994567));
		}
	}

	public _0023_003DzV2oSLtcAc39qqlMrcWLrfkiOffeoj3MRlQjciWdrVNGT(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
		: base(_0023_003DzhidJeNw_003D)
	{
	}

	public void _0023_003DzOtJLa_0024I_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, double _0023_003Dz9NrCn_o_003D)
	{
		Line line = new Line(_0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D, _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D, _0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D, _0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D);
		line.ColorMethod = colorMethodType.byEntity;
		line.Color = Color.FromArgb(50, Color.Red);
		_0023_003DzWc9WmS8VMsuA.Add(line);
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003DzhoegMB067LVL)
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = _0023_003DzlY77YgY_003D(item._0023_003Dz6V_0024QadA_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = _0023_003DzlY77YgY_003D(item._0023_003DzCskoEKg_003D);
			Line line2 = new Line(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D, _0023_003DzmKBPh7nOT6nY3._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY3._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY3._0023_003DzId5C3LA_003D);
			line2.LineWeightMethod = colorMethodType.byEntity;
			line2.LineWeight = 2f;
			line2.ColorMethod = colorMethodType.byEntity;
			line2.Color = Color.Red;
			_0023_003DzWc9WmS8VMsuA.Add(line2);
		}
	}
}
