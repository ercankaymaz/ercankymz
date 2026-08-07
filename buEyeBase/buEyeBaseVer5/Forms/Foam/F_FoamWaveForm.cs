// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamWaveForm
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.GCode;
using buEyeBaseVer5.Forms.Holes;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamWaveForm : Form
{
  public drillCommands Commands;
  public drillCommandBase CommandsBase;
  public static List<string> Captions;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  public static byte f002FFD;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public DrillCNCSettings varCNC;
  internal IContainer \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal NumericUpDown \u0003;
  internal Label \u0003;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal Label \u0005;
  internal CheckBox \u0001;
  internal ImageList \u0001;
  public Button btn_ok;
  public Button btn_cancel;
  public static byte f00300F;
  private IContainer \u0001;
  internal TabControl \u0001;
  internal Label \u0001;
  internal Label \u0002;
  public TabPage tabPage_drill;
  public Label lbl_slotmode1_usemilling;
  public CheckBox chk_slotmode1_usemilling;
  public Label lbl_slotmode_length;
  public NumericUpDown spn_slotmode_length;
  public NumericUpDown spn_slotmode1_x;
  public NumericUpDown spn_slotmode1_y;
  public NumericUpDown spn_slotmode1_depth;
  public Label lbl_slotmode1_width;
  public Label lbl_slotmode1_depth;
  public NumericUpDown spn_slotmode1_width;
  public Label lbl_drillmode1_distancedrill;
  public NumericUpDown spn_drillmode1_distancedrill;
  public Label lbl_drillmode1_drillcount;
  public NumericUpDown spn_drillmode1_drillcount;
  public NumericUpDown spn_drillmode1_holex;
  public Label lbl_drillmode1_holex;
  public NumericUpDown spn_drillmode1_holey;
  public Label lbl_drillmode1_holey;
  public NumericUpDown spn_drillmode1_holez;
  public Label lbl_drillmode1_holez;
  public NumericUpDown spn_drillmode1_holedepth;
  public Label lbl_drillmode1_holediameter;
  public Label lbl_drillmode1_holedepth;
  public NumericUpDown spn_drillmode1_holediameter;
  public Label label22;
  public NumericUpDown spn_rectangleheight;
  public NumericUpDown spn_rectanglex;
  public Label label10;
  public NumericUpDown spn_rectangley;
  public Label label11;
  public NumericUpDown spn_rectanglez;
  public Label label12;
  public NumericUpDown spn_rectangledepth;
  public Label label13;
  public Label label14;
  public NumericUpDown spn_rectanglewidth;
  public Label label21;
  public CheckBox chk_circleisdrill;
  public NumericUpDown spn_circlex;
  public Label label16;
  public NumericUpDown spn_circley;

  public F_FoamWaveForm()
  {
    ((F_FoamGCodeConverter) this).PropertiesForm = new FormProperties();
    ((F_FoamSpeedList) this).Shape = (buShape) null;
    ((F_FoamSpeedList) this).ClockType = ClockDirectionType.CW;
    ((F_FoamSpeedList) this).Degree = 90.0;
    ((F_FoamSpeedList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_RotatePanel) this);
  }

  public void Init()
  {
    ((F_FoamGCodeConverter) this).PropertiesForm.Inited = false;
    if (((F_FoamGCodeConverter) this).PropertiesForm.Height > 10)
      this.Height = ((F_FoamGCodeConverter) this).PropertiesForm.Height;
    if (((F_FoamGCodeConverter) this).PropertiesForm.Width > 10)
      this.Width = ((F_FoamGCodeConverter) this).PropertiesForm.Width;
    this.TopMost = ((F_FoamGCodeConverter) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_FoamGCodeConverter) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    if (((F_FoamSpeedList) this).Degree == 180.0)
    {
      ((F_FoamSpeedList) this).radio_180.Checked = true;
      ((F_FoamSpeedList) this).radio_90.Checked = false;
    }
    else
    {
      ((F_FoamSpeedList) this).radio_180.Checked = false;
      ((F_FoamSpeedList) this).radio_90.Checked = true;
    }
    if (((F_FoamSpeedList) this).ClockType == ClockDirectionType.CW)
    {
      ((F_FoamSpeedList) this).radio_ccw.Checked = false;
      ((F_FoamSpeedList) this).radio_cw.Checked = true;
    }
    else
    {
      ((F_FoamSpeedList) this).radio_ccw.Checked = true;
      ((F_FoamSpeedList) this).radio_cw.Checked = false;
    }
    ((F_FoamGCodeConverter) this).PropertiesForm.Result = DialogResult.None;
    ((F_FoamGCodeConverter) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Rotate;
      ((F_FoamSpeedList) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_FoamSpeedList) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    if (((F_FoamSpeedList) this).radio_cw.Checked)
      ((F_FoamSpeedList) this).ClockType = ClockDirectionType.CW;
    else
      ((F_FoamSpeedList) this).ClockType = ClockDirectionType.CCW;
    if (((F_FoamSpeedList) this).radio_90.Checked)
      ((F_FoamSpeedList) this).Degree = 90.0;
    else
      ((F_FoamSpeedList) this).Degree = 180.0;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_FoamGCodeConverter) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_FoamGCodeConverter) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSpeedList) this).btn_ok.Name)
    {
      this.Apply();
      ((F_FoamGCodeConverter) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_FoamSpeedList) this).btn_cancel.Name))
        return;
      ((F_FoamGCodeConverter) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamGCodeConverter) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamSpeedList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSpeedList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamWaveForm() => F_FoamGCodeConverter.Captions = new List<string>();

  public F_FoamWaveForm()
  {
    ((F_FoamSpeedList) this).PropertiesForm = new FormProperties();
    ((F_FoamSpeedList) this).Shape = (buShape) null;
    ((F_FoamSlicesList) this).MirrorType = MirrorBoxType.Plane;
    ((F_FoamSlicesList) this).newPlane = planeBoxNames.Top;
    ((F_FoamSlicesList) this).newCorner = CornerLocation.BottomCenter;
    ((F_FoamSlicesList) this).\u0001 = CornerLocation.BottomCenter;
    ((F_FoamSlicesList) this).\u0002 = CornerLocation.BottomCenter;
    ((F_FoamSlicesList) this).CopyAsNew = false;
    ((F_FoamSlicesList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MirrorOP) this);
  }

  public void Init()
  {
    ((F_FoamSpeedList) this).PropertiesForm.Inited = false;
    if (((F_FoamSpeedList) this).PropertiesForm.Height > 10)
      this.Height = ((F_FoamSpeedList) this).PropertiesForm.Height;
    if (((F_FoamSpeedList) this).PropertiesForm.Width > 10)
      this.Width = ((F_FoamSpeedList) this).PropertiesForm.Width;
    this.TopMost = ((F_FoamSpeedList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_FoamSpeedList) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_FoamSlicesList) this).btn_oldver.Enabled = true;
    ((F_FoamSlicesList) this).btn_newver.Enabled = true;
    ((F_FoamWaveMenu) this).radio_vertical.Enabled = true;
    ((F_FoamWaveMenu) this).radio_horizontal.Enabled = true;
    if (((F_FoamSlicesList) this).MirrorType == MirrorBoxType.Plane)
      ((F_FoamWaveMenu) this).radio_plane.Checked = true;
    if (((F_FoamSlicesList) this).MirrorType == MirrorBoxType.Horizotal)
      ((F_FoamWaveMenu) this).radio_horizontal.Checked = true;
    if (((F_FoamSlicesList) this).MirrorType == MirrorBoxType.Vertical)
      ((F_FoamWaveMenu) this).radio_vertical.Checked = true;
    ((F_FoamWaveMenu) this).chk_copynew.Checked = ((F_FoamSlicesList) this).CopyAsNew;
    if (((F_FoamSpeedList) this).Shape != null)
    {
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Top)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 0;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 1;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Bottom;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Bottom)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 1;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 0;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Top;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Front)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 2;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 3;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Back;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Back)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 3;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 2;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Front;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Left)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 4;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 5;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Right;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).planeName == planeBoxNames.Right)
      {
        ((F_FoamSlicesList) this).btn_oldplane.ImageIndex = 5;
        ((F_FoamWaveMenu) this).btn_newplane.ImageIndex = 4;
        ((F_FoamSlicesList) this).newPlane = planeBoxNames.Left;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.TopCenter)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = -1;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 6;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 7;
        ((F_FoamWaveMenu) this).btn_oldhor.Enabled = false;
        ((F_FoamWaveMenu) this).btn_newhor.Enabled = false;
        ((F_FoamWaveMenu) this).radio_horizontal.Enabled = false;
        ((F_FoamWaveMenu) this).radio_vertical.Checked = true;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.BottomCenter;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.BottomCenter)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = -1;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 7;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 6;
        ((F_FoamWaveMenu) this).btn_oldhor.Enabled = false;
        ((F_FoamWaveMenu) this).btn_newhor.Enabled = false;
        ((F_FoamWaveMenu) this).radio_horizontal.Enabled = false;
        ((F_FoamWaveMenu) this).radio_vertical.Checked = true;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.TopCenter;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.LeftCenter)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 8;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 9;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_oldver.Enabled = false;
        ((F_FoamSlicesList) this).btn_newver.Enabled = false;
        ((F_FoamWaveMenu) this).radio_vertical.Enabled = false;
        ((F_FoamWaveMenu) this).radio_horizontal.Checked = true;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.RightCenter;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.RightCenter)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 9;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 8;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = -1;
        ((F_FoamSlicesList) this).btn_oldver.Enabled = false;
        ((F_FoamSlicesList) this).btn_newver.Enabled = false;
        ((F_FoamWaveMenu) this).radio_vertical.Enabled = false;
        ((F_FoamWaveMenu) this).radio_horizontal.Checked = true;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.LeftCenter;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.RightTop)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 13;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 12;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 13;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 11;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.RightBottom;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.LeftTop;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.RightBottom)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 11;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 12;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 11;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 10;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.RightTop;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.LeftBottom;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.LeftTop)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 12;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 13;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 12;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 10;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.LeftBottom;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.RightTop;
      }
      if (((buClipperBase) ((F_FoamSpeedList) this).Shape).Corner == CornerLocation.LeftBottom)
      {
        ((F_FoamWaveMenu) this).btn_oldhor.ImageIndex = 10;
        ((F_FoamWaveMenu) this).btn_newhor.ImageIndex = 11;
        ((F_FoamSlicesList) this).btn_oldver.ImageIndex = 10;
        ((F_FoamSlicesList) this).btn_newver.ImageIndex = 12;
        ((F_FoamSlicesList) this).\u0002 = CornerLocation.LeftTop;
        ((F_FoamSlicesList) this).\u0001 = CornerLocation.RightBottom;
      }
    }
    ((F_FoamSpeedList) this).PropertiesForm.Result = DialogResult.None;
    ((F_FoamSpeedList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Mirror;
      ((F_FoamWaveMenu) this).radio_horizontal.Text = buLangTranslate.preDef.Horizontal;
      ((F_FoamWaveMenu) this).radio_plane.Text = buLangTranslate.preDef.Plane;
      ((F_FoamWaveMenu) this).radio_vertical.Text = buLangTranslate.preDef.Vertical;
      ((F_FoamSlicesList) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_FoamSlicesList) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_FoamWaveMenu) this).chk_copynew.Text = $"{buLangTranslate.preDef.Copy} {buLangTranslate.preDef.New}";
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    if (((F_FoamWaveMenu) this).radio_plane.Checked)
      ((F_FoamSlicesList) this).MirrorType = MirrorBoxType.Plane;
    else if (((F_FoamWaveMenu) this).radio_horizontal.Checked)
    {
      ((F_FoamSlicesList) this).MirrorType = MirrorBoxType.Horizotal;
      ((F_FoamSlicesList) this).newCorner = ((F_FoamSlicesList) this).\u0001;
    }
    else if (((F_FoamWaveMenu) this).radio_vertical.Checked)
    {
      ((F_FoamSlicesList) this).MirrorType = MirrorBoxType.Vertical;
      ((F_FoamSlicesList) this).newCorner = ((F_FoamSlicesList) this).\u0002;
    }
    ((F_FoamSlicesList) this).CopyAsNew = ((F_FoamWaveMenu) this).chk_copynew.Checked;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_FoamSpeedList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_FoamSpeedList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSlicesList) this).btn_ok.Name)
    {
      this.Apply();
      ((F_FoamSpeedList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_FoamSlicesList) this).btn_cancel.Name))
        return;
      ((F_FoamSpeedList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamSpeedList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamSlicesList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSlicesList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamWaveForm() => F_FoamSpeedList.Captions = new List<string>();

  public event OkCommandWithTwoDataEventHandler DataChanged;

  public event OkCommandWithTwoDataEventHandler ParameterChanged;

  public event CancelCommandEventHandler DataCancel;
}
