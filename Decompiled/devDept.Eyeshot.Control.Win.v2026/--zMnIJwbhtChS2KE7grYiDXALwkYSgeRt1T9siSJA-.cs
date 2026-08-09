using System;
using devDept.Eyeshot;
using devDept.Eyeshot.Control.Labels;
using devDept.Geometry.ConstraintSolver;

internal sealed class _0023_003DzMnIJwbhtChS2KE7grYiDXALwkYSgeRt1T9siSJA_003D : ILabelFactory
{
	public IStackedLabel Create(labelType _0023_003DzhklmJFQ_003D, SketchCurve _0023_003DzSLnz75LnM5Rs, Constraint _0023_003Dzrokt1ec_003D)
	{
		return _0023_003DzhklmJFQ_003D switch
		{
			labelType.Equal => new EqualLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Mirror => new MirrorLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.EqualRadius => new EqualRadiusLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.PointOn => new PointOnLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.PointAt => new PointAtLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Join => new JoinLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Horizontal => new HorizontalLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Vertical => new VerticalLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Parallel => new ParallelLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Perpendicular => new PerpendicularLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Fix => new FixLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Polygon => new PolygonLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Tangent => new TangentLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.Collinear => new CollinearLabel(_0023_003DzSLnz75LnM5Rs), 
			labelType.MidPoint => new MidPointLabel(_0023_003DzSLnz75LnM5Rs), 
			_ => throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589412) + _0023_003DzhklmJFQ_003D), 
		};
	}
}
