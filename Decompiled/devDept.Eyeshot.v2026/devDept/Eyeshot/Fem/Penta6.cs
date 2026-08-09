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
public class Penta6 : Element3D
{
	public Penta6(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, Material mat)
		: this(new int[6] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6 }, mat)
	{
	}

	public Penta6(IEnumerable<int> nodeIndices, Material mat)
		: base(6, mat)
	{
		NumberOfGaussPoints = 6;
		Connection = new int[NumberOfNodes];
		Connection = nodeIndices.ToArray();
		elFaces = new Face[5]
		{
			new Face(new byte[3] { 0, 2, 1 }),
			new Face(new byte[4] { 0, 1, 4, 3 }),
			new Face(new byte[4] { 1, 2, 5, 4 }),
			new Face(new byte[4] { 2, 0, 3, 5 }),
			new Face(new byte[3] { 3, 4, 5 })
		};
	}

	protected Penta6(Penta6 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Penta6(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemPenta6Surrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		M = new double[base.TotalDof, base.TotalDof];
		GaussQuadrature(out var _, out var _);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		double _0023_003DzRpXgovo_003D = 0.0;
		for (int i = 1; i <= 6; i++)
		{
			int kGauss = i;
			switch (i)
			{
			case 1:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 3:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 4:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 5:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 6:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			}
			_0023_003Dzp1lKOkVGnslt(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(kGauss, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * (1.0 / 3.0) * 0.5;
			AssembleMassMatrix(array, dVolume);
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		GaussQuadrature(out var _, out var _);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DziMjqlCo_003D = 0.0;
		double _0023_003DzI4dRPW0_003D = 0.0;
		double _0023_003DzYEhafAA_003D = 0.0;
		double _0023_003DzRpXgovo_003D = 0.0;
		for (int i = 1; i <= 6; i++)
		{
			int num = i;
			switch (i)
			{
			case 1:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 3:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 4:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 5:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 6:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			}
			_0023_003Dzp1lKOkVGnslt(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * (1.0 / 3.0) * 0.5;
			StiffnessComputation(num, cartDeriv, dvolu);
		}
		StiffnessComputation(nodes);
	}

	private void _0023_003Dzp1lKOkVGnslt(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double _0023_003DzRpXgovo_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		double[,] array = new double[6, 4];
		_0023_003DzwaU_0024oWk_003D[0] = 0.5 * _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[1] = 0.5 * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[2] = 0.5 * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[3] = 0.5 * _0023_003DziMjqlCo_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[4] = 0.5 * _0023_003DzI4dRPW0_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[5] = 0.5 * _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D);
		array[0, 0] = 0.5 * (1.0 - _0023_003DzRpXgovo_003D);
		array[1, 1] = 0.5 * (1.0 - _0023_003DzRpXgovo_003D);
		array[2, 2] = 0.5 * (1.0 - _0023_003DzRpXgovo_003D);
		array[3, 0] = 0.5 * (1.0 + _0023_003DzRpXgovo_003D);
		array[4, 1] = 0.5 * (1.0 + _0023_003DzRpXgovo_003D);
		array[5, 2] = 0.5 * (1.0 + _0023_003DzRpXgovo_003D);
		array[0, 3] = 0.0 - 0.5 * _0023_003DziMjqlCo_003D;
		array[1, 3] = 0.0 - 0.5 * _0023_003DzI4dRPW0_003D;
		array[2, 3] = 0.0 - 0.5 * _0023_003DzYEhafAA_003D;
		array[3, 3] = 0.5 * _0023_003DziMjqlCo_003D;
		array[4, 3] = 0.5 * _0023_003DzI4dRPW0_003D;
		array[5, 3] = 0.5 * _0023_003DzYEhafAA_003D;
		for (int i = 0; i < 6; i++)
		{
			_0023_003DzmB17IaV5XzRN[i, 0] = array[i, 0] - array[i, 2];
			_0023_003DzmB17IaV5XzRN[i, 1] = array[i, 1] - array[i, 2];
			_0023_003DzmB17IaV5XzRN[i, 2] = array[i, 3];
		}
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		int num = 0;
		int num2 = 0;
		double[,] array = new double[NumberOfStressesPerNode, NumberOfNodes];
		for (int i = 1; i <= 6; i++)
		{
			num2++;
			num++;
			double[] strsg = ComputeCartesianStressAtSamplingPoint(num, nodes);
			ComputeThermalLoading(num2, temperature, array, strsg);
		}
		double[,] array2 = new double[NumberOfStressesPerNode, NumberOfNodes];
		for (int j = 0; j < 6; j++)
		{
			double num3 = 0.0 - 0.8660254037844384 * (array[j, 3] - array[j, 0]) + (array[j, 0] + array[j, 3]) / 2.0;
			double num4 = 0.0 - 0.8660254037844384 * (array[j, 4] - array[j, 1]) + (array[j, 1] + array[j, 4]) / 2.0;
			double num5 = 0.0 - 0.8660254037844384 * (array[j, 5] - array[j, 2]) + (array[j, 2] + array[j, 5]) / 2.0;
			double num6 = 0.8660254037844384 * (array[j, 3] - array[j, 0]) + (array[j, 0] + array[j, 3]) / 2.0;
			double num7 = 0.8660254037844384 * (array[j, 4] - array[j, 1]) + (array[j, 1] + array[j, 4]) / 2.0;
			double num8 = 0.8660254037844384 * (array[j, 5] - array[j, 2]) + (array[j, 2] + array[j, 5]) / 2.0;
			array2[j, 0] = num3 + num5 - num4;
			array2[j, 1] = num3 + num4 - num5;
			array2[j, 2] = num4 + num5 - num3;
			array2[j, 3] = num6 + num8 - num7;
			array2[j, 4] = num6 + num7 - num8;
			array2[j, 5] = num7 + num8 - num6;
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
		double _0023_003DzRpXgovo_003D = 0.0;
		for (int j = 1; j <= 6; j++)
		{
			int num = j;
			switch (j)
			{
			case 1:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 2:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 3:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = -0.577350269189626;
				break;
			case 4:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.0;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 5:
				_0023_003DziMjqlCo_003D = 0.0;
				_0023_003DzI4dRPW0_003D = 0.5;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			case 6:
				_0023_003DziMjqlCo_003D = 0.5;
				_0023_003DzI4dRPW0_003D = 0.0;
				_0023_003DzYEhafAA_003D = 0.5;
				_0023_003DzRpXgovo_003D = 0.577350269189626;
				break;
			}
			_0023_003Dzp1lKOkVGnslt(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array2, array3);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * (1.0 / 3.0) * 0.5;
			ComputeTemp(array, array2, num, cartDeriv, dvolu);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFace3(context, singleColor, 0, vertices, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, singleColor, i, vertices, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace3(context, singleColor, 4, vertices, ampFactor, mode);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFace3(context, 0, vertices, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, i, vertices, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace3(context, 4, vertices, ampFactor, mode);
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFace3(context, 0, vertices, min, max, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace4(context, i, vertices, min, max, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace3(context, 4, vertices, min, max, ampFactor, mode);
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFaceElement3(context, 0, vertices, min, max, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFaceElement4(context, i, vertices, min, max, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFaceElement3(context, 4, vertices, min, max, ampFactor, mode);
		}
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		List<IndexTriangle> list = new List<IndexTriangle>();
		if (elFaces[0].Visible)
		{
			list.AddRange(GetFace3(elIndex, 0, vertices, ampFactor, centroids));
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				list.AddRange(GetFace4(elIndex, i, vertices, ampFactor, centroids));
			}
		}
		if (elFaces[4].Visible)
		{
			list.AddRange(GetFace3(elIndex, 4, vertices, ampFactor, centroids));
		}
		return list.ToArray();
	}

	public override void SetPressure(int faceIndex, Vector3D pressure, Point3D[] nodes)
	{
		double length = pressure.Length;
		if (!(length > 1E-12))
		{
			return;
		}
		Vector3D vector3D = (Vector3D)pressure.Clone();
		vector3D.Normalize();
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(0.0, 0.0, length);
		double[] array = null;
		if (distLoad != null)
		{
			array = distLoad;
		}
		_0023_003DzRCHXC0lb1Zfn(nodes, _0023_003DzJvZCors_003D, faceIndex);
		if (array != null)
		{
			int num = distLoad.Length;
			double[] array2 = new double[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = array[i] - distLoad[i];
			}
			Element3D._0023_003DzqPQh4udtQiJJVOnZXXL0JnWywA39(array2, vector3D, elFaces[faceIndex].Indices);
			for (int j = 0; j < num; j++)
			{
				distLoad[j] = array[j] + array2[j];
			}
		}
		else
		{
			Element3D._0023_003DzqPQh4udtQiJJVOnZXXL0JnWywA39(distLoad, vector3D, elFaces[faceIndex].Indices);
		}
		base.SetPressure(faceIndex, pressure, nodes);
	}

	public override void SetPressure(int faceIndex, double pressure, Point3D[] nodes)
	{
		Vector3D _0023_003DzJvZCors_003D = new Vector3D(0.0, 0.0, 0.0 - pressure);
		_0023_003DzRCHXC0lb1Zfn(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	internal void _0023_003DzRCHXC0lb1Zfn(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
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
		bool flag = false;
		int[] array3;
		if (_0023_003DzL8NvYU0_003D == 0 || _0023_003DzL8NvYU0_003D == 4)
		{
			flag = true;
			array3 = new int[3];
			for (int k = 0; k < 3; k++)
			{
				array3[k] = elFaces[_0023_003DzL8NvYU0_003D].Indices[k];
			}
		}
		else
		{
			array3 = new int[4];
			for (int l = 0; l < 4; l++)
			{
				array3[l] = elFaces[_0023_003DzL8NvYU0_003D].Indices[l];
			}
		}
		if (flag)
		{
			for (int m = 1; m <= 3; m++)
			{
				double _0023_003DziMjqlCo_003D;
				double _0023_003DzI4dRPW0_003D;
				double _0023_003DzYEhafAA_003D;
				switch (m)
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
				_0023_003DzJu_9h_0024282FVIbKOjmQ_003D_003D(_0023_003DzwaU_0024oWk_003D, array2, _0023_003DzmB17IaV5XzRN, array, array3);
			}
			return;
		}
		double[] array4 = new double[2] { -0.577350269189626, 0.577350269189626 };
		for (int n = 1; n <= 2; n++)
		{
			for (int num2 = 0; num2 < 2; num2++)
			{
				double _0023_003DzuwH5j5s_003D = array4[n - 1];
				double _0023_003DzNDQ_E88_003D = array4[num2];
				_0023_003Dzyia2av_0024QpCT3_g6A7A_003D_003D(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzKjjYWhJTvaT_0024, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D);
				_0023_003Dz64ORJv9Aw3SuQhHOaw_003D_003D(_0023_003DzKjjYWhJTvaT_0024, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, array, array3);
			}
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		List<int> list2 = new List<int>();
		int num = Connection.Length;
		_0023_003DzK8EDfQ5Yw71v(r, fm, list2, list);
		int[] array = new int[3];
		for (int i = 0; i <= r; i++)
		{
			Array.Copy(list2.ToArray(), 3 * i, array, 0, 3);
			for (int j = 0; j < array.Length; j++)
			{
				Segment3D segment3D = ((j != 2) ? new Segment3D(list[array[j]], list[array[j + 1]]) : new Segment3D(list[array[j]], list[array[0]]));
				int count = list.Count;
				list2.Add(count);
				list.Add((Node)list[array[j]].Clone());
				list2.Add(list.Count);
				list.Add(new Node(segment3D.MidPoint.X, segment3D.MidPoint.Y, segment3D.MidPoint.Z));
			}
		}
		List<Element> list3 = new List<Element>();
		list3.AddRange(fm.elements);
		for (int k = 0; k < r; k++)
		{
			Penta6 item = new Penta6(list2[9 + k * num], list2[10 + k * num], list2[14 + k * num], list2[15 + k * num], list2[16 + k * num], list2[20 + k * num], base.Material);
			Penta6 item2 = new Penta6(list2[10 + k * num], list2[12 + k * num], list2[14 + k * num], list2[16 + k * num], list2[18 + k * num], list2[20 + k * num], base.Material);
			Penta6 item3 = new Penta6(list2[10 + k * num], list2[11 + k * num], list2[12 + k * num], list2[16 + k * num], list2[17 + k * num], list2[18 + k * num], base.Material);
			Penta6 item4 = new Penta6(list2[14 + k * num], list2[12 + k * num], list2[13 + k * num], list2[20 + k * num], list2[18 + k * num], list2[19 + k * num], base.Material);
			list3.Add(item);
			list3.Add(item2);
			list3.Add(item3);
			list3.Add(item4);
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list3.ToArray();
	}

	private void _0023_003DzK8EDfQ5Yw71v(int _0023_003DzRpXgovo_003D, FemMesh _0023_003Dzkx0ud14_003D, List<int> _0023_003DzGoWUA5Q_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		Segment3D segment3D = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[0]], _0023_003Dzkx0ud14_003D.Vertices[Connection[3]]);
		Segment3D segment3D2 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[1]], _0023_003Dzkx0ud14_003D.Vertices[Connection[4]]);
		Segment3D segment3D3 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[2]], _0023_003Dzkx0ud14_003D.Vertices[Connection[5]]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[0]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[1]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[2]);
		for (int i = 1; i < _0023_003DzRpXgovo_003D; i++)
		{
			Point3D point3D = segment3D.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D3 = segment3D3.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
		}
		_0023_003DzGoWUA5Q_003D.Add(Connection[3]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[4]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[5]);
	}

	internal Penta15 _0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		return _0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(_0023_003DzDvuIQCU_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
	}

	internal static Penta15 _0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>(3);
		for (int i = 0; i < _0023_003DzDvuIQCU_003D.Length; i++)
		{
			list.Add(_0023_003DzDvuIQCU_003D[i]);
			Segment3D segment3D = i switch
			{
				2 => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[0]]), 
				5 => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[3]]), 
				_ => new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 1]]), 
			};
			Node item = new Node(segment3D.MidPoint.X, segment3D.MidPoint.Y, segment3D.MidPoint.Z);
			list.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item);
			if (i <= 2)
			{
				Segment3D segment3D2 = new Segment3D(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 3]]);
				Node item2 = new Node(segment3D2.MidPoint.X, segment3D2.MidPoint.Y, segment3D2.MidPoint.Z);
				list2.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item2);
			}
			if (i == 2)
			{
				list.AddRange(list2);
			}
		}
		return new Penta15(list, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D);
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
			case 2:
			{
				point3D = vertices[Connection[0]];
				PointSection p4 = new PointSection(point3D.X, point3D.Y, point3D.Z, ((Node)point3D).PlotValue);
				segment3D = new Segment3D(p, p4);
				break;
			}
			case 5:
			{
				point3D = vertices[Connection[3]];
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
			if (i <= 2)
			{
				point3D = vertices[Connection[i + 3]];
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
