using System;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Node : PointWithDisplacement
{
	internal int index;

	internal double[] load;

	internal bool[] restraints;

	internal double[] displacement;

	public double Ux => base.Unknowns[0][0];

	public double Uy => base.Unknowns[0][1];

	public double Uz => base.Unknowns[0][2];

	public double U => Math.Sqrt(base.Unknowns[0][0] * base.Unknowns[0][0] + base.Unknowns[0][1] * base.Unknowns[0][1] + base.Unknowns[0][2] * base.Unknowns[0][2]);

	public double Sx => Stress[0];

	public double Sy => Stress[1];

	public double Sz => Stress[2];

	public double Txy => Stress[3];

	public double Tyz => Stress[4];

	public double Txz => Stress[5];

	public double P1 => Principals[0];

	public double P2 => Principals[1];

	public double P3 => Principals[2];

	public double Tresca => Principals[0] - Principals[2];

	public bool Selected { get; set; }

	public int Index => index;

	public bool Loaded => load != null;

	public double[] Load => load;

	public bool Restrained => restraints != null;

	public bool[] Restraints => restraints;

	public double[] Displacement => displacement;

	public devDept.Geometry.Rotation Rotation { get; set; }

	public double[] Reactions { get; set; }

	public double Temperature { get; set; }

	public double[] Stress { get; set; }

	public double[] Principals { get; set; }

	public double VonMises { get; set; }

	public float PlotValue { get; }

	public Node(double x, double y)
		: base(x, y, 0.0)
	{
		_0023_003DzbELcLllGRSTy();
	}

	public Node(double x, double y, double z)
		: base(x, y, z)
	{
		_0023_003DzbELcLllGRSTy();
	}

	public Node(double x, double y, bool restrainedInX, bool restrainedInY, double displacementInX, double displacementInY)
		: base(x, y, 0.0)
	{
		restraints = new bool[3];
		restraints[0] = restrainedInX;
		restraints[1] = restrainedInY;
		displacement = new double[3];
		displacement[0] = displacementInX;
		displacement[1] = displacementInY;
		load = null;
		_0023_003DzbELcLllGRSTy();
	}

	public Node(double x, double y, double z, bool restrainedInX, bool restrainedInY, bool restrainedInZ, double displacementInX, double displacementInY, double displacementInZ)
		: base(x, y, z)
	{
		restraints = new bool[3];
		restraints[0] = restrainedInX;
		restraints[1] = restrainedInY;
		restraints[2] = restrainedInZ;
		displacement = new double[3];
		displacement[0] = displacementInX;
		displacement[1] = displacementInY;
		displacement[2] = displacementInZ;
		load = null;
		_0023_003DzbELcLllGRSTy();
	}

	public Node(double x, double y, double loadInX, double loadInY)
		: base(x, y, 0.0)
	{
		load = new double[3];
		load[0] = loadInX;
		load[1] = loadInY;
		_0023_003DzbELcLllGRSTy();
	}

	public Node(double x, double y, double z, double loadInX, double loadInY, double loadInZ)
		: base(x, y, z)
	{
		load = new double[3];
		load[0] = loadInX;
		load[1] = loadInY;
		load[2] = loadInZ;
		_0023_003DzbELcLllGRSTy();
	}

	protected Node(Node another)
		: base(another)
	{
		if (another.load != null)
		{
			load = (double[])another.load.Clone();
		}
		if (another.restraints != null)
		{
			restraints = (bool[])another.restraints.Clone();
		}
		if (another.displacement != null)
		{
			displacement = (double[])another.displacement.Clone();
		}
		Rotation = another.Rotation;
		_0023_003DzefHtJcxwG1M2(another.PlotValue);
		_0023_003DzbELcLllGRSTy();
	}

	private void _0023_003DzbELcLllGRSTy()
	{
		Stress = new double[6];
		Principals = new double[3];
		base.Unknowns = new double[1][];
		base.Unknowns[0] = new double[3];
	}

	public override object Clone()
	{
		return new Node(this);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new FemNodeSurrogate(this);
	}

	internal void _0023_003DzefHtJcxwG1M2(float _0023_003DzPzO_0024GUk_003D)
	{
		PlotValue = _0023_003DzPzO_0024GUk_003D;
	}

	public void SetRestraint(bool inX, bool inY, double amountInX = 0.0, double amountInY = 0.0)
	{
		if (restraints == null)
		{
			restraints = new bool[3];
		}
		restraints[0] = inX;
		restraints[1] = inY;
		if (displacement == null)
		{
			displacement = new double[3];
		}
		displacement[0] = amountInX;
		displacement[1] = amountInY;
	}

	public void SetRestraint(bool inX, bool inY, bool inZ, double amountInX = 0.0, double amountInY = 0.0, double amountInZ = 0.0)
	{
		if (restraints == null)
		{
			restraints = new bool[3];
		}
		restraints[0] = inX;
		restraints[1] = inY;
		restraints[2] = inZ;
		if (displacement == null)
		{
			displacement = new double[3];
		}
		displacement[0] = amountInX;
		displacement[1] = amountInY;
		displacement[2] = amountInZ;
	}

	internal void _0023_003DzBQLVxDib9_iB(double _0023_003DzYNjcavt9guh2)
	{
		if (restraints == null)
		{
			restraints = new bool[3];
		}
		restraints[0] = true;
		if (displacement == null)
		{
			displacement = new double[3];
		}
		displacement[0] = _0023_003DzYNjcavt9guh2;
	}

	internal void _0023_003Dzd9lfsXbEXe5u(double _0023_003DzYNjcavt9guh2)
	{
		if (restraints == null)
		{
			restraints = new bool[3];
		}
		restraints[1] = true;
		if (displacement == null)
		{
			displacement = new double[3];
		}
		displacement[1] = _0023_003DzYNjcavt9guh2;
	}

	internal void _0023_003DzKv_0024B85OU7Q_00246(double _0023_003DzYNjcavt9guh2)
	{
		if (restraints == null)
		{
			restraints = new bool[3];
		}
		restraints[2] = true;
		if (displacement == null)
		{
			displacement = new double[3];
		}
		displacement[2] = _0023_003DzYNjcavt9guh2;
	}

	public virtual void ClearAllRestrains()
	{
		restraints = null;
		displacement = null;
	}

	public void SetForce(double amountInX, double amountInY)
	{
		if (load == null)
		{
			load = new double[3];
			load[0] = amountInX;
			load[1] = amountInY;
		}
		else
		{
			load[0] += amountInX;
			load[1] += amountInY;
		}
	}

	public void SetForce(Vector2D amount)
	{
		if (load == null)
		{
			load = new double[3];
			load[0] = amount.X;
			load[1] = amount.Y;
		}
		else
		{
			load[0] += amount.X;
			load[1] += amount.Y;
		}
	}

	public void SetForce(double amountInX, double amountInY, double amountInZ)
	{
		if (load == null)
		{
			load = new double[3];
			load[0] = amountInX;
			load[1] = amountInY;
			load[2] = amountInZ;
		}
		else
		{
			load[0] += amountInX;
			load[1] += amountInY;
			load[2] += amountInZ;
		}
	}

	public void SetForce(Vector3D amount)
	{
		if (load == null)
		{
			load = new double[3];
			load[0] = amount.X;
			load[1] = amount.Y;
			load[2] = amount.Z;
		}
		else
		{
			load[0] += amount.X;
			load[1] += amount.Y;
			load[2] += amount.Z;
		}
	}

	public virtual void ClearAllLoads()
	{
		load = null;
	}

	public void UpdateVonMisesAndPrincipals()
	{
		Element.CalcPrincipal(Stress, out var vm, out var principal);
		VonMises = vm;
		Principals = principal;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984927), base.ToString(), base.Unknowns[0][0], base.Unknowns[0][1], (base.Unknowns[0].Length > 2) ? base.Unknowns[0][2] : 0.0, (Reactions == null) ? 0.0 : Reactions[0], (Reactions == null) ? 0.0 : Reactions[1], (Reactions == null || Reactions.Length == 2) ? 0.0 : Reactions[2]);
	}
}
