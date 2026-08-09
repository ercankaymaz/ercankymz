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
public abstract class Element2D : Element
{
	[Serializable]
	public class Edge
	{
		public byte[] Indices;

		public bool[] Restraints;

		internal double[] displacement;

		public double NormalPressure;

		public double[] Pressure;

		public Edge(byte[] indices)
		{
			Indices = indices;
		}

		internal Edge(Edge _0023_003DzySgeilxprQOK)
		{
			Indices = _0023_003DzySgeilxprQOK.Indices;
			if (_0023_003DzySgeilxprQOK.Restraints != null)
			{
				Restraints = new bool[_0023_003DzySgeilxprQOK.Restraints.Length];
				_0023_003DzySgeilxprQOK.Restraints.CopyTo(Restraints, 0);
			}
			if (_0023_003DzySgeilxprQOK.displacement != null)
			{
				displacement = new double[_0023_003DzySgeilxprQOK.displacement.Length];
				_0023_003DzySgeilxprQOK.displacement.CopyTo(displacement, 0);
			}
			NormalPressure = _0023_003DzySgeilxprQOK.NormalPressure;
			if (_0023_003DzySgeilxprQOK.Pressure != null)
			{
				Pressure = new double[_0023_003DzySgeilxprQOK.Pressure.Length];
				_0023_003DzySgeilxprQOK.Pressure.CopyTo(Pressure, 0);
			}
		}

		internal object _0023_003Dzx9P_oXY_003D()
		{
			return new Edge(this);
		}

		public virtual FemEdgeSurrogate ConvertToSurrogate()
		{
			return new FemEdgeSurrogate(this);
		}

		internal void _0023_003DzC6uJhr2aAtLiXUpnqQ_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[] _0023_003DzvXl0C1c_003D, out Vector3D _0023_003DzCJkr8nY_003D, out Point3D _0023_003DzaA_FhnNUXoi7)
		{
			Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzvXl0C1c_003D[Indices[0]]];
			Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzvXl0C1c_003D[Indices[Indices.Length - 1]]];
			_0023_003DzCJkr8nY_003D = new Vector3D(node, node2);
			_0023_003DzaA_FhnNUXoi7 = Point3D.MidPoint(node, node2);
		}
	}

	protected internal Edge[] elEdges;

	public Edge[] Edges => elEdges;

	protected Element2D(int numberOfNodes, Material mat)
		: base(numberOfNodes, mat)
	{
		NumberOfDimensions = 2;
		NumberOfDofPerNode = 2;
		switch (mat.ElementType)
		{
		case elementType.PlaneStrain:
		case elementType.PlaneStress:
			NumberOfStressesPerNode = 3;
			break;
		case elementType.Axisymmetric:
			NumberOfStressesPerNode = 4;
			break;
		}
	}

	protected Element2D(Element2D another)
		: base(another)
	{
		elEdges = new Edge[another.elEdges.Length];
		for (int i = 0; i < elEdges.Length; i++)
		{
			elEdges[i] = (Edge)another.elEdges[i]._0023_003Dzx9P_oXY_003D();
		}
	}

	public virtual void Revolve(double angle, Vector3D axis, Point3D center, int slices, FemMesh fm)
	{
	}

	public virtual void Extrude(Vector3D amount, int slices, FemMesh fm)
	{
	}

	internal List<int> _0023_003Dz_0024LLljbvl_0024PEt(int[] _0023_003DzC59vsFaKqmb_0024, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		int num = _0023_003DzC59vsFaKqmb_0024.Length;
		int num2 = num / 2;
		int num3 = num / 4;
		int[] array = new int[num + num3];
		Array.Copy(_0023_003DzC59vsFaKqmb_0024, 0, array, 0, num2);
		Array.Copy(_0023_003DzC59vsFaKqmb_0024, num2, array, num2 + num3, num2);
		int num4 = 0;
		for (int i = 0; i < num2; i += 2)
		{
			Line line = new Line(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzC59vsFaKqmb_0024[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzC59vsFaKqmb_0024[i + num2]]);
			int count = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(line.MidPoint.X, line.MidPoint.Y, line.MidPoint.Z));
			array[num2 + num4] = count;
			num4++;
		}
		return array.ToList();
	}

	protected void Jacob2(int kGauss, int elIndex, Point3D[] nodes, double[] shapeFunc, double[,] shapeFuncDeriv, out double detJacob, double[,] gaussPoints, double[,] cartDeriv)
	{
		double[,] array = new double[2, 2];
		double[,] array2 = new double[2, 2];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfNodes; j++)
			{
				int num = Connection[j];
				gaussPoints[kGauss - 1, i] += nodes[num][i] * shapeFunc[j];
			}
		}
		for (int k = 0; k < NumberOfDimensions; k++)
		{
			for (int l = 0; l < NumberOfDimensions; l++)
			{
				for (int m = 0; m < NumberOfNodes; m++)
				{
					int num2 = Connection[m];
					array[l, k] += shapeFuncDeriv[m, k] * nodes[num2][l];
				}
			}
		}
		detJacob = array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1];
		if (detJacob <= 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985172) + elIndex);
		}
		array2[0, 0] = array[1, 1] / detJacob;
		array2[1, 1] = array[0, 0] / detJacob;
		array2[1, 0] = (0.0 - array[1, 0]) / detJacob;
		array2[0, 1] = (0.0 - array[0, 1]) / detJacob;
		for (int k = 0; k < NumberOfDimensions; k++)
		{
			for (int m = 0; m < NumberOfNodes; m++)
			{
				for (int l = 0; l < NumberOfDimensions; l++)
				{
					cartDeriv[m, k] += array2[l, k] * shapeFuncDeriv[m, l];
				}
			}
		}
	}

	internal double[,] _0023_003Dz3Hkb3Pc_003D(double[,] _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D, double[] _0023_003DzYQpUmXrEvLCn, double[,] _0023_003DzC46lEgrei1pnjGTMlA_003D_003D, int _0023_003DzVXBE34Sg8kz0)
	{
		double[,] array = new double[base.TotalDof, NumberOfStressesPerNode];
		int num = 0;
		if (mat.ElementType != elementType.Axisymmetric)
		{
			for (int i = 0; i < NumberOfNodes; i++)
			{
				int num2 = num + 1;
				num = num2 + 1;
				array[num2 - 1, 0] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 0];
				array[num - 1, 0] = 0.0;
				array[num2 - 1, 1] = 0.0;
				array[num - 1, 1] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 1];
				array[num2 - 1, 2] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 1];
				array[num - 1, 2] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 0];
			}
		}
		else
		{
			for (int j = 0; j < NumberOfNodes; j++)
			{
				int num2 = num + 1;
				num = num2 + 1;
				array[num2 - 1, 0] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[j, 0];
				array[num - 1, 0] = 0.0;
				array[num2 - 1, 1] = 0.0;
				array[num - 1, 1] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[j, 1];
				array[num2 - 1, 2] = _0023_003DzYQpUmXrEvLCn[j] / _0023_003DzC46lEgrei1pnjGTMlA_003D_003D[_0023_003DzVXBE34Sg8kz0 - 1, 0];
				array[num - 1, 2] = 0.0;
				array[num2 - 1, 3] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[j, 1];
				array[num - 1, 3] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[j, 0];
			}
		}
		return array;
	}

	protected void StiffnessComputation(int kgasp, double[] shapeFuncValues, double[,] cartDeriv, double[,] gaussPoints, double dvolu, double thick)
	{
		B = _0023_003Dz3Hkb3Pc_003D(cartDeriv, shapeFuncValues, gaussPoints, kgasp);
		double[,] array = _0023_003DzwTQF9gqyciKw(mat.Matrix, B);
		if (NumberOfStressesPerNode == 3)
		{
			for (int i = 0; i < base.TotalDof; i++)
			{
				for (int j = i; j < base.TotalDof; j++)
				{
					for (int k = 0; k < NumberOfStressesPerNode; k++)
					{
						K[j, i] += B[i, k] * array[j, k] * dvolu * thick;
					}
				}
			}
		}
		else
		{
			for (int l = 0; l < base.TotalDof; l++)
			{
				for (int m = l; m < base.TotalDof; m++)
				{
					for (int n = 0; n < NumberOfStressesPerNode; n++)
					{
						K[m, l] += B[l, n] * array[m, n] * dvolu * gaussPoints[kgasp - 1, 0];
					}
				}
			}
		}
		for (int num = 0; num < NumberOfStressesPerNode; num++)
		{
			for (int num2 = 0; num2 < base.TotalDof; num2++)
			{
				StressMatrix[kgasp - 1, num2, num] = array[num2, num];
			}
		}
	}

	protected void ComputeThermalLoading(int numgp, bool temperature, double[,] strGp, double[] strsg)
	{
		if (temperature)
		{
			switch (mat.ElementType)
			{
			case elementType.PlaneStrain:
			{
				for (int j = 0; j < 3; j++)
				{
					strGp[j, numgp - 1] = strsg[j] + strin[numgp - 1, j];
				}
				strGp[3, numgp - 1] = mat.Poisson * (strGp[0, numgp - 1] + strGp[1, numgp - 1]) + strin[numgp - 1, 3];
				break;
			}
			case elementType.PlaneStress:
			case elementType.Axisymmetric:
			{
				for (int i = 0; i < NumberOfStressesPerNode; i++)
				{
					strGp[i, numgp - 1] = strsg[i] + strin[numgp - 1, i];
				}
				break;
			}
			}
			return;
		}
		switch (mat.ElementType)
		{
		case elementType.PlaneStress:
		case elementType.Axisymmetric:
		{
			for (int l = 0; l < NumberOfStressesPerNode; l++)
			{
				strGp[l, numgp - 1] = strsg[l];
			}
			break;
		}
		case elementType.PlaneStrain:
		{
			for (int k = 0; k < 3; k++)
			{
				strGp[k, numgp - 1] = strsg[k];
			}
			strGp[3, numgp - 1] = mat.Poisson * (strGp[0, numgp - 1] + strGp[1, numgp - 1]);
			break;
		}
		}
	}

	protected void TotalUpTheStresses(double[,] strNode, int[] numberOfElementsPerNode, Point3D[] nodes)
	{
		for (int i = 0; i < NumberOfNodes; i++)
		{
			int num = Connection[i];
			numberOfElementsPerNode[num]++;
			((Node)nodes[num]).Stress[0] += strNode[0, i];
			((Node)nodes[num]).Stress[1] += strNode[1, i];
			base.Stress[i, 0] = strNode[0, i];
			base.Stress[i, 1] = strNode[1, i];
			if (NumberOfStressesPerNode != 6)
			{
				switch (mat.ElementType)
				{
				case elementType.PlaneStress:
					((Node)nodes[num]).Stress[3] += strNode[2, i];
					base.Stress[i, 3] = strNode[2, i];
					break;
				case elementType.PlaneStrain:
					((Node)nodes[num]).Stress[2] += strNode[3, i];
					((Node)nodes[num]).Stress[3] += strNode[2, i];
					base.Stress[i, 2] = strNode[3, i];
					base.Stress[i, 3] = strNode[2, i];
					break;
				case elementType.Axisymmetric:
					((Node)nodes[num]).Stress[2] += strNode[2, i];
					((Node)nodes[num]).Stress[3] += strNode[3, i];
					base.Stress[i, 2] = strNode[2, i];
					base.Stress[i, 3] = strNode[3, i];
					break;
				}
			}
			else
			{
				((Node)nodes[num]).Stress[2] += strNode[2, i];
				((Node)nodes[num]).Stress[3] += strNode[3, i];
				((Node)nodes[num]).Stress[4] += strNode[4, i];
				((Node)nodes[num]).Stress[5] += strNode[5, i];
				base.Stress[i, 2] = strNode[2, i];
				base.Stress[i, 3] = strNode[3, i];
				base.Stress[i, 4] = strNode[4, i];
				base.Stress[i, 5] = strNode[5, i];
			}
			Element.CalcPrincipal(base.Stress[i, 0], base.Stress[i, 1], base.Stress[i, 2], base.Stress[i, 3], base.Stress[i, 4], base.Stress[i, 5], out base.VonMises[i], out var principal);
			if (mat.ElementType == elementType.PlaneStress && NumberOfStressesPerNode != 6)
			{
				_0023_003DzE4Mg1WoLAeiM(base.Stress[i, 0], base.Stress[i, 1], base.Stress[i, 3], principal);
			}
			base.Principals[i, 0] = principal[0];
			base.Principals[i, 1] = principal[1];
			base.Principals[i, 2] = principal[2];
		}
	}

	internal static void _0023_003DzE4Mg1WoLAeiM(double _0023_003DzOSfGTJw_003D, double _0023_003DzBexVt40_003D, double _0023_003DzrUc9Edw_003D, double[] _0023_003DzO0AO3iPnQw1B)
	{
		double num = (_0023_003DzOSfGTJw_003D + _0023_003DzBexVt40_003D) / 2.0;
		double num2 = Math.Sqrt(0.25 * (_0023_003DzOSfGTJw_003D - _0023_003DzBexVt40_003D) * (_0023_003DzOSfGTJw_003D - _0023_003DzBexVt40_003D) + _0023_003DzrUc9Edw_003D * _0023_003DzrUc9Edw_003D);
		_0023_003DzO0AO3iPnQw1B[0] = num + num2;
		_0023_003DzO0AO3iPnQw1B[1] = num - num2;
		_0023_003DzO0AO3iPnQw1B[2] = 0.0;
	}

	protected void ComputeTemp(Point3D[] nodes, double[] shapeFunc, double[,] cartDeriv, double dvolu, double[] tempLocal, int kgasp, double[,] gaussPoints)
	{
		double num = 0.0;
		for (int i = 0; i < NumberOfNodes; i++)
		{
			num += tempLocal[i] * shapeFunc[i];
		}
		double[] array = new double[4];
		switch (mat.ElementType)
		{
		case elementType.PlaneStrain:
			array[0] = (0.0 - num) * mat.CoeffOfThermalExp * (1.0 + mat.Poisson);
			array[1] = (0.0 - num) * mat.CoeffOfThermalExp * (1.0 + mat.Poisson);
			array[2] = 0.0;
			break;
		case elementType.PlaneStress:
			array[0] = (0.0 - num) * mat.CoeffOfThermalExp;
			array[1] = (0.0 - num) * mat.CoeffOfThermalExp;
			array[2] = 0.0;
			break;
		case elementType.Axisymmetric:
			array[0] = (0.0 - num) * mat.CoeffOfThermalExp;
			array[1] = (0.0 - num) * mat.CoeffOfThermalExp;
			array[2] = (0.0 - num) * mat.CoeffOfThermalExp;
			array[3] = 0.0;
			break;
		}
		double[] array2 = new double[NumberOfStressesPerNode];
		for (int j = 0; j < NumberOfStressesPerNode; j++)
		{
			for (int k = 0; k < NumberOfStressesPerNode; k++)
			{
				array2[j] += mat.Matrix[k, j] * array[k];
			}
			strin[kgasp - 1, j] = array2[j];
		}
		if (mat.ElementType == elementType.PlaneStrain)
		{
			strin[kgasp - 1, 3] = 0.0 - num * mat.CoeffOfThermalExp * mat.Young;
		}
		if (mat.ElementType == elementType.PlaneStrain)
		{
			strin[kgasp - 1, 3] = 0.0 - num * mat.CoeffOfThermalExp * mat.Young;
		}
		B = _0023_003Dz3Hkb3Pc_003D(cartDeriv, shapeFunc, gaussPoints, kgasp);
		double num2 = 1.0;
		if (mat.ElementType == elementType.Axisymmetric)
		{
			num2 = 0.0;
			for (int l = 0; l < NumberOfNodes; l++)
			{
				num2 += shapeFunc[l] * nodes[Connection[l]].X;
			}
		}
		for (int m = 0; m < NumberOfStressesPerNode; m++)
		{
			for (int n = 0; n < base.TotalDof; n++)
			{
				tLoad[n] -= B[n, m] * array2[m] * dvolu * num2;
			}
		}
	}

	internal void _0023_003DzIOeurJfZGn2VbAAjxA_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, Vector2D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
	{
		double[,] array = new double[NumberOfDimensions, elEdges[_0023_003DzL8NvYU0_003D].Indices.Length];
		array[0, 0] = _0023_003DzJvZCors_003D.Y;
		array[1, 0] = _0023_003DzJvZCors_003D.X;
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		double[] array2 = new double[2];
		array2[0] = -0.5773502588272095;
		array2[1] = 0.0 - array2[0];
		int num = 2;
		int[] array3 = new int[2]
		{
			Connection[elEdges[_0023_003DzL8NvYU0_003D].Indices[0]],
			Connection[elEdges[_0023_003DzL8NvYU0_003D].Indices[1]]
		};
		array[1, 1] = array[1, 0];
		array[0, 1] = array[0, 0];
		double[,] array4 = new double[array3.Length, NumberOfDimensions];
		for (int i = 0; i < num; i++)
		{
			int num2 = array3[i];
			array4[i, 0] = _0023_003DzDvuIQCU_003D[num2].X;
			array4[i, 1] = _0023_003DzDvuIQCU_003D[num2].Y;
		}
		double _0023_003DzNDQ_E88_003D = -1.0;
		for (int j = 0; j < 2; j++)
		{
			double _0023_003DzuwH5j5s_003D = array2[j];
			_0023_003DzKIeZvySN_0024BQ4(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzwaU_0024oWk_003D, out var _0023_003DzmB17IaV5XzRN);
			double[] array5 = new double[NumberOfDofPerNode];
			double[] array6 = new double[NumberOfDofPerNode];
			for (int k = 0; k < NumberOfDofPerNode; k++)
			{
				array5[k] = 0.0;
				array6[k] = 0.0;
				for (int l = 0; l < num; l++)
				{
					array5[k] += array[k, l] * _0023_003DzwaU_0024oWk_003D[l];
					array6[k] += array4[l, k] * _0023_003DzmB17IaV5XzRN[l, 0];
				}
			}
			double num3 = 1.0;
			double num4 = array6[0] * array5[1] - array6[1] * array5[0];
			double num5 = array6[0] * array5[0] + array6[1] * array5[1];
			int m;
			for (m = 0; m <= NumberOfNodes - 1 && Connection[m] != array3[0]; m++)
			{
			}
			int num6 = m + num - 1;
			int num7 = 0;
			int num8 = 0;
			for (int n = m; n <= num6; n++)
			{
				num7++;
				int num9 = n * NumberOfDofPerNode + 1;
				int num10 = n * NumberOfDofPerNode + 2;
				if (n >= NumberOfNodes)
				{
					num9 = 1;
				}
				if (n >= NumberOfNodes)
				{
					num10 = 2;
				}
				if (NumberOfStressesPerNode == 3)
				{
					distLoad[num9 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num4 * num3;
					distLoad[num10 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num5 * num3;
				}
				else
				{
					num8++;
					distLoad[num9 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num4 * num3 * array4[num8 - 1, 0];
					distLoad[num10 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num5 * num3 * array4[num8 - 1, 0];
				}
			}
		}
	}

	internal void _0023_003DzjB34KOs19_0024U0(Point3D[] _0023_003DzDvuIQCU_003D, Vector2D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
	{
		double[,] array = new double[NumberOfDimensions, elEdges[_0023_003DzL8NvYU0_003D].Indices.Length];
		array[0, 0] = _0023_003DzJvZCors_003D.Y;
		array[1, 0] = _0023_003DzJvZCors_003D.X;
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		double[] array2 = new double[2];
		array2[0] = -0.5773502588272095;
		array2[1] = 0.0 - array2[0];
		int num = 3;
		int[] array3 = new int[3]
		{
			Connection[elEdges[_0023_003DzL8NvYU0_003D].Indices[0]],
			Connection[elEdges[_0023_003DzL8NvYU0_003D].Indices[1]],
			Connection[elEdges[_0023_003DzL8NvYU0_003D].Indices[2]]
		};
		array[1, 1] = array[1, 0];
		array[1, 2] = array[1, 0];
		array[0, 1] = array[0, 0];
		array[0, 2] = array[0, 0];
		double[,] array4 = new double[array3.Length, NumberOfDimensions];
		for (int i = 0; i < num; i++)
		{
			int num2 = array3[i];
			array4[i, 0] = _0023_003DzDvuIQCU_003D[num2].X;
			array4[i, 1] = _0023_003DzDvuIQCU_003D[num2].Y;
		}
		double _0023_003DzNDQ_E88_003D = -1.0;
		for (int j = 0; j < 2; j++)
		{
			double _0023_003DzuwH5j5s_003D = array2[j];
			_0023_003DzvjFPku3sVc_e(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzwaU_0024oWk_003D, out var _0023_003DzmB17IaV5XzRN);
			double[] array5 = new double[NumberOfDofPerNode];
			double[] array6 = new double[NumberOfDofPerNode];
			for (int k = 0; k < NumberOfDofPerNode; k++)
			{
				array5[k] = 0.0;
				array6[k] = 0.0;
				for (int l = 0; l < num; l++)
				{
					array5[k] += array[k, l] * _0023_003DzwaU_0024oWk_003D[l];
					array6[k] += array4[l, k] * _0023_003DzmB17IaV5XzRN[l, 0];
				}
			}
			double num3 = 1.0;
			double num4 = array6[0] * array5[1] - array6[1] * array5[0];
			double num5 = array6[0] * array5[0] + array6[1] * array5[1];
			int m;
			for (m = 0; m < NumberOfNodes && Connection[m] != array3[0]; m++)
			{
			}
			int num6 = m + num - 1;
			int num7 = 0;
			int num8 = 0;
			for (int n = m; n <= num6; n++)
			{
				num7++;
				int num9 = n * NumberOfDofPerNode + 1;
				int num10 = n * NumberOfDofPerNode + 2;
				if (n >= NumberOfNodes)
				{
					num9 = 1;
				}
				if (n >= NumberOfNodes)
				{
					num10 = 2;
				}
				if (NumberOfStressesPerNode == 3)
				{
					distLoad[num9 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num4 * num3;
					distLoad[num10 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num5 * num3;
				}
				else
				{
					num8++;
					distLoad[num9 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num4 * num3 * array4[num8 - 1, 0];
					distLoad[num10 - 1] += _0023_003DzwaU_0024oWk_003D[num7 - 1] * num5 * num3 * array4[num8 - 1, 0];
				}
			}
		}
	}

	private void _0023_003DzKIeZvySN_0024BQ4(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, out double[] _0023_003DzwaU_0024oWk_003D, out double[,] _0023_003DzmB17IaV5XzRN)
	{
		if (NumberOfNodes == 4)
		{
			_0023_003DzwaU_0024oWk_003D = new double[4];
			_0023_003DzmB17IaV5XzRN = new double[4, 2];
			_0023_003DzwaU_0024oWk_003D[0] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzwaU_0024oWk_003D[1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzwaU_0024oWk_003D[2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzwaU_0024oWk_003D[3] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[0, 0] = 0.0 - (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 0] = (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[2, 0] = (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[3, 0] = 0.0 - (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[0, 1] = 0.0 - (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 1] = 0.0 - (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[2, 1] = (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[3, 1] = (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
		}
		else
		{
			_0023_003DzwaU_0024oWk_003D = new double[3];
			_0023_003DzmB17IaV5XzRN = new double[3, 2];
			_0023_003DzwaU_0024oWk_003D[0] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzwaU_0024oWk_003D[1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzwaU_0024oWk_003D[2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[0, 0] = 0.0 - (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 0] = (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[2, 0] = (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[0, 1] = 0.0 - (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 1] = 0.0 - (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
			_0023_003DzmB17IaV5XzRN[2, 1] = (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
		}
	}

	private void _0023_003DzvjFPku3sVc_e(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, out double[] _0023_003DzwaU_0024oWk_003D, out double[,] _0023_003DzmB17IaV5XzRN)
	{
		if (NumberOfNodes == 8)
		{
			_0023_003DzwaU_0024oWk_003D = new double[8];
			_0023_003DzmB17IaV5XzRN = new double[8, 2];
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
		else
		{
			_0023_003DzwaU_0024oWk_003D = new double[6];
			_0023_003DzmB17IaV5XzRN = new double[6, 2];
			double num9 = _0023_003DzuwH5j5s_003D * 2.0;
			double num10 = _0023_003DzNDQ_E88_003D * 2.0;
			double num11 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D;
			double num12 = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
			double num13 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
			double num14 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
			double num15 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
			double num16 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * 2.0;
			_0023_003DzwaU_0024oWk_003D[0] = (-1.0 + num13 + num11 + num12 - num14 - num15) / 4.0;
			_0023_003DzwaU_0024oWk_003D[1] = (1.0 - _0023_003DzNDQ_E88_003D - num11 + num14) / 2.0;
			_0023_003DzwaU_0024oWk_003D[2] = (-1.0 - num13 + num11 + num12 - num14 + num15) / 4.0;
			_0023_003DzwaU_0024oWk_003D[3] = (1.0 + _0023_003DzuwH5j5s_003D - num12 - num15) / 2.0;
			_0023_003DzwaU_0024oWk_003D[4] = (-1.0 + num13 + num11 + num12 + num14 + num15) / 4.0;
			_0023_003DzwaU_0024oWk_003D[5] = (1.0 + _0023_003DzNDQ_E88_003D - num11 - num14) / 2.0;
			_0023_003DzmB17IaV5XzRN[0, 0] = (_0023_003DzNDQ_E88_003D + num9 - num16 - num12) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 0] = 0.0 - _0023_003DzuwH5j5s_003D + num13;
			_0023_003DzmB17IaV5XzRN[2, 0] = (0.0 - _0023_003DzNDQ_E88_003D + num9 - num16 + num12) / 4.0;
			_0023_003DzmB17IaV5XzRN[3, 0] = (1.0 - num12) / 2.0;
			_0023_003DzmB17IaV5XzRN[4, 0] = (_0023_003DzNDQ_E88_003D + num9 + num16 + num12) / 4.0;
			_0023_003DzmB17IaV5XzRN[5, 0] = 0.0 - _0023_003DzuwH5j5s_003D - num13;
			_0023_003DzmB17IaV5XzRN[0, 1] = (_0023_003DzuwH5j5s_003D + num10 - num11 - num16) / 4.0;
			_0023_003DzmB17IaV5XzRN[1, 1] = (-1.0 + num11) / 2.0;
			_0023_003DzmB17IaV5XzRN[2, 1] = (0.0 - _0023_003DzuwH5j5s_003D + num10 - num11 + num16) / 4.0;
			_0023_003DzmB17IaV5XzRN[3, 1] = 0.0 - _0023_003DzNDQ_E88_003D - num13;
			_0023_003DzmB17IaV5XzRN[4, 1] = (_0023_003DzuwH5j5s_003D + num10 + num11 + num16) / 4.0;
			_0023_003DzmB17IaV5XzRN[5, 1] = (1.0 - num11) / 2.0;
		}
	}

	internal static Vector2D _0023_003DzTYQj7dTpRcf3AB30m3Ejgzk_003D(Vector2D _0023_003DzSi0fJ0kEgr24, Vector2D _0023_003DzTx2aqr8_003D)
	{
		_0023_003DzTx2aqr8_003D.Normalize();
		double length = _0023_003DzSi0fJ0kEgr24.Length;
		_0023_003DzSi0fJ0kEgr24.Normalize();
		double num = Vector2D.SignedAngleBetween(_0023_003DzTx2aqr8_003D, _0023_003DzSi0fJ0kEgr24);
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		if (Utility.AreEqual(0.0, num2, Math.PI * 2.0))
		{
			if (num3 > 0.0)
			{
				return new Vector2D(0.0, length);
			}
			return new Vector2D(0.0, 0.0 - length);
		}
		double y = length * num3;
		return new Vector2D(length * num2, y);
	}

	public override void FixEdgeFace(int edgeIndex, bool alongX, bool alongY, bool alongZ)
	{
		if (elEdges[edgeIndex].Restraints == null)
		{
			elEdges[edgeIndex].Restraints = new bool[2] { alongX, alongY };
			elEdges[edgeIndex].displacement = new double[2];
		}
		else
		{
			elEdges[edgeIndex].Restraints[0] |= alongX;
			elEdges[edgeIndex].Restraints[1] |= alongY;
		}
	}

	public override void FixAllEdgeFace(int edgeIndex)
	{
		elEdges[edgeIndex].Restraints = new bool[2] { true, true };
		elEdges[edgeIndex].displacement = new double[2];
	}

	public override void SetRestraintEdgeFace(int edgeIndex, bool alongX, bool alongY, bool alongZ, double amountInX, double amountInY, double amountInZ)
	{
		if (elEdges[edgeIndex].Restraints == null)
		{
			elEdges[edgeIndex].Restraints = new bool[2] { alongX, alongY };
			elEdges[edgeIndex].displacement = new double[2] { amountInX, amountInY };
		}
		else
		{
			elEdges[edgeIndex].Restraints[0] |= alongX;
			elEdges[edgeIndex].Restraints[1] |= alongY;
			elEdges[edgeIndex].displacement[0] += amountInX;
			elEdges[edgeIndex].displacement[1] += amountInY;
		}
	}

	public override void SetRestraintEdgeFaceInX(int edgeIndex, double amountInX)
	{
		if (elEdges[edgeIndex].Restraints == null)
		{
			elEdges[edgeIndex].Restraints = new bool[2] { true, false };
			elEdges[edgeIndex].displacement = new double[2] { amountInX, 0.0 };
		}
		else
		{
			elEdges[edgeIndex].Restraints[0] = true;
			elEdges[edgeIndex].displacement[0] += amountInX;
		}
	}

	public override void SetRestraintEdgeFaceInY(int edgeIndex, double amountInY)
	{
		if (elEdges[edgeIndex].Restraints == null)
		{
			elEdges[edgeIndex].Restraints = new bool[2] { false, true };
			elEdges[edgeIndex].displacement = new double[2] { 0.0, amountInY };
		}
		else
		{
			elEdges[edgeIndex].Restraints[1] = true;
			elEdges[edgeIndex].displacement[1] += amountInY;
		}
	}

	internal Node _0023_003DzUO3ZY9Q_003D(byte _0023_003DzAdg8iZA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		return (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[_0023_003DzAdg8iZA_003D]];
	}

	internal double _0023_003Dzu0ZuQ_ZWhLdl5P_KFCYkF7U_003D(byte _0023_003DzAdg8iZA_003D, byte _0023_003DzVzS_0024neo_003D)
	{
		return base.Stress[_0023_003DzAdg8iZA_003D, _0023_003DzVzS_0024neo_003D];
	}

	protected void DrawFace3(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		Node node = (Node)vertices[Connection[0]];
		Node node2 = (Node)vertices[Connection[1]];
		Node node3 = (Node)vertices[Connection[2]];
		context.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { node, node2, node3 }, new Vector3D[3] { singleNormal, singleNormal, singleNormal }, singleColor, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFace3(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Node node = (Node)vertices[Connection[0]];
		Node node2 = (Node)vertices[Connection[1]];
		Node node3 = (Node)vertices[Connection[2]];
		context.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { node, node2, node3 }, new Vector3D[3] { singleNormal, singleNormal, singleNormal }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(node.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node2.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node3.PlotValue, min, max)
		}, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFaceElement3(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		int num = Connection[0];
		int num2 = Connection[1];
		int num3 = Connection[2];
		Node node = (Node)vertices[num];
		Node node2 = (Node)vertices[num2];
		Node node3 = (Node)vertices[num3];
		context.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { node, node2, node3 }, new Vector3D[3] { singleNormal, singleNormal, singleNormal }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(base.PlotValues[0], min, max),
			Utility._0023_003DzbV1eOjg_003D(base.PlotValues[1], min, max),
			Utility._0023_003DzbV1eOjg_003D(base.PlotValues[2], min, max)
		}, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFace4(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace4(context, singleNormal, vertices, singleColor, ampFactor, mode);
	}

	protected void DrawFace4(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		Node node = (Node)vertices[Connection[0]];
		Node node2 = (Node)vertices[Connection[1]];
		Node node3 = (Node)vertices[Connection[2]];
		Node node4 = (Node)vertices[Connection[3]];
		context.DrawTrianglesWithDisplacement(new PointWithDisplacement[6] { node, node2, node3, node, node3, node4 }, new Vector3D[6] { singleNormal, singleNormal, singleNormal, singleNormal, singleNormal, singleNormal }, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFace4(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, Color singleColor, double ampFactor, int mode)
	{
		Node node = (Node)vertices[Connection[0]];
		Node node2 = (Node)vertices[Connection[1]];
		Node node3 = (Node)vertices[Connection[2]];
		Node node4 = (Node)vertices[Connection[3]];
		context.DrawTrianglesWithDisplacement(new PointWithDisplacement[6] { node, node2, node3, node, node3, node4 }, new Vector3D[6] { singleNormal, singleNormal, singleNormal, singleNormal, singleNormal, singleNormal }, singleColor, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFace4(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Node node = (Node)vertices[Connection[0]];
		Node node2 = (Node)vertices[Connection[1]];
		Node node3 = (Node)vertices[Connection[2]];
		Node node4 = (Node)vertices[Connection[3]];
		PointWithDisplacement[] vertices2 = new PointWithDisplacement[6] { node, node2, node3, node, node3, node4 };
		Vector3D[] normals = new Vector3D[6] { singleNormal, singleNormal, singleNormal, singleNormal, singleNormal, singleNormal };
		context.DrawTrianglesWithDisplacement(vertices2, normals, new float[6]
		{
			Utility._0023_003DzbV1eOjg_003D(node.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node2.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node3.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node3.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node4.PlotValue, min, max)
		}, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFaceElement4(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		int num = Connection[0];
		int num2 = Connection[1];
		int num3 = Connection[2];
		int num4 = Connection[3];
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[num];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[num2];
		Node node = (Node)vertices[num3];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[num4];
		_0023_003DzOtt2oBpNBc1J(context, singleNormal, base.PlotValues[0], base.PlotValues[1], base.PlotValues[2], _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, node, min, max, ampFactor, mode);
		_0023_003DzOtt2oBpNBc1J(context, singleNormal, base.PlotValues[0], base.PlotValues[2], base.PlotValues[3], _0023_003Dz0wAkCmM_003D, node, _0023_003Dz5cbO6Ls_003D, min, max, ampFactor, mode);
	}

	internal Mesh _0023_003Dz5Ue9HStbPvpr(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Node node3 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[2]];
		Mesh mesh = new Mesh(Mesh.natureType.Plain);
		mesh.Vertices = new Point3D[3];
		mesh.Vertices[0] = new Point3D(node.X + node.Unknowns[_0023_003DznXXM9vk_003D][0] * _0023_003DzXGmnJb5mDXOU, node.Y + node.Unknowns[_0023_003DznXXM9vk_003D][1] * _0023_003DzXGmnJb5mDXOU, node.Z + node.Unknowns[_0023_003DznXXM9vk_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Vertices[1] = new Point3D(node2.X + node2.Unknowns[_0023_003DznXXM9vk_003D][0] * _0023_003DzXGmnJb5mDXOU, node2.Y + node2.Unknowns[_0023_003DznXXM9vk_003D][1] * _0023_003DzXGmnJb5mDXOU, node2.Z + node2.Unknowns[_0023_003DznXXM9vk_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Vertices[2] = new Point3D(node3.X + node3.Unknowns[_0023_003DznXXM9vk_003D][0] * _0023_003DzXGmnJb5mDXOU, node3.Y + node3.Unknowns[_0023_003DznXXM9vk_003D][1] * _0023_003DzXGmnJb5mDXOU, node3.Z + node3.Unknowns[_0023_003DznXXM9vk_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Triangles = new IndexTriangle[1];
		_0023_003DzKX9_h2E_003D(0, 0, 1, 2, mesh);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = mat.Diffuse;
		return mesh;
	}

	internal Mesh _0023_003DzZW9DcFCFIKzt(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003Dzg9C1BOA_003D)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Node node3 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[2]];
		Node node4 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[3]];
		Mesh mesh = new Mesh(Mesh.natureType.Plain);
		mesh.Vertices = new Point3D[4];
		mesh.Vertices[0] = new Point3D(node.X + node.Unknowns[_0023_003Dzg9C1BOA_003D][0] * _0023_003DzXGmnJb5mDXOU, node.Y + node.Unknowns[_0023_003Dzg9C1BOA_003D][1] * _0023_003DzXGmnJb5mDXOU, node.Z + node.Unknowns[_0023_003Dzg9C1BOA_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Vertices[1] = new Point3D(node2.X + node2.Unknowns[_0023_003Dzg9C1BOA_003D][0] * _0023_003DzXGmnJb5mDXOU, node2.Y + node2.Unknowns[_0023_003Dzg9C1BOA_003D][1] * _0023_003DzXGmnJb5mDXOU, node2.Z + node2.Unknowns[_0023_003Dzg9C1BOA_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Vertices[2] = new Point3D(node3.X + node3.Unknowns[_0023_003Dzg9C1BOA_003D][0] * _0023_003DzXGmnJb5mDXOU, node3.Y + node3.Unknowns[_0023_003Dzg9C1BOA_003D][1] * _0023_003DzXGmnJb5mDXOU, node3.Z + node3.Unknowns[_0023_003Dzg9C1BOA_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Vertices[3] = new Point3D(node4.X + node4.Unknowns[_0023_003Dzg9C1BOA_003D][0] * _0023_003DzXGmnJb5mDXOU, node4.Y + node4.Unknowns[_0023_003Dzg9C1BOA_003D][1] * _0023_003DzXGmnJb5mDXOU, node4.Z + node4.Unknowns[_0023_003Dzg9C1BOA_003D][2] * _0023_003DzXGmnJb5mDXOU);
		mesh.Triangles = new IndexTriangle[2];
		_0023_003DzKX9_h2E_003D(0, 0, 1, 2, mesh);
		_0023_003DzKX9_h2E_003D(1, 0, 2, 3, mesh);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = mat.Diffuse;
		return mesh;
	}

	private static void _0023_003DzOtt2oBpNBc1J(RenderContextBase _0023_003DzB8iS0QA_003D, Vector3D _0023_003DzSJ5J1_uojj_s, double _0023_003DzffqPLNQ_003D, double _0023_003Dz5Azd7L8_003D, double _0023_003DzZe6oCrQ_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzSJ5J1_uojj_s, _0023_003DzSJ5J1_uojj_s, _0023_003DzSJ5J1_uojj_s }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(_0023_003DzffqPLNQ_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz5Azd7L8_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003DzZe6oCrQ_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D)
		}, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}

	private static void _0023_003DzQhddrIGPdy0i(RenderContextBase _0023_003DzB8iS0QA_003D, Vector3D _0023_003DzSJ5J1_uojj_s, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzSJ5J1_uojj_s, _0023_003DzSJ5J1_uojj_s, _0023_003DzSJ5J1_uojj_s }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz0wAkCmM_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz_0024eRdUwQ_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz5cbO6Ls_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D)
		}, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}
}
