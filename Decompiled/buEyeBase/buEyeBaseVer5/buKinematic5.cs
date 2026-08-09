using System;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buKinematic5
{
	public buKinematic5()
	{
		if (!buVector5.smethod_0("buKinematic5"))
		{
			throw new RegisterException("buKinematic5");
		}
	}

	public void ForwardKinematix4Ax(double ToolLength, KinematicBase5 Kinematic, VectorType AxisVector, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
		kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
		kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
		if ((Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis) | (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis))
		{
			double num = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num2 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num3 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num4 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num5 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num6 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num, 0.0 - num2, 0.0, 0.0, num2, num, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m2 = buMatrix5.CreatMatrix4x4(num3, 0.0, num4, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num4, 0.0, num3, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m3 = buMatrix5.CreatMatrix4x4(num5, 0.0 - num6, 0.0, 0.0, num6, num5, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix6 = null;
			buMatrix5 m4 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m5 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m6 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			if (AxisVector == VectorType.XVector)
			{
				buMatrix5 m7 = buMatrix5.Multiply(m, m4);
				buMatrix5 m8 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m7, m8);
			}
			if (AxisVector == VectorType.YVector)
			{
				buMatrix5 m9 = buMatrix5.Multiply(m2, m5);
				buMatrix5 m10 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m9, m10);
			}
			if (AxisVector == VectorType.ZVector)
			{
				buMatrix5 m11 = buMatrix5.Multiply(m3, m6);
				buMatrix5 m12 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m11, m12);
			}
			CalcPoint.X = buMatrix6[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix6[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix6[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristA_4Axis)
		{
			double num7 = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num8 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num9 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num10 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num11 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num12 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m13 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num7, 0.0 - num8, 0.0, 0.0, num8, num7, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num9, 0.0, num10, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num10, 0.0, num9, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num11, 0.0 - num12, 0.0, 0.0, num12, num11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix7 = null;
			buMatrix5 m14 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m15 = buMatrix5.Multiply(m13, m14);
			buMatrix5 m16 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
			buMatrix7 = buMatrix5.Multiply(m15, m16);
			CalcPoint.X = buMatrix7[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix7[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix7[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
	}

	public void ReverseKinematix4Ax(double ToolLength, KinematicBase5 Kinematic, VectorType AxisVector, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
		kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
		kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
		if ((Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis) | (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis))
		{
			double num = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num2 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num3 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num4 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num5 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num6 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num, 0.0 - num2, 0.0, 0.0, num2, num, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m2 = buMatrix5.CreatMatrix4x4(num3, 0.0, num4, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num4, 0.0, num3, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m3 = buMatrix5.CreatMatrix4x4(num5, 0.0 - num6, 0.0, 0.0, num6, num5, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix6 = null;
			buMatrix5 m4 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m5 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m6 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			if (AxisVector == VectorType.XVector)
			{
				buMatrix5 m7 = buMatrix5.Multiply(m, m4);
				buMatrix5 m8 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m7, m8);
			}
			if (AxisVector == VectorType.YVector)
			{
				buMatrix5 m9 = buMatrix5.Multiply(m2, m5);
				buMatrix5 m10 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m9, m10);
			}
			if (AxisVector == VectorType.ZVector)
			{
				buMatrix5 m11 = buMatrix5.Multiply(m3, m6);
				buMatrix5 m12 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m11, m12);
			}
			CalcPoint.X = MovePoint.X - buMatrix6[0, 0];
			CalcPoint.Y = MovePoint.Y - buMatrix6[1, 0];
			CalcPoint.Z = MovePoint.Z - buMatrix6[2, 0];
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristA_4Axis)
		{
			double num7 = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num8 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num9 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num10 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num11 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num12 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m13 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num7, 0.0 - num8, 0.0, 0.0, num8, num7, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num9, 0.0, num10, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num10, 0.0, num9, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num11, 0.0 - num12, 0.0, 0.0, num12, num11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix7 = null;
			buMatrix5 m14 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m15 = buMatrix5.Multiply(m13, m14);
			buMatrix5 m16 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
			buMatrix7 = buMatrix5.Multiply(m15, m16);
			CalcPoint.X = MovePoint.X - buMatrix7[0, 0];
			CalcPoint.Y = MovePoint.Y - buMatrix7[1, 0];
			CalcPoint.Z = MovePoint.Z - buMatrix7[2, 0];
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
	}

	public void ForwardKinematix5Ax(double ToolLength, KinematicBase5 Kinematic, OrientationAngle Orientation, Point3D MovePoint, bool ApplyOffset, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Point3D point3D = new Point3D();
			KinematicBase5 Kinematic2 = new KinematicBase5(Kinematic);
			if (ApplyOffset)
			{
				FindKinematicOffsets(ref Kinematic2, Orientation);
			}
			KinematicBase5 kinematicBase = new KinematicBase5(Kinematic2);
			kinematicBase.RotateCenterOffsetOfA.Z = Kinematic2.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic2.RotateCenterOffsetOfA.Y - Kinematic2.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num = 0.0;
			CalcPoint.X = CalcPoint.X + num + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z = CalcPoint.Z + MovePoint.Z + kinematicBase.CalcOffsetXYZ.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Point3D point3D2 = new Point3D();
			KinematicBase5 kinematicBase2 = new KinematicBase5(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D2.X, point3D2.Y, point3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num2 = Math.Round(0.5 * Math.Sin(buConversion5.DegreeToRadian(Orientation.C)), 5);
			num2 = 0.0;
			CalcPoint.X = CalcPoint.X + num2 + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
	}

	public void FindKinematicOffsets(ref KinematicBase5 Kinematic, OrientationAngle Orientation)
	{
		double num = Orientation.C;
		if (num < 0.0)
		{
			num += 360.0;
		}
		if (num > 360.0)
		{
			num -= 360.0;
		}
		if (num < -360.0)
		{
			num += 360.0;
		}
		if (!(num >= 0.0 && num <= 90.0))
		{
			if (!(num >= 90.0 && num <= 180.0))
			{
				if (!(num >= 180.0 && num <= 270.0))
				{
					if (num >= 270.0 && num <= 360.0)
					{
						double X = 0.0;
						buNumeric5.EquationLineer(Kinematic.CDistanceAtC270, Kinematic.CDistanceAtC0, 270.0, 360.0, num, ref X);
						Kinematic.RotateCenterOffsetOfC.Y = Kinematic.RotateCenterOffsetOfC.Y + X;
						if (!(Math.Abs(Orientation.A) <= 1.0))
						{
							double X2 = 0.0;
							buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC270, Kinematic.ZDistanceForA45AtC0, 270.0, 360.0, num, ref X2);
							Kinematic.CalcOffsetXYZ.Z = X2;
						}
						else
						{
							double X3 = 0.0;
							buNumeric5.EquationLineer(Kinematic.ZDistanceForA0AtC270, Kinematic.ZDistanceForA0AtC0, 270.0, 360.0, num, ref X3);
							Kinematic.CalcOffsetXYZ.Z = X3;
						}
						if (Math.Abs(Orientation.A) > 0.0)
						{
							double X4 = 0.0;
							buNumeric5.EquationLineer(Kinematic.ADistanceForA45AtC270, Kinematic.ADistanceForA45AtC0, 270.0, 360.0, num, ref X4);
							Kinematic.RotateCenterOffsetOfA.Y = Kinematic.RotateCenterOffsetOfA.Y + X4;
							double X5 = 0.0;
							buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC270, Kinematic.ZDistanceForA45AtC0, 270.0, 360.0, num, ref X5);
							Kinematic.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + X5;
						}
					}
				}
				else
				{
					double X6 = 0.0;
					buNumeric5.EquationLineer(Kinematic.CDistanceAtC180, Kinematic.CDistanceAtC270, 180.0, 270.0, num, ref X6);
					Kinematic.RotateCenterOffsetOfC.Y = Kinematic.RotateCenterOffsetOfC.Y + X6;
					if (!(Math.Abs(Orientation.A) <= 1.0))
					{
						double X7 = 0.0;
						buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC180, Kinematic.ZDistanceForA45AtC270, 180.0, 270.0, num, ref X7);
						Kinematic.CalcOffsetXYZ.Z = X7;
					}
					else
					{
						double X8 = 0.0;
						buNumeric5.EquationLineer(Kinematic.ZDistanceForA0AtC180, Kinematic.ZDistanceForA0AtC270, 180.0, 270.0, num, ref X8);
						Kinematic.CalcOffsetXYZ.Z = X8;
					}
					if (Math.Abs(Orientation.A) > 0.0)
					{
						double X9 = 0.0;
						buNumeric5.EquationLineer(Kinematic.ADistanceForA45AtC180, Kinematic.ADistanceForA45AtC270, 180.0, 270.0, num, ref X9);
						Kinematic.RotateCenterOffsetOfA.Y = Kinematic.RotateCenterOffsetOfA.Y + X9;
						double X10 = 0.0;
						buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC180, Kinematic.ZDistanceForA45AtC270, 180.0, 270.0, num, ref X10);
						Kinematic.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + X10;
					}
				}
			}
			else
			{
				double X11 = 0.0;
				buNumeric5.EquationLineer(Kinematic.CDistanceAtC90, Kinematic.CDistanceAtC180, 90.0, 180.0, num, ref X11);
				Kinematic.RotateCenterOffsetOfC.Y = Kinematic.RotateCenterOffsetOfC.Y + X11;
				if (!(Math.Abs(Orientation.A) <= 1.0))
				{
					double X12 = 0.0;
					buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC90, Kinematic.ZDistanceForA45AtC180, 90.0, 180.0, num, ref X12);
					Kinematic.CalcOffsetXYZ.Z = X12;
				}
				else
				{
					double X13 = 0.0;
					buNumeric5.EquationLineer(Kinematic.ZDistanceForA0AtC90, Kinematic.ZDistanceForA0AtC180, 90.0, 180.0, num, ref X13);
					Kinematic.CalcOffsetXYZ.Z = X13;
				}
				if (Math.Abs(Orientation.A) > 0.0)
				{
					double X14 = 0.0;
					buNumeric5.EquationLineer(Kinematic.ADistanceForA45AtC90, Kinematic.ADistanceForA45AtC180, 90.0, 180.0, num, ref X14);
					Kinematic.RotateCenterOffsetOfA.Y = Kinematic.RotateCenterOffsetOfA.Y + X14;
					double X15 = 0.0;
					buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC90, Kinematic.ZDistanceForA45AtC180, 90.0, 180.0, num, ref X15);
					Kinematic.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + X15;
				}
			}
		}
		else
		{
			double X16 = 0.0;
			buNumeric5.EquationLineer(Kinematic.CDistanceAtC0, Kinematic.CDistanceAtC90, 0.0, 90.0, num, ref X16);
			Kinematic.RotateCenterOffsetOfC.Y = Kinematic.RotateCenterOffsetOfC.Y + X16;
			if (!(Math.Abs(Orientation.A) <= 1.0))
			{
				double X17 = 0.0;
				buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC0, Kinematic.ZDistanceForA45AtC90, 0.0, 90.0, num, ref X17);
				Kinematic.CalcOffsetXYZ.Z = X17;
			}
			else
			{
				double X18 = 0.0;
				buNumeric5.EquationLineer(Kinematic.ZDistanceForA0AtC0, Kinematic.ZDistanceForA0AtC90, 0.0, 90.0, num, ref X18);
				Kinematic.CalcOffsetXYZ.Z = X18;
			}
			if (Math.Abs(Orientation.A) > 0.0)
			{
				double X19 = 0.0;
				buNumeric5.EquationLineer(Kinematic.ADistanceForA45AtC0, Kinematic.ADistanceForA45AtC90, 0.0, 90.0, num, ref X19);
				Kinematic.RotateCenterOffsetOfA.Y = Kinematic.RotateCenterOffsetOfA.Y + X19;
				double X20 = 0.0;
				buNumeric5.EquationLineer(Kinematic.ZDistanceForA45AtC0, Kinematic.ZDistanceForA45AtC90, 0.0, 90.0, num, ref X20);
				Kinematic.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + X20;
			}
		}
	}

	public void ForwardKinematix5Ax(double ToolLength, KinematicBase5 Kinematic, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Point3D point3D = new Point3D();
			KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
			kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num = 0.0;
			CalcPoint.X = CalcPoint.X + num + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Point3D point3D2 = new Point3D();
			KinematicBase5 kinematicBase2 = new KinematicBase5(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D2.X, point3D2.Y, point3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num2 = Math.Round(0.5 * Math.Sin(buConversion5.DegreeToRadian(Orientation.C)), 5);
			num2 = 0.0;
			CalcPoint.X = CalcPoint.X + num2 + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
	}

	public void ForwardKinematix4AxMilling(double ToolLength, KinematicBase5 Kinematic, VectorType AxisVector, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
		kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
		if ((Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis) | (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis))
		{
			double num = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num2 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num3 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num4 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num5 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num6 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num, 0.0 - num2, 0.0, 0.0, num2, num, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m2 = buMatrix5.CreatMatrix4x4(num3, 0.0, num4, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num4, 0.0, num3, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m3 = buMatrix5.CreatMatrix4x4(num5, 0.0 - num6, 0.0, 0.0, num6, num5, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix6 = null;
			buMatrix5 m4 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m5 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m6 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			if (AxisVector == VectorType.XVector)
			{
				buMatrix5 m7 = buMatrix5.Multiply(m, m4);
				buMatrix5 m8 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m7, m8);
			}
			if (AxisVector == VectorType.YVector)
			{
				buMatrix5 m9 = buMatrix5.Multiply(m2, m5);
				buMatrix5 m10 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m9, m10);
			}
			if (AxisVector == VectorType.ZVector)
			{
				buMatrix5 m11 = buMatrix5.Multiply(m3, m6);
				buMatrix5 m12 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
				buMatrix6 = buMatrix5.Multiply(m11, m12);
			}
			CalcPoint.X = buMatrix6[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix6[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix6[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristA_4Axis)
		{
			double num7 = Math.Cos(buConversion5.DegreeToRadian(Orientation.A));
			double num8 = Math.Sin(buConversion5.DegreeToRadian(Orientation.A));
			double num9 = Math.Cos(buConversion5.DegreeToRadian(Orientation.B));
			double num10 = Math.Sin(buConversion5.DegreeToRadian(Orientation.B));
			double num11 = Math.Cos(buConversion5.DegreeToRadian(Orientation.C));
			double num12 = Math.Sin(buConversion5.DegreeToRadian(Orientation.C));
			buMatrix5 m13 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num7, 0.0 - num8, 0.0, 0.0, num8, num7, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num9, 0.0, num10, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0 - num10, 0.0, num9, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(num11, 0.0 - num12, 0.0, 0.0, num12, num11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 buMatrix7 = null;
			buMatrix5 m14 = buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
			buMatrix5 m15 = buMatrix5.Multiply(m13, m14);
			buMatrix5 m16 = buMatrix5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0);
			buMatrix7 = buMatrix5.Multiply(m15, m16);
			CalcPoint.X = buMatrix7[0, 0] + MovePoint.X;
			CalcPoint.Y = buMatrix7[1, 0] + MovePoint.Y;
			CalcPoint.Z = buMatrix7[2, 0] + MovePoint.Z;
			CalcPoint.A = Orientation.A;
			CalcPoint.B = Orientation.B;
			CalcPoint.C = Orientation.C;
		}
	}

	public void ForwardKinematix5AxMilling(double ToolLength, double PivotOffseet, IJK ijk, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		double num = ToolLength + PivotOffseet;
		double x = MovePoint.X + num * ijk.I;
		double y = MovePoint.Y + num * ijk.J;
		double z = MovePoint.Z + num * ijk.K - num;
		CalcPoint = new Pnt6D(x, y, z, Orientation.A, Orientation.B, Orientation.C);
	}

	public void ReverseKinematix5AxMilling(double ToolLength, double PivotOffseet, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		double num = Orientation.A * Math.PI / 180.0;
		double num2 = Orientation.B * Math.PI / 180.0;
		double num3 = Orientation.C * Math.PI / 180.0;
		_ = Math.Cos(num3) * Math.Sin(num2) * Math.Cos(num) + Math.Sin(num3) * Math.Sin(num);
		_ = Math.Sin(num3) * Math.Sin(num2) * Math.Cos(num) - Math.Cos(num3) * Math.Sin(num);
		_ = Math.Cos(num2) * Math.Cos(num);
	}

	public void ForwardKinematix5AxMilling(double ToolLength, KinematicBase5 Kinematic, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Point3D point3D = new Point3D();
			KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4AxMilling(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4AxMilling(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num = 0.0;
			CalcPoint.X = CalcPoint.X + num + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Point3D point3D2 = new Point3D();
			KinematicBase5 kinematicBase2 = new KinematicBase5(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D2.X, point3D2.Y, point3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			double num2 = Math.Round(0.5 * Math.Sin(buConversion5.DegreeToRadian(Orientation.C)), 5);
			num2 = 0.0;
			CalcPoint.X = CalcPoint.X + num2 + MovePoint.X;
			CalcPoint.Y += MovePoint.Y;
			CalcPoint.Z += MovePoint.Z;
		}
	}

	public void ReverseKinematix5Ax(double ToolLength, KinematicBase5 Kinematic, OrientationAngle Orientation, Point3D MovePoint, ref Pnt6D CalcPoint)
	{
		if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			Point3D point3D = new Point3D();
			KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
			kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			CalcPoint.X = MovePoint.X - CalcPoint.X;
			CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
			CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
		}
		if (Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
		{
			Point3D point3D2 = new Point3D();
			KinematicBase5 kinematicBase2 = new KinematicBase5(Kinematic);
			kinematicBase2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
			kinematicBase2.RotateCenterOffsetOfC.Z = 0.0;
			ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D2.X, point3D2.Y, point3D2.Z), ref CalcPoint);
			CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
			kinematicBase2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
			ForwardKinematix4Ax(ToolLength, kinematicBase2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
			CalcPoint.X = MovePoint.X - CalcPoint.X;
			CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
			CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
		}
	}
}
