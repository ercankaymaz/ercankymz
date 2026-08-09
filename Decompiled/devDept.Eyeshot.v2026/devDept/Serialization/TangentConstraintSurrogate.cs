using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class TangentConstraintSurrogate : ConstraintSurrogate
{
	internal double t0;

	internal double t1;

	public byte Option;

	public TangentConstraintSurrogate(TangentConstraint tangentConstraint)
		: base(tangentConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		TangentConstraint tangentConstraint = new TangentConstraint(null);
		CopyDataToObject(tangentConstraint);
		return tangentConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		TangentConstraint obj = (TangentConstraint)sketchItem;
		obj.t0._0023_003DzO_0024HwSzQ_003D(t0);
		obj.t1._0023_003DzO_0024HwSzQ_003D(t1);
		obj._0023_003DzmJuZp_0024UcZA5h((TangentConstraint.Option)Option);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		TangentConstraint tangentConstraint = (TangentConstraint)sketchItem;
		t0 = tangentConstraint.t0._0023_003DzV29zQ3g_003D();
		t1 = tangentConstraint.t1._0023_003DzV29zQ3g_003D();
		Option = (byte)tangentConstraint._0023_003Dz0neAlmEyvmPj();
		base.CopyDataFromObject(sketchItem);
	}
}
