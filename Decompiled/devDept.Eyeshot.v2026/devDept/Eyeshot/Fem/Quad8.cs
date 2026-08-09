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
public class Quad8 : Element2D
{
	public Quad8(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, int nodeIndex7, int nodeIndex8, Material mat)
		: this(new int[8] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6, nodeIndex7, nodeIndex8 }, mat)
	{
	}

	public Quad8(IEnumerable<int> nodeIndices, Material mat)
		: base(8, mat)
	{
		NumberOfGaussPoints = 4;
		Connection = nodeIndices.ToArray();
		elEdges = new Edge[4]
		{
			new Edge(new byte[3] { 0, 1, 2 }),
			new Edge(new byte[3] { 2, 3, 4 }),
			new Edge(new byte[3] { 4, 5, 6 }),
			new Edge(new byte[3] { 6, 7, 0 })
		};
		elFaces = new Face[1]
		{
			new Face(new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7 })
		};
	}

	protected Quad8(Quad8 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Quad8(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemQuad8Surrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		int num = 0;
		M = new double[base.TotalDof, base.TotalDof];
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DzuwH5j5s_003D = 0.0;
		double _0023_003DzNDQ_E88_003D = 0.0;
		for (int i = 1; i <= 4; i++)
		{
			num++;
			if (num == 1)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 2)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			if (num == 3)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 4)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			_0023_003Dzcm21Yc_0024BQLaU(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * gpWeight[0] * gpWeight[0];
			AssembleMassMatrix(array, dVolume);
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		double thick = 1.0;
		if (base.Material.ElementType == elementType.PlaneStress)
		{
			thick = base.Material.ElementThickness;
		}
		int num = 0;
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DzuwH5j5s_003D = 0.0;
		double _0023_003DzNDQ_E88_003D = 0.0;
		for (int i = 1; i <= 4; i++)
		{
			num++;
			if (num == 1)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 2)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			if (num == 3)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 4)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			_0023_003Dzcm21Yc_0024BQLaU(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * gpWeight[0] * gpWeight[0];
			StiffnessComputation(num, array, cartDeriv, gaussPoints, dvolu, thick);
		}
		StiffnessComputation(nodes);
	}

	private static void _0023_003Dzcm21Yc_0024BQLaU(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		double num = _0023_003DzuwH5j5s_003D * 2.0;
		double num2 = _0023_003DzNDQ_E88_003D * 2.0;
		double num3 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D;
		double num4 = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num5 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
		double num6 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
		double num7 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num8 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * 2.0;
		_0023_003DzwaU_0024oWk_003D[0] = (-1.0 + num5 + num3 + num4 - num6 - num7) / 4.0;
		_0023_003DzwaU_0024oWk_003D[1] = (1.0 - _0023_003DzNDQ_E88_003D - num3 + num6) / 2.0;
		_0023_003DzwaU_0024oWk_003D[2] = (-1.0 - num5 + num3 + num4 - num6 + num7) / 4.0;
		_0023_003DzwaU_0024oWk_003D[3] = (1.0 + _0023_003DzuwH5j5s_003D - num4 - num7) / 2.0;
		_0023_003DzwaU_0024oWk_003D[4] = (-1.0 + num5 + num3 + num4 + num6 + num7) / 4.0;
		_0023_003DzwaU_0024oWk_003D[5] = (1.0 + _0023_003DzNDQ_E88_003D - num3 - num6) / 2.0;
		_0023_003DzwaU_0024oWk_003D[6] = (-1.0 - num5 + num3 + num4 + num6 - num7) / 4.0;
		_0023_003DzwaU_0024oWk_003D[7] = (1.0 - _0023_003DzuwH5j5s_003D - num4 + num7) / 2.0;
		_0023_003DzmB17IaV5XzRN[0, 0] = (_0023_003DzNDQ_E88_003D + num - num8 - num4) / 4.0;
		_0023_003DzmB17IaV5XzRN[1, 0] = 0.0 - _0023_003DzuwH5j5s_003D + num5;
		_0023_003DzmB17IaV5XzRN[2, 0] = (0.0 - _0023_003DzNDQ_E88_003D + num - num8 + num4) / 4.0;
		_0023_003DzmB17IaV5XzRN[3, 0] = (1.0 - num4) / 2.0;
		_0023_003DzmB17IaV5XzRN[4, 0] = (_0023_003DzNDQ_E88_003D + num + num8 + num4) / 4.0;
		_0023_003DzmB17IaV5XzRN[5, 0] = 0.0 - _0023_003DzuwH5j5s_003D - num5;
		_0023_003DzmB17IaV5XzRN[6, 0] = (0.0 - _0023_003DzNDQ_E88_003D + num + num8 - num4) / 4.0;
		_0023_003DzmB17IaV5XzRN[7, 0] = (-1.0 + num4) / 2.0;
		_0023_003DzmB17IaV5XzRN[0, 1] = (_0023_003DzuwH5j5s_003D + num2 - num3 - num8) / 4.0;
		_0023_003DzmB17IaV5XzRN[1, 1] = (-1.0 + num3) / 2.0;
		_0023_003DzmB17IaV5XzRN[2, 1] = (0.0 - _0023_003DzuwH5j5s_003D + num2 - num3 + num8) / 4.0;
		_0023_003DzmB17IaV5XzRN[3, 1] = 0.0 - _0023_003DzNDQ_E88_003D - num5;
		_0023_003DzmB17IaV5XzRN[4, 1] = (_0023_003DzuwH5j5s_003D + num2 + num3 + num8) / 4.0;
		_0023_003DzmB17IaV5XzRN[5, 1] = (1.0 - num3) / 2.0;
		_0023_003DzmB17IaV5XzRN[6, 1] = (0.0 - _0023_003DzuwH5j5s_003D + num2 + num3 - num8) / 4.0;
		_0023_003DzmB17IaV5XzRN[7, 1] = 0.0 - _0023_003DzNDQ_E88_003D + num5;
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		double[] array = new double[NumberOfNodes];
		for (int i = 0; i < NumberOfNodes; i++)
		{
			array[i] = ((Node)nodes[Connection[i]]).Temperature;
		}
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array2 = new double[NumberOfNodes];
		double[,] array3 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		tLoad = new double[base.TotalDof];
		strin = new double[NumberOfGaussPoints, 4];
		int num = 0;
		double _0023_003DzuwH5j5s_003D = 0.0;
		double _0023_003DzNDQ_E88_003D = 0.0;
		for (int j = 1; j <= 4; j++)
		{
			num++;
			if (num == 1)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 2)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			if (num == 3)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num == 4)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			_0023_003Dzcm21Yc_0024BQLaU(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array2, array3);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * gpWeight[0] * gpWeight[0];
			ComputeTemp(nodes, array2, cartDeriv, dvolu, array, num, gaussPoints);
		}
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[4, NumberOfNodes];
		for (int i = 1; i <= 2; i++)
		{
			for (int j = 1; j <= 2; j++)
			{
				num2++;
				num++;
				double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
				ComputeThermalLoading(num2, temperature, array, strsg);
			}
		}
		double[,] array2 = new double[4, NumberOfNodes];
		double num3 = 1.8660254037844386;
		double num4 = 0.1339745962155614;
		switch (base.Material.ElementType)
		{
		case elementType.PlaneStress:
		{
			for (int l = 0; l < 3; l++)
			{
				array2[l, 0] = num3 * array[l, 0] + -0.5 * array[l, 2] + num4 * array[l, 3] + -0.5 * array[l, 1];
				array2[l, 2] = -0.5 * array[l, 0] + num3 * array[l, 2] + -0.5 * array[l, 3] + num4 * array[l, 1];
				array2[l, 4] = num4 * array[l, 0] + -0.5 * array[l, 2] + num3 * array[l, 3] + -0.5 * array[l, 1];
				array2[l, 6] = -0.5 * array[l, 0] + num4 * array[l, 2] + -0.5 * array[l, 3] + num3 * array[l, 1];
				array2[l, 1] = (array2[l, 0] + array2[l, 2]) / 2.0;
				array2[l, 3] = (array2[l, 2] + array2[l, 4]) / 2.0;
				array2[l, 5] = (array2[l, 4] + array2[l, 6]) / 2.0;
				array2[l, 7] = (array2[l, 0] + array2[l, 6]) / 2.0;
			}
			break;
		}
		case elementType.PlaneStrain:
		case elementType.Axisymmetric:
		{
			for (int k = 0; k < 4; k++)
			{
				array2[k, 0] = num3 * array[k, 0] + -0.5 * array[k, 2] + num4 * array[k, 3] + -0.5 * array[k, 1];
				array2[k, 2] = -0.5 * array[k, 0] + num3 * array[k, 2] + -0.5 * array[k, 3] + num4 * array[k, 1];
				array2[k, 4] = num4 * array[k, 0] + -0.5 * array[k, 2] + num3 * array[k, 3] + -0.5 * array[k, 1];
				array2[k, 6] = -0.5 * array[k, 0] + num4 * array[k, 2] + -0.5 * array[k, 3] + num3 * array[k, 1];
				array2[k, 1] = (array2[k, 0] + array2[k, 2]) / 2.0;
				array2[k, 3] = (array2[k, 2] + array2[k, 4]) / 2.0;
				array2[k, 5] = (array2[k, 4] + array2[k, 6]) / 2.0;
				array2[k, 7] = (array2[k, 0] + array2[k, 6]) / 2.0;
			}
			break;
		}
		}
		TotalUpTheStresses(array2, numberOfElementsPerNode, nodes);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace8(context, singleColor, 0, vertices, ampFactor, mode);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace8(context, 0, vertices, ampFactor, mode);
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		DrawFace8(context, 0, vertices, min, max, ampFactor, mode);
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003Dz_0024pRElff8RWIV(context, 0, vertices, min, max, ampFactor, mode);
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		return GetFace8(elIndex, 0, vertices, ampFactor, centroids);
	}

	public override void SetPressure(int edgeIndex, Vector3D pressure, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elEdges[edgeIndex].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elEdges[edgeIndex].Indices[2]]];
		Vector2D _0023_003DzTx2aqr8_003D = new Vector2D(p, p2);
		Vector2D _0023_003DzJvZCors_003D = Element2D._0023_003DzTYQj7dTpRcf3AB30m3Ejgzk_003D(new Vector2D(pressure.X, pressure.Y), _0023_003DzTx2aqr8_003D);
		_0023_003DzjB34KOs19_0024U0(nodes, _0023_003DzJvZCors_003D, edgeIndex);
		base.SetPressure(edgeIndex, pressure, nodes);
	}

	public override void SetPressure(int edgeIndex, double pressure, Point3D[] nodes)
	{
		Vector2D _0023_003DzJvZCors_003D = new Vector2D(0.0, pressure);
		_0023_003DzjB34KOs19_0024U0(nodes, _0023_003DzJvZCors_003D, edgeIndex);
		base.SetPressure(edgeIndex, pressure, nodes);
	}

	public override void Revolve(double angle, Vector3D axis, Point3D center, int slices, FemMesh fm)
	{
		List<Element> list = new List<Element>();
		list.AddRange(fm.Elements);
		List<Point3D> list2 = new List<Point3D>();
		list2.AddRange(fm.Vertices);
		int num = fm.Vertices.Count();
		devDept.Geometry.Rotation xform = new devDept.Geometry.Rotation(angle / (double)slices, axis, center);
		for (int i = 1; i <= slices; i++)
		{
			num = fm.Vertices.Count();
			list2 = new List<Point3D>();
			list2.AddRange(fm.Vertices);
			int[] connection = Connection;
			foreach (int num2 in connection)
			{
				Node node = (Node)fm.Vertices[num2].Clone();
				node.TransformBy(xform);
				list2.Add(node);
			}
			List<int> list3 = new List<int>();
			list3.AddRange(Connection);
			Connection = new int[8]
			{
				num,
				num + 1,
				num + 2,
				num + 3,
				num + 4,
				num + 5,
				num + 6,
				num + 7
			};
			list3.AddRange(Connection);
			list3 = _0023_003Dz_0024LLljbvl_0024PEt(list3.ToArray(), list2);
			Hexa20 item = new Hexa20(list3, base.Material);
			list.Add(item);
			fm.Vertices = list2.ToArray();
		}
		fm.Elements = list.ToArray();
	}

	public override void Extrude(Vector3D amount, int slices, FemMesh fm)
	{
		List<Element> list = new List<Element>();
		list.AddRange(fm.Elements);
		List<Point3D> list2 = new List<Point3D>();
		list2.AddRange(fm.Vertices);
		int num = fm.Vertices.Count();
		Translation xform = new Translation(amount / slices);
		for (int i = 1; i <= slices; i++)
		{
			num = fm.Vertices.Count();
			list2 = new List<Point3D>();
			list2.AddRange(fm.Vertices);
			int[] connection = Connection;
			foreach (int num2 in connection)
			{
				Node node = (Node)fm.Vertices[num2].Clone();
				node.TransformBy(xform);
				list2.Add(node);
			}
			List<int> list3 = new List<int>();
			list3.AddRange(Connection);
			Connection = new int[8]
			{
				num,
				num + 1,
				num + 2,
				num + 3,
				num + 4,
				num + 5,
				num + 6,
				num + 7
			};
			list3.AddRange(Connection);
			list3 = _0023_003Dz_0024LLljbvl_0024PEt(list3.ToArray(), list2);
			Hexa20 item = new Hexa20(list3, base.Material);
			list.Add(item);
			fm.Vertices = list2.ToArray();
		}
		fm.Elements = list.ToArray();
	}

	public override void Refine(int r, int s, int t, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		for (int i = 0; i <= s; i++)
		{
			Segment3D segment3D = new Segment3D(fm.Vertices[Connection[0]], fm.Vertices[Connection[6]]);
			Segment3D segment3D2 = new Segment3D(fm.Vertices[Connection[2]], fm.Vertices[Connection[4]]);
			Point3D point3D = segment3D.PointAt((double)i / (double)s);
			list.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)s);
			for (int j = 1; j < r; j++)
			{
				Point3D point3D3 = new Segment3D(point3D, point3D2).PointAt((double)j / (double)r);
				list.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			}
			list.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
		}
		List<Element> list2 = new List<Element>();
		list2.AddRange(fm.elements);
		int num = r + 1;
		int num2 = fm.Vertices.Length;
		for (int k = 0; k < s; k++)
		{
			for (int l = 0; l < r; l++)
			{
				Quad8 item = Quad4._0023_003DzjKLmeSIGqK0l(new List<int>
				{
					num2 + num * k + l,
					num2 + num * k + l + 1,
					num2 + num * (k + 1) + l + 1,
					num2 + num * (k + 1) + l
				}.ToArray(), list, base.Material);
				list2.Add(item);
			}
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list2.ToArray();
	}

	internal override double[] _0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(Face _0023_003Dz3PZbRez_mP9t)
	{
		double[] array = new double[8];
		_0023_003Dzcm21Yc_0024BQLaU(0.0, 0.0, array, new double[8, 2]);
		return array;
	}
}
