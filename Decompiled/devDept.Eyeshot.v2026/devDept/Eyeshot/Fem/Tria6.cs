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
public class Tria6 : Element2D
{
	public Tria6(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, Material mat)
		: this(new int[6] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6 }, mat)
	{
	}

	public Tria6(IEnumerable<int> nodeIndices, Material mat)
		: base(6, mat)
	{
		NumberOfGaussPoints = 3;
		Connection = new int[NumberOfNodes];
		Connection = nodeIndices.ToArray();
		elEdges = new Edge[3]
		{
			new Edge(new byte[3] { 0, 1, 2 }),
			new Edge(new byte[3] { 2, 3, 4 }),
			new Edge(new byte[3] { 4, 5, 0 })
		};
		elFaces = new Face[1]
		{
			new Face(new byte[6] { 0, 1, 2, 3, 4, 5 })
		};
	}

	protected Tria6(Tria6 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Tria6(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemTria6Surrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		int num = 0;
		M = new double[base.TotalDof, base.TotalDof];
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfNodes, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		for (int i = 1; i <= 3; i++)
		{
			num++;
			if (i == 1)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
			}
			if (i == 2)
			{
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			if (i == 3)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			_0023_003DzvXyia0CBZjno(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * 0.33333333333 * 0.5;
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
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfNodes, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		for (int i = 1; i <= 3; i++)
		{
			num++;
			if (i == 1)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
			}
			if (i == 2)
			{
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			if (i == 3)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			_0023_003DzvXyia0CBZjno(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * 0.33333333333 * 0.5;
			StiffnessComputation(num, array, cartDeriv, gaussPoints, dvolu, thick);
		}
		StiffnessComputation(nodes);
	}

	private void _0023_003DzvXyia0CBZjno(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzwaU_0024oWk_003D[0] = _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[1] = 4.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D;
		_0023_003DzwaU_0024oWk_003D[2] = _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[3] = 4.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D;
		_0023_003DzwaU_0024oWk_003D[4] = _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0);
		_0023_003DzwaU_0024oWk_003D[5] = 4.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D;
		double[,] array = new double[6, 3];
		array[0, 0] = 4.0 * _0023_003DziMjqlCo_003D - 1.0;
		array[1, 0] = 4.0 * _0023_003DzI4dRPW0_003D;
		array[5, 0] = 4.0 * _0023_003DzYEhafAA_003D;
		array[1, 1] = 4.0 * _0023_003DziMjqlCo_003D;
		array[2, 1] = 4.0 * _0023_003DzI4dRPW0_003D - 1.0;
		array[3, 1] = 4.0 * _0023_003DzYEhafAA_003D;
		array[3, 2] = 4.0 * _0023_003DzI4dRPW0_003D;
		array[4, 2] = 4.0 * _0023_003DzYEhafAA_003D - 1.0;
		array[5, 2] = 4.0 * _0023_003DziMjqlCo_003D;
		_0023_003DzmB17IaV5XzRN[0, 0] = array[0, 0] - array[0, 2];
		_0023_003DzmB17IaV5XzRN[1, 0] = array[1, 0] - array[1, 2];
		_0023_003DzmB17IaV5XzRN[2, 0] = array[2, 0] - array[2, 2];
		_0023_003DzmB17IaV5XzRN[3, 0] = array[3, 0] - array[3, 2];
		_0023_003DzmB17IaV5XzRN[4, 0] = array[4, 0] - array[4, 2];
		_0023_003DzmB17IaV5XzRN[5, 0] = array[5, 0] - array[5, 2];
		_0023_003DzmB17IaV5XzRN[0, 1] = array[0, 1] - array[0, 2];
		_0023_003DzmB17IaV5XzRN[1, 1] = array[1, 1] - array[1, 2];
		_0023_003DzmB17IaV5XzRN[2, 1] = array[2, 1] - array[2, 2];
		_0023_003DzmB17IaV5XzRN[3, 1] = array[3, 1] - array[3, 2];
		_0023_003DzmB17IaV5XzRN[4, 1] = array[4, 1] - array[4, 2];
		_0023_003DzmB17IaV5XzRN[5, 1] = array[5, 1] - array[5, 2];
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[4, NumberOfNodes];
		for (int i = 1; i <= 3; i++)
		{
			num2++;
			num++;
			double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
			ComputeThermalLoading(num2, temperature, array, strsg);
		}
		double[,] array2 = new double[4, NumberOfNodes];
		switch (base.Material.ElementType)
		{
		case elementType.PlaneStress:
		{
			for (int k = 0; k < 3; k++)
			{
				array2[k, 1] = array[k, 0];
				array2[k, 3] = array[k, 1];
				array2[k, 5] = array[k, 2];
				array2[k, 0] = array2[k, 5] + array2[k, 1] - array2[k, 3];
				array2[k, 2] = array2[k, 1] + array2[k, 3] - array2[k, 5];
				array2[k, 4] = array2[k, 3] + array2[k, 5] - array2[k, 1];
			}
			break;
		}
		case elementType.PlaneStrain:
		case elementType.Axisymmetric:
		{
			for (int j = 0; j < 4; j++)
			{
				array2[j, 1] = array[j, 0];
				array2[j, 3] = array[j, 1];
				array2[j, 5] = array[j, 2];
				array2[j, 0] = array2[j, 5] + array2[j, 1] - array2[j, 3];
				array2[j, 2] = array2[j, 1] + array2[j, 3] - array2[j, 5];
				array2[j, 4] = array2[j, 3] + array2[j, 5] - array2[j, 1];
			}
			break;
		}
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
		strin = new double[NumberOfGaussPoints, 4];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		int num = 0;
		for (int j = 1; j <= 3; j++)
		{
			num++;
			if (j == 1)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
			}
			if (j == 2)
			{
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			if (j == 3)
			{
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
			}
			_0023_003DzvXyia0CBZjno(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, array2, array3);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * 0.33333333333333 * 0.5;
			ComputeTemp(nodes, array2, cartDeriv, dvolu, array, num, gaussPoints);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace6(context, singleColor, 0, vertices, ampFactor, mode);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace6(context, 0, vertices, ampFactor, mode);
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		DrawFace6(context, 0, vertices, min, max, ampFactor, mode);
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		DrawFaceElement6(context, 0, vertices, min, max, ampFactor, mode);
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		return GetFace6(elIndex, 0, vertices, ampFactor, centroids);
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
		devDept.Geometry.Rotation xform = new devDept.Geometry.Rotation(angle / (double)slices, axis, center);
		for (int i = 1; i <= slices; i++)
		{
			int num = fm.Vertices.Count();
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
			Connection = new int[6]
			{
				num,
				num + 1,
				num + 2,
				num + 3,
				num + 4,
				num + 5
			};
			list3.AddRange(Connection);
			list3 = _0023_003Dz_0024LLljbvl_0024PEt(list3.ToArray(), list2);
			Penta15 item = new Penta15(list3, base.Material);
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
		Translation xform = new Translation(amount / slices);
		for (int i = 1; i <= slices; i++)
		{
			int num = fm.Vertices.Count();
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
			Connection = new int[6]
			{
				num,
				num + 1,
				num + 2,
				num + 3,
				num + 4,
				num + 5
			};
			list3.AddRange(Connection);
			list3 = _0023_003Dz_0024LLljbvl_0024PEt(list3.ToArray(), list2);
			Penta15 item = new Penta15(list3, base.Material);
			list.Add(item);
			fm.Vertices = list2.ToArray();
		}
		fm.Elements = list.ToArray();
	}

	public override void Refine(int r, int s, int t, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		List<Element> list2 = new List<Element>();
		list2.AddRange(fm.elements);
		int[][] array = new int[4][]
		{
			new int[3]
			{
				Connection[0],
				Connection[1],
				Connection[5]
			},
			new int[3]
			{
				Connection[1],
				Connection[2],
				Connection[3]
			},
			new int[3]
			{
				Connection[1],
				Connection[3],
				Connection[5]
			},
			new int[3]
			{
				Connection[5],
				Connection[3],
				Connection[4]
			}
		};
		for (int i = 0; i < array.Length; i++)
		{
			Tria6 item = Tria3._0023_003Dzjfhd66VFBfATvheb_g_003D_003D(array[i].ToArray(), list, base.Material);
			list2.Add(item);
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list2.ToArray();
	}
}
