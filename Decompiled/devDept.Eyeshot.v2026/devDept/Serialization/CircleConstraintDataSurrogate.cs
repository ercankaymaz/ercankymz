using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class CircleConstraintDataSurrogate : ConstraintDataSurrogate
{
	public Point3D Center;

	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	public double Radius;

	public CircleConstraintDataSurrogate(CircleConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		CircleConstraintData circleConstraintData = new CircleConstraintData(this);
		CopyDataToObject(circleConstraintData);
		return circleConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		CircleConstraintData circleConstraintData = (CircleConstraintData)obj;
		Center = circleConstraintData.Center;
		AxisX = circleConstraintData.AxisX;
		AxisY = circleConstraintData.AxisY;
		AxisZ = circleConstraintData.AxisZ;
		Radius = circleConstraintData.Radius;
	}
}
