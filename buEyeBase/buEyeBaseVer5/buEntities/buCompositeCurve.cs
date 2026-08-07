// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buCompositeCurve
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.ClassViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buCompositeCurve : buEntity
{
  public buCheckBox chk_smoot;
  public buButton btn_tiltstrategy;
  internal new buLabel \u0001;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern buCompositeCurve(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(object sender, object Value, cParameter5 Parameter);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    object sender,
    object Value,
    cParameter5 Parameter,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public buCompositeCurve()
  {
    ((buMachinePart) this).OkCaption = "Ok";
    ((buMachinePart) this).CancelCaption = "Cancel";
    ((buMachinePart) this).FormCaption = "";
    ((buMaterialMoveable) this).ParCaptions = new List<string>();
    ((buMaterialMoveable) this).Result = DialogResult.None;
    ((buMaterialMoveable) this).ValuePersentage = 50.0;
    ((buMaterialMoveable) this).DecimalPlace = 3;
    ((buMaterialMoveable) this).Value = (object) null;
    ((buMaterialMoveable) this).\u0001 = (object) null;
    ((buMaterialMoveable) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_ClassViewerColorDialog5) this);
  }

  public new void Init()
  {
    if (((buMachinePart) this).FormCaption.Length > 0)
      ((Control) this).Text = ((buMachinePart) this).FormCaption;
    if (((buMachinePart) this).OkCaption.Length > 0)
      ((buMaterialMoveable) this).btn_ok.Text = ((buMachinePart) this).OkCaption;
    if (((buMachinePart) this).CancelCaption.Length > 0)
      ((buMaterialMoveable) this).btn_cancel.Text = ((buMachinePart) this).CancelCaption;
    buSerilization5.CopyClass(((buMaterialMoveable) this).Value, ref ((buMaterialMoveable) this).\u0001);
    ((buArcCam) ((buMaterialMoveable) this).\u0001).ClassObject = ((buMaterialMoveable) this).\u0001;
    ((buCompositeCurveCam) ((buMaterialMoveable) this).\u0001).RowSpace = 1;
    ((buMaterialMoveable) this).\u0001.Width = ((Control) this).Width - 15;
    ((buMaterialMoveable) this).\u0001.Visible = true;
    ((buLinearPathCam) ((buMaterialMoveable) this).\u0001).DecimalPlace = ((buMaterialMoveable) this).DecimalPlace;
    ((buLinearPathCam) ((buMaterialMoveable) this).\u0001).ValueWidth = Convert.ToInt32((double) ((Control) this).Width * (((buMaterialMoveable) this).ValuePersentage / 100.0)) - 8;
    ((buLineCam) ((buMaterialMoveable) this).\u0001).ParCaptions.Clear();
    for (int index = 0; index <= ((buMaterialMoveable) this).ParCaptions.Count - 1; ++index)
      ((buLineCam) ((buMaterialMoveable) this).\u0001).ParCaptions.Add(((buMaterialMoveable) this).ParCaptions[index]);
    ((buCircle) ((buMaterialMoveable) this).\u0001).Init();
  }

  internal new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    buSerilization5.CopyClass(((buMaterialMoveable) this).\u0001, ref ((buMaterialMoveable) this).Value);
    ((buMaterialMoveable) this).Result = DialogResult.OK;
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Component) this).Dispose());
  }

  internal new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((buMaterialMoveable) this).Result = DialogResult.Cancel;
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Component) this).Dispose());
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buMaterialMoveable) this).\u0001 != null ? 1 : 0)) != 0)
      ((buMaterialMoveable) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }
}
