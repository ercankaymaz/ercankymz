using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemNodeBeamSurrogate : FemNodeSurrogate
{
	public double[] MomentLoad;

	public bool[] RotationRestraints;

	public double[] RotationDisplacement;

	public FemNodeBeamSurrogate(NodeBeam nodeBeam)
		: base(nodeBeam)
	{
	}

	protected override Point2D ConvertToObject()
	{
		NodeBeam nodeBeam = new NodeBeam(X, Y, Z);
		CopyDataToObject(nodeBeam);
		return nodeBeam;
	}

	protected override void CopyDataToObject(Point2D p)
	{
		NodeBeam nodeBeam = p as NodeBeam;
		nodeBeam.momentLoad = MomentLoad;
		nodeBeam.rotationRestraints = RotationRestraints;
		nodeBeam.rotationDisplacement = RotationDisplacement;
		base.CopyDataToObject((Point2D)nodeBeam);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		NodeBeam nodeBeam = p as NodeBeam;
		MomentLoad = nodeBeam.momentLoad;
		RotationRestraints = nodeBeam.rotationRestraints;
		RotationDisplacement = nodeBeam.rotationDisplacement;
		base.CopyDataFromObject(p);
	}
}
