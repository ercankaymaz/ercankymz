using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class LinearConstraintData : ConstraintData
{
	public Point3D Start;

	public Point3D End;

	private Vector3D _direction;

	internal override int Order => 6;

	public Vector3D Direction
	{
		get
		{
			if (_direction == null)
			{
				Vector3D vector3D = new Vector3D(Start, End);
				vector3D.Normalize();
				_direction = vector3D;
			}
			return _direction;
		}
	}

	public LinearConstraintData(Segment3D segment, Stack<BlockReference> parents)
		: base(parents)
	{
		Point3D point3D = (Point3D)segment.P0.Clone();
		point3D.TransformBy(AccTrans);
		Point3D point3D2 = (Point3D)segment.P1.Clone();
		point3D2.TransformBy(AccTrans);
		Start = point3D;
		End = point3D2;
	}

	protected internal LinearConstraintData(LinearConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Start = surrogate.Start;
		End = surrogate.End;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new LinearConstraintDataSurrogate(this);
	}
}
