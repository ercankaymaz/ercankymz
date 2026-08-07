// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLine
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buLine : buEntity
{
  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (buShapeHole3.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public new void Apply()
  {
    ((DrillJob) ((buShapeCut) this).Settings).NozzleDiameter = (double) ((buShapeProfiling) this).\u0003.Value;
    ((DrillJob) ((buShapeCut) this).Settings).OffsetXY = (double) ((buShapeProfiling) this).\u0002.Value;
    ((DrillJob) ((buShapeCut) this).Settings).SliceCount = (int) ((buShapeCut) this).\u0001.Value;
    ((DrillJob) ((buShapeCut) this).Settings).InFill = ((buShapeProfiling) this).\u0001.Checked;
    ((DrillJob) ((buShapeCut) this).Settings).Simplify = ((buShapeEngrave) this).\u0002.Checked;
    ((DrillJob) ((buShapeCut) this).Settings).ZSpiralMove = ((buShapeNotch) this).\u0003.Checked;
    ((DrillJob) ((buShapeCut) this).Settings).UseSpline = ((buShapeVisualition) this).\u0004.Checked;
    ((DrillJob) ((buShapeCut) this).Settings).FeedSpeed = (double) ((buShapeJunction) this).\u0004.Value;
    ((DrillJob) ((buShapeCut) this).Settings).PlungeSpeed = (double) ((buShapeJunction) this).\u0005.Value;
    ((DrillJob) ((buShapeCut) this).Settings).TopHeight = (double) ((buShapeText) this).\u0007.Value;
    ((DrillJob) ((buShapeCut) this).Settings).SliceStep = (double) ((buShapeText) this).\u0006.Value;
    ((DrillJob) ((buShapeCut) this).Settings).FilletRadius = (double) ((buShapeNotch) this).\u0008.Value;
    ((DrillJob) ((buShapeCut) this).Settings).FilletLimitMinAngle = (double) ((buShapeNotch) this).\u000F.Value;
    ((DrillJob) ((buShapeCut) this).Settings).FilletLimitMaxAngle = (double) ((buShapeNotch) this).\u000E.Value;
    if (((buShapeJunction) this).\u0001.Checked)
      ((DrillJob) ((buShapeCut) this).Settings).SliceType = Printer3DSliceType.Count;
    else
      ((DrillJob) ((buShapeCut) this).Settings).SliceType = Printer3DSliceType.Step;
    if (((buShapeVisualition) this).\u0005.Checked)
      ((DrillJob) ((buShapeCut) this).Settings).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Linear;
    else if (((buShapeVisualition) this).\u0006.Checked)
      ((DrillJob) ((buShapeCut) this).Settings).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Quadratic;
    else if (((buShapeVisualition) this).\u0003.Checked)
      ((DrillJob) ((buShapeCut) this).Settings).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Cubic;
    else
      ((DrillJob) ((buShapeCut) this).Settings).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Bezeir;
  }

  internal new void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((buShapeHole3) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((buShapeHole3) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buShapeHole3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buShapeHole3) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  internal new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((buShapeCut) this).btn_ok.Name)
    {
      this.Apply();
      ((buShapeHole3) this).PropertiesForm.Result = DialogResult.OK;
      if (((buShapeHole3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buShapeHole3) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      ((Control) this).Visible = false;
    }
    else
    {
      if (!(control2.Name == ((buShapeCut) this).btn_cancel.Name))
        return;
      ((buShapeHole3) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((buShapeHole3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buShapeHole3) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      ((Control) this).Visible = false;
    }
  }

  internal new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buShapeCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((buShapeCut) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buLine() => buShapeHole3.Captions = new List<string>();
}
