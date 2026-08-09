using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class CylindricalConstraintDataSurrogate : SphericalConstraintDataSurrogate
{
	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	public CylindricalConstraintDataSurrogate(CylindricalConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		CylindricalConstraintData cylindricalConstraintData = new CylindricalConstraintData(this);
		CopyDataToObject(cylindricalConstraintData);
		return cylindricalConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		CylindricalConstraintData cylindricalConstraintData = (CylindricalConstraintData)obj;
		AxisX = cylindricalConstraintData.AxisX;
		AxisY = cylindricalConstraintData.AxisY;
		AxisZ = cylindricalConstraintData.AxisZ;
	}
}
