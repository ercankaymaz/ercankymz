// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItemSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemSettings : buSerilization5
{
  public bool ToolSpeedDataToOperationSpeedData;
  public bool ToolDistanceDataToOperationDistanceData;
  public bool AutoCloseWater;
  public bool DontAddLineFromExternalFile;
  public bool ClamperCanMoveInsideProfileLength;
  public bool MultipleEdit;
  public ProfilePositionCalculationMode ProfilePositionCalculation;
  public ProfileSafeDistanceMode ProfileSafeDistanceForPlanes;
  public ProfileOutSizeClamperMode ProfileOutsizeClamperMode;
  public ProfileOperationWindowType OperationWindow;
  public ProfileOperationWindowCloseType OperationWindowClose;
  public GoFirstPositionType GoFirstPositionMode;
  public ToolFindType FindToolType;
  public ProfileYAxisDirection YDirection;
  public ProfileXAxisDirection XDirection;
  public LeftRightType XDirRefType;
  public bool ShowCabinet;
  public buViewTypeBasic PreviewViewType;
  public bool ShowPreviewSides;
  public bool ShowOperationButton;
  public Color PreviewSideColor;
  public Color PreviewDoneOperationColor;
  public Color PreviewActiveOperationColor;

  public MarbleItemSettings(double XPosition)
  {
    ((PanelCutMoveCommand) this).XPosition = 0.0;
    ((buMarbleCalc) this).GeometrixMaxX = 0.0;
    ((buMarbleCalc) this).GeometrixMinX = 0.0;
    ((buMarbleCalc) this).XOffset = 0.0;
    ((buMarbleCalc) this).Width = 100.0;
    ((buMarbleCalc) this).Text = "";
    ((buMarbleCalc) this).MaxPositionRange = 10000.0;
    ((buMarbleCalc) this).MinPositionRange = 0.0;
    ((buMarbleCalc) this).Used = false;
    ((buMarbleCalc) this).Enable = true;
    ((buMarbleCalc) this).isCollision = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((PanelCutMoveCommand) this).XPosition = XPosition;
  }

  public MarbleItemSettings(bool used, bool enable, double width)
  {
    ((PanelCutMoveCommand) this).XPosition = 0.0;
    ((buMarbleCalc) this).GeometrixMaxX = 0.0;
    ((buMarbleCalc) this).GeometrixMinX = 0.0;
    ((buMarbleCalc) this).XOffset = 0.0;
    ((buMarbleCalc) this).Width = 100.0;
    ((buMarbleCalc) this).Text = "";
    ((buMarbleCalc) this).MaxPositionRange = 10000.0;
    ((buMarbleCalc) this).MinPositionRange = 0.0;
    ((buMarbleCalc) this).Used = false;
    ((buMarbleCalc) this).Enable = true;
    ((buMarbleCalc) this).isCollision = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((buMarbleCalc) this).Used = used;
    ((buMarbleCalc) this).Enable = enable;
    ((buMarbleCalc) this).Width = width;
  }

  public MarbleItemSettings(double xPos, bool used, bool enable, double width)
  {
    ((PanelCutMoveCommand) this).XPosition = 0.0;
    ((buMarbleCalc) this).GeometrixMaxX = 0.0;
    ((buMarbleCalc) this).GeometrixMinX = 0.0;
    ((buMarbleCalc) this).XOffset = 0.0;
    ((buMarbleCalc) this).Width = 100.0;
    ((buMarbleCalc) this).Text = "";
    ((buMarbleCalc) this).MaxPositionRange = 10000.0;
    ((buMarbleCalc) this).MinPositionRange = 0.0;
    ((buMarbleCalc) this).Used = false;
    ((buMarbleCalc) this).Enable = true;
    ((buMarbleCalc) this).isCollision = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((PanelCutMoveCommand) this).XPosition = xPos;
    ((buMarbleCalc) this).Used = used;
    ((buMarbleCalc) this).Enable = enable;
    ((buMarbleCalc) this).Width = width;
    ((buMarbleCalc) this).GeometrixMaxX = ((PanelCutMoveCommand) this).XPosition + ((buMarbleCalc) this).Width / 2.0;
    ((buMarbleCalc) this).GeometrixMinX = ((PanelCutMoveCommand) this).XPosition - ((buMarbleCalc) this).Width / 2.0;
  }

  public MarbleItemSettings(ProfileClamper data)
  {
    ((PanelCutMoveCommand) this).XPosition = 0.0;
    ((buMarbleCalc) this).GeometrixMaxX = 0.0;
    ((buMarbleCalc) this).GeometrixMinX = 0.0;
    ((buMarbleCalc) this).XOffset = 0.0;
    ((buMarbleCalc) this).Width = 100.0;
    ((buMarbleCalc) this).Text = "";
    ((buMarbleCalc) this).MaxPositionRange = 10000.0;
    ((buMarbleCalc) this).MinPositionRange = 0.0;
    ((buMarbleCalc) this).Used = false;
    ((buMarbleCalc) this).Enable = true;
    ((buMarbleCalc) this).isCollision = false;
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
}
