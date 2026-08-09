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
public class Hexa8 : Element3D
{
	public Hexa8(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, int nodeIndex7, int nodeIndex8, Material mat)
		: this(new int[8] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6, nodeIndex7, nodeIndex8 }, mat)
	{
	}

	public Hexa8(IEnumerable<int> nodeIndices, Material mat)
		: base(8, mat)
	{
		NumberOfGaussPoints = 8;
		Connection = nodeIndices.ToArray();
		elFaces = new Face[6]
		{
			new Face(new byte[4] { 0, 3, 2, 1 }),
			new Face(new byte[4] { 0, 1, 5, 4 }),
			new Face(new byte[4] { 1, 2, 6, 5 }),
			new Face(new byte[4] { 2, 3, 7, 6 }),
			new Face(new byte[4] { 3, 0, 4, 7 }),
			new Face(new byte[4] { 4, 5, 6, 7 })
		};
	}

	protected Hexa8(Hexa8 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Hexa8(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemHexa8Surrogate(this);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		int num = 0;
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < 2; k++)
				{
					num++;
					double _0023_003DzuwH5j5s_003D = gpPosition[i];
					double _0023_003DzNDQ_E88_003D = gpPosition[j];
					double _0023_003Dz77g161c_003D = gpPosition[k];
					_0023_003DznYLn3XjOZy97(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array, array2);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
					double dvolu = detJacob * gpWeight[i] * gpWeight[j] * gpWeight[k];
					StiffnessComputation(num, cartDeriv, dvolu);
				}
			}
		}
		StiffnessComputation(nodes);
	}

	private void _0023_003DznYLn3XjOZy97(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double _0023_003Dz77g161c_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzwaU_0024oWk_003D[0] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[3] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[4] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[5] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[6] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzwaU_0024oWk_003D[7] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[0, 0] = (0.0 - (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 0] = (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[2, 0] = (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 0] = (0.0 - (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 - _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[4, 0] = (0.0 - (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 0] = (1.0 - _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[6, 0] = (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 0] = (0.0 - (1.0 + _0023_003DzNDQ_E88_003D) * (1.0 + _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[0, 1] = (0.0 - (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 1] = (0.0 - (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[2, 1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 1] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[4, 1] = (0.0 - (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 1] = (0.0 - (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003Dz77g161c_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[6, 1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 1] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003Dz77g161c_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[0, 2] = (0.0 - (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 2] = (0.0 - (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[2, 2] = (0.0 - (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 2] = (0.0 - (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D)) / 8.0;
		_0023_003DzmB17IaV5XzRN[4, 2] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[6, 2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 2] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0;
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		int num = 0;
		M = new double[base.TotalDof, base.TotalDof];
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < 2; k++)
				{
					num++;
					double _0023_003DzuwH5j5s_003D = gpPosition[i];
					double _0023_003DzNDQ_E88_003D = gpPosition[j];
					double _0023_003Dz77g161c_003D = gpPosition[k];
					_0023_003DznYLn3XjOZy97(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array, array2);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
					double dVolume = detJacob * gpWeight[i] * gpWeight[j] * gpWeight[k];
					AssembleMassMatrix(array, dVolume);
				}
			}
		}
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[NumberOfStressesPerNode, NumberOfNodes];
		for (int i = 1; i <= 2; i++)
		{
			for (int j = 1; j <= 2; j++)
			{
				for (int k = 1; k <= 2; k++)
				{
					num2++;
					num++;
					double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
					ComputeThermalLoading(num2, temperature, array, strsg);
				}
			}
		}
		double[,] array2 = new double[NumberOfStressesPerNode, NumberOfNodes];
		double num3 = -1.7320508075688772;
		double num4 = 1.7320508075688772;
		double[] array3 = new double[6];
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num4, num3, array, array3);
		for (int l = 0; l < 6; l++)
		{
			array2[l, 0] = array3[l];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num3, num3, array, array3);
		for (int m = 0; m < 6; m++)
		{
			array2[m, 1] = array3[m];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num3, num3, array, array3);
		for (int n = 0; n < 6; n++)
		{
			array2[n, 2] = array3[n];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num4, num3, array, array3);
		for (int num5 = 0; num5 < 6; num5++)
		{
			array2[num5, 3] = array3[num5];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num4, num4, array, array3);
		for (int num6 = 0; num6 < 6; num6++)
		{
			array2[num6, 4] = array3[num6];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num3, num4, array, array3);
		for (int num7 = 0; num7 < 6; num7++)
		{
			array2[num7, 5] = array3[num7];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num3, num4, array, array3);
		for (int num8 = 0; num8 < 6; num8++)
		{
			array2[num8, 6] = array3[num8];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num4, num4, array, array3);
		for (int num9 = 0; num9 < 6; num9++)
		{
			array2[num9, 7] = array3[num9];
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
		GaussQuadrature(out var gpPosition, out var _);
		double[] array2 = new double[NumberOfNodes];
		double[,] array3 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		tLoad = new double[base.TotalDof];
		strin = new double[NumberOfGaussPoints, NumberOfStressesPerNode];
		int num = 0;
		for (int j = 0; j < 2; j++)
		{
			for (int k = 0; k < 2; k++)
			{
				for (int l = 0; l < 2; l++)
				{
					num++;
					double _0023_003DzuwH5j5s_003D = gpPosition[j];
					double _0023_003DzNDQ_E88_003D = gpPosition[k];
					double _0023_003Dz77g161c_003D = gpPosition[l];
					_0023_003DznYLn3XjOZy97(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array2, array3);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
					double dvolu = detJacob;
					ComputeTemp(array, array2, num, cartDeriv, dvolu);
				}
			}
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, singleColor, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFaceElement4(context, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		List<IndexTriangle> list = new List<IndexTriangle>();
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				list.AddRange(GetFace4(elIndex, i, vertices, ampFactor, centroids));
			}
		}
		return list.ToArray();
	}

	public override void SetPressure(int faceIndex, Vector3D pressure, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elFaces[faceIndex].Indices[0]]];
		Node node = (Node)nodes[Connection[elFaces[faceIndex].Indices[1]]];
		Node p2 = (Node)nodes[Connection[elFaces[faceIndex].Indices[2]]];
		Vector3D vector3D = new Vector3D(p, node);
		vector3D.Normalize();
		Vector3D vector3D2 = new Vector3D(node, p2);
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
		_0023_003DzN56q_0024hSzdT0O(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	public override void SetPressure(int faceIndex, double pressure, Point3D[] nodes)
	{
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(0.0, 0.0, 0.0 - pressure);
		_0023_003DzN56q_0024hSzdT0O(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	internal void _0023_003DzN56q_0024hSzdT0O(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
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
		int[] array3 = new int[4];
		for (int k = 0; k < 4; k++)
		{
			array3[k] = elFaces[_0023_003DzL8NvYU0_003D].Indices[k];
		}
		double[] array4 = new double[2] { -0.577350269189626, 0.577350269189626 };
		for (int l = 0; l < 2; l++)
		{
			for (int m = 0; m < 2; m++)
			{
				double _0023_003DzuwH5j5s_003D = array4[l];
				double _0023_003DzNDQ_E88_003D = array4[m];
				_0023_003Dzyia2av_0024QpCT3_g6A7A_003D_003D(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzKjjYWhJTvaT_0024, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D);
				_0023_003Dz64ORJv9Aw3SuQhHOaw_003D_003D(_0023_003DzKjjYWhJTvaT_0024, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, array, array3);
			}
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		Segment3D segment3D = new Segment3D(fm.Vertices[Connection[0]], fm.Vertices[Connection[4]]);
		Segment3D segment3D2 = new Segment3D(fm.Vertices[Connection[1]], fm.Vertices[Connection[5]]);
		Segment3D segment3D3 = new Segment3D(fm.Vertices[Connection[2]], fm.Vertices[Connection[6]]);
		Segment3D segment3D4 = new Segment3D(fm.Vertices[Connection[3]], fm.Vertices[Connection[7]]);
		for (int i = 0; i <= t; i++)
		{
			List<Point3D> list2 = new List<Point3D>(4);
			Point3D point3D = segment3D.PointAt((double)i / (double)t);
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)t);
			Point3D point3D3 = segment3D3.PointAt((double)i / (double)t);
			Point3D point3D4 = segment3D4.PointAt((double)i / (double)t);
			list2.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			list2.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
			list2.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			list2.Add(new Node(point3D4.X, point3D4.Y, point3D4.Z));
			_0023_003DzK8EDfQ5Yw71v(s, r, list, list2);
		}
		List<Element> list3 = new List<Element>();
		list3.AddRange(fm.elements);
		int num = fm.Vertices.Length;
		int num2 = (s + 1) * (r + 1);
		int num3 = s + 1;
		for (int j = 0; j < t; j++)
		{
			for (int k = 0; k < r; k++)
			{
				for (int l = 0; l < s; l++)
				{
					Hexa8 item = new Hexa8(num + (num3 * k + l) + j * num2, num + (num3 * k + l + 1) + j * num2, num + (num3 * (k + 1) + l + 1) + j * num2, num + (num3 * (k + 1) + l) + j * num2, num + (num3 * k + l) + (j + 1) * num2, num + (num3 * k + l + 1) + (j + 1) * num2, num + (num3 * (k + 1) + l + 1) + (j + 1) * num2, num + (num3 * (k + 1) + l) + (j + 1) * num2, base.Material);
					list3.Add(item);
				}
			}
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list3.ToArray();
	}

	private void _0023_003DzK8EDfQ5Yw71v(int _0023_003DzuwH5j5s_003D, int _0023_003DzRpXgovo_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Point3D> _0023_003DzvXl0C1c_003D)
	{
		for (int i = 0; i <= _0023_003DzRpXgovo_003D; i++)
		{
			Segment3D segment3D = new Segment3D(_0023_003DzvXl0C1c_003D[0], _0023_003DzvXl0C1c_003D[3]);
			Segment3D segment3D2 = new Segment3D(_0023_003DzvXl0C1c_003D[1], _0023_003DzvXl0C1c_003D[2]);
			Point3D point3D = segment3D.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			for (int j = 1; j < _0023_003DzuwH5j5s_003D; j++)
			{
				Point3D point3D3 = new Segment3D(point3D, point3D2).PointAt((double)j / (double)_0023_003DzuwH5j5s_003D);
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			}
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
		}
	}

	internal Hexa20 _0023_003DzuqZUnnjQavZDSny_xA_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		return _0023_003DzuqZUnnjQavZDSny_xA_003D_003D(_0023_003DzDvuIQCU_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
	}

	internal static Hexa20 _0023_003DzuqZUnnjQavZDSny_xA_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>(4);
		for (int i = 0; i < _0023_003DzDvuIQCU_003D.Length; i++)
		{
			list.Add(_0023_003DzDvuIQCU_003D[i]);
			Segment3D segment3D = null;
			segment3D = i switch
			{
				3 => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[0]]), 
				7 => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[4]]), 
				_ => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 1]]), 
			};
			Node item = new Node(segment3D.MidPoint.X, segment3D.MidPoint.Y, segment3D.MidPoint.Z);
			list.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item);
			if (i <= 3)
			{
				Segment3D segment3D2 = new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 4]]);
				Node item2 = new Node(segment3D2.MidPoint.X, segment3D2.MidPoint.Y, segment3D2.MidPoint.Z);
				list2.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item2);
			}
			if (i == 3)
			{
				list.AddRange(list2);
			}
		}
		return new Hexa20(list, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D);
	}

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < Connection.Length; i++)
		{
			Point3D point3D = vertices[Connection[i]];
			PointSection p = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
			Segment3D segment3D;
			switch (i)
			{
			case 3:
			{
				point3D = vertices[Connection[0]];
				PointSection p4 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p4);
				break;
			}
			case 7:
			{
				point3D = vertices[Connection[4]];
				PointSection p3 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p3);
				break;
			}
			default:
			{
				point3D = vertices[Connection[i + 1]];
				PointSection p2 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p2);
				break;
			}
			}
			if (segment3D.IntersectWith(clippingPlane, out var intPoint))
			{
				PointSection pointSection = (PointSection)segment3D.P0;
				PointSection pointSection2 = (PointSection)segment3D.P1;
				double num = segment3D.Project(intPoint);
				PointSection item = new PointSection(intPoint.X, intPoint.Y, intPoint.Z, pointSection.plotValue + num * (pointSection2.plotValue - pointSection.plotValue));
				list.Add(item);
			}
			if (i <= 3)
			{
				point3D = vertices[Connection[i + 4]];
				PointSection p5 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				Segment3D segment3D2 = new Segment3D(p, p5);
				if (segment3D2.IntersectWith(clippingPlane, out intPoint))
				{
					PointSection pointSection3 = (PointSection)segment3D2.P0;
					PointSection pointSection4 = (PointSection)segment3D2.P1;
					double num2 = segment3D2.Project(intPoint);
					PointSection item2 = new PointSection(intPoint.X, intPoint.Y, intPoint.Z, pointSection3.plotValue + num2 * (pointSection4.plotValue - pointSection3.plotValue));
					list.Add(item2);
				}
			}
		}
		if (list.Count > 0)
		{
			return _0023_003DzpDhSsbU_003D(contourPlot, list, clippingPlane, size, legend);
		}
		return null;
	}
}
