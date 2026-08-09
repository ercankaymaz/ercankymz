using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal abstract class ConstraintDataSurrogate : Surrogate<ConstraintData>
{
	public BlockReference Component;

	public Transformation AccTrans;

	protected ConstraintDataSurrogate(ConstraintData obj)
		: base(obj)
	{
	}

	protected override void CopyDataToObject(ConstraintData obj)
	{
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		Component = obj.Component;
		AccTrans = obj.AccTrans;
	}

	public static implicit operator ConstraintData(ConstraintDataSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ConstraintDataSurrogate(ConstraintData source)
	{
		return source?.ConvertToSurrogate();
	}
}
