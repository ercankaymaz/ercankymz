using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class PointConstraintData : ConstraintData
{
	public Point3D Position;

	internal override int Order => 8;

	public PointConstraintData(Point3D point, Stack<BlockReference> parents)
		: base(parents)
	{
		Point3D point3D = (Point3D)point.Clone();
		point3D.TransformBy(AccTrans);
		Position = point3D;
	}

	protected internal PointConstraintData(PointConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Position = surrogate.Position;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new PointConstraintDataSurrogate(this);
	}
}
