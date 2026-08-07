// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.Printer3D;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zen.Barcode;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buPoint : buEntity
{
  internal new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_BarCode) this);
    ((buShapeHole) this).PropertiesForm.Result = DialogResult.OK;
    if (((buShapeHole) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buShapeHole) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  internal new void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((buShapeHole) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buShapeHole) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buShapeHole) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    if (obj1.KeyCode != Keys.Return)
      return;
    ((buShapeHole3) this).\u0001.Image = BarcodeDrawFactory.Code128WithChecksum.Draw(((buShapeHoleMulti) this).\u0001.Text, 100);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buShapeHoleMulti) this).\u0001 != null ? 1 : 0)) != 0)
      ((buShapeHoleMulti) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buPoint() => buShapeHole.Captions = new List<string>();

  public buPoint()
  {
    ((buShapeHole3) this).PropertiesForm = new FormProperties();
    ((buShapeCut) this).Settings = (Printer3DSettings) new DrillMove();
    ((buShapeCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Printer3DSettings) this);
  }

  public new void Init()
  {
    ((buShapeHole3) this).PropertiesForm.Inited = false;
    if (((buShapeHole3) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((buShapeHole3) this).PropertiesForm.Height;
    if (((buShapeHole3) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((buShapeHole3) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((buShapeHole3) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((buShapeHole3) this).PropertiesForm.FormPosition;
    ((buLine) this).ControlUpdate();
    ((buLine) this).LoadLanguage();
    ((buShapeProfiling) this).\u0003.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).NozzleDiameter;
    ((buShapeProfiling) this).\u0002.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).OffsetXY;
    ((buShapeCut) this).\u0001.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).SliceCount;
    ((buShapeProfiling) this).\u0001.Checked = ((DrillJob) ((buShapeCut) this).Settings).InFill;
    ((buShapeEngrave) this).\u0002.Checked = ((DrillJob) ((buShapeCut) this).Settings).Simplify;
    ((buShapeNotch) this).\u0003.Checked = ((DrillJob) ((buShapeCut) this).Settings).ZSpiralMove;
    ((buShapeVisualition) this).\u0004.Checked = ((DrillJob) ((buShapeCut) this).Settings).UseSpline;
    ((buShapeJunction) this).\u0004.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).FeedSpeed;
    ((buShapeJunction) this).\u0005.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).PlungeSpeed;
    ((buShapeText) this).\u0007.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).TopHeight;
    ((buShapeText) this).\u0006.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).SliceStep;
    ((buShapeNotch) this).\u0008.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).FilletRadius;
    ((buShapeNotch) this).\u000F.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).FilletLimitMinAngle;
    ((buShapeNotch) this).\u000E.Value = (Decimal) ((DrillJob) ((buShapeCut) this).Settings).FilletLimitMaxAngle;
    if (((DrillJob) ((buShapeCut) this).Settings).SliceType == Printer3DSliceType.Count)
      ((buShapeJunction) this).\u0001.Checked = true;
    else
      ((buShapeJunction) this).\u0002.Checked = true;
    if (((DrillJob) ((buShapeCut) this).Settings).SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Linear)
      ((buShapeVisualition) this).\u0005.Checked = true;
    else if (((DrillJob) ((buShapeCut) this).Settings).SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Quadratic)
      ((buShapeVisualition) this).\u0006.Checked = true;
    else if (((DrillJob) ((buShapeCut) this).Settings).SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Cubic)
      ((buShapeVisualition) this).\u0003.Checked = true;
    else if (((DrillJob) ((buShapeCut) this).Settings).SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Bezeir)
      ((buShapeVisualition) this).\u0004.Checked = true;
    ((buShapeHole3) this).PropertiesForm.Result = DialogResult.None;
    ((buShapeHole3) this).PropertiesForm.Inited = true;
  }
}
