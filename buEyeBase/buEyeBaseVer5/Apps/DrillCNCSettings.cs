// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillCNCSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillCNCSettings : buSerilization5
{
  public double BlockHeight;
  public double BlockIdealWidth;
  public double BlockIdealHeight;
  public double PatternWidth;
  public double PatternHeight;
  public double PatternOrjWidth;
  public double PatternOrjHeight;
  public double PatternWidthStartOffset;
  public double PatternWidthEndOffset;
  public double PatternHeightStartOffset;
  public double PatternHeightEndOffset;
  public bool PatternMirrorX;
  public bool PatternMirrorY;
  public bool DrawBorder;
  public bool WaveReverse;
  public bool WaveUpDownDirection;
  public bool SemiAutoSelection;
  public bool ShowVirtualDrawings;
  public double MaterialWidth;
  public double MaterialHeight;
  public double MaterialDepth;
  public FoamPlaneType planeNames;
  public FoamType TypeFoam;
  public FoamOperationType Operation;
  public string pathFoamPattern;
  public string pathFoamJob;
  public string pathConverter;
  public int SimStep;
  public static byte f003E0D;
  public double BlockTrimedHeight;
  public double BlockTrimedWidth;
  public double PatternHeight;
  public double PatternWidth;
  public double XOffset;
  public double YOffset;
  public double ZOffset;
  public double XRatio;
  public double YRatio;
  public double XMax;
  public double YMax;
  public int XCountActual;
  public int YCountActual;
  public double BlockIdealWidth;
  public double BlockIdealHeight;
  public bool isVertical;
  public double MaterialWidth;
  public double MaterialHeight;
  public double MaterialDepth;
  public FoamPlaneType planeNames;
  public FoamType TypeFoam;
  public FoamOperationType Operation;
  public bool ShowRightVirtualDrawing;
  public bool ShowBottomVirtualDrawing;
  public bool ShowBottomRightVirtualDrawing;
  public double RigthVirtualDrawingDistance;
  public double BottomVirtualDrawingDistance;
  public Color VirtualColor;
  public bool isReverse;
  public bool NotCatchFound;
  public Point3D pntLastSelected;
  public string LayerGeneral;
  public string LayerFoam;
  public string Layer3DPattern;
  public string LayerWirePattern;
  public string LayerSelection;
  public string LayerMark;
  public string LayerDefault;
  public static byte f003E34;
  public double StartWidthOffset;
  public double ZPos;
  public double Height;
  public double Width;
  public double BaseHeight;
  public int WaveCount;
  public int RepeatCount;
  public double ZOffset;
  public FoamPlaneType refPlane;
  public SizeObject Size;
  public double CuttingSpeed;
  public double RoundRadius;
  public double ChamferLen;
  public double PatternWidth;
  public double PatternHeight;
  public double ZOffset;
  public double OutLimitMaxAngle;
  public double OutLimitMinAngle;
  public double MaxAngle;
  public double MinAngle;
  public bool UpdateRuntime;
  public bool Finished;
  public bool FitToLength;
  public double PatternSpaceWidth;
  public double PatternSpaceHeight;
  public string Command;
  public static byte f003E4F;
  public static List<string> LangSewingStatus;
  public static List<string> LangSewingMessage;
  public static List<string> LangSewingCaptions;
  public static List<string> LangSewingCommands;
  public static List<string> LangSewingMainForm;
  public static string UnlockString;
  public static byte f003E56;
  public List<buEntity> MainEntityList;
  public SimulationTp SimilationPoint;
  public bool isSorted;
  public double StitchLen;
  public bool isStitch;
  public int indexEntity;
  public int indexVertex;
  public entitySortDirection SortDir;
  public SewingDrawType DrawType;
  public SewingPunteriz Punteriz;
  public double PointThickness;
  public Color PointColor;
  public string PointLayerName;
  public double DrawigThickness;
  public Color DrawingColor;
  public string DrawingLayerName;
  public int StartIndex;
  public int EndIndex;
  public bool ProtectEntityStitchLen;
  public bool ApplyNewLenUpToEnd;
  public static byte f003E6B;
  public OffsetCornerType CornerTyppe;
  public CamClosedContourType ClosedType;
  public CamOpenContourType OpenType;
  public bool MakeSameStartOffsetYLevel;
  public bool MakeSameEndOffsetYLevel;
  public int EntityIndex;
  public int VertexIndex;
  public SewingPickClickType PickType;
  public SewingPickEntitySelectType EntitySelectType;
  public Point3D refPoint;
  public static byte f003E76;
  public int No;
  public string Defination;
  public static byte f003E79;
  public Point3D refPoint;
  public int VertexIndex;
  public int EntityIndex;
  public StartMiddleEndType CatchPosition;
  public bool isStitch;
  public static byte f003E7F;
  public static SewingDrawCommand DrawCommand;
  public static SewingDrawType DrawType;
  public double defaultStitchLength;
  public MoveVertexType VertexMoveType;
  public string layerNameGeneral;
  public string layerNameOriginal;
  public string layerNameDrawing;
  public string layerNamePoint;
  public string layerNameDrawingPoints;
  public string layerNameDrawingDevided;
  public double CatchResolution;
  public Color colorGeneral;
  public Color colorOriginalDrawing;
  public Color colorDrawing;
  public Color colorPoints;
  public Color colorDrawingPoints;
  public Color colorDrawingDevided;
  public Color colorSimulation;
  public Color colorStitched;
  public Color colorJump;
  public Color colorLockStitch;
  public Color colorPunterez;
  public Color colorVertex;
  public Color colorNoStitch;
  public Color colorVertexHasCode;
  public double thicknessGeneral;
  public double thicknessStitched;
  public double thicknessJump;
  public double thicknessOriginalDrawing;
  public double thicknessDrawing;
  public double thicknessPoints;
  public double thicknessDrawingPoints;
  public double thicknessDrawingDevided;
  public int SimulationTransparency;
  public int SimulationTick;
  public int SimulationStep;
  public bool SimulationSolid;
  public bool SimulationRotate;
  public bool DevideEntitiesAfterSort;
  public double thicknessVertex;
  public double thicknessNoStitch;
  public double thicknessVertexHasCode;
  public Point3D FoldingPostion1;
  public Point3D FoldingPostion2;
  public Point3D NeedlePostion;
  public static byte f003EAD;
  public string pathTeachFile;
  public double PunterizWidth;
  public double PunterizHeigth;
  public double PunterizLength;
  public double MoveDistance;
  public double RotateDegree;
  public double FootHeight;
  public double StitchLen;
  public double SewingOffset;
  public double SewingSpeed;
  public int LockStitcCount;
  public SewingAddStitchType LockStitchType;
  public SewingPunterizType PunterizType;
  public LeftRightType OffsetType;
  public SortingNextGroupFindRulesType NextRules;
  public bool ShowDialog;
  public Point3D pntStart;
  public double PositionX;
  public double PositionY;
  public double PositionA;
  public double StitchStep;
  public double HeadSpeed;
  public double FootHeight;
  public bool StitchedWay;
  public int StitchCount;
  public int Style;
  public int Code0;
  public int Code1;
  public int Code2;
  public int Code3;
  public int Code4;
  public int Code5;
  public static byte f003ECE;
  [SpecialName]
  public int value__;
  public const MoveVertexType MoveCorner = ; // Unable to render the field
  public const MoveVertexType MoveOnlyVertex = ; // Unable to render the field
  public static List<string> LangQuiltingStatus;
  public static List<string> LangQuiltingMessage;
  public static List<string> LangQuiltingCaptions;
  public static List<string> LangQuiltingCommand;
  public SortSettings QuiltSortSettings;
  public quiltingHeadType Heads;
  public static byte f003ED8;
  public double CornerAngle;
  public bool SharpCornerEnable;
  public bool DevideOnlyLines;
  public double DevideLength;

  public string SequenceToExplanation(FoamSequenceHor Seq)
  {
    string explanation = "";
    if (Seq == FoamSequenceHor.HorizontalStartThenEnd)
      explanation = "Horizontal Sequence Start Then End";
    if (Seq == FoamSequenceHor.HorizontalStartThenStart)
      explanation = "Horizontal Sequence Start Then Start";
    if (Seq == FoamSequenceHor.HorizontalStartThenStartDirect)
      explanation = "Horizontal Sequence Start Then Start Direct";
    return explanation;
  }

  public string SequenceToExplanation(FoamSequenceVer Seq)
  {
    string explanation = "";
    if (Seq == FoamSequenceVer.VerticalStartThenEnd)
      explanation = "Vertical Sequence Start Then End";
    if (Seq == FoamSequenceVer.VerticalStartThenStart)
      explanation = "Vertical Sequence Start Then Start";
    if (Seq == FoamSequenceVer.VerticalStartThenStartDirect)
      explanation = "Vertical Sequence Start Then Start Direct";
    return explanation;
  }
}
