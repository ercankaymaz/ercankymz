// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventOffset
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

public class F_MarbleEventOffset : Form
{
  public buButton btn_zoomout;
  public buButton btn_zoomin;
  public TreeView tree_job;
  public Panel pnl_viewport;
  public buGround ground_base;
  public buButton btn_close;
  public static byte f001B5D;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  public void Init()
  {
    ((F_MarbleEditLength) this).PropertiesForm.Inited = false;
    if (((F_MarbleEditLength) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEditLength) this).PropertiesForm.Height;
    if (((F_MarbleEditLength) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEditLength) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEditLength) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEditLength) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEditLength) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEditLength) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEditBaseH) this).ground_base.Text = "G " + buLangTranslate.preDef.Codes;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEditLength) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEditLength) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditLength) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditLength) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleEditBaseH) this).btn_close.Name)
    {
      ((F_MarbleEditLength) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleEditLength) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEditLength) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_MarbleEditBaseH) this).btn_size_1_5.Name)
    {
      this.Width = Convert.ToInt32((double) ((F_MarbleEditLength) this).BaseWidth * 1.5);
      this.Height = Convert.ToInt32((double) ((F_MarbleEditLength) this).BaseHeight * 1.5);
    }
    if (control.Name == ((F_MarbleEditBaseH) this).btn_size_2_0.Name)
    {
      this.Width = Convert.ToInt32(((F_MarbleEditLength) this).BaseWidth * 2);
      this.Height = Convert.ToInt32((double) ((F_MarbleEditLength) this).BaseHeight * 1.7);
    }
    if (!(control.Name == ((F_MarbleEditBaseH) this).btn_normalsize.Name))
      return;
    this.Width = Convert.ToInt32(((F_MarbleEditLength) this).BaseWidth);
    this.Height = Convert.ToInt32(((F_MarbleEditLength) this).BaseHeight);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditLength) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditLength) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventOffset() => F_MarbleEditLength.Captions = new List<string>();

  public F_MarbleEventOffset()
  {
    ((F_MarbleEventBreak) this).\u0001 = "F_MarbleJobList";
    ((F_MarbleEventBreak) this).PropertiesForm = new FormProperties();
    ((F_MarbleEventBreak) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleJobList) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      ((F_MarbleEventExtend) this).LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEventBreak) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleEventBreak) this).PropertiesForm.Inited = false;
    if (((F_MarbleEventBreak) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEventBreak) this).PropertiesForm.Height;
    if (((F_MarbleEventBreak) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEventBreak) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEventBreak) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEventBreak) this).PropertiesForm.FormPosition;
    ((F_MarbleEventExtend) this).LoadLanguage();
    ((F_MarbleEventBreak) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEventBreak) this).PropertiesForm.Inited = true;
  }
}
