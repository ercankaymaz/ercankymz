// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCounterTopMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCounterTopMenu : Form
{
  public TabPage tabPage_magazine;
  public buLabel lbl_tool1;
  public buLabel lbl_tool6;
  public buLabel lbl_tool5;
  public buLabel lbl_tool4;
  public buLabel lbl_tool3;
  public buLabel lbl_tool2;
  public buLabel lbl_toolspeed;
  public buLabel lbl_tooldia;
  public buLabel lbl_toollen;
  internal TabPage \u0001;
  public buSpin spn_toolZ6;
  public buSpin spn_toolY6;
  public buSpin spn_toolX6;
  public buSpin spn_toolZ5;
  public buSpin spn_toolY5;
  public buSpin spn_toolX5;
  public buSpin spn_toolZ4;
  public buSpin spn_toolY4;
  public buSpin spn_toolX4;
  public buSpin spn_toolZ3;
  public buSpin spn_toolY3;
  public buSpin spn_toolX3;
  public buSpin spn_toolZ2;

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleToolSpindleAndMagazine) this).Properties.Inited)
      ;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCounterTopMenu() => F_MarbleToolSpindleAndMagazine.Captions = new List<string>();

  public F_MarbleCounterTopMenu()
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolSpindleAndMagazine) this).Language = 0;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleLanguageMenu) this);
  }

  public void Init()
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleToolSpindleAndMagazine) this).btn_cn.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_de.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_en.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_es.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_fr.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_it.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_tr.Check = false;
    ((F_MarbleToolSpindleAndMagazine) this).btn_bae.Check = false;
    if (((F_MarbleToolSpindleAndMagazine) this).Language == 0)
      ((F_MarbleToolSpindleAndMagazine) this).btn_en.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 1)
      ((F_MarbleToolSpindleAndMagazine) this).btn_tr.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 2)
      ((F_MarbleToolSpindleAndMagazine) this).btn_cn.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 3)
      ((F_MarbleToolSpindleAndMagazine) this).btn_de.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 4)
      ((F_MarbleToolSpindleAndMagazine) this).btn_it.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 5)
      ((F_MarbleToolSpindleAndMagazine) this).btn_es.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 7)
      ((F_MarbleToolSpindleAndMagazine) this).btn_bae.Check = true;
    else if (((F_MarbleToolSpindleAndMagazine) this).Language == 8)
      ((F_MarbleToolSpindleAndMagazine) this).btn_fr.Check = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleToolSpindleAndMagazine) this).buGround1.Text = buLangTranslate.preDef.Language;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_tr.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 1;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_en.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 0;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_cn.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 2;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_de.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 3;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_it.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 4;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_es.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 5;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_bae.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 7;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_fr.Name)
      ((F_MarbleToolSpindleAndMagazine) this).Language = 8;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
