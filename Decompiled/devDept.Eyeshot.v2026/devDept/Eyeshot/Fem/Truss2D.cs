using System;
using System.Drawing;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Truss2D : Element2D
{
	internal readonly double secArea;

	private double temperature;

	private double L;

	private double c;

	private double s;

	private double axialLoad;

	public double AxialLoad => axialLoad;

	public Truss2D(int nodeIndex1, int nodeIndex2, Material mat, double area)
		: base(2, mat)
	{
		NumberOfGaussPoints = 1;
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		secArea = area;
		elFaces = new Face[0];
	}

	protected Truss2D(Truss2D another)
		: base(another)
	{
		secArea = another.secArea;
	}

	public override object Clone()
	{
		return new Truss2D(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemTruss2DSurrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		M = new double[4, 4];
		double num = mat.Density * secArea * L / 6.0;
		for (int i = 0; i < 4; i++)
		{
			M[i, i] = 2.0 * num;
		}
		M[2, 0] = (M[0, 2] = num);
		M[3, 1] = (M[1, 3] = num);
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		L = nodes[Connection[0]].DistanceTo(nodes[Connection[1]]);
		c = (nodes[Connection[1]].X - nodes[Connection[0]].X) / L;
		s = (nodes[Connection[1]].Y - nodes[Connection[0]].Y) / L;
		double num = c * c;
		double num2 = c * s;
		double num3 = s * s;
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		double num4 = mat.Young * secArea / L;
		K[0, 0] = (K[2, 2] = num * num4);
		K[2, 0] = (0.0 - num) * num4;
		K[1, 1] = (K[3, 3] = num3 * num4);
		K[3, 1] = (0.0 - num3) * num4;
		K[1, 0] = (K[3, 2] = num2 * num4);
		K[3, 0] = (K[2, 1] = (0.0 - num2) * num4);
		StiffnessComputation(nodes);
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		double[] array = new double[4]
		{
			0.0 - c,
			0.0 - s,
			c,
			s
		};
		double[] array2 = new double[4]
		{
			((Node)nodes[Connection[0]]).Unknowns[0][0],
			((Node)nodes[Connection[0]]).Unknowns[0][1],
			((Node)nodes[Connection[1]]).Unknowns[0][0],
			((Node)nodes[Connection[1]]).Unknowns[0][1]
		};
		double num = 0.0;
		double num2 = mat.Young / L;
		for (int i = 0; i < 4; i++)
		{
			num += num2 * array[i] * array2[i];
		}
		if (this.temperature != 0.0)
		{
			double num3 = mat.CoeffOfThermalExp * this.temperature * mat.Young;
			num -= num3;
		}
		double[,] array3 = new double[4, NumberOfNodes];
		for (int j = 0; j < 3; j++)
		{
			array3[j, 0] = num;
			array3[j, 1] = num;
		}
		axialLoad = num * secArea;
		TotalUpTheStresses(array3, numberOfElementsPerNode, nodes);
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		tLoad = new double[base.TotalDof];
		temperature = (((Node)nodes[Connection[0]]).Temperature + ((Node)nodes[Connection[1]]).Temperature) / 2.0;
		tLoad[0] = (0.0 - mat.CoeffOfThermalExp) * temperature * mat.Young * secArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[1] = (0.0 - mat.CoeffOfThermalExp) * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[2] = mat.CoeffOfThermalExp * temperature * mat.Young * secArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[3] = mat.CoeffOfThermalExp * temperature * mat.Young * secArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
	}

	internal void _0023_003DzaXawPti23jEv(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Point3D[] vertices = new Point3D[2] { node, node2 };
		Color[] colors = new Color[2] { mat.Diffuse, mat.Diffuse };
		_0023_003DzB8iS0QA_003D.DrawLines(vertices, colors);
	}

	public override void Draw(RenderContextBase renderContext, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(renderContext, singleColor, vertices, 8, ampFactor, secArea, mode);
	}

	public override void Draw(RenderContextBase renderContext, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(renderContext, vertices, 8, ampFactor, secArea, mode);
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003DzOm2z22ujB4a_0024(context, vertices, 8, min, max, ampFactor, secArea, mode);
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003DzrhR_0024jny4mWKP(context, vertices, 8, min, max, ampFactor, secArea, mode);
	}
}
