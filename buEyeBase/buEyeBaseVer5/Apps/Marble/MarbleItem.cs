// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItem : buSerilization5
{
  public static string strRoundRect;
  public static string strSlot;
  public static string strNotch;
  public static string strFreeDraw;
  public static string strText;
  public static string strCut;
  public static string strPoylgon;
  public static string LayerNameProfile;
  public static string LayerNameOperation;
  public static string LayerNameCam;
  public static string LayerNameContour;
  public static string LastCreatedProfileEntityName;
  public static int LastCreatedProfileEntityIndex;
  public static bool OperationEditing;
  public static bool MultiOperationStarted;
  public static bool ClamperMoved;
  public static double TemplateXOffset;
  public static bool TemplateScaleUseX;
  public static bool TemplateScaleUseYZ;
  public static double TemplateXScaleRatio;
  public static double TemplateYZScaleRatio;
  public static int MainBottomTabIndex;
  public static double PlaneIncrement;
  public static int PlaneSelectedIndex;
  public static bool PlaneInited;
  public static bool DepthInited;
  public static bool TemplateMode;
  public static bool CamAssinged;
  public static bool DepthForced;
  public static int DepthSelectedIndex;
  public static bool RotateKeyKole;
  public static bool ChangeCamDir;
  public static Pnt6DSimMove P6SimMachine;
  public static Pnt6D P6SimTool;
  public static Point3D P3SimTool;
  public static Point3D PntPatternDxf;
  public static OrientationAngle PAngleSimTool;
  public bool AutoToolFind;
  public bool ShowProgressCam;
  public bool MeasureActive;
  public bool DrawMouseDown;
  public static bool PatternDxfOperation;
  public buShape lastShape;
  public static ProfileOperation CreatingOperation;
  public Point3D pntMouseDown;
  public ViewportRefType ViewportRef;
  public planeBoxNames activePlane;
  public ProfileJobType JobItemType;
  public int selectedProfileIndex;
  public int selectedItemIndex;

  public abstract void m001E68();

  public MarbleItem()
  {
    ((NestingPanelNode) this).TextWidth = 0.0;
    ((NestingPanelNode) this).TextHeight = 0.0;
    ((NestingPanelNode) this).TextAngle = 0.0;
    ((NestingPanelNode) this).TextString = "";
    ((NestingPanelNode) this).CharSpace = 1.0;
    ((NestingPanelNode) this).SpaceValue = 2.0;
    ((NestingPanelNode) this).isWire = false;
    ((NestingPanelNode) this).TextFont = new Font("Arial", 12f);
    ((PanelCutSettings) this).TextScaleCenter = ProfileScaleCenterType.Center;
    ((PanelCutSettings) this).TextAlignment = ContentAlignment.MiddleCenter;
    ((PanelCutSettings) this).TextColor = Color.Blue;
    ((PanelCutSettings) this).TextThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleItem(ProfileOperationDataText data)
  {
    ((NestingPanelNode) this).TextWidth = 0.0;
    ((NestingPanelNode) this).TextHeight = 0.0;
    ((NestingPanelNode) this).TextAngle = 0.0;
    ((NestingPanelNode) this).TextString = "";
    ((NestingPanelNode) this).CharSpace = 1.0;
    ((NestingPanelNode) this).SpaceValue = 2.0;
    ((NestingPanelNode) this).isWire = false;
    ((NestingPanelNode) this).TextFont = new Font("Arial", 12f);
    ((PanelCutSettings) this).TextScaleCenter = ProfileScaleCenterType.Center;
    ((PanelCutSettings) this).TextAlignment = ContentAlignment.MiddleCenter;
    ((PanelCutSettings) this).TextColor = Color.Blue;
    ((PanelCutSettings) this).TextThickness = 1.0;
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
    return $"{((NestingPanelNode) this).TextString} - Width : {((NestingPanelNode) this).TextWidth.ToString()} - TextHeight : {((NestingPanelNode) this).TextHeight.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataText P, string Char, int Space)
  {
    string str = "ProfileOperationDataTextPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + MarbleItem.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataText P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataTextPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + MarbleItem.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataTextPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataText P)
  {
    return buSerilization5.ClassToString((object) P);
  }
}
