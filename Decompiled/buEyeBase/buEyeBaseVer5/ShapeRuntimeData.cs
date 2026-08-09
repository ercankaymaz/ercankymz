using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeRuntimeData : buSerilization5
{
	public camParameters5 CamPars = new camParameters5();

	public Point3D pntBase = new Point3D();

	public Point3D pntCalc = new Point3D();

	public Point3D pntCorner = new Point3D();

	public ShapeGroup ShapeGroup = ShapeGroup.Shape;

	public drillTypes DrillType = drillTypes.SingleHole;

	public CutTypes CutType = CutTypes.CutHorizontal;

	public ProfilingTypes ProfilingType = ProfilingTypes.ProfilingRectangle;

	public JunctionTypes JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;

	public ShapeTypes ShapeType = ShapeTypes.Rectangle;

	public planeBoxNames selectedPlane = planeBoxNames.Top;

	public CornerLocation selectedCorner = CornerLocation.LeftBottom;

	public ObjectAlignment objectAlignment = ObjectAlignment.MiddleCenter;

	public ShapeDataValueType ValueType = ShapeDataValueType.None;

	public ShapeEdit Edit = new ShapeEdit();

	public bool isTapping = false;

	public bool isMillingHole = false;

	public bool isMillingCut = false;

	public bool isMillingJunction = false;

	public bool isShapePocket = false;

	public bool isProfilingPocket = false;

	public bool isEngravePocket = false;

	public bool isIncrementalMode = false;

	public bool ManuelDepthEnable = false;

	public bool EachLayer = false;

	public int Priority = 0;

	public double SizeMaterailWidth = 0.0;

	public double SizeMaterailHeight = 0.0;

	public double SizeMaterailDepth = 0.0;

	public double ExtraDepth = 0.0;

	public double ManuelDepthStart = 0.0;

	public double IncrementalDistance = 100.0;

	public double RectangleWidth = 20.0;

	public double RectangleHeight = 20.0;

	public double RectangleDepth = 5.0;

	public double RectangleAngle = 0.0;

	public double RectangleRadius = 0.0;

	public double RectangleChamfer = 0.0;

	public double CircleRadius = 20.0;

	public double CircleDepth = 5.0;

	public double EllipseRadiusX = 20.0;

	public double EllipseRadiusY = 10.0;

	public double EllipseDepth = 5.0;

	public double EllipseAngle = 0.0;

	public double PolygonRadius = 20.0;

	public int PolygonSide = 5;

	public double PolygonDepth = 5.0;

	public double PolygonAngle = 0.0;

	public double SlotLength = 50.0;

	public double SlotDiameter = 10.0;

	public double SlotDepth = 5.0;

	public double SlotAngle = 0.0;

	public double KeyHoleLength = 33.0;

	public double KeyHoleHeadDiameter = 17.0;

	public double KeyHoleDiameter = 8.0;

	public double KeyHoleDepth = 0.0;

	public double KeyHoleAngle = 0.0;

	public double FreeDrawWidth = 20.0;

	public double FreeDrawHeight = 20.0;

	public double FreeDrawDepth = 5.0;

	public double FreeDrawAngle = 0.0;

	public double TextWidth = 20.0;

	public double TextHeight = 20.0;

	public double TextDepth = 5.0;

	public double TextAngle = 0.0;

	public string TextString = "";

	public bool TextIsWire = false;

	public Font TextFont = new Font("Arial", 10f);

	public double HoleDiameter = 8.0;

	public double HoleDiameterOutside = 8.0;

	public double HoleDepth = 5.0;

	public double HoleDistance = 0.0;

	public int HoleCount = 2;

	public double HoleStartDistance = 0.0;

	public double HoleEndDistance = 0.0;

	public double HoleAngle = 0.0;

	public double HoleOutsideDisX = 40.0;

	public double HoleOutsideDisY = 10.0;

	public double HoleAngle3Point = 0.0;

	public double TappingDiameter = 8.0;

	public double TappingPitch = 2.0;

	public double TappingAdditional = 1.0;

	public double TappingDepth = 5.0;

	public double CutDiameter = 8.0;

	public double CutLength = 100.0;

	public double CutDepth = 5.0;

	public double CutStartDistance = 0.0;

	public double CutEndDistance = 0.0;

	public double CutAngle = 0.0;

	public double ProfilingRadius = 8.0;

	public double ProfilingLength = 10.0;

	public double ProfilingWidth = 20.0;

	public double ProfilingHeight = 20.0;

	public double ProfilingDepth = 5.0;

	public double EngravingWidth = 100.0;

	public double EngravingHeight = 100.0;

	public double EngravingDepth = 5.0;

	public double EngravingOffsetZ = 0.0;

	public double JunctionDiameter = 8.0;

	public double JunctionDiameterOutside = 5.0;

	public double JunctionDistance = 100.0;

	public double JunctionDepth = 5.0;

	public double NotchWidth = 10.0;

	public double NotchHeight = 10.0;

	public double NotchDepth = 10.0;

	public double NotchStartHeight = 0.0;

	public double NotchCutPersentage = 90.0;

	public ProfileNotchOperationType NotchOPType = ProfileNotchOperationType.Side;

	public UpDownLocationType NotchUpDown = UpDownLocationType.Up;

	public FrontBackType NotchFrontBack = FrontBackType.Front;

	public ProfileNotchLocationType NotchSideLocation = ProfileNotchLocationType.Left;

	public ProfileNotchLocationType NotchLengthLocation = ProfileNotchLocationType.Front;

	public UpDownDirectionType CutDirection = UpDownDirectionType.UpToDown;

	public ProfileNotchCutType NotchCutType = ProfileNotchCutType.BySawAndMilling;

	public CamCuttingWayDirectionType NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;

	public bool UpdateEditOperationWithoutOk = false;

	public List<double> DepthLevels = new List<double>();

	public void MmToInch()
	{
		CamPars.MmToInch();
		Edit.MmToInch();
		pntBase.X = Math.Round(pntBase.X * buSystem.MmToInchRatio, 5);
		pntBase.Y = Math.Round(pntBase.Y * buSystem.MmToInchRatio, 5);
		pntBase.Z = Math.Round(pntBase.Z * buSystem.MmToInchRatio, 5);
		pntCalc.X = Math.Round(pntCalc.X * buSystem.MmToInchRatio, 5);
		pntCalc.Y = Math.Round(pntCalc.Y * buSystem.MmToInchRatio, 5);
		pntCalc.Z = Math.Round(pntCalc.Z * buSystem.MmToInchRatio, 5);
		SizeMaterailWidth = Math.Round(SizeMaterailWidth * buSystem.MmToInchRatio, 5);
		SizeMaterailHeight = Math.Round(SizeMaterailHeight * buSystem.MmToInchRatio, 5);
		SizeMaterailDepth = Math.Round(SizeMaterailDepth * buSystem.MmToInchRatio, 5);
		ExtraDepth = Math.Round(ExtraDepth * buSystem.MmToInchRatio, 5);
		ManuelDepthStart = Math.Round(ManuelDepthStart * buSystem.MmToInchRatio, 5);
		IncrementalDistance = Math.Round(IncrementalDistance * buSystem.MmToInchRatio, 5);
		RectangleWidth = Math.Round(RectangleWidth * buSystem.MmToInchRatio, 5);
		RectangleHeight = Math.Round(RectangleHeight * buSystem.MmToInchRatio, 5);
		RectangleDepth = Math.Round(RectangleDepth * buSystem.MmToInchRatio, 5);
		RectangleAngle = Math.Round(RectangleAngle * buSystem.MmToInchRatio, 5);
		RectangleRadius = Math.Round(RectangleRadius * buSystem.MmToInchRatio, 5);
		RectangleChamfer = Math.Round(RectangleChamfer * buSystem.MmToInchRatio, 5);
		CircleRadius = Math.Round(CircleRadius * buSystem.MmToInchRatio, 5);
		CircleDepth = Math.Round(CircleDepth * buSystem.MmToInchRatio, 5);
		EllipseRadiusX = Math.Round(EllipseRadiusX * buSystem.MmToInchRatio, 5);
		EllipseRadiusY = Math.Round(EllipseRadiusY * buSystem.MmToInchRatio, 5);
		EllipseDepth = Math.Round(EllipseDepth * buSystem.MmToInchRatio, 5);
		PolygonRadius = Math.Round(PolygonRadius * buSystem.MmToInchRatio, 5);
		PolygonDepth = Math.Round(PolygonDepth * buSystem.MmToInchRatio, 5);
		SlotLength = Math.Round(SlotLength * buSystem.MmToInchRatio, 5);
		SlotDiameter = Math.Round(SlotDiameter * buSystem.MmToInchRatio, 5);
		SlotDepth = Math.Round(SlotDepth * buSystem.MmToInchRatio, 5);
		KeyHoleLength = Math.Round(KeyHoleLength * buSystem.MmToInchRatio, 5);
		KeyHoleHeadDiameter = Math.Round(KeyHoleHeadDiameter * buSystem.MmToInchRatio, 5);
		KeyHoleDiameter = Math.Round(KeyHoleDiameter * buSystem.MmToInchRatio, 5);
		KeyHoleDepth = Math.Round(KeyHoleDepth * buSystem.MmToInchRatio, 5);
		FreeDrawWidth = Math.Round(FreeDrawWidth * buSystem.MmToInchRatio, 5);
		FreeDrawHeight = Math.Round(FreeDrawHeight * buSystem.MmToInchRatio, 5);
		FreeDrawDepth = Math.Round(FreeDrawDepth * buSystem.MmToInchRatio, 5);
		TextWidth = Math.Round(TextWidth * buSystem.MmToInchRatio, 5);
		TextHeight = Math.Round(TextHeight * buSystem.MmToInchRatio, 5);
		TextDepth = Math.Round(TextDepth * buSystem.MmToInchRatio, 5);
		HoleDiameter = Math.Round(HoleDiameter * buSystem.MmToInchRatio, 5);
		HoleDiameterOutside = Math.Round(HoleDiameterOutside * buSystem.MmToInchRatio, 5);
		HoleDepth = Math.Round(HoleDepth * buSystem.MmToInchRatio, 5);
		HoleDistance = Math.Round(HoleDistance * buSystem.MmToInchRatio, 5);
		HoleStartDistance = Math.Round(HoleStartDistance * buSystem.MmToInchRatio, 5);
		HoleEndDistance = Math.Round(HoleEndDistance * buSystem.MmToInchRatio, 5);
		HoleOutsideDisX = Math.Round(HoleOutsideDisX * buSystem.MmToInchRatio, 5);
		HoleOutsideDisY = Math.Round(HoleOutsideDisY * buSystem.MmToInchRatio, 5);
		HoleAngle3Point = Math.Round(HoleAngle3Point * buSystem.MmToInchRatio, 5);
		CutDiameter = Math.Round(CutDiameter * buSystem.MmToInchRatio, 5);
		CutLength = Math.Round(CutLength * buSystem.MmToInchRatio, 5);
		CutDepth = Math.Round(CutDepth * buSystem.MmToInchRatio, 5);
		CutStartDistance = Math.Round(CutStartDistance * buSystem.MmToInchRatio, 5);
		CutEndDistance = Math.Round(CutEndDistance * buSystem.MmToInchRatio, 5);
		ProfilingRadius = Math.Round(ProfilingRadius * buSystem.MmToInchRatio, 5);
		ProfilingLength = Math.Round(ProfilingLength * buSystem.MmToInchRatio, 5);
		ProfilingWidth = Math.Round(ProfilingWidth * buSystem.MmToInchRatio, 5);
		ProfilingHeight = Math.Round(ProfilingHeight * buSystem.MmToInchRatio, 5);
		ProfilingDepth = Math.Round(ProfilingDepth * buSystem.MmToInchRatio, 5);
		EngravingWidth = Math.Round(EngravingWidth * buSystem.MmToInchRatio, 5);
		EngravingHeight = Math.Round(EngravingHeight * buSystem.MmToInchRatio, 5);
		EngravingDepth = Math.Round(EngravingDepth * buSystem.MmToInchRatio, 5);
		EngravingOffsetZ = Math.Round(EngravingOffsetZ * buSystem.MmToInchRatio, 5);
		JunctionDiameter = Math.Round(JunctionDiameter * buSystem.MmToInchRatio, 5);
		JunctionDiameterOutside = Math.Round(JunctionDiameterOutside * buSystem.MmToInchRatio, 5);
		JunctionDistance = Math.Round(JunctionDistance * buSystem.MmToInchRatio, 5);
		JunctionDepth = Math.Round(JunctionDepth * buSystem.MmToInchRatio, 5);
		NotchWidth = Math.Round(NotchWidth * buSystem.MmToInchRatio, 5);
		NotchHeight = Math.Round(NotchHeight * buSystem.MmToInchRatio, 5);
		NotchDepth = Math.Round(NotchDepth * buSystem.MmToInchRatio, 5);
		NotchStartHeight = Math.Round(NotchStartHeight * buSystem.MmToInchRatio, 5);
	}

	public void InchToMm()
	{
		CamPars.InchToMm();
		Edit.InchToMm();
		pntBase.X = Math.Round(pntBase.X * buSystem.InchToMmRatio, 5);
		pntBase.Y = Math.Round(pntBase.Y * buSystem.InchToMmRatio, 5);
		pntBase.Z = Math.Round(pntBase.Z * buSystem.InchToMmRatio, 5);
		pntCalc.X = Math.Round(pntCalc.X * buSystem.InchToMmRatio, 5);
		pntCalc.Y = Math.Round(pntCalc.Y * buSystem.InchToMmRatio, 5);
		pntCalc.Z = Math.Round(pntCalc.Z * buSystem.InchToMmRatio, 5);
		SizeMaterailWidth = Math.Round(SizeMaterailWidth * buSystem.InchToMmRatio, 5);
		SizeMaterailHeight = Math.Round(SizeMaterailHeight * buSystem.InchToMmRatio, 5);
		SizeMaterailDepth = Math.Round(SizeMaterailDepth * buSystem.InchToMmRatio, 5);
		ExtraDepth = Math.Round(ExtraDepth * buSystem.InchToMmRatio, 5);
		ManuelDepthStart = Math.Round(ManuelDepthStart * buSystem.InchToMmRatio, 5);
		IncrementalDistance = Math.Round(IncrementalDistance * buSystem.InchToMmRatio, 5);
		RectangleWidth = Math.Round(RectangleWidth * buSystem.InchToMmRatio, 5);
		RectangleHeight = Math.Round(RectangleHeight * buSystem.InchToMmRatio, 5);
		RectangleDepth = Math.Round(RectangleDepth * buSystem.InchToMmRatio, 5);
		RectangleAngle = Math.Round(RectangleAngle * buSystem.InchToMmRatio, 5);
		RectangleRadius = Math.Round(RectangleRadius * buSystem.InchToMmRatio, 5);
		RectangleChamfer = Math.Round(RectangleChamfer * buSystem.InchToMmRatio, 5);
		CircleRadius = Math.Round(CircleRadius * buSystem.InchToMmRatio, 5);
		CircleDepth = Math.Round(CircleDepth * buSystem.InchToMmRatio, 5);
		EllipseRadiusX = Math.Round(EllipseRadiusX * buSystem.InchToMmRatio, 5);
		EllipseRadiusY = Math.Round(EllipseRadiusY * buSystem.InchToMmRatio, 5);
		EllipseDepth = Math.Round(EllipseDepth * buSystem.InchToMmRatio, 5);
		PolygonRadius = Math.Round(PolygonRadius * buSystem.InchToMmRatio, 5);
		PolygonDepth = Math.Round(PolygonDepth * buSystem.InchToMmRatio, 5);
		SlotLength = Math.Round(SlotLength * buSystem.InchToMmRatio, 5);
		SlotDiameter = Math.Round(SlotDiameter * buSystem.InchToMmRatio, 5);
		SlotDepth = Math.Round(SlotDepth * buSystem.InchToMmRatio, 5);
		KeyHoleLength = Math.Round(KeyHoleLength * buSystem.InchToMmRatio, 5);
		KeyHoleHeadDiameter = Math.Round(KeyHoleHeadDiameter * buSystem.InchToMmRatio, 5);
		KeyHoleDiameter = Math.Round(KeyHoleDiameter * buSystem.InchToMmRatio, 5);
		KeyHoleDepth = Math.Round(KeyHoleDepth * buSystem.InchToMmRatio, 5);
		FreeDrawWidth = Math.Round(FreeDrawWidth * buSystem.InchToMmRatio, 5);
		FreeDrawHeight = Math.Round(FreeDrawHeight * buSystem.InchToMmRatio, 5);
		FreeDrawDepth = Math.Round(FreeDrawDepth * buSystem.InchToMmRatio, 5);
		TextWidth = Math.Round(TextWidth * buSystem.InchToMmRatio, 5);
		TextHeight = Math.Round(TextHeight * buSystem.InchToMmRatio, 5);
		TextDepth = Math.Round(TextDepth * buSystem.InchToMmRatio, 5);
		HoleDiameter = Math.Round(HoleDiameter * buSystem.InchToMmRatio, 5);
		HoleDiameterOutside = Math.Round(HoleDiameterOutside * buSystem.InchToMmRatio, 5);
		HoleDepth = Math.Round(HoleDepth * buSystem.InchToMmRatio, 5);
		HoleDistance = Math.Round(HoleDistance * buSystem.InchToMmRatio, 5);
		HoleStartDistance = Math.Round(HoleStartDistance * buSystem.InchToMmRatio, 5);
		HoleEndDistance = Math.Round(HoleEndDistance * buSystem.InchToMmRatio, 5);
		HoleOutsideDisX = Math.Round(HoleOutsideDisX * buSystem.InchToMmRatio, 5);
		HoleOutsideDisY = Math.Round(HoleOutsideDisY * buSystem.InchToMmRatio, 5);
		HoleAngle3Point = Math.Round(HoleAngle3Point * buSystem.InchToMmRatio, 5);
		CutDiameter = Math.Round(CutDiameter * buSystem.InchToMmRatio, 5);
		CutLength = Math.Round(CutLength * buSystem.InchToMmRatio, 5);
		CutDepth = Math.Round(CutDepth * buSystem.InchToMmRatio, 5);
		CutStartDistance = Math.Round(CutStartDistance * buSystem.InchToMmRatio, 5);
		CutEndDistance = Math.Round(CutEndDistance * buSystem.InchToMmRatio, 5);
		ProfilingRadius = Math.Round(ProfilingRadius * buSystem.InchToMmRatio, 5);
		ProfilingLength = Math.Round(ProfilingLength * buSystem.InchToMmRatio, 5);
		ProfilingWidth = Math.Round(ProfilingWidth * buSystem.InchToMmRatio, 5);
		ProfilingHeight = Math.Round(ProfilingHeight * buSystem.InchToMmRatio, 5);
		ProfilingDepth = Math.Round(ProfilingDepth * buSystem.InchToMmRatio, 5);
		EngravingWidth = Math.Round(EngravingWidth * buSystem.InchToMmRatio, 5);
		EngravingHeight = Math.Round(EngravingHeight * buSystem.InchToMmRatio, 5);
		EngravingDepth = Math.Round(EngravingDepth * buSystem.InchToMmRatio, 5);
		EngravingOffsetZ = Math.Round(EngravingOffsetZ * buSystem.InchToMmRatio, 5);
		JunctionDiameter = Math.Round(JunctionDiameter * buSystem.InchToMmRatio, 5);
		JunctionDiameterOutside = Math.Round(JunctionDiameterOutside * buSystem.InchToMmRatio, 5);
		JunctionDistance = Math.Round(JunctionDistance * buSystem.InchToMmRatio, 5);
		JunctionDepth = Math.Round(JunctionDepth * buSystem.InchToMmRatio, 5);
		NotchWidth = Math.Round(NotchWidth * buSystem.InchToMmRatio, 5);
		NotchHeight = Math.Round(NotchHeight * buSystem.InchToMmRatio, 5);
		NotchDepth = Math.Round(NotchDepth * buSystem.InchToMmRatio, 5);
		NotchStartHeight = Math.Round(NotchStartHeight * buSystem.InchToMmRatio, 5);
	}

	public ShapeRuntimeData()
	{
	}

	public ShapeRuntimeData(ShapeRuntimeData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		CamPars = new camParameters5(data.CamPars);
		Edit = new ShapeEdit(data.Edit);
		pntBase = new Point3D(data.pntBase.X, data.pntBase.Y, data.pntBase.Z);
		pntCalc = new Point3D(data.pntCalc.X, data.pntCalc.Y, data.pntCalc.Z);
		pntCorner = new Point3D(data.pntCorner.X, data.pntCorner.Y, data.pntCorner.Z);
	}

	public override string ToString()
	{
		return "X :" + pntBase.X + ", Y :" + pntBase.Y + ", Z :" + pntBase.Z;
	}
}
