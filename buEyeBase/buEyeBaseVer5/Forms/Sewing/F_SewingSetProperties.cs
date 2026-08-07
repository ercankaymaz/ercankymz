// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingSetProperties
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.RollerBend;
using buEyeBaseVer5.Forms.Shape;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingSetProperties : Form
{
  internal ImageList \u0004;
  internal ImageList \u0005;
  internal ImageList \u0006;
  internal Button \u0003;
  internal CheckBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  public ListBox lst_info;
  public static byte f001330;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_SewingExtend) this).PropertiesForm.Inited)
      return;
    if (control.Name == this.\u0001.Name && ((F_SewingPunteriz) this).selectedShape is buShapeHole)
    {
      buShapeHole selectedShape = ((F_SewingPunteriz) this).selectedShape as buShapeHole;
      ((DiemakerGrindingShapeSettings) selectedShape).isMilling = this.\u0001.Checked;
      ((F_SewingPunteriz) this).parShape.isMillingHole = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      ((F_SewingStitchLen) this).ShapeToDataGrid(((F_SewingPunteriz) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_SewingMove) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_SewingPunteriz) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
      }
    }
    ((F_SewingExtend) this).PropertiesForm.Inited = false;
    ((F_SewingStitchLen) this).Apply();
    ((F_SewingExtend) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001(obj0, (EventArgs) null, (F_DrillList) this);
  }

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_SewingExtend) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = 0;
    ((F_SewingStitchLen) this).ShapeToDataGrid(obj1.ItemIndex);
    ((F_SewingPunteriz) this).\u0001 = obj1.ItemIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_SewingMove) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_SewingPunteriz) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SewingPunteriz) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SewingPunteriz) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingSetProperties() => F_SewingExtend.Captions = new List<string>();

  public F_SewingSetProperties()
  {
    ((F_RollerTable) this).PropertiesForm = new FormProperties();
    ((F_RollerTable) this).ShowViewport = true;
    ((F_RollerTable) this).ShowCamSettings = true;
    ((F_RollerTable) this).ShowTool = false;
    ((F_RollerTable) this).ShowObjectPosition = true;
    ((F_RollerTable) this).ShowCornerLocation = true;
    ((F_RollerRectangle) this).EnableTopPlane = true;
    ((F_RollerRectangle) this).EnableBottomPlane = true;
    ((F_RollerRectangle) this).EnableLeftPlane = true;
    ((F_RollerRectangle) this).EnableRightPlane = true;
    ((F_RollerRectangle) this).EnableFrontPlane = true;
    ((F_RollerRectangle) this).EnableBacktPlane = true;
    ((F_RollerRectangle) this).ClosePageAfterOk = false;
    ((F_RollerRectangle) this).Tools = new List<ToolBase5>();
    ((F_RollerRectangle) this).activeTool = (ToolBase5) null;
    ((F_RollerRectangle) this).selectedShape = (buShape) null;
    ((F_RollerRectangle) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_RollerRectangle) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_RollerRectangle) this).\u0001 = -1;
    ((F_RollerRectangle) this).\u0001 = false;
    ((F_RollerRectangle) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeList) this);
    ((F_RollerRectangle) this).\u0001.Interval = 100;
    ((F_RollerRectangle) this).\u0001.Tick += new EventHandler(((F_RollerTable) this).\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RollerTable) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RollerTable) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RollerTable) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RollerTable) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
