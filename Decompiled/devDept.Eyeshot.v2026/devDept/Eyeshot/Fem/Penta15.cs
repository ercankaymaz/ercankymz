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
public class Penta15 : Element3D
{
	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

		internal Point3D _0023_003Dz_ZMSnWNZj5bzJ5Hipt6yHKc_003D(int _0023_003Dzi9fncwc_003D)
		{
			return (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dzi9fncwc_003D].Clone();
		}
	}

	public Penta15(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, int nodeIndex5, int nodeIndex6, int nodeIndex7, int nodeIndex8, int nodeIndex9, int nodeIndex10, int nodeIndex11, int nodeIndex12, int nodeIndex13, int nodeIndex14, int nodeIndex15, Material mat)
		: this(new int[15]
		{
			nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4, nodeIndex5, nodeIndex6, nodeIndex7, nodeIndex8, nodeIndex9, nodeIndex10,
			nodeIndex11, nodeIndex12, nodeIndex13, nodeIndex14, nodeIndex15
		}, mat)
	{
	}

	public Penta15(IEnumerable<int> nodeIndices, Material mat)
		: base(15, mat)
	{
		NumberOfGaussPoints = 6;
		Connection = new int[NumberOfNodes];
		Connection = nodeIndices.ToArray();
		elFaces = new Face[5]
		{
			new Face(new byte[6] { 0, 5, 4, 3, 2, 1 }),
			new Face(new byte[8] { 0, 1, 2, 7, 11, 10, 9, 6 }),
			new Face(new byte[8] { 2, 3, 4, 8, 13, 12, 11, 7 }),
			new Face(new byte[8] { 4, 5, 0, 6, 9, 14, 13, 8 }),
			new Face(new byte[6] { 9, 10, 11, 12, 13, 14 })
		};
	}

	protected Penta15(Penta15 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Penta15(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemPenta15Surrogate(this);
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		int num = 0;
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
			num = i;
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
			_0023_003DzVRI6hgy90v33(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * (1.0 / 3.0) * 0.5;
			AssembleMassMatrix(array, dVolume);
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		int num = 0;
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
			num = i;
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
			_0023_003DzVRI6hgy90v33(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob3(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * (1.0 / 3.0) * 0.5;
			StiffnessComputation(num, cartDeriv, dvolu);
		}
		StiffnessComputation(nodes);
	}

	private static void _0023_003DzVRI6hgy90v33(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double _0023_003DzRpXgovo_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzVRI6hgy90v33(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, _0023_003DzwaU_0024oWk_003D, _0023_003DzmB17IaV5XzRN, out var _);
	}

	private static void _0023_003DzVRI6hgy90v33(double _0023_003DziMjqlCo_003D, double _0023_003DzI4dRPW0_003D, double _0023_003DzYEhafAA_003D, double _0023_003DzRpXgovo_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN, out double[,] _0023_003Dzoqf80331KnEe)
	{
		_0023_003Dzoqf80331KnEe = new double[15, 4];
		_0023_003DzwaU_0024oWk_003D[0] = 0.5 * _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[2] = 0.5 * _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[4] = 0.5 * _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[9] = 0.5 * _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[11] = 0.5 * _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[13] = 0.5 * _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[1] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[3] = 2.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[5] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[10] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[12] = 2.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[14] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[6] = _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[7] = _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003DzwaU_0024oWk_003D[8] = _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[0, 0] = 0.5 * (2.0 * _0023_003DziMjqlCo_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) + _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[2, 1] = 0.5 * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) + _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[4, 2] = 0.5 * (2.0 * _0023_003DzYEhafAA_003D - 1.0) * (1.0 - _0023_003DzRpXgovo_003D) + _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[9, 0] = 0.5 * (2.0 * _0023_003DziMjqlCo_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) + _0023_003DziMjqlCo_003D * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[11, 1] = 0.5 * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) + _0023_003DzI4dRPW0_003D * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[13, 2] = 0.5 * (2.0 * _0023_003DzYEhafAA_003D - 1.0) * (1.0 + _0023_003DzRpXgovo_003D) + _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D) - 0.5 * (1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[1, 0] = 2.0 * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[1, 1] = 2.0 * _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[3, 1] = 2.0 * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[3, 2] = 2.0 * _0023_003DzI4dRPW0_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[5, 0] = 2.0 * _0023_003DzYEhafAA_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[5, 2] = 2.0 * _0023_003DziMjqlCo_003D * (1.0 - _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[10, 0] = 2.0 * _0023_003DzI4dRPW0_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[10, 1] = 2.0 * _0023_003DziMjqlCo_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[12, 1] = 2.0 * _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[12, 2] = 2.0 * _0023_003DzI4dRPW0_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[14, 0] = 2.0 * _0023_003DzYEhafAA_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[14, 2] = 2.0 * _0023_003DziMjqlCo_003D * (1.0 + _0023_003DzRpXgovo_003D);
		_0023_003Dzoqf80331KnEe[6, 0] = 1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[7, 1] = 1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[8, 2] = 1.0 - _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[0, 3] = 0.0 - 0.5 * _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0) + _0023_003DziMjqlCo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[2, 3] = 0.0 - 0.5 * _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) + _0023_003DzI4dRPW0_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[4, 3] = 0.0 - 0.5 * _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0) + _0023_003DzYEhafAA_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[9, 3] = 0.5 * _0023_003DziMjqlCo_003D * (2.0 * _0023_003DziMjqlCo_003D - 1.0) + _0023_003DziMjqlCo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[11, 3] = 0.5 * _0023_003DzI4dRPW0_003D * (2.0 * _0023_003DzI4dRPW0_003D - 1.0) + _0023_003DzI4dRPW0_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[13, 3] = 0.5 * _0023_003DzYEhafAA_003D * (2.0 * _0023_003DzYEhafAA_003D - 1.0) + _0023_003DzYEhafAA_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[1, 3] = 0.0 - 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D;
		_0023_003Dzoqf80331KnEe[3, 3] = 0.0 - 2.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D;
		_0023_003Dzoqf80331KnEe[5, 3] = 0.0 - 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D;
		_0023_003Dzoqf80331KnEe[10, 3] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzI4dRPW0_003D;
		_0023_003Dzoqf80331KnEe[12, 3] = 2.0 * _0023_003DzI4dRPW0_003D * _0023_003DzYEhafAA_003D;
		_0023_003Dzoqf80331KnEe[14, 3] = 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzYEhafAA_003D;
		_0023_003Dzoqf80331KnEe[6, 3] = 0.0 - 2.0 * _0023_003DziMjqlCo_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[7, 3] = 0.0 - 2.0 * _0023_003DzI4dRPW0_003D * _0023_003DzRpXgovo_003D;
		_0023_003Dzoqf80331KnEe[8, 3] = 0.0 - 2.0 * _0023_003DzYEhafAA_003D * _0023_003DzRpXgovo_003D;
		for (int i = 0; i < 15; i++)
		{
			_0023_003DzmB17IaV5XzRN[i, 0] = _0023_003Dzoqf80331KnEe[i, 0] - _0023_003Dzoqf80331KnEe[i, 2];
			_0023_003DzmB17IaV5XzRN[i, 1] = _0023_003Dzoqf80331KnEe[i, 1] - _0023_003Dzoqf80331KnEe[i, 2];
			_0023_003DzmB17IaV5XzRN[i, 2] = _0023_003Dzoqf80331KnEe[i, 3];
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
			array2[j, 1] = 0.0 - 0.8660254037844384 * (array[j, 3] - array[j, 0]) + (array[j, 0] + array[j, 3]) / 2.0;
			array2[j, 3] = 0.0 - 0.8660254037844384 * (array[j, 4] - array[j, 1]) + (array[j, 1] + array[j, 4]) / 2.0;
			array2[j, 5] = 0.0 - 0.8660254037844384 * (array[j, 5] - array[j, 2]) + (array[j, 2] + array[j, 5]) / 2.0;
			array2[j, 10] = 0.8660254037844384 * (array[j, 3] - array[j, 0]) + (array[j, 0] + array[j, 3]) / 2.0;
			array2[j, 12] = 0.8660254037844384 * (array[j, 4] - array[j, 1]) + (array[j, 1] + array[j, 4]) / 2.0;
			array2[j, 14] = 0.8660254037844384 * (array[j, 5] - array[j, 2]) + (array[j, 2] + array[j, 5]) / 2.0;
			array2[j, 0] = array2[j, 5] + array2[j, 1] - array2[j, 3];
			array2[j, 2] = array2[j, 1] + array2[j, 3] - array2[j, 5];
			array2[j, 4] = array2[j, 3] + array2[j, 5] - array2[j, 1];
			array2[j, 9] = array2[j, 14] + array2[j, 10] - array2[j, 12];
			array2[j, 11] = array2[j, 10] + array2[j, 12] - array2[j, 14];
			array2[j, 13] = array2[j, 12] + array2[j, 14] - array2[j, 10];
			array2[j, 6] = (array2[j, 0] + array2[j, 9]) / 2.0;
			array2[j, 7] = (array2[j, 2] + array2[j, 11]) / 2.0;
			array2[j, 8] = (array2[j, 4] + array2[j, 13]) / 2.0;
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
			_0023_003DzVRI6hgy90v33(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzRpXgovo_003D, array2, array3);
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
			DrawFace6(context, singleColor, 0, vertices, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(context, singleColor, i, vertices, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace6(context, singleColor, 4, vertices, ampFactor, mode);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFace6(context, 0, vertices, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(context, i, vertices, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace6(context, 4, vertices, ampFactor, mode);
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFace6(context, 0, vertices, min, max, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				DrawFace8(context, i, vertices, min, max, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFace6(context, 4, vertices, min, max, ampFactor, mode);
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (elFaces[0].Visible)
		{
			DrawFaceElement6(context, 0, vertices, min, max, ampFactor, mode);
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				_0023_003Dz_0024pRElff8RWIV(context, i, vertices, min, max, ampFactor, mode);
			}
		}
		if (elFaces[4].Visible)
		{
			DrawFaceElement6(context, 4, vertices, min, max, ampFactor, mode);
		}
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		List<IndexTriangle> list = new List<IndexTriangle>();
		if (elFaces[0].Visible)
		{
			list.AddRange(GetFace6(elIndex, 0, vertices, ampFactor, centroids));
		}
		for (int i = 1; i < 4; i++)
		{
			if (elFaces[i].Visible)
			{
				list.AddRange(GetFace8(elIndex, i, vertices, ampFactor, centroids));
			}
		}
		if (elFaces[4].Visible)
		{
			list.AddRange(GetFace6(elIndex, 4, vertices, ampFactor, centroids));
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
		_0023_003Dzq0Uk7eeKzyVlc6ob1A_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
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
		_0023_003Dzq0Uk7eeKzyVlc6ob1A_003D_003D(nodes, _0023_003DzJvZCors_003D, faceIndex);
		base.SetPressure(faceIndex, pressure, nodes);
	}

	internal void _0023_003Dzq0Uk7eeKzyVlc6ob1A_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, Vector3D _0023_003DzJvZCors_003D, int _0023_003DzL8NvYU0_003D)
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
			array3 = new int[6];
			for (int k = 0; k < 6; k++)
			{
				array3[k] = elFaces[_0023_003DzL8NvYU0_003D].Indices[k];
			}
		}
		else
		{
			array3 = new int[8];
			for (int l = 0; l < 8; l++)
			{
				array3[l] = elFaces[_0023_003DzL8NvYU0_003D].Indices[l];
			}
		}
		if (flag)
		{
			for (int m = 1; m <= 3; m++)
			{
				double _0023_003DzgPsOl1A_003D;
				double _0023_003DzD5YCi2M_003D;
				double _0023_003Dz9_0024bIhS0_003D;
				double _0023_003DzbQkwuM0_003D;
				switch (m)
				{
				case 1:
					_0023_003DzgPsOl1A_003D = 0.5;
					_0023_003DzD5YCi2M_003D = 0.5;
					_0023_003Dz9_0024bIhS0_003D = 0.0;
					_0023_003DzbQkwuM0_003D = 1.0;
					break;
				case 2:
					_0023_003DzgPsOl1A_003D = 0.0;
					_0023_003DzD5YCi2M_003D = 0.5;
					_0023_003Dz9_0024bIhS0_003D = 0.5;
					_0023_003DzbQkwuM0_003D = 1.0;
					break;
				default:
					_0023_003DzgPsOl1A_003D = 0.5;
					_0023_003DzD5YCi2M_003D = 0.0;
					_0023_003Dz9_0024bIhS0_003D = 0.5;
					_0023_003DzbQkwuM0_003D = 1.0;
					break;
				}
				_0023_003DznHxD323XQtsall3J8w_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, out var _0023_003DzKjjYWhJTvaT_0024, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D);
				_0023_003DzJoqQbD5u3xR2LyPb4A_003D_003D(_0023_003DzKjjYWhJTvaT_0024, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D, array, array3, _0023_003DzbQkwuM0_003D);
			}
			return;
		}
		for (int n = 1; n <= 2; n++)
		{
			for (int num2 = 0; num2 < 2; num2++)
			{
				double[] obj = new double[2] { -0.577350269189626, 0.577350269189626 };
				double _0023_003DzuwH5j5s_003D = obj[n - 1];
				double _0023_003DzNDQ_E88_003D = obj[num2];
				_0023_003Dzf4wUc4yo_ghzsgmsIg_003D_003D(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, out var _0023_003DzKjjYWhJTvaT_00242, out var _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D2);
				_0023_003Dz4pc2H7of1UIr0YJRgw_003D_003D(_0023_003DzKjjYWhJTvaT_00242, array2, _0023_003Dzi7P_0024XNG5mdEqrUnHCQ_003D_003D2, array, array3);
			}
		}
	}

	public override void Refine(int s, int t, int r, FemMesh fm)
	{
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		List<int> _0023_003DzGoWUA5Q_003D = new List<int>();
		_0023_003DzK8EDfQ5Yw71v(r, fm, _0023_003DzGoWUA5Q_003D, list);
		List<Element> list2 = new List<Element>();
		list2.AddRange(fm.elements);
		for (int i = 0; i < r; i++)
		{
			_0023_003Dzsoo0Hdlh_0024LC5(_0023_003DzGoWUA5Q_003D, i, 6, list, list2);
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list2.ToArray();
	}

	private void _0023_003Dzsoo0Hdlh_0024LC5(List<int> _0023_003DzGoWUA5Q_003D, int _0023_003DzN6G05Lg_003D, int _0023_003DzeF_9RkSNRRYJ, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Element> _0023_003Dzzwxsafw_003D)
	{
		List<int> obj = new List<int>
		{
			_0023_003DzGoWUA5Q_003D[_0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ],
			_0023_003DzGoWUA5Q_003D[1 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ],
			_0023_003DzGoWUA5Q_003D[5 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ],
			_0023_003DzGoWUA5Q_003D[6 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ],
			_0023_003DzGoWUA5Q_003D[7 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ],
			_0023_003DzGoWUA5Q_003D[11 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]
		};
		Penta15 item = Penta6._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(obj.ToArray(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
		obj.Clear();
		obj.Add(_0023_003DzGoWUA5Q_003D[1 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[3 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[5 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[7 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[9 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[11 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		Penta15 item2 = Penta6._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(obj.ToArray(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
		obj.Clear();
		obj.Add(_0023_003DzGoWUA5Q_003D[1 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[2 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[3 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[7 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[8 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[9 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		Penta15 item3 = Penta6._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(obj.ToArray(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
		obj.Clear();
		obj.Add(_0023_003DzGoWUA5Q_003D[5 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[3 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[4 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[11 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[9 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		obj.Add(_0023_003DzGoWUA5Q_003D[10 + _0023_003DzN6G05Lg_003D * _0023_003DzeF_9RkSNRRYJ]);
		Penta15 item4 = Penta6._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(obj.ToArray(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
		_0023_003Dzzwxsafw_003D.Add(item);
		_0023_003Dzzwxsafw_003D.Add(item2);
		_0023_003Dzzwxsafw_003D.Add(item3);
		_0023_003Dzzwxsafw_003D.Add(item4);
	}

	private void _0023_003DzK8EDfQ5Yw71v(int _0023_003DzRpXgovo_003D, FemMesh _0023_003Dzkx0ud14_003D, List<int> _0023_003DzGoWUA5Q_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		Segment3D segment3D = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[0]], _0023_003Dzkx0ud14_003D.Vertices[Connection[9]]);
		Segment3D segment3D2 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[1]], _0023_003Dzkx0ud14_003D.Vertices[Connection[10]]);
		Segment3D segment3D3 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[2]], _0023_003Dzkx0ud14_003D.Vertices[Connection[11]]);
		Segment3D segment3D4 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[3]], _0023_003Dzkx0ud14_003D.Vertices[Connection[12]]);
		Segment3D segment3D5 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[4]], _0023_003Dzkx0ud14_003D.Vertices[Connection[13]]);
		Segment3D segment3D6 = new Segment3D(_0023_003Dzkx0ud14_003D.Vertices[Connection[5]], _0023_003Dzkx0ud14_003D.Vertices[Connection[14]]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[0]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[1]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[2]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[3]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[4]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[5]);
		for (int i = 1; i < _0023_003DzRpXgovo_003D; i++)
		{
			Point3D point3D = segment3D.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D3 = segment3D3.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D4 = segment3D4.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D5 = segment3D5.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			Point3D point3D6 = segment3D6.PointAt((double)i / (double)_0023_003DzRpXgovo_003D);
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D4.X, point3D4.Y, point3D4.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D5.X, point3D5.Y, point3D5.Z));
			_0023_003DzGoWUA5Q_003D.Add(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count);
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(point3D6.X, point3D6.Y, point3D6.Z));
		}
		_0023_003DzGoWUA5Q_003D.Add(Connection[9]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[10]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[11]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[12]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[13]);
		_0023_003DzGoWUA5Q_003D.Add(Connection[14]);
	}

	public override Mesh SliceElementWithPlane(bool contourPlot, Plane clippingPlane, Point3D[] vertices, Size3D size, ILegend legend)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D = vertices;
		FemMesh femMesh = new FemMesh(Connection.Select(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz_ZMSnWNZj5bzJ5Hipt6yHKc_003D).ToArray(), new Element[1]
		{
			new Penta15(Enumerable.Range(0, 15), base.Material)
		});
		femMesh.Regen(0.0);
		femMesh.skin.Regen(0.0);
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
		double[] array2 = new double[15];
		PointSection[] array3 = new PointSection[num];
		for (int i = 0; i < linearPath.Vertices.Length; i++)
		{
			Point3D point3D = linearPath.Vertices[i];
			double _0023_003DziMjqlCo_003D = 0.0;
			double _0023_003DzI4dRPW0_003D = 0.0;
			double _0023_003DzYEhafAA_003D = 0.0;
			double _0023_003DzId5C3LA_003D = 0.0;
			_0023_003DzLvDDD5THV4qo(point3D, femMesh.Vertices, array2, ref _0023_003DziMjqlCo_003D, ref _0023_003DzI4dRPW0_003D, ref _0023_003DzYEhafAA_003D, ref _0023_003DzId5C3LA_003D);
			double num2 = 0.0;
			for (int j = 0; j < array2.Length; j++)
			{
				num2 += array2[j] * (double)((Node)_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[j]]).PlotValue;
			}
			array3[i] = new PointSection(point3D.X, point3D.Y, point3D.Z, num2);
		}
		if (num != linearPath.Vertices.Length)
		{
			_ = linearPath.Vertices[0];
			array3[num - 1] = (PointSection)array3[0].Clone();
		}
		return GetSlice(contourPlot, array3, clippingPlane, legend);
	}

	private bool _0023_003DzLvDDD5THV4qo(Point3D _0023_003Dzzo8RvXc_003D, Point3D[] _0023_003DzZ86NWzV6mlAE, double[] _0023_003DzwaU_0024oWk_003D, ref double _0023_003DziMjqlCo_003D, ref double _0023_003DzI4dRPW0_003D, ref double _0023_003DzYEhafAA_003D, ref double _0023_003DzId5C3LA_003D)
	{
		double num = 1E-10;
		double[,] _0023_003DzmB17IaV5XzRN = new double[15, 3];
		double[,] array = new double[4, 4];
		double[,] array2 = new double[4, 4];
		double[] array3 = new double[4];
		double[] X = new double[4] { _0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzId5C3LA_003D };
		int num2 = 0;
		do
		{
			_0023_003DzVRI6hgy90v33(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzYEhafAA_003D, _0023_003DzId5C3LA_003D, _0023_003DzwaU_0024oWk_003D, _0023_003DzmB17IaV5XzRN, out var _0023_003Dzoqf80331KnEe);
			for (int i = 0; i < 3; i++)
			{
				array3[i] = 0.0;
			}
			for (int j = 0; j < _0023_003DzwaU_0024oWk_003D.Length; j++)
			{
				Point3D point3D = _0023_003DzZ86NWzV6mlAE[j];
				array3[0] += _0023_003DzwaU_0024oWk_003D[j] * point3D.X;
				array3[1] += _0023_003DzwaU_0024oWk_003D[j] * point3D.Y;
				array3[2] += _0023_003DzwaU_0024oWk_003D[j] * point3D.Z;
			}
			array3[0] -= _0023_003Dzzo8RvXc_003D.X;
			array3[1] -= _0023_003Dzzo8RvXc_003D.Y;
			array3[2] -= _0023_003Dzzo8RvXc_003D.Z;
			array3[3] = _0023_003DziMjqlCo_003D + _0023_003DzI4dRPW0_003D + _0023_003DzYEhafAA_003D - 1.0;
			if (Math.Abs(array3[0]) < num && Math.Abs(array3[1]) < num && Math.Abs(array3[2]) < num && Math.Abs(array3[3]) < num)
			{
				return true;
			}
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					array[k, l] = 0.0;
				}
			}
			for (int m = 0; m < _0023_003DzwaU_0024oWk_003D.Length; m++)
			{
				Point3D point3D2 = _0023_003DzZ86NWzV6mlAE[m];
				for (int n = 0; n < 4; n++)
				{
					array[0, n] += _0023_003Dzoqf80331KnEe[m, n] * point3D2.X;
					array[1, n] += _0023_003Dzoqf80331KnEe[m, n] * point3D2.Y;
					array[2, n] += _0023_003Dzoqf80331KnEe[m, n] * point3D2.Z;
				}
			}
			array[3, 0] = 1.0;
			array[3, 1] = 1.0;
			array[3, 2] = 1.0;
			array[3, 3] = 0.0;
			double[,] array4 = new double[3, 15];
			for (int num3 = 0; num3 < 15; num3++)
			{
				Point3D point3D3 = _0023_003DzZ86NWzV6mlAE[num3];
				array4[0, num3] = point3D3.X;
				array4[1, num3] = point3D3.Y;
				array4[2, num3] = point3D3.Z;
			}
			Matrix.Multiply(array4, _0023_003Dzoqf80331KnEe);
			for (int num4 = 0; num4 < 4; num4++)
			{
				for (int num5 = 0; num5 < 4; num5++)
				{
					double num6 = 0.0;
					for (int num7 = 0; num7 < 4; num7++)
					{
						num6 += array[num4, num7] * array[num5, num7];
					}
					array2[num4, num5] = num6;
				}
			}
			GaussianMethod.Solve(array2, array3, ref X);
			for (int num8 = 0; num8 < 4; num8++)
			{
				double num9 = 0.0;
				for (int num10 = 0; num10 < 4; num10++)
				{
					num9 += X[num10] * array[num10, num8];
				}
				array3[num8] = num9;
			}
			_0023_003DziMjqlCo_003D -= array3[0];
			_0023_003DzI4dRPW0_003D -= array3[1];
			_0023_003DzYEhafAA_003D -= array3[2];
			_0023_003DzId5C3LA_003D -= array3[3];
		}
		while (num2++ <= 5);
		_0023_003DziMjqlCo_003D = double.NaN;
		_0023_003DzI4dRPW0_003D = double.NaN;
		_0023_003DzYEhafAA_003D = double.NaN;
		return false;
	}

	internal override double[] _0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(Face _0023_003Dz3PZbRez_mP9t)
	{
		byte[] indices = _0023_003Dz3PZbRez_mP9t.Indices;
		double[] array = new double[15];
		if (indices[0] == 0)
		{
			_0023_003DzVRI6hgy90v33(0.5, 0.5, 0.0, 0.0, array, new double[15, 4]);
		}
		else if (indices[0] == 2)
		{
			_0023_003DzVRI6hgy90v33(0.0, 0.5, 0.5, 0.0, array, new double[15, 4]);
		}
		else
		{
			_0023_003DzVRI6hgy90v33(0.5, 0.0, 0.5, 0.0, array, new double[15, 4]);
		}
		return array;
	}
}
