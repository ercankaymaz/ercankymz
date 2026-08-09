using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class Beam : Element3D
{
	internal KeyValuePair<double, Vector3D> _alongBeamLoad;

	internal double[] _alongBeamLoads;

	public double Temperature;

	internal Vector3D v;

	internal Point3D[] beamVerts;

	private double[] _bendingMomentW;

	private double[] _bendingMomentV;

	private double[] _shearForceW;

	private double[] _shearForceV;

	private double[] _axialForce;

	private double[] _twistAngle;

	private double _torsionMoment;

	internal double AxialPressureBeam;

	internal double PerpPressureBeamV;

	internal double PerpPressureBeamW;

	public int SubdivisionNumber { get; set; }

	public bool HingeStart { get; set; }

	public bool HingeEnd { get; set; }

	public double[] BendingMomentW => _bendingMomentW;

	public double[] BendingMomentV => _bendingMomentV;

	public double[] ShearForceW => _shearForceW;

	public double[] ShearForceV => _shearForceV;

	public double[] AxialForce => _axialForce;

	public double[] TwistAngle => _twistAngle;

	public double TorsionMoment => _torsionMoment;

	public Beam(int nodeIndex1, int nodeIndex2, MaterialBeam mat)
		: base(2, mat)
	{
		NumberOfDofPerNode = 6;
		NumberOfDimensions = 6;
		NumberOfGaussPoints = 0;
		Connection = new int[NumberOfNodes];
		Connection[0] = nodeIndex1;
		Connection[1] = nodeIndex2;
		SubdivisionNumber = 10;
		HingeStart = false;
		HingeEnd = false;
		elFaces = new Face[1]
		{
			new Face(new byte[2] { 0, 1 })
		};
	}

	protected Beam(Beam another)
		: base(another)
	{
		v = (Vector3D)another.v.Clone();
		SubdivisionNumber = another.SubdivisionNumber;
		HingeStart = another.HingeStart;
		HingeEnd = another.HingeEnd;
		elFaces = another.elFaces;
	}

	public override object Clone()
	{
		return new Beam(this);
	}

	public override FemElementSurrogate ConvertToSurrogate()
	{
		return new FemBeamSurrogate(this);
	}

	public void SetStartSectionVertices(Point3D[] vertices)
	{
		beamVerts = vertices;
	}

	internal void _0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(Point3D[] _0023_003DzDvuIQCU_003D, out double _0023_003DzEWLeis8_003D, out double[,] _0023_003DzWWgGxds_003D)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003DzDvuIQCU_003D, out _0023_003DzEWLeis8_003D, out _0023_003DzWWgGxds_003D, out var _, out var _);
	}

	internal void _0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(Point3D[] _0023_003DzDvuIQCU_003D, out double _0023_003DzEWLeis8_003D, out double[,] _0023_003DzWWgGxds_003D, out Vector3D _0023_003Dz_eY3Y4c_003D, out Vector3D _0023_003DzAvn2b38_003D)
	{
		_0023_003DzEWLeis8_003D = _0023_003DzDvuIQCU_003D[Connection[0]].DistanceTo(_0023_003DzDvuIQCU_003D[Connection[1]]);
		_0023_003Dz_eY3Y4c_003D = new Vector3D(_0023_003DzDvuIQCU_003D[Connection[0]], _0023_003DzDvuIQCU_003D[Connection[1]]);
		_0023_003Dz_eY3Y4c_003D.Normalize();
		if (v == null)
		{
			_0023_003DzqkQ1pF0_003D(_0023_003Dz_eY3Y4c_003D);
		}
		_0023_003DzAvn2b38_003D = Vector3D.Cross(_0023_003Dz_eY3Y4c_003D, v);
		_0023_003DzAvn2b38_003D.Normalize();
		_0023_003DzWWgGxds_003D = _0023_003DzAw6gMzECPNwD(_0023_003Dz_eY3Y4c_003D, _0023_003DzAvn2b38_003D);
	}

	private void _0023_003DzqkQ1pF0_003D(Vector3D _0023_003Dz_eY3Y4c_003D)
	{
		v = Vector3D.Cross(Vector3D.AxisZ, _0023_003Dz_eY3Y4c_003D);
		if (v.Length < 1E-06)
		{
			v = Vector3D.AxisY;
		}
		v.Normalize();
	}

	private double[,] _0023_003DzAw6gMzECPNwD(Vector3D _0023_003Dz_eY3Y4c_003D, Vector3D _0023_003DzAvn2b38_003D)
	{
		double x = _0023_003Dz_eY3Y4c_003D.X;
		double y = _0023_003Dz_eY3Y4c_003D.Y;
		double z = _0023_003Dz_eY3Y4c_003D.Z;
		double x2 = v.X;
		double y2 = v.Y;
		double z2 = v.Z;
		double x3 = _0023_003DzAvn2b38_003D.X;
		double y3 = _0023_003DzAvn2b38_003D.Y;
		double z3 = _0023_003DzAvn2b38_003D.Z;
		double[,] array = new double[base.TotalDof, base.TotalDof];
		array[0, 0] = (array[3, 3] = (array[6, 6] = (array[9, 9] = x)));
		array[0, 1] = (array[3, 4] = (array[6, 7] = (array[9, 10] = y)));
		array[0, 2] = (array[3, 5] = (array[6, 8] = (array[9, 11] = z)));
		array[1, 0] = (array[4, 3] = (array[7, 6] = (array[10, 9] = x2)));
		array[1, 1] = (array[4, 4] = (array[7, 7] = (array[10, 10] = y2)));
		array[1, 2] = (array[4, 5] = (array[7, 8] = (array[10, 11] = z2)));
		array[2, 0] = (array[5, 3] = (array[8, 6] = (array[11, 9] = x3)));
		array[2, 1] = (array[5, 4] = (array[8, 7] = (array[11, 10] = y3)));
		array[2, 2] = (array[5, 5] = (array[8, 8] = (array[11, 11] = z3)));
		return array;
	}

	public void SetLocalCoordinates(IList<Point3D> nodes, Vector3D vAxis)
	{
		v = (Vector3D)vAxis.Clone();
		v.Normalize();
	}

	public override void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
		M = new double[12, 12];
		double num = ((MaterialBeam)mat).Iv + ((MaterialBeam)mat).Iw;
		double sectionArea = ((MaterialBeam)mat).SectionArea;
		double density = mat.Density;
		double num2 = nodes[Connection[0]].DistanceTo(nodes[Connection[1]]);
		M[0, 0] = 1.0 / 3.0;
		M[1, 1] = 13.0 / 35.0;
		M[2, 2] = 13.0 / 35.0;
		M[3, 3] = num / (3.0 * sectionArea);
		M[4, 4] = num2 * num2 / 105.0;
		M[5, 5] = num2 * num2 / 105.0;
		M[6, 6] = 1.0 / 3.0;
		M[7, 7] = 13.0 / 35.0;
		M[8, 8] = 13.0 / 35.0;
		M[9, 9] = num / (3.0 * sectionArea);
		M[10, 10] = num2 * num2 / 105.0;
		M[11, 11] = num2 * num2 / 105.0;
		M[4, 2] = (M[2, 4] = -11.0 / 210.0 * num2);
		M[5, 1] = (M[1, 5] = 11.0 / 210.0 * num2);
		M[6, 0] = (M[0, 6] = 1.0 / 6.0);
		M[7, 5] = (M[5, 7] = 13.0 / 420.0 * num2);
		M[7, 1] = (M[1, 7] = 9.0 / 70.0);
		M[8, 2] = (M[2, 8] = 9.0 / 70.0);
		M[8, 4] = (M[4, 8] = -13.0 / 420.0 * num2);
		M[9, 3] = (M[3, 9] = num / (6.0 * sectionArea));
		M[10, 8] = (M[8, 10] = 11.0 / 210.0 * num2);
		M[10, 2] = (M[2, 10] = num2 * 13.0 / 420.0);
		M[10, 4] = (M[4, 10] = (0.0 - num2) * num2 / 140.0);
		M[11, 5] = (M[5, 11] = (0.0 - num2) * num2 / 140.0);
		M[11, 7] = (M[7, 11] = -11.0 / 210.0 * num2);
		M[11, 1] = (M[1, 11] = -13.0 / 420.0 * num2);
		for (int i = 0; i < 12; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				M[i, j] *= density * sectionArea * num2;
			}
		}
	}

	public override void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double young = mat.Young;
		double num = young * materialBeam.Iw;
		double num2 = young * materialBeam.Iv;
		double shearModulus = mat.ShearModulus;
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes, out var _0023_003DzEWLeis8_003D, out var _0023_003DzWWgGxds_003D);
		K = new double[base.TotalDof, base.TotalDof];
		StressMatrix = new double[NumberOfGaussPoints, base.TotalDof, NumberOfStressesPerNode];
		double[,] array = new double[base.TotalDof, base.TotalDof];
		if (!HingeStart && !HingeEnd)
		{
			double num3 = young * materialBeam.SectionArea / _0023_003DzEWLeis8_003D;
			double num4 = 12.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num5 = 6.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num6 = 4.0 * num / _0023_003DzEWLeis8_003D;
			double num7 = 2.0 * num / _0023_003DzEWLeis8_003D;
			double num8 = shearModulus * materialBeam.TorsionK / _0023_003DzEWLeis8_003D;
			double num9 = 12.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num10 = 6.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num11 = 4.0 * num2 / _0023_003DzEWLeis8_003D;
			double num12 = 2.0 * num2 / _0023_003DzEWLeis8_003D;
			array[0, 0] = (array[6, 6] = num3);
			array[6, 0] = 0.0 - num3;
			array[1, 1] = (array[7, 7] = num4);
			array[7, 1] = 0.0 - num4;
			array[5, 1] = (array[11, 1] = num5);
			array[7, 5] = (array[11, 7] = 0.0 - num5);
			array[2, 2] = (array[8, 8] = num9);
			array[8, 2] = 0.0 - num9;
			array[4, 2] = (array[10, 2] = 0.0 - num10);
			array[8, 4] = (array[10, 8] = num10);
			array[3, 3] = (array[9, 9] = num8);
			array[9, 3] = 0.0 - num8;
			array[4, 4] = (array[10, 10] = num11);
			array[5, 5] = (array[11, 11] = num6);
			array[10, 4] = num12;
			array[11, 5] = num7;
			array[0, 6] = 0.0 - num3;
			array[1, 5] = (array[1, 11] = num5);
			array[1, 7] = 0.0 - num4;
			array[2, 4] = (array[2, 10] = 0.0 - num10);
			array[2, 8] = 0.0 - num9;
			array[3, 9] = 0.0 - num8;
			array[4, 8] = (array[8, 10] = num10);
			array[4, 10] = num12;
			array[5, 7] = (array[7, 11] = 0.0 - num5);
			array[5, 11] = num7;
		}
		else if (HingeStart && HingeEnd)
		{
			double num13 = young * materialBeam.SectionArea / _0023_003DzEWLeis8_003D;
			array[0, 0] = (array[6, 6] = num13);
			array[6, 0] = (array[0, 6] = 0.0 - num13);
		}
		else if (HingeStart)
		{
			double num14 = young * materialBeam.SectionArea / _0023_003DzEWLeis8_003D;
			double num15 = 3.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num16 = 3.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num17 = 3.0 * num / _0023_003DzEWLeis8_003D;
			double num18 = 3.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num19 = 3.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num20 = 3.0 * num2 / _0023_003DzEWLeis8_003D;
			array[0, 0] = (array[6, 6] = num14);
			array[0, 6] = (array[6, 0] = 0.0 - num14);
			array[1, 1] = (array[7, 7] = num15);
			array[1, 7] = (array[7, 1] = 0.0 - num15);
			array[1, 11] = (array[11, 1] = num16);
			array[7, 11] = (array[11, 7] = 0.0 - num16);
			array[2, 2] = (array[8, 8] = num18);
			array[2, 8] = (array[8, 2] = 0.0 - num18);
			array[2, 10] = (array[10, 2] = 0.0 - num19);
			array[8, 10] = (array[10, 8] = num19);
			array[10, 10] = num20;
			array[11, 11] = num17;
		}
		else
		{
			double num21 = young * materialBeam.SectionArea / _0023_003DzEWLeis8_003D;
			double num22 = 3.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num23 = 3.0 * num / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num24 = 3.0 * num / _0023_003DzEWLeis8_003D;
			double num25 = 3.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num26 = 3.0 * num2 / (_0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D);
			double num27 = 3.0 * num2 / _0023_003DzEWLeis8_003D;
			array[0, 0] = (array[6, 6] = num21);
			array[0, 6] = (array[6, 0] = 0.0 - num21);
			array[1, 1] = (array[7, 7] = num22);
			array[1, 7] = (array[7, 1] = 0.0 - num22);
			array[1, 5] = (array[5, 1] = num23);
			array[7, 5] = (array[5, 7] = 0.0 - num23);
			array[2, 2] = (array[8, 8] = num25);
			array[2, 8] = (array[8, 2] = 0.0 - num25);
			array[4, 2] = (array[2, 4] = 0.0 - num26);
			array[8, 4] = (array[4, 8] = num26);
			array[4, 4] = num27;
			array[5, 5] = num24;
		}
		double[,] a = Matrix.Multiply(Matrix.Transpose(_0023_003DzWWgGxds_003D), array);
		K = Matrix.Multiply(a, _0023_003DzWWgGxds_003D);
		StiffnessComputation(nodes);
	}

	public override void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double young = mat.Young;
		double _0023_003DzoeWcMeQ_003D = young * materialBeam.Iw;
		double _0023_003DzzFgDFp4_003D = young * materialBeam.Iv;
		double sectionArea = materialBeam.SectionArea;
		double shearModulus = mat.ShearModulus;
		double _0023_003DzEWLeis8_003D;
		double[] array = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, 0, out _0023_003DzEWLeis8_003D);
		double num = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
		double _0023_003DzVSAhiYo_003D = num * _0023_003DzEWLeis8_003D;
		double[] array2 = _0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(array, 0.0, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		double[] array3 = _0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(array, _0023_003DzEWLeis8_003D, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		_bendingMomentW = new double[2]
		{
			array2[0],
			array3[0]
		};
		_bendingMomentV = new double[2]
		{
			array2[1],
			array3[1]
		};
		double[] array4 = _0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(array, 0.0, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		double[] array5 = _0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(array, _0023_003DzEWLeis8_003D, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		_shearForceV = new double[2]
		{
			array4[0],
			array5[0]
		};
		_shearForceW = new double[2]
		{
			array4[1],
			array5[1]
		};
		double num2 = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(array, 0.0, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, sectionArea);
		double num3 = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(array, _0023_003DzEWLeis8_003D, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, sectionArea);
		_axialForce = new double[2] { num2, num3 };
		_twistAngle = new double[2];
		_twistAngle[0] = _0023_003DzaIZASCgKPfgv_EKIYg_003D_003D(array, 0.0, _0023_003DzEWLeis8_003D);
		_twistAngle[1] = _0023_003DzaIZASCgKPfgv_EKIYg_003D_003D(array, _0023_003DzEWLeis8_003D, _0023_003DzEWLeis8_003D);
		double num4 = -1.0 / _0023_003DzEWLeis8_003D * array[3] + 1.0 / _0023_003DzEWLeis8_003D * array[9];
		_torsionMoment = shearModulus * materialBeam.TorsionK * num4;
	}

	internal double[] _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(Point3D[] _0023_003DzDvuIQCU_003D, int _0023_003DznXXM9vk_003D, out double _0023_003DzEWLeis8_003D)
	{
		double[] array = new double[base.TotalDof];
		for (int i = 0; i < NumberOfDofPerNode; i++)
		{
			array[i] = ((Node)_0023_003DzDvuIQCU_003D[Connection[0]]).Unknowns[_0023_003DznXXM9vk_003D][i];
			array[i + NumberOfDofPerNode] = ((Node)_0023_003DzDvuIQCU_003D[Connection[1]]).Unknowns[_0023_003DznXXM9vk_003D][i];
		}
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003DzDvuIQCU_003D, out _0023_003DzEWLeis8_003D, out var _0023_003DzWWgGxds_003D);
		return Matrix.Multiply(_0023_003DzWWgGxds_003D, array);
	}

	public void CalcMoments(Point3D[] nodes, double t, out double torsion, out double bendingV, out double bendingW, int mode = 0)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double young = mat.Young;
		double _0023_003DzoeWcMeQ_003D = young * materialBeam.Iw;
		double _0023_003DzzFgDFp4_003D = young * materialBeam.Iv;
		double _0023_003DzEWLeis8_003D;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, mode, out _0023_003DzEWLeis8_003D);
		double num = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
		double _0023_003DzVSAhiYo_003D = num * _0023_003DzEWLeis8_003D;
		double[] array = _0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(_0023_003Dzt38nTwk_003D, t, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		bendingW = array[0];
		bendingV = array[1];
		torsion = TorsionMoment;
	}

	public void CalcForces(Point3D[] nodes, double t, out double axial, out double shearV, out double shearW)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double young = mat.Young;
		double _0023_003DzoeWcMeQ_003D = young * materialBeam.Iw;
		double _0023_003DzzFgDFp4_003D = young * materialBeam.Iv;
		double sectionArea = materialBeam.SectionArea;
		double _0023_003DzEWLeis8_003D;
		double[] _0023_003Dzt38nTwk_003D = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, 0, out _0023_003DzEWLeis8_003D);
		double num = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
		double _0023_003DzVSAhiYo_003D = num * _0023_003DzEWLeis8_003D;
		double[] array = _0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(_0023_003Dzt38nTwk_003D, t, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
		shearV = array[0];
		shearW = array[1];
		axial = _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D, t, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, sectionArea);
	}

	internal double _0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzhP_00249tPG__0024QG7)
	{
		double num;
		if (!HingeStart && !HingeEnd)
		{
			num = -1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[0] + 1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[6];
			if (Temperature != 0.0)
			{
				double num2 = mat.CoeffOfThermalExp * Temperature;
				num -= num2;
			}
		}
		else
		{
			num = -1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[0] + 1.0 / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[6];
			if (Temperature != 0.0)
			{
				double num3 = mat.CoeffOfThermalExp * Temperature;
				num -= num3;
			}
		}
		double num4 = mat.Young * _0023_003DzhP_00249tPG__0024QG7 * num;
		if (AxialPressureBeam != 0.0)
		{
			double num5 = _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D * distLoad[0] - (1.0 - _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D) * distLoad[6];
			num4 -= num5;
		}
		if (_alongBeamLoads != null && _alongBeamLoad.Value[0] != 0.0)
		{
			num4 = ((!(_0023_003DzNDQ_E88_003D > _alongBeamLoad.Key)) ? (num4 + _alongBeamLoads[0]) : (num4 - _alongBeamLoads[6]));
		}
		return num4;
	}

	internal double[] _0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzzFgDFp4_003D, double _0023_003DzoeWcMeQ_003D)
	{
		double num = ((!HingeStart && !HingeEnd) ? ((-6.0 / _0023_003DzOKtgTr4_003D + 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + (-4.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[5] + (6.0 / _0023_003DzOKtgTr4_003D - 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[7] + (-2.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[11]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? ((0.0 - 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + (0.0 - 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[5] + (0.0 + 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[7] + 0.0 * _0023_003Dzt38nTwk_003D[11]) : ((0.0 + 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[1] + 0.0 * _0023_003Dzt38nTwk_003D[5] + (0.0 - 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[7] + (0.0 + 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[11]))));
		double num2 = _0023_003DzoeWcMeQ_003D * num;
		if (PerpPressureBeamV != 0.0)
		{
			if (HingeStart)
			{
				num2 = ((!HingeEnd) ? (num2 - PerpPressureBeamV * _0023_003DzNDQ_E88_003D * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D / 2.0)) : (num2 - PerpPressureBeamV * _0023_003DzNDQ_E88_003D / 2.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num3 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num2 -= PerpPressureBeamV * num3 * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num3 / 2.0);
			}
			else
			{
				num2 += PerpPressureBeamV / 12.0 * (_0023_003DzOKtgTr4_003D - 6.0 * _0023_003DzEWLeis8_003D * _0023_003DzNDQ_E88_003D + 6.0 * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null && _alongBeamLoad.Value[1] != 0.0)
		{
			if (_0023_003DzNDQ_E88_003D == 0.0)
			{
				num2 += _alongBeamLoads[5];
			}
			else if (_0023_003DzNDQ_E88_003D == _0023_003DzEWLeis8_003D)
			{
				num2 -= _alongBeamLoads[11];
			}
			else
			{
				num2 = BendingMomentW[0] + ShearForceV[0] * _0023_003DzNDQ_E88_003D;
				if (_0023_003DzNDQ_E88_003D > _alongBeamLoad.Key)
				{
					num2 += (_0023_003DzNDQ_E88_003D - _alongBeamLoad.Key) * _alongBeamLoad.Value[1];
				}
			}
		}
		double num4 = ((!HingeStart && !HingeEnd) ? ((-6.0 / _0023_003DzOKtgTr4_003D + 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[2] - (-4.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[4] + (6.0 / _0023_003DzOKtgTr4_003D - 12.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[8] - (-2.0 / _0023_003DzEWLeis8_003D + 6.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[10]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? ((0.0 - 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[2] + (0.0 + 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[4] + (0.0 + 3.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D) / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[8] + 0.0 * _0023_003Dzt38nTwk_003D[10]) : ((0.0 + 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[2] + 0.0 * _0023_003Dzt38nTwk_003D[4] + (0.0 - 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzVSAhiYo_003D) * _0023_003Dzt38nTwk_003D[8] + (0.0 - 3.0 * _0023_003DzNDQ_E88_003D / _0023_003DzOKtgTr4_003D) * _0023_003Dzt38nTwk_003D[10]))));
		double num5 = (0.0 - _0023_003DzzFgDFp4_003D) * num4;
		if (PerpPressureBeamW != 0.0)
		{
			if (HingeStart)
			{
				num5 = ((!HingeEnd) ? (num5 + PerpPressureBeamW * _0023_003DzNDQ_E88_003D * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D / 2.0)) : (num5 + PerpPressureBeamW * _0023_003DzNDQ_E88_003D / 2.0 * (_0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num6 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num5 += PerpPressureBeamW * num6 * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num6 / 2.0);
			}
			else
			{
				num5 -= PerpPressureBeamW / 12.0 * (_0023_003DzOKtgTr4_003D - 6.0 * _0023_003DzEWLeis8_003D * _0023_003DzNDQ_E88_003D + 6.0 * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null && _alongBeamLoad.Value[2] != 0.0)
		{
			if (_0023_003DzNDQ_E88_003D == 0.0)
			{
				num5 += _alongBeamLoads[4];
			}
			else if (_0023_003DzNDQ_E88_003D == _0023_003DzEWLeis8_003D)
			{
				num5 -= _alongBeamLoads[10];
			}
			else
			{
				num5 = BendingMomentV[0] - ShearForceW[0] * _0023_003DzNDQ_E88_003D;
				if (_0023_003DzNDQ_E88_003D > _alongBeamLoad.Key)
				{
					num5 -= (_0023_003DzNDQ_E88_003D - _alongBeamLoad.Key) * _alongBeamLoad.Value[2];
				}
			}
		}
		return new double[2] { num2, num5 };
	}

	internal double[] _0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D, double _0023_003DzOKtgTr4_003D, double _0023_003DzVSAhiYo_003D, double _0023_003DzzFgDFp4_003D, double _0023_003DzoeWcMeQ_003D)
	{
		double num = ((!HingeStart && !HingeEnd) ? (12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[5] + -12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[7] + 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[11]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? (-3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + -3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[5] + 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[7] + 0.0 * _0023_003Dzt38nTwk_003D[11]) : (3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 0.0 * _0023_003Dzt38nTwk_003D[5] - 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[7] + 3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[11]))));
		double num2 = _0023_003DzoeWcMeQ_003D * num;
		if (PerpPressureBeamV != 0.0)
		{
			if (HingeStart)
			{
				num2 = ((!HingeEnd) ? (num2 + PerpPressureBeamV * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D)) : (num2 + PerpPressureBeamV * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num3 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num2 += PerpPressureBeamV * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num3);
			}
			else
			{
				num2 -= PerpPressureBeamV * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null)
		{
			num2 = ((!(_0023_003DzNDQ_E88_003D < _alongBeamLoad.Key)) ? (num2 + _alongBeamLoads[7]) : (num2 - _alongBeamLoads[1]));
		}
		double num4 = ((!HingeStart && !HingeEnd) ? (12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[2] - 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[4] + -12.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[8] - 6.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[10]) : ((HingeStart && HingeEnd) ? 0.0 : ((!HingeStart) ? (-3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[5] + 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[7] + 0.0 * _0023_003Dzt38nTwk_003D[11]) : (3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[1] + 0.0 * _0023_003Dzt38nTwk_003D[5] - 3.0 / _0023_003DzVSAhiYo_003D * _0023_003Dzt38nTwk_003D[7] - 3.0 / _0023_003DzOKtgTr4_003D * _0023_003Dzt38nTwk_003D[11]))));
		double num5 = _0023_003DzzFgDFp4_003D * num4;
		if (PerpPressureBeamW != 0.0)
		{
			if (HingeStart)
			{
				num5 = ((!HingeEnd) ? (num5 + PerpPressureBeamW * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - _0023_003DzNDQ_E88_003D)) : (num5 + PerpPressureBeamW * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D)));
			}
			else if (HingeEnd)
			{
				double num6 = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
				num5 += PerpPressureBeamW * (3.0 * _0023_003DzEWLeis8_003D / 8.0 - num6);
			}
			else
			{
				num5 -= PerpPressureBeamW * (_0023_003DzEWLeis8_003D / 2.0 - _0023_003DzNDQ_E88_003D);
			}
		}
		if (_alongBeamLoads != null)
		{
			num5 = ((!(_0023_003DzNDQ_E88_003D < _alongBeamLoad.Key)) ? (num5 + _alongBeamLoads[8]) : (num5 - _alongBeamLoads[2]));
		}
		return new double[2] { num2, num5 };
	}

	private double _0023_003DzaIZASCgKPfgv_EKIYg_003D_003D(double[] _0023_003Dzt38nTwk_003D, double _0023_003DzNDQ_E88_003D, double _0023_003DzEWLeis8_003D)
	{
		return (1.0 - _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D) * _0023_003Dzt38nTwk_003D[3] + _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D * _0023_003Dzt38nTwk_003D[9];
	}

	public double[] CalcDisplacementsAlongTheBeam(Point3D[] nodes, double t, int mode = 0)
	{
		MaterialBeam materialBeam = (MaterialBeam)mat;
		double young = mat.Young;
		double num = young * materialBeam.Iw;
		double num2 = young * materialBeam.Iv;
		double _0023_003DzEWLeis8_003D;
		double[] array = _0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(nodes, mode, out _0023_003DzEWLeis8_003D);
		double num3 = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
		double num4 = num3 * _0023_003DzEWLeis8_003D;
		double num5 = t * t;
		double num6 = num5 * t;
		double num7 = (1.0 - t / _0023_003DzEWLeis8_003D) * array[0] + t / _0023_003DzEWLeis8_003D * array[6];
		double num8 = (1.0 - 3.0 * num5 / num3 + 2.0 * num6 / num4) * array[1] + (t - 2.0 * num5 / _0023_003DzEWLeis8_003D + num6 / num3) * array[5] + (3.0 * num5 / num3 - 2.0 * num6 / num4) * array[7] + ((0.0 - num5) / _0023_003DzEWLeis8_003D + num6 / num3) * array[11];
		if (PerpPressureBeamV != 0.0)
		{
			if (HingeStart)
			{
				num8 = ((!HingeEnd) ? (num8 + PerpPressureBeamV * t / (48.0 * num) * (num4 - 3.0 * _0023_003DzEWLeis8_003D * num5 + 2.0 * num6)) : (num8 + PerpPressureBeamV * t / (24.0 * num) * (num4 - 2.0 * _0023_003DzEWLeis8_003D * num5 + num6)));
			}
			else if (HingeEnd)
			{
				double num9 = _0023_003DzEWLeis8_003D - t;
				double num10 = num9 * num9;
				double num11 = num9 * num10;
				num8 += PerpPressureBeamV * num9 / (48.0 * num) * (num4 - 3.0 * _0023_003DzEWLeis8_003D * num10 + 2.0 * num11);
			}
			else
			{
				num8 += PerpPressureBeamV / (24.0 * num) * (_0023_003DzEWLeis8_003D - t) * (_0023_003DzEWLeis8_003D - t) * num5;
			}
		}
		if (_alongBeamLoads != null)
		{
			double key = _alongBeamLoad.Key;
			double num12 = _0023_003DzEWLeis8_003D - key;
			if (t < key)
			{
				num8 += _alongBeamLoad.Value.Y * num5 * num12 * num12 / (6.0 * num * num4) * (2.0 * key * (_0023_003DzEWLeis8_003D - t) + _0023_003DzEWLeis8_003D * (key - t));
			}
			else
			{
				double num13 = _0023_003DzEWLeis8_003D - t;
				num8 += _alongBeamLoad.Value.Y * num13 * num13 * key * key / (6.0 * num * num4) * (2.0 * num12 * (_0023_003DzEWLeis8_003D - num13) + _0023_003DzEWLeis8_003D * (num12 - num13));
			}
		}
		double num14 = (1.0 - 3.0 * num5 / num3 + 2.0 * num6 / num4) * array[2] + (0.0 - (t - 2.0 * num5 / _0023_003DzEWLeis8_003D + num6 / num3)) * array[4] + (3.0 * num5 / num3 - 2.0 * num6 / num4) * array[8] + (0.0 - ((0.0 - num5) / _0023_003DzEWLeis8_003D + num6 / num3)) * array[10];
		if (PerpPressureBeamW != 0.0)
		{
			if (HingeStart)
			{
				num14 = ((!HingeEnd) ? (num14 + PerpPressureBeamW * t / (48.0 * num2) * (num4 - 3.0 * _0023_003DzEWLeis8_003D * num5 + 2.0 * num6)) : (num14 + PerpPressureBeamW * t / (24.0 * num2) * (num4 - 2.0 * _0023_003DzEWLeis8_003D * num5 + num6)));
			}
			else if (HingeEnd)
			{
				double num15 = _0023_003DzEWLeis8_003D - t;
				double num16 = num15 * num15;
				double num17 = num15 * num16;
				num14 += PerpPressureBeamW * num15 / (48.0 * num2) * (num4 - 3.0 * _0023_003DzEWLeis8_003D * num16 + 2.0 * num17);
			}
			else
			{
				num14 += PerpPressureBeamW / (24.0 * num2) * (_0023_003DzEWLeis8_003D - t) * (_0023_003DzEWLeis8_003D - t) * num5;
			}
		}
		if (_alongBeamLoads != null)
		{
			double key2 = _alongBeamLoad.Key;
			double num18 = _0023_003DzEWLeis8_003D - key2;
			if (t < key2)
			{
				num14 += _alongBeamLoad.Value.Z * num5 * num18 * num18 / (6.0 * num2 * num4) * (2.0 * key2 * (_0023_003DzEWLeis8_003D - t) + _0023_003DzEWLeis8_003D * (key2 - t));
			}
			else
			{
				double num19 = _0023_003DzEWLeis8_003D - t;
				num14 += _alongBeamLoad.Value.Z * num19 * num19 * key2 * key2 / (6.0 * num2 * num4) * (2.0 * num18 * (_0023_003DzEWLeis8_003D - num19) + _0023_003DzEWLeis8_003D * (num18 - num19));
			}
		}
		return new double[3] { num7, num8, num14 };
	}

	public double[] CalcGlobalDisplacementsAlongTheBeam(Point3D[] nodes, double t)
	{
		double[] array = CalcDisplacementsAlongTheBeam(nodes, t);
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes, out var _, out var _, out var _0023_003Dz_eY3Y4c_003D, out var _0023_003DzAvn2b38_003D);
		Point3D point3D = (Node)nodes[Connection[0]] + t * _0023_003Dz_eY3Y4c_003D;
		Point3D p = point3D + _0023_003Dz_eY3Y4c_003D * array[0] + v * array[1] + _0023_003DzAvn2b38_003D * array[2];
		Vector3D vector3D = new Vector3D(point3D, p);
		return new double[3] { vector3D.X, vector3D.Y, vector3D.Z };
	}

	public override void SetPressure(int edgeIndex, Vector3D pressure, Point3D[] nodes)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984669));
	}

	public void SetDistributedLoad(Vector3D amount, Point3D[] nodes)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes, out var _, out var _, out var _0023_003Dz_eY3Y4c_003D, out var _);
		Align3D xform = new Align3D(new Plane(Point3D.Origin, _0023_003Dz_eY3Y4c_003D, v), Plane.XY);
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.TransformBy(xform);
		_0023_003Dzv5XRFuQ_0pMTljNF0Q_003D_003D(vector3D, nodes, _0023_003Dz4KKrSFI74_0024Et: false);
		base.SetPressure(0, amount, nodes);
	}

	public override void SetPressure(int edgeIndex, double pressure, Point3D[] nodes)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984669));
	}

	public void SetDistributedLoad(double amount, Point3D[] nodes)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes, out var _0023_003DzEWLeis8_003D, out var _0023_003DzWWgGxds_003D);
		PerpPressureBeamV += amount;
		double[] b = new double[12]
		{
			0.0,
			amount * _0023_003DzEWLeis8_003D / 2.0,
			0.0,
			0.0,
			0.0,
			amount * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0,
			0.0,
			amount * _0023_003DzEWLeis8_003D / 2.0,
			0.0,
			0.0,
			0.0,
			(0.0 - amount) * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0
		};
		double[] array = Matrix.Multiply(Matrix.Transpose(_0023_003DzWWgGxds_003D), b);
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		distLoad[0] += array[0];
		distLoad[1] += array[1];
		distLoad[2] += array[2];
		distLoad[3] += array[3];
		distLoad[4] += array[4];
		distLoad[5] += array[5];
		distLoad[6] += array[6];
		distLoad[7] += array[7];
		distLoad[8] += array[8];
		distLoad[9] += array[9];
		distLoad[10] += array[10];
		distLoad[11] += array[11];
		base.SetPressure(0, amount, nodes);
	}

	private void _0023_003Dzv5XRFuQ_0pMTljNF0Q_003D_003D(Vector3D _0023_003Dz6Bznvn_dghKhNojuyQ_003D_003D, Point3D[] _0023_003DzDvuIQCU_003D, bool _0023_003Dz4KKrSFI74_0024Et)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003DzDvuIQCU_003D, out var _0023_003DzEWLeis8_003D, out var _0023_003DzWWgGxds_003D, out var _0023_003Dz_eY3Y4c_003D, out var _);
		double x = _0023_003Dz6Bznvn_dghKhNojuyQ_003D_003D.X;
		double y = _0023_003Dz6Bznvn_dghKhNojuyQ_003D_003D.Y;
		double z = _0023_003Dz6Bznvn_dghKhNojuyQ_003D_003D.Z;
		if (_0023_003Dz4KKrSFI74_0024Et)
		{
			Align3D xform = new Align3D(new Plane(Point3D.Origin, Vector3D.AxisX, Vector3D.AxisY), new Plane(Point3D.Origin, _0023_003Dz_eY3Y4c_003D, v));
			Vector3D vector3D = (Vector3D)_0023_003Dz6Bznvn_dghKhNojuyQ_003D_003D.Clone();
			vector3D.TransformBy(xform);
			base.SetPressure(0, vector3D, _0023_003DzDvuIQCU_003D);
		}
		AxialPressureBeam += x;
		PerpPressureBeamV += y;
		PerpPressureBeamW += z;
		double[] b = new double[12]
		{
			x * _0023_003DzEWLeis8_003D / 2.0,
			y * _0023_003DzEWLeis8_003D / 2.0,
			z * _0023_003DzEWLeis8_003D / 2.0,
			0.0,
			(0.0 - z) * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0,
			y * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0,
			x * _0023_003DzEWLeis8_003D / 2.0,
			y * _0023_003DzEWLeis8_003D / 2.0,
			z * _0023_003DzEWLeis8_003D / 2.0,
			0.0,
			z * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0,
			(0.0 - y) * _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D / 12.0
		};
		double[] array = Matrix.Multiply(Matrix.Transpose(_0023_003DzWWgGxds_003D), b);
		if (distLoad == null)
		{
			distLoad = new double[base.TotalDof];
		}
		distLoad[0] += array[0];
		distLoad[1] += array[1];
		distLoad[2] += array[2];
		distLoad[3] += array[3];
		distLoad[4] += array[4];
		distLoad[5] += array[5];
		distLoad[6] += array[6];
		distLoad[7] += array[7];
		distLoad[8] += array[8];
		distLoad[9] += array[9];
		distLoad[10] += array[10];
		distLoad[11] += array[11];
	}

	public void SetDistributedLoad(double amountInV, double amountInW, Point3D[] nodes)
	{
		_0023_003Dzv5XRFuQ_0pMTljNF0Q_003D_003D(new Vector3D(0.0, amountInV, amountInW), nodes, _0023_003Dz4KKrSFI74_0024Et: true);
	}

	public void SetForce(Vector3D amount, double t, Point3D[] nodes)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(nodes, out var _, out var _, out var _0023_003Dz_eY3Y4c_003D, out var _);
		Align3D xform = new Align3D(new Plane(Point3D.Origin, _0023_003Dz_eY3Y4c_003D, v), Plane.XY);
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.TransformBy(xform);
		_0023_003DzsGciFNgFrjP4_HGFgCBrwTL9w004(vector3D, t, nodes, _0023_003Dz4KKrSFI74_0024Et: false);
		_alongBeamLoad = new KeyValuePair<double, Vector3D>(t, vector3D);
	}

	public void SetForce(double amountInV, double amountInW, double t, Point3D[] nodes)
	{
		_0023_003DzsGciFNgFrjP4_HGFgCBrwTL9w004(new Vector3D(0.0, amountInV, amountInW), t, nodes, _0023_003Dz4KKrSFI74_0024Et: true);
		_alongBeamLoad = new KeyValuePair<double, Vector3D>(t, new Vector3D(0.0, amountInV, amountInW));
	}

	private void _0023_003DzsGciFNgFrjP4_HGFgCBrwTL9w004(Vector3D _0023_003Dzcrymziv8HJnY, double _0023_003DzNDQ_E88_003D, Point3D[] _0023_003DzDvuIQCU_003D, bool _0023_003Dz4KKrSFI74_0024Et)
	{
		_0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003DzDvuIQCU_003D, out var _0023_003DzEWLeis8_003D, out var _0023_003DzWWgGxds_003D, out var _0023_003Dz_eY3Y4c_003D, out var _);
		double num = _0023_003DzEWLeis8_003D - _0023_003DzNDQ_E88_003D;
		double num2 = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		double num3 = num * num;
		double num4 = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
		double x = _0023_003Dzcrymziv8HJnY.X;
		double y = _0023_003Dzcrymziv8HJnY.Y;
		double z = _0023_003Dzcrymziv8HJnY.Z;
		if (_0023_003Dz4KKrSFI74_0024Et)
		{
			Align3D xform = new Align3D(new Plane(Point3D.Origin, Vector3D.AxisX, Vector3D.AxisY), new Plane(Point3D.Origin, _0023_003Dz_eY3Y4c_003D, v));
			((Vector3D)_0023_003Dzcrymziv8HJnY.Clone()).TransformBy(xform);
		}
		double[] b = new double[12]
		{
			x * num3 / num4 * (1.0 + 2.0 * _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D),
			y * num3 / num4 * (1.0 + 2.0 * _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D),
			z * num3 / num4 * (1.0 + 2.0 * _0023_003DzNDQ_E88_003D / _0023_003DzEWLeis8_003D),
			0.0,
			(0.0 - z) * _0023_003DzNDQ_E88_003D * num3 / num4,
			y * _0023_003DzNDQ_E88_003D * num3 / num4,
			x * num2 / num4 * (1.0 + 2.0 * num / _0023_003DzEWLeis8_003D),
			y * num2 / num4 * (1.0 + 2.0 * num / _0023_003DzEWLeis8_003D),
			z * num2 / num4 * (1.0 + 2.0 * num / _0023_003DzEWLeis8_003D),
			0.0,
			z * num2 * num / num4,
			(0.0 - y) * num2 * num / num4
		};
		double[] array = Matrix.Multiply(Matrix.Transpose(_0023_003DzWWgGxds_003D), b);
		if (_alongBeamLoads == null)
		{
			_alongBeamLoads = new double[12];
		}
		_alongBeamLoads[0] = array[0];
		_alongBeamLoads[1] = array[1];
		_alongBeamLoads[2] = array[2];
		_alongBeamLoads[3] = array[3];
		_alongBeamLoads[4] = array[4];
		_alongBeamLoads[5] = array[5];
		_alongBeamLoads[6] = array[6];
		_alongBeamLoads[7] = array[7];
		_alongBeamLoads[8] = array[8];
		_alongBeamLoads[9] = array[9];
		_alongBeamLoads[10] = array[10];
		_alongBeamLoads[11] = array[11];
	}

	public override void CalcTemp(int elemIndex, Point3D[] nodes)
	{
		tLoad = new double[base.TotalDof];
		double sectionArea = ((MaterialBeam)mat).SectionArea;
		double num = nodes[Connection[0]].DistanceTo(nodes[Connection[1]]);
		tLoad[0] = (0.0 - mat.CoeffOfThermalExp) * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[1] = (0.0 - mat.CoeffOfThermalExp) * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[2] = (0.0 - mat.CoeffOfThermalExp) * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].Z - nodes[Connection[0]].Z);
		tLoad[6] = mat.CoeffOfThermalExp * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].X - nodes[Connection[0]].X);
		tLoad[7] = mat.CoeffOfThermalExp * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].Y - nodes[Connection[0]].Y);
		tLoad[8] = mat.CoeffOfThermalExp * Temperature * mat.Young * sectionArea / num * (nodes[Connection[1]].Z - nodes[Connection[0]].Z);
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
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node p = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		Vector3D vector3D = new Vector3D(node, p);
		vector3D.Normalize();
		if (v == null)
		{
			_0023_003DzqkQ1pF0_003D(vector3D);
		}
		Vector3D _0023_003DzZpdQVNE_003D = Vector3D.Cross(vector3D, v);
		double length = new Segment3D(node, p).Length;
		_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzZpdQVNE_003D, node, length, vector3D, null, 0.0, 0.0, 0.0, 0.0, _0023_003DzpXqcGaz7sKJt: false, null, _0023_003DzAI3jPBBmCGmn: true, _0023_003DzXiGznWxb_0eQ: true, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
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
		Vector3D vector3D2 = Vector3D.Cross(vector3D, v);
		vector3D2.Normalize();
		double num2 = segment3D.Length * 0.075;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Red;
		array[num] = segment3D.MidPoint + vector3D * num2;
		array2[num++] = Color.Red;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Green;
		array[num] = segment3D.MidPoint + v * num2;
		array2[num++] = Color.Green;
		array[num] = segment3D.MidPoint;
		array2[num++] = Color.Blue;
		array[num] = segment3D.MidPoint + vector3D2 * num2;
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

	internal void _0023_003DzoWW7VaZ6bbGLCHQ_0024W_abLcU_003D(double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D _0023_003Dz_eY3Y4c_003D, Vector3D _0023_003DzAvn2b38_003D, double _0023_003DzxigXYm0EiNwh, int _0023_003DzKWlpThug3Qun, out Point3D _0023_003DzFj_0024IqDQ_003D, out Point3D _0023_003DzjdeMMkk_003D, out Vector3D _0023_003DzLz7mDrk_003D, out Vector3D _0023_003DzZpdQVNE_003D, out double _0023_003Dz6gJpTukVm_0024VY)
	{
		Node obj = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		double num = _0023_003DzxigXYm0EiNwh * (double)_0023_003DzKWlpThug3Qun;
		double num2 = _0023_003DzxigXYm0EiNwh * (double)(_0023_003DzKWlpThug3Qun + 1);
		Point3D point3D = obj + num * _0023_003Dz_eY3Y4c_003D;
		Point3D point3D2 = obj + num2 * _0023_003Dz_eY3Y4c_003D;
		double[] array = CalcDisplacementsAlongTheBeam(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, num, _0023_003DznXXM9vk_003D);
		double[] array2 = CalcDisplacementsAlongTheBeam(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, num2, _0023_003DznXXM9vk_003D);
		_0023_003DzFj_0024IqDQ_003D = point3D + _0023_003Dz_eY3Y4c_003D * array[0] * _0023_003DzXGmnJb5mDXOU + v * array[1] * _0023_003DzXGmnJb5mDXOU + _0023_003DzAvn2b38_003D * array[2] * _0023_003DzXGmnJb5mDXOU;
		_0023_003DzjdeMMkk_003D = point3D2 + _0023_003Dz_eY3Y4c_003D * array2[0] * _0023_003DzXGmnJb5mDXOU + v * array2[1] * _0023_003DzXGmnJb5mDXOU + _0023_003DzAvn2b38_003D * array2[2] * _0023_003DzXGmnJb5mDXOU;
		_0023_003DzLz7mDrk_003D = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		if (!_0023_003DzLz7mDrk_003D.Normalize())
		{
			_0023_003DzLz7mDrk_003D = _0023_003Dz_eY3Y4c_003D;
		}
		_0023_003DzZpdQVNE_003D = Vector3D.Cross(_0023_003DzLz7mDrk_003D, v);
		_0023_003DzZpdQVNE_003D.Normalize();
		Segment3D segment3D = new Segment3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		_0023_003Dz6gJpTukVm_0024VY = segment3D.Length;
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
