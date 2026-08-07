// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.RollerBend.F_RollerMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Profile;
using buEyeBaseVer5.Forms.Sewing;
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
namespace buEyeBaseVer5.Forms.RollerBend;

public class F_RollerMenu : Form
{
  internal ListView \u0001;
  internal ImageList \u0002;
  internal DataGridView \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  public Button btn_front;
  internal Label \u0004;
  public Button btn_back;
  internal Label \u0005;
  public Button btn_right;
  internal Label \u0006;
  public Button btn_left;
  public Button btn_top;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_RollerTable) this).PropertiesForm.Inited)
      return;
    ((F_RollerTable) this).PropertiesForm.Inited = false;
    if (control.Name == ((F_RollerCircle) this).\u0001.Name && ((F_RollerRectangle) this).selectedShape != null)
    {
      buShape selectedShape = ((F_RollerRectangle) this).selectedShape;
      ((buClipperBase) selectedShape).isPocket = ((F_RollerCircle) this).\u0001.Checked;
      ((F_RollerRectangle) this).parShape.isShapePocket = ((buClipperBase) selectedShape).isPocket;
      ((camOperation5) ((buClipper) selectedShape).CamPar.Pockets).Enable = ((buClipperBase) selectedShape).isPocket;
      ((camOperation5) ((F_RollerRectangle) this).parShape.CamPars.Pockets).Enable = ((buClipperBase) selectedShape).isPocket;
      ((F_RollerRectangle) this).ShapeToDataGrid(((F_RollerRectangle) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_RollerRectangle) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) ((F_RollerRectangle) this).selectedShape, (object) Data2);
      }
    }
    ((F_RollerRectangle) this).Apply();
    ((F_RollerTable) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(obj0, (F_ShapeList) this, (EventArgs) null);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_RollerTable) this).PropertiesForm.Inited || !((F_RollerTable) this).ShowTool || !(((F_RollerCircle) this).cmb_tools.SelectedIndex >= 0 & ((F_RollerCircle) this).cmb_tools.SelectedIndex <= ((F_RollerRectangle) this).Tools.Count - 1))
      return;
    ((F_RollerRectangle) this).activeTool = (ToolBase5) new ToolGeometry5(((F_RollerRectangle) this).Tools[((F_RollerCircle) this).cmb_tools.SelectedIndex]);
  }

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_RollerTable) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((F_RollerRectangle) this).ShapeToDataGrid(obj1.ItemIndex);
    ((F_RollerRectangle) this).\u0001 = obj1.ItemIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_RollerTable) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_RollerRectangle) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_RollerTable) this).\u0001((object) ((F_RollerRectangle) this).selectedShape, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RollerRectangle) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RollerRectangle) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RollerMenu() => F_RollerTable.Captions = new List<string>();

  public F_RollerMenu()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).CodesDefined = new List<SewingCode>();
    ((F_Settnigs) this).Codes = new List<SewingCode>();
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingCodes) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_RotateCommad(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
