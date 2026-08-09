using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemNodeSurrogate : PointWithDisplacementSurrogate
{
	internal devDept.Eyeshot.Fem.Rotation rotation_V12;

	public double[] Load;

	public bool[] Restraints;

	public double[] Displacement;

	public double Temperature;

	public Transformation Transformation;

	public FemNodeSurrogate(Node node)
		: base(node)
	{
	}

	protected override Point2D ConvertToObject()
	{
		Node node = new Node(X, Y, Z);
		CopyDataToObject(node);
		return node;
	}

	protected override void CopyDataToObject(Point2D p)
	{
		Node node = (Node)p;
		node.load = Load;
		node.restraints = Restraints;
		node.displacement = Displacement;
		node.Temperature = Temperature;
		if (base.Version < 13)
		{
			if (rotation_V12 != null)
			{
				devDept.Geometry.Rotation rotation = new devDept.Geometry.Rotation(0.0, 0.0, 0.0);
				rotation.Matrix[0, 0] = rotation_V12.Matrix[0, 0];
				rotation.Matrix[0, 1] = rotation_V12.Matrix[0, 1];
				rotation.Matrix[0, 2] = rotation_V12.Matrix[0, 2];
				rotation.Matrix[0, 3] = 0.0;
				rotation.Matrix[1, 0] = rotation_V12.Matrix[1, 0];
				rotation.Matrix[1, 1] = rotation_V12.Matrix[1, 1];
				rotation.Matrix[1, 2] = rotation_V12.Matrix[1, 2];
				rotation.Matrix[1, 3] = 0.0;
				rotation.Matrix[2, 0] = rotation_V12.Matrix[2, 0];
				rotation.Matrix[2, 1] = rotation_V12.Matrix[2, 1];
				rotation.Matrix[2, 2] = rotation_V12.Matrix[2, 2];
				rotation.Matrix[2, 3] = 0.0;
				rotation.Matrix[3, 0] = 0.0;
				rotation.Matrix[3, 1] = 0.0;
				rotation.Matrix[3, 2] = 0.0;
				rotation.Matrix[3, 3] = 1.0;
			}
		}
		else if (Transformation != null)
		{
			node.Rotation = new devDept.Geometry.Rotation(0.0, 0.0, 0.0);
			node.Rotation.Matrix = Transformation.Matrix;
		}
		base.CopyDataToObject((Point2D)node);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		Node node = (Node)p;
		Load = node.load;
		Restraints = node.restraints;
		Displacement = node.displacement;
		Temperature = node.Temperature;
		Transformation = node.Rotation;
		base.CopyDataFromObject(p);
	}
}
