// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIRadio
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Door;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIRadio : Form
{
  internal NumericUpDown \u0006;
  internal Label \u0007;
  internal NumericUpDown \u0007;
  internal Label \u0008;
  internal NumericUpDown \u0008;
  internal Label \u000E;
  internal NumericUpDown \u000E;
  internal Label \u000F;
  internal NumericUpDown \u000F;
  internal Label \u0010;
  internal NumericUpDown \u0010;
  public static byte f0032E3;
  public FormProperties PropertiesForm;
  public Design viewport;
  public ToolBase5 ToolGrinding;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_ControlUIPanel) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_ControlUIBasic) this).SpinBaseColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUIPanel) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUIPanel) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUIRadio() => F_ControlUIPanel.Captions = new List<string>();

  public F_ControlUIRadio()
  {
    ((F_ControlUIDataGridView) this).PropertiesForm = new FormProperties();
    ((F_ControlUIDataGridView) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((F_ControlUIDataGridView) this).Case1 = new SizeObject();
    ((F_ControlUIDataGridView) this).Case2 = new SizeObject();
    ((F_ControlUIDataGridView) this).\u0001 = new Timer();
    ((F_ControlUIDataGridView) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_DoorMat) this);
  }

  public void Init(MaterialBase5 material)
  {
    ((F_ControlUIDataGridView) this).PropertiesForm.Inited = false;
    if (((F_ControlUIDataGridView) this).PropertiesForm.Height > 10)
      this.Height = ((F_ControlUIDataGridView) this).PropertiesForm.Height;
    if (((F_ControlUIDataGridView) this).PropertiesForm.Width > 10)
      this.Width = ((F_ControlUIDataGridView) this).PropertiesForm.Width;
    this.TopMost = ((F_ControlUIDataGridView) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ControlUIDataGridView) this).PropertiesForm.FormPosition;
    ((F_ControlUIGroup) this).btn_ok.Enabled = false;
    if (material != null)
      ((F_ControlUIDataGridView) this).Material = (MaterialBase5) new ShapeMultiCenterData(material);
    this.LoadLanguage();
    ((F_ControlUIDataGridView) this).PropertiesForm.Inited = false;
    ((F_ControlUIGroup) this).\u0001.Text = $"{buLangTranslate.preDef.Door} {AppLanguage.CadCamDynamic[0]} (X) ";
    ((F_ControlUIGroup) this).\u0002.Text = $"{buLangTranslate.preDef.Door} {AppLanguage.CadCamDynamic[16 /*0x10*/]} (Y) ";
    ((F_ControlUIGroup) this).\u0003.Text = $"{buLangTranslate.preDef.Door} {AppLanguage.CadCamDynamic[113]} (Z) ";
    ((F_ControlUIGroup) this).\u0004.Text = $"{AppLanguage.CadCamDynamic[131]} {AppLanguage.CadCamDynamic[2]}";
    ((F_ControlUIGroup) this).\u0005.Text = $"{AppLanguage.CadCamDynamic[132]} {AppLanguage.CadCamDynamic[2]}";
    ((F_ControlUIDataGridView) this).viewportLayout.ActiveViewport.CoordinateSystemIcon.Visible = true;
    this.\u0008.Text = $"1. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[0]} (X) ";
    this.\u0007.Text = $"1. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[16 /*0x10*/]} (Y) ";
    ((F_ControlUIGroup) this).\u0006.Text = $"1. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[113]} (Z) ";
    this.\u0010.Text = $"2. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[0]} (X) ";
    this.\u000F.Text = $"2. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[16 /*0x10*/]} (Y) ";
    this.\u000E.Text = $"2. {buLangTranslate.preDef.Case} {AppLanguage.CadCamDynamic[113]} (Z) ";
    ((F_ControlUIGroup) this).\u0001.Value = (Decimal) ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Width;
    ((F_ControlUIGroup) this).\u0002.Value = (Decimal) ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Height;
    ((F_ControlUIGroup) this).\u0003.Value = (Decimal) ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Depth;
    ((F_ControlUIGroup) this).\u0004.Value = (Decimal) ((SortResult) ((F_ControlUIDataGridView) this).Material).FrontAngle;
    ((F_ControlUIGroup) this).\u0005.Value = (Decimal) ((SortResult) ((F_ControlUIDataGridView) this).Material).BackAngle;
    if (((SortAskMe) ((F_ControlUIDataGridView) this).Material).Purpose == MaterialPurpose.Door)
      ((F_ControlUIGroup) this).\u0001.Checked = true;
    else
      ((F_ControlUIGroup) this).\u0002.Checked = true;
    this.\u0008.Value = (Decimal) ((F_ControlUIDataGridView) this).Case1.Width;
    this.\u0007.Value = (Decimal) ((F_ControlUIDataGridView) this).Case1.Height;
    this.\u0006.Value = (Decimal) ((F_ControlUIDataGridView) this).Case1.Depth;
    this.\u0010.Value = (Decimal) ((F_ControlUIDataGridView) this).Case2.Width;
    this.\u000F.Value = (Decimal) ((F_ControlUIDataGridView) this).Case2.Height;
    this.\u000E.Value = (Decimal) ((F_ControlUIDataGridView) this).Case2.Depth;
    ((F_ControlUIDataGridView) this).\u0001.Interval = 100;
    ((F_ControlUIDataGridView) this).\u0001.Tick += new EventHandler(this.\u0002);
    ((F_ControlUIDataGridView) this).\u0001.Enabled = true;
    ((F_ControlUIDataGridView) this).PropertiesForm.Result = DialogResult.None;
    ((F_ControlUIDataGridView) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_ControlUIDataGridView.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUIDataGridView) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUIDataGridView) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_ControlUIGroup) this).btn_ok.Name)
    {
      ((MostClosestPointOption) ((F_ControlUIDataGridView) this).Material).Entities.Clear();
      for (int index = 0; index <= ((F_ControlUIDataGridView) this).viewportLayout.Entities.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(((F_ControlUIDataGridView) this).viewportLayout.Entities[index], ref copiedEnt);
        CustomData customData = (CustomData) new ClipperOffset();
        copiedEnt.EntityData = (object) customData;
        ((MostClosestPointOption) ((F_ControlUIDataGridView) this).Material).Entities.Add(copiedEnt);
      }
      ((F_ControlUIProgress) this).Apply();
      ((F_ControlUIDataGridView) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ControlUIGroup) this).btn_cancel.Name))
      return;
    ((F_ControlUIDataGridView) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIDataGridView) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u0018.\u0002.\u0007.\u0001((F_DoorMat) this);
    ((F_ControlUIGroup) this).btn_ok.Enabled = true;
    ((F_ControlUIDataGridView) this).\u0001.Enabled = false;
  }
}
