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
public class Quad4 : Element2D
{
	public Quad4(int nodeIndex1, int nodeIndex2, int nodeIndex3, int nodeIndex4, Material mat)
		: this(new int[4] { nodeIndex1, nodeIndex2, nodeIndex3, nodeIndex4 }, mat)
	{
	}

	public Quad4(IEnumerable<int> nodeIndices, Material mat)
		: base(4, mat)
	{
		NumberOfGaussPoints = 4;
		Connection = nodeIndices.ToArray();
		elEdges = new Edge[4]
		{
			new Edge(new byte[2] { 0, 1 }),
			new Edge(new byte[2] { 1, 2 }),
			new Edge(new byte[2] { 2, 3 }),
			new Edge(new byte[2] { 3, 0 })
		};
		elFaces = new Face[1]
		{
			new Face(new byte[4] { 0, 1, 2, 3 })
		};
	}

	protected Quad4(Quad4 another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new Quad4(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemQuad4Surrogate(this);
	}

	internal void _0023_003DzyWdJ4nflae0e(Point3D[] _0023_003DzDvuIQCU_003D)
	{
		if (_0023_003DzDvuIQCU_003D[Connection[0]] is NodeBeam && _0023_003DzDvuIQCU_003D[Connection[1]] is NodeBeam && _0023_003DzDvuIQCU_003D[Connection[2]] is NodeBeam && _0023_003DzDvuIQCU_003D[Connection[3]] is NodeBeam)
		{
			NumberOfDimensions = 3;
			NumberOfDofPerNode = 6;
			NumberOfGaussPoints = 8;
			NumberOfStressesPerNode = 6;
		}
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		double _0023_003DzBFhdx14hKg_h = 1.0;
		if (base.Material.ElementType == elementType.PlaneStress)
		{
			_0023_003DzBFhdx14hKg_h = base.Material.ElementThickness;
		}
		M = new double[base.TotalDof, base.TotalDof];
		if (nodes[Connection[0]] is NodeBeam && nodes[Connection[1]] is NodeBeam && nodes[Connection[2]] is NodeBeam && nodes[Connection[3]] is NodeBeam)
		{
			_0023_003DztZoZxKLoQr3m_0024qhVuw_003D_003D(nodes, elemIndex, lumpMass, _0023_003DzBFhdx14hKg_h);
			return;
		}
		int num = 0;
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
			_0023_003Dz3UeRax27BOx3(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dVolume = detJacob * gpWeight[0] * gpWeight[0];
			AssembleMassMatrix(array, dVolume);
		}
	}

	private void _0023_003DztZoZxKLoQr3m_0024qhVuw_003D_003D(Point3D[] _0023_003DzDvuIQCU_003D, int _0023_003DziLhQ6oA_003D, bool _0023_003Dz6lNmKJpyuXKwcmbAjw_003D_003D, double _0023_003DzBFhdx14hKg_h)
	{
		double[] array = _0023_003DzDvuIQCU_003D[Connection[0]].ToArray();
		double[] array2 = _0023_003DzDvuIQCU_003D[Connection[1]].ToArray();
		double[] array3 = _0023_003DzDvuIQCU_003D[Connection[2]].ToArray();
		double[] array4 = _0023_003DzDvuIQCU_003D[Connection[3]].ToArray();
		double[,] a = Matrix.CreateMatrixFromVectors(new double[4][] { array, array2, array3, array4 }, asRows: false);
		Vector3D vector3D = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[1]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[3]]));
		Vector3D vector3D2 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[2]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[0]]));
		Vector3D vector3D3 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[3]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[1]]));
		Vector3D vector3D4 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[0]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[2]]));
		vector3D.Normalize();
		vector3D2.Normalize();
		vector3D3.Normalize();
		vector3D4.Normalize();
		double[,] a2 = Matrix.CreateMatrixFromVectors(new double[4][]
		{
			vector3D.ToArray(),
			vector3D2.ToArray(),
			vector3D3.ToArray(),
			vector3D4.ToArray()
		}, asRows: false);
		double num = 1.0 / Math.Sqrt(3.0);
		Point4D[] array5 = new Point4D[8]
		{
			new Point4D(0.0 - num, 0.0 - num, 0.0 - num, 1.0),
			new Point4D(0.0 - num, 0.0 - num, num, 1.0),
			new Point4D(0.0 - num, num, 0.0 - num, 1.0),
			new Point4D(0.0 - num, num, num, 1.0),
			new Point4D(num, 0.0 - num, 0.0 - num, 1.0),
			new Point4D(num, 0.0 - num, num, 1.0),
			new Point4D(num, num, 0.0 - num, 1.0),
			new Point4D(num, num, num, 1.0)
		};
		for (int i = 0; i < array5.GetLength(0); i++)
		{
			double x = array5[i].X;
			double y = array5[i].Y;
			double z = array5[i].Z;
			double w = array5[i].W;
			double[] array6 = new double[4]
			{
				0.25 * (1.0 - x) * (1.0 - y),
				0.25 * (1.0 + x) * (1.0 - y),
				0.25 * (1.0 + x) * (1.0 + y),
				0.25 * (1.0 - x) * (1.0 + y)
			};
			double[] b = new double[4]
			{
				-0.25 * (1.0 - y),
				0.25 * (1.0 - y),
				0.25 * (1.0 + y),
				-0.25 * (1.0 + y)
			};
			double[] b2 = new double[4]
			{
				-0.25 * (1.0 - x),
				-0.25 * (1.0 + x),
				0.25 * (1.0 + x),
				0.25 * (1.0 - x)
			};
			Vector3D vector3D5 = new Vector3D(Matrix.Multiply(a, b));
			Vector3D vector3D6 = new Vector3D(Matrix.Multiply(a, b2));
			Vector3D vector3D7 = new Vector3D(Matrix.Multiply(a2, array6));
			Vector3D vector3D8 = new Vector3D(Matrix.Multiply(a2, b));
			Vector3D vector3D9 = new Vector3D(Matrix.Multiply(a2, b2));
			Vector3D vector3D10 = new Vector3D(vector3D5.X + z * _0023_003DzBFhdx14hKg_h * vector3D8.X / 2.0, vector3D5.Y + z * _0023_003DzBFhdx14hKg_h * vector3D8.Y / 2.0, vector3D5.Z + z * _0023_003DzBFhdx14hKg_h * vector3D8.Z / 2.0);
			Vector3D vector3D11 = new Vector3D(vector3D6.X + z * _0023_003DzBFhdx14hKg_h * vector3D9.X / 2.0, vector3D6.Y + z * _0023_003DzBFhdx14hKg_h * vector3D9.Y / 2.0, vector3D6.Z + z * _0023_003DzBFhdx14hKg_h * vector3D9.Z / 2.0);
			Vector3D vector3D12 = new Vector3D(_0023_003DzBFhdx14hKg_h * vector3D7.X / 2.0, _0023_003DzBFhdx14hKg_h * vector3D7.Y / 2.0, _0023_003DzBFhdx14hKg_h * vector3D7.Z / 2.0);
			_0023_003DzOYVb4B_0024UEzh3(vector3D12, vector3D11, out var _, out var _, out var _0023_003DzOC64tNw_003D, out var _);
			double num2 = vector3D10 * Vector3D.Cross(vector3D11, vector3D12);
			if (num2 <= 0.0)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985172) + _0023_003DziLhQ6oA_003D);
			}
			double num3 = w * num2;
			double[,] array7 = new double[3, 3];
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					array7[j, k] = mat.Density * (((j == k) ? 1E-10 : 0.0) + -9.99999E-11 * _0023_003DzOC64tNw_003D[j] * _0023_003DzOC64tNw_003D[k]);
				}
			}
			if (_0023_003Dz6lNmKJpyuXKwcmbAjw_003D_003D)
			{
				for (int l = 0; l < NumberOfNodes; l++)
				{
					double num4 = num3 * mat.Density * array6[l];
					int num5 = l * NumberOfDofPerNode;
					M[num5, num5] += num4;
					M[num5 + 1, num5 + 1] += num4;
					M[num5 + 2, num5 + 2] += num4;
				}
			}
			else
			{
				for (int m = 0; m < NumberOfNodes; m++)
				{
					for (int n = 0; n < NumberOfNodes; n++)
					{
						double num6 = num3 * mat.Density * array6[m] * array6[n];
						int num7 = m * NumberOfDofPerNode;
						int num8 = n * NumberOfDofPerNode;
						M[num7, num8] += num6;
						M[num7 + 1, num8 + 1] += num6;
						M[num7 + 2, num8 + 2] += num6;
					}
				}
			}
			for (int num9 = 0; num9 < NumberOfNodes; num9++)
			{
				double num10 = num3 * array6[num9] * array6[num9];
				int num11 = num9 * NumberOfDofPerNode + 3;
				for (int num12 = 0; num12 < 3; num12++)
				{
					for (int num13 = 0; num13 < 3; num13++)
					{
						M[num11 + num12, num11 + num13] += num10 * array7[num12, num13];
					}
				}
			}
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		double num = 1.0;
		if (base.Material.ElementType == elementType.PlaneStress)
		{
			num = base.Material.ElementThickness;
		}
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		if (nodes[Connection[0]] is NodeBeam && nodes[Connection[1]] is NodeBeam && nodes[Connection[2]] is NodeBeam && nodes[Connection[3]] is NodeBeam)
		{
			_0023_003DzIuwGTEzcO9kzlWlH_0024zxDeMOWmcIy(nodes, elemIndex, num);
			StiffnessComputation(nodes);
			return;
		}
		int num2 = 0;
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array = new double[NumberOfNodes];
		double[,] array2 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DzuwH5j5s_003D = 0.0;
		double _0023_003DzNDQ_E88_003D = 0.0;
		for (int i = 1; i <= 4; i++)
		{
			num2++;
			if (num2 == 1)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num2 == 2)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[0];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			if (num2 == 3)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[0];
			}
			if (num2 == 4)
			{
				_0023_003DzuwH5j5s_003D = gpPosition[1];
				_0023_003DzNDQ_E88_003D = gpPosition[1];
			}
			_0023_003Dz3UeRax27BOx3(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array, array2);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num2, elemIndex, nodes, array, array2, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * gpWeight[0] * gpWeight[0];
			StiffnessComputation(num2, array, cartDeriv, gaussPoints, dvolu, num);
		}
		StiffnessComputation(nodes);
	}

	private void _0023_003Dz3UeRax27BOx3(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, double[] _0023_003DzwaU_0024oWk_003D, double[,] _0023_003DzmB17IaV5XzRN)
	{
		_0023_003DzwaU_0024oWk_003D[0] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzwaU_0024oWk_003D[1] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzwaU_0024oWk_003D[2] = (1.0 + _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzwaU_0024oWk_003D[3] = (1.0 - _0023_003DzuwH5j5s_003D) * (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzmB17IaV5XzRN[0, 0] = (0.0 - (1.0 - _0023_003DzNDQ_E88_003D)) / 4.0;
		_0023_003DzmB17IaV5XzRN[1, 0] = (1.0 - _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzmB17IaV5XzRN[2, 0] = (1.0 + _0023_003DzNDQ_E88_003D) / 4.0;
		_0023_003DzmB17IaV5XzRN[3, 0] = (0.0 - (1.0 + _0023_003DzNDQ_E88_003D)) / 4.0;
		_0023_003DzmB17IaV5XzRN[0, 1] = (0.0 - (1.0 - _0023_003DzuwH5j5s_003D)) / 4.0;
		_0023_003DzmB17IaV5XzRN[1, 1] = (0.0 - (1.0 + _0023_003DzuwH5j5s_003D)) / 4.0;
		_0023_003DzmB17IaV5XzRN[2, 1] = (1.0 + _0023_003DzuwH5j5s_003D) / 4.0;
		_0023_003DzmB17IaV5XzRN[3, 1] = (1.0 - _0023_003DzuwH5j5s_003D) / 4.0;
	}

	private void _0023_003DzIuwGTEzcO9kzlWlH_0024zxDeMOWmcIy(Point3D[] _0023_003DzDvuIQCU_003D, int _0023_003DziLhQ6oA_003D, double _0023_003DzBFhdx14hKg_h)
	{
		double[] array = _0023_003DzDvuIQCU_003D[Connection[0]].ToArray();
		double[] array2 = _0023_003DzDvuIQCU_003D[Connection[1]].ToArray();
		double[] array3 = _0023_003DzDvuIQCU_003D[Connection[2]].ToArray();
		double[] array4 = _0023_003DzDvuIQCU_003D[Connection[3]].ToArray();
		double[,] _0023_003DzghVYKJ4_003D = Matrix.CreateMatrixFromVectors(new double[4][] { array, array2, array3, array4 }, asRows: false);
		Vector3D vector3D = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[1]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[3]]));
		Vector3D vector3D2 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[2]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[0]]));
		Vector3D vector3D3 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[3]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[1]]));
		Vector3D vector3D4 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[0]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[2]]));
		vector3D.Normalize();
		vector3D2.Normalize();
		vector3D3.Normalize();
		vector3D4.Normalize();
		double[,] array5 = Matrix.CreateMatrixFromVectors(new double[4][]
		{
			vector3D.ToArray(),
			vector3D2.ToArray(),
			vector3D3.ToArray(),
			vector3D4.ToArray()
		}, asRows: false);
		Vector3D a = new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]].X - _0023_003DzDvuIQCU_003D[Connection[0]].X, _0023_003DzDvuIQCU_003D[Connection[2]].Y - _0023_003DzDvuIQCU_003D[Connection[0]].Y, _0023_003DzDvuIQCU_003D[Connection[2]].Z - _0023_003DzDvuIQCU_003D[Connection[0]].Z);
		Vector3D b = new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]].X - _0023_003DzDvuIQCU_003D[Connection[1]].X, _0023_003DzDvuIQCU_003D[Connection[3]].Y - _0023_003DzDvuIQCU_003D[Connection[1]].Y, _0023_003DzDvuIQCU_003D[Connection[3]].Z - _0023_003DzDvuIQCU_003D[Connection[1]].Z);
		double num = 0.5 * Vector3D.Cross(a, b).Length;
		double[,] a2 = new double[6, 6]
		{
			{
				mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				mat.Poisson * mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				0.0,
				0.0,
				0.0,
				0.0
			},
			{
				mat.Poisson * mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				0.0,
				0.0,
				0.0,
				0.0
			},
			{ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
			{
				0.0,
				0.0,
				0.0,
				mat.Young / (2.0 + 2.0 * mat.Poisson),
				0.0,
				0.0
			},
			{
				0.0,
				0.0,
				0.0,
				0.0,
				5.0 * mat.Young / (12.0 + 12.0 * mat.Poisson),
				0.0
			},
			{
				0.0,
				0.0,
				0.0,
				0.0,
				0.0,
				5.0 * mat.Young / (12.0 + 12.0 * mat.Poisson)
			}
		};
		_0023_003DzIYZUJc9jJi_uSlxV9vwOVw2sSUP9(_0023_003DzBFhdx14hKg_h, _0023_003DzghVYKJ4_003D, array5, out var _0023_003Dz586LM_jbBebO, out var _0023_003DzVQPWxL3v6tIG);
		double num2 = 1.0 / Math.Sqrt(3.0);
		Point4D[] array6 = new Point4D[8]
		{
			new Point4D(0.0 - num2, 0.0 - num2, 0.0 - num2, 1.0),
			new Point4D(0.0 - num2, 0.0 - num2, num2, 1.0),
			new Point4D(0.0 - num2, num2, 0.0 - num2, 1.0),
			new Point4D(0.0 - num2, num2, num2, 1.0),
			new Point4D(num2, 0.0 - num2, 0.0 - num2, 1.0),
			new Point4D(num2, 0.0 - num2, num2, 1.0),
			new Point4D(num2, num2, 0.0 - num2, 1.0),
			new Point4D(num2, num2, num2, 1.0)
		};
		for (int i = 0; i < array6.GetLength(0); i++)
		{
			B = _0023_003DzhUTKKHJLW_c8HGBtIg_003D_003D(_0023_003DzBFhdx14hKg_h, _0023_003DzghVYKJ4_003D, array5, _0023_003Dz586LM_jbBebO, _0023_003DzVQPWxL3v6tIG, array6[i], _0023_003DziLhQ6oA_003D, out var _0023_003Dzujbp9cCPSfk_0024, out var _0023_003DzwFoJ3JyJ3FK_0024);
			double[,] b2 = Matrix.Multiply(a2, B);
			double[,] array7 = Matrix.Multiply(_0023_003DzwFoJ3JyJ3FK_0024, b2);
			for (int j = 0; j < NumberOfStressesPerNode; j++)
			{
				for (int k = 0; k < base.TotalDof; k++)
				{
					StressMatrix[i, k, j] = array7[j, k];
				}
			}
			double[,] array8 = Matrix.Multiply(Matrix.Transpose(B), b2);
			for (int l = 0; l < base.TotalDof; l++)
			{
				for (int m = 0; m < base.TotalDof; m++)
				{
					K[l, m] += array6[i].W * _0023_003Dzujbp9cCPSfk_0024 * array8[l, m];
				}
			}
		}
		double num3 = 1E-12 * mat.Young * num * _0023_003DzBFhdx14hKg_h;
		for (int n = 0; n < NumberOfNodes; n++)
		{
			Vector3D vector3D5 = new Vector3D(array5[0, n], array5[1, n], array5[2, n]);
			for (int num4 = 0; num4 < 3; num4++)
			{
				for (int num5 = 0; num5 < 3; num5++)
				{
					double num6 = num3 * vector3D5[num4] * vector3D5[num5];
					int num7 = n * 6 + 3 + num4;
					int num8 = n * 6 + 3 + num5;
					K[num7, num8] += num6;
				}
			}
		}
	}

	private void _0023_003DzIYZUJc9jJi_uSlxV9vwOVw2sSUP9(double _0023_003DzBFhdx14hKg_h, double[,] _0023_003DzghVYKJ4_003D, double[,] _0023_003Dz9TW2RR8_003D, out double[][] _0023_003Dz586LM_jbBebO, out double[][] _0023_003DzVQPWxL3v6tIG)
	{
		double[,] array = new double[4, 2]
		{
			{ 0.0, 1.0 },
			{ 0.0, -1.0 },
			{ 1.0, 0.0 },
			{ -1.0, 0.0 }
		};
		_0023_003Dz586LM_jbBebO = new double[array.GetLength(0)][];
		_0023_003DzVQPWxL3v6tIG = new double[array.GetLength(0)][];
		for (int i = 0; i < array.GetLength(0); i++)
		{
			double num = array[i, 0];
			double num2 = array[i, 1];
			double[] array2 = new double[4]
			{
				0.25 * (1.0 - num) * (1.0 - num2),
				0.25 * (1.0 + num) * (1.0 - num2),
				0.25 * (1.0 + num) * (1.0 + num2),
				0.25 * (1.0 - num) * (1.0 + num2)
			};
			double[] array3 = new double[4]
			{
				-0.25 * (1.0 - num2),
				0.25 * (1.0 - num2),
				0.25 * (1.0 + num2),
				-0.25 * (1.0 + num2)
			};
			double[] array4 = new double[4]
			{
				-0.25 * (1.0 - num),
				-0.25 * (1.0 + num),
				0.25 * (1.0 + num),
				0.25 * (1.0 - num)
			};
			Vector3D vector3D = new Vector3D(Matrix.Multiply(_0023_003DzghVYKJ4_003D, array3));
			Vector3D vector3D2 = new Vector3D(Matrix.Multiply(_0023_003DzghVYKJ4_003D, array4));
			Vector3D vector3D3 = new Vector3D(Matrix.Multiply(_0023_003Dz9TW2RR8_003D, array2));
			Vector3D vector3D4 = new Vector3D(vector3D.X, vector3D.Y, vector3D.Z);
			Vector3D vector3D5 = new Vector3D(vector3D2.X, vector3D2.Y, vector3D2.Z);
			Vector3D vector3D6 = new Vector3D(_0023_003DzBFhdx14hKg_h * vector3D3.X / 2.0, _0023_003DzBFhdx14hKg_h * vector3D3.Y / 2.0, _0023_003DzBFhdx14hKg_h * vector3D3.Z / 2.0);
			_0023_003Dz16oBYCA_SMLLcV5DxZEO0jI_003D(array2, array3, array4, _0023_003DzBFhdx14hKg_h, _0023_003Dz9TW2RR8_003D, out var _0023_003DzSZY4TyU_003D, out var _0023_003Dz2fxfrto_003D, out var _0023_003Dz_CJJjm8_003D, 0.0);
			_0023_003Dz586LM_jbBebO[i] = Matrix.Sum(Matrix.Multiply(_0023_003DzSZY4TyU_003D, (vector3D6 * 0.5).ToArray()), Matrix.Multiply(_0023_003Dz_CJJjm8_003D, (vector3D4 * 0.5).ToArray()));
			_0023_003DzVQPWxL3v6tIG[i] = Matrix.Sum(Matrix.Multiply(_0023_003Dz2fxfrto_003D, (vector3D6 * 0.5).ToArray()), Matrix.Multiply(_0023_003Dz_CJJjm8_003D, (vector3D5 * 0.5).ToArray()));
		}
	}

	private double[,] _0023_003DzhUTKKHJLW_c8HGBtIg_003D_003D(double _0023_003DzBFhdx14hKg_h, double[,] _0023_003DzghVYKJ4_003D, double[,] _0023_003Dz9TW2RR8_003D, double[][] _0023_003Dz586LM_jbBebO, double[][] _0023_003DzVQPWxL3v6tIG, Point4D _0023_003Dzuc1aA5o_003D, int _0023_003DziLhQ6oA_003D, out double _0023_003Dzujbp9cCPSfk_0024, out double[,] _0023_003DzwFoJ3JyJ3FK_0024)
	{
		double x = _0023_003Dzuc1aA5o_003D.X;
		double y = _0023_003Dzuc1aA5o_003D.Y;
		double z = _0023_003Dzuc1aA5o_003D.Z;
		double[] array = new double[4]
		{
			0.25 * (1.0 - x) * (1.0 - y),
			0.25 * (1.0 + x) * (1.0 - y),
			0.25 * (1.0 + x) * (1.0 + y),
			0.25 * (1.0 - x) * (1.0 + y)
		};
		double[] array2 = new double[4]
		{
			-0.25 * (1.0 - y),
			0.25 * (1.0 - y),
			0.25 * (1.0 + y),
			-0.25 * (1.0 + y)
		};
		double[] array3 = new double[4]
		{
			-0.25 * (1.0 - x),
			-0.25 * (1.0 + x),
			0.25 * (1.0 + x),
			0.25 * (1.0 - x)
		};
		Vector3D vector3D = new Vector3D(Matrix.Multiply(_0023_003DzghVYKJ4_003D, array2));
		Vector3D vector3D2 = new Vector3D(Matrix.Multiply(_0023_003DzghVYKJ4_003D, array3));
		Vector3D vector3D3 = new Vector3D(Matrix.Multiply(_0023_003Dz9TW2RR8_003D, array));
		Vector3D vector3D4 = new Vector3D(Matrix.Multiply(_0023_003Dz9TW2RR8_003D, array2));
		Vector3D vector3D5 = new Vector3D(Matrix.Multiply(_0023_003Dz9TW2RR8_003D, array3));
		Vector3D vector3D6 = new Vector3D(vector3D.X + z * _0023_003DzBFhdx14hKg_h * vector3D4.X / 2.0, vector3D.Y + z * _0023_003DzBFhdx14hKg_h * vector3D4.Y / 2.0, vector3D.Z + z * _0023_003DzBFhdx14hKg_h * vector3D4.Z / 2.0);
		Vector3D vector3D7 = new Vector3D(vector3D2.X + z * _0023_003DzBFhdx14hKg_h * vector3D5.X / 2.0, vector3D2.Y + z * _0023_003DzBFhdx14hKg_h * vector3D5.Y / 2.0, vector3D2.Z + z * _0023_003DzBFhdx14hKg_h * vector3D5.Z / 2.0);
		Vector3D vector3D8 = new Vector3D(_0023_003DzBFhdx14hKg_h * vector3D3.X / 2.0, _0023_003DzBFhdx14hKg_h * vector3D3.Y / 2.0, _0023_003DzBFhdx14hKg_h * vector3D3.Z / 2.0);
		_0023_003DzOYVb4B_0024UEzh3(vector3D8, vector3D7, out var _0023_003Dz2T4sy2I_003D, out var _0023_003DzO91j_0024fQ_003D, out var _0023_003DzOC64tNw_003D, out _0023_003DzwFoJ3JyJ3FK_0024);
		_0023_003Dzujbp9cCPSfk_0024 = vector3D6 * Vector3D.Cross(vector3D7, vector3D8);
		if (_0023_003Dzujbp9cCPSfk_0024 <= 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985172) + _0023_003DziLhQ6oA_003D);
		}
		Vector3D vector3D9 = Vector3D.Cross(vector3D7, vector3D8) / _0023_003Dzujbp9cCPSfk_0024;
		Vector3D vector3D10 = Vector3D.Cross(vector3D8, vector3D6) / _0023_003Dzujbp9cCPSfk_0024;
		Vector3D vector3D11 = Vector3D.Cross(vector3D6, vector3D7) / _0023_003Dzujbp9cCPSfk_0024;
		_0023_003Dz16oBYCA_SMLLcV5DxZEO0jI_003D(array, array2, array3, _0023_003DzBFhdx14hKg_h, _0023_003Dz9TW2RR8_003D, out var _0023_003DzSZY4TyU_003D, out var _0023_003Dz2fxfrto_003D, out var _, z);
		double[] array4 = Matrix.Multiply(_0023_003DzSZY4TyU_003D, vector3D6.ToArray());
		double[] array5 = Matrix.Multiply(_0023_003Dz2fxfrto_003D, vector3D7.ToArray());
		double[] array6 = Matrix.Sum(Matrix.Multiply(_0023_003DzSZY4TyU_003D, (0.5 * vector3D7).ToArray()), Matrix.Multiply(_0023_003Dz2fxfrto_003D, (0.5 * vector3D6).ToArray()));
		double[] array7 = new double[base.TotalDof];
		double[] array8 = new double[base.TotalDof];
		for (int i = 0; i < base.TotalDof; i++)
		{
			array7[i] = (1.0 + y) * _0023_003Dz586LM_jbBebO[0][i] / 2.0 + (1.0 - y) * _0023_003Dz586LM_jbBebO[1][i] / 2.0;
			array8[i] = (1.0 + x) * _0023_003DzVQPWxL3v6tIG[2][i] / 2.0 + (1.0 - x) * _0023_003DzVQPWxL3v6tIG[3][i] / 2.0;
		}
		double[] array9 = new double[base.TotalDof];
		double[] array10 = new double[base.TotalDof];
		double[] array11 = new double[base.TotalDof];
		double[] array12 = new double[base.TotalDof];
		double[] array13 = new double[base.TotalDof];
		double[] array14 = new double[base.TotalDof];
		for (int j = 0; j < base.TotalDof; j++)
		{
			array9[j] = array4[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D) * (vector3D9 * _0023_003Dz2T4sy2I_003D) + array5[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D) * (vector3D10 * _0023_003Dz2T4sy2I_003D) + 2.0 * array6[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D) * (vector3D10 * _0023_003Dz2T4sy2I_003D) + 2.0 * array7[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D) * (vector3D11 * _0023_003Dz2T4sy2I_003D) + 2.0 * array8[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D) * (vector3D11 * _0023_003Dz2T4sy2I_003D);
			array10[j] = array4[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D) * (vector3D9 * _0023_003DzO91j_0024fQ_003D) + array5[j] * (vector3D10 * _0023_003DzO91j_0024fQ_003D) * (vector3D10 * _0023_003DzO91j_0024fQ_003D) + 2.0 * array6[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D) * (vector3D10 * _0023_003DzO91j_0024fQ_003D) + 2.0 * array7[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D) * (vector3D11 * _0023_003DzO91j_0024fQ_003D) + 2.0 * array8[j] * (vector3D10 * _0023_003DzO91j_0024fQ_003D) * (vector3D11 * _0023_003DzO91j_0024fQ_003D);
			array12[j] = 2.0 * (array4[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D) * (vector3D9 * _0023_003DzO91j_0024fQ_003D) + array5[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D) * (vector3D10 * _0023_003DzO91j_0024fQ_003D) + array6[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D * (vector3D10 * _0023_003DzO91j_0024fQ_003D) + vector3D10 * _0023_003Dz2T4sy2I_003D * (vector3D9 * _0023_003DzO91j_0024fQ_003D)) + array7[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D * (vector3D11 * _0023_003DzO91j_0024fQ_003D) + vector3D11 * _0023_003Dz2T4sy2I_003D * (vector3D9 * _0023_003DzO91j_0024fQ_003D)) + array8[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D * (vector3D11 * _0023_003DzO91j_0024fQ_003D) + vector3D11 * _0023_003Dz2T4sy2I_003D * (vector3D10 * _0023_003DzO91j_0024fQ_003D)));
			array14[j] = 2.0 * (array4[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D) * (vector3D9 * _0023_003DzOC64tNw_003D) + array5[j] * (vector3D10 * _0023_003DzO91j_0024fQ_003D) * (vector3D10 * _0023_003DzOC64tNw_003D) + array6[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D * (vector3D10 * _0023_003DzOC64tNw_003D) + vector3D10 * _0023_003DzO91j_0024fQ_003D * (vector3D9 * _0023_003DzOC64tNw_003D)) + array7[j] * (vector3D9 * _0023_003DzO91j_0024fQ_003D * (vector3D11 * _0023_003DzOC64tNw_003D) + vector3D11 * _0023_003DzO91j_0024fQ_003D * (vector3D9 * _0023_003DzOC64tNw_003D)) + array8[j] * (vector3D10 * _0023_003DzO91j_0024fQ_003D * (vector3D11 * _0023_003DzOC64tNw_003D) + vector3D11 * _0023_003DzO91j_0024fQ_003D * (vector3D10 * _0023_003DzOC64tNw_003D)));
			array13[j] = 2.0 * (array4[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D) * (vector3D9 * _0023_003DzOC64tNw_003D) + array5[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D) * (vector3D10 * _0023_003DzOC64tNw_003D) + array6[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D * (vector3D10 * _0023_003DzOC64tNw_003D) + vector3D10 * _0023_003Dz2T4sy2I_003D * (vector3D9 * _0023_003DzOC64tNw_003D)) + array7[j] * (vector3D9 * _0023_003Dz2T4sy2I_003D * (vector3D11 * _0023_003DzOC64tNw_003D) + vector3D11 * _0023_003Dz2T4sy2I_003D * (vector3D9 * _0023_003DzOC64tNw_003D)) + array8[j] * (vector3D10 * _0023_003Dz2T4sy2I_003D * (vector3D11 * _0023_003DzOC64tNw_003D) + vector3D11 * _0023_003Dz2T4sy2I_003D * (vector3D10 * _0023_003DzOC64tNw_003D)));
		}
		return Matrix.CreateMatrixFromVectors(new double[6][] { array9, array10, array11, array12, array14, array13 }, asRows: true);
	}

	private void _0023_003DzOYVb4B_0024UEzh3(Vector3D _0023_003DzZbOaTIM_003D, Vector3D _0023_003DzcgQS2OJJ2x_L, out Vector3D _0023_003Dz2T4sy2I_003D, out Vector3D _0023_003DzO91j_0024fQ_003D, out Vector3D _0023_003DzOC64tNw_003D, out double[,] _0023_003DzWWgGxds_003D)
	{
		_0023_003DzOC64tNw_003D = _0023_003DzZbOaTIM_003D / _0023_003DzZbOaTIM_003D.Length;
		_0023_003Dz2T4sy2I_003D = Vector3D.Cross(_0023_003DzcgQS2OJJ2x_L, _0023_003DzOC64tNw_003D);
		_0023_003Dz2T4sy2I_003D.Normalize();
		_0023_003DzO91j_0024fQ_003D = Vector3D.Cross(_0023_003DzOC64tNw_003D, _0023_003Dz2T4sy2I_003D);
		_0023_003DzWWgGxds_003D = new double[6, 6];
		double x = _0023_003Dz2T4sy2I_003D.X;
		double x2 = _0023_003DzO91j_0024fQ_003D.X;
		double x3 = _0023_003DzOC64tNw_003D.X;
		double y = _0023_003Dz2T4sy2I_003D.Y;
		double y2 = _0023_003DzO91j_0024fQ_003D.Y;
		double y3 = _0023_003DzOC64tNw_003D.Y;
		double z = _0023_003Dz2T4sy2I_003D.Z;
		double z2 = _0023_003DzO91j_0024fQ_003D.Z;
		double z3 = _0023_003DzOC64tNw_003D.Z;
		_0023_003DzWWgGxds_003D[0, 0] = x * x;
		_0023_003DzWWgGxds_003D[0, 1] = x2 * x2;
		_0023_003DzWWgGxds_003D[0, 2] = x3 * x3;
		_0023_003DzWWgGxds_003D[0, 3] = 2.0 * x * x2;
		_0023_003DzWWgGxds_003D[0, 4] = 2.0 * x2 * x3;
		_0023_003DzWWgGxds_003D[0, 5] = 2.0 * x3 * x;
		_0023_003DzWWgGxds_003D[1, 0] = y * y;
		_0023_003DzWWgGxds_003D[1, 1] = y2 * y2;
		_0023_003DzWWgGxds_003D[1, 2] = y3 * y3;
		_0023_003DzWWgGxds_003D[1, 3] = 2.0 * y * y2;
		_0023_003DzWWgGxds_003D[1, 4] = 2.0 * y2 * y3;
		_0023_003DzWWgGxds_003D[1, 5] = 2.0 * y3 * y;
		_0023_003DzWWgGxds_003D[2, 0] = z * z;
		_0023_003DzWWgGxds_003D[2, 1] = z2 * z2;
		_0023_003DzWWgGxds_003D[2, 2] = z3 * z3;
		_0023_003DzWWgGxds_003D[2, 3] = 2.0 * z * z2;
		_0023_003DzWWgGxds_003D[2, 4] = 2.0 * z2 * z3;
		_0023_003DzWWgGxds_003D[2, 5] = 2.0 * z3 * z;
		_0023_003DzWWgGxds_003D[3, 0] = x * y;
		_0023_003DzWWgGxds_003D[3, 1] = x2 * y2;
		_0023_003DzWWgGxds_003D[3, 2] = x3 * y3;
		_0023_003DzWWgGxds_003D[3, 3] = x * y2 + y * x2;
		_0023_003DzWWgGxds_003D[3, 4] = x2 * y3 + y2 * x3;
		_0023_003DzWWgGxds_003D[3, 5] = x * y3 + y * x3;
		_0023_003DzWWgGxds_003D[4, 0] = y * z;
		_0023_003DzWWgGxds_003D[4, 1] = y2 * z2;
		_0023_003DzWWgGxds_003D[4, 2] = y3 * z3;
		_0023_003DzWWgGxds_003D[4, 3] = y * z2 + z * y2;
		_0023_003DzWWgGxds_003D[4, 4] = y2 * z3 + z2 * y3;
		_0023_003DzWWgGxds_003D[4, 5] = y * z3 + z * y3;
		_0023_003DzWWgGxds_003D[5, 0] = x * z;
		_0023_003DzWWgGxds_003D[5, 1] = x2 * z2;
		_0023_003DzWWgGxds_003D[5, 2] = x3 * z3;
		_0023_003DzWWgGxds_003D[5, 3] = x * z2 + z * x2;
		_0023_003DzWWgGxds_003D[5, 4] = x2 * z3 + z2 * x3;
		_0023_003DzWWgGxds_003D[5, 5] = x * z3 + z * x3;
	}

	private void _0023_003Dz16oBYCA_SMLLcV5DxZEO0jI_003D(double[] _0023_003DzoMNiNRw_003D, double[] _0023_003DzxyTUwy6mshU4, double[] _0023_003Dz3fdGqlBUejC5, double _0023_003DzfJFRO2o_003D, double[,] _0023_003Dz9TW2RR8_003D, out double[,] _0023_003DzSZY4TyU_003D, out double[,] _0023_003Dz2fxfrto_003D, out double[,] _0023_003Dz_CJJjm8_003D, double _0023_003DzNDQ_E88_003D)
	{
		_0023_003DzSZY4TyU_003D = new double[base.TotalDof, 3];
		_0023_003Dz2fxfrto_003D = new double[base.TotalDof, 3];
		_0023_003Dz_CJJjm8_003D = new double[base.TotalDof, 3];
		for (int i = 0; i < NumberOfNodes; i++)
		{
			_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode, 0] = _0023_003DzxyTUwy6mshU4[i];
			_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode, 0] = _0023_003Dz3fdGqlBUejC5[i];
			_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 1, 1] = _0023_003DzxyTUwy6mshU4[i];
			_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 1, 1] = _0023_003Dz3fdGqlBUejC5[i];
			_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 2, 2] = _0023_003DzxyTUwy6mshU4[i];
			_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 2, 2] = _0023_003Dz3fdGqlBUejC5[i];
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 3, 1] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 3, 2] = _0023_003DzfJFRO2o_003D * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 4, 0] = _0023_003DzfJFRO2o_003D * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 4, 2] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 5, 0] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			_0023_003Dz_CJJjm8_003D[i * NumberOfDofPerNode + 5, 1] = _0023_003DzfJFRO2o_003D * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003DzoMNiNRw_003D[i] / 2.0;
			if (_0023_003DzNDQ_E88_003D != 0.0)
			{
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 3, 1] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 3, 1] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 3, 2] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 3, 2] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 4, 0] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 4, 0] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[2, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 4, 2] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 4, 2] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 5, 0] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 5, 0] = (0.0 - _0023_003DzfJFRO2o_003D) * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[1, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
				_0023_003DzSZY4TyU_003D[i * NumberOfDofPerNode + 5, 1] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003DzxyTUwy6mshU4[i] / 2.0;
				_0023_003Dz2fxfrto_003D[i * NumberOfDofPerNode + 5, 1] = _0023_003DzfJFRO2o_003D * _0023_003DzNDQ_E88_003D * _0023_003Dz9TW2RR8_003D[0, i] * _0023_003Dz3fdGqlBUejC5[i] / 2.0;
			}
		}
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		double[,] array = new double[Math.Max(NumberOfStressesPerNode, 4), NumberOfGaussPoints];
		for (int i = 1; i <= NumberOfGaussPoints; i++)
		{
			double[] strsg = ComputeCartesianStressAtSamplingPoint(i, nodes);
			ComputeThermalLoading(i, temperature, array, strsg);
		}
		double[,] array2 = new double[Math.Max(NumberOfStressesPerNode, 4), NumberOfNodes];
		double num = 1.8660254037844386;
		double num2 = -0.5;
		double num3 = 0.1339745962155614;
		if (NumberOfStressesPerNode != 6)
		{
			switch (base.Material.ElementType)
			{
			case elementType.PlaneStress:
			{
				for (int k = 0; k < 3; k++)
				{
					array2[k, 0] = num * array[k, 0] + num2 * array[k, 2] + num3 * array[k, 3] + num2 * array[k, 1];
					array2[k, 1] = num2 * array[k, 0] + num * array[k, 2] + num2 * array[k, 3] + num3 * array[k, 1];
					array2[k, 2] = num3 * array[k, 0] + num2 * array[k, 2] + num * array[k, 3] + num2 * array[k, 1];
					array2[k, 3] = num2 * array[k, 0] + num3 * array[k, 2] + num2 * array[k, 3] + num * array[k, 1];
				}
				break;
			}
			case elementType.PlaneStrain:
			case elementType.Axisymmetric:
			{
				for (int j = 0; j < 4; j++)
				{
					array2[j, 0] = num * array[j, 0] + num2 * array[j, 2] + num3 * array[j, 3] + num2 * array[j, 1];
					array2[j, 1] = num2 * array[j, 0] + num * array[j, 2] + num2 * array[j, 3] + num3 * array[j, 1];
					array2[j, 2] = num3 * array[j, 0] + num2 * array[j, 2] + num * array[j, 3] + num2 * array[j, 1];
					array2[j, 3] = num2 * array[j, 0] + num3 * array[j, 2] + num2 * array[j, 3] + num * array[j, 1];
				}
				break;
			}
			}
		}
		else
		{
			for (int l = 0; l < NumberOfStressesPerNode; l++)
			{
				array2[l, 0] = (num * array[l, 0] + num * array[l, 1] + num2 * array[l, 2] + num2 * array[l, 3] + num2 * array[l, 4] + num2 * array[l, 5] + num3 * array[l, 6] + num3 * array[l, 7]) / 2.0;
				array2[l, 1] = (num2 * array[l, 0] + num2 * array[l, 1] + num3 * array[l, 2] + num3 * array[l, 3] + num * array[l, 4] + num * array[l, 5] + num2 * array[l, 6] + num2 * array[l, 7]) / 2.0;
				array2[l, 2] = (num3 * array[l, 0] + num3 * array[l, 1] + num2 * array[l, 2] + num2 * array[l, 3] + num2 * array[l, 4] + num2 * array[l, 5] + num * array[l, 6] + num * array[l, 7]) / 2.0;
				array2[l, 3] = (num2 * array[l, 0] + num2 * array[l, 1] + num * array[l, 2] + num * array[l, 3] + num3 * array[l, 4] + num3 * array[l, 5] + num2 * array[l, 6] + num2 * array[l, 7]) / 2.0;
			}
		}
		TotalUpTheStresses(array2, numberOfElementsPerNode, nodes);
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		double _0023_003DzBFhdx14hKg_h = 1.0;
		if (base.Material.ElementType == elementType.PlaneStress)
		{
			_0023_003DzBFhdx14hKg_h = base.Material.ElementThickness;
		}
		double[] array = new double[NumberOfNodes];
		for (int i = 0; i < NumberOfNodes; i++)
		{
			array[i] = ((Node)nodes[Connection[i]]).Temperature;
		}
		tLoad = new double[base.TotalDof];
		strin = new double[NumberOfGaussPoints, Math.Max(NumberOfStressesPerNode, 4)];
		if (nodes[Connection[0]] is NodeBeam && nodes[Connection[1]] is NodeBeam && nodes[Connection[2]] is NodeBeam && nodes[Connection[3]] is NodeBeam)
		{
			_0023_003DzDb12ERrcRsX0r1MzBw_003D_003D(elemIndex, nodes, _0023_003DzBFhdx14hKg_h, array);
			return;
		}
		GaussQuadrature(out var gpPosition, out var gpWeight);
		double[] array2 = new double[NumberOfNodes];
		double[,] array3 = new double[NumberOfNodes, NumberOfDimensions];
		double[,] gaussPoints = new double[NumberOfGaussPoints, NumberOfDimensions];
		double _0023_003DzuwH5j5s_003D = 0.0;
		double _0023_003DzNDQ_E88_003D = 0.0;
		int num = 0;
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
			_0023_003Dz3UeRax27BOx3(_0023_003DzuwH5j5s_003D, _0023_003DzNDQ_E88_003D, array2, array3);
			double[,] cartDeriv = new double[NumberOfNodes, NumberOfDimensions];
			Jacob2(num, elemIndex, nodes, array2, array3, out var detJacob, gaussPoints, cartDeriv);
			double dvolu = detJacob * gpWeight[0] * gpWeight[0];
			ComputeTemp(nodes, array2, cartDeriv, dvolu, array, num, gaussPoints);
		}
	}

	private void _0023_003DzDb12ERrcRsX0r1MzBw_003D_003D(int _0023_003DziLhQ6oA_003D, Point3D[] _0023_003DzDvuIQCU_003D, double _0023_003DzBFhdx14hKg_h, double[] _0023_003Dz4l4UPFDqrozm)
	{
		double[] array = _0023_003DzDvuIQCU_003D[Connection[0]].ToArray();
		double[] array2 = _0023_003DzDvuIQCU_003D[Connection[1]].ToArray();
		double[] array3 = _0023_003DzDvuIQCU_003D[Connection[2]].ToArray();
		double[] array4 = _0023_003DzDvuIQCU_003D[Connection[3]].ToArray();
		double[,] _0023_003DzghVYKJ4_003D = Matrix.CreateMatrixFromVectors(new double[4][] { array, array2, array3, array4 }, asRows: false);
		Vector3D vector3D = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[1]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[3]]));
		Vector3D vector3D2 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[2]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[1]], _0023_003DzDvuIQCU_003D[Connection[0]]));
		Vector3D vector3D3 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[3]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[2]], _0023_003DzDvuIQCU_003D[Connection[1]]));
		Vector3D vector3D4 = Vector3D.Cross(new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[0]]), new Vector3D(_0023_003DzDvuIQCU_003D[Connection[3]], _0023_003DzDvuIQCU_003D[Connection[2]]));
		vector3D.Normalize();
		vector3D2.Normalize();
		vector3D3.Normalize();
		vector3D4.Normalize();
		double[,] _0023_003Dz9TW2RR8_003D = Matrix.CreateMatrixFromVectors(new double[4][]
		{
			vector3D.ToArray(),
			vector3D2.ToArray(),
			vector3D3.ToArray(),
			vector3D4.ToArray()
		}, asRows: false);
		double[,] array5 = new double[6, 6]
		{
			{
				mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				mat.Poisson * mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				0.0,
				0.0,
				0.0,
				0.0
			},
			{
				mat.Poisson * mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				mat.Young / (1.0 - mat.Poisson * mat.Poisson),
				0.0,
				0.0,
				0.0,
				0.0
			},
			{ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
			{
				0.0,
				0.0,
				0.0,
				mat.Young / (2.0 + 2.0 * mat.Poisson),
				0.0,
				0.0
			},
			{
				0.0,
				0.0,
				0.0,
				0.0,
				5.0 * mat.Young / (12.0 + 12.0 * mat.Poisson),
				0.0
			},
			{
				0.0,
				0.0,
				0.0,
				0.0,
				0.0,
				5.0 * mat.Young / (12.0 + 12.0 * mat.Poisson)
			}
		};
		_0023_003DzIYZUJc9jJi_uSlxV9vwOVw2sSUP9(_0023_003DzBFhdx14hKg_h, _0023_003DzghVYKJ4_003D, _0023_003Dz9TW2RR8_003D, out var _0023_003Dz586LM_jbBebO, out var _0023_003DzVQPWxL3v6tIG);
		double num = 0.0;
		for (int i = 0; i < NumberOfNodes; i++)
		{
			num += _0023_003Dz4l4UPFDqrozm[i] / 4.0;
		}
		double[] array6 = new double[6]
		{
			(0.0 - num) * mat.CoeffOfThermalExp,
			(0.0 - num) * mat.CoeffOfThermalExp,
			0.0,
			0.0,
			0.0,
			0.0
		};
		double[] array7 = new double[NumberOfStressesPerNode];
		for (int j = 0; j < NumberOfStressesPerNode; j++)
		{
			for (int k = 0; k < NumberOfStressesPerNode; k++)
			{
				array7[j] += array5[j, k] * array6[k];
			}
		}
		B = _0023_003DzhUTKKHJLW_c8HGBtIg_003D_003D(_0023_003DzBFhdx14hKg_h, _0023_003DzghVYKJ4_003D, _0023_003Dz9TW2RR8_003D, _0023_003Dz586LM_jbBebO, _0023_003DzVQPWxL3v6tIG, new Point4D(0.0, 0.0, 0.0), _0023_003DziLhQ6oA_003D, out var _0023_003Dzujbp9cCPSfk_0024, out var _);
		for (int l = 0; l < NumberOfStressesPerNode; l++)
		{
			for (int m = 0; m < base.TotalDof; m++)
			{
				tLoad[m] -= B[l, m] * array7[l] * _0023_003Dzujbp9cCPSfk_0024 * 8.0;
			}
		}
		double num2 = 1.0 / Math.Sqrt(3.0);
		Point4D[] array8 = new Point4D[8]
		{
			new Point4D(0.0 - num2, 0.0 - num2, 0.0 - num2, 1.0),
			new Point4D(0.0 - num2, 0.0 - num2, num2, 1.0),
			new Point4D(0.0 - num2, num2, 0.0 - num2, 1.0),
			new Point4D(0.0 - num2, num2, num2, 1.0),
			new Point4D(num2, 0.0 - num2, 0.0 - num2, 1.0),
			new Point4D(num2, 0.0 - num2, num2, 1.0),
			new Point4D(num2, num2, 0.0 - num2, 1.0),
			new Point4D(num2, num2, num2, 1.0)
		};
		for (int n = 0; n < array8.Length; n++)
		{
			B = _0023_003DzhUTKKHJLW_c8HGBtIg_003D_003D(_0023_003DzBFhdx14hKg_h, _0023_003DzghVYKJ4_003D, _0023_003Dz9TW2RR8_003D, _0023_003Dz586LM_jbBebO, _0023_003DzVQPWxL3v6tIG, array8[n], _0023_003DziLhQ6oA_003D, out var _, out var _0023_003DzwFoJ3JyJ3FK_00242);
			double[] array9 = new double[NumberOfStressesPerNode];
			for (int num3 = 0; num3 < NumberOfStressesPerNode; num3++)
			{
				for (int num4 = 0; num4 < NumberOfStressesPerNode; num4++)
				{
					array9[num3] += _0023_003DzwFoJ3JyJ3FK_00242[num3, num4] * array7[num4];
				}
			}
			for (int num5 = 0; num5 < NumberOfStressesPerNode; num5++)
			{
				strin[n, num5] = array9[num5];
			}
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		if (vertices[0] is NodeBeam)
		{
			DrawFace4(context, singleColor, 0, vertices, ampFactor, mode);
		}
		else
		{
			DrawFace4(context, singleNormal, singleColor, vertices, ampFactor, mode);
		}
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		DrawFace4(context, singleNormal, vertices, ampFactor, mode);
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (vertices[0] is NodeBeam)
		{
			DrawFace4(context, 0, vertices, min, max, ampFactor, mode);
		}
		else
		{
			DrawFace4(context, singleNormal, vertices, min, max, ampFactor, mode);
		}
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		if (vertices[0] is NodeBeam)
		{
			DrawFaceElement4(context, 0, vertices, min, max, ampFactor, mode);
		}
		else
		{
			DrawFaceElement4(context, singleNormal, vertices, min, max, ampFactor, mode);
		}
	}

	public override IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		return GetFace4(elIndex, 0, vertices, ampFactor, centroids);
	}

	public void SetPressure(Vector3D globalPressure, Point3D[] nodes)
	{
		if (!(nodes[Connection[0]] is NodeBeam) || !(nodes[Connection[1]] is NodeBeam) || !(nodes[Connection[2]] is NodeBeam) || !(nodes[Connection[3]] is NodeBeam))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985479));
		}
		_0023_003DzyWdJ4nflae0e(nodes);
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		int num = Connection[elFaces[0].Indices[0]];
		int num2 = Connection[elFaces[0].Indices[1]];
		int num3 = Connection[elFaces[0].Indices[2]];
		int num4 = Connection[elFaces[0].Indices[3]];
		Vector3D a = new Vector3D(nodes[num], nodes[num2]);
		Vector3D vector3D = new Vector3D(nodes[num], nodes[num3]);
		Vector3D b = new Vector3D(nodes[num], nodes[num4]);
		double num5 = 0.5 * Vector3D.Cross(a, vector3D).Length + 0.5 * Vector3D.Cross(vector3D, b).Length;
		Vector3D vector3D2 = new Vector3D(globalPressure.X * (num5 / 4.0), globalPressure.Y * (num5 / 4.0), globalPressure.Z * (num5 / 4.0));
		for (int i = 0; i < 4; i++)
		{
			int num6 = elFaces[0].Indices[i] * NumberOfDofPerNode;
			distLoad[num6] += vector3D2.X;
			distLoad[num6 + 1] += vector3D2.Y;
			distLoad[num6 + 2] += vector3D2.Z;
		}
		base.SetPressure(0, globalPressure, nodes);
	}

	public void SetPressure(double pressureMag, Point3D[] nodes)
	{
		if (!(nodes[Connection[0]] is NodeBeam) || !(nodes[Connection[1]] is NodeBeam) || !(nodes[Connection[2]] is NodeBeam) || !(nodes[Connection[3]] is NodeBeam))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985479));
		}
		_0023_003DzyWdJ4nflae0e(nodes);
		int num = Connection[elFaces[0].Indices[0]];
		int num2 = Connection[elFaces[0].Indices[1]];
		int num3 = Connection[elFaces[0].Indices[2]];
		Vector3D a = new Vector3D(nodes[num], nodes[num2]);
		Vector3D b = new Vector3D(nodes[num], nodes[num3]);
		Vector3D vector3D = Vector3D.Cross(a, b);
		vector3D.Normalize();
		Vector3D globalPressure = new Vector3D((0.0 - pressureMag) * vector3D.X, (0.0 - pressureMag) * vector3D.Y, (0.0 - pressureMag) * vector3D.Z);
		SetPressure(globalPressure, nodes);
	}

	public override void SetPressure(int edgeIndex, Vector3D pressure, Point3D[] nodes)
	{
		if (nodes[Connection[0]] is NodeBeam && nodes[Connection[1]] is NodeBeam && nodes[Connection[2]] is NodeBeam && nodes[Connection[3]] is NodeBeam)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985689));
		}
		Node p = (Node)nodes[Connection[elEdges[edgeIndex].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elEdges[edgeIndex].Indices[1]]];
		Vector2D _0023_003DzTx2aqr8_003D = new Vector2D(p, p2);
		Vector2D _0023_003DzJvZCors_003D = Element2D._0023_003DzTYQj7dTpRcf3AB30m3Ejgzk_003D(new Vector2D(pressure.X, pressure.Y), _0023_003DzTx2aqr8_003D);
		_0023_003DzIOeurJfZGn2VbAAjxA_003D_003D(nodes, _0023_003DzJvZCors_003D, edgeIndex);
		base.SetPressure(edgeIndex, pressure, nodes);
	}

	public override void SetPressure(int edgeIndex, double pressure, Point3D[] nodes)
	{
		if (nodes[Connection[0]] is NodeBeam && nodes[Connection[1]] is NodeBeam && nodes[Connection[2]] is NodeBeam && nodes[Connection[3]] is NodeBeam)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985689));
		}
		Vector2D _0023_003DzJvZCors_003D = new Vector2D(0.0, pressure);
		_0023_003DzIOeurJfZGn2VbAAjxA_003D_003D(nodes, _0023_003DzJvZCors_003D, edgeIndex);
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
			fm.Vertices = list2.ToArray();
			List<int> list3 = new List<int>();
			list3.AddRange(Connection);
			Connection = new int[4]
			{
				num,
				num + 1,
				num + 2,
				num + 3
			};
			list3.AddRange(Connection);
			Hexa8 item = new Hexa8(list3, base.Material);
			list.Add(item);
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
			fm.Vertices = list2.ToArray();
			List<int> list3 = new List<int>();
			list3.AddRange(Connection);
			Connection = new int[4]
			{
				num,
				num + 1,
				num + 2,
				num + 3
			};
			list3.AddRange(Connection);
			Hexa8 item = new Hexa8(list3, base.Material);
			list.Add(item);
		}
		fm.Elements = list.ToArray();
	}

	public override void Refine(int r, int s, int t, FemMesh fm)
	{
		bool flag = fm.Vertices[Connection[0]] is NodeBeam && fm.Vertices[Connection[1]] is NodeBeam && fm.Vertices[Connection[2]] is NodeBeam && fm.Vertices[Connection[3]] is NodeBeam;
		List<Point3D> list = new List<Point3D>();
		list.AddRange(fm.Vertices);
		for (int i = 0; i <= s; i++)
		{
			Segment3D segment3D = new Segment3D(fm.Vertices[Connection[0]], fm.Vertices[Connection[3]]);
			Segment3D segment3D2 = new Segment3D(fm.Vertices[Connection[1]], fm.Vertices[Connection[2]]);
			Point3D point3D = segment3D.PointAt((double)i / (double)s);
			if (flag)
			{
				list.Add(new NodeBeam(point3D.X, point3D.Y, point3D.Z));
			}
			else
			{
				list.Add(new Node(point3D.X, point3D.Y, point3D.Z));
			}
			Point3D point3D2 = segment3D2.PointAt((double)i / (double)s);
			for (int j = 1; j < r; j++)
			{
				Point3D point3D3 = new Segment3D(point3D, point3D2).PointAt((double)j / (double)r);
				if (flag)
				{
					list.Add(new NodeBeam(point3D3.X, point3D3.Y, point3D3.Z));
				}
				else
				{
					list.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
				}
			}
			if (flag)
			{
				list.Add(new NodeBeam(point3D2.X, point3D2.Y, point3D2.Z));
			}
			else
			{
				list.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
			}
		}
		List<Element> list2 = new List<Element>();
		list2.AddRange(fm.elements);
		int num = r + 1;
		int num2 = fm.Vertices.Length;
		for (int k = 0; k < s; k++)
		{
			for (int l = 0; l < r; l++)
			{
				Quad4 item = new Quad4(num2 + num * k + l, num2 + num * k + l + 1, num2 + num * (k + 1) + l + 1, num2 + num * (k + 1) + l, base.Material);
				list2.Add(item);
			}
		}
		fm.Vertices = list.ToArray();
		fm.Elements = list2.ToArray();
	}

	internal Quad8 _0023_003DzjKLmeSIGqK0l(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D)
	{
		return _0023_003DzjKLmeSIGqK0l(_0023_003DzDvuIQCU_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, base.Material);
	}

	internal static Quad8 _0023_003DzjKLmeSIGqK0l(int[] _0023_003DzDvuIQCU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < _0023_003DzDvuIQCU_003D.Length; i++)
		{
			Line line = null;
			line = ((i != _0023_003DzDvuIQCU_003D.Length - 1) ? new Line(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i + 1]]) : new Line(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[i]], _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzDvuIQCU_003D[0]]));
			int count = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Node(line.MidPoint.X, line.MidPoint.Y, line.MidPoint.Z));
			list.Add(_0023_003DzDvuIQCU_003D[i]);
			list.Add(count);
		}
		return new Quad8(list, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D);
	}
}
