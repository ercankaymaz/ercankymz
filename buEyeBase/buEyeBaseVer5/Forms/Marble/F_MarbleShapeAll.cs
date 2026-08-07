// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleShapeAll
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleShapeAll : Form
{
  public buLabel lbl_counthor;
  public buLabel lbl_hor7;
  public buSpin spn_itemhorEA7;
  public buSpin spn_itemhorSA7;
  public buSpin spn_itemhorcount7;
  public buSpin spn_itemhorlen7;
  public buLabel lbl_hor6;
  public buSpin spn_itemhorEA6;
  public buSpin spn_itemhorSA6;
  public buSpin spn_itemhorcount6;
  public buSpin spn_itemhorlen6;
  public Panel pnl_base;
  public buButton btn_itemhorclearall;
  public buSpin spn_horverangle;
  public buButton btn_horversave;
  internal buLabel \u0001;
  public TextBox txt_info;
  public Panel pnl_data;
  public buSpin spn_horverxoffset;
  public buSpin spn_horveryoffset;
  public buButton btn_itemhorverstartpos;
  public buButton btn_itemhorverendpos;
  public buButton btn_addtolist;
  public buLabel lbl_lengthver;
  public buSpin spn_itemverlen4;
  public buSpin spn_itemverEA3;
  public buSpin spn_itemvercount4;
  public buButton btn_itemverclearall;
  public buSpin spn_itemverSA3;
  public buSpin spn_itemverSA4;
  public buSpin spn_itemvercount3;
  public buLabel lbl_ver7;
  public buSpin spn_itemverEA4;
  public buSpin spn_itemverEA7;
  public buSpin spn_itemverlen3;
  public buSpin spn_itemverSA7;
  public buSpin spn_itemverlen5;
  public buSpin spn_itemvercount7;
  public buSpin spn_itemverEA2;
  public buSpin spn_itemverlen7;
  public buSpin spn_itemvercount5;
  public buLabel lbl_ver6;
  public buSpin spn_itemverSA2;
  public buSpin spn_itemverEA6;
  public buSpin spn_itemverSA5;
  public buSpin spn_itemverSA6;
  public buSpin spn_itemvercount2;
  public buSpin spn_itemvercount6;
  public buSpin spn_itemverEA5;
  public buSpin spn_itemverlen6;
  public buSpin spn_itemverlen2;
  public buLabel lbl_ver5;
  public buLabel lbl_ver4;
  public buButton btn_itemverup;
  public buLabel lbl_ver3;
  public buButton btn_itemverdown;
  public buLabel lbl_ver2;
  public buLabel lbl_ver1;
  public buLabel lbl_eaver;
  public buSpin spn_itemverEA1;
  public buLabel lbl_saver;
  public buSpin spn_itemverlen1;
  public buSpin spn_itemverSA1;
  public buSpin spn_itemvercount1;
  public buLabel lbl_countver;
  public buSpin spn_itemverlength;
  public TabPage tabPage_Hor;
  public TabPage tabPage_Ver;
  public buCheckBox chk_horverleftbottom;
  public buCheckBox chk_horverlefttop;
  public buTab buTab1;
  public Panel pnl_viewport;
  public buLabel lbl_EAimgHor7;
  public ImageList IC32;
  public buLabel lbl_SAimgHor7;
  public buLabel lbl_EAimgHor6;
  public buLabel lbl_SAimgHor6;
  public buLabel lbl_EAimgHor5;
  public buLabel lbl_SAimgHor5;
  public buLabel lbl_EAimgHor4;
  public buLabel lbl_SAimgHor4;
  public buLabel lbl_EAimgHor3;
  public buLabel lbl_SAimgHor3;
  public buLabel lbl_EAimgHor2;
  public buLabel lbl_SAimgHor2;
  public buLabel lbl_EAimgHor1;
  public buLabel lbl_SAimgHor1;
  public buLabel lbl_EAimgVer7;
  public buLabel lbl_EAimgVer6;
  public buLabel lbl_SAimgVer7;
  public buLabel lbl_EAimgVer5;
  public buLabel lbl_EAimgVer4;
  public buLabel lbl_EAimgVer3;
  public buLabel lbl_SAimgVer6;
  public buLabel lbl_EAimgVer2;
  public buLabel lbl_EAimgVer1;
  public buLabel lbl_SAimgVer5;
  public buLabel lbl_SAimgVer4;
  public buLabel lbl_SAimgVer3;
  public buLabel lbl_SAimgVer2;
  public buLabel lbl_SAimgVer1;
  public buCheckBox chk_verticalfirst;
  public static byte f00214E;
  public static List<string> Captions;
  public FormProperties Properties;
  public bool isHorizontal;
  public bool isDialog;
  internal IContainer \u0001;
  public buSpin spn_itemlength;
  public buSpin spn_itemEA5;
  public buSpin spn_itemSA5;
  public buSpin spn_itemcount5;
  public buSpin spn_itemlen5;
  public buSpin spn_itemEA4;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSingleCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSingleCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleShapeAll() => F_MarbleSingleCutV2.Captions = new List<string>();

  public F_MarbleShapeAll()
  {
    ((F_MarbleHorVerCutV3) this).PropertiesForm = new FormProperties();
    ((F_MarbleHorVerCutV3) this).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((F_MarbleHorVerCutV3) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleProfileCam) this);
  }

  public void Init(int CamIndex)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorVerCutV3) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCutV3) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleHorVerCutV3) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCam) this);
        ((F_MarbleHorVerCutV3) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleHorVerCutV3) this).btn_cancel.Name | control2.Name == ((F_MarbleHorVerCutV3) this).\u0001.Name))
        return;
      ((F_MarbleHorVerCutV3) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleHorVerCutV3) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCutV3) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCutV3) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleShapeAll() => F_MarbleHorVerCutV3.Captions = new List<string>();

  public F_MarbleShapeAll()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleHorVerCutV2) this).varSawMilling = (marbleSawMillingPars) new \u0007.\u0001();
    ((F_MarbleHorVerCutV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawCornerClean) this);
  }

  public void Init(FormStartPosition formPos = FormStartPosition.CenterScreen, FormCloseModeType CloseMode = FormCloseModeType.Invisible)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
