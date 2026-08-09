using System;
using System.Collections.Generic;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class KinematicBase5 : buSerilization5
{
	public Point3D OffsetXYZ = new Point3D();

	public OrientationAngle OffsetABC = new OrientationAngle();

	public Point3D RotateCenterOffsetOfA = new Point3D();

	public Point3D RotateCenterOffsetOfB = new Point3D();

	public Point3D RotateCenterOffsetOfC = new Point3D();

	public Point3D MovePartRuntimeOffset = new Point3D();

	public Length3D DistanceCenterOfAC = new Length3D();

	public Length3D DistanceCenterOfAB = new Length3D();

	public Length3D DistanceCenterOfBC = new Length3D();

	public Point3D CalcOffsetXYZ = new Point3D();

	public double ZDistanceForA0AtC0 = 0.0;

	public double ZDistanceForA0AtC90 = 0.0;

	public double ZDistanceForA0AtC180 = 0.0;

	public double ZDistanceForA0AtC270 = 0.0;

	public double ZDistanceForA45AtC0 = 0.0;

	public double ZDistanceForA45AtC90 = 0.0;

	public double ZDistanceForA45AtC180 = 0.0;

	public double ZDistanceForA45AtC270 = 0.0;

	public double ADistanceForA45AtC0 = 0.0;

	public double ADistanceForA45AtC90 = 0.0;

	public double ADistanceForA45AtC180 = 0.0;

	public double ADistanceForA45AtC270 = 0.0;

	public double CDistanceAtC0 = 0.0;

	public double CDistanceAtC90 = 0.0;

	public double CDistanceAtC180 = 0.0;

	public double CDistanceAtC270 = 0.0;

	public KinemeticType Type = KinemeticType.CartezianXYZ_3Axis;

	public string Name = "Kinematic";

	public string FileName = "";

	public static List<string> Captions = new List<string>();

	public KinematicBase5()
	{
	}

	public KinematicBase5(KinematicBase5 data)
	{
		OffsetXYZ.X = data.OffsetXYZ.X;
		OffsetXYZ.Y = data.OffsetXYZ.Y;
		OffsetXYZ.Z = data.OffsetXYZ.Z;
		OffsetABC.A = data.OffsetABC.A;
		OffsetABC.B = data.OffsetABC.B;
		OffsetABC.C = data.OffsetABC.C;
		CalcOffsetXYZ.X = data.CalcOffsetXYZ.X;
		CalcOffsetXYZ.Y = data.CalcOffsetXYZ.Y;
		CalcOffsetXYZ.Z = data.CalcOffsetXYZ.Z;
		RotateCenterOffsetOfA.X = data.RotateCenterOffsetOfA.X;
		RotateCenterOffsetOfA.Y = data.RotateCenterOffsetOfA.Y;
		RotateCenterOffsetOfA.Z = data.RotateCenterOffsetOfA.Z;
		RotateCenterOffsetOfB.X = data.RotateCenterOffsetOfB.X;
		RotateCenterOffsetOfB.Y = data.RotateCenterOffsetOfB.Y;
		RotateCenterOffsetOfB.Z = data.RotateCenterOffsetOfB.Z;
		RotateCenterOffsetOfC.X = data.RotateCenterOffsetOfC.X;
		RotateCenterOffsetOfC.Y = data.RotateCenterOffsetOfC.Y;
		RotateCenterOffsetOfC.Z = data.RotateCenterOffsetOfC.Z;
		MovePartRuntimeOffset.X = data.MovePartRuntimeOffset.X;
		MovePartRuntimeOffset.Y = data.MovePartRuntimeOffset.Y;
		MovePartRuntimeOffset.Z = data.MovePartRuntimeOffset.Z;
		DistanceCenterOfAC.dX = data.DistanceCenterOfAC.dX;
		DistanceCenterOfAC.dY = data.DistanceCenterOfAC.dY;
		DistanceCenterOfAC.dZ = data.DistanceCenterOfAC.dZ;
		DistanceCenterOfAB.dX = data.DistanceCenterOfAB.dX;
		DistanceCenterOfAB.dY = data.DistanceCenterOfAB.dY;
		DistanceCenterOfAB.dZ = data.DistanceCenterOfAB.dZ;
		DistanceCenterOfBC.dX = data.DistanceCenterOfBC.dX;
		DistanceCenterOfBC.dY = data.DistanceCenterOfBC.dY;
		DistanceCenterOfBC.dZ = data.DistanceCenterOfBC.dZ;
		ADistanceForA45AtC0 = data.ADistanceForA45AtC0;
		ADistanceForA45AtC90 = data.ADistanceForA45AtC90;
		ADistanceForA45AtC180 = data.ADistanceForA45AtC180;
		ADistanceForA45AtC270 = data.ADistanceForA45AtC270;
		ZDistanceForA45AtC0 = data.ZDistanceForA45AtC0;
		ZDistanceForA45AtC90 = data.ZDistanceForA45AtC90;
		ZDistanceForA45AtC180 = data.ZDistanceForA45AtC180;
		ZDistanceForA45AtC270 = data.ZDistanceForA45AtC270;
		ZDistanceForA0AtC0 = data.ZDistanceForA0AtC0;
		ZDistanceForA0AtC90 = data.ZDistanceForA0AtC90;
		ZDistanceForA0AtC180 = data.ZDistanceForA0AtC180;
		ZDistanceForA0AtC270 = data.ZDistanceForA0AtC270;
		CDistanceAtC0 = data.CDistanceAtC0;
		CDistanceAtC90 = data.CDistanceAtC90;
		CDistanceAtC180 = data.CDistanceAtC180;
		CDistanceAtC270 = data.CDistanceAtC270;
		Type = data.Type;
		Name = data.Name;
		FileName = data.FileName;
	}

	public void MmToInch()
	{
		OffsetXYZ.X = Math.Round(OffsetXYZ.X * buSystem.MmToInchRatio, 5);
		OffsetXYZ.Y = Math.Round(OffsetXYZ.Y * buSystem.MmToInchRatio, 5);
		OffsetXYZ.Z = Math.Round(OffsetXYZ.Z * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfA.X = Math.Round(RotateCenterOffsetOfA.X * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfA.Y = Math.Round(RotateCenterOffsetOfA.Y * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfA.Z = Math.Round(RotateCenterOffsetOfA.Z * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfB.X = Math.Round(RotateCenterOffsetOfB.X * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfB.Y = Math.Round(RotateCenterOffsetOfB.Y * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfB.Z = Math.Round(RotateCenterOffsetOfB.Z * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfC.X = Math.Round(RotateCenterOffsetOfC.X * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfC.Y = Math.Round(RotateCenterOffsetOfC.Y * buSystem.MmToInchRatio, 5);
		RotateCenterOffsetOfC.Z = Math.Round(RotateCenterOffsetOfC.Z * buSystem.MmToInchRatio, 5);
		MovePartRuntimeOffset.X = Math.Round(MovePartRuntimeOffset.X * buSystem.MmToInchRatio, 5);
		MovePartRuntimeOffset.Y = Math.Round(MovePartRuntimeOffset.Y * buSystem.MmToInchRatio, 5);
		MovePartRuntimeOffset.Z = Math.Round(MovePartRuntimeOffset.Z * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAC.dX = Math.Round(DistanceCenterOfAC.dX * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAC.dY = Math.Round(DistanceCenterOfAC.dY * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAC.dZ = Math.Round(DistanceCenterOfAC.dZ * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAB.dX = Math.Round(DistanceCenterOfAB.dX * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAB.dY = Math.Round(DistanceCenterOfAB.dY * buSystem.MmToInchRatio, 5);
		DistanceCenterOfAB.dZ = Math.Round(DistanceCenterOfAB.dZ * buSystem.MmToInchRatio, 5);
		DistanceCenterOfBC.dX = Math.Round(DistanceCenterOfBC.dX * buSystem.MmToInchRatio, 5);
		DistanceCenterOfBC.dY = Math.Round(DistanceCenterOfBC.dY * buSystem.MmToInchRatio, 5);
		DistanceCenterOfBC.dZ = Math.Round(DistanceCenterOfBC.dZ * buSystem.MmToInchRatio, 5);
	}

	public void InchToInch()
	{
		OffsetXYZ.X = Math.Round(OffsetXYZ.X * buSystem.InchToMmRatio, 5);
		OffsetXYZ.Y = Math.Round(OffsetXYZ.Y * buSystem.InchToMmRatio, 5);
		OffsetXYZ.Z = Math.Round(OffsetXYZ.Z * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfA.X = Math.Round(RotateCenterOffsetOfA.X * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfA.Y = Math.Round(RotateCenterOffsetOfA.Y * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfA.Z = Math.Round(RotateCenterOffsetOfA.Z * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfB.X = Math.Round(RotateCenterOffsetOfB.X * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfB.Y = Math.Round(RotateCenterOffsetOfB.Y * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfB.Z = Math.Round(RotateCenterOffsetOfB.Z * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfC.X = Math.Round(RotateCenterOffsetOfC.X * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfC.Y = Math.Round(RotateCenterOffsetOfC.Y * buSystem.InchToMmRatio, 5);
		RotateCenterOffsetOfC.Z = Math.Round(RotateCenterOffsetOfC.Z * buSystem.InchToMmRatio, 5);
		MovePartRuntimeOffset.X = Math.Round(MovePartRuntimeOffset.X * buSystem.InchToMmRatio, 5);
		MovePartRuntimeOffset.Y = Math.Round(MovePartRuntimeOffset.Y * buSystem.InchToMmRatio, 5);
		MovePartRuntimeOffset.Z = Math.Round(MovePartRuntimeOffset.Z * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAC.dX = Math.Round(DistanceCenterOfAC.dX * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAC.dY = Math.Round(DistanceCenterOfAC.dY * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAC.dZ = Math.Round(DistanceCenterOfAC.dZ * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAB.dX = Math.Round(DistanceCenterOfAB.dX * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAB.dY = Math.Round(DistanceCenterOfAB.dY * buSystem.InchToMmRatio, 5);
		DistanceCenterOfAB.dZ = Math.Round(DistanceCenterOfAB.dZ * buSystem.InchToMmRatio, 5);
		DistanceCenterOfBC.dX = Math.Round(DistanceCenterOfBC.dX * buSystem.InchToMmRatio, 5);
		DistanceCenterOfBC.dY = Math.Round(DistanceCenterOfBC.dY * buSystem.InchToMmRatio, 5);
		DistanceCenterOfBC.dZ = Math.Round(DistanceCenterOfBC.dZ * buSystem.InchToMmRatio, 5);
	}

	public static void Copy(KinematicBase5 baseKinematic, ref KinematicBase copyKinematic)
	{
		copyKinematic = new KinematicBase();
		copyKinematic.RotateCenterOffsetOfA = new Pnt3D(baseKinematic.RotateCenterOffsetOfA.X, baseKinematic.RotateCenterOffsetOfA.Y, baseKinematic.RotateCenterOffsetOfA.Z);
		copyKinematic.RotateCenterOffsetOfB = new Pnt3D(baseKinematic.RotateCenterOffsetOfB.X, baseKinematic.RotateCenterOffsetOfB.Y, baseKinematic.RotateCenterOffsetOfB.Z);
		copyKinematic.RotateCenterOffsetOfC = new Pnt3D(baseKinematic.RotateCenterOffsetOfC.X, baseKinematic.RotateCenterOffsetOfC.Y, baseKinematic.RotateCenterOffsetOfC.Z);
		copyKinematic.OffsetXYZ = new Pnt3D(baseKinematic.OffsetXYZ.X, baseKinematic.OffsetXYZ.Y, baseKinematic.OffsetXYZ.Z);
		copyKinematic.OffsetABC = new OrientationAngle(baseKinematic.OffsetABC.A, baseKinematic.OffsetABC.B, baseKinematic.OffsetABC.C);
		copyKinematic.Type = baseKinematic.Type;
		copyKinematic.Name = baseKinematic.Name;
		copyKinematic.FileName = baseKinematic.FileName;
	}

	public override string ToString()
	{
		return "Type: " + Type;
	}
}
