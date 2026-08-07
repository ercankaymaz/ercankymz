// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_CabinetCycle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_CabinetCycle : Form
{
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal Label \u0008;

  public F_CabinetCycle()
  {
    ((F_KeyPadCharV1) this).PropertiesForm = new FormProperties();
    ((F_KeyPadCharV1) this).ReturnVal = 0.0;
    ((F_KeyPadCharV1) this).Preset1 = 0.01;
    ((F_KeyPadCharV1) this).Preset2 = 0.1;
    ((F_KeyPadCharV1) this).Preset3 = 1.0;
    ((F_KeyPadCharV1) this).Preset4 = 5.0;
    ((F_KeyPadCharV1) this).Preset5 = 10.0;
    ((F_KeyPadCharV1) this).Preset6 = 45.0;
    ((F_KeyPadCharV1) this).Preset7 = 100.0;
    ((F_KeyPadCharV1) this).Preset8 = 500.0;
    ((F_KeyPadCharV1) this).Preset9 = 1000.0;
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Preset) this);
  }

  public void Init()
  {
    ((F_KeyPadCharV1) this).PropertiesForm.Inited = false;
    if (((F_KeyPadCharV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_KeyPadCharV1) this).PropertiesForm.Height;
    if (((F_KeyPadCharV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_KeyPadCharV1) this).PropertiesForm.Width;
    this.TopMost = ((F_KeyPadCharV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_KeyPadCharV1) this).PropertiesForm.FormPosition;
    ((F_KeyPadCharV1) this).btn_preset1.Text = ((F_KeyPadCharV1) this).Preset1.ToString();
    ((F_KeyPadCharV1) this).btn_preset1.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset1;
    ((F_KeyPadCharV1) this).btn_preset2.Text = ((F_KeyPadCharV1) this).Preset2.ToString();
    ((F_KeyPadCharV1) this).btn_preset2.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset2;
    ((F_KeyPadCharV1) this).btn_preset3.Text = ((F_KeyPadCharV1) this).Preset3.ToString();
    ((F_KeyPadCharV1) this).btn_preset3.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset3;
    ((F_KeyPadCharV1) this).btn_preset4.Text = ((F_KeyPadCharV1) this).Preset4.ToString();
    ((F_KeyPadCharV1) this).btn_preset4.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset4;
    ((F_KeyPadCharV1) this).btn_preset5.Text = ((F_KeyPadCharV1) this).Preset5.ToString();
    ((F_KeyPadCharV1) this).btn_preset5.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset5;
    ((F_KeyPadCharV1) this).btn_preset6.Text = ((F_KeyPadCharV1) this).Preset6.ToString();
    ((F_KeyPadCharV1) this).btn_preset6.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset6;
    ((F_KeyPadCharV1) this).btn_preset7.Text = ((F_KeyPadCharV1) this).Preset7.ToString();
    ((F_KeyPadCharV1) this).btn_preset7.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset7;
    ((F_KeyPadCharV1) this).btn_preset8.Text = ((F_KeyPadCharV1) this).Preset8.ToString();
    ((F_KeyPadCharV1) this).btn_preset8.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset8;
    ((F_KeyPadCharV1) this).btn_preset9.Text = ((F_KeyPadCharV1) this).Preset9.ToString();
    ((F_KeyPadCharV1) this).btn_preset9.Aux.ValDouble = ((F_KeyPadCharV1) this).Preset9;
    this.LoadLanguage();
    ((F_KeyPadCharV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_KeyPadCharV1) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.Text = buLangTranslate.preDef.Preset;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_KeyPadCharV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_KeyPadCharV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_KeyPadCharV1) this).ReturnVal = (obj0 as buButton).Aux.ValDouble;
    ((F_KeyPadCharV1) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_KeyPadCharV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_KeyPadCharV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KeyPadCharV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KeyPadCharV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CabinetCycle() => F_KeyPadCharV1.Captions = new List<string>();
}
