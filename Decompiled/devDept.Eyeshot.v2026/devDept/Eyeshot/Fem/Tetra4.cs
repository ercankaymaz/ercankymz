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
public class Tetra4 : Element3D
{
	public Tetra4(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, Material mat)
		: this(new int[4] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4 }, mat)
	{
	}

	public Tetra4(IEnumerable<int> nodeIndices, Material mat)
		: base(4, mat)
	{
		NumberOfGaussPoints = 1;
		NumberOfStressesPerNode = 6;
		Connection = new int[NumberOfNodes];
		Connection = nodeIndices.ToArray();
		elFaces = new Face[4]
		{
			new Face(new byte[3] { 0, 2, 1 }),
			new Face(new byte[3] { 0, 1, 3 }),
			new Face(new byte[3] { 1, 2, 3 }),
			new Face(new byte[3] { 2, 0, 3 })
		};
	}

	protected Tetra4(Tetra4 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Tetra4(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemTetra4Surrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lump = false)
	{
		M = new double[base.TotalDof, base.TotalDof];
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		_0023_003Dz0qq7SBw7CxqP(0.25, 0.25, 0.25, 0.25, array, array2);
		double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
		Jacob3(1, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
		double num = detJacob * (1.0 / 6.0);
		double num2 = base.Material.Density * num / 20.0;
		for (int i = 0; i < 12; i++)
		{
			M[i, i] = 2.0 * num2;
		}
		for (int j = 0; j < 9; j++)
		{
			M[j, 3 + j] = num2;
			M[3 + j, j] = num2;
		}
		for (int k = 0; k < 5; k++)
		{
			M[k, 6 + k] = num2;
			M[6 + k, k] = num2;
		}
		for (int l = 0; l < 3; l++)
		{
			M[l, 9 + l] = num2;
			M[9 + l, l] = num2;
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfNodes, base.TotalDof, NumberOfStressesPerNode];
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		_0023_003Dz0qq7SBw7CxqP(0.25, 0.25, 0.25, 0.25, array, array2);
		double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
		Jacob3(1, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
		double dvolu = detJacob * (1.0 / 6.0);
		StiffnessComputation(1, cartDeriv, dvolu);
		StiffnessComputation(nodes);
	}

	private void _0023_003Dz0qq7SBw7CxqP(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double _0023_003DzE5gt1ko_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzwaU_0024oWk_003D[0] = _0023_003DziMjqlCo_003D;
		_0023_003DzwaU_0024oWk_003D[1] = _0023_003DzI4dRPW0_003D;
		_0023_003DzwaU_0024oWk_003D[2] = _0023_003DzE5gt1ko_003D;
		_0023_003DzwaU_0024oWk_003D[3] = _0023_003DzYEhafAA_003D;
		double[,] array = new double[4, 4];
		array[0, 0] = 1.0;
		array[1, 1] = 1.0;
		array[3, 2] = 1.0;
		array[2, 3] = 1.0;
		_0023_003DzmB17IaV5XzRN[0, 0] = array[0, 0] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 0] = array[1, 0] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 0] = array[2, 0] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 0] = array[3, 0] - array[3, 3];
		_0023_003DzmB17IaV5XzRN[0, 1] = array[0, 1] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 1] = array[1, 1] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 1] = array[2, 1] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 1] = array[3, 1] - array[3, 3];
		_0023_003DzmB17IaV5XzRN[0, 2] = array[0, 2] - array[0, 3];
		_0023_003DzmB17IaV5XzRN[1, 2] = array[1, 2] - array[1, 3];
		_0023_003DzmB17IaV5XzRN[2, 2] = array[2, 2] - array[2, 3];
		_0023_003DzmB17IaV5XzRN[3, 2] = array[3, 2] - array[3, 3];
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[NumberOfStressesPerNode, NumberOfNodes];
		num2++;
		num++;
		double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
		ComputeThermalLoading(num2, temperature, array, strsg);
		double[,] array2 = new double[6, NumberOfNodes];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				array2[j, i] = array[j, 0];
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
		strin = new double[NumberOfGaussPoints, NumberOfStressesPerNode];
		int num = 1;
		_0023_003Dz0qq7SBw7CxqP(0.25, 0.25, 0.25, 0.25, array2, array3);
		double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
		Jacob3(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
		double dvolu = detJacob * (1.0 / 6.0);
		ComputeTemp(array, array2, num, cartDeriv, dvolu);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace3(context, singleColor, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace3(context, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace3(context, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFaceElement3(context, i, vertices, min, max, ampFactor, mode);
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
				list.AddRange(GetFace3(elIndex, i, vertices, ampFactor, centroids));
			}
		}
		return list.ToArray();
	}

	public override void SetPressure(int faceIndex, Vector3D pressure, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elFaces[faceIndex].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elFaces[faceIndex].Indices[1]]];
		Node p3 = (Node)nodes[Connection[elFaces[faceIndex].Indices[2]]];
		Vector3D vector3D = new Vector3D(p3, p);
		vector3D.Normalize();
		Vector3D vector3D2 = new Vector3D(p3, p2);
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
		_0023_003DznHTyYTx9Dmii9sLp9A_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	public override void SetPressure(int faceIndex, double pressure, Point3D[] nodes)
	{
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(0.0, 0.0, 0.0 - pressure);
		_0023_003DznHTyYTx9Dmii9sLp9A_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	internal void _0023_003DznHTyYTx9Dmii9sLp9A_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
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
		int[] array2 = new int[3];
		for (int j = 0; j < 3; j++)
		{
			array2[j] = elFaces[_0023_003DzL8NvYU0_003D].Indices[j];
		}
		double[] array3 = new double[NumberOfNodes * NumberOfDimensions];
		for (int k = 0; k < NumberOfNodes; k++)
		{
			int num = Connection[k];
			array3[k * NumberOfDimensions] = _0023_003DzDvuIQCU_003D[num].X;
			array3[k * NumberOfDimensions + 1] = _0023_003DzDvuIQCU_003D[num].Y;
			array3[k * NumberOfDimensions + 2] = _0023_003DzDvuIQCU_003D[num].Z;
		}
		for (int l = 1; l <= 3; l++)
		{
			double _0023_003DziMjqlCo_003D;
			double _0023_003DzI4dRPW0_003D;
			double _0023_003DzYEhafAA_003D;
			switch (l)
			{
			case 1:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				break;
			default:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				break;
			}
			_0023_003DzXkqbKnf_0024FS3S(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, out var _0023_003DzwaU_0024oWk_003D, out var _0023_003DzmB17IaV5XzRN);
			_0023_003DzJu_9h_0024282FVIbKOjmQ_003D_003D(_0023_003DzwaU_0024oWk_003D, array3, _0023_003DzmB17IaV5XzRN, array, array2);
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		List<int> list2 = new List<int>();
		for (int i = 0; i < Connection.Length - 1; i++)
		{
			Segment3D segment3D = new Segment3D(list[Connection[i]], list[Connection[3]]);
			Segment3D segment3D2 = ((i != 2) ? new Segment3D(list[Connection[i]], list[Connection[i + 1]]) : new Segment3D(list[Connection[i]], list[Connection[0]]));
			list2.Add(list.Count);
			list.Add((Node)list[Connection[i]].Clone());
			list2.Add(list.Count);
			list.Add(new Node(segment3D2.MidPoint.X, segment3D2.MidPoint.Y, segment3D2.MidPoint.Z));
			list2.Add(list.Count);
			list.Add(new Node(segment3D.MidPoint.X, segment3D.MidPoint.Y, segment3D.MidPoint.Z));
		}
		list2.Add(list.Count);
		list.Add((Node)fm.Vertices[Connection[Connection.Length - 1]].Clone());
		List<Element> list3 = new List<Element>();
		list3.AddRange(fm.elements);
		Tetra4 item = new Tetra4(7, 8, 5, 9, base.Material);
		Tetra4 item2 = new Tetra4(8, 10, 11, 12, base.Material);
		Tetra4 item3 = new Tetra4(5, 11, 4, 6, base.Material);
		Tetra4 item4 = new Tetra4(8, 12, 5, 9, base.Material);
		Tetra4 item5 = new Tetra4(12, 11, 5, 6, base.Material);
		Tetra4 item6 = new Tetra4(9, 12, 5, 6, base.Material);
		Tetra4 item7 = new Tetra4(9, 12, 6, 13, base.Material);
		Tetra4 item8 = new Tetra4(8, 11, 5, 12, base.Material);
		list3.Add(item);
		list3.Add(item2);
		list3.Add(item3);
		list3.Add(item4);
		list3.Add(item5);
		list3.Add(item6);
		list3.Add(item7);
		list3.Add(item8);
		fm.Vertices = list.ToArray();
		fm.Elements = list3.ToArray();
	}

	internal Tetra10 _0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		return _0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(_0023_003DzDvuIQCU_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
	}

	internal static Tetra10 _0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>(3);
		for (int i = 0; i < _0023_003DzDvuIQCU_003D.Length - 1; i++)
		{
			list.Add(_0023_003DzDvuIQCU_003D[i]);
			Segment3D segment3D = ((i != 2) ? new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 1]]) : new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[0]]));
			Node item = new Node(segment3D.MidPoint.X, segment3D.MidPoint.Y, segment3D.MidPoint.Z);
			list.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item);
			Segment3D segment3D2 = new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[3]]);
			Node item2 = new Node(segment3D2.MidPoint.X, segment3D2.MidPoint.Y, segment3D2.MidPoint.Z);
			list2.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item2);
		}
		list.AddRange(list2);
		list.Add(_0023_003DzDvuIQCU_003D[3]);
		return new Tetra10(list, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D);
	}

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < Connection.Length - 1; i++)
		{
			Point3D point3D = vertices[Connection[i]];
			PointSection p = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
			Segment3D segment3D;
			if (i == 2)
			{
				point3D = vertices[Connection[0]];
				PointSection p2 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p2);
			}
			else
			{
				point3D = vertices[Connection[i + 1]];
				PointSection p3 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p3);
			}
			if (segment3D.IntersectWith(clippingPlane, out var intPoint))
			{
				PointSection pointSection = (PointSection)segment3D.P0;
				PointSection pointSection2 = (PointSection)segment3D.P1;
				double num = segment3D.Project(intPoint);
				PointSection item = new PointSection(intPoint.X, intPoint.Y, intPoint.Z, pointSection.plotValue + num * (pointSection2.plotValue - pointSection.plotValue));
				list.Add(item);
			}
			point3D = vertices[Connection[3]];
			PointSection p4 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
			Segment3D segment3D2 = new Segment3D(p, p4);
			if (segment3D2.IntersectWith(clippingPlane, out intPoint) && segment3D2.IntersectWith(clippingPlane, out intPoint))
			{
				PointSection pointSection3 = (PointSection)segment3D2.P0;
				PointSection pointSection4 = (PointSection)segment3D2.P1;
				double num2 = segment3D2.Project(intPoint);
				PointSection item2 = new PointSection(intPoint.X, intPoint.Y, intPoint.Z, pointSection3.plotValue + num2 * (pointSection4.plotValue - pointSection3.plotValue));
				list.Add(item2);
			}
		}
		if (list.Count > 0)
		{
			return _0023_003DzpDhSsbU_003D(contourPlot, list, clippingPlane, size, legend);
		}
		return null;
	}
}
