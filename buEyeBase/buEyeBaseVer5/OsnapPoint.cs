// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.OsnapPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

public class OsnapPoint : Point3D
{
  public double ADistanceForA45AtC0;
  public double ADistanceForA45AtC90;
  public double ADistanceForA45AtC180;
  public double ADistanceForA45AtC270;
  public double CDistanceAtC0;

  public abstract void m00024A();

  public OsnapPoint()
  {
    ((OsnapCoordinateCatch) this).OffsetXYZ = new Point3D();
    ((OsnapCoordinateCatch) this).OffsetABC = new OrientationAngle();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA = new Point3D();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB = new Point3D();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC = new Point3D();
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset = new Point3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC = new Length3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB = new Length3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC = new Length3D();
    ((OsnapCoordinateCatch) this).CalcOffsetXYZ = new Point3D();
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC0 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC90 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC180 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC270 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC0 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC90 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC180 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC270 = 0.0;
    this.ADistanceForA45AtC0 = 0.0;
    this.ADistanceForA45AtC90 = 0.0;
    this.ADistanceForA45AtC180 = 0.0;
    this.ADistanceForA45AtC270 = 0.0;
    this.CDistanceAtC0 = 0.0;
    ((PointWithIndex) this).CDistanceAtC90 = 0.0;
    ((PointWithIndex) this).CDistanceAtC180 = 0.0;
    ((MeshToSurfacePointsSettings) this).CDistanceAtC270 = 0.0;
    ((MeshToSurfacePointsSettings) this).Type = KinemeticType.CartezianXYZ_3Axis;
    ((MeshToSurfacePointsSettings) this).Name = "Kinematic";
    ((MeshToSurfacePointsSettings) this).FileName = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public OsnapPoint(KinematicBase5 data)
  {
    ((OsnapCoordinateCatch) this).OffsetXYZ = new Point3D();
    ((OsnapCoordinateCatch) this).OffsetABC = new OrientationAngle();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA = new Point3D();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB = new Point3D();
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC = new Point3D();
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset = new Point3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC = new Length3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB = new Length3D();
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC = new Length3D();
    ((OsnapCoordinateCatch) this).CalcOffsetXYZ = new Point3D();
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC0 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC90 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC180 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC270 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC0 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC90 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC180 = 0.0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC270 = 0.0;
    this.ADistanceForA45AtC0 = 0.0;
    this.ADistanceForA45AtC90 = 0.0;
    this.ADistanceForA45AtC180 = 0.0;
    this.ADistanceForA45AtC270 = 0.0;
    this.CDistanceAtC0 = 0.0;
    ((PointWithIndex) this).CDistanceAtC90 = 0.0;
    ((PointWithIndex) this).CDistanceAtC180 = 0.0;
    ((MeshToSurfacePointsSettings) this).CDistanceAtC270 = 0.0;
    ((MeshToSurfacePointsSettings) this).Type = KinemeticType.CartezianXYZ_3Axis;
    ((MeshToSurfacePointsSettings) this).Name = "Kinematic";
    ((MeshToSurfacePointsSettings) this).FileName = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((OsnapCoordinateCatch) this).OffsetXYZ.X = ((OsnapCoordinateCatch) data).OffsetXYZ.X;
    ((OsnapCoordinateCatch) this).OffsetXYZ.Y = ((OsnapCoordinateCatch) data).OffsetXYZ.Y;
    ((OsnapCoordinateCatch) this).OffsetXYZ.Z = ((OsnapCoordinateCatch) data).OffsetXYZ.Z;
    ((OsnapCoordinateCatch) this).OffsetABC.A = ((OsnapCoordinateCatch) data).OffsetABC.A;
    ((OsnapCoordinateCatch) this).OffsetABC.B = ((OsnapCoordinateCatch) data).OffsetABC.B;
    ((OsnapCoordinateCatch) this).OffsetABC.C = ((OsnapCoordinateCatch) data).OffsetABC.C;
    ((OsnapCoordinateCatch) this).CalcOffsetXYZ.X = ((OsnapCoordinateCatch) data).CalcOffsetXYZ.X;
    ((OsnapCoordinateCatch) this).CalcOffsetXYZ.Y = ((OsnapCoordinateCatch) data).CalcOffsetXYZ.Y;
    ((OsnapCoordinateCatch) this).CalcOffsetXYZ.Z = ((OsnapCoordinateCatch) data).CalcOffsetXYZ.Z;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.X = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfA.X;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfA.Y;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfA.Z;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.X = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfB.X;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Y = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfB.Y;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Z = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfB.Z;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.X = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfC.X;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfC.Y;
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Z = ((OsnapCoordinateCatch) data).RotateCenterOffsetOfC.Z;
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.X = ((OsnapCoordinateCatch) data).MovePartRuntimeOffset.X;
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Y = ((OsnapCoordinateCatch) data).MovePartRuntimeOffset.Y;
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Z = ((OsnapCoordinateCatch) data).MovePartRuntimeOffset.Z;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dX = ((OsnapCoordinateCatch) data).DistanceCenterOfAC.dX;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dY = ((OsnapCoordinateCatch) data).DistanceCenterOfAC.dY;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dZ = ((OsnapCoordinateCatch) data).DistanceCenterOfAC.dZ;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dX = ((OsnapCoordinateCatch) data).DistanceCenterOfAB.dX;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dY = ((OsnapCoordinateCatch) data).DistanceCenterOfAB.dY;
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dZ = ((OsnapCoordinateCatch) data).DistanceCenterOfAB.dZ;
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dX = ((OsnapCoordinateCatch) data).DistanceCenterOfBC.dX;
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dY = ((OsnapCoordinateCatch) data).DistanceCenterOfBC.dY;
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dZ = ((OsnapCoordinateCatch) data).DistanceCenterOfBC.dZ;
    this.ADistanceForA45AtC0 = ((OsnapPoint) data).ADistanceForA45AtC0;
    this.ADistanceForA45AtC90 = ((OsnapPoint) data).ADistanceForA45AtC90;
    this.ADistanceForA45AtC180 = ((OsnapPoint) data).ADistanceForA45AtC180;
    this.ADistanceForA45AtC270 = ((OsnapPoint) data).ADistanceForA45AtC270;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC0 = ((OsnapCoordinateCatch) data).ZDistanceForA45AtC0;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC90 = ((OsnapCoordinateCatch) data).ZDistanceForA45AtC90;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC180 = ((OsnapCoordinateCatch) data).ZDistanceForA45AtC180;
    ((OsnapCoordinateCatch) this).ZDistanceForA45AtC270 = ((OsnapCoordinateCatch) data).ZDistanceForA45AtC270;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC0 = ((OsnapCoordinateCatch) data).ZDistanceForA0AtC0;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC90 = ((OsnapCoordinateCatch) data).ZDistanceForA0AtC90;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC180 = ((OsnapCoordinateCatch) data).ZDistanceForA0AtC180;
    ((OsnapCoordinateCatch) this).ZDistanceForA0AtC270 = ((OsnapCoordinateCatch) data).ZDistanceForA0AtC270;
    this.CDistanceAtC0 = ((OsnapPoint) data).CDistanceAtC0;
    ((PointWithIndex) this).CDistanceAtC90 = ((PointWithIndex) data).CDistanceAtC90;
    ((PointWithIndex) this).CDistanceAtC180 = ((PointWithIndex) data).CDistanceAtC180;
    ((MeshToSurfacePointsSettings) this).CDistanceAtC270 = ((MeshToSurfacePointsSettings) data).CDistanceAtC270;
    ((MeshToSurfacePointsSettings) this).Type = ((MeshToSurfacePointsSettings) data).Type;
    ((MeshToSurfacePointsSettings) this).Name = ((MeshToSurfacePointsSettings) data).Name;
    ((MeshToSurfacePointsSettings) this).FileName = ((MeshToSurfacePointsSettings) data).FileName;
  }

  public void MmToInch()
  {
    ((OsnapCoordinateCatch) this).OffsetXYZ.X = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.X * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).OffsetXYZ.Y = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.Y * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).OffsetXYZ.Z = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.Z * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.X * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Y * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Z * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.X * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Y * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Z * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.X * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Y * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Z * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.X = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.X * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Y = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Y * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Z = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Z * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dX * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dY * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dZ * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dX * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dY * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dZ * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dX * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dY * buSystem.MmToInchRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dZ * buSystem.MmToInchRatio, 5);
  }
}
