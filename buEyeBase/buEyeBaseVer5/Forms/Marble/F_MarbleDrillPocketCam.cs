// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDrillPocketCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDrillPocketCam : Form
{
  public buButton btn_viewleft;
  public buButton btn_viewright;
  public buButton btn_viewiso;
  public buButton btn_viewzoomfit;
  public buButton btn_rotate;
  public buButton btn_pan;
  internal ImageList \u0001;
  public TreeView tree_entities;
  public buLabel lbl_items;
  public buButton btn_start;
  internal buLabel \u0001;
  public buSpin spn_starty;
  internal buLabel \u0002;
  public buSpin spn_startx;
  public buButton btn_rectangle;
  public buButton btn_circle;
  public buButton btn_arc;
  public buButton btn_polyline;
  public buTab buTab1;
  internal TabPage \u0001;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Marble3DAddMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Marble3DAddMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleDrillPocketCam() => F_Marble3DAddMenu.Captions = new List<string>();

  public F_MarbleDrillPocketCam()
  {
    ((F_MarbleBackupLoad) this).PropertiesForm = new FormProperties();
    ((F_MarbleBackupLoad) this).pntList = new List<Point3D>();
    ((F_MarbleBackupLoad) this).\u0001 = (Timer) null;
    ((F_MarbleBackupLoad) this).\u0001 = DrawingTypes.None;
    ((F_MarblePointerCmd) this).\u0001 = new List<buEntity>();
    ((F_MarblePointerCmd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleVacuum) this);
    ((F_MarbleBackupLoad) this).\u0001 = new Timer();
    ((F_MarbleBackupLoad) this).\u0001.Interval = 50;
    ((F_MarbleBackupLoad) this).\u0001.Tick += new EventHandler(this.\u0001);
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_MarbleBackupLoad) this).PropertiesForm.Inited = false;
    if (((F_MarbleBackupLoad) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleBackupLoad) this).PropertiesForm.Height;
    if (((F_MarbleBackupLoad) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleBackupLoad) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleBackupLoad) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleBackupLoad) this).PropertiesForm.FormPosition;
    \u0007.\u0001.\u0001((F_MarbleVacuum) this);
    ((F_MarblePointerCmd) this).\u0001.Clear();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleVacuum) this);
    ((F_MarbleBackupLoad) this).\u0001.Enabled = true;
    ((F_MarbleBackupLoad) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleBackupLoad) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleVacuum) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleBackupLoad) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleBackupLoad) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleCutRemailMaterial) this).btn_rotate.Name)
      {
        if (buEyeItems.viewportDialogs.ActionMode == actionType.Rotate)
          buEyeItems.viewportDialogs.ActionMode = actionType.None;
        else
          buEyeItems.viewportDialogs.ActionMode = actionType.Rotate;
      }
      else if (control.Name == ((F_MarbleCutRemailMaterial) this).btn_pan.Name)
      {
        if (buEyeItems.viewportDialogs.ActionMode == actionType.Pan)
          buEyeItems.viewportDialogs.ActionMode = actionType.None;
        else
          buEyeItems.viewportDialogs.ActionMode = actionType.Pan;
      }
      else if (control.Name == ((F_MarblePointerCmd) this).btn_viewtop.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Top);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarblePointerCmd) this).btn_viewfront.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Front);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarblePointerCmd) this).btn_viewback.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Rear);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarblePointerCmd) this).btn_viewleft.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Left);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarblePointerCmd) this).btn_viewright.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Right);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleCutRemailMaterial) this).btn_viewiso.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleCutRemailMaterial) this).btn_viewzoomfit.Name)
      {
        buEyeItems.viewportDialogs.ZoomFit(10);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else
      {
        if (control.Name == ((F_MarbleCutRemailMaterial) this).btn_clear.Name && buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
        {
          ((F_MarbleBackupLoad) this).pntList.Clear();
          buEyeItems.viewportDialogs.Entities.Clear();
          buEyeItems.viewportDialogs.Invalidate();
        }
        if (control.Name == ((F_MarblePointerCmd) this).btn_settings.Name)
          ;
        if (control.Name == ((F_MarblePointerCmd) this).btn_ok.Name)
        {
          \u0007.\u0001.\u0001((F_MarbleVacuum) this);
          ((F_MarbleBackupLoad) this).PropertiesForm.Result = DialogResult.OK;
          if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
        if (!(control.Name == ((F_MarblePointerCmd) this).btn_cancel.Name | control.Name == ((F_MarblePointerCmd) this).btn_close.Name))
          return;
        ((F_MarbleBackupLoad) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleBackupLoad) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }
}
