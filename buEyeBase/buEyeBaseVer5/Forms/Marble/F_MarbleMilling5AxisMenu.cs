// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleMilling5AxisMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
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

public class F_MarbleMilling5AxisMenu : Form
{
  public buGround buGround1;
  public buButton btn_cancel;
  public Panel pnl_base;
  public Panel pnl_data;
  public buButton btn_save;
  public buButton btn_open;
  public buButton btn_itemok;
  public buCheckBox chk_cutend;
  public buButton btn_remove;
  public buCheckBox chk_cutstart;
  public buButton btn_add;
  public buButton btn_itemendpos;
  public buButton btn_itemstartpos;
  public buButton btn_itemclearall;
  public buButton btn_itemup;
  public buButton btn_itemdown;
  public buSpin spn_angle;
  public DataGridView DGV_items;
  public buSpin spn_length;
  public buCheckBox chk_lefttop;
  public buCheckBox chk_leftbottom;
  public buLabel lbl_width;
  public buLabel lbl_endangle;
  public buSpin spn_itemEA1;
  public buLabel lbl_startangle;
  public buSpin spn_itemlen1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buLabel lbl_count;
  public static byte f0020AC;
  public static List<string> Captions;
  public FormProperties Properties;
  public bool isHorizontal;
  public bool isDialog;
  private IContainer \u0001;
  public buButton btn_minimise;

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCam) this).\u0001.Text = buLangTranslate.preDef.Settings;
      ((F_MarbleProfileCam) this).spn_materialhorlimit.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Limit}";
      ((F_MarbleProfileCam) this).spn_materialverlimit.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Limit}";
      ((F_MarbleProfileCam) this).spn_matrialcutWidth.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Width}";
      ((F_MarbleProfileCam) this).spn_materialheight.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Height}";
      ((F_MarbleProfileCam) this).spn_matrialcutWidth.Caption.Caption = $"{buLangTranslate.preDef.User} {buLangTranslate.preDef.Cut} {buLangTranslate.preDef.Width}";
      ((F_MarbleProfileCam) this).spn_materialcutheight.Caption.Caption = $"{buLangTranslate.preDef.User} {buLangTranslate.preDef.Cut} {buLangTranslate.preDef.Height}";
      ((F_MarbleProfileCam) this).spn_verticaloffset.Caption.Caption = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Offset}";
      ((F_MarbleProfileCam) this).spn_horizontaloffset.Caption.Caption = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Offset}";
      ((F_MarbleProfileCam) this).chk_horizontalcutenable.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Cut} {buLangTranslate.preDef.Enable}";
      ((F_MarbleProfileCam) this).chk_verticalcutenable.Text = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Cut} {buLangTranslate.preDef.Enable}";
      ((F_MarbleProfileCam) this).chk_pasueaftercut.Text = $"{buLangTranslate.preDef.Pause} {buLangTranslate.preDef.After} {buLangTranslate.preDef.Cut}";
      ((F_MarbleProfileCam) this).\u0002.Text = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Data} {buLangTranslate.preDef.Use}";
      ((F_MarbleProfileCam) this).\u0001.Text = $"{buLangTranslate.preDef.User} {buLangTranslate.preDef.Data} {buLangTranslate.preDef.Use}";
      ((F_MarbleProfileCam) this).\u0001.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleProfileCam) this).\u0002.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(((F_MarbleProfileCam) this).\u0001.Controls, result, obj1.Shift);
  }

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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((MarbleCamType) ((F_MarbleProfileCam) this).SettingsMaterial).MaterialHeight = ((F_MarbleProfileCam) this).spn_materialheight.Value;
    ((MarbleCamType) ((F_MarbleProfileCam) this).SettingsMaterial).MaterialWidth = ((F_MarbleProfileCam) this).spn_materialwidth.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialHorizontalMinDistance = ((F_MarbleProfileCam) this).spn_materialhorlimit.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialVerticalMinDistance = ((F_MarbleProfileCam) this).spn_materialverlimit.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialCutHeight = ((F_MarbleProfileCam) this).spn_materialcutheight.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialCutWidth = ((F_MarbleProfileCam) this).spn_matrialcutWidth.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).VerticalOffset = ((F_MarbleProfileCam) this).spn_verticaloffset.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).HorizontalOffset = ((F_MarbleProfileCam) this).spn_horizontaloffset.Value;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).PauseAfterCut = ((F_MarbleProfileCam) this).chk_pasueaftercut.Check;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).HorizontalCutEnable = ((F_MarbleProfileCam) this).chk_horizontalcutenable.Check;
    ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).VerticalCutEnable = ((F_MarbleProfileCam) this).chk_verticalcutenable.Check;
    if (((F_MarbleProfileCam) this).\u0002.Checked)
      ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).UseMaterialData = true;
    else
      ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).UseMaterialData = false;
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMilling5AxisMenu() => F_MarbleProfileCam.Captions = new List<string>();

  public F_MarbleMilling5AxisMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
