// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSingleCut
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

public class F_MarbleSingleCut : Form
{
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public CamTriangularMeshType MeshType;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buCheckBox chk_constantZ;
  public buCheckBox chk_parallelcut;
  public buCheckBox chk_rough;
  public buCheckBox chk_none;
  public static byte f0021B3;
  public Color SpinBaseColor;

  public void Init()
  {
    ((F_MarbleShapeAll) this).Properties.Inited = false;
    if (((F_MarbleShapeAll) this).Properties.Height > 10)
      this.Height = ((F_MarbleShapeAll) this).Properties.Height;
    if (((F_MarbleShapeAll) this).Properties.Width > 10)
      this.Width = ((F_MarbleShapeAll) this).Properties.Width;
    this.TopMost = ((F_MarbleShapeAll) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleShapeAll) this).Properties.FormPosition;
    ((F_MarbleShapeAll) this).Properties.Result = DialogResult.None;
    ((F_MarbleShapeAll) this).Properties.Inited = true;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    ((F_MarbleCuttingSequence) this).lbl_count.Text = buLangTranslate.preDef.Count;
    ((F_MarbleCuttingSequence) this).lbl_ea.Text = buLangTranslate.preDef.EndAngle;
    ((F_MarbleSawCutParameters) this).\u0001.Text = buLangTranslate.preDef.Information;
    ((F_MarbleCuttingSequence) this).lbl_length.Text = buLangTranslate.preDef.Width;
    ((F_MarbleCuttingSequence) this).lbl_sa.Text = buLangTranslate.preDef.StartAngle;
    ((F_MarbleSawCutParameters) this).btn_addtolist.Text = buLangTranslate.preDef.AddToList;
    ((F_MarbleCuttingSequence) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_MarbleSawCutParameters) this).btn_itemendpos.Text = buLangTranslate.preDef.EndPoint;
    ((F_MarbleCuttingSequence) this).btn_itemok.Text = buLangTranslate.preDef.Ok;
    ((F_MarbleSawCutParameters) this).btn_itemstartpos.Text = buLangTranslate.preDef.StartPoint;
    ((F_MarbleCircularShapeResolution) this).btn_open.Text = buLangTranslate.preDef.Open;
    ((F_MarbleSawCutParameters) this).btn_save.Text = buLangTranslate.preDef.Save;
    ((F_MarbleSawCutParameters) this).spn_angle.Caption.Caption = buLangTranslate.preDef.Angle;
    ((F_MarbleShapeAll) this).spn_itemlength.Caption.Caption = buLangTranslate.preDef.Length;
    ((F_MarbleSawCutParameters) this).spn_xoffset.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Offset}";
    ((F_MarbleSawCutParameters) this).spn_yoffset.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Offset}";
    ((F_MarbleSawCutParameters) this).chk_cutend.Text = $"{buLangTranslate.preDef.End} {buLangTranslate.preDef.Cutting}";
    ((F_MarbleSawCutParameters) this).chk_cutstart.Text = $"{buLangTranslate.preDef.Start} {buLangTranslate.preDef.Cutting}";
    this.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Cutting}";
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleShapeAll) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleShapeAll) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleShapeAll) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleShapeAll) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (!((F_MarbleShapeAll) this).isDialog)
        return;
      if (control2.Name == ((F_MarbleCuttingSequence) this).btn_itemok.Name)
      {
        ((F_MarbleShapeAll) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleShapeAll) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleShapeAll) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleCircularShapeResolution) this).btn_close.Name)
      {
        ((F_MarbleShapeAll) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleShapeAll) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleShapeAll) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleCircularShapeResolution) this).btn_maximize.Name)
        this.WindowState = FormWindowState.Maximized;
      if (!(control2.Name == ((F_MarbleCircularShapeResolution) this).btn_minimise.Name))
        return;
      this.WindowState = FormWindowState.Normal;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleShapeAll) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleShapeAll) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSingleCut() => F_MarbleShapeAll.Captions = new List<string>();
}
