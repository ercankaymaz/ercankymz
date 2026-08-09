using System;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Joint3D : Joint2D
{
	public Joint3D(int nodeIndex1, int nodeIndex2, devDept.Geometry.Rotation rotation, double[] stiffness)
		: this(nodeIndex1, nodeIndex2, rotation.Matrix, stiffness)
	{
	}

	protected internal Joint3D(int nodeIndex1, int nodeIndex2, double[,] matrixRotation, double[] stiffness)
		: base(2, matrixRotation)
	{
		NumberOfDimensions = 3;
		NumberOfDofPerNode = 3;
		NumberOfGaussPoints = 0;
		NumberOfStressesPerNode = 0;
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		rot = matrixRotation;
		base.Stiffness = new double[3]
		{
			stiffness[0],
			stiffness[1],
			stiffness[2]
		};
	}

	protected Joint3D(Joint3D another)
		: base(another)
	{
		base.Stiffness = new double[another.Stiffness.Length];
		Array.Copy(another.Stiffness, base.Stiffness, another.Stiffness.Length);
		rot = another.rot;
	}

	public override object Clone()
	{
		return new Joint3D(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemJoint3DSurrogate(this);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		Vector3D vector3D = new Vector3D(rot[0, 0], rot[0, 1], rot[0, 2]);
		Vector3D vector3D2 = new Vector3D(rot[1, 0], rot[1, 1], rot[1, 2]);
		Vector3D vector3D3 = new Vector3D(rot[2, 0], rot[2, 1], rot[2, 2]);
		double[,] array = new double[2, 6]
		{
			{ vector3D.X, vector3D.Y, vector3D.Z, 0.0, 0.0, 0.0 },
			{ 0.0, 0.0, 0.0, vector3D.X, vector3D.Y, vector3D.Z }
		};
		double[,] array2 = new double[6, 2];
		array2[0, 0] = vector3D.X;
		array2[1, 0] = vector3D.Y;
		array2[2, 0] = vector3D.Z;
		array2[3, 0] = 0.0;
		array2[4, 0] = 0.0;
		array2[5, 0] = 0.0;
		array2[0, 1] = 0.0;
		array2[1, 1] = 0.0;
		array2[2, 1] = 0.0;
		array2[3, 1] = vector3D.X;
		array2[4, 1] = vector3D.Y;
		array2[5, 1] = vector3D.Z;
		double[,] array3 = new double[2, 2];
		array3[0, 0] = base.Stiffness[0];
		array3[1, 1] = base.Stiffness[0];
		array3[1, 0] = 0.0 - base.Stiffness[0];
		array3[0, 1] = 0.0 - base.Stiffness[0];
		double[,] array4 = new double[2, 6];
		double[,] array5 = new double[6, 6];
		Element._0023_003Dz3PdJaxsL3lyc(array4, array, array3, 6, 2, 2);
		Element._0023_003Dz3PdJaxsL3lyc(array5, array4, array2, 6, 6, 2);
		K = new double[6, 6];
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				K[j, i] += array5[j, i];
			}
		}
		array[0, 0] = vector3D2.X;
		array[0, 1] = vector3D2.Y;
		array[0, 2] = vector3D2.Z;
		array[0, 3] = 0.0;
		array[0, 4] = 0.0;
		array[0, 5] = 0.0;
		array[1, 0] = 0.0;
		array[1, 1] = 0.0;
		array[1, 2] = 0.0;
		array[1, 3] = vector3D2.X;
		array[1, 4] = vector3D2.Y;
		array[1, 5] = vector3D2.Z;
		array2[0, 0] = vector3D2.X;
		array2[1, 0] = vector3D2.Y;
		array2[2, 0] = vector3D2.Z;
		array2[3, 0] = 0.0;
		array2[4, 0] = 0.0;
		array2[5, 0] = 0.0;
		array2[0, 1] = 0.0;
		array2[1, 1] = 0.0;
		array2[2, 1] = 0.0;
		array2[3, 1] = vector3D2.X;
		array2[4, 1] = vector3D2.Y;
		array2[5, 1] = vector3D2.Z;
		array3[0, 0] = base.Stiffness[1];
		array3[1, 1] = base.Stiffness[1];
		array3[1, 0] = 0.0 - base.Stiffness[1];
		array3[0, 1] = 0.0 - base.Stiffness[1];
		Array.Clear(array4, 0, array4.Length);
		Array.Clear(array5, 0, array5.Length);
		Element._0023_003Dz3PdJaxsL3lyc(array4, array, array3, 6, 2, 2);
		Element._0023_003Dz3PdJaxsL3lyc(array5, array4, array2, 6, 6, 2);
		for (int k = 0; k < 6; k++)
		{
			for (int l = 0; l < 6; l++)
			{
				K[l, k] += array5[l, k];
			}
		}
		array[0, 0] = vector3D3.X;
		array[0, 1] = vector3D3.Y;
		array[0, 2] = vector3D3.Z;
		array[0, 3] = 0.0;
		array[0, 4] = 0.0;
		array[0, 5] = 0.0;
		array[1, 0] = 0.0;
		array[1, 1] = 0.0;
		array[1, 2] = 0.0;
		array[1, 3] = vector3D3.X;
		array[1, 4] = vector3D3.Y;
		array[1, 5] = vector3D3.Z;
		array2[0, 0] = vector3D3.X;
		array2[1, 0] = vector3D3.Y;
		array2[2, 0] = vector3D3.Z;
		array2[3, 0] = 0.0;
		array2[4, 0] = 0.0;
		array2[5, 0] = 0.0;
		array2[0, 1] = 0.0;
		array2[1, 1] = 0.0;
		array2[2, 1] = 0.0;
		array2[3, 1] = vector3D3.X;
		array2[4, 1] = vector3D3.Y;
		array2[5, 1] = vector3D3.Z;
		array3[0, 0] = base.Stiffness[2];
		array3[1, 1] = base.Stiffness[2];
		array3[1, 0] = 0.0 - base.Stiffness[2];
		array3[0, 1] = 0.0 - base.Stiffness[2];
		Array.Clear(array4, 0, array4.Length);
		Array.Clear(array5, 0, array5.Length);
		Element._0023_003Dz3PdJaxsL3lyc(array4, array, array3, 6, 2, 2);
		Element._0023_003Dz3PdJaxsL3lyc(array5, array4, array2, 6, 6, 2);
		for (int m = 0; m < 6; m++)
		{
			for (int n = 0; n < 6; n++)
			{
				K[n, m] += array5[n, m];
			}
		}
		_0023_003DzkK3Z3MIFFh9x(nodes);
		minConn = int.MaxValue;
		maxConn = int.MinValue;
		int[] connection = Connection;
		foreach (int num2 in connection)
		{
			if (num2 < minConn)
			{
				minConn = num2;
			}
			if (num2 > maxConn)
			{
				maxConn = num2;
			}
		}
	}
}
