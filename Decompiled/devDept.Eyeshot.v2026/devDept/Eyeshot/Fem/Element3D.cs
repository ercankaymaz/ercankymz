using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Fem;

[Serializable]
public abstract class Element3D : Element
{
	protected Element3D(int numberOfNodes, Material mat)
		: base(numberOfNodes, mat)
	{
		NumberOfDimensions = 3;
		NumberOfDofPerNode = 3;
		NumberOfStressesPerNode = 6;
	}

	protected Element3D(Element3D another)
		: base(another)
	{
	}

	protected void Jacob3(int kGauss, int elIndex, Point3D[] nodes, double[] shapeFunc, double[,] shapeFuncDeriv, out double detJacob, double[,] gaussPoints, double[,] cartDeriv)
	{
		double[,] array = new double[3, 3];
		double[,] array2 = new double[3, 3];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfNodes; j++)
			{
				int num = Connection[j];
				gaussPoints[kGauss - 1, i] += nodes[num][i] * shapeFunc[j];
			}
		}
		_0023_003Dzd5AIw3_Yikt1AMvCSg_003D_003D(elIndex, nodes, shapeFuncDeriv, out detJacob, array);
		array2[0, 0] = (array[1, 1] * array[2, 2] - array[1, 2] * array[2, 1]) / detJacob;
		array2[1, 0] = 0.0 - (array[1, 0] * array[2, 2] - array[1, 2] * array[2, 0]) / detJacob;
		array2[2, 0] = (array[1, 0] * array[2, 1] - array[1, 1] * array[2, 0]) / detJacob;
		array2[0, 1] = 0.0 - (array[0, 1] * array[2, 2] - array[0, 2] * array[2, 1]) / detJacob;
		array2[1, 1] = (array[0, 0] * array[2, 2] - array[0, 2] * array[2, 0]) / detJacob;
		array2[2, 1] = 0.0 - (array[0, 0] * array[2, 1] - array[0, 1] * array[2, 0]) / detJacob;
		array2[0, 2] = (array[0, 1] * array[1, 2] - array[0, 2] * array[1, 1]) / detJacob;
		array2[1, 2] = 0.0 - (array[0, 0] * array[1, 2] - array[0, 2] * array[1, 0]) / detJacob;
		array2[2, 2] = (array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1]) / detJacob;
		for (int k = 0; k < NumberOfDimensions; k++)
		{
			for (int l = 0; l < NumberOfNodes; l++)
			{
				for (int m = 0; m < NumberOfDimensions; m++)
				{
					cartDeriv[l, k] += array2[m, k] * shapeFuncDeriv[l, m];
				}
			}
		}
	}

	internal void _0023_003Dzd5AIw3_Yikt1AMvCSg_003D_003D(int _0023_003DzKAXXKpk_003D, Point3D[] _0023_003DzDvuIQCU_003D, double[,] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, out double _0023_003Dz608OBdQOuUH1JsAnVw_003D_003D, double[,] _0023_003DzUlx_EoChee9l)
	{
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfDimensions; j++)
			{
				for (int k = 0; k < NumberOfNodes; k++)
				{
					int num = Connection[k];
					_0023_003DzUlx_EoChee9l[j, i] += _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[k, i] * _0023_003DzDvuIQCU_003D[num][j];
				}
			}
		}
		_0023_003Dz608OBdQOuUH1JsAnVw_003D_003D = _0023_003DzUlx_EoChee9l[0, 0] * (_0023_003DzUlx_EoChee9l[1, 1] * _0023_003DzUlx_EoChee9l[2, 2] - _0023_003DzUlx_EoChee9l[1, 2] * _0023_003DzUlx_EoChee9l[2, 1]) - _0023_003DzUlx_EoChee9l[1, 0] * (_0023_003DzUlx_EoChee9l[0, 1] * _0023_003DzUlx_EoChee9l[2, 2] - _0023_003DzUlx_EoChee9l[0, 2] * _0023_003DzUlx_EoChee9l[2, 1]) + _0023_003DzUlx_EoChee9l[2, 0] * (_0023_003DzUlx_EoChee9l[0, 1] * _0023_003DzUlx_EoChee9l[1, 2] - _0023_003DzUlx_EoChee9l[0, 2] * _0023_003DzUlx_EoChee9l[1, 1]);
		if (_0023_003Dz608OBdQOuUH1JsAnVw_003D_003D <= 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985123) + _0023_003DzKAXXKpk_003D);
		}
	}

	internal double[,] _0023_003Dz3Hkb3Pc_003D(double[,] _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D)
	{
		double[,] array = new double[NumberOfNodes * NumberOfDimensions, NumberOfStressesPerNode];
		int num = 0;
		for (int i = 0; i < NumberOfNodes; i++)
		{
			int num2 = num + 1;
			int num3 = num2 + 1;
			num = num3 + 1;
			array[num2 - 1, 0] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 0];
			array[num3 - 1, 0] = 0.0;
			array[num - 1, 0] = 0.0;
			array[num2 - 1, 1] = 0.0;
			array[num3 - 1, 1] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 1];
			array[num - 1, 1] = 0.0;
			array[num2 - 1, 2] = 0.0;
			array[num3 - 1, 2] = 0.0;
			array[num - 1, 2] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 2];
			array[num2 - 1, 3] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 1];
			array[num3 - 1, 3] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 0];
			array[num - 1, 3] = 0.0;
			array[num2 - 1, 4] = 0.0;
			array[num3 - 1, 4] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 2];
			array[num - 1, 4] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 1];
			array[num2 - 1, 5] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 2];
			array[num3 - 1, 5] = 0.0;
			array[num - 1, 5] = _0023_003Dzps_0024MBoBOfF1dcFV_LA_003D_003D[i, 0];
		}
		return array;
	}

	protected void StiffnessComputation(int kgasp, double[,] cartDeriv, double dvolu)
	{
		B = _0023_003Dz3Hkb3Pc_003D(cartDeriv);
		double[,] array = _0023_003DzwTQF9gqyciKw(mat.Matrix, B);
		for (int i = 0; i < base.TotalDof; i++)
		{
			for (int j = i; j < base.TotalDof; j++)
			{
				for (int k = 0; k < NumberOfStressesPerNode; k++)
				{
					double num = B[i, k];
					if (num != 0.0)
					{
						K[j, i] += num * array[j, k] * dvolu;
					}
				}
			}
		}
		for (int l = 0; l < NumberOfStressesPerNode; l++)
		{
			for (int m = 0; m < base.TotalDof; m++)
			{
				StressMatrix[kgasp - 1, m, l] = array[m, l];
			}
		}
	}

	protected void ComputeThermalLoading(int numgp, bool temperature, double[,] stgp, double[] strsg)
	{
		if (temperature)
		{
			for (int i = 0; i < 6; i++)
			{
				stgp[i, numgp - 1] = strsg[i] + strin[numgp - 1, i];
			}
		}
		else
		{
			for (int j = 0; j < 6; j++)
			{
				stgp[j, numgp - 1] = strsg[j];
			}
		}
	}

	protected void TotalUpTheStresses(double[,] strnd, int[] numberOfElementsPerNode, Point3D[] nodes)
	{
		base.Stress = new double[NumberOfNodes, 6];
		base.VonMises = new double[NumberOfNodes];
		base.Principals = new double[NumberOfNodes, 3];
		for (int i = 0; i < NumberOfNodes; i++)
		{
			int num = Connection[i];
			numberOfElementsPerNode[num]++;
			((Node)nodes[num]).Stress[0] += strnd[0, i];
			((Node)nodes[num]).Stress[1] += strnd[1, i];
			((Node)nodes[num]).Stress[2] += strnd[2, i];
			((Node)nodes[num]).Stress[3] += strnd[3, i];
			((Node)nodes[num]).Stress[4] += strnd[4, i];
			((Node)nodes[num]).Stress[5] += strnd[5, i];
			base.Stress[i, 0] = strnd[0, i];
			base.Stress[i, 1] = strnd[1, i];
			base.Stress[i, 2] = strnd[2, i];
			base.Stress[i, 3] = strnd[3, i];
			base.Stress[i, 4] = strnd[4, i];
			base.Stress[i, 5] = strnd[5, i];
			Element.CalcPrincipal(base.Stress[i, 0], base.Stress[i, 1], base.Stress[i, 2], base.Stress[i, 3], base.Stress[i, 4], base.Stress[i, 5], out base.VonMises[i], out var principal);
			base.Principals[i, 0] = principal[0];
			base.Principals[i, 1] = principal[1];
			base.Principals[i, 2] = principal[2];
		}
	}

	internal void _0023_003Dz3BcI_0024NWhMXKQ(double _0023_003DzRpXgovo_003D, double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double[,] _0023_003Dzzq8KIW2JJp76, double[] _0023_003DziBVrRQk_003D)
	{
		int[] array = new int[8] { 1, 2, 5, 6, 3, 4, 7, 8 };
		double[] array2 = new double[8]
		{
			(1.0 - _0023_003DzRpXgovo_003D) * (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 - _0023_003DzRpXgovo_003D) * (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 - _0023_003DzRpXgovo_003D) * (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 - _0023_003DzRpXgovo_003D) * (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 + _0023_003DzRpXgovo_003D) * (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 + _0023_003DzRpXgovo_003D) * (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 + _0023_003DzRpXgovo_003D) * (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 8.0,
			(1.0 + _0023_003DzRpXgovo_003D) * (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 8.0
		};
		Array.Clear(_0023_003DziBVrRQk_003D, 0, 6);
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				_0023_003DziBVrRQk_003D[j] += _0023_003Dzzq8KIW2JJp76[j, array[i] - 1] * array2[i];
			}
		}
	}

	protected void ComputeTemp(double[] tempLocal, double[] shapeFunc, int kgasp, double[,] cartDeriv, double dvolu)
	{
		double num = 0.0;
		for (int i = 0; i < NumberOfNodes; i++)
		{
			num += tempLocal[i] * shapeFunc[i];
		}
		double[] array = new double[6]
		{
			(0.0 - num) * mat.CoeffOfThermalExp,
			(0.0 - num) * mat.CoeffOfThermalExp,
			(0.0 - num) * mat.CoeffOfThermalExp,
			0.0,
			0.0,
			0.0
		};
		double[] array2 = new double[NumberOfStressesPerNode];
		for (int j = 0; j < NumberOfStressesPerNode; j++)
		{
			for (int k = 0; k < NumberOfStressesPerNode; k++)
			{
				array2[j] += mat.Matrix[k, j] * array[k];
			}
			strin[kgasp - 1, j] = array2[j];
		}
		B = _0023_003Dz3Hkb3Pc_003D(cartDeriv);
		for (int l = 0; l < NumberOfStressesPerNode; l++)
		{
			for (int m = 0; m < base.TotalDof; m++)
			{
				tLoad[m] -= B[m, l] * array2[l] * dvolu;
			}
		}
	}

	internal void _0023_003DzXkqbKnf_0024FS3S(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, out double[] _0023_003DzwaU_0024oWk_003D, out double[] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzwaU_0024oWk_003D = new double[3];
		_0023_003DzwaU_0024oWk_003D[0] = _0023_003DziMjqlCo_003D;
		_0023_003DzwaU_0024oWk_003D[1] = _0023_003DzI4dRPW0_003D;
		_0023_003DzwaU_0024oWk_003D[2] = _0023_003DzYEhafAA_003D;
		_0023_003DzmB17IaV5XzRN = new double[9];
		_0023_003DzmB17IaV5XzRN[0] = 1.0;
		_0023_003DzmB17IaV5XzRN[4] = 1.0;
		_0023_003DzmB17IaV5XzRN[8] = 1.0;
	}

	internal void _0023_003DzJu_9h_0024282FVIbKOjmQ_003D_003D(double[] _0023_003DzKjjYWhJTvaT_0024, double[] _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D, double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, double[,] _0023_003DzSi0fJ0kEgr24, int[] _0023_003DzkvfuOSosGSo5295lXQ_003D_003D)
	{
		int numberOfDimensions = NumberOfDimensions;
		double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfDimensions; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					int num = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[k];
					array[j, i] += _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D[j + num * numberOfDimensions] * (_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[i + k * numberOfDimensions] - _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[2 + k * numberOfDimensions]);
				}
			}
		}
		double[] array2 = new double[3];
		for (int l = 0; l < 3; l++)
		{
			array2[0] += _0023_003DzSi0fJ0kEgr24[l, 0] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[1] += _0023_003DzSi0fJ0kEgr24[l, 1] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[2] += _0023_003DzSi0fJ0kEgr24[l, 2] * _0023_003DzKjjYWhJTvaT_0024[l];
		}
		double num2 = array[1, 0] * array[2, 1] - array[2, 0] * array[1, 1];
		double num3 = 0.0 - array[0, 0] * array[2, 1] + array[2, 0] * array[0, 1];
		double num4 = array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1];
		num2 /= 6.0;
		num3 /= 6.0;
		num4 /= 6.0;
		array[0, 1] = 0.0 - array[1, 0] * num4 + array[2, 0] * num3;
		array[1, 1] = array[0, 0] * num4 - array[2, 0] * num2;
		array[2, 1] = 0.0 - array[0, 0] * num3 + array[1, 0] * num2;
		double num5 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
		double num6 = array[0, 0] * array[0, 0];
		double num7 = array[1, 0] * array[1, 0];
		double num8 = array[2, 0] * array[2, 0];
		double num9 = Math.Sqrt(num6 + num7 + num8);
		double num10 = array[0, 1] * array[0, 1];
		num7 = array[1, 1] * array[1, 1];
		num8 = array[2, 1] * array[2, 1];
		double num11 = Math.Sqrt(num10 + num7 + num8);
		double num12 = array2[2] * num2;
		double num13 = array2[2] * num3;
		double num14 = array2[2] * num4;
		num12 += num5 * (array2[0] * array[0, 0] / num9);
		num13 += num5 * (array2[0] * array[1, 0] / num9);
		num14 += num5 * (array2[0] * array[2, 0] / num9);
		num12 += num5 * (array2[1] * array[0, 1] / num11);
		num13 += num5 * (array2[1] * array[1, 1] / num11);
		num14 += num5 * (array2[1] * array[2, 1] / num11);
		for (int m = 0; m < 3; m++)
		{
			int num15 = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[m] * numberOfDimensions;
			int num16 = num15 + 1;
			int num17 = num16 + 1;
			distLoad[num15] += _0023_003DzKjjYWhJTvaT_0024[m] * num12;
			distLoad[num16] += _0023_003DzKjjYWhJTvaT_0024[m] * num13;
			distLoad[num17] += _0023_003DzKjjYWhJTvaT_0024[m] * num14;
		}
	}

	internal void _0023_003Dzyia2av_0024QpCT3_g6A7A_003D_003D(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, out double[] _0023_003DzKjjYWhJTvaT_0024, out double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D)
	{
		_0023_003DzKjjYWhJTvaT_0024 = new double[4];
		_0023_003DzKjjYWhJTvaT_0024[0] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzKjjYWhJTvaT_0024[1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzKjjYWhJTvaT_0024[2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzKjjYWhJTvaT_0024[3] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D = new double[12];
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[0] = 0.0 - (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[3] = (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[6] = (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[9] = 0.0 - (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[1] = 0.0 - (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[4] = 0.0 - (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[7] = (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[10] = (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
	}

	internal void _0023_003Dz64ORJv9Aw3SuQhHOaw_003D_003D(double[] _0023_003DzKjjYWhJTvaT_0024, double[] _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D, double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, double[,] _0023_003DzSi0fJ0kEgr24, int[] _0023_003DzkvfuOSosGSo5295lXQ_003D_003D)
	{
		int numberOfDimensions = NumberOfDimensions;
		double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfDimensions; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					int num = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[k];
					array[j, i] += _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D[j + num * numberOfDimensions] * _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[i + k * numberOfDimensions];
				}
			}
		}
		double[] array2 = new double[3];
		for (int l = 0; l < 4; l++)
		{
			array2[0] += _0023_003DzSi0fJ0kEgr24[l, 0] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[1] += _0023_003DzSi0fJ0kEgr24[l, 1] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[2] += _0023_003DzSi0fJ0kEgr24[l, 2] * _0023_003DzKjjYWhJTvaT_0024[l];
		}
		double num2 = array[1, 0] * array[2, 1] - array[2, 0] * array[1, 1];
		double num3 = 0.0 - array[0, 0] * array[2, 1] + array[2, 0] * array[0, 1];
		double num4 = array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1];
		array[0, 1] = 0.0 - array[1, 0] * num4 + array[2, 0] * num3;
		array[1, 1] = array[0, 0] * num4 - array[2, 0] * num2;
		array[2, 1] = 0.0 - array[0, 0] * num3 + array[1, 0] * num2;
		double num5 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
		double num6 = array[0, 0] * array[0, 0];
		double num7 = array[1, 0] * array[1, 0];
		double num8 = array[2, 0] * array[2, 0];
		double num9 = Math.Sqrt(num6 + num7 + num8);
		double num10 = array[0, 1] * array[0, 1];
		num7 = array[1, 1] * array[1, 1];
		num8 = array[2, 1] * array[2, 1];
		double num11 = Math.Sqrt(num10 + num7 + num8);
		double num12 = array2[2] * num2;
		double num13 = array2[2] * num3;
		double num14 = array2[2] * num4;
		num12 += num5 * (array2[0] * array[0, 0] / num9);
		num13 += num5 * (array2[0] * array[1, 0] / num9);
		num14 += num5 * (array2[0] * array[2, 0] / num9);
		num12 += num5 * (array2[1] * array[0, 1] / num11);
		num13 += num5 * (array2[1] * array[1, 1] / num11);
		num14 += num5 * (array2[1] * array[2, 1] / num11);
		for (int m = 0; m < 4; m++)
		{
			int num15 = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[m] * numberOfDimensions;
			int num16 = num15 + 1;
			int num17 = num16 + 1;
			distLoad[num15] += _0023_003DzKjjYWhJTvaT_0024[m] * num12;
			distLoad[num16] += _0023_003DzKjjYWhJTvaT_0024[m] * num13;
			distLoad[num17] += _0023_003DzKjjYWhJTvaT_0024[m] * num14;
		}
	}

	internal void _0023_003DznHxD323XQtsall3J8w_003D_003D(double _0023_003DzgPsOl1A_003D, double _0023_003DzD5YCi2M_003D, double _0023_003Dz9_0024bIhS0_003D, out double[] _0023_003DzKjjYWhJTvaT_0024, out double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D)
	{
		_0023_003DzKjjYWhJTvaT_0024 = new double[6];
		_0023_003DzKjjYWhJTvaT_0024[2] = _0023_003DzgPsOl1A_003D * (_0023_003DzgPsOl1A_003D * 2.0 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[3] = _0023_003DzgPsOl1A_003D * _0023_003DzD5YCi2M_003D * 4.0;
		_0023_003DzKjjYWhJTvaT_0024[4] = _0023_003DzD5YCi2M_003D * (_0023_003DzD5YCi2M_003D * 2.0 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[5] = _0023_003DzD5YCi2M_003D * _0023_003Dz9_0024bIhS0_003D * 4.0;
		_0023_003DzKjjYWhJTvaT_0024[0] = _0023_003Dz9_0024bIhS0_003D * (_0023_003Dz9_0024bIhS0_003D * 2.0 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[1] = _0023_003DzgPsOl1A_003D * _0023_003Dz9_0024bIhS0_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D = new double[18];
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[6] = _0023_003DzgPsOl1A_003D * 4.0 - 1.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[9] = _0023_003DzD5YCi2M_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[3] = _0023_003Dz9_0024bIhS0_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[10] = _0023_003DzgPsOl1A_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[13] = _0023_003DzD5YCi2M_003D * 4.0 - 1.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[16] = _0023_003Dz9_0024bIhS0_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[17] = _0023_003DzD5YCi2M_003D * 4.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[2] = _0023_003Dz9_0024bIhS0_003D * 4.0 - 1.0;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[5] = _0023_003DzgPsOl1A_003D * 4.0;
	}

	internal void _0023_003DzJoqQbD5u3xR2LyPb4A_003D_003D(double[] _0023_003DzKjjYWhJTvaT_0024, double[] _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D, double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, double[,] _0023_003DzSi0fJ0kEgr24, int[] _0023_003DzkvfuOSosGSo5295lXQ_003D_003D, double _0023_003DzbQkwuM0_003D)
	{
		int numberOfDimensions = NumberOfDimensions;
		double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfDimensions; j++)
			{
				for (int k = 0; k < 6; k++)
				{
					int num = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[k];
					array[j, i] += _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D[j + num * numberOfDimensions] * (_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[i + k * numberOfDimensions] - _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[2 + k * numberOfDimensions]);
				}
			}
		}
		double[] array2 = new double[3];
		for (int l = 0; l < 6; l++)
		{
			array2[0] += _0023_003DzSi0fJ0kEgr24[l, 0] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[1] += _0023_003DzSi0fJ0kEgr24[l, 1] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[2] += _0023_003DzSi0fJ0kEgr24[l, 2] * _0023_003DzKjjYWhJTvaT_0024[l];
		}
		double num2 = array[1, 0] * array[2, 1] - array[2, 0] * array[1, 1];
		double num3 = 0.0 - array[0, 0] * array[2, 1] + array[2, 0] * array[0, 1];
		double num4 = array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1];
		num2 /= 6.0;
		num3 /= 6.0;
		num4 /= 6.0;
		array[0, 1] = 0.0 - array[1, 0] * num4 + array[2, 0] * num3;
		array[1, 1] = array[0, 0] * num4 - array[2, 0] * num2;
		array[2, 1] = 0.0 - array[0, 0] * num3 + array[1, 0] * num2;
		double num5 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
		double num6 = array[0, 0] * array[0, 0];
		double num7 = array[1, 0] * array[1, 0];
		double num8 = array[2, 0] * array[2, 0];
		double num9 = Math.Sqrt(num6 + num7 + num8);
		double num10 = array[0, 1] * array[0, 1];
		num7 = array[1, 1] * array[1, 1];
		num8 = array[2, 1] * array[2, 1];
		double num11 = Math.Sqrt(num10 + num7 + num8);
		double num12 = array2[2] * num2;
		double num13 = array2[2] * num3;
		double num14 = array2[2] * num4;
		num12 += num5 * (array2[0] * array[0, 0] / num9);
		num13 += num5 * (array2[0] * array[1, 0] / num9);
		num14 += num5 * (array2[0] * array[2, 0] / num9);
		num12 += num5 * (array2[1] * array[0, 1] / num11);
		num13 += num5 * (array2[1] * array[1, 1] / num11);
		num14 += num5 * (array2[1] * array[2, 1] / num11);
		for (int m = 0; m < 6; m++)
		{
			int num15 = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[m] * numberOfDimensions;
			int num16 = num15 + 1;
			int num17 = num16 + 1;
			distLoad[num15] += _0023_003DzKjjYWhJTvaT_0024[m] * num12 * _0023_003DzbQkwuM0_003D;
			distLoad[num16] += _0023_003DzKjjYWhJTvaT_0024[m] * num13 * _0023_003DzbQkwuM0_003D;
			distLoad[num17] += _0023_003DzKjjYWhJTvaT_0024[m] * num14 * _0023_003DzbQkwuM0_003D;
		}
	}

	internal void _0023_003Dzf4wUc4yo_ghzsgmsIg_003D_003D(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, out double[] _0023_003DzKjjYWhJTvaT_0024, out double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D)
	{
		double num = 0.25;
		double num2 = 0.5;
		double num3 = _0023_003DzuwH5j5s_003D * 2.0;
		double num4 = _0023_003DzNDQ_E88_003D * 2.0;
		double num5 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D;
		double num6 = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num7 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
		double num8 = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D;
		double num9 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num10 = _0023_003DzuwH5j5s_003D * _0023_003DzNDQ_E88_003D * 2.0;
		_0023_003DzKjjYWhJTvaT_0024 = new double[8];
		_0023_003DzKjjYWhJTvaT_0024[0] = num * (num7 + num5 + num6 - num8 - num9 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[1] = num2 * (num8 - _0023_003DzNDQ_E88_003D - num5 + 1.0);
		_0023_003DzKjjYWhJTvaT_0024[2] = num * (num9 + num5 + num6 - num8 - num7 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[3] = num2 * (_0023_003DzuwH5j5s_003D - num6 - num9 + 1.0);
		_0023_003DzKjjYWhJTvaT_0024[4] = num * (num7 + num5 + num6 + num8 + num9 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[5] = num2 * (_0023_003DzNDQ_E88_003D - num5 - num8 + 1.0);
		_0023_003DzKjjYWhJTvaT_0024[6] = num * (num5 + num6 + num8 - num9 - num7 - 1.0);
		_0023_003DzKjjYWhJTvaT_0024[7] = num2 * (num9 - _0023_003DzuwH5j5s_003D - num6 + 1.0);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D = new double[24];
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[0] = num * (_0023_003DzNDQ_E88_003D + num3 - num10 - num6);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[3] = num7 - _0023_003DzuwH5j5s_003D;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[6] = num * (num6 + num3 - num10 - _0023_003DzNDQ_E88_003D);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[9] = num2 * (1.0 - num6);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[12] = num * (_0023_003DzNDQ_E88_003D + num3 + num10 + num6);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[15] = 0.0 - _0023_003DzuwH5j5s_003D - num7;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[18] = num * (num3 + num10 - _0023_003DzNDQ_E88_003D - num6);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[21] = num2 * (num6 - 1.0);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[1] = num * (_0023_003DzuwH5j5s_003D + num4 - num5 - num10);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[4] = num2 * (num5 - 1.0);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[7] = num * (num10 + num4 - _0023_003DzuwH5j5s_003D - num5);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[10] = 0.0 - _0023_003DzNDQ_E88_003D - num7;
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[13] = num * (_0023_003DzuwH5j5s_003D + num4 + num5 + num10);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[16] = num2 * (1.0 - num5);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[19] = num * (num5 + num4 - _0023_003DzuwH5j5s_003D - num10);
		_0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[22] = num7 - _0023_003DzNDQ_E88_003D;
	}

	internal void _0023_003Dz4pc2H7of1UIr0YJRgw_003D_003D(double[] _0023_003DzKjjYWhJTvaT_0024, double[] _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D, double[] _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, double[,] _0023_003DzSi0fJ0kEgr24, int[] _0023_003DzkvfuOSosGSo5295lXQ_003D_003D)
	{
		int numberOfDimensions = NumberOfDimensions;
		double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
		for (int i = 0; i < NumberOfDimensions; i++)
		{
			for (int j = 0; j < NumberOfDimensions; j++)
			{
				array[j, i] = 0.0;
				for (int k = 0; k < 8; k++)
				{
					int num = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[k];
					array[j, i] += _0023_003Dze3XgI_GC_0024BgAVcD3KffIQoc_003D[j + num * numberOfDimensions] * _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D[i + k * numberOfDimensions];
				}
			}
		}
		double[] array2 = new double[3];
		for (int l = 0; l < 8; l++)
		{
			array2[0] += _0023_003DzSi0fJ0kEgr24[l, 0] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[1] += _0023_003DzSi0fJ0kEgr24[l, 1] * _0023_003DzKjjYWhJTvaT_0024[l];
			array2[2] += _0023_003DzSi0fJ0kEgr24[l, 2] * _0023_003DzKjjYWhJTvaT_0024[l];
		}
		double num2 = array[1, 0] * array[2, 1] - array[2, 0] * array[1, 1];
		double num3 = 0.0 - array[0, 0] * array[2, 1] + array[2, 0] * array[0, 1];
		double num4 = array[0, 0] * array[1, 1] - array[1, 0] * array[0, 1];
		array[0, 1] = 0.0 - array[1, 0] * num4 + array[2, 0] * num3;
		array[1, 1] = array[0, 0] * num4 - array[2, 0] * num2;
		array[2, 1] = 0.0 - array[0, 0] * num3 + array[1, 0] * num2;
		double num5 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
		double num6 = array[0, 0] * array[0, 0];
		double num7 = array[1, 0] * array[1, 0];
		double num8 = array[2, 0] * array[2, 0];
		double num9 = Math.Sqrt(num6 + num7 + num8);
		double num10 = array[0, 1] * array[0, 1];
		num7 = array[1, 1] * array[1, 1];
		num8 = array[2, 1] * array[2, 1];
		double num11 = Math.Sqrt(num10 + num7 + num8);
		double num12 = array2[2] * num2;
		double num13 = array2[2] * num3;
		double num14 = array2[2] * num4;
		num12 += num5 * (array2[0] * array[0, 0] / num9);
		num13 += num5 * (array2[0] * array[1, 0] / num9);
		num14 += num5 * (array2[0] * array[2, 0] / num9);
		num12 += num5 * (array2[1] * array[0, 1] / num11);
		num13 += num5 * (array2[1] * array[1, 1] / num11);
		num14 += num5 * (array2[1] * array[2, 1] / num11);
		for (int m = 0; m < 8; m++)
		{
			int num15 = _0023_003DzkvfuOSosGSo5295lXQ_003D_003D[m] * numberOfDimensions;
			int num16 = num15 + 1;
			int num17 = num16 + 1;
			distLoad[num15] += _0023_003DzKjjYWhJTvaT_0024[m] * num12;
			distLoad[num16] += _0023_003DzKjjYWhJTvaT_0024[m] * num13;
			distLoad[num17] += _0023_003DzKjjYWhJTvaT_0024[m] * num14;
		}
	}

	public override void FixEdgeFace(int faceIndex, bool alongX, bool alongY, bool alongZ)
	{
		if (elFaces[faceIndex].Restraints == null)
		{
			elFaces[faceIndex].Restraints = new bool[3] { alongX, alongY, alongZ };
			elFaces[faceIndex].displacement = new double[3];
		}
		else
		{
			elFaces[faceIndex].Restraints[0] |= alongX;
			elFaces[faceIndex].Restraints[1] |= alongY;
			elFaces[faceIndex].Restraints[2] |= alongZ;
		}
	}

	public override void FixAllEdgeFace(int faceIndex)
	{
		elFaces[faceIndex].Restraints = new bool[3] { true, true, true };
		elFaces[faceIndex].displacement = new double[3];
	}

	public override void SetRestraintEdgeFace(int faceIndex, bool alongX, bool alongY, bool alongZ, double amountInX, double amountInY, double amountInZ)
	{
		elFaces[faceIndex].Restraints = new bool[2] { alongX, alongY };
		elFaces[faceIndex].displacement = new double[2] { amountInX, amountInY };
	}

	public override void SetRestraintEdgeFaceInX(int faceIndex, double amountInX)
	{
		if (elFaces[faceIndex].Restraints == null)
		{
			elFaces[faceIndex].Restraints = new bool[3] { true, false, false };
			elFaces[faceIndex].displacement = new double[3] { amountInX, 0.0, 0.0 };
		}
		else
		{
			elFaces[faceIndex].Restraints[0] = true;
			elFaces[faceIndex].displacement[0] += amountInX;
		}
	}

	public override void SetRestraintEdgeFaceInY(int faceIndex, double amountInY)
	{
		if (elFaces[faceIndex].Restraints == null)
		{
			elFaces[faceIndex].Restraints = new bool[3] { false, true, false };
			elFaces[faceIndex].displacement = new double[3] { 0.0, amountInY, 0.0 };
		}
		else
		{
			elFaces[faceIndex].Restraints[1] = true;
			elFaces[faceIndex].displacement[1] += amountInY;
		}
	}

	public override void SetRestraintEdgeFaceInZ(int faceIndex, double amountInZ)
	{
		if (elFaces[faceIndex].Restraints == null)
		{
			elFaces[faceIndex].Restraints = new bool[3] { false, false, true };
			elFaces[faceIndex].displacement = new double[3] { 0.0, 0.0, amountInZ };
		}
		else
		{
			elFaces[faceIndex].Restraints[2] = true;
			elFaces[faceIndex].displacement[2] += amountInZ;
		}
	}

	internal static void _0023_003DzqPQh4udtQiJJVOnZXXL0JnWywA39(double[] _0023_003Dz2lS1C6s9I0e6, Vector3D _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D, byte[] _0023_003DzXSN9MPz6IsKe)
	{
		int num = _0023_003DzXSN9MPz6IsKe.Length;
		bool flag = num == 6 || num == 8;
		for (int i = 0; i < _0023_003DzXSN9MPz6IsKe.Length; i++)
		{
			int num2 = _0023_003DzXSN9MPz6IsKe[i] * 3;
			double num3 = Math.Sqrt(_0023_003Dz2lS1C6s9I0e6[num2] * _0023_003Dz2lS1C6s9I0e6[num2] + _0023_003Dz2lS1C6s9I0e6[num2 + 1] * _0023_003Dz2lS1C6s9I0e6[num2 + 1] + _0023_003Dz2lS1C6s9I0e6[num2 + 2] * _0023_003Dz2lS1C6s9I0e6[num2 + 2]);
			if (flag && i % 2 == 0)
			{
				_0023_003Dz2lS1C6s9I0e6[num2] = (0.0 - _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[0]) * num3;
				_0023_003Dz2lS1C6s9I0e6[num2 + 1] = (0.0 - _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[1]) * num3;
				_0023_003Dz2lS1C6s9I0e6[num2 + 2] = (0.0 - _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[2]) * num3;
			}
			else
			{
				_0023_003Dz2lS1C6s9I0e6[num2] = _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[0] * num3;
				_0023_003Dz2lS1C6s9I0e6[num2 + 1] = _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[1] * num3;
				_0023_003Dz2lS1C6s9I0e6[num2 + 2] = _0023_003DzRpfUnJ1YOjuoo2n3gA_003D_003D[2] * num3;
			}
		}
	}

	public abstract Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend);

	internal bool _0023_003DzrBgJrTjgFFt3MwQiAChxhcoHohTg(Plane _0023_003Dzrgqz890sj_0024X9, int[] _0023_003DzfYMyE9c_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		int num = 0;
		int num2 = 0;
		foreach (int num3 in _0023_003DzfYMyE9c_003D)
		{
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3].DistanceTo(_0023_003Dzrgqz890sj_0024X9) > 0.0)
			{
				num++;
			}
			else
			{
				num2++;
			}
		}
		if (num == _0023_003DzfYMyE9c_003D.Length || num2 == _0023_003DzfYMyE9c_003D.Length)
		{
			return false;
		}
		return true;
	}

	internal Mesh _0023_003DzpDhSsbU_003D(bool _0023_003DzMneOfPkjGMYt, IList<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, Plane _0023_003DzF4Mz_3Ehqy_2sw_0024vlrxTmIw_003D, Size3D _0023_003DzD21_0024ur8_003D, ILegend _0023_003DzK_lIM315NEeH)
	{
		Align3D align3D = new Align3D(_0023_003DzF4Mz_3Ehqy_2sw_0024vlrxTmIw_003D, Plane.XY);
		for (int i = 0; i < _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count; i++)
		{
			_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D[i].TransformBy(align3D);
		}
		Point2D maxValue = Point2D.MaxValue;
		Point2D minValue = Point2D.MinValue;
		foreach (Point3D item in _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D)
		{
			if (item.X < maxValue.X)
			{
				maxValue.X = item.X;
			}
			if (item.X > minValue.X)
			{
				minValue.X = item.X;
			}
			if (item.Y < maxValue.Y)
			{
				maxValue.Y = item.Y;
			}
			if (item.Y > minValue.Y)
			{
				minValue.Y = item.Y;
			}
		}
		Size2D size2D = new Size2D(maxValue, minValue);
		double num = _0023_003DzD21_0024ur8_003D.Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (size2D.X < num || size2D.Y < num)
		{
			return null;
		}
		Point2D[] array = ClipperUtility.RemoveDuplicates(_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, maxValue, minValue);
		Mesh mesh = null;
		if (array.Length > 2)
		{
			try
			{
				Point2D[] array2 = Utility.ConvexHull2D(array, sorted: true);
				Mesh mesh2 = new Mesh();
				mesh2.Vertices = new Point3D[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					Point2D point2D = array2[j];
					mesh2.Vertices[j] = new Point3D(point2D.X, point2D.Y);
				}
				if (!Utility.Triangulate(array2, null, fixOrientation: true, checkValidity: false, out var _, out var triangles))
				{
					return null;
				}
				mesh2.Triangles = new IndexTriangle[triangles.Length];
				Mesh.natureType meshNature = (_0023_003DzMneOfPkjGMYt ? Mesh.natureType.RichPlain : Mesh.natureType.MulticolorPlain);
				for (int k = 0; k < triangles.Length; k++)
				{
					IndexTriangle indexTriangle = triangles[k];
					mesh2.Triangles[k] = Utility.CreateTriangle(meshNature, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				}
				Point3D[] array3 = new Point3D[mesh2.Vertices.Length];
				PointF[] array4 = null;
				align3D.Invert();
				if (_0023_003DzMneOfPkjGMYt)
				{
					array4 = new PointF[mesh2.Vertices.Length];
					for (int l = 0; l < mesh2.Vertices.Length; l++)
					{
						PointSection pointSection = (PointSection)array2[l];
						pointSection.TransformBy(align3D);
						if (_0023_003DzK_lIM315NEeH != null)
						{
							array4[l] = new PointF((float)_0023_003DzK_lIM315NEeH.Normalize(pointSection.plotValue), 0f);
						}
						array3[l] = new Point3D(pointSection.X, pointSection.Y, pointSection.Z);
					}
					IndexTriangle[] triangles2 = mesh2.Triangles;
					for (int m = 0; m < triangles2.Length; m++)
					{
						RichTriangle obj = (RichTriangle)triangles2[m];
						obj.T1 = obj.V1;
						obj.T2 = obj.V2;
						obj.T3 = obj.V3;
					}
				}
				else
				{
					for (int n = 0; n < mesh2.Vertices.Length; n++)
					{
						PointSection pointSection2 = (PointSection)array2[n];
						pointSection2.TransformBy(align3D);
						Color color = base.Material.Diffuse;
						if (_0023_003DzK_lIM315NEeH != null)
						{
							color = _0023_003DzK_lIM315NEeH.GetColorTable()[_0023_003DzK_lIM315NEeH.IndexAt(pointSection2.plotValue)];
						}
						array3[n] = new PointRGB(pointSection2.X, pointSection2.Y, pointSection2.Z, color);
					}
				}
				mesh = new Mesh(array3, mesh2.Triangles);
				mesh.TextureCoords = array4;
			}
			catch (Exception)
			{
			}
		}
		return mesh;
	}

	protected Mesh GetSlice(bool useTexture, IList<Point3D> intersectionPoints, Plane clippingPlane, ILegend legend)
	{
		Align3D align3D = new Align3D(clippingPlane, Plane.XY);
		Point2D[] array = new Point2D[intersectionPoints.Count];
		for (int i = 0; i < intersectionPoints.Count; i++)
		{
			intersectionPoints[i].TransformBy(align3D);
			array[i] = new Point2D(intersectionPoints[i].X, intersectionPoints[i].Y);
		}
		if (array.Length < 4)
		{
			return null;
		}
		if (!Utility.Triangulate(array, null, fixOrientation: false, checkValidity: false, out var _, out var triangles))
		{
			return null;
		}
		Mesh.natureType meshNature = (useTexture ? Mesh.natureType.RichPlain : Mesh.natureType.MulticolorPlain);
		Mesh mesh = new Mesh(intersectionPoints.Count, triangles.Length, meshNature);
		Array.Copy(triangles, mesh.Triangles, mesh.Triangles.Length);
		for (int j = 0; j < triangles.Length; j++)
		{
			IndexTriangle indexTriangle = triangles[j];
			mesh.Triangles[j] = Utility.CreateTriangle(meshNature, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
		}
		Point3D[] array2 = new Point3D[intersectionPoints.Count];
		PointF[] array3 = null;
		align3D.Invert();
		if (useTexture)
		{
			array3 = new PointF[intersectionPoints.Count];
			for (int k = 0; k < intersectionPoints.Count; k++)
			{
				PointSection pointSection = (PointSection)intersectionPoints[k];
				pointSection.TransformBy(align3D);
				if (legend != null)
				{
					array3[k] = new PointF((float)legend.Normalize(pointSection.plotValue), 0f);
				}
				array2[k] = new Point3D(pointSection.X, pointSection.Y, pointSection.Z);
			}
			IndexTriangle[] triangles2 = mesh.Triangles;
			for (int l = 0; l < triangles2.Length; l++)
			{
				RichTriangle obj = (RichTriangle)triangles2[l];
				obj.T1 = obj.V1;
				obj.T2 = obj.V2;
				obj.T3 = obj.V3;
			}
		}
		else
		{
			for (int m = 0; m < mesh.Vertices.Length; m++)
			{
				PointSection pointSection2 = (PointSection)intersectionPoints[m];
				pointSection2.TransformBy(align3D);
				Color color = base.Material.Diffuse;
				if (legend != null)
				{
					color = legend.GetColorTable()[legend.IndexAt(pointSection2.plotValue)];
				}
				array2[m] = new PointRGB(pointSection2.X, pointSection2.Y, pointSection2.Z, color);
			}
		}
		Array.Copy(array2, mesh.Vertices, mesh.Vertices.Length);
		mesh.TextureCoords = array3;
		return mesh;
	}
}
