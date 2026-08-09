using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleRuntimeSettings : buSerilization5
{
	public string WoodTextureName = "";

	public string MarbleTextureName = "";

	public bool SnapEnable = false;

	public bool ShowGridCNC = false;

	public bool RotateCameraCNC = true;

	public bool ShowGridCadCam = false;

	public bool RotateCameraCadCam = true;

	public double GridStep = 100.0;

	public double ManuelMove = 100.0;

	public double ManuelRotate = 45.0;

	public double HorizontalLenght = 1000.0;

	public double VerticalLenght = 1000.0;

	public double TextWireframeHeight = 50.0;

	public string TextWireframeString = "";

	public string pathItems = Application.StartupPath;

	public string pathFromFileMilling5Axis = Application.StartupPath;

	public string pathFromFileEngraving = Application.StartupPath;

	public string pathFromFileSawMilling = Application.StartupPath;

	public string pathFromFileProfiling = Application.StartupPath;

	public string pathFromFileProfileCurve = Application.StartupPath;

	public string pathFromFileContour = Application.StartupPath;

	public string pathFromFileSweep = Application.StartupPath;

	public string pathFromFileSweepForm = Application.StartupPath;

	public string pathFromFileLibray = Application.StartupPath;

	public string pathFromFileLathe = Application.StartupPath;

	public string pathFromFileColumns = Application.StartupPath;

	public string pathFromFileDrill = Application.StartupPath;

	public string pathFromPhoto = Application.StartupPath;

	public string pathFromSheet = Application.StartupPath;

	public string pathExternalGCode = Application.StartupPath;

	public string pathGCode = Application.StartupPath;

	public string pathImportImage = Application.StartupPath;

	public string pathTextFile = Application.StartupPath;

	public string pathTools = Application.StartupPath;

	public string pathJob = Application.StartupPath;

	public string pathG54 = Application.StartupPath;

	public string pathMaterialMeasure = Application.StartupPath;

	public string pathParks = Application.StartupPath;

	public string pathEasyDraw = Application.StartupPath;

	public string fileWood = "";

	public string fileMarble = "";

	public string textFontDrawing = "";

	public string textWireframeDrawing = "";

	public bool FromFileKeepRatio = true;

	public bool ShowAllDrawing = true;

	public bool Text3D = true;

	public double CameraBaseXPosition = 0.0;

	public double CameraBaseYPosition = 0.0;

	public double CameraFirstXPosition = 0.0;

	public double CameraFirstYPosition = 0.0;

	public double CameraFirstMaterial = 20.0;

	public double CameraSecondXPosition = 0.0;

	public double CameraSecondYPosition = 0.0;

	public double CameraSecondMaterial = 100.0;

	public double LathePartLength = 1000.0;

	public double DrillXPosition = 100.0;

	public double DrillYPosition = 100.0;

	public double DrillZPosition = 100.0;

	public double DrillDiameter = 10.0;

	public double DrillDepth = 8.0;

	public double CutLengthHorizontal = 500.0;

	public double CutLengthVertical = 500.0;

	public double CutLengthHorVerHorizontal = 500.0;

	public double CutLengthHorVerVertical = 500.0;

	public double HorizontalWidth = 300.0;

	public double HorizontalCount = 1.0;

	public double HorizontalStartAngle = 0.0;

	public double HorizontalEndAngle = 0.0;

	public double VerticalWidth = 300.0;

	public double VerticalCount = 1.0;

	public double VerticalStartAngle = 0.0;

	public double VerticalEndAngle = 0.0;

	public double SingleCutLength = 1000.0;

	public double SingleCutAAngle = 0.0;

	public double SliceWidth = 200.0;

	public double SliceLength = 1200.0;

	public int SliceCount = 1;

	public double SliceStartAngle = 0.0;

	public double SliceEndAngle = 0.0;

	public HorizontalVertical SliceType = HorizontalVertical.Horizontal;

	public double ScaleWidth = 0.0;

	public double ScaleHeight = 0.0;

	public double ScaleDepth = 0.0;

	public double ScaleLength = 0.0;

	public double ScaleBaseHeight = 0.0;

	public bool ScaleKeepRatio = true;

	public double SlatWidth = 50.0;

	public double SlatStartAngle = 45.0;

	public double SlatEndAngle = 0.0;

	public double SlatOffset = 10.0;

	public bool SlatAddAngleSelectedEdge = false;

	public double CollapseDepth = 4.0;

	public double CollapseOffset = 4.0;

	public double CollapseStep = 2.0;

	public OutsideInsideType CollapseDirection = OutsideInsideType.Inside;

	public MarbleToolType CollapseToolType = MarbleToolType.Milling;

	public bool CollapseEnable = false;

	public double BorderLeft = 0.0;

	public double BorderRight = 0.0;

	public double BorderTop = 0.0;

	public double BorderBottom = 0.0;

	public bool BorderEnable = true;

	public double ArrayXCount = 1.0;

	public double ArrayXDistance = 50.0;

	public double ArrayYCount = 1.0;

	public double ArrayYDistance = 50.0;

	public double CopyXDistance = 50.0;

	public double CopyYDistance = 50.0;

	public double CopyXCount = 1.0;

	public double CopyYCount = 1.0;

	public MarbleCopyType CopyType = MarbleCopyType.XDirection;

	public MirrorAxisXYType MirrorType = MirrorAxisXYType.X;

	public double MirrorDistance = 10.0;

	public bool MirrorDeleteOriginale = true;

	public double AlignMagnetOffset = 0.0;

	public double AlignMoveValue = 50.0;

	public double AlignSideOffset = 0.0;

	public double ExtendLength = 20.0;

	public double VacuumMove = 100.0;

	public double BreakDistance = 50.0;

	public MarbleBreakType BreakType = MarbleBreakType.Distance;

	public double OffsetDistance = 50.0;

	public double Shape3DHeight = 200.0;

	public double Shape3DDepth = 10.0;

	public double Shape3DOffsetX = 0.0;

	public double Shape3DOffsetY = 0.0;

	public double Shape3DInOffsetX = 0.0;

	public double Shape3DInOffsetY = 0.0;

	public planeNames Shape3DPlane = planeNames.Top;

	public double BasicDrawAngle = 0.0;

	public double BasicDrawLength = 100.0;

	public double BasicDrawDx = 100.0;

	public double BasicDrawDy = 100.0;

	public double BasicDrawWidth = 100.0;

	public double BasicDrawHeight = 100.0;

	public double BasicDrawDiameter = 100.0;

	public int BasicDrawLineMethod = 0;

	public double ShapeRectangleWidth = 500.0;

	public double ShapeRectangleHeight = 500.0;

	public double ShapeRectangleTopAngle = 0.0;

	public double ShapeRectangleBottomAngle = 0.0;

	public double ShapeRectangleLeftAngle = 0.0;

	public double ShapeRectangleRightAngle = 0.0;

	public double ShapeRectangleCrossWidth = 500.0;

	public double ShapeRectangleCrossHeight = 500.0;

	public double ShapeRectangleCrossTopAngle = 0.0;

	public double ShapeRectangleCrossBottomAngle = 0.0;

	public double ShapeRectangleCrossLeftAngle = 0.0;

	public double ShapeRectangleCrossRightAngle = 0.0;

	public double ShapeRectangleRoundWidth = 500.0;

	public double ShapeRectangleRoundHeight = 500.0;

	public double ShapeRectangleRoundRadius = 50.0;

	public double ShapeRectangleRoundAngle = 0.0;

	public double ShapeRectangleRoundTopAngle = 0.0;

	public double ShapeRectangleRoundBottomAngle = 0.0;

	public double ShapeRectangleRoundLeftAngle = 0.0;

	public double ShapeRectangleRoundRightAngle = 0.0;

	public double ShapeRectangleChamferWidth = 500.0;

	public double ShapeRectangleChamferHeight = 500.0;

	public double ShapeRectangleChamferLength = 50.0;

	public double ShapeRectangleChamferAngle = 0.0;

	public double ShapeRectangleChamferTopAngle = 0.0;

	public double ShapeRectangleChamferBottomAngle = 0.0;

	public double ShapeRectangleChamferLeftAngle = 0.0;

	public double ShapeRectangleChamferRightAngle = 0.0;

	public double ShapeCircleDiameter = 100.0;

	public double ShapeCircleAngle = 0.0;

	public double ShapeEllipseWidth = 200.0;

	public double ShapeEllipseHeight = 100.0;

	public double ShapeEllipseAngle = 0.0;

	public double ShapePolygonRadius = 100.0;

	public int ShapePolygonSide = 6;

	public double ShapePolygonAngle = 0.0;

	public double ShapeTriangleWidth = 100.0;

	public double ShapeTriangleHeight = 100.0;

	public double ShapeTriangleLeftAngle = 0.0;

	public double ShapeTriangleBottomAngle = 0.0;

	public double ShapeTriangleCrossAngle = 0.0;

	public double ShapeTrapezLength1 = 100.0;

	public double ShapeTrapezLength2 = 200.0;

	public double ShapeTrapezHeight = 100.0;

	public double ShapeTrapezTopAngle = 0.0;

	public double ShapeTrapezBottomAngle = 0.0;

	public double ShapeTrapezLeftAngle = 0.0;

	public double ShapeTrapezRightAngle = 0.0;

	public double ShapeSlotWidth = 200.0;

	public double ShapeSlotHeight = 300.0;

	public double ShapeSlotAngle = 0.0;

	public double ShapeArcPieRadius = 500.0;

	public double ShapeArcPieSweepAngle = 90.0;

	public double ShapeArcPieAngle = 0.0;

	public double ShapeShipNoseWidth = 500.0;

	public double ShapeShipNoseHeight = 500.0;

	public double ShapeShipNoseTopAngle = 0.0;

	public double ShapeShipNoseBottomAngle = 0.0;

	public double ShapeShipNoseLeftAngle = 0.0;

	public double ShapeShipNoseRightAngle = 0.0;

	public double ShapeShipNoseArcXDistance = 50.0;

	public double ShapeShipNoseArcYDistance = 50.0;

	public double ShapeShipNoseRadius = 0.0;

	public double ShapeArcBigRadius = 100.0;

	public double ShapeArcSmallRadius = 100.0;

	public double ShapeArcSweepAngle = 90.0;

	public double ShapeArcOutsideLength = 300.0;

	public double ShapeArcHeight = 100.0;

	public double ShapeArcThickness = 70.0;

	public double ShapeEllipsePieWidth = 400.0;

	public double ShapeEllipsePieHeight = 400.0;

	public double ShapeEllipsePieSweepAngle = 90.0;

	public double ShapeEllipsePieAngle = 0.0;

	public double ShapeRotation = 0.0;

	public double ShapeRotateAngle = 0.0;

	public bool ShapeLinearArrayEnable = false;

	public double ShapeLinearArrayXCount = 1.0;

	public double ShapeLinearArrayYCount = 1.0;

	public double ShapeLinearArrayXDistance = 0.0;

	public double ShapeLinearArrayYDistance = 0.0;

	public double ShapeCircularArrayCount = 1.0;

	public double ShapeCircularArrarAngle = 0.0;

	public bool selectedSheetAddNesting = false;

	public bool selectedPhotoAddNesting = false;

	public bool selectedContourAddNesting = false;

	public bool selectedProfileAddNesting = false;

	public bool selectedLibraryAddNesting = false;

	public bool selectedTextAddNesting = false;

	public bool selectedDrawingAddNesting = false;

	public bool selectedEngraving5AxisMilling = false;

	public bool selectedColomns5AxisMilling = false;

	public bool InisdeMilling = false;

	public bool selectedPhotoEdit = false;

	public bool selectedSheetEdit = false;

	public bool HorReverseCut = false;

	public bool VerReverseCut = false;

	public bool SliceHorStartCut = false;

	public bool SliceHorEndCut = false;

	public bool SliceVerStartCut = false;

	public bool SliceVerEndCut = false;

	public MarbleCorners HorVerHorCornerType = MarbleCorners.LeftBottom;

	public MarbleCorners HorVerVerCornerType = MarbleCorners.LeftTop;

	public MarbleCorners HorCornerType = MarbleCorners.LeftBottom;

	public MarbleCorners VerCornerType = MarbleCorners.LeftTop;

	public marbleMenuType selectedContour = new marbleMenuType();

	public marbleMenuType selectedProfile = new marbleMenuType();

	public marbleMenuType selectedProfileCurve = new marbleMenuType();

	public marbleMenuType selectedLibrary = new marbleMenuType();

	public marbleMenuType selectedText = new marbleMenuType();

	public marbleMenuType selectedSweep = new marbleMenuType();

	public marbleMenuType selectedDrill = new marbleMenuType();

	public marbleMenuType selectedDrawing = new marbleMenuType();

	public marbleMenuType selectedColumns = new marbleMenuType();

	public marbleMenuType selectedLathe = new marbleMenuType();

	public marbleMenuType selectedLathePerpendicular = new marbleMenuType();

	public marbleMenuType selectedEngraving = new marbleMenuType();

	public marbleMenuType selectedType = new marbleMenuType();

	public marbleMenuType selectedSawMilling = new marbleMenuType();

	public marbleMenuType selectedMilling5Axis = new marbleMenuType();

	public MarbleRuntimeSettings()
	{
	}

	public MarbleRuntimeSettings(MarbleRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		selectedContour = new marbleMenuType(data.selectedContour);
		selectedProfile = new marbleMenuType(data.selectedProfile);
		selectedProfileCurve = new marbleMenuType(data.selectedProfileCurve);
		selectedLibrary = new marbleMenuType(data.selectedLibrary);
		selectedText = new marbleMenuType(data.selectedText);
		selectedSweep = new marbleMenuType(data.selectedSweep);
		selectedDrill = new marbleMenuType(data.selectedDrill);
		selectedDrawing = new marbleMenuType(data.selectedDrawing);
		selectedColumns = new marbleMenuType(data.selectedColumns);
		selectedLathe = new marbleMenuType(data.selectedLathe);
		selectedLathePerpendicular = new marbleMenuType(data.selectedLathePerpendicular);
		selectedEngraving = new marbleMenuType(data.selectedEngraving);
		selectedType = new marbleMenuType(data.selectedType);
	}

	public static void Copy(MarbleRuntimeSettings Source, ref MarbleRuntimeSettings Target)
	{
		Target = new MarbleRuntimeSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
