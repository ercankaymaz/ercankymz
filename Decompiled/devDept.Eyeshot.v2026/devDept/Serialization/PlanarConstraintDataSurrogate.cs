using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class PlanarConstraintDataSurrogate : ConstraintDataSurrogate
{
	public Point3D Origin;

	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	public PlanarConstraintDataSurrogate(PlanarConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		PlanarConstraintData planarConstraintData = new PlanarConstraintData(this);
		CopyDataToObject(planarConstraintData);
		return planarConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		PlanarConstraintData planarConstraintData = (PlanarConstraintData)obj;
		Origin = planarConstraintData.Origin;
		AxisX = planarConstraintData.AxisX;
		AxisY = planarConstraintData.AxisY;
		AxisZ = planarConstraintData.AxisZ;
	}
}
