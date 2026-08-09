using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Beam2D : Element2D
{
	internal Point3D[] beamVerts;

	internal KeyValuePair<double, Vector3D> _alongBeamLoad;

	internal double[] _alongBeamLoads;

	public double Temperature;

	private double L;

	private double c;

	private double s;

	private bool initializedQuantities;

	private double[] _bendingMomentW;

	private double[] _shearForce;

	private double[] _axialForce;

	internal double PerpPressureBeam;

	internal double AxialPressureBeam;

	public int SubdivisionNumber { get; set; }

	public bool HingeStart { get; set; }

	public bool HingeEnd { get; set; }

	public double[] BendingMoment => _bendingMomentW;

	public double[] ShearForce => _shearForce;

	public double[] AxialForce => _axialForce;

	public Beam2D(int nodeIndex1, int nodeIndex2, MaterialBeam mat)
		: base(2, mat)
	{
		NumberOfDofPerNode = 3;
		NumberOfDimensions = 3;
		NumberOfGaussPoints = 1;
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		SubdivisionNumber = 10;
		HingeStart = false;
		HingeEnd = false;
		elEdges = new Edge[1]
		{
			new Edge(new byte[2] { 0, 1 })
		};
		elFaces = new Face[0];
	}

	protected Beam2D(Beam2D another)
		: base(another)
	{
		SubdivisionNumber = another.SubdivisionNumber;
		HingeStart = another.HingeStart;
		HingeEnd = another.HingeEnd;
		elEdges = another.Edges;
	}

	public void SetStartSectionVertices(Point3D[] vertices)
	{
		beamVerts = vertices;
	}

	public override object Clone()
	{
		return new Beam2D(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemBeam2DSurrogate(this);
	}

	private void _0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(Point3D[] _0023_003DzDvuIQCU_003D)
	{
		L = _0023_003DzDvuIQCU_003D[Connection[0]].DistanceTo(_0023_003DzDvuIQCU_003D[Connection[1]]);
		c = (_0023_003DzDvuIQCU_003D[Connection[1]].X - _0023_003DzDvuIQCU_003D[Connection[0]].X) / L;
		s = (_0023_003DzDvuIQCU_003D[Connection[1]].Y - _0023_003DzDvuIQCU_003D[Connection[0]].Y) / L;
		initializedQuantities = true;
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		M = new double[6, 6];
		M[0, 0] = 1.0 / 3.0;
		M[1, 1] = 13.0 / 35.0;
		M[2, 2] = L * L / 105.0;
		M[3, 3] = 1.0 / 3.0;
		M[4, 4] = 13.0 / 35.0;
		M[5, 5] = L * L / 105.0;
		M[2, 1] = (M[1, 2] = L * 11.0 / 210.0);
		M[3, 0] = (M[0, 3] = 1.0 / 6.0);
		M[4, 1] = (M[1, 4] = 9.0 / 70.0);
		M[4, 2] = (M[2, 4] = 13.0 * L / 140.0);
		M[5, 1] = (M[1, 5] = -13.0 * L / 420.0);
		M[5, 2] = (M[2, 5] = (0.0 - L) * L / 140.0);
		M[5, 4] = (M[4, 5] = -11.0 * L / 210.0);
		double num = mat.Density * L * ((MaterialBeam)mat).SectionArea;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				M[i, j] *= num;
			}
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		if (materialBeam.Iw == 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984614) + elemIndex);
		}
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		double[,] array = new double[base.TotalDof, base.TotalDof];
		if (!HingeStart && !HingeEnd)
		{
			double young = mat.Young;
			double num = young * materialBeam.Iw;
			double num2 = young * materialBeam.SectionArea / L;
			double num3 = 12.0 * num / (L * L * L);
			double num4 = 6.0 * num / (L * L);
			double num5 = 4.0 * num / L;
			double num6 = 2.0 * num / L;
			array[0, 0] = (array[3, 3] = num2);
			array[3, 0] = (array[0, 3] = 0.0 - num2);
			array[1, 1] = (array[4, 4] = num3);
			array[1, 4] = (array[4, 1] = 0.0 - num3);
			array[1, 2] = (array[2, 1] = (array[1, 5] = (array[5, 1] = num4)));
			array[2, 4] = (array[4, 2] = (array[4, 5] = (array[5, 4] = 0.0 - num4)));
			array[2, 2] = (array[5, 5] = num5);
			array[2, 5] = (array[5, 2] = num6);
		}
		else
		{
			_0023_003DzMEJ0yAjyk4JiXTXB_H9kySo_003D(materialBeam, array);
		}
		double[,] b = _0023_003DzriI8brks0YM0();
		double[,] array2 = new double[base.TotalDof, base.TotalDof];
		array2[0, 0] = (array2[3, 3] = (array2[1, 1] = (array2[4, 4] = c)));
		array2[2, 2] = (array2[5, 5] = 1.0);
		array2[0, 1] = (array2[3, 4] = 0.0 - s);
		array2[1, 0] = (array2[4, 3] = s);
		double[,] a = Matrix.Multiply(array2, array);
		K = Matrix.Multiply(a, b);
		StiffnessComputation(nodes);
	}

	private void _0023_003DzMEJ0yAjyk4JiXTXB_H9kySo_003D(MaterialBeam _0023_003DzUDlFc7k_003D, double[,] _0023_003DzGKVLTNs_003D)
	{
		double young = mat.Young;
		double num = young * _0023_003DzUDlFc7k_003D.Iw;
		if (HingeStart && HingeEnd)
		{
			double num2 = young * _0023_003DzUDlFc7k_003D.SectionArea / L;
			_0023_003DzGKVLTNs_003D[0, 0] = (_0023_003DzGKVLTNs_003D[3, 3] = num2);
			_0023_003DzGKVLTNs_003D[3, 0] = (_0023_003DzGKVLTNs_003D[0, 3] = 0.0 - num2);
		}
		else if (HingeStart)
		{
			double num3 = young * _0023_003DzUDlFc7k_003D.SectionArea / L;
			double num4 = 3.0 * num / (L * L * L);
			double num5 = 3.0 * num / (L * L);
			double num6 = 3.0 * num / L;
			_0023_003DzGKVLTNs_003D[0, 0] = (_0023_003DzGKVLTNs_003D[3, 3] = num3);
			_0023_003DzGKVLTNs_003D[3, 0] = (_0023_003DzGKVLTNs_003D[0, 3] = 0.0 - num3);
			_0023_003DzGKVLTNs_003D[1, 1] = (_0023_003DzGKVLTNs_003D[4, 4] = num4);
			_0023_003DzGKVLTNs_003D[1, 4] = (_0023_003DzGKVLTNs_003D[4, 1] = 0.0 - num4);
			_0023_003DzGKVLTNs_003D[1, 5] = (_0023_003DzGKVLTNs_003D[5, 1] = num5);
			_0023_003DzGKVLTNs_003D[4, 5] = (_0023_003DzGKVLTNs_003D[5, 4] = 0.0 - num5);
			_0023_003DzGKVLTNs_003D[5, 5] = num6;
		}
		else
		{
			double num7 = young * _0023_003DzUDlFc7k_003D.SectionArea / L;
			double num8 = 3.0 * num / (L * L * L);
			double num9 = 3.0 * num / (L * L);
			double num10 = 3.0 * num / L;
			_0023_003DzGKVLTNs_003D[0, 0] = (_0023_003DzGKVLTNs_003D[3, 3] = num7);
			_0023_003DzGKVLTNs_003D[3, 0] = (_0023_003DzGKVLTNs_003D[0, 3] = 0.0 - num7);
			_0023_003DzGKVLTNs_003D[1, 1] = (_0023_003DzGKVLTNs_003D[4, 4] = num8);
			_0023_003DzGKVLTNs_003D[1, 4] = (_0023_003DzGKVLTNs_003D[4, 1] = 0.0 - num8);
			_0023_003DzGKVLTNs_003D[1, 2] = (_0023_003DzGKVLTNs_003D[2, 1] = num9);
			_0023_003DzGKVLTNs_003D[2, 4] = (_0023_003DzGKVLTNs_003D[4, 2] = 0.0 - num9);
			_0023_003DzGKVLTNs_003D[2, 2] = num10;
		}
	}

	private double[,] _0023_003DzriI8brks0YM0()
	{
		double[,] array = new double[base.TotalDof, base.TotalDof];
		array[0, 0] = (array[3, 3] = (array[1, 1] = (array[4, 4] = c)));
		array[2, 2] = (array[5, 5] = 1.0);
		array[0, 1] = (array[3, 4] = s);
		array[1, 0] = (array[4, 3] = 0.0 - s);
		return array;
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double _0023_003DzEj_7zY0_003D = mat.Young * materialBeam.Iw;
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		double num = L * L;
		double _0023_003DzVSAhiYo_003D = num * L;
		_bendingMomentW = new double[2];
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, 0);
		_bendingMomentW[0] = _0023_003DzLX7kOPjiM_0024qCT3a5eUZKopA_003D(_0023_003Dzt38nTwk_003D, 0.0, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		_bendingMomentW[1] = _0023_003DzLX7kOPjiM_0024qCT3a5eUZKopA_003D(_0023_003Dzt38nTwk_003D, L, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		_shearForce = new double[2];
		_shearForce[0] = _0023_003DzUB_0024BC5Lq7uPDjANuBg_003D_003D(_0023_003Dzt38nTwk_003D, 0.0, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		_shearForce[1] = _0023_003DzUB_0024BC5Lq7uPDjANuBg_003D_003D(_0023_003Dzt38nTwk_003D, L, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		_axialForce = new double[2];
		_axialForce[0] = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D, 0.0, L, num, _0023_003DzVSAhiYo_003D, materialBeam.SectionArea);
		_axialForce[1] = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D, L, L, num, _0023_003DzVSAhiYo_003D, materialBeam.SectionArea);
	}

	private double[] _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(Point3D[] _0023_003DzDvuIQCU_003D, int _0023_003DznXXM9vk_003D)
	{
		double[] array = new double[base.TotalDof];
		for (int i = 0; i < NumberOfDofPerNode; i++)
		{
			if (i != NumberOfDofPerNode - 1)
			{
				array[i] = ((Node)_0023_003DzDvuIQCU_003D[Connection[0]]).Unknowns[_0023_003DznXXM9vk_003D][i];
				array[i + NumberOfDofPerNode] = ((Node)_0023_003DzDvuIQCU_003D[Connection[1]]).Unknowns[_0023_003DznXXM9vk_003D][i];
			}
			else
			{
				array[i] = ((Node)_0023_003DzDvuIQCU_003D[Connection[0]]).Unknowns[_0023_003DznXXM9vk_003D][5];
				array[i + NumberOfDofPerNode] = ((Node)_0023_003DzDvuIQCU_003D[Connection[1]]).Unknowns[_0023_003DznXXM9vk_003D][5];
			}
		}
		return Matrix.Multiply(_0023_003DzriI8brks0YM0(), array);
	}

	public override void SetPressure(int edgeIndex, Vector3D pressure, Point3D[] nodes)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984669));
	}

	public void SetDistributedLoad(Vector3D amount, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elEdges[0].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elEdges[0].Indices[1]]];
		Vector2D _0023_003DzTx2aqr8_003D = new Vector2D(p, p2);
		Vector2D vector2D = Element2D._0023_003DzTYQj7dTpRcf3AB30m3Ejgzk_003D(new Vector2D(amount.X, amount.Y), _0023_003DzTx2aqr8_003D);
		PerpPressureBeam += vector2D.Y;
		AxialPressureBeam += vector2D.X;
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		double num = vector2D.Y * L * L / 12.0;
		Vector2D vector2D2 = new Vector2D(amount.X * L / 2.0, amount.Y * L / 2.0);
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		distLoad[0] += vector2D2.X;
		distLoad[1] += vector2D2.Y;
		distLoad[2] += num;
		distLoad[3] += vector2D2.X;
		distLoad[4] += vector2D2.Y;
		distLoad[5] -= num;
		base.SetPressure(0, amount, nodes);
	}

	public override void SetPressure(int edgeIndex, double pressure, Point3D[] nodes)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984669));
	}

	public void SetDistributedLoad(double amount, Point3D[] nodes)
	{
		PerpPressureBeam += amount;
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		Vector2D vector2D = new Vector2D((0.0 - s) * amount * L / 2.0, c * amount * L / 2.0);
		double num = amount * L * L / 12.0;
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		distLoad[0] += vector2D.X;
		distLoad[1] += vector2D.Y;
		distLoad[2] += num;
		distLoad[3] += vector2D.X;
		distLoad[4] += vector2D.Y;
		distLoad[5] -= num;
		base.SetPressure(0, amount, nodes);
	}

	public void SetForce(Vector3D amount, double t, Point3D[] nodes)
	{
		Node p = (Node)nodes[Connection[elEdges[0].Indices[0]]];
		Node p2 = (Node)nodes[Connection[elEdges[0].Indices[1]]];
		Vector2D _0023_003DzTx2aqr8_003D = new Vector2D(p, p2);
		Vector2D vector2D = Element2D._0023_003DzTYQj7dTpRcf3AB30m3Ejgzk_003D(new Vector2D(amount.X, amount.Y), _0023_003DzTx2aqr8_003D);
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		double num = L - t;
		double num2 = t * t;
		double num3 = num * num;
		double num4 = L * L;
		double num5 = vector2D.Y * t * num3 / num4;
		double num6 = vector2D.Y * num * num2 / num4;
		Vector2D vector2D2 = new Vector2D(amount.X * num3 / num4 * (1.0 + 2.0 * t / L), amount.Y * num3 / num4 * (1.0 + 2.0 * t / L));
		Vector2D vector2D3 = new Vector2D(amount.X * num2 / num4 * (1.0 + 2.0 * num / L), amount.Y * num2 / num4 * (1.0 + 2.0 * num / L));
		if (_alongBeamLoads == null)
		{
			_alongBeamLoads = new double[6];
		}
		_alongBeamLoads[0] = vector2D2.X;
		_alongBeamLoads[1] = vector2D2.Y;
		_alongBeamLoads[2] = num5;
		_alongBeamLoads[3] = vector2D3.X;
		_alongBeamLoads[4] = vector2D3.Y;
		_alongBeamLoads[5] = 0.0 - num6;
		_alongBeamLoad = new KeyValuePair<double, Vector3D>(t, new Vector3D(vector2D.X, vector2D.Y, 0.0));
	}

	public void SetForce(double amount, double t, Point3D[] nodes)
	{
		_ = (Node)nodes[Connection[elEdges[0].Indices[0]]];
		_ = (Node)nodes[Connection[elEdges[0].Indices[1]]];
		if (!initializedQuantities)
		{
			_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes);
		}
		double num = L - t;
		double num2 = t * t;
		double num3 = num * num;
		double num4 = L * L;
		double num5 = amount * t * num3 / num4;
		double num6 = amount * num * num2 / num4;
		Vector2D vector2D = new Vector2D((0.0 - s) * amount * num3 / num4 * (1.0 + 2.0 * t / L), c * amount * num3 / num4 * (1.0 + 2.0 * t / L));
		Vector2D vector2D2 = new Vector2D((0.0 - s) * amount * num2 / num4 * (1.0 + 2.0 * num / L), c * amount * num2 / num4 * (1.0 + 2.0 * num / L));
		if (_alongBeamLoads == null)
		{
			_alongBeamLoads = new double[6];
		}
		_alongBeamLoads[0] = vector2D.X;
		_alongBeamLoads[1] = vector2D.Y;
		_alongBeamLoads[2] = num5;
		_alongBeamLoads[3] = vector2D2.X;
		_alongBeamLoads[4] = vector2D2.Y;
		_alongBeamLoads[5] = 0.0 - num6;
		_alongBeamLoad = new KeyValuePair<double, Vector3D>(t, new Vector3D(0.0, amount, 0.0));
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		tLoad = new double[base.TotalDof];
		double sectionArea = ((MaterialBeam)mat).SectionArea;
		tLoad[0] = (0.0 - mat.CoeffOfThermalExp) * Temperature * mat.Young * sectionArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[1] = (0.0 - mat.CoeffOfThermalExp) * Temperature * mat.Young * sectionArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[3] = mat.CoeffOfThermalExp * Temperature * mat.Young * sectionArea / L * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[4] = mat.CoeffOfThermalExp * Temperature * mat.Young * sectionArea / L * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
	}

	public double CalcBendingMoment(Point3D[] nodes, double t, int mode = 0)
	{
		double _0023_003DzEj_7zY0_003D = mat.Young * ((MaterialBeam)mat).Iw;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, mode);
		if (!initializedQuantities)
		{
			L = new Vector3D(nodes[Connection[0]], nodes[Connection[1]]).Length;
		}
		double num = L * L;
		double _0023_003DzVSAhiYo_003D = num * L;
		return _0023_003DzLX7kOPjiM_0024qCT3a5eUZKopA_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
	}

	private double _0023_003DzLX7kOPjiM_0024qCT3a5eUZKopA_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzEj_7zY0_003D)
	{
		double num = ((!HingeStart && !HingeEnd) ? ((-6.0 / _0023_003DzOKtgTr4_003D + 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + (-4.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[2] + (6.0 / _0023_003DzOKtgTr4_003D - 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[4] + (-2.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[5]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? ((0.0 - 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + (0.0 - 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[2] + (0.0 + 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[4] + 0.0 * _0023_003Dzt38nTwk_003D[5]) : ((0.0 + 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + 0.0 * _0023_003Dzt38nTwk_003D[2] + (0.0 - 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[4] + (0.0 + 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[5]))));
		double num2 = _0023_003DzEj_7zY0_003D * num;
		if (PerpPressureBeam != 0.0)
		{
			double num3 = PerpPressureBeam / (12.0 * _0023_003DzEj_7zY0_003D) * (_0023_003DzOKtgTr4_003D - 6.0 * _0023_003DzEWLeis8_003D * _0023_003DzNDQ_E88_003D + 6.0 * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
			num += num3;
			if (HingeStart)
			{
				num2 = ((!HingeEnd) ? (num2 - PerpPressureBeam * _0023_003DzNDQ_E88_003D * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D / 2.0)) : (num2 - PerpPressureBeam * _0023_003DzNDQ_E88_003D / 2.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num4 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num2 -= PerpPressureBeam * num4 * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num4 / 2.0);
			}
			else
			{
				num2 += PerpPressureBeam / 12.0 * (_0023_003DzOKtgTr4_003D - 6.0 * _0023_003DzEWLeis8_003D * _0023_003DzNDQ_E88_003D + 6.0 * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null)
		{
			if (_0023_003DzNDQ_E88_003D == 0.0)
			{
				num2 += _alongBeamLoads[2];
			}
			else if (_0023_003DzNDQ_E88_003D == _0023_003DzEWLeis8_003D)
			{
				num2 -= _alongBeamLoads[5];
			}
			else
			{
				num2 = BendingMoment[0] + ShearForce[0] * _0023_003DzNDQ_E88_003D;
				if (_0023_003DzNDQ_E88_003D > _alongBeamLoad.Key)
				{
					num2 += (_0023_003DzNDQ_E88_003D - _alongBeamLoad.Key) * _alongBeamLoad.Value[1];
				}
			}
		}
		return num2;
	}

	public double CalcShearForce(Point3D[] nodes, double t, int mode = 0)
	{
		double _0023_003DzEj_7zY0_003D = mat.Young * ((MaterialBeam)mat).Iw;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, mode);
		if (!initializedQuantities)
		{
			L = new Vector3D(nodes[Connection[0]], nodes[Connection[1]]).Length;
		}
		double num = L * L;
		double _0023_003DzVSAhiYo_003D = num * L;
		return _0023_003DzUB_0024BC5Lq7uPDjANuBg_003D_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
	}

	private double _0023_003DzUB_0024BC5Lq7uPDjANuBg_003D_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzEj_7zY0_003D)
	{
		double num = ((!HingeStart && !HingeEnd) ? (12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[2] + -12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[4] + 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[5]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? (-3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + -3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[2] + 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[4] + 0.0 * _0023_003Dzt38nTwk_003D[5]) : (3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 0.0 * _0023_003Dzt38nTwk_003D[2] - 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[4] + 3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[5]))));
		double num2 = _0023_003DzEj_7zY0_003D * num;
		if (PerpPressureBeam != 0.0)
		{
			if (HingeStart)
			{
				num2 = ((!HingeEnd) ? (num2 + PerpPressureBeam * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D)) : (num2 + PerpPressureBeam * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num3 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num2 += PerpPressureBeam * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num3);
			}
			else
			{
				num2 -= PerpPressureBeam * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null)
		{
			num2 = ((!(_0023_003DzNDQ_E88_003D < _alongBeamLoad.Key)) ? (num2 + _alongBeamLoads[4]) : (num2 - _alongBeamLoads[1]));
		}
		return num2;
	}

	public double CalcAxialForce(Point3D[] nodes, double t)
	{
		double sectionArea = ((MaterialBeam)mat).SectionArea;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, 0);
		if (!initializedQuantities)
		{
			L = new Vector3D(nodes[Connection[0]], nodes[Connection[1]]).Length;
		}
		double num = L * L;
		double _0023_003DzVSAhiYo_003D = num * L;
		return _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, sectionArea);
	}

	internal double _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzhP_00249tPG__0024QG7)
	{
		double num;
		if (!HingeStart && !HingeEnd)
		{
			num = -1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[0] + 1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[3];
			if (Temperature != 0.0)
			{
				double num2 = mat.CoeffOfThermalExp * Temperature;
				num -= num2;
			}
		}
		else
		{
			num = -1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[0] + 1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[3];
			if (Temperature != 0.0)
			{
				double num3 = mat.CoeffOfThermalExp * Temperature;
				num -= num3;
			}
		}
		double num4 = mat.Young * _0023_003DzhP_00249tPG__0024QG7 * num;
		if (AxialPressureBeam != 0.0)
		{
			double num5 = _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D * distLoad[0] - (1.0 - _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D) * distLoad[3];
			num4 -= num5;
		}
		if (_alongBeamLoads != null && _alongBeamLoad.Value[0] != 0.0)
		{
			num4 = ((!(_0023_003DzNDQ_E88_003D > _alongBeamLoad.Key)) ? (num4 + _alongBeamLoads[0]) : (num4 - _alongBeamLoads[3]));
		}
		return num4;
	}

	public void CalcMomentAndForces(Point3D[] nodes, double t, out double bendingMoment, out double shearForce, out double axialForce)
	{
		double _0023_003DzEj_7zY0_003D = mat.Young * ((MaterialBeam)mat).Iw;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, 0);
		if (!initializedQuantities)
		{
			L = new Vector3D(nodes[Connection[0]], nodes[Connection[1]]).Length;
		}
		double num = L * L;
		double _0023_003DzVSAhiYo_003D = num * L;
		bendingMoment = _0023_003DzLX7kOPjiM_0024qCT3a5eUZKopA_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		shearForce = _0023_003DzUB_0024BC5Lq7uPDjANuBg_003D_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, _0023_003DzEj_7zY0_003D);
		axialForce = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D, t, L, num, _0023_003DzVSAhiYo_003D, ((MaterialBeam)mat).SectionArea);
	}

	public double[] CalcDisplacementsAlongTheBeam(Point3D[] nodes, double t, int mode = 0)
	{
		double num = mat.Young * ((MaterialBeam)mat).Iw;
		double[] array = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, mode);
		if (!initializedQuantities)
		{
			L = new Vector3D(nodes[Connection[0]], nodes[Connection[1]]).Length;
		}
		double num2 = L * L;
		double num3 = num2 * L;
		double num4 = t * t;
		double num5 = num4 * t;
		double num6 = (1.0 - t / L) * array[0] + t / L * array[3];
		double num7 = (1.0 - 3.0 * num4 / num2 + 2.0 * num5 / num3) * array[1] + (t - 2.0 * num4 / L + num5 / num2) * array[2] + (3.0 * num4 / num2 - 2.0 * num5 / num3) * array[4] + ((0.0 - num4) / L + num5 / num2) * array[5];
		if (PerpPressureBeam != 0.0)
		{
			if (HingeStart)
			{
				num7 = ((!HingeEnd) ? (num7 - PerpPressureBeam * t / (48.0 * num) * (num3 - 3.0 * L * num4 + 2.0 * num5)) : (num7 - PerpPressureBeam * t / (24.0 * num) * (num3 - 2.0 * L * num4 + num5)));
			}
			else if (HingeEnd)
			{
				double num8 = L - t;
				double num9 = num8 * num8;
				double num10 = num8 * num9;
				num7 -= PerpPressureBeam * num8 / (48.0 * num) * (num3 - 3.0 * L * num9 + 2.0 * num10);
			}
			else
			{
				num7 -= PerpPressureBeam / (24.0 * num) * (L - t) * (L - t) * num4;
			}
		}
		if (_alongBeamLoads != null)
		{
			double key = _alongBeamLoad.Key;
			double num11 = L - key;
			if (t < key)
			{
				num7 += _alongBeamLoad.Value.Y * num4 * num11 * num11 / (6.0 * num * num3) * (2.0 * key * (L - t) + L * (key - t));
			}
			else
			{
				double num12 = L - t;
				num7 += _alongBeamLoad.Value.Y * num12 * num12 * key * key / (6.0 * num * num3) * (2.0 * num11 * (L - num12) + L * (num11 - num12));
			}
		}
		return new double[3] { num6, num7, 0.0 };
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzMasDKnav2nxX(context, vertices, _0023_003Dzz1fGUs2oBc0E: false, mode);
	}

	public override void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzMasDKnav2nxX(context, vertices, _0023_003Dzz1fGUs2oBc0E: true, mode);
	}

	private void _0023_003DzMasDKnav2nxX(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, bool _0023_003Dzz1fGUs2oBc0E, int _0023_003DznXXM9vk_003D)
	{
		Node _0023_003DzO2ha6ckJVFiD = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		_0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz_eY3Y4c_003D, out var _, out var _0023_003DzAvn2b38_003D, out var _0023_003DzELnUZQyM6IsC);
		_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzAvn2b38_003D, _0023_003DzO2ha6ckJVFiD, _0023_003DzELnUZQyM6IsC, _0023_003Dz_eY3Y4c_003D, null, 0.0, 0.0, 0.0, 0.0, _0023_003DzpXqcGaz7sKJt: false, null, _0023_003DzAI3jPBBmCGmn: true, _0023_003DzXiGznWxb_0eQ: true, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
	}

	internal void _0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Vector3D _0023_003Dz_eY3Y4c_003D, out Vector3D _0023_003Dz77g161c_003D, out Vector3D _0023_003DzAvn2b38_003D, out double _0023_003DzELnUZQyM6IsC)
	{
		Node p = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node p2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		_0023_003Dz_eY3Y4c_003D = new Vector3D(p, p2);
		_0023_003Dz_eY3Y4c_003D.Normalize();
		_0023_003DzAvn2b38_003D = Vector3D.AxisZ;
		_0023_003Dz77g161c_003D = Vector3D.Cross(_0023_003DzAvn2b38_003D, _0023_003Dz_eY3Y4c_003D);
		Segment3D segment3D = new Segment3D(p, p2);
		_0023_003DzELnUZQyM6IsC = segment3D.Length;
	}

	internal void _0023_003DzaXawPti23jEv(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Point3D[] array = new Point3D[8];
		Color[] array2 = new Color[8];
		int num = 0;
		array[num] = node;
		array2[num++] = mat.Diffuse;
		array[num] = node2;
		array2[num++] = mat.Diffuse;
		Segment3D segment3D = new Segment3D(node, node2);
		Vector3D vector3D = Vector3D.Subtract(node2, node);
		vector3D.Normalize();
		Vector3D axisZ = Vector3D.AxisZ;
		Vector3D vector3D2 = Vector3D.Cross(axisZ, vector3D);
		double num2 = segment3D.Length * 0.075;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Red;
		array[num] = segment3D.MidPoint + vector3D * num2;
		array2[num++] = Color.Red;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Green;
		array[num] = segment3D.MidPoint + vector3D2 * num2;
		array2[num++] = Color.Green;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Blue;
		array[num] = segment3D.MidPoint + axisZ * num2;
		array2[num++] = Color.Blue;
		_0023_003DzB8iS0QA_003D.DrawLines(array, array2);
		if (HingeStart || HingeEnd)
		{
			double num3 = _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D / 100.0;
			double num4 = segment3D.Length / 100.0 * 5.0;
			if (num3 < num4)
			{
				num3 = num4;
			}
			double num5 = segment3D.Length / 5.0;
			if (num3 > num5)
			{
				num3 = num4;
			}
			_0023_003DzB8iS0QA_003D.SetColorWireframe(Color.FromArgb(0, 255, 0));
			_0023_003DzB8iS0QA_003D.PushShader();
			_0023_003DzB8iS0QA_003D.SetPointSize(6f);
			if (HingeStart)
			{
				Point3D point3D = node + vector3D * num3;
				_0023_003DzB8iS0QA_003D.DrawPoints(new Point3D[1] { point3D });
			}
			if (HingeEnd)
			{
				Point3D point3D2 = node2 - vector3D * num3;
				_0023_003DzB8iS0QA_003D.DrawPoints(new Point3D[1] { point3D2 });
			}
			_0023_003DzB8iS0QA_003D.PopShader();
		}
	}

	public override void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		DrawWithSharpColorElement(context, singleNormal, vertices, min, max, ampFactor, mode);
	}

	public override void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003Dzfl9GWk_0024bAGr6_0024mhmcThGjZf4swUh(context, vertices, min, max, ampFactor, null, mode);
	}

	internal void _0023_003DzoWW7VaZ6bbGLCHQ_0024W_abLcU_003D(double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D _0023_003Dz_eY3Y4c_003D, Vector3D _0023_003Dz77g161c_003D, double _0023_003DzxigXYm0EiNwh, int _0023_003DzKWlpThug3Qun, out Point3D _0023_003DzFj_0024IqDQ_003D, out Point3D _0023_003DzjdeMMkk_003D, out Vector3D _0023_003DzLz7mDrk_003D, out Vector3D _0023_003DzZpdQVNE_003D, out double _0023_003Dz6gJpTukVm_0024VY)
	{
		Node obj = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		double num = _0023_003DzxigXYm0EiNwh * (double)_0023_003DzKWlpThug3Qun;
		double num2 = _0023_003DzxigXYm0EiNwh * (double)(_0023_003DzKWlpThug3Qun + 1);
		Point3D point3D = obj + num * _0023_003Dz_eY3Y4c_003D;
		Point3D point3D2 = obj + num2 * _0023_003Dz_eY3Y4c_003D;
		double[] array = CalcDisplacementsAlongTheBeam(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, num, _0023_003DznXXM9vk_003D);
		double[] array2 = CalcDisplacementsAlongTheBeam(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, num2, _0023_003DznXXM9vk_003D);
		_0023_003DzFj_0024IqDQ_003D = point3D + _0023_003Dz_eY3Y4c_003D * array[0] * _0023_003DzXGmnJb5mDXOU + _0023_003Dz77g161c_003D * array[1] * _0023_003DzXGmnJb5mDXOU;
		_0023_003DzjdeMMkk_003D = point3D2 + _0023_003Dz_eY3Y4c_003D * array2[0] * _0023_003DzXGmnJb5mDXOU + _0023_003Dz77g161c_003D * array2[1] * _0023_003DzXGmnJb5mDXOU;
		_0023_003DzLz7mDrk_003D = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		if (!_0023_003DzLz7mDrk_003D.Normalize())
		{
			_0023_003DzLz7mDrk_003D = _0023_003Dz_eY3Y4c_003D;
		}
		_0023_003DzZpdQVNE_003D = Vector3D.Cross(_0023_003DzLz7mDrk_003D, _0023_003Dz77g161c_003D);
		_0023_003DzZpdQVNE_003D.Normalize();
		Segment3D segment3D = new Segment3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		_0023_003Dz6gJpTukVm_0024VY = segment3D.Length;
	}
}
