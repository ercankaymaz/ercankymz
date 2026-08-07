// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTextMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Layer;
using buEyeBaseVer5.Forms.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTextMenu : Form
{
  internal buGround \u0001;
  public buCheckBox chk_concavecuttingNone;
  public buCheckBox chk_DontAddExtensionEntities;
  public buSpin spn_CutSawDistanceOverlap;
  internal buSeparator \u0001;
  public buLabel lbl_concavetype;
  public buSpin spn_ConcaveMillingStepDown;
  public buCheckBox chk_concexcuttingWaterjet;
  public buCheckBox chk_concexcuttingmilling;
  public buLabel lbl_convexcuttingtype;
  public buCheckBox chk_concexcuttingNone;
  public buCheckBox chk_concavecuttingWaterjet;
  public buCheckBox chk_concavecuttingMilling;
  public buButton btn_close;
  public buButton btn_advancedsettings;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varSettings;
  public string strMessageRoughtFinish;
  public string strMessageRoughtFinishSelect;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buSpin spn_safedistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_plungespeed;
  public buSpin spn_cutspeed;
  internal buGround \u0001;
  internal buButton \u0001;
  public buSpin spn_radiustopdistance;
  public buSpin spn_baseheight;
  public static byte f002769;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleProfileCurveCutPars varProfileCurveCut;
  public bool CamVisible;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleBaseMatClear) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleProfileCutCad) this);
        ((F_MarbleBaseMatClear) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleBaseMatClear) this).btn_cancel.Name | control2.Name == ((F_MarbleBaseMatClear) this).\u0001.Name)
      {
        ((F_MarbleBaseMatClear) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleBaseMatClear) this).btn_settings.Name))
        return;
      F_MarbleProfileSettings marbleProfileSettings = (F_MarbleProfileSettings) new buEyeBaseVer5.Forms.KeyPad.F_KeyPadCharV1();
      ((F_LayerOptionList) marbleProfileSettings).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001(((F_MarbleBaseMatClear) this).varProfileCut);
      ((F_SketchLibrary) marbleProfileSettings).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_SketchLibrary) marbleProfileSettings).Properties.FormPosition = FormStartPosition.CenterParent;
      ((buEyeBaseVer5.Forms.KeyPad.F_KeyPadCharV1) marbleProfileSettings).Init();
      int num = (int) marbleProfileSettings.ShowDialog();
      if (((F_SketchLibrary) marbleProfileSettings).Properties.Result != DialogResult.OK)
        return;
      ((F_MarbleBaseMatClear) this).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001(((F_LayerOptionList) marbleProfileSettings).varProfileCut);
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
    buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1 fKeyPadNumV1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleBaseMatClear) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleBaseMatClear) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleTextMenu() => F_MarbleBaseMatClear.Captions = new List<string>();

  public F_MarbleTextMenu()
  {
    ((F_MarbleMaterialSize) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleMaterialSize) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleMaterialSize) this).PropertiesForm = new FormProperties();
    ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.Rough;
    ((F_MarbleMaterialSize) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0008.\u0002.\u0001.\u0001((F_Marble3DCamStrategyMenu) this);
  }

  public void Init()
  {
    ((F_MarbleMaterialSize) this).PropertiesForm.Inited = false;
    if (((F_MarbleMaterialSize) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMaterialSize) this).PropertiesForm.Height;
    if (((F_MarbleMaterialSize) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMaterialSize) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMaterialSize) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMaterialSize) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleMaterialSize) this).chk_constantZ.Check = false;
    ((F_MarbleMaterialSize) this).chk_parallelcut.Check = false;
    ((F_MarbleMaterialSize) this).chk_flatlands.Check = false;
    ((F_MarbleMaterialSize) this).chk_pencil.Check = false;
    ((F_MarbleSweepCut) this).chk_rough.Check = false;
    ((F_MarbleSweepCut) this).chk_none.Check = false;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.ConstantZ)
      ((F_MarbleMaterialSize) this).chk_constantZ.Check = true;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.Rough)
      ((F_MarbleSweepCut) this).chk_rough.Check = true;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.ParallelCuts)
      ((F_MarbleMaterialSize) this).chk_parallelcut.Check = true;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.Flatlands)
      ((F_MarbleMaterialSize) this).chk_flatlands.Check = true;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.Pencil)
      ((F_MarbleMaterialSize) this).chk_pencil.Check = true;
    if (((F_MarbleMaterialSize) this).MeshType == CamTriangularMeshType.None)
      ((F_MarbleSweepCut) this).chk_none.Check = true;
    ((F_MarbleMaterialSize) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMaterialSize) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleMaterialSize) this).chk_constantZ.Text = $"{buLangTranslate.preDef.ConstantZ} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleMaterialSize) this).chk_flatlands.Text = $"{buLangTranslate.preDef.Flatlands} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleMaterialSize) this).chk_parallelcut.Text = $"{buLangTranslate.preDef.ParalelCuts} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleMaterialSize) this).chk_pencil.Text = $"{buLangTranslate.preDef.Pencil} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleSweepCut) this).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleSweepCut) this).chk_none.Text = buLangTranslate.preDef.None;
      ((F_MarbleMaterialSize) this).\u0001.Text = $"{buLangTranslate.preDef.Milling3D} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMaterialSize) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMaterialSize) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleMaterialSize) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleMaterialSize) this).PropertiesForm.Inited)
      return;
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleMaterialSize) this).chk_constantZ.Name)
    {
      ((F_MarbleMaterialSize) this).chk_constantZ.Check = true;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.ConstantZ;
    }
    if (control.Name == ((F_MarbleSweepCut) this).chk_rough.Name)
    {
      ((F_MarbleSweepCut) this).chk_rough.Check = true;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.Rough;
    }
    if (control.Name == ((F_MarbleMaterialSize) this).chk_parallelcut.Name)
    {
      ((F_MarbleMaterialSize) this).chk_parallelcut.Check = false;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.ParallelCuts;
    }
    if (control.Name == ((F_MarbleMaterialSize) this).chk_pencil.Name)
    {
      ((F_MarbleMaterialSize) this).chk_pencil.Check = false;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.Pencil;
    }
    if (control.Name == ((F_MarbleMaterialSize) this).chk_flatlands.Name)
    {
      ((F_MarbleMaterialSize) this).chk_flatlands.Check = false;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.Flatlands;
    }
    if (control.Name == ((F_MarbleSweepCut) this).chk_none.Name)
    {
      ((F_MarbleSweepCut) this).chk_none.Check = false;
      ((F_MarbleMaterialSize) this).MeshType = CamTriangularMeshType.None;
    }
    ((F_MarbleMaterialSize) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMaterialSize) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMaterialSize) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMaterialSize) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleTextMenu() => F_MarbleMaterialSize.Captions = new List<string>();

  public F_MarbleTextMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleSweepCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleSweepCut) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
