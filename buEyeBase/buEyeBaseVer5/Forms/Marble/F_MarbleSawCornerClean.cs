// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawCornerClean
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawCornerClean : Form
{
  internal buGround \u0001;
  public buSpin spn_lefttapdepth;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_tapdiameter;
  public buSpin spn_tapdepth;
  public buSpin spn_righttapdiameter;
  public buSpin spn_lefttapdiameter;
  public buSpin spn_righttapdepth;
  public buCheckBox chk_lefttapenable;
  internal PictureBox \u0001;
  public buCheckBox chk_toolmillinghead;
  public buCheckBox chk_toolmilling;
  public buButton btn_closecross;
  public buSpin spn_righttapxoffset;
  public buSpin spn_righttapyoffset;
  public buSpin spn_lefttapxoffset;
  public buSpin spn_lefttapyoffset;
  public buCheckBox chk_righttapenable;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleDrillPars varDrill;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_drillpocketscanY;
  public buSpin spn_drillpocketscanX;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_drillpocketsafedis;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal buLabel \u0001;
  public buSpin spn_drillpocketplungefeed;
  internal TabPage \u0003;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Depth = ((F_MarbleSawMillingCam) this).spn_depth.Value;
    ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Diameter = ((F_MarbleSawMillingCam) this).spn_dia.Value;
    ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.X = ((F_MarbleSawMillingCam) this).spn_x.Value;
    ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.Y = ((F_MarbleSawMillingCam) this).spn_y.Value;
    ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.Z = ((F_MarbleSawMillingCam) this).spn_z.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((obj0 as Control).Name == ((F_MarbleSawMillingCam) this).btn_ok.Name))
      return;
    this.Apply();
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawMillingCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawMillingCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawCornerClean() => F_MarbleSawMillingCam.Captions = new List<string>();

  public F_MarbleSawCornerClean()
  {
    ((F_MarbleSawMillingCam) this).PropertiesForm = new FormProperties();
    ((F_MarbleSawMillingCam) this).Settings = (marbleCamPars) new \u0007.\u0001();
    ((F_MarbleSawMillingCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleMaterialList) this);
  }
}
