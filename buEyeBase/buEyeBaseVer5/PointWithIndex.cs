// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PointWithIndex
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class PointWithIndex : buSerilization5
{
  public double CDistanceAtC90;
  public double CDistanceAtC180;

  public void InchToInch()
  {
    ((OsnapCoordinateCatch) this).OffsetXYZ.X = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.X * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).OffsetXYZ.Y = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.Y * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).OffsetXYZ.Z = Math.Round(((OsnapCoordinateCatch) this).OffsetXYZ.Z * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.X * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Y * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfA.Z * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.X * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Y * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfB.Z * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.X = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.X * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Y = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Y * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Z = Math.Round(((OsnapCoordinateCatch) this).RotateCenterOffsetOfC.Z * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.X = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.X * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Y = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Y * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Z = Math.Round(((OsnapCoordinateCatch) this).MovePartRuntimeOffset.Z * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dX * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dY * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAC.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAC.dZ * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dX * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dY * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfAB.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfAB.dZ * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dX = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dX * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dY = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dY * buSystem.InchToMmRatio, 5);
    ((OsnapCoordinateCatch) this).DistanceCenterOfBC.dZ = Math.Round(((OsnapCoordinateCatch) this).DistanceCenterOfBC.dZ * buSystem.InchToMmRatio, 5);
  }

  public static void Copy(KinematicBase5 baseKinematic, ref KinematicBase copyKinematic)
  {
    copyKinematic = new KinematicBase();
    copyKinematic.RotateCenterOffsetOfA = new Pnt3D(((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfA.X, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfA.Y, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfA.Z);
    copyKinematic.RotateCenterOffsetOfB = new Pnt3D(((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfB.X, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfB.Y, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfB.Z);
    copyKinematic.RotateCenterOffsetOfC = new Pnt3D(((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfC.X, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfC.Y, ((OsnapCoordinateCatch) baseKinematic).RotateCenterOffsetOfC.Z);
    copyKinematic.OffsetXYZ = new Pnt3D(((OsnapCoordinateCatch) baseKinematic).OffsetXYZ.X, ((OsnapCoordinateCatch) baseKinematic).OffsetXYZ.Y, ((OsnapCoordinateCatch) baseKinematic).OffsetXYZ.Z);
    copyKinematic.OffsetABC = new OrientationAngle(((OsnapCoordinateCatch) baseKinematic).OffsetABC.A, ((OsnapCoordinateCatch) baseKinematic).OffsetABC.B, ((OsnapCoordinateCatch) baseKinematic).OffsetABC.C);
    copyKinematic.Type = ((MeshToSurfacePointsSettings) baseKinematic).Type;
    copyKinematic.Name = ((MeshToSurfacePointsSettings) baseKinematic).Name;
    copyKinematic.FileName = ((MeshToSurfacePointsSettings) baseKinematic).FileName;
  }

  public override string ToString()
  {
    return "Type: " + ((MeshToSurfacePointsSettings) this).Type.ToString();
  }
}
