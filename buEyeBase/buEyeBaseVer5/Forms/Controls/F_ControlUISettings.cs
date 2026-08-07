// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUISettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUISettings : Form
{
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_slotdepth;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  public buSpin spn_ZPos;
  public buSpin spn_XPos;
  public buCheckBox chk_contourcenter;
  public buCheckBox chk_contourinside;
  public buCheckBox chk_tool3;
  public buCheckBox chk_contouroutside;
  public buCheckBox chk_tool2;
  public buCheckBox chk_tool1;
  public buSpin spn_step;
  internal buGroup \u0001;
  public buSpin spn_cuttingfeed;
  public buSpin spn_rapiddis;
  public buSpin spn_plungefeed;
  public buSpin spn_safedis;
  public FormProperties Properties;
  public static List<string> Captions;
  public double ZPos;
  public double Depth;
  public double X1Pos;
  public double X2Pos;
  public double SafeDis;
  public double RapidDis;
  public double PlungeFeed;
  public double CuttingFeed;
  public HorizontalDirectionType Dir;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buCheckBox chk_linerighttoleft;
  public buCheckBox chk_linelefttorigth;
  public buSpin spn_linedepth;
  public buSpin spn_zpos;
  public buSpin spn_x2Pos;
  public buSpin spn_x1pos;
  internal buGroup \u0001;
  public buSpin spn_cuttingfeed;
  public buSpin spn_rapiddis;
  public buSpin spn_plungefeed;
  public buSpin spn_safedis;
  public FormProperties Properties;
  public static List<string> Captions;
  public double Width;
  public double StartHeight;
  public double EndHeight;
  public double Depth;
  public double XPos;
  public double ZOffset;
  public double XOffset;
  public double SafeDis;
  public double RapidDis;
  public double PlungeFeed;
  public double CuttingFeed;
  public LeftMiddleRightLocationType OpLocation;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buCheckBox chk_vmiddle;
  public buCheckBox chk_vright;
  public buCheckBox chk_vleft;
  public buSpin spn_vcleaningendheight;
  public buSpin spn_vcleaningdepth;
  public buSpin spn_vcleaningstartheight;
  public buSpin spn_vcleaningwidth;
  public buSpin spn_xpos;
  public buSpin spn_ZOffset;
  internal buGroup \u0001;
  public buSpin spn_cuttingfeed;
  public buSpin spn_rapiddis;
  public buSpin spn_plungefeed;
  public buSpin spn_safedis;
  public buSpin spn_xoffset;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buCheckBox refCheck;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buControlDisplaySet \u0002;
  internal buControlDisplaySet \u0003;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buCheckBox \u0001;
  internal buCheckBox \u0002;
  public buSpin spn_iconsize;
  internal buCheckBox \u0003;
  internal buCheckBox \u0004;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  public buLabel lbl_val;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if ((obj0 as Control).Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).pnl_ref.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).pnl_ref.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).pnl_ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).pnl_ref.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).pnl_ref.ImageAlign = result1;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUISettings() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_ControlUISettings()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).refList = (buListBox) null;
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUIListbox) this);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    ((F_CamTriMeshSettings) this).\u0001.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    if (((F_CamTriMeshSettings) this).refList != null)
    {
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).refList.Display;
      ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((F_CamTriMeshSettings) this).refList.Geometry.ArcDiameter;
      ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((F_CamTriMeshSettings) this).refList.Geometry.ShapeMode;
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    }
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIListbox) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name))
          return;
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }
}
