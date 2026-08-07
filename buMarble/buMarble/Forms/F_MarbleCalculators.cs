// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleCalculators
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleCalculators : Form
{
  public Color SpinFocusColor;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public int SelectedTab;
  internal IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_closecross;
  internal ImageList \u0001;
  public Color SpinBaseColor = Color.LightGreen;
  public Color SpinFocusColor = Color.MistyRose;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  public int SelectedTab = 0;
  internal IContainer \u0001 = (IContainer) null;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buTab buTab_tools;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  public buButton btn_sawdiscalculate;
  public buSpin spn_sawdistooldiameter;
  internal Panel \u0001;
  internal PictureBox \u0001;
  public buButton btn_pointmove;
  public buButton btn_sawdistance;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.\u0001.Controls);
    this.SelectedTab = PageIndex;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (!((obj0 as Control).Name == this.btn_closecross.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleCalculators() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_tools.ItemSize = new Size(1, 1);
    this.spn_sawdistooldiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
    ((F_MarbleGantryMove) this).spn_sawdismaterialdistance.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
    ((F_MarbleGantryMove) this).spn_sawdistargetz.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
    this.LoadLanguage();
    ((F_MarbleGantryMove) this).MenuButtonColors(this.SelectedTab);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.\u0001.Text = buLangTranslate.preDef.Calculate;
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
      this.btn_sawdistance.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Distance}";
      this.btn_sawdiscalculate.Text = buLangTranslate.preDef.Calculate;
      this.spn_sawdistooldiameter.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleGantryMove) this).spn_sawdisAAngle.Caption.Caption = $"{buLangTranslate.preChar.A} {buLangTranslate.preDef.Angle}";
      ((F_MarbleGantryMove) this).spn_sawdiscalculatedvalue.Caption.Caption = $"{buLangTranslate.preDef.Calculated} {buLangTranslate.preDef.Value}";
      ((F_MarbleGantryMove) this).spn_sawdismaterialdistance.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleGantryMove) this).spn_sawdissafedistance.Caption.Caption = $"{buLangTranslate.preDef.Safe} {buLangTranslate.preDef.Length}";
      ((F_MarbleGantryMove) this).spn_sawdistargetz.Caption.Caption = $"{buLangTranslate.preDef.Target} {buLangTranslate.preChar.Z}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
