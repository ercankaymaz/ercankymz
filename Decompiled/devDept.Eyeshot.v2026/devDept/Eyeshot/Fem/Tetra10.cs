using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Tetra10 : Element3D
{
	private double[] lumpedMass = new double[10] { 6.0, 6.0, 6.0, 6.0, 32.0, 32.0, 32.0, 32.0, 32.0, 32.0 };

	public Tetra10(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, int nodeIndex7, int nodeIndex8, int nodeIndex9, int nodeIndex10, Material mat)
		: this(new int[10] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6, nodeIndex7, nodeIndex8, nodeIndex9, nodeIndex10 }, mat)
	{
	}

	public Tetra10(IEnumerable<int> nodeIndices, Material mat)
		: base(10, mat)
	{
		NumberOfGaussPoints = 4;
		Connection = new int[NumberOfNodes];
		Connection = nodeIndices.ToArray();
		elFaces = new Face[4]
		{
			new Face(new byte[6] { 0, 5, 4, 3, 2, 1 }),
			new Face(new byte[6] { 0, 1, 2, 7, 9, 6 }),
			new Face(new byte[6] { 2, 3, 4, 8, 9, 7 }),
			new Face(new byte[6] { 4, 5, 0, 6, 9, 8 })
		};
	}

	protected Tetra10(Tetra10 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Tetra10(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemTetra10Surrogate(this);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		int num = 0;
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		GaussQuadrature(out var _, out var _);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		double _0023_003DzE5gt1ko_003D = 0.0;
		for (int i = 1; i <= 4; i++)
		{
			num = i;
			switch (i)
			{
			case 1:
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DziMjqlCo_003D = 0.5854102;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.5854102;
				break;
			case 3:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.5854102;
				break;
			case 4:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.5854102;
				break;
			}
			_0023_003Dz2lz4ccbh_B1y3PUyyQ_003D_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzE5gt1ko_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * (1.0 / 6.0) * 0.25;
			StiffnessComputation(num, cartDeriv, dvolu);
		}
		StiffnessComputation(nodes);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		int num = 0;
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		double _0023_003DzE5gt1ko_003D = 0.0;
		M = new double[30, 30];
		for (int i = 1; i <= 4; i++)
		{
			num = i;
			switch (i)
			{
			case 1:
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DziMjqlCo_003D = 0.5854102;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.5854102;
				break;
			case 3:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.5854102;
				break;
			case 4:
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.5854102;
				break;
			}
			_0023_003Dz2lz4ccbh_B1y3PUyyQ_003D_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzE5gt1ko_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * (1.0 / 6.0) * 0.25;
			AssembleMassMatrix(array, dVolume);
		}
	}

	private void _0023_003Dz2lz4ccbh_B1y3PUyyQ_003D_003D(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double _0023_003DzE5gt1ko_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		double[,] array = new double[10, 4];
		_0023_003DzwaU_0024oWk_003D[0] = _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[1] = 4.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D;
		_0023_003DzwaU_0024oWk_003D[2] = _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[3] = 4.0 * _0023_003DzI4dRPW0_003D * _0023_003DzE5gt1ko_003D;
		_0023_003DzwaU_0024oWk_003D[4] = _0023_003DzE5gt1ko_003D * (2.0 * _0023_003DzE5gt1ko_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[5] = 4.0 * _0023_003DziMjqlCo_003D * _0023_003DzE5gt1ko_003D;
		_0023_003DzwaU_0024oWk_003D[6] = 4.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D;
		_0023_003DzwaU_0024oWk_003D[7] = 4.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D;
		_0023_003DzwaU_0024oWk_003D[8] = 4.0 * _0023_003DzYEhafAA_003D * _0023_003DzE5gt1ko_003D;
		_0023_003DzwaU_0024oWk_003D[9] = _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0);
		array[0, 0] = 4.0 * _0023_003DziMjqlCo_003D - 1.0;
		array[1, 0] = 4.0 * _0023_003DzI4dRPW0_003D;
		array[5, 0] = 4.0 * _0023_003DzE5gt1ko_003D;
		array[6, 0] = 4.0 * _0023_003DzYEhafAA_003D;
		array[1, 1] = 4.0 * _0023_003DziMjqlCo_003D;
		array[2, 1] = 4.0 * _0023_003DzI4dRPW0_003D - 1.0;
		array[3, 1] = 4.0 * _0023_003DzE5gt1ko_003D;
		array[7, 1] = 4.0 * _0023_003DzYEhafAA_003D;
		array[6, 2] = 4.0 * _0023_003DziMjqlCo_003D;
		array[7, 2] = 4.0 * _0023_003DzI4dRPW0_003D;
		array[8, 2] = 4.0 * _0023_003DzE5gt1ko_003D;
		array[9, 2] = 4.0 * _0023_003DzYEhafAA_003D - 1.0;
		array[3, 3] = 4.0 * _0023_003DzI4dRPW0_003D;
		array[4, 3] = 4.0 * _0023_003DzE5gt1ko_003D - 1.0;
		array[5, 3] = 4.0 * _0023_003DziMjqlCo_003D;
		array[8, 3] = 4.0 * _0023_003DzYEhafAA_003D;
		_0023_003DzmB17IaV5XzRN[0, 0] = array[0, 0] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 0] = array[1, 0] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 0] = array[2, 0] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 0] = array[3, 0] - array[3, 3];
		_0023_003DzmB17IaV5XzRN[4, 0] = array[4, 0] - array[4, 3];
		_0023_003DzmB17IaV5XzRN[5, 0] = array[5, 0] - array[5, 3];
		_0023_003DzmB17IaV5XzRN[6, 0] = array[6, 0] - array[6, 3];
		_0023_003DzmB17IaV5XzRN[7, 0] = array[7, 0] - array[7, 3];
		_0023_003DzmB17IaV5XzRN[8, 0] = array[8, 0] - array[8, 3];
		_0023_003DzmB17IaV5XzRN[9, 0] = array[9, 0] - array[9, 3];
		_0023_003DzmB17IaV5XzRN[0, 1] = array[0, 1] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 1] = array[1, 1] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 1] = array[2, 1] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 1] = array[3, 1] - array[3, 3];
		_0023_003DzmB17IaV5XzRN[4, 1] = array[4, 1] - array[4, 3];
		_0023_003DzmB17IaV5XzRN[5, 1] = array[5, 1] - array[5, 3];
		_0023_003DzmB17IaV5XzRN[6, 1] = array[6, 1] - array[6, 3];
		_0023_003DzmB17IaV5XzRN[7, 1] = array[7, 1] - array[7, 3];
		_0023_003DzmB17IaV5XzRN[8, 1] = array[8, 1] - array[8, 3];
		_0023_003DzmB17IaV5XzRN[9, 1] = array[9, 1] - array[9, 3];
		_0023_003DzmB17IaV5XzRN[0, 2] = array[0, 2] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 2] = array[1, 2] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 2] = array[2, 2] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 2] = array[3, 2] - array[3, 3];
		_0023_003DzmB17IaV5XzRN[4, 2] = array[4, 2] - array[4, 3];
		_0023_003DzmB17IaV5XzRN[5, 2] = array[5, 2] - array[5, 3];
		_0023_003DzmB17IaV5XzRN[6, 2] = array[6, 2] - array[6, 3];
		_0023_003DzmB17IaV5XzRN[7, 2] = array[7, 2] - array[7, 3];
		_0023_003DzmB17IaV5XzRN[8, 2] = array[8, 2] - array[8, 3];
		_0023_003DzmB17IaV5XzRN[9, 2] = array[9, 2] - array[9, 3];
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[NumberOfStressesPerNode, NumberOfNodes];
		for (int i = 1; i <= 4; i++)
		{
			num2++;
			num++;
			double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
			ComputeThermalLoading(num2, temperature, array, strsg);
		}
		double[,] array2 = new double[NumberOfStressesPerNode, NumberOfNodes];
		for (int j = 0; j < 6; j++)
		{
			array2[j, 0] = 1.92705096624968 * array[j, 0] + -0.309016988749895 * (array[j, 1] + array[j, 2] + array[j, 3]);
			array2[j, 2] = 1.92705096624968 * array[j, 1] + -0.309016988749895 * (array[j, 0] + array[j, 2] + array[j, 3]);
			array2[j, 4] = 1.92705096624968 * array[j, 2] + -0.309016988749895 * (array[j, 0] + array[j, 1] + array[j, 3]);
			array2[j, 9] = 1.92705096624968 * array[j, 3] + -0.309016988749895 * (array[j, 0] + array[j, 1] + array[j, 2]);
			array2[j, 1] = (array2[j, 0] + array2[j, 2]) / 2.0;
			array2[j, 3] = (array2[j, 2] + array2[j, 4]) / 2.0;
			array2[j, 5] = (array2[j, 0] + array2[j, 4]) / 2.0;
			array2[j, 6] = (array2[j, 0] + array2[j, 9]) / 2.0;
			array2[j, 7] = (array2[j, 2] + array2[j, 9]) / 2.0;
			array2[j, 8] = (array2[j, 4] + array2[j, 9]) / 2.0;
		}
		TotalUpTheStresses(array2, numberOfElementsPerNode, nodes);
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		double[] array = new double[NumberOfNodes];
		for (int i = 0; i < NumberOfNodes; i++)
		{
			array[i] = ((Node)nodes[Connection[i]]).Temperature;
		}
		GaussQuadrature(out var _, out var _);
		double[] array2 = new double[NumberOfNodes];
		double[,] array3 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		tLoad = new double[base.TotalDof];
		strin = new double[NumberOfGaussPoints, NumberOfStressesPerNode];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		double _0023_003DzE5gt1ko_003D = 0.0;
		for (int j = 1; j <= 4; j++)
		{
			int num = j;
			if (j == 1)
			{
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DziMjqlCo_003D = 0.5854102;
			}
			if (j == 2)
			{
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.5854102;
			}
			if (j == 3)
			{
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.5854102;
			}
			if (j == 4)
			{
				_0023_003DziMjqlCo_003D = 0.1381966;
				_0023_003DzI4dRPW0_003D = 0.1381966;
				_0023_003DzE5gt1ko_003D = 0.1381966;
				_0023_003DzYEhafAA_003D = 0.5854102;
			}
			_0023_003Dz2lz4ccbh_B1y3PUyyQ_003D_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzE5gt1ko_003D, array2, array3);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * (1.0 / 6.0) * 0.25;
			ComputeTemp(array, array2, num, cartDeriv, dvolu);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace6(context, singleColor, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace6(context, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace6(context, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFaceElement6(context, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		List<IndexTriangle> list = new List<IndexTriangle>();
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				list.AddRange(GetFace6(elIndex, i, vertices, ampFactor, centroids));
			}
		}
		return list.ToArray();
	}

	public override void SetPressure(int faceIndex, Vector3D pressure, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elFaces[faceIndex].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elFaces[faceIndex].Indices[2]]];
		Node p3 = (Node)nodes[Connection[elFaces[faceIndex].Indices[4]]];
		Vector3D vector3D = new Vector3D(p, p2);
		vector3D.Normalize();
		Vector3D vector3D2 = new Vector3D(p, p3);
		vector3D2.Normalize();
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		vector3D3.Normalize();
		vector3D2 = Vector3D.Cross(vector3D3, vector3D);
		Segment3D segment3D = new Segment3D(vector3D);
		Segment3D segment3D2 = new Segment3D(vector3D2);
		Segment3D segment3D3 = new Segment3D(vector3D3);
		double x = segment3D.Project(pressure.AsPoint);
		double y = segment3D2.Project(pressure.AsPoint);
		double z = segment3D3.Project(pressure.AsPoint);
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(x, y, z);
		_0023_003DzbxjA56crdiwG9FZGQQ_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	public override void SetPressure(int edgeIndex, double pressure, Point3D[] nodes)
	{
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(0.0, 0.0, 0.0 - pressure);
		_0023_003DzbxjA56crdiwG9FZGQQ_003D_003D(nodes, _0023_003DzJvZCors_003D, edgeIndex);
		base.SetPressure(edgeIndex, pressure, nodes);
	}

	internal void _0023_003DzbxjA56crdiwG9FZGQQ_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
	{
		double[,] array = new double[elFaces[_0023_003DzL8NvYU0_003D].Indices.Length, NumberOfDimensions];
		for (int i = 0; i < array.GetLength(0); i++)
		{
			array[i, 0] = _0023_003DzJvZCors_003D.X;
			array[i, 1] = _0023_003DzJvZCors_003D.Y;
			array[i, 2] = _0023_003DzJvZCors_003D.Z;
		}
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		double[] array2 = new double[NumberOfNodes * NumberOfDimensions];
		for (int j = 0; j < NumberOfNodes; j++)
		{
			int num = Connection[j];
			array2[j * NumberOfDimensions] = _0023_003DzDvuIQCU_003D[num].X;
			array2[j * NumberOfDimensions + 1] = _0023_003DzDvuIQCU_003D[num].Y;
			array2[j * NumberOfDimensions + 2] = _0023_003DzDvuIQCU_003D[num].Z;
		}
		int[] array3 = new int[6];
		for (int k = 0; k < 6; k++)
		{
			array3[k] = elFaces[_0023_003DzL8NvYU0_003D].Indices[k];
		}
		for (int l = 1; l <= 7; l++)
		{
			double _0023_003DzgPsOl1A_003D;
			double _0023_003DzD5YCi2M_003D;
			double _0023_003Dz9_0024bIhS0_003D;
			double _0023_003DzbQkwuM0_003D;
			switch (l)
			{
			case 1:
				_0023_003DzgPsOl1A_003D = 0.5;
				_0023_003DzD5YCi2M_003D = 0.5;
				_0023_003Dz9_0024bIhS0_003D = 0.0;
				_0023_003DzbQkwuM0_003D = 0.4;
				break;
			case 2:
				_0023_003DzgPsOl1A_003D = 0.0;
				_0023_003DzD5YCi2M_003D = 0.5;
				_0023_003Dz9_0024bIhS0_003D = 0.5;
				_0023_003DzbQkwuM0_003D = 0.4;
				break;
			case 3:
				_0023_003DzgPsOl1A_003D = 0.5;
				_0023_003DzD5YCi2M_003D = 0.0;
				_0023_003Dz9_0024bIhS0_003D = 0.5;
				_0023_003DzbQkwuM0_003D = 0.4;
				break;
			case 4:
				_0023_003DzgPsOl1A_003D = 1.0;
				_0023_003DzD5YCi2M_003D = 0.0;
				_0023_003Dz9_0024bIhS0_003D = 0.0;
				_0023_003DzbQkwuM0_003D = 0.15;
				break;
			case 5:
				_0023_003DzgPsOl1A_003D = 0.0;
				_0023_003DzD5YCi2M_003D = 1.0;
				_0023_003Dz9_0024bIhS0_003D = 0.0;
				_0023_003DzbQkwuM0_003D = 0.15;
				break;
			case 6:
				_0023_003DzgPsOl1A_003D = 0.0;
				_0023_003DzD5YCi2M_003D = 0.0;
				_0023_003Dz9_0024bIhS0_003D = 1.0;
				_0023_003DzbQkwuM0_003D = 0.15;
				break;
			default:
				_0023_003DzgPsOl1A_003D = 1.0 / 3.0;
				_0023_003DzD5YCi2M_003D = 1.0 / 3.0;
				_0023_003Dz9_0024bIhS0_003D = 1.0 / 3.0;
				_0023_003DzbQkwuM0_003D = 1.350000023841858;
				break;
			}
			_0023_003DznHxD323XQtsall3J8w_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, out var _0023_003DzKjjYWhJTvaT_0024, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D);
			_0023_003DzJoqQbD5u3xR2LyPb4A_003D_003D(_0023_003DzKjjYWhJTvaT_0024, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, array, array3, _0023_003DzbQkwuM0_003D);
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(new Node[4]
		{
			(Node)fm.Vertices[Connection[0]],
			(Node)fm.Vertices[Connection[2]],
			(Node)fm.Vertices[Connection[4]],
			(Node)fm.Vertices[Connection[9]]
		});
		List<int> list2 = new List<int>();
		int num = 6;
		for (int i = 0; i < 6; i += 2)
		{
			Node item = (Node)fm.Vertices[Connection[i]].Clone();
			list2.Add(list.Count);
			list.Add(item);
			Node item2 = (Node)fm.Vertices[Connection[i + 1]].Clone();
			list2.Add(list.Count);
			list.Add(item2);
			Node item3 = (Node)fm.Vertices[Connection[num]].Clone();
			num++;
			list2.Add(list.Count);
			list.Add(item3);
		}
		list2.Add(list.Count);
		list.Add((Node)fm.Vertices[Connection[Connection.Length - 1]].Clone());
		List<Element> list3 = new List<Element>();
		list3.AddRange(fm.elements);
		List<int> list4 = new List<int>();
		list4.AddRange(new int[4] { 7, 8, 5, 9 });
		Tetra10 item4 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 8, 10, 11, 12 });
		Tetra10 item5 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 5, 11, 4, 6 });
		Tetra10 item6 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 8, 12, 5, 9 });
		Tetra10 item7 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 12, 11, 5, 6 });
		Tetra10 item8 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 9, 12, 5, 6 });
		Tetra10 item9 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 9, 12, 6, 13 });
		Tetra10 item10 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list4.Clear();
		list4.AddRange(new int[4] { 8, 11, 5, 12 });
		Tetra10 item11 = Tetra4._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(list4.ToArray(), list, base.Material);
		list3.Add(item4);
		list3.Add(item5);
		list3.Add(item6);
		list3.Add(item7);
		list3.Add(item8);
		list3.Add(item9);
		list3.Add(item10);
		list3.Add(item11);
		fm.Vertices = list.ToArray();
		fm.Elements = list3.ToArray();
	}

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		return new Tetra4(new int[4]
		{
			Connection[0],
			Connection[2],
			Connection[4],
			Connection[9]
		}, base.Material).SliceElementWithPlane(contourPlot, clippingPlane, vertices, size, legend);
	}
}
