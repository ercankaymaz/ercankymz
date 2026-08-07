// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleRuntimeSettings : buSerilization5
{
  public bool IncrementalMode;
  public bool FromFileKeepRatio;
  public bool HideClampers;
  public bool HideMachine;
  public bool HideMachineBody;
  public bool HideCam;
  public bool HideContour;
  public bool HideSupport;
  public bool HideProfile;
  public bool HideOperations;
  public int activeProfileIndex;
  public int activeOPIndex;
  public string activeOPName;
  public int activeCalcDataIndex;
  public bool ProfileKeepRatio;
  public bool GhostClamper;
  public bool CollisionDetect;
  public bool CopyMoveUseOriginalePlane;
  public int CopyCount;
  public double CopyDistanceHor;
  public double CopyDistanceVer;
  public bool CopyUseDistance;
  public double LeftAngle;
  public double RigthAngle;
  public string path3DJob;
  public string pathEngraving;
  public string lastToolName;
  public bool EngravingKeepRatio;
  public string RecentSaveFile1;
  public string RecentSaveFile2;
  public string RecentSaveFile3;
  public string RecentSaveFile4;
  public string RecentSaveFile5;
  public string RecentSaveFile6;
  public string RecentOpenFile1;
  public string RecentOpenFile2;
  public string RecentOpenFile3;
  public string RecentOpenFile4;
  public string RecentOpenFile5;
  public string RecentOpenFile6;
  public List<string> Transformations;
  public static byte f00471B;
  public double LeftMinDis;
  public double LeftMaxDis;
  public double LeftMinClamperPos;
  public double LeftMaxClamperPos;
  public double RightMinDis;
  public double RightMaxDis;
  public double RightMinClamperPos;
  public double RightMaxClamperPos;
  public bool OperationAboveClamper;
  public static byte f004725;
  public double SmallChangeGap;
  public double BigChangeGap;
  public double LeftDistance;
  public double RightDistance;
  public bool UseBig;
  public static byte f00472B;
  public double LeftDistance;
  public double RightDistance;
  public int IndexOpertion;
  public bool UseTopPlane;
  public double ClamperWidth;
  public static byte f004731;
  public double Depth;
  public double TopPosition;
  public double BottomPosition;
  public double SpindleSpeed;
  public double PlungeFeed;
  public bool PeckingUp;
  public double PeckingUpDistance;
  public double Wait;
  public static byte f00473A;
  public double MinThickness;
  public double MaxThickness;
  public bool AreaCalculation;
  public int AreaStep;
  public double ConnectGap;
  public static byte f004740;
  public bool CircularEnable;
  public int CircularCount;
  public double CircularAngle;
  public bool LineerEnable;
  public int LineerXCount;
  public double LineerXDistance;
  public int LineerYCount;
  public double LineerYDistance;
  public static byte f004749;
  public bool MirrorEnable;
  public MirrorAxisXYType MirrorAxis;
  public MinCenterMaxType MirrorLocation;
  public double MirrorDistance;
  public MirrorModeType Mode;
  public static byte f00474F;
  public double Distance;
  public double CutSpace;
  public int Count;
  public static byte f004753;
  public bool OnlyDrawing;
  public bool AutoToolFound;
  public string ToolAuxName;
  public static byte f004757;
  public double ToolBaseLength;
  public bool checkToolLength;
  public static byte f00475A;
  public double Length;
  public double NeededWidth;
  public double NeededHeight;
  public double SupportBlockZWidth;
  public double SupportBlockZHeight;
  public double SupportBlockY1Width;
  public double SupportBlockY1Height;
  public double SupportBlockY2Width;
  public double SupportBlockY2Height;
  public bool ConnectSmallGap;
  public double GapConnection;
  public double SortResolituon;
  public double MinPointFilterLength;
  public SortingIntersectionRulesType IntersectionRules;
  public SortingNextGroupFindRulesType NextFroupRules;
  public int MaxClamper;
  public int Transparency;
  public Color color;
  public string FileName;
  public string FullName;
  public string Name;
  public static byte f004770;
  public bool UpdateRuntime;
  public bool Finished;
  public string ToolName;
  public int ToolIndex;
  public static byte f004775;
  [SpecialName]
  public int value__;
  public const profileSortSequenceAtSamePosition FrontTopBack = ; // Unable to render the field
  public const profileSortSequenceAtSamePosition BackTopFront = ; // Unable to render the field
  public static byte f004779;
  public Point3D Position;
  public double MaterialLength;
  public double XPosition;
  public Rectangle2D Panel;
  public List<Line2D> CutLines;
  public List<Rectangle2D> SawCutRectangles;
  public bool FinalProduct;
  public int Index;
  public int NodeID;
  public int PartID;
  public nestPanelNodeType NodeType;
  public PanelCutMoveCommand Command;
  public bool isActive;
  public static byte f004787;
  public int Depth;
  public int XIndex;
  public int YIndex;
  public string Note;
  public int NodeID;
  public nestPanelNodeType NodeType;
  public static byte f00478E;
  public Rectangle2D Panel;
  public int PartID;
  public int Count;
  public string Name;
  public static byte f004793;
  public Rectangle2D Panel;
  public int NodeID;
  public int Count;
  public string Name;
  public static byte f004798;
  public List<NestingPanel> Panels;
  public List<buNestingPart> usedParts;
  public List<Rectangle2D> Parts;
  public List<Rectangle2D> Sheets;
  public List<PanelCutMove> SimulationMoves;
  public List<string> SimulationCodes;
  public List<buEntity> MovingEntities;
  public List<PanelWaitAssembly> WaitingAssembly;
  public List<PanelDonePart> DoneParts;
  public List<NestingPanelNode> Nodes;
  public List<Rectangle2D> CalculatedRectangles;
  public List<string> PanelCodes;
  public int Count;
  public int PartCount;
  public double PanelArea;
  public double PartsArea;
  public double TotalCutLength;
  public double Waste;
  public double Width;
  public double Height;
  public double Depth;
  public string Explanation;
  public string Material;
  public static byte f0047B0;
  public Point3D LowerLeft;
  public DirectionXandY Direction;
  public nestPanelNodeType NodeType;
  public int NodeID;
  public int XQuantity;
  public int YQuantity;
  public int Depth;
  public double DimensionX;
  public double DimensionY;
  public Point3D SubNodeLowerLeft;
  public Rectangle2D BaseRectangle;
  public Rectangle2D Rectangle;
  public Line2D CutLine;
  public double CutOffset;
  public double CutFeedDistance;
  public double CutSawDistance;
  public int PartID;
  public int ID;
  public List<NestingPanelNode> Node;
  public List<PanelCutMove> SimMoves;
  public static byte f0047C5;
  public int simulationInterval;
  public double SawThickness;
  public int NestingExecuteTimeSec;
  public bool ShowOperationButton;
  public double CutSimDevideLen;
  public int CutSawZMoveCount;
  public int MaxOptimisationDepth;
  public double PanelThickness;
  public double PanelMaxThickness;
  public double GeneralTrimWidth;
  public double GeneralTrimHeight;
  public bool CollisionCheck;
  public bool StepRun;
  public int SimStep;
  public bool simRelease;
  public int acliveLine;
  public int OffcutCount;
  public string layerPanel;
  public string layerOperation;
  public string layerGeneral;
  public string layerSelected;
  public string layerCam;
  public static byte f0047DC;
  [SpecialName]
  public int value__;
  public const PanelCutMoveCommand AxisMove = ; // Unable to render the field
  public const PanelCutMoveCommand SawUp = ; // Unable to render the field
  public const PanelCutMoveCommand SawDown = ; // Unable to render the field
  public const PanelCutMoveCommand Finished = ; // Unable to render the field
  public const PanelCutMoveCommand ClamperOn = ; // Unable to render the field
  public const PanelCutMoveCommand ClamperOff = ; // Unable to render the field
  public const PanelCutMoveCommand SideReclaimOn = ; // Unable to render the field
  public const PanelCutMoveCommand SideReclaimOff = ; // Unable to render the field
  public const PanelCutMoveCommand FrontReclaimOn = ; // Unable to render the field
  public const PanelCutMoveCommand FrontReclaimOff = ; // Unable to render the field
  public const PanelCutMoveCommand CutMaterial = ; // Unable to render the field
  public const PanelCutMoveCommand AddMaterial = ; // Unable to render the field
  public const PanelCutMoveCommand RemoveMaterial = ; // Unable to render the field
  public const PanelCutMoveCommand PartFinished = ; // Unable to render the field
  private string \u0001;
  public static MarbleItemSettings varOperation;
  public static MarbleMachineSettings varMarbleMachineSettings;
  public static MarbleProgramSettings varMarbleSettings;
  public static MarbleRuntimeSettings varMarbleRunSettings;

  public MarbleRuntimeSettings(ProfileSupportBlock data)
  {
    ((MarbleJob) this).SupportBlockEnable = false;
    ((MarbleJob) this).SupportBlockZWidth = 0.0;
    ((MarbleJob) this).SupportBlockZHeight = 0.0;
    ((MarbleJob) this).SupportBlockZLength = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontWidth = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontHeight = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontLength = 0.0;
    ((MarbleJob) this).SupportBlockY2BackWidth = 0.0;
    ((MarbleJob) this).SupportBlockY2BackHeight = 0.0;
    ((MarbleJob) this).SupportBlockY2BackLength = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public MarbleRuntimeSettings()
  {
    ((MarbleJob) this).ProfileMultiplyEnable = false;
    ((MarbleJob) this).ProfileMultiplyMirror = false;
    ((MarbleJob) this).ProfileMultiplySpace = 0.0;
    ((MarbleJob) this).ProfileMultiplyCount = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleRuntimeSettings(ProfileMultiply data)
  {
    ((MarbleJob) this).ProfileMultiplyEnable = false;
    ((MarbleJob) this).ProfileMultiplyMirror = false;
    ((MarbleJob) this).ProfileMultiplySpace = 0.0;
    ((MarbleJob) this).ProfileMultiplyCount = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Enable: {((MarbleJob) this).ProfileMultiplyEnable.ToString()} , Cnt: {((MarbleJob) this).ProfileMultiplyCount.ToString()} , Mirror: {((MarbleJob) this).ProfileMultiplyMirror.ToString()} , Space: {((MarbleJob) this).ProfileMultiplySpace.ToString()}";
  }
}
