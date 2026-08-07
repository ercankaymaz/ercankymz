// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCountertopChamfer
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopChamfer : Form
{
  public buLabel lbl_EAimg6;
  public buLabel lbl_SAimg6;
  public buLabel lbl_EAimg5;
  public buLabel lbl_SAimg5;
  public buLabel lbl_EAimg4;
  public buLabel lbl_SAimg4;
  public buLabel lbl_EAimg3;
  public buLabel lbl_SAimg3;
  public buLabel lbl_EAimg2;
  public buLabel lbl_SAimg2;
  public buLabel lbl_SAimg1;
  public buCheckBox chk_reversecutdir;
  public static byte f0021A6;
  public Color SpinBaseColor;
  public Color SpinFocusColor;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMilling5AxisMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMilling5AxisMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCountertopChamfer() => F_MarbleMilling5AxisMenu.Captions = new List<string>();

  public F_MarbleCountertopChamfer()
  {
    ((F_MarbleToolMillingMillingHeadMenu) this).Properties = new FormProperties();
    ((F_MarbleToolMillingMillingHeadMenu) this).isDialog = false;
    ((F_MarbleToolMillingMillingHeadMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorVerCutV3) this);
  }

  public void Init()
  {
    ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Inited = false;
    if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Height;
    if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleToolMillingMillingHeadMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormPosition;
    ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Inited = true;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    ((F_MarbleShapeAll) this).lbl_countver.Text = buLangTranslate.preDef.Count;
    ((F_MarbleShapeAll) this).lbl_eaver.Text = buLangTranslate.preDef.EndAngle;
    ((F_MarbleShapeAll) this).lbl_lengthver.Text = buLangTranslate.preDef.Width;
    ((F_MarbleShapeAll) this).lbl_saver.Text = buLangTranslate.preDef.StartAngle;
    ((F_MarbleShapeAll) this).lbl_counthor.Text = buLangTranslate.preDef.Count;
    ((F_MarbleSawMillingVertical) this).lbl_eahor.Text = buLangTranslate.preDef.EndAngle;
    ((F_MarbleSawMillingVertical) this).lbl_lengthhor.Text = buLangTranslate.preDef.Width;
    ((F_MarbleSawMillingVertical) this).lbl_sahor.Text = buLangTranslate.preDef.StartAngle;
    ((F_MarbleShapeAll) this).\u0001.Text = buLangTranslate.preDef.Information;
    ((F_MarbleShapeAll) this).btn_addtolist.Text = buLangTranslate.preDef.AddToList;
    ((F_MarbleSawMillingVertical) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_MarbleShapeAll) this).btn_itemhorverendpos.Text = buLangTranslate.preDef.EndPoint;
    ((F_MarbleSawMillingVertical) this).btn_itemhorverok.Text = buLangTranslate.preDef.Ok;
    ((F_MarbleShapeAll) this).btn_itemhorverstartpos.Text = buLangTranslate.preDef.StartPoint;
    ((F_MarbleSawMillingVertical) this).btn_horveropen.Text = buLangTranslate.preDef.Open;
    ((F_MarbleShapeAll) this).btn_horversave.Text = buLangTranslate.preDef.Save;
    ((F_MarbleToolMillingMillingHeadMenu) this).spn_itemhorlength.Caption.Caption = buLangTranslate.preDef.Length;
    ((F_MarbleShapeAll) this).spn_itemverlength.Caption.Caption = buLangTranslate.preDef.Length;
    ((F_MarbleShapeAll) this).spn_horverangle.Caption.Caption = buLangTranslate.preDef.Angle;
    ((F_MarbleShapeAll) this).spn_horverxoffset.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Offset}";
    ((F_MarbleShapeAll) this).spn_horveryoffset.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Offset}";
    ((F_MarbleShapeAll) this).tabPage_Hor.Text = buLangTranslate.preDef.Horizontal;
    ((F_MarbleShapeAll) this).tabPage_Ver.Text = buLangTranslate.preDef.Vertical;
    this.Text = $"{buLangTranslate.preDef.Horizontal} - {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Cutting}";
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (!((F_MarbleToolMillingMillingHeadMenu) this).isDialog)
        return;
      if (control2.Name == ((F_MarbleSawMillingVertical) this).btn_itemhorverok.Name)
      {
        ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleSawMillingVertical) this).btn_close.Name)
      {
        ((F_MarbleToolMillingMillingHeadMenu) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleToolMillingMillingHeadMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleSawMillingVertical) this).btn_maximize.Name))
        return;
      this.WindowState = FormWindowState.Maximized;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolMillingMillingHeadMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolMillingMillingHeadMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCountertopChamfer()
  {
    F_MarbleToolMillingMillingHeadMenu.Captions = new List<string>();
  }

  public F_MarbleCountertopChamfer()
  {
    ((F_MarbleShapeAll) this).Properties = new FormProperties();
    ((F_MarbleShapeAll) this).isHorizontal = false;
    ((F_MarbleShapeAll) this).isDialog = false;
    ((F_MarbleShapeAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorVerCutV2) this);
  }
}
