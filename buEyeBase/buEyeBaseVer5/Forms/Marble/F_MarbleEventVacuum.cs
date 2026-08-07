// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventVacuum
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventVacuum : Form
{
  public buTrack track_quickspeed;
  public buLabel lbl_quickspeed;
  public buLabel lbl_sawspeed;
  public buTrack track_sawspeed;
  public buButton btn_spindle;
  public buButton btn_saw;
  public buSpin spn_sawspeed;
  public buSpin spn_spindlespeed;
  public buButton btn_sawminus;
  public buButton btn_sawplus;
  public buButton btn_spindleminus;
  public buButton btn_spindleplus;
  public buLabel lbl_sawdia;
  public buButton btn_toolmillinheadset;
  public buButton btn_toolmillinset;
  public buButton btn_toolsawset;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buLabel lbl_millingheadlen;
  public buLabel lbl_millingheaddia;
  public buLabel lbl_millinglen;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
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
    if ((!disposing ? 0 : (((F_MarbleEventExtend) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventExtend) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventVacuum() => F_MarbleEventOffset.Captions = new List<string>();

  public F_MarbleEventVacuum()
  {
    ((F_MarbleEventAling) this).\u0001 = "F_MarbleCommandsV1";
    ((F_MarbleEventAling) this).PropertiesForm = new FormProperties();
    ((F_MarbleEventAling) this).DryRunEnable = false;
    ((F_MarbleEventAling) this).DryRunOffsetZ = 0.0;
    ((F_MarbleEventAling) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCommandsV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      this.LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleEventAling) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleEventAling) this).ground_base.Controls);
      ((F_MarbleEventAling) this).PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEventAling) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleEventAling) this).PropertiesForm.Inited = false;
    if (((F_MarbleEventAling) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEventAling) this).PropertiesForm.Height;
    if (((F_MarbleEventAling) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEventAling) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEventAling) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEventAling) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEventAling) this).chk_Dryrun.Check = ((F_MarbleEventAling) this).DryRunEnable;
    ((F_MarbleEventAling) this).spn_dryrunoffset.Value = ((F_MarbleEventAling) this).DryRunOffsetZ;
    ((F_MarbleEventAling) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEventAling) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEventAling) this).ground_base.Text = buLangTranslate.preDef.Command;
      ((F_MarbleEventAling) this).btn_addmaterial.Text = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Add}";
      ((F_MarbleEventAling) this).btn_deletematerial.Text = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Delete}";
      ((F_MarbleEventAling) this).btn_materialcontour.Text = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Contour}";
      ((F_MarbleEventAling) this).btn_deletephoto.Text = $"{buLangTranslate.preDef.Photo} {buLangTranslate.preDef.Delete}";
      ((F_MarbleEventAling) this).btn_importphoto.Text = $"{buLangTranslate.preDef.Photo} {buLangTranslate.preDef.Import}";
      ((F_MarbleEventAling) this).btn_drawing.Text = $"{buLangTranslate.preDef.Drawing} {buLangTranslate.preDef.Menu}";
      ((F_MarbleEventAling) this).btn_draw.Text = buLangTranslate.preDef.Draw;
      ((F_MarbleEventAling) this).chk_Dryrun.Text = buLangTranslate.preDef.DryRun;
      ((F_MarbleEventAling) this).spn_dryrunoffset.Caption.Caption = "Z " + buLangTranslate.preDef.Offset;
      ((F_MarbleEventAling) this).spn_goposx.Caption.Caption = "X " + buLangTranslate.preDef.Position;
      ((F_MarbleEventAling) this).spn_goposy.Caption.Caption = "Y " + buLangTranslate.preDef.Position;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    ((F_MarbleEventAling) this).DryRunEnable = ((F_MarbleEventAling) this).chk_Dryrun.Check;
    ((F_MarbleEventAling) this).DryRunOffsetZ = ((F_MarbleEventAling) this).spn_dryrunoffset.Value;
    if (((F_MarbleEventAling) this).PropertiesForm.Result != DialogResult.OK)
    {
      obj1.Cancel = true;
      ((F_MarbleEventAling) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleEventAling) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEventAling) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEventAling) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventAling) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventAling) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString(), (IWin32Window) this);
      if (buFile5.IsNumeric(fKeyPadNumV1.Value))
        buSpin.Value = double.Parse(fKeyPadNumV1.Value);
      if (this.Owner == null)
        return;
      this.Owner.Focus();
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventAling) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventAling) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventVacuum() => F_MarbleEventAling.Captions = new List<string>();

  public event OkCommandWithFiveDataEventHandler VacuumCommand;
}
