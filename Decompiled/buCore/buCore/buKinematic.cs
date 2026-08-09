using System;
using buClass;

namespace buCore;

public class buKinematic
{
	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	private static string string_2 = "";

	private static string string_3 = "";

	private static double double_0 = 0.0;

	private static double double_1 = 0.0;

	public buKinematic()
	{
		if (!buVector.smethod_0("buKinematic"))
		{
			throw new RegisterException("buKinematic");
		}
	}

	public void ForwardKinematix4Ax(double ToolLength, KinematicBase Kinematic, VectorType AxisVector, OrientationAngle Orientation, Pnt3D MovePoint, ref Pnt6D CalcPoint)
	{
		KinematicBase kinematicBase = new KinematicBase(Kinematic);
		kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
		kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
		if ((Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis) | (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis))
		{
			double num = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
			double num2 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
			double num3 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
			double num4 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
			double num5 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
			double num6 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
			buMatrix m = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num, 0.0 - num2, 0.0, 0.0, num2, num, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix m2 = buMatrix.CreatMatrix4x4(num3, 0.0, num4, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num4, 0.0, num3, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix m3 = buMatrix.CreatMatrix4x4(num5, 0.0 - num6, 0.0, 0.0, num6, num5, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix buMatrix2 = null;
			buMatrix m4 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m5 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m6 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			if (AxisVector == VectorType.XVector)
			{
				buMatrix m7 = buMatrix.Multiply(m, m4);
				buMatrix m8 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m7, m8);
			}
			if (AxisVector == VectorType.YVector)
			{
				buMatrix m9 = buMatrix.Multiply(m2, m5);
				buMatrix m10 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m9, m10);
			}
			if (AxisVector == VectorType.ZVector)
			{
				buMatrix m11 = buMatrix.Multiply(m3, m6);
				buMatrix m12 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m11, m12);
			}
			CalcPoint.X = buMatrix2[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix2[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix2[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristA_4Axis)
		{
			double num7 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
			double num8 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
			double num9 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
			double num10 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
			double num11 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
			double num12 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
			buMatrix m13 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num7, 0.0 - num8, 0.0, 0.0, num8, num7, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(num9, 0.0, num10, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num10, 0.0, num9, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(num11, 0.0 - num12, 0.0, 0.0, num12, num11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix buMatrix3 = null;
			buMatrix m14 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m15 = buMatrix.Multiply(m13, m14);
			buMatrix m16 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
			buMatrix3 = buMatrix.Multiply(m15, m16);
			CalcPoint.X = buMatrix3[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix3[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix3[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
	}

	public void ReverseKinematix4Ax(double ToolLength, KinematicBase Kinematic, VectorType AxisVector, OrientationAngle Orientation, Pnt3D MovePoint, ref Pnt6D CalcPoint)
	{
		KinematicBase kinematicBase = new KinematicBase(Kinematic);
		kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
		kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
		if ((Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis) | (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis))
		{
			double num = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
			double num2 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
			double num3 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
			double num4 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
			double num5 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
			double num6 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
			buMatrix m = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num, 0.0 - num2, 0.0, 0.0, num2, num, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix m2 = buMatrix.CreatMatrix4x4(num3, 0.0, num4, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num4, 0.0, num3, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix m3 = buMatrix.CreatMatrix4x4(num5, 0.0 - num6, 0.0, 0.0, num6, num5, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix buMatrix2 = null;
			buMatrix m4 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m5 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m6 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			if (AxisVector == VectorType.XVector)
			{
				buMatrix m7 = buMatrix.Multiply(m, m4);
				buMatrix m8 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m7, m8);
			}
			if (AxisVector == VectorType.YVector)
			{
				buMatrix m9 = buMatrix.Multiply(m2, m5);
				buMatrix m10 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m9, m10);
			}
			if (AxisVector == VectorType.ZVector)
			{
				buMatrix m11 = buMatrix.Multiply(m3, m6);
				buMatrix m12 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix2 = buMatrix.Multiply(m11, m12);
			}
			CalcPoint.X = MovePoint.X - buMatrix2[0, 0];
			CalcPoint.Y = MovePoint.Y - buMatrix2[1, 0];
			CalcPoint.Z = MovePoint.Z - buMatrix2[2, 0];
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristA_4Axis)
		{
			double num7 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
			double num8 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
			double num9 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
			double num10 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
			double num11 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
			double num12 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
			buMatrix m13 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num7, 0.0 - num8, 0.0, 0.0, num8, num7, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(num9, 0.0, num10, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num10, 0.0, num9, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(num11, 0.0 - num12, 0.0, 0.0, num12, num11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix buMatrix3 = null;
			buMatrix m14 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix m15 = buMatrix.Multiply(m13, m14);
			buMatrix m16 = buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
			buMatrix3 = buMatrix.Multiply(m15, m16);
			CalcPoint.X = MovePoint.X - buMatrix3[0, 0];
			CalcPoint.Y = MovePoint.Y - buMatrix3[1, 0];
			CalcPoint.Z = MovePoint.Z - buMatrix3[2, 0];
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
	}

	public void ForwardKinematix5Ax(double ToolLength, KinematicBase Kinematic, OrientationAngle Orientation, Pnt3D MovePoint, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Pnt3D pnt3D = new Pnt3D();
			KinematicBase kinematicBase = new KinematicBase(Kinematic);
			kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num = Math.Round(0.5 * Math.Sin(buConversion.DegreeToRadian(Orientation.C)), 5);
			num = 0.0;
			CalcPoint.X = CalcPoint.X + num + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Pnt3D pnt3D2 = new Pnt3D();
			KinematicBase kinematicBase2 = new KinematicBase(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num2 = Math.Round(0.5 * Math.Sin(buConversion.DegreeToRadian(Orientation.C)), 5);
			num2 = 0.0;
			CalcPoint.X = CalcPoint.X + num2 + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
	}

	public void ReverseKinematix5Ax(double ToolLength, KinematicBase Kinematic, OrientationAngle Orientation, Pnt3D MovePoint, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Pnt3D pnt3D = new Pnt3D();
			KinematicBase kinematicBase = new KinematicBase(Kinematic);
			kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			CalcPoint.X = MovePoint.X - CalcPoint.X;
			CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
			CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Pnt3D pnt3D2 = new Pnt3D();
			KinematicBase kinematicBase2 = new KinematicBase(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			CalcPoint.X = MovePoint.X - CalcPoint.X;
			CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
			CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
		}
	}
}
