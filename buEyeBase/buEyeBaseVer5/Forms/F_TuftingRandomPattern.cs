// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_TuftingRandomPattern
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Watch;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_TuftingRandomPattern : Form
{
  public static byte f001040;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<RoboticSurfacePoint> SurfPoints;
  public bool isTangent;
  private int \u0001;
  private int \u0002;
  internal IContainer \u0001;
  internal DataGridView \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;

  static F_TuftingRandomPattern() => F_TuftingExchange.Captions = new List<string>();

  public F_TuftingRandomPattern()
  {
    ((F_TuftingSetProps) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PreviewMulti) this);
    ((F_TuftingSetProps) this).viewport_preview.CreateControl();
    ((F_TuftingSetProps) this).viewport_preview.CreateGraphics();
  }

  public void Init()
  {
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].SetView(viewType.Trimetric);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].DisplayMode = displayType.Flat;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].Camera.ProjectionMode = projectionType.Orthographic;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240 /*0xF0*/, 235, 211), 0.75, (Image) null, colorThemeType.Auto, 0.33);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].Grid.Visible = false;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[0].ZoomFit(5);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].SetView(viewType.Top);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].DisplayMode = displayType.Flat;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].Camera.ProjectionMode = projectionType.Orthographic;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240 /*0xF0*/, 235, 211), 0.75, (Image) null, colorThemeType.Auto, 0.33);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].Grid.Visible = false;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[1].ZoomFit(5);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].SetView(viewType.Right);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].DisplayMode = displayType.Flat;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].Camera.ProjectionMode = projectionType.Orthographic;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240 /*0xF0*/, 235, 211), 0.75, (Image) null, colorThemeType.Auto, 0.33);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].Grid.Visible = false;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[2].ZoomFit(5);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].SetView(viewType.Front);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].DisplayMode = displayType.Flat;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].Camera.ProjectionMode = projectionType.Orthographic;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240 /*0xF0*/, 235, 211), 0.75, (Image) null, colorThemeType.Auto, 0.33);
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].Grid.Visible = false;
    ((F_TuftingSetProps) this).viewport_preview.Viewports[3].ZoomFit(5);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingSetProps) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingSetProps) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_TuftingRandomPattern()
  {
    ((F_TuftingSetProps) this).PropertiesForm = new FormProperties();
    ((F_TuftingSetProps) this).Setting = (QuiltingRuntimeSettings) new buNestingPartAddData();
    ((F_TuftingSetProps) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_QuiltingSetProperties) this);
  }

  public void Init()
  {
    ((F_TuftingSetProps) this).PropertiesForm.Inited = false;
    if (((F_TuftingSetProps) this).PropertiesForm.Height > 10)
      this.Height = ((F_TuftingSetProps) this).PropertiesForm.Height;
    if (((F_TuftingSetProps) this).PropertiesForm.Width > 10)
      this.Width = ((F_TuftingSetProps) this).PropertiesForm.Width;
    this.TopMost = ((F_TuftingSetProps) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_TuftingSetProps) this).PropertiesForm.FormPosition;
    if (((DrillCNCSettings) ((F_TuftingSetProps) this).Setting).Heads == quiltingHeadType.First)
      ((F_TuftingSetProps) this).\u0002.Checked = true;
    else if (((DrillCNCSettings) ((F_TuftingSetProps) this).Setting).Heads == quiltingHeadType.Second)
      ((F_TuftingSetProps) this).\u0003.Checked = true;
    else
      ((F_TuftingSetProps) this).\u0001.Checked = true;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_TuftingSetProps) this).PropertiesForm.Result = DialogResult.None;
    ((F_TuftingSetProps) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_TuftingSetProps.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_TuftingSetProps) this).btn_ok.Name)
    {
      ((F_WatchByGrid) this).Apply();
      ((F_TuftingSetProps) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_TuftingSetProps) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingSetProps) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_TuftingSetProps) this).btn_cancel.Name))
      return;
    ((F_TuftingSetProps) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_TuftingSetProps) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_TuftingSetProps) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }
}
