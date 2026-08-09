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
public class Hexa20 : Element3D
{
	private sealed class _0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D
	{
		public Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

		internal Point3D _0023_003Dz_ZMSnWNZj5bzJ5Hipt6yHKc_003D(int _0023_003Dzi9fncwc_003D)
		{
			return (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dzi9fncwc_003D].Clone();
		}
	}

	public Hexa20(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, int nodeIndex7, int nodeIndex8, int nodeIndex9, int nodeIndex10, int nodeIndex11, int nodeIndex12, int nodeIndex13, int nodeIndex14, int nodeIndex15, int nodeIndex16, int nodeIndex17, int nodeIndex18, int nodeIndex19, int nodeIndex20, Material mat)
		: this(new int[20]
		{
			nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6, nodeIndex7, nodeIndex8, nodeIndex9, nodeIndex10,
			nodeIndex11, nodeIndex12, nodeIndex13, nodeIndex14, nodeIndex15, nodeIndex16, nodeIndex17, nodeIndex18, nodeIndex19, nodeIndex20
		}, mat)
	{
	}

	public Hexa20(IEnumerable<int> nodeIndices, Material mat)
		: base(20, mat)
	{
		NumberOfGaussPoints = 8;
		Connection = nodeIndices.ToArray();
		elFaces = new Face[6]
		{
			new Face(new byte[8] { 0, 7, 6, 5, 4, 3, 2, 1 }),
			new Face(new byte[8] { 0, 1, 2, 9, 14, 13, 12, 8 }),
			new Face(new byte[8] { 2, 3, 4, 10, 16, 15, 14, 9 }),
			new Face(new byte[8] { 4, 5, 6, 11, 18, 17, 16, 10 }),
			new Face(new byte[8] { 6, 7, 0, 8, 12, 19, 18, 11 }),
			new Face(new byte[8] { 12, 13, 14, 15, 16, 17, 18, 19 })
		};
	}

	protected Hexa20(Hexa20 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Hexa20(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemHexa20Surrogate(this);
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
					_0023_003Dz8sBt3_0024SkdvSo(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array, array2);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
					double dVolume = detJacob * gpWeight[i] * gpWeight[j] * gpWeight[k];
					AssembleMassMatrix(array, dVolume);
				}
			}
		}
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
					_0023_003Dz8sBt3_0024SkdvSo(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array, array2);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
					double dvolu = detJacob * gpWeight[i] * gpWeight[j] * gpWeight[k];
					StiffnessComputation(num, cartDeriv, dvolu);
				}
			}
		}
		StiffnessComputation(nodes);
	}

	private static void _0023_003Dz8sBt3_0024SkdvSo(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double _0023_003Dz77g161c_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		double num = _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D;
		double num2 = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num3 = _0023_003Dz77g161c_003D * _0023_003Dz77g161c_003D;
		double num4 = 1.0 - _0023_003DzuwH5j5s_003D;
		double num5 = 1.0 + _0023_003DzuwH5j5s_003D;
		double num6 = 1.0 - _0023_003DzNDQ_E88_003D;
		double num7 = 1.0 + _0023_003DzNDQ_E88_003D;
		double num8 = 1.0 - _0023_003Dz77g161c_003D;
		double num9 = 1.0 + _0023_003Dz77g161c_003D;
		_0023_003DzwaU_0024oWk_003D[0] = num4 * num6 * num8 * (0.0 - _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[1] = (1.0 - num) * num6 * num8 / 4.0;
		_0023_003DzwaU_0024oWk_003D[2] = num5 * num6 * num8 * (_0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[3] = num5 * (1.0 - num2) * num8 / 4.0;
		_0023_003DzwaU_0024oWk_003D[4] = num5 * num7 * num8 * (_0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[5] = (1.0 - num) * num7 * num8 / 4.0;
		_0023_003DzwaU_0024oWk_003D[6] = num4 * num7 * num8 * (0.0 - _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[7] = num4 * (1.0 - num2) * num8 / 4.0;
		_0023_003DzwaU_0024oWk_003D[8] = num4 * num6 * (1.0 - num3) / 4.0;
		_0023_003DzwaU_0024oWk_003D[9] = num5 * num6 * (1.0 - num3) / 4.0;
		_0023_003DzwaU_0024oWk_003D[10] = num5 * num7 * (1.0 - num3) / 4.0;
		_0023_003DzwaU_0024oWk_003D[11] = num4 * num7 * (1.0 - num3) / 4.0;
		_0023_003DzwaU_0024oWk_003D[12] = num4 * num6 * num9 * (0.0 - _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[13] = (1.0 - num) * num6 * num9 / 4.0;
		_0023_003DzwaU_0024oWk_003D[14] = num5 * num6 * num9 * (_0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[15] = num5 * (1.0 - num2) * num9 / 4.0;
		_0023_003DzwaU_0024oWk_003D[16] = num5 * num7 * num9 * (_0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[17] = (1.0 - num) * num7 * num9 / 4.0;
		_0023_003DzwaU_0024oWk_003D[18] = num4 * num7 * num9 * (0.0 - _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 2.0) / 8.0;
		_0023_003DzwaU_0024oWk_003D[19] = num4 * (1.0 - num2) * num9 / 4.0;
		_0023_003DzmB17IaV5XzRN[0, 0] = num6 * num8 * (2.0 * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 0] = 0.0 - _0023_003DzuwH5j5s_003D * num6 * num8 / 2.0;
		_0023_003DzmB17IaV5XzRN[2, 0] = num6 * num8 * (2.0 * _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 0] = (1.0 - num2) * num8 / 4.0;
		_0023_003DzmB17IaV5XzRN[4, 0] = num7 * num8 * (2.0 * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 0] = 0.0 - _0023_003DzuwH5j5s_003D * num7 * num8 / 2.0;
		_0023_003DzmB17IaV5XzRN[6, 0] = num7 * num8 * (2.0 * _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 0] = 0.0 - (1.0 - num2) * num8 / 4.0;
		_0023_003DzmB17IaV5XzRN[8, 0] = 0.0 - num6 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[9, 0] = num6 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[10, 0] = num7 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[11, 0] = 0.0 - num7 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[12, 0] = num6 * num9 * (2.0 * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[13, 0] = 0.0 - _0023_003DzuwH5j5s_003D * num6 * num9 / 2.0;
		_0023_003DzmB17IaV5XzRN[14, 0] = num6 * num9 * (2.0 * _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[15, 0] = (1.0 - num2) * num9 / 4.0;
		_0023_003DzmB17IaV5XzRN[16, 0] = num7 * num9 * (2.0 * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[17, 0] = 0.0 - _0023_003DzuwH5j5s_003D * num7 * num9 / 2.0;
		_0023_003DzmB17IaV5XzRN[18, 0] = num7 * num9 * (2.0 * _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[19, 0] = 0.0 - (1.0 - num2) * num9 / 4.0;
		_0023_003DzmB17IaV5XzRN[0, 1] = num4 * num8 * (_0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 1] = 0.0 - (1.0 - num) * num8 / 4.0;
		_0023_003DzmB17IaV5XzRN[2, 1] = num5 * num8 * (0.0 - _0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 1] = 0.0 - _0023_003DzNDQ_E88_003D * num5 * num8 / 2.0;
		_0023_003DzmB17IaV5XzRN[4, 1] = num5 * num8 * (_0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 1] = (1.0 - num) * num8 / 4.0;
		_0023_003DzmB17IaV5XzRN[6, 1] = num4 * num8 * (0.0 - _0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 1] = 0.0 - _0023_003DzNDQ_E88_003D * num4 * num8 / 2.0;
		_0023_003DzmB17IaV5XzRN[8, 1] = 0.0 - num4 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[9, 1] = 0.0 - num5 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[10, 1] = num5 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[11, 1] = num4 * (1.0 - num3) / 4.0;
		_0023_003DzmB17IaV5XzRN[12, 1] = num4 * num9 * (_0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[13, 1] = 0.0 - (1.0 - num) * num9 / 4.0;
		_0023_003DzmB17IaV5XzRN[14, 1] = num5 * num9 * (0.0 - _0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D - _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[15, 1] = 0.0 - _0023_003DzNDQ_E88_003D * num5 * num9 / 2.0;
		_0023_003DzmB17IaV5XzRN[16, 1] = num5 * num9 * (_0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[17, 1] = (1.0 - num) * num9 / 4.0;
		_0023_003DzmB17IaV5XzRN[18, 1] = num4 * num9 * (0.0 - _0023_003DzuwH5j5s_003D + 2.0 * _0023_003DzNDQ_E88_003D + _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[19, 1] = 0.0 - _0023_003DzNDQ_E88_003D * num4 * num9 / 2.0;
		_0023_003DzmB17IaV5XzRN[0, 2] = num4 * num6 * (_0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[1, 2] = 0.0 - (1.0 - num) * num6 / 4.0;
		_0023_003DzmB17IaV5XzRN[2, 2] = num5 * num6 * (0.0 - _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[3, 2] = 0.0 - num5 * (1.0 - num2) / 4.0;
		_0023_003DzmB17IaV5XzRN[4, 2] = num5 * num7 * (0.0 - _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[5, 2] = 0.0 - (1.0 - num) * num7 / 4.0;
		_0023_003DzmB17IaV5XzRN[6, 2] = num4 * num7 * (_0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D + 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[7, 2] = 0.0 - num4 * (1.0 - num2) / 4.0;
		_0023_003DzmB17IaV5XzRN[8, 2] = 0.0 - _0023_003Dz77g161c_003D * num4 * num6 / 2.0;
		_0023_003DzmB17IaV5XzRN[9, 2] = 0.0 - _0023_003Dz77g161c_003D * num5 * num6 / 2.0;
		_0023_003DzmB17IaV5XzRN[10, 2] = 0.0 - _0023_003Dz77g161c_003D * num5 * num7 / 2.0;
		_0023_003DzmB17IaV5XzRN[11, 2] = 0.0 - _0023_003Dz77g161c_003D * num4 * num7 / 2.0;
		_0023_003DzmB17IaV5XzRN[12, 2] = num4 * num6 * (0.0 - _0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[13, 2] = (1.0 - num) * num6 / 4.0;
		_0023_003DzmB17IaV5XzRN[14, 2] = num5 * num6 * (_0023_003DzuwH5j5s_003D - _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[15, 2] = num5 * (1.0 - num2) / 4.0;
		_0023_003DzmB17IaV5XzRN[16, 2] = num5 * num7 * (_0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[17, 2] = (1.0 - num) * num7 / 4.0;
		_0023_003DzmB17IaV5XzRN[18, 2] = num4 * num7 * (0.0 - _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D + 2.0 * _0023_003Dz77g161c_003D - 1.0) / 8.0;
		_0023_003DzmB17IaV5XzRN[19, 2] = num4 * (1.0 - num2) / 4.0;
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
			array2[m, 2] = array3[m];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num3, num3, array, array3);
		for (int n = 0; n < 6; n++)
		{
			array2[n, 4] = array3[n];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num4, num3, array, array3);
		for (int num5 = 0; num5 < 6; num5++)
		{
			array2[num5, 6] = array3[num5];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num4, num4, array, array3);
		for (int num6 = 0; num6 < 6; num6++)
		{
			array2[num6, 12] = array3[num6];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num3, num3, num4, array, array3);
		for (int num7 = 0; num7 < 6; num7++)
		{
			array2[num7, 14] = array3[num7];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num3, num4, array, array3);
		for (int num8 = 0; num8 < 6; num8++)
		{
			array2[num8, 16] = array3[num8];
		}
		_0023_003Dz3BcI_0024NWhMXKQ(num4, num4, num4, array, array3);
		for (int num9 = 0; num9 < 6; num9++)
		{
			array2[num9, 18] = array3[num9];
		}
		for (int num10 = 0; num10 < 6; num10++)
		{
			array2[num10, 1] = (array2[num10, 0] + array2[num10, 2]) / 2.0;
			array2[num10, 3] = (array2[num10, 2] + array2[num10, 4]) / 2.0;
			array2[num10, 5] = (array2[num10, 4] + array2[num10, 6]) / 2.0;
			array2[num10, 7] = (array2[num10, 0] + array2[num10, 6]) / 2.0;
			array2[num10, 8] = (array2[num10, 0] + array2[num10, 12]) / 2.0;
			array2[num10, 9] = (array2[num10, 2] + array2[num10, 14]) / 2.0;
			array2[num10, 10] = (array2[num10, 4] + array2[num10, 16]) / 2.0;
			array2[num10, 11] = (array2[num10, 6] + array2[num10, 18]) / 2.0;
			array2[num10, 13] = (array2[num10, 12] + array2[num10, 14]) / 2.0;
			array2[num10, 15] = (array2[num10, 14] + array2[num10, 16]) / 2.0;
			array2[num10, 17] = (array2[num10, 16] + array2[num10, 18]) / 2.0;
			array2[num10, 19] = (array2[num10, 12] + array2[num10, 18]) / 2.0;
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
					_0023_003Dz8sBt3_0024SkdvSo(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, array2, array3);
					double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
					Jacob3(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
					double dvolu = detJacob;
					ComputeTemp(array, array2, num, cartDeriv, dvolu);
				}
			}
		}
	}

	public override void Draw(RenderContextBase renderContext, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(renderContext, singleColor, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void Draw(RenderContextBase renderContext, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(renderContext, i, vertices, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColor(RenderContextBase renderContext, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(renderContext, i, vertices, min, max, ampFactor, mode);
			}
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase renderContext, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		for (int i = 0; i < 6; i++)
		{
			if (elFaces[i].Visible)
			{
				_0023_003Dz_0024pRElff8RWIV(renderContext, i, vertices, min, max, ampFactor, mode);
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
				list.AddRange(GetFace8(elIndex, i, vertices, ampFactor, centroids));
			}
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
		_0023_003DzQP_a_9tKgg2BK6b1lA_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
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
		_0023_003DzQP_a_9tKgg2BK6b1lA_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	internal void _0023_003DzQP_a_9tKgg2BK6b1lA_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
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
		int[] array3 = new int[8];
		for (int k = 0; k < 8; k++)
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
				_0023_003Dzf4wUc4yo_ghzsgmsIg_003D_003D(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzKjjYWhJTvaT_0024, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D);
				_0023_003Dz4pc2H7of1UIr0YJRgw_003D_003D(_0023_003DzKjjYWhJTvaT_0024, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, array, array3);
			}
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		Segment3D segment3D = new Segment3D(fm.Vertices[Connection[0]], fm.Vertices[Connection[12]]);
		Segment3D segment3D2 = new Segment3D(fm.Vertices[Connection[2]], fm.Vertices[Connection[14]]);
		Segment3D segment3D3 = new Segment3D(fm.Vertices[Connection[4]], fm.Vertices[Connection[16]]);
		Segment3D segment3D4 = new Segment3D(fm.Vertices[Connection[6]], fm.Vertices[Connection[18]]);
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
					Hexa20 item = Hexa8._0023_003DzuqZUnnjQavZDSny_xA_003D_003D(new List<int>
					{
						num + (num3 * k + l) + j * num2,
						num + (num3 * k + l + 1) + j * num2,
						num + (num3 * (k + 1) + l + 1) + j * num2,
						num + (num3 * (k + 1) + l) + j * num2,
						num + (num3 * k + l) + (j + 1) * num2,
						num + (num3 * k + l + 1) + (j + 1) * num2,
						num + (num3 * (k + 1) + l + 1) + (j + 1) * num2,
						num + (num3 * (k + 1) + l) + (j + 1) * num2
					}.ToArray(), list, base.Material);
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

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		_0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D _0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D2 = new _0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D();
		_0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D = vertices;
		FemMesh femMesh = new FemMesh(Connection.Select(_0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D2._0023_003Dz_ZMSnWNZj5bzJ5Hipt6yHKc_003D).ToArray(), new Element[1]
		{
			new Hexa20(Enumerable.Range(0, 20), base.Material)
		});
		femMesh.Regen(0.0);
		SharedEdge[][] edges;
		ICurve[] array = femMesh.skin.Section(clippingPlane.Equation, out edges);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		LinearPath linearPath = (LinearPath)array[0];
		int num = linearPath.Vertices.Length;
		if (!linearPath.IsClosed)
		{
			num++;
		}
		double[] array2 = new double[20];
		PointSection[] array3 = new PointSection[num];
		for (int i = 0; i < linearPath.Vertices.Length; i++)
		{
			Point3D point3D = linearPath.Vertices[i];
			double _0023_003DzuwH5j5s_003D = 0.0;
			double _0023_003DzNDQ_E88_003D = 0.0;
			double _0023_003Dz77g161c_003D = 0.0;
			_0023_003DzLvDDD5THV4qo(point3D, femMesh.Vertices, array2, ref _0023_003DzuwH5j5s_003D, ref _0023_003DzNDQ_E88_003D, ref _0023_003Dz77g161c_003D);
			double value = 0.0;
			for (int j = 0; j < array2.Length; j++)
			{
				value += array2[j] * (double)((Node)_0023_003DzVU_0024BANoJ8daVCH4i1Q6enQ0_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[j]]).PlotValue;
			}
			if (legend != null)
			{
				Utility.LimitRange(legend.Min, ref value, legend.Max);
			}
			array3[i] = new PointSection(point3D.X, point3D.Y, point3D.Z, value);
		}
		if (num != linearPath.Vertices.Length)
		{
			_ = linearPath.Vertices[0];
			array3[num - 1] = (PointSection)array3[0].Clone();
		}
		return GetSlice(contourPlot, array3, clippingPlane, legend);
	}

	private bool _0023_003DzLvDDD5THV4qo(Point3D _0023_003Dzzo8RvXc_003D, Point3D[] _0023_003DzZ86NWzV6mlAE, double[] _0023_003DzwaU_0024oWk_003D, ref double _0023_003DzuwH5j5s_003D, ref double _0023_003DzNDQ_E88_003D, ref double _0023_003Dz77g161c_003D)
	{
		double num = 1E-10;
		double[,] array = new double[20, 3];
		double[,] array2 = new double[3, 3];
		double[,] array3 = new double[3, 3];
		double[] array4 = new double[3];
		double[] X = new double[3] { _0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D };
		int num2 = 0;
		do
		{
			_0023_003Dz8sBt3_0024SkdvSo(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz77g161c_003D, _0023_003DzwaU_0024oWk_003D, array);
			for (int i = 0; i < 3; i++)
			{
				array4[i] = 0.0;
			}
			for (int j = 0; j < _0023_003DzwaU_0024oWk_003D.Length; j++)
			{
				Point3D point3D = _0023_003DzZ86NWzV6mlAE[j];
				array4[0] += _0023_003DzwaU_0024oWk_003D[j] * point3D.X;
				array4[1] += _0023_003DzwaU_0024oWk_003D[j] * point3D.Y;
				array4[2] += _0023_003DzwaU_0024oWk_003D[j] * point3D.Z;
			}
			array4[0] -= _0023_003Dzzo8RvXc_003D.X;
			array4[1] -= _0023_003Dzzo8RvXc_003D.Y;
			array4[2] -= _0023_003Dzzo8RvXc_003D.Z;
			if (Math.Abs(array4[0]) < num && Math.Abs(array4[1]) < num && Math.Abs(array4[2]) < num)
			{
				return true;
			}
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					array2[k, l] = 0.0;
				}
			}
			for (int m = 0; m < 20; m++)
			{
				Point3D point3D2 = _0023_003DzZ86NWzV6mlAE[m];
				for (int n = 0; n < 3; n++)
				{
					array2[0, n] += array[m, n] * point3D2.X;
					array2[1, n] += array[m, n] * point3D2.Y;
					array2[2, n] += array[m, n] * point3D2.Z;
				}
			}
			for (int num3 = 0; num3 < 3; num3++)
			{
				for (int num4 = 0; num4 < 3; num4++)
				{
					double num5 = 0.0;
					for (int num6 = 0; num6 < 3; num6++)
					{
						num5 += array2[num3, num6] * array2[num4, num6];
					}
					array3[num3, num4] = num5;
				}
			}
			GaussianMethod.Solve(array3, array4, ref X);
			for (int num7 = 0; num7 < 3; num7++)
			{
				double num8 = 0.0;
				for (int num9 = 0; num9 < 3; num9++)
				{
					num8 += X[num9] * array2[num9, num7];
				}
				array4[num7] = num8;
			}
			_0023_003DzuwH5j5s_003D -= array4[0];
			_0023_003DzNDQ_E88_003D -= array4[1];
			_0023_003Dz77g161c_003D -= array4[2];
		}
		while (num2++ <= 5);
		_0023_003DzuwH5j5s_003D = double.NaN;
		_0023_003DzNDQ_E88_003D = double.NaN;
		_0023_003Dz77g161c_003D = double.NaN;
		return false;
	}

	internal override double[] _0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(Face _0023_003Dz3PZbRez_mP9t)
	{
		byte[] indices = _0023_003Dz3PZbRez_mP9t.Indices;
		Point3D point3D = null;
		if (indices[0] == 0)
		{
			if (indices[1] == 7)
			{
				point3D = new Point3D(0.0, 0.0, -1.0);
			}
			else if (indices[1] == 1)
			{
				point3D = new Point3D(0.0, -1.0, 0.0);
			}
		}
		else if (indices[0] == 6)
		{
			point3D = new Point3D(-1.0, 0.0, 0.0);
		}
		else if (indices[0] == 2)
		{
			point3D = new Point3D(1.0, 0.0, 0.0);
		}
		else if (indices[0] == 4)
		{
			point3D = new Point3D(0.0, 1.0, 0.0);
		}
		else if (indices[0] == 12)
		{
			point3D = new Point3D(0.0, 0.0, 1.0);
		}
		double[] array = new double[20];
		_0023_003Dz8sBt3_0024SkdvSo(point3D.X, point3D.Y, point3D.Z, array, new double[20, 3]);
		return array;
	}
}
