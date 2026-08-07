// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LaserMaterial
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LaserMaterial : Form
{
  public List<buNestingPart> Parts;
  public List<Entity> SendToCadEntities;
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal DataGridView \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal TextBox \u0001;
  internal Label \u0002;
  internal TextBox \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal TabPage \u0002;
  internal Label \u0003;
  internal TextBox \u0003;
  internal Label \u0004;
  internal TextBox \u0004;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal Button \u000E;
  internal Button \u000F;
  internal DataGridView \u0002;
  internal ContextMenuStrip \u0002;
  internal ToolStripMenuItem \u0004;
  internal ToolStripMenuItem \u0005;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0006;
  internal ToolStripMenuItem \u0007;
  internal ToolStripMenuItem \u0008;
  internal ToolStripMenuItem \u000E;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u000F;
  internal ToolStripSeparator \u0004;
  internal ToolStripMenuItem \u0010;
  internal ToolStripMenuItem \u0011;
  internal Button \u0010;
  internal Button \u0011;
  internal Button \u0012;
  internal Button \u0013;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal ToolStripSeparator \u0005;
  internal ToolStripMenuItem \u0012;
  public CheckBox chk_preview;
  internal ToolStripSeparator \u0006;
  internal ToolStripMenuItem \u0013;
  internal Label \u0005;
  internal Label \u0006;
  internal Panel \u0004;
  internal NumericUpDown \u0001;
  internal Label \u0007;
  internal ToolStripMenuItem \u0014;
  internal ToolStripMenuItem \u0015;
  internal ToolStripSeparator \u0007;
  internal ToolStripMenuItem \u0016;
  public static byte f000E0B;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public int SelectedIndex;
  public int DiskIndex;
  private System.Windows.Forms.Timer \u0001;
  internal IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_importsolid;
  public TreeView tree_jobs;
  public buSpin buSpin2;
  public buSpin buSpin1;
  public buSpin buSpin4;
  public buSpin buSpin3;
  internal buGroup \u0001;
  public buSpin buSpin5;
  public buSpin buSpin7;
  public buSpin buSpin9;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_NestPartAddV2) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAddV2) this).\u0001.SelectedIndex <= ((SortOptions) ((F_NestOnlineCalc) this).Material).Points.Count - 1))
      return;
    ((SortOptions) ((F_NestOnlineCalc) this).Material).Points.RemoveAt(((F_NestPartAddV2) this).\u0001.SelectedIndex);
    ((F_NestPartAddV2) this).\u0001.Items.RemoveAt(((F_NestPartAddV2) this).\u0001.SelectedIndex);
    \u0007.\u0001.\u0001((F_Material) this);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_NestOnlineCalc) this).\u0001.SelectedIndex == 0)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes = MaterialShapes.Rectangle;
    if (((F_NestOnlineCalc) this).\u0001.SelectedIndex == 1)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes = MaterialShapes.Circle;
    if (((F_NestOnlineCalc) this).\u0001.SelectedIndex == 2)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes = MaterialShapes.Ellipse;
    if (((F_NestOnlineCalc) this).\u0001.SelectedIndex == 3)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes = MaterialShapes.Irregular;
    if (((F_NestOnlineCalc) this).\u0001.SelectedIndex == 4)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes = MaterialShapes.FromFile;
    \u0007.\u0001.\u0001((F_Material) this);
    \u0007.\u0001.\u0001((F_Material) this);
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (!((F_NestOnlineCalc) this).Properties.Inited)
      return;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0002.Name)
      ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Width = (double) ((F_NestOnlineCalc) this).\u0002.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0001.Name)
      ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Height = (double) ((F_NestOnlineCalc) this).\u0001.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0005.Name)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).MajorRadius = (double) ((F_NestOnlineCalc) this).\u0005.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0004.Name)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).MinorRadius = (double) ((F_NestOnlineCalc) this).\u0004.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0003.Name)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Radius = (double) ((F_NestOnlineCalc) this).\u0003.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0007.Name)
      ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Depth = (double) ((F_NestOnlineCalc) this).\u0007.Value;
    if (control2.Name == ((F_NestOnlineCalc) this).\u0006.Name)
      ((SortAskMe) ((F_NestOnlineCalc) this).Material).Angle = (double) ((F_NestOnlineCalc) this).\u0006.Value;
    \u0007.\u0001.\u0001((F_Material) this);
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    ColorDialogBox.ShowDialog(((F_NestPartAddV2) this).\u0001.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    ((F_NestPartAddV2) this).\u0001.BackColor = ColorDialogBox.Color;
    ((F_NestPartAddV2) this).\u0001.ForeColor = buFile5.InvertColorNoGray(((F_NestPartAddV2) this).\u0001.BackColor);
    ((F_NestPartAddV2) this).\u0001.Text = buFile5.GetColorKnownName(((F_NestPartAddV2) this).\u0001.BackColor);
    ((SortOptions) ((F_NestOnlineCalc) this).Material).Display.SkinColor = ColorDialogBox.Color;
    \u0007.\u0001.\u0001((F_Material) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestOnlineCalc) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestOnlineCalc) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_LaserMaterial() => F_NestOnlineCalc.Captions = new List<string>();

  public F_LaserMaterial()
  {
    ((F_NestPartAddV2) this).PropertiesForm = new FormProperties();
    ((F_NestPartAddV2) this).viewport = (Design) null;
    ((F_NestPartAddV2) this).Layers = new List<LayerBase5>();
    ((F_NestPartAddV2) this).NestingResultSettings = (buNestingResultSettings) new ProfileOperationDataRectangle();
    ((F_NestPartAddV2) this).RunParameter = (buNestingRuntime) new ProfileOperationDataBarel();
    ((F_NestPartAddV2) this).pathSaveImage = Application.StartupPath;
    ((F_NestPartAddV2) this).strSheetName = "Sheet";
    ((F_NestPartAddV2) this).DrawFatBorderAtPreview = false;
    ((F_NestPartAddV2) this).NestParameters = (buNestingVar) new ProfileOperationDataBarel();
    ((F_PanelCutNestSheetPartList) this).\u0001 = -1;
    ((F_PanelCutNestSheetPartList) this).\u0002 = -1;
    ((F_PanelCutNestSheetPartList) this).\u0001 = "";
    ((F_PanelCutNestSheetPartList) this).\u0001 = false;
    ((F_PanelCutNestSheetPartList) this).\u0001 = (buNestedResult) null;
    ((F_PanelCutNestSheetPartList) this).\u0001 = (buNestedSheet) null;
    ((F_PanelCutNestSheetPartList) this).\u0001 = (TreeNode) null;
    ((F_PanelCutNestSheetPartList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestedResults) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_Creat(CreatbuNestedResultEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CreatbuNestedResultEventHandler resultEventHandler = ((F_NestPartAddV2) this).\u0001;
    CreatbuNestedResultEventHandler comparand;
    do
    {
      comparand = resultEventHandler;
      // ISSUE: reference to a compiler-generated field
      resultEventHandler = Interlocked.CompareExchange<CreatbuNestedResultEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand + value, comparand);
    }
    while (resultEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_Creat(CreatbuNestedResultEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CreatbuNestedResultEventHandler resultEventHandler = ((F_NestPartAddV2) this).\u0001;
    CreatbuNestedResultEventHandler comparand;
    do
    {
      comparand = resultEventHandler;
      // ISSUE: reference to a compiler-generated field
      resultEventHandler = Interlocked.CompareExchange<CreatbuNestedResultEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand - value, comparand);
    }
    while (resultEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DrawResult(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
