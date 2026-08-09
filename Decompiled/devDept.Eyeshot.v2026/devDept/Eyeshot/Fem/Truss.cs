using System;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Truss : Element3D
{
	private readonly double secArea;

	internal double temperature;

	private double L;

	private double dx;

	private double dy;

	private double dz;

	private double axialLoad;

	public double SectionArea => secArea;

	public double AxialLoad => axialLoad;

	public Truss(int nodeIndex1, int nodeIndex2, Material mat, double area)
		: base(2, mat)
	{
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		secArea = area;
		elFaces = new Face[0];
	}

	protected Truss(Truss another)
		: base(another)
	{
		secArea = another.secArea;
		elFaces = new Face[0];
	}

	public override object Clone()
	{
		return new Truss(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemTrussSurrogate(this);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		L = nodes[Connection[0]].DistanceTo(nodes[Connection[1]]);
		dx = (nodes[Connection[1]].X - nodes[Connection[0]].X) / L;
		dy = (nodes[Connection[1]].Y - nodes[Connection[0]].Y) / L;
		dz = (nodes[Connection[1]].Z - nodes[Connection[0]].Z) / L;
		double num = dx * dx;
		double num2 = dx * dy;
		double num3 = dx * dz;
		double num4 = dy * dy;
		double num5 = dy * dz;
		double num6 = dz * dz;
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		double num7 = mat.Young * secArea / L;
		K[0, 0] = (K[3, 3] = num * num7);
		K[3, 0] = (0.0 - num) * num7;
		K[1, 1] = (K[4, 4] = num4 * num7);
		K[4, 1] = (0.0 - num4) * num7;
		K[2, 2] = (K[5, 5] = num6 * num7);
		K[5, 2] = (0.0 - num6) * num7;
		K[1, 0] = (K[4, 3] = num2 * num7);
		K[4, 0] = (K[3, 1] = (0.0 - num2) * num7);
		K[2, 0] = (K[5, 3] = num3 * num7);
		K[5, 0] = (K[3, 2] = (0.0 - num3) * num7);
		K[2, 1] = (K[5, 4] = num5 * num7);
		K[4, 2] = (K[5, 1] = (0.0 - num5) * num7);
		StiffnessComputation(nodes);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		M = new double[6, 6];
		double num = mat.Density * secArea * L / 6.0;
		for (int i = 0; i < 6; i++)
		{
			M[i, i] = 2.0 * num;
		}
		for (int j = 0; j < 3; j++)
		{
			M[3 + j, j] = num;
			M[j, 3 + j] = num;
		}
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		double[] array = new double[6]
		{
			0.0 - dx,
			0.0 - dy,
			0.0 - dz,
			dx,
			dy,
			dz
		};
		double[] array2 = new double[6]
		{
			((Node)nodes[Connection[0]]).Unknowns[0][0],
			((Node)nodes[Connection[0]]).Unknowns[0][1],
			((Node)nodes[Connection[0]]).Unknowns[0][2],
			((Node)nodes[Connection[1]]).Unknowns[0][0],
			((Node)nodes[Connection[1]]).Unknowns[0][1],
			((Node)nodes[Connection[1]]).Unknowns[0][2]
		};
		double num = mat.Young / L;
		double num2 = 0.0;
		for (int i = 0; i < 6; i++)
		{
			num2 += num * array[i] * array2[i];
		}
		if (this.temperature != 0.0)
		{
			double num3 = mat.CoeffOfThermalExp * this.temperature * mat.Young;
			num2 -= num3;
		}
		double[,] array3 = new double[6, NumberOfNodes];
		for (int j = 0; j < 6; j++)
		{
			array3[j, 0] = num2;
			array3[j, 1] = num2;
		}
		axialLoad = num2 * secArea;
		TotalUpTheStresses(array3, numberOfElementsPerNode, nodes);
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		tLoad = new double[base.TotalDof];
		temperature = (((Node)nodes[Connection[0]]).Temperature + ((Node)nodes[Connection[1]]).Temperature) / 2.0;
		tLoad[0] = (0.0 - mat.CoeffOfThermalExp) * temperature * mat.Young * secArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[1] = (0.0 - mat.CoeffOfThermalExp) * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[2] = (0.0 - mat.CoeffOfThermalExp) * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Z - nodes[Connection[0]].Z);
		tLoad[3] = mat.CoeffOfThermalExp * temperature * mat.Young * secArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[4] = mat.CoeffOfThermalExp * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[5] = mat.CoeffOfThermalExp * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Z - nodes[Connection[0]].Z);
	}

	internal void _0023_003DzaXawPti23jEv(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Point3D[] vertices = new Point3D[2] { node, node2 };
		Color[] colors = new Color[2] { mat.Diffuse, mat.Diffuse };
		_0023_003DzB8iS0QA_003D.DrawLines(vertices, colors);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(context, singleColor, vertices, 8, ampFactor, secArea, mode);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(context, vertices, 8, ampFactor, secArea, mode);
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(context, vertices, 8, min, max, ampFactor, secArea, mode);
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003DzrhR_0024jny4mWKP(context, vertices, 8, min, max, ampFactor, secArea, mode);
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		throw new NotImplementedException();
	}

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		throw new NotImplementedException();
	}
}
