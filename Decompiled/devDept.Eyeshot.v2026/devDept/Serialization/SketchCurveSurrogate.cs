using System.Collections.Generic;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public abstract class SketchCurveSurrogate : SketchItemSurrogate
{
	public bool Construction;

	public bool Projected;

	public bool Fixed;

	internal SketchCurve[] children;

	internal SketchCurve[] linkedCurves;

	public SketchCurveSurrogate(SketchCurve sketchCurve)
		: base(sketchCurve)
	{
	}

	protected abstract override SketchItem ConvertToObject();

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		SketchCurve sketchCurve = (SketchCurve)sketchItem;
		sketchCurve.Construction = Construction;
		sketchCurve.Fixed = Fixed;
		if (children != null)
		{
			for (int i = 0; i < children.Length; i++)
			{
				sketchCurve.children[i] = children[i];
				sketchCurve.children[i]._0023_003DzbnpFo4dSYs9p(sketchCurve);
			}
		}
		if (linkedCurves != null)
		{
			sketchCurve.linkedCurves = new List<SketchCurve>(linkedCurves.Length);
			for (int j = 0; j < linkedCurves.Length; j++)
			{
				sketchCurve.linkedCurves.Add(linkedCurves[j]);
			}
		}
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchCurve sketchCurve = (SketchCurve)sketchItem;
		Construction = sketchCurve.Construction;
		Fixed = sketchCurve.Fixed;
		children = sketchCurve.children.ToArray();
		linkedCurves = sketchCurve.linkedCurves.ToArray();
		base.CopyDataFromObject((SketchItem)sketchCurve);
	}
}
