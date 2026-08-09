using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ParallelConstraintSurrogate : ConstraintSurrogate
{
	public byte Option;

	public ParallelConstraintSurrogate(ParallelConstraint parallelConstraint)
		: base(parallelConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		ParallelConstraint parallelConstraint = new ParallelConstraint(null);
		CopyDataToObject(parallelConstraint);
		return parallelConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		((ParallelConstraint)sketchItem)._0023_003DzmJuZp_0024UcZA5h((ParallelConstraint.Option)Option);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		ParallelConstraint parallelConstraint = (ParallelConstraint)sketchItem;
		Option = (byte)parallelConstraint._0023_003Dz0neAlmEyvmPj();
		base.CopyDataFromObject(sketchItem);
	}
}
