using System;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class NodeBeam : Node
{
	internal double[] momentLoad;

	internal bool[] rotationRestraints;

	internal double[] rotationDisplacement;

	public double Rx => base.Unknowns[0][3];

	public double Ry => base.Unknowns[0][4];

	public double Rz => base.Unknowns[0][5];

	public bool RotationRestrained => rotationRestraints != null;

	public bool MomentLoaded => momentLoad != null;

	public NodeBeam(double x, double y)
		: base(x, y, 0.0)
	{
		base.Unknowns = new double[1][];
		base.Unknowns[0] = new double[3];
	}

	public NodeBeam(double x, double y, double z)
		: base(x, y, z)
	{
		base.Unknowns = new double[1][];
		base.Unknowns[0] = new double[3];
	}

	protected NodeBeam(NodeBeam another)
		: base(another)
	{
		momentLoad = another.momentLoad;
		rotationRestraints = another.rotationRestraints;
		rotationDisplacement = another.rotationDisplacement;
	}

	public override object Clone()
	{
		return new NodeBeam(this);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new FemNodeBeamSurrogate(this);
	}

	public void SetRotationRestraint(bool aroundX, bool aroundY, bool aroundZ, double rotationX = 0.0, double rotationY = 0.0, double rotationZ = 0.0)
	{
		if (rotationRestraints == null)
		{
			rotationRestraints = new bool[3];
		}
		rotationRestraints[0] = aroundX;
		rotationRestraints[1] = aroundY;
		rotationRestraints[2] = aroundZ;
		if (rotationDisplacement == null)
		{
			rotationDisplacement = new double[3];
		}
		rotationDisplacement[0] = rotationX;
		rotationDisplacement[1] = rotationY;
		rotationDisplacement[2] = rotationZ;
	}

	public void SetRotationRestraint(bool aroundZ, double rotationZ = 0.0)
	{
		if (rotationRestraints == null)
		{
			rotationRestraints = new bool[3];
		}
		rotationRestraints[2] = aroundZ;
		if (rotationDisplacement == null)
		{
			rotationDisplacement = new double[3];
		}
		rotationDisplacement[2] = rotationZ;
	}

	public override void ClearAllRestrains()
	{
		rotationRestraints = null;
		rotationDisplacement = null;
		base.ClearAllRestrains();
	}

	public void SetMoment(double amountInX, double amountInY, double amountInZ)
	{
		if (momentLoad == null)
		{
			momentLoad = new double[3];
			momentLoad[0] = amountInX;
			momentLoad[1] = amountInY;
			momentLoad[2] = amountInZ;
		}
		else
		{
			momentLoad[0] += amountInX;
			momentLoad[1] += amountInY;
			momentLoad[2] += amountInZ;
		}
	}

	public override void ClearAllLoads()
	{
		momentLoad = null;
		base.ClearAllLoads();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984863), X, Y, Z, base.Unknowns[0][0], base.Unknowns[0][1], (base.Unknowns[0].Length > 2) ? base.Unknowns[0][2] : 0.0, Rx, Ry, Rz, (base.Reactions == null) ? 0.0 : base.Reactions[0], (base.Reactions == null) ? 0.0 : base.Reactions[1], (base.Reactions == null || base.Reactions.Length == 3) ? 0.0 : base.Reactions[2], (base.Reactions == null || base.Reactions.Length == 3) ? 0.0 : base.Reactions[3], (base.Reactions == null || base.Reactions.Length == 3) ? 0.0 : base.Reactions[4], (base.Reactions == null) ? 0.0 : ((base.Reactions.Length == 3) ? base.Reactions[2] : base.Reactions[5]));
	}
}
