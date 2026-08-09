using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ValueConstraintSurrogate : ConstraintSurrogate
{
	internal double Value;

	public bool Reference;

	public Point3D DimPos;

	public ValueConstraintSurrogate(ValueConstraint valueConstraint)
		: base(valueConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		ValueConstraint valueConstraint = new ValueConstraint(null);
		CopyDataToObject(valueConstraint);
		return valueConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		ValueConstraint obj = (ValueConstraint)sketchItem;
		obj.DimPos = DimPos;
		obj.Reference = Reference;
		obj.value._0023_003DzO_0024HwSzQ_003D(Value);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		ValueConstraint valueConstraint = (ValueConstraint)sketchItem;
		Reference = valueConstraint.Reference;
		DimPos = valueConstraint.DimPos;
		Value = valueConstraint.value._0023_003DzV29zQ3g_003D();
		base.CopyDataFromObject(sketchItem);
	}
}
