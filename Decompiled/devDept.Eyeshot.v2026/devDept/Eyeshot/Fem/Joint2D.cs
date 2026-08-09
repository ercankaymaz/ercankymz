using System;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Joint2D : Element
{
	internal double[,] rot;

	public double[] Stiffness { get; set; }

	protected Joint2D(int numberOfNodes, devDept.Geometry.Rotation rotation)
		: this(numberOfNodes, rotation.Matrix)
	{
	}

	protected Joint2D(int numberOfNodes, double[,] matrixRotation)
		: base(numberOfNodes, null)
	{
		rot = matrixRotation;
	}

	public Joint2D(int nodeIndex1, int nodeIndex2, devDept.Geometry.Rotation rotation, double[] stiffness)
		: this(nodeIndex1, nodeIndex2, rotation.Matrix, stiffness)
	{
	}

	protected internal Joint2D(int nodeIndex1, int nodeIndex2, double[,] matrixRotation, double[] stiffness)
		: base(2, null)
	{
		NumberOfDimensions = 2;
		NumberOfDofPerNode = 2;
		NumberOfGaussPoints = 0;
		NumberOfStressesPerNode = 0;
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		rot = matrixRotation;
		Stiffness = new double[2]
		{
			stiffness[0],
			stiffness[1]
		};
	}

	protected Joint2D(Joint2D another)
		: base(another)
	{
		Stiffness = (double[])another.Stiffness.Clone();
		rot = another.rot;
	}

	public override object Clone()
	{
		return new Joint2D(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemJoint2DSurrogate(this);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		Vector2D vector2D = new Vector2D(rot[0, 0], rot[0, 1]);
		Vector2D vector2D2 = new Vector2D(rot[1, 0], rot[1, 1]);
		double[,] array = new double[2, 4]
		{
			{ vector2D.X, vector2D.Y, 0.0, 0.0 },
			{ 0.0, 0.0, vector2D.X, vector2D.Y }
		};
		double[,] array2 = new double[4, 2];
		array2[0, 0] = vector2D.X;
		array2[1, 0] = vector2D.Y;
		array2[2, 0] = 0.0;
		array2[3, 0] = 0.0;
		array2[0, 1] = 0.0;
		array2[1, 1] = 0.0;
		array2[2, 1] = vector2D.X;
		array2[3, 1] = vector2D.Y;
		double[,] array3 = new double[2, 2];
		array3[0, 0] = Stiffness[0];
		array3[1, 1] = Stiffness[0];
		array3[1, 0] = 0.0 - Stiffness[0];
		array3[0, 1] = 0.0 - Stiffness[0];
		double[,] array4 = new double[2, 4];
		double[,] array5 = new double[4, 4];
		Element._0023_003Dz3PdJaxsL3lyc(array4, array, array3, 4, 2, 2);
		Element._0023_003Dz3PdJaxsL3lyc(array5, array4, array2, 4, 4, 2);
		K = new double[4, 4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				K[j, i] += array5[j, i];
			}
		}
		array[0, 0] = vector2D2.X;
		array[0, 1] = vector2D2.Y;
		array[0, 2] = 0.0;
		array[0, 3] = 0.0;
		array[1, 0] = 0.0;
		array[1, 1] = 0.0;
		array[1, 2] = vector2D2.X;
		array[1, 3] = vector2D2.Y;
		array2[0, 0] = vector2D2.X;
		array2[1, 0] = vector2D2.Y;
		array2[2, 0] = 0.0;
		array2[3, 0] = 0.0;
		array2[0, 1] = 0.0;
		array2[1, 1] = 0.0;
		array2[2, 1] = vector2D2.X;
		array2[3, 1] = vector2D2.Y;
		array3[0, 0] = Stiffness[1];
		array3[1, 1] = Stiffness[1];
		array3[1, 0] = 0.0 - Stiffness[1];
		array3[0, 1] = 0.0 - Stiffness[1];
		Array.Clear(array4, 0, array4.Length);
		Array.Clear(array5, 0, array5.Length);
		Element._0023_003Dz3PdJaxsL3lyc(array4, array, array3, 4, 2, 2);
		Element._0023_003Dz3PdJaxsL3lyc(array5, array4, array2, 4, 4, 2);
		for (int k = 0; k < 4; k++)
		{
			for (int l = 0; l < 4; l++)
			{
				K[l, k] += array5[l, k];
			}
		}
		_0023_003DzkK3Z3MIFFh9x(nodes);
		minConn = int.MaxValue;
		maxConn = int.MinValue;
		int[] connection = Connection;
		foreach (int num in connection)
		{
			if (num < minConn)
			{
				minConn = num;
			}
			if (num > maxConn)
			{
				maxConn = num;
			}
		}
	}
}
