// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Marble3DShapeMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble3DShapeMenu : Form
{
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_slatstartangle;
  public buButton btn_okVer;
  public buSpin spn_topchamferstartheight;
  public buSpin spn_topchamferstartangle;
  public buSpin spn_slatwidth;
  public buButton btn_cancel;
  public buCheckBox chk_topchamferstartenable;
  public buCheckBox chk_slatenable;
  public buSpin spn_slatendangle;
  public buCheckBox chk_topchamferendenable;
  public buSpin spn_topchamferendheight;
  public buSpin spn_topchamferendangle;
  public buCheckBox chk_Socket1;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  public buSpin spn_socketxdistance1;
  public buSpin spn_socketydistance1;
  public buSpin spn_socketwidth1;
  public buSpin spn_socketheight1;
  public buCheckBox chk_socket2;
  public buSpin spn_socketxdistance2;
  public buSpin spn_socketydistance2;
  public buSpin spn_socketwidth2;
  public buSpin spn_socketheight2;
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0002;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<ValuesItem> ItemList;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buEnableTwoValueList lst_edges;
  public FormProperties PropertiesForm;
  public static List<string> Captions;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleHoleData) this).btn_ok.Name)
      {
        ((F_MarbleSlice) this).Apply();
        ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleHoleData) this).btn_cancel.Name | control.Name == ((F_MarbleEasyDraw) this).btn_close.Name))
        return;
      ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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
    if ((!disposing ? 0 : (((F_MarbleEasyDraw) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEasyDraw) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble3DShapeMenu() => F_MarbleEasyDraw.Captions = new List<string>();

  public F_Marble3DShapeMenu()
  {
    ((F_MarbleHoleData) this).\u0001 = "F_MarbleViewV1";
    ((F_MarbleHoleData) this).PropertiesForm = new FormProperties();
    ((F_MarbleHoleData) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventRotate) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleHoleData) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleHoleData) this).PropertiesForm.Inited = false;
    if (((F_MarbleHoleData) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHoleData) this).PropertiesForm.Height;
    if (((F_MarbleHoleData) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHoleData) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHoleData) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHoleData) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleHoleData) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHoleData) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleHoleData) this).ground_base.Text = buLangTranslate.preDef.Rotate;
      ((F_MarbleMaterialList) this).spn_eventrotatevalue.Caption.Caption = buLangTranslate.preDef.Rotate;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHoleData) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHoleData) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHoleData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHoleData) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleHoleData) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHoleData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHoleData) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleMaterialList) this).spn_eventrotatevalue.Value = (obj0 as buButton).Aux.ValDouble;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString(), (IWin32Window) this);
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHoleData) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHoleData) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble3DShapeMenu() => F_MarbleHoleData.Captions = new List<string>();

  public F_Marble3DShapeMenu()
  {
    ((F_MarbleMaterialList) this).\u0001 = "F_MarbleViewV1";
    ((F_MarbleMaterialList) this).PropertiesForm = new FormProperties();
    ((F_MarbleMaterialList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleEventMove) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      ((F_Marble3DAddMenu) this).LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleMaterialList) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
