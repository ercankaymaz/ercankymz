// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMove : Form
{
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleEngraveMenuType EngraveType;
  public MarbleItemType ItemType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal buSeparator \u0001;

  public F_MarbleMove()
  {
    ((F_MarbleCountertopChamfer) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleCountertopChamfer) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleSingleCut) this).PropertiesForm = new FormProperties();
    ((F_MarbleSingleCut) this).MeshType = CamTriangularMeshType.Rough;
    ((F_MarbleSingleCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Marble5DCamStrategyMenu) this);
  }

  public void Init()
  {
    ((F_MarbleSingleCut) this).PropertiesForm.Inited = false;
    if (((F_MarbleSingleCut) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSingleCut) this).PropertiesForm.Height;
    if (((F_MarbleSingleCut) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSingleCut) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSingleCut) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSingleCut) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleSingleCut) this).chk_constantZ.Check = false;
    ((F_MarbleSingleCut) this).chk_parallelcut.Check = false;
    ((F_MarbleSingleCut) this).chk_rough.Check = false;
    ((F_MarbleSingleCut) this).chk_none.Check = false;
    if (((F_MarbleSingleCut) this).MeshType == CamTriangularMeshType.ConstantZ)
      ((F_MarbleSingleCut) this).chk_constantZ.Check = true;
    else if (((F_MarbleSingleCut) this).MeshType == CamTriangularMeshType.Rough)
      ((F_MarbleSingleCut) this).chk_rough.Check = true;
    else if (((F_MarbleSingleCut) this).MeshType == CamTriangularMeshType.ParallelCuts)
      ((F_MarbleSingleCut) this).chk_parallelcut.Check = true;
    else
      ((F_MarbleSingleCut) this).chk_none.Check = true;
    ((F_MarbleSingleCut) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSingleCut) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleSingleCut) this).chk_constantZ.Text = $"{buLangTranslate.preDef.ConstantZ} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleSingleCut) this).chk_parallelcut.Text = $"{buLangTranslate.preDef.ParalelCuts} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleSingleCut) this).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleSingleCut) this).chk_none.Text = buLangTranslate.preDef.None;
      ((F_MarbleSingleCut) this).\u0001.Text = $"5 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSingleCut) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSingleCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSingleCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleSingleCut) this).PropertiesForm.Inited)
      return;
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleSingleCut) this).chk_constantZ.Name)
    {
      ((F_MarbleSingleCut) this).chk_constantZ.Check = true;
      ((F_MarbleSingleCut) this).MeshType = CamTriangularMeshType.ConstantZ;
    }
    if (control.Name == ((F_MarbleSingleCut) this).chk_rough.Name)
    {
      ((F_MarbleSingleCut) this).chk_rough.Check = true;
      ((F_MarbleSingleCut) this).MeshType = CamTriangularMeshType.Rough;
    }
    if (control.Name == ((F_MarbleSingleCut) this).chk_parallelcut.Name)
    {
      ((F_MarbleSingleCut) this).chk_parallelcut.Check = false;
      ((F_MarbleSingleCut) this).MeshType = CamTriangularMeshType.ParallelCuts;
    }
    if (control.Name == ((F_MarbleSingleCut) this).chk_none.Name)
    {
      ((F_MarbleSingleCut) this).chk_none.Check = false;
      ((F_MarbleSingleCut) this).MeshType = CamTriangularMeshType.None;
    }
    ((F_MarbleSingleCut) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSingleCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSingleCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSingleCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMove() => F_MarbleSingleCut.Captions = new List<string>();

  public F_MarbleMove()
  {
    // ISSUE: unable to decompile the method.
  }

  public event OkCommandWithThreeDataEventHandler CommandExecute;
}
