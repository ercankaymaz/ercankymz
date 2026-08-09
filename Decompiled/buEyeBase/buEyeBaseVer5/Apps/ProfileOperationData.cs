using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationData : buSerilization5
{
	public ProfileOperationDataCircle CircleData = new ProfileOperationDataCircle();

	public ProfileOperationDataRectangle RectangleData = new ProfileOperationDataRectangle();

	public ProfileOperationDataRectangleRound RectangleRoundData = new ProfileOperationDataRectangleRound();

	public ProfileOperationDataCut CutData = new ProfileOperationDataCut();

	public ProfileOperationDataSlot SlotData = new ProfileOperationDataSlot();

	public ProfileOperationDataEllipse EllipseData = new ProfileOperationDataEllipse();

	public ProfileOperationDataNotch NotchData = new ProfileOperationDataNotch();

	public ProfileOperationDataHole HoleData = new ProfileOperationDataHole();

	public ProfileOperationDataBarel BarelData = new ProfileOperationDataBarel();

	public ProfileOperationDataFreeDraw FreeDrawData = new ProfileOperationDataFreeDraw();

	public ProfileOperationDataText TextData = new ProfileOperationDataText();

	public ProfileOperationDataPolygon PolygonData = new ProfileOperationDataPolygon();

	public ShapeArray Array = new ShapeArray();

	public ShapeMirror Mirror = new ShapeMirror();

	public camParameters5 CamParMilling = new camParameters5();

	public camParameters5 CamParNotch = new camParameters5();

	public double ExternalDepth = 0.0;

	public double ExtraDepth = 0.0;

	public double IncrementalDistance = 100.0;

	public double ManuelZVal = 0.0;

	public double SelectedPlaneLength = 0.0;

	public bool ExtraDepthEnable = false;

	public bool EachLayer = false;

	public bool ManuelZEnable = false;

	public bool XRefFromProfileEnd = false;

	public planeNames selectedPlaneName = planeNames.Top;

	public SelectedPlaneInfo selectedPlaneInfo = new SelectedPlaneInfo();

	public Plane selectedPlane = new Plane();

	public Point3D movePlanePoint = new Point3D();

	public Point3D Position = new Point3D();

	public Point3D basePosition = new Point3D();

	public Point3D cornerPosition = new Point3D();

	public string ToolName = "";

	public string ToolNotchName = "";

	public string ToolAuxName = "";

	public actionTypeBU Action = actionTypeBU.None;

	public ProfileOperationTypes OperationType = ProfileOperationTypes.Circle;

	public CornerLocation Corner = CornerLocation.RightTop;

	public ObjectAlignment Alignment = ObjectAlignment.MiddleCenter;

	public DepthPositions Depth = new DepthPositions();

	public List<DepthPositions> DepthValues = new List<DepthPositions>();

	public bool DepthForced = false;

	public double ToolDiameter = 0.0;

	public static List<string> Captions = new List<string>();

	public ProfileOperationData()
	{
	}

	public ProfileOperationData(ProfileOperationData data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		selectedPlaneInfo = new SelectedPlaneInfo(data.selectedPlaneInfo);
		CamParMilling = new camParameters5(data.CamParMilling);
		CamParNotch = new camParameters5(data.CamParNotch);
		selectedPlane = (Plane)data.selectedPlane.Clone();
		Position = buVector5.ToPoint3D(data.Position);
		basePosition = buVector5.ToPoint3D(data.basePosition);
		movePlanePoint = buVector5.ToPoint3D(data.movePlanePoint);
		DepthValues.Clear();
		for (int j = 0; j <= data.DepthValues.Count - 1; j++)
		{
			DepthValues.Add(new DepthPositions(data.DepthValues[j]));
		}
		Array = new ShapeArray(data.Array);
		Depth = new DepthPositions(data.Depth);
		Mirror = new ShapeMirror(data.Mirror);
		CircleData = new ProfileOperationDataCircle(data.CircleData);
		RectangleData = new ProfileOperationDataRectangle(data.RectangleData);
		RectangleRoundData = new ProfileOperationDataRectangleRound(data.RectangleRoundData);
		SlotData = new ProfileOperationDataSlot(data.SlotData);
		EllipseData = new ProfileOperationDataEllipse(data.EllipseData);
		NotchData = new ProfileOperationDataNotch(data.NotchData);
		HoleData = new ProfileOperationDataHole(data.HoleData);
		BarelData = new ProfileOperationDataBarel(data.BarelData);
		FreeDrawData = new ProfileOperationDataFreeDraw(data.FreeDrawData);
		TextData = new ProfileOperationDataText(data.TextData);
		CutData = new ProfileOperationDataCut(data.CutData);
		PolygonData = new ProfileOperationDataPolygon(data.PolygonData);
	}

	public void MmToInch()
	{
		CircleData.CircleDiameter = Math.Round(CircleData.CircleDiameter * buSystem.MmToInchRatio, 5);
		CircleData.CircleThickness = Math.Round(CircleData.CircleDiameter * buSystem.MmToInchRatio, 5);
		RectangleData.RectangleChamfer = Math.Round(RectangleData.RectangleChamfer * buSystem.MmToInchRatio, 5);
		RectangleData.RectangleHeight = Math.Round(RectangleData.RectangleHeight * buSystem.MmToInchRatio, 5);
		RectangleData.RectangleRadius = Math.Round(RectangleData.RectangleRadius * buSystem.MmToInchRatio, 5);
		RectangleData.RectangleThickness = Math.Round(RectangleData.RectangleThickness * buSystem.MmToInchRatio, 5);
		RectangleData.RectangleWidth = Math.Round(RectangleData.RectangleWidth * buSystem.MmToInchRatio, 5);
		RectangleRoundData.RoundRectangleHeight = Math.Round(RectangleRoundData.RoundRectangleHeight * buSystem.MmToInchRatio, 5);
		RectangleRoundData.RoundRectangleRadius = Math.Round(RectangleRoundData.RoundRectangleRadius * buSystem.MmToInchRatio, 5);
		RectangleRoundData.RoundRectangleThickness = Math.Round(RectangleRoundData.RoundRectangleThickness * buSystem.MmToInchRatio, 5);
		RectangleRoundData.RoundRectangleWidth = Math.Round(RectangleRoundData.RoundRectangleWidth * buSystem.MmToInchRatio, 5);
		CutData.CutDepth = Math.Round(CutData.CutDepth * buSystem.MmToInchRatio, 5);
		CutData.CutHeigth = Math.Round(CutData.CutHeigth * buSystem.MmToInchRatio, 5);
		CutData.CutThickness = Math.Round(CutData.CutThickness * buSystem.MmToInchRatio, 5);
		CutData.CutWidth = Math.Round(CutData.CutWidth * buSystem.MmToInchRatio, 5);
		SlotData.SlotDiameter = Math.Round(SlotData.SlotDiameter * buSystem.MmToInchRatio, 5);
		SlotData.SlotThickness = Math.Round(SlotData.SlotThickness * buSystem.MmToInchRatio, 5);
		SlotData.SlotWidth = Math.Round(SlotData.SlotWidth * buSystem.MmToInchRatio, 5);
		EllipseData.EllipseHeight = Math.Round(EllipseData.EllipseHeight * buSystem.MmToInchRatio, 5);
		EllipseData.EllipseThickness = Math.Round(EllipseData.EllipseThickness * buSystem.MmToInchRatio, 5);
		EllipseData.EllipseWidth = Math.Round(EllipseData.EllipseWidth * buSystem.MmToInchRatio, 5);
		NotchData.NotchDepth = Math.Round(NotchData.NotchDepth * buSystem.MmToInchRatio, 5);
		NotchData.NotchHeight = Math.Round(NotchData.NotchHeight * buSystem.MmToInchRatio, 5);
		NotchData.NotchStart = Math.Round(NotchData.NotchStart * buSystem.MmToInchRatio, 5);
		NotchData.NotchThickness = Math.Round(NotchData.NotchThickness * buSystem.MmToInchRatio, 5);
		NotchData.NotchWidth = Math.Round(NotchData.NotchWidth * buSystem.MmToInchRatio, 5);
		HoleData.HoleDepth = Math.Round(HoleData.HoleDepth * buSystem.MmToInchRatio, 5);
		HoleData.HoleDiameter = Math.Round(HoleData.HoleDiameter * buSystem.MmToInchRatio, 5);
		HoleData.HoleThickness = Math.Round(HoleData.HoleThickness * buSystem.MmToInchRatio, 5);
		BarelData.BarrelDiameter = Math.Round(BarelData.BarrelDiameter * buSystem.MmToInchRatio, 5);
		BarelData.BarrelLength = Math.Round(BarelData.BarrelLength * buSystem.MmToInchRatio, 5);
		BarelData.BarrelThickness = Math.Round(BarelData.BarrelThickness * buSystem.MmToInchRatio, 5);
		BarelData.BarrelWidth = Math.Round(BarelData.BarrelWidth * buSystem.MmToInchRatio, 5);
		FreeDrawData.FreeDrawHeight = Math.Round(FreeDrawData.FreeDrawHeight * buSystem.MmToInchRatio, 5);
		FreeDrawData.FreeDrawThickness = Math.Round(FreeDrawData.FreeDrawThickness * buSystem.MmToInchRatio, 5);
		FreeDrawData.FreeDrawWidth = Math.Round(FreeDrawData.FreeDrawThickness * buSystem.MmToInchRatio, 5);
		TextData.CharSpace = Math.Round(TextData.CharSpace * buSystem.MmToInchRatio, 5);
		TextData.SpaceValue = Math.Round(TextData.SpaceValue * buSystem.MmToInchRatio, 5);
		TextData.TextHeight = Math.Round(TextData.TextHeight * buSystem.MmToInchRatio, 5);
		TextData.TextThickness = Math.Round(TextData.TextThickness * buSystem.MmToInchRatio, 5);
		TextData.TextWidth = Math.Round(TextData.TextWidth * buSystem.MmToInchRatio, 5);
		PolygonData.PolygonDiameter = Math.Round(PolygonData.PolygonDiameter * buSystem.MmToInchRatio, 5);
		PolygonData.PolygonThickness = Math.Round(PolygonData.PolygonThickness * buSystem.MmToInchRatio, 5);
		Array.LineerXDistance = Math.Round(Array.LineerXDistance * buSystem.MmToInchRatio, 5);
		Array.LineerYDistance = Math.Round(Array.LineerXDistance * buSystem.MmToInchRatio, 5);
		Mirror.MirrorDistance = Math.Round(Mirror.MirrorDistance * buSystem.MmToInchRatio, 5);
		ExternalDepth = Math.Round(ExternalDepth * buSystem.MmToInchRatio, 5);
		ExtraDepth = Math.Round(ExtraDepth * buSystem.MmToInchRatio, 5);
		IncrementalDistance = Math.Round(IncrementalDistance * buSystem.MmToInchRatio, 5);
		ManuelZVal = Math.Round(ManuelZVal * buSystem.MmToInchRatio, 5);
		SelectedPlaneLength = Math.Round(SelectedPlaneLength * buSystem.MmToInchRatio, 5);
		movePlanePoint.X = Math.Round(movePlanePoint.X * buSystem.MmToInchRatio, 5);
		movePlanePoint.Y = Math.Round(movePlanePoint.Y * buSystem.MmToInchRatio, 5);
		movePlanePoint.Z = Math.Round(movePlanePoint.Z * buSystem.MmToInchRatio, 5);
		Position.X = Math.Round(Position.X * buSystem.MmToInchRatio, 5);
		Position.Y = Math.Round(Position.Y * buSystem.MmToInchRatio, 5);
		Position.Z = Math.Round(Position.Z * buSystem.MmToInchRatio, 5);
		basePosition.X = Math.Round(basePosition.X * buSystem.MmToInchRatio, 5);
		basePosition.Y = Math.Round(basePosition.Y * buSystem.MmToInchRatio, 5);
		basePosition.Z = Math.Round(basePosition.Z * buSystem.MmToInchRatio, 5);
		cornerPosition.X = Math.Round(cornerPosition.X * buSystem.MmToInchRatio, 5);
		cornerPosition.Y = Math.Round(cornerPosition.Y * buSystem.MmToInchRatio, 5);
		cornerPosition.Z = Math.Round(cornerPosition.Z * buSystem.MmToInchRatio, 5);
		Depth.BottomPosition = Math.Round(Depth.BottomPosition * buSystem.MmToInchRatio, 5);
		Depth.Depth = Math.Round(Depth.Depth * buSystem.MmToInchRatio, 5);
		Depth.TopPosition = Math.Round(Depth.TopPosition * buSystem.MmToInchRatio, 5);
		for (int i = 0; i <= DepthValues.Count - 1; i++)
		{
			DepthValues[i].BottomPosition = Math.Round(DepthValues[i].BottomPosition * buSystem.MmToInchRatio, 5);
			DepthValues[i].Depth = Math.Round(DepthValues[i].Depth * buSystem.MmToInchRatio, 5);
			DepthValues[i].TopPosition = Math.Round(DepthValues[i].TopPosition * buSystem.MmToInchRatio, 5);
		}
	}

	public void InchToMm()
	{
		CircleData.CircleDiameter = Math.Round(CircleData.CircleDiameter * buSystem.InchToMmRatio, 5);
		CircleData.CircleThickness = Math.Round(CircleData.CircleDiameter * buSystem.InchToMmRatio, 5);
		RectangleData.RectangleChamfer = Math.Round(RectangleData.RectangleChamfer * buSystem.InchToMmRatio, 5);
		RectangleData.RectangleHeight = Math.Round(RectangleData.RectangleHeight * buSystem.InchToMmRatio, 5);
		RectangleData.RectangleRadius = Math.Round(RectangleData.RectangleRadius * buSystem.InchToMmRatio, 5);
		RectangleData.RectangleThickness = Math.Round(RectangleData.RectangleThickness * buSystem.InchToMmRatio, 5);
		RectangleData.RectangleWidth = Math.Round(RectangleData.RectangleWidth * buSystem.InchToMmRatio, 5);
		RectangleRoundData.RoundRectangleHeight = Math.Round(RectangleRoundData.RoundRectangleHeight * buSystem.InchToMmRatio, 5);
		RectangleRoundData.RoundRectangleRadius = Math.Round(RectangleRoundData.RoundRectangleRadius * buSystem.InchToMmRatio, 5);
		RectangleRoundData.RoundRectangleThickness = Math.Round(RectangleRoundData.RoundRectangleThickness * buSystem.InchToMmRatio, 5);
		RectangleRoundData.RoundRectangleWidth = Math.Round(RectangleRoundData.RoundRectangleWidth * buSystem.InchToMmRatio, 5);
		CutData.CutDepth = Math.Round(CutData.CutDepth * buSystem.InchToMmRatio, 5);
		CutData.CutHeigth = Math.Round(CutData.CutHeigth * buSystem.InchToMmRatio, 5);
		CutData.CutThickness = Math.Round(CutData.CutThickness * buSystem.InchToMmRatio, 5);
		CutData.CutWidth = Math.Round(CutData.CutWidth * buSystem.InchToMmRatio, 5);
		SlotData.SlotDiameter = Math.Round(SlotData.SlotDiameter * buSystem.InchToMmRatio, 5);
		SlotData.SlotThickness = Math.Round(SlotData.SlotThickness * buSystem.InchToMmRatio, 5);
		SlotData.SlotWidth = Math.Round(SlotData.SlotWidth * buSystem.InchToMmRatio, 5);
		EllipseData.EllipseHeight = Math.Round(EllipseData.EllipseHeight * buSystem.InchToMmRatio, 5);
		EllipseData.EllipseThickness = Math.Round(EllipseData.EllipseThickness * buSystem.InchToMmRatio, 5);
		EllipseData.EllipseWidth = Math.Round(EllipseData.EllipseWidth * buSystem.InchToMmRatio, 5);
		NotchData.NotchDepth = Math.Round(NotchData.NotchDepth * buSystem.InchToMmRatio, 5);
		NotchData.NotchHeight = Math.Round(NotchData.NotchHeight * buSystem.InchToMmRatio, 5);
		NotchData.NotchStart = Math.Round(NotchData.NotchStart * buSystem.InchToMmRatio, 5);
		NotchData.NotchThickness = Math.Round(NotchData.NotchThickness * buSystem.InchToMmRatio, 5);
		NotchData.NotchWidth = Math.Round(NotchData.NotchWidth * buSystem.InchToMmRatio, 5);
		HoleData.HoleDepth = Math.Round(HoleData.HoleDepth * buSystem.InchToMmRatio, 5);
		HoleData.HoleDiameter = Math.Round(HoleData.HoleDiameter * buSystem.InchToMmRatio, 5);
		HoleData.HoleThickness = Math.Round(HoleData.HoleThickness * buSystem.InchToMmRatio, 5);
		BarelData.BarrelDiameter = Math.Round(BarelData.BarrelDiameter * buSystem.InchToMmRatio, 5);
		BarelData.BarrelLength = Math.Round(BarelData.BarrelLength * buSystem.InchToMmRatio, 5);
		BarelData.BarrelThickness = Math.Round(BarelData.BarrelThickness * buSystem.InchToMmRatio, 5);
		BarelData.BarrelWidth = Math.Round(BarelData.BarrelWidth * buSystem.InchToMmRatio, 5);
		FreeDrawData.FreeDrawHeight = Math.Round(FreeDrawData.FreeDrawHeight * buSystem.InchToMmRatio, 5);
		FreeDrawData.FreeDrawThickness = Math.Round(FreeDrawData.FreeDrawThickness * buSystem.InchToMmRatio, 5);
		FreeDrawData.FreeDrawWidth = Math.Round(FreeDrawData.FreeDrawThickness * buSystem.InchToMmRatio, 5);
		TextData.CharSpace = Math.Round(TextData.CharSpace * buSystem.InchToMmRatio, 5);
		TextData.SpaceValue = Math.Round(TextData.SpaceValue * buSystem.InchToMmRatio, 5);
		TextData.TextHeight = Math.Round(TextData.TextHeight * buSystem.InchToMmRatio, 5);
		TextData.TextThickness = Math.Round(TextData.TextThickness * buSystem.InchToMmRatio, 5);
		TextData.TextWidth = Math.Round(TextData.TextWidth * buSystem.InchToMmRatio, 5);
		PolygonData.PolygonDiameter = Math.Round(PolygonData.PolygonDiameter * buSystem.InchToMmRatio, 5);
		PolygonData.PolygonThickness = Math.Round(PolygonData.PolygonThickness * buSystem.InchToMmRatio, 5);
		Array.LineerXDistance = Math.Round(Array.LineerXDistance * buSystem.InchToMmRatio, 5);
		Array.LineerYDistance = Math.Round(Array.LineerXDistance * buSystem.InchToMmRatio, 5);
		Mirror.MirrorDistance = Math.Round(Mirror.MirrorDistance * buSystem.InchToMmRatio, 5);
		ExternalDepth = Math.Round(ExternalDepth * buSystem.InchToMmRatio, 5);
		ExtraDepth = Math.Round(ExtraDepth * buSystem.InchToMmRatio, 5);
		IncrementalDistance = Math.Round(IncrementalDistance * buSystem.InchToMmRatio, 5);
		ManuelZVal = Math.Round(ManuelZVal * buSystem.InchToMmRatio, 5);
		SelectedPlaneLength = Math.Round(SelectedPlaneLength * buSystem.InchToMmRatio, 5);
		movePlanePoint.X = Math.Round(movePlanePoint.X * buSystem.InchToMmRatio, 5);
		movePlanePoint.Y = Math.Round(movePlanePoint.Y * buSystem.InchToMmRatio, 5);
		movePlanePoint.Z = Math.Round(movePlanePoint.Z * buSystem.InchToMmRatio, 5);
		Position.X = Math.Round(Position.X * buSystem.InchToMmRatio, 5);
		Position.Y = Math.Round(Position.Y * buSystem.InchToMmRatio, 5);
		Position.Z = Math.Round(Position.Z * buSystem.InchToMmRatio, 5);
		basePosition.X = Math.Round(basePosition.X * buSystem.InchToMmRatio, 5);
		basePosition.Y = Math.Round(basePosition.Y * buSystem.InchToMmRatio, 5);
		basePosition.Z = Math.Round(basePosition.Z * buSystem.InchToMmRatio, 5);
		cornerPosition.X = Math.Round(cornerPosition.X * buSystem.InchToMmRatio, 5);
		cornerPosition.Y = Math.Round(cornerPosition.Y * buSystem.InchToMmRatio, 5);
		cornerPosition.Z = Math.Round(cornerPosition.Z * buSystem.InchToMmRatio, 5);
		Depth.BottomPosition = Math.Round(Depth.BottomPosition * buSystem.InchToMmRatio, 5);
		Depth.Depth = Math.Round(Depth.Depth * buSystem.InchToMmRatio, 5);
		Depth.TopPosition = Math.Round(Depth.TopPosition * buSystem.InchToMmRatio, 5);
		for (int i = 0; i <= DepthValues.Count - 1; i++)
		{
			DepthValues[i].BottomPosition = Math.Round(DepthValues[i].BottomPosition * buSystem.InchToMmRatio, 5);
			DepthValues[i].Depth = Math.Round(DepthValues[i].Depth * buSystem.InchToMmRatio, 5);
			DepthValues[i].TopPosition = Math.Round(DepthValues[i].TopPosition * buSystem.InchToMmRatio, 5);
		}
	}

	public override string ToString()
	{
		string text = OperationType.ToString() + " , Plane: " + selectedPlaneName.ToString() + " , Pos: " + Position.ToString();
		if (ToolName.Length > 0)
		{
			text = text + ", Tool: " + ToolName;
		}
		return text;
	}

	public static ArrayList ToDefPars(ProfileOperationData P, string Char, int Space)
	{
		string text = "ProfileOperationDataPars";
		if (Char.Trim().Length > 0)
		{
			text = Char;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<" + text);
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</" + text);
		return arrayList;
	}

	public static ArrayList ToDefPars(ProfileOperationData P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationData P)
	{
		return buSerilization5.ClassToString(P);
	}
}
