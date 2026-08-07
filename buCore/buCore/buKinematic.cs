// Decompiled with JetBrains decompiler
// Type: buCore.buKinematic
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;

#nullable disable
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
    if (!buVector.smethod_0(nameof (buKinematic)))
      throw new RegisterException(nameof (buKinematic));
  }

  public void ForwardKinematix4Ax(
    double ToolLength,
    KinematicBase Kinematic,
    VectorType AxisVector,
    OrientationAngle Orientation,
    Pnt3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    KinematicBase kinematicBase = new KinematicBase(Kinematic);
    kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
    kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
    if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis | Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
    {
      double num1 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
      double m32 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
      double num2 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
      double m13 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
      double num3 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
      double m21 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
      buMatrix m1_1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num1, -m32, 0.0, 0.0, m32, num1, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix m1_2 = buMatrix.CreatMatrix4x4(num2, 0.0, m13, 0.0, 0.0, 1.0, 0.0, 0.0, -m13, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix m1_3 = buMatrix.CreatMatrix4x4(num3, -m21, 0.0, 0.0, m21, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix buMatrix = (buMatrix) null;
      buMatrix m2_1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix m2_2 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix m2_3 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
      if (AxisVector == VectorType.XVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_1, m2_1), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.YVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_2, m2_2), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.ZVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_3, m2_3), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      CalcPoint.X = buMatrix[0, 0] + MovePoint.X;
      CalcPoint.Y = buMatrix[1, 0] + MovePoint.Y;
      CalcPoint.Z = buMatrix[2, 0] + MovePoint.Z;
      CalcPoint.A = Orientation.A;
      CalcPoint.B = Orientation.B;
      CalcPoint.C = Orientation.C;
    }
    if (Kinematic.Type != KinemeticType.CartezianXYZ_WristA_4Axis)
      return;
    double num4 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
    double m32_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
    double num5 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
    double m13_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
    double num6 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
    double m21_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
    buMatrix m1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num4, -m32_1, 0.0, 0.0, m32_1, num4, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(num5, 0.0, m13_1, 0.0, 0.0, 1.0, 0.0, 0.0, -m13_1, 0.0, num5, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(num6, -m21_1, 0.0, 0.0, m21_1, num6, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix m2 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix buMatrix1 = buMatrix.Multiply(buMatrix.Multiply(m1, m2), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
    CalcPoint.X = buMatrix1[0, 0] + MovePoint.X;
    CalcPoint.Y = buMatrix1[1, 0] + MovePoint.Y;
    CalcPoint.Z = buMatrix1[2, 0] + MovePoint.Z;
    CalcPoint.A = Orientation.A;
    CalcPoint.B = Orientation.B;
    CalcPoint.C = Orientation.C;
  }

  public void ReverseKinematix4Ax(
    double ToolLength,
    KinematicBase Kinematic,
    VectorType AxisVector,
    OrientationAngle Orientation,
    Pnt3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    KinematicBase kinematicBase = new KinematicBase(Kinematic);
    kinematicBase.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
    kinematicBase.RotateCenterOffsetOfC.Z = 0.0;
    if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis | Kinematic.Type == KinemeticType.CartezianXYZ_TableC_4Axis)
    {
      double num1 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
      double m32 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
      double num2 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
      double m13 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
      double num3 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
      double m21 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
      buMatrix m1_1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num1, -m32, 0.0, 0.0, m32, num1, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix m1_2 = buMatrix.CreatMatrix4x4(num2, 0.0, m13, 0.0, 0.0, 1.0, 0.0, 0.0, -m13, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix m1_3 = buMatrix.CreatMatrix4x4(num3, -m21, 0.0, 0.0, m21, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix buMatrix = (buMatrix) null;
      buMatrix m2_1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix m2_2 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix m2_3 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
      if (AxisVector == VectorType.XVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_1, m2_1), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.YVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_2, m2_2), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.ZVector)
        buMatrix = buMatrix.Multiply(buMatrix.Multiply(m1_3, m2_3), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      CalcPoint.X = MovePoint.X - buMatrix[0, 0];
      CalcPoint.Y = MovePoint.Y - buMatrix[1, 0];
      CalcPoint.Z = MovePoint.Z - buMatrix[2, 0];
      CalcPoint.A = Orientation.A;
      CalcPoint.B = Orientation.B;
      CalcPoint.C = Orientation.C;
    }
    if (Kinematic.Type != KinemeticType.CartezianXYZ_WristA_4Axis)
      return;
    double num4 = Math.Cos(buConversion.DegreeToRadian(Orientation.A));
    double m32_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.A));
    double num5 = Math.Cos(buConversion.DegreeToRadian(Orientation.B));
    double m13_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.B));
    double num6 = Math.Cos(buConversion.DegreeToRadian(Orientation.C));
    double m21_1 = Math.Sin(buConversion.DegreeToRadian(Orientation.C));
    buMatrix m1 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num4, -m32_1, 0.0, 0.0, m32_1, num4, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(num5, 0.0, m13_1, 0.0, 0.0, 1.0, 0.0, 0.0, -m13_1, 0.0, num5, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(num6, -m21_1, 0.0, 0.0, m21_1, num6, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix m2 = buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix.CreatMatrix4x4(1.0, 0.0, 0.0, kinematicBase.RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, kinematicBase.RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, kinematicBase.RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix buMatrix1 = buMatrix.Multiply(buMatrix.Multiply(m1, m2), buMatrix.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
    CalcPoint.X = MovePoint.X - buMatrix1[0, 0];
    CalcPoint.Y = MovePoint.Y - buMatrix1[1, 0];
    CalcPoint.Z = MovePoint.Z - buMatrix1[2, 0];
    CalcPoint.A = Orientation.A;
    CalcPoint.B = Orientation.B;
    CalcPoint.C = Orientation.C;
  }

  public void ForwardKinematix5Ax(
    double ToolLength,
    KinematicBase Kinematic,
    OrientationAngle Orientation,
    Pnt3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Pnt3D pnt3D = new Pnt3D();
      KinematicBase Kinematic1 = new KinematicBase(Kinematic);
      Kinematic1.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
      Kinematic1.RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z), ref CalcPoint);
      CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
      Kinematic1.RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4Ax(ToolLength, Kinematic1, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      Math.Round(0.5 * Math.Sin(buConversion.DegreeToRadian(Orientation.C)), 5);
      double num = 0.0;
      CalcPoint.X = CalcPoint.X + num + MovePoint.X;
      CalcPoint.Y += MovePoint.Y;
      CalcPoint.Z += MovePoint.Z;
    }
    if (Kinematic.Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Pnt3D pnt3D1 = new Pnt3D();
    KinematicBase Kinematic2 = new KinematicBase(Kinematic);
    Kinematic2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
    Kinematic2.RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D1.X, pnt3D1.Y, pnt3D1.Z), ref CalcPoint);
    CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
    Kinematic2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    Math.Round(0.5 * Math.Sin(buConversion.DegreeToRadian(Orientation.C)), 5);
    double num1 = 0.0;
    CalcPoint.X = CalcPoint.X + num1 + MovePoint.X;
    CalcPoint.Y += MovePoint.Y;
    CalcPoint.Z += MovePoint.Z;
  }

  public void ReverseKinematix5Ax(
    double ToolLength,
    KinematicBase Kinematic,
    OrientationAngle Orientation,
    Pnt3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    if (Kinematic.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Pnt3D pnt3D = new Pnt3D();
      KinematicBase Kinematic1 = new KinematicBase(Kinematic);
      Kinematic1.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
      Kinematic1.RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z), ref CalcPoint);
      CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
      Kinematic1.RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4Ax(ToolLength, Kinematic1, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      CalcPoint.X = MovePoint.X - CalcPoint.X;
      CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
      CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
    }
    if (Kinematic.Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Pnt3D pnt3D1 = new Pnt3D();
    KinematicBase Kinematic2 = new KinematicBase(Kinematic);
    Kinematic2.RotateCenterOffsetOfA.Z = Kinematic.RotateCenterOffsetOfA.Z + ToolLength;
    Kinematic2.RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt3D1.X, pnt3D1.Y, pnt3D1.Z), ref CalcPoint);
    CalcPoint.Y -= Kinematic.RotateCenterOffsetOfA.Y - Kinematic.RotateCenterOffsetOfC.Y;
    Kinematic2.RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Pnt3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    CalcPoint.X = MovePoint.X - CalcPoint.X;
    CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
    CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
  }
}
