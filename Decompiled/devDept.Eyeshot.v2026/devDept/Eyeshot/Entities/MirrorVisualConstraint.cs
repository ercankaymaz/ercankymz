using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Entities;

public class MirrorVisualConstraint : VisualConstraint
{
	internal MirrorVisualConstraint(IViewportInternal _0023_003DzqkfbPc0_003D, IStackedLabel[] _0023_003DzhnS4u9ZtBDlB, MirrorConstraint _0023_003DzP8SZzsQxy6SJ3OghmQ_003D_003D)
		: base(_0023_003DzqkfbPc0_003D, _0023_003DzhnS4u9ZtBDlB, _0023_003DzP8SZzsQxy6SJ3OghmQ_003D_003D)
	{
	}

	internal override void _0023_003DzRxMIdizdKQ7q(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D)
	{
		Line line = new Line(_0023_003DzwTd_wmIwiPye()[0].AnchorPoint, _0023_003DzwTd_wmIwiPye()[1].AnchorPoint);
		line.Regen(new RegenParams(_0023_003Dz3BW3eaE_003D.parent.Entities));
		line.LineWeight = 1f;
		line.LineWeightMethod = colorMethodType.byEntity;
		line.Color = _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Params.HoveringColor;
		line.ColorMethod = colorMethodType.byEntity;
		_0023_003Dz3BW3eaE_003D.parent.TempEntities.Add(line);
	}
}
