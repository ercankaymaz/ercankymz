// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCam
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

public class F_MarbleProfileCam : Form
{
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenueditor;
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buLabel lbl_contourtype;
  public static byte f001ED0;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public string BackupFolder;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_close;
  internal buListBox \u0001;
  internal buButton \u0002;
  internal buButton \u0003;
  internal buButton \u0004;
  internal buButton \u0005;
  public static byte f001EDD;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_pointerundo;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_pointerclosedraw;
  public buButton btn_pointeraddcircle;
  public buCheckBox chk_pointerarcmode;
  public buSpin spn_pointerdiameter;
  public buButton btn_pointergostart;
  public buCheckBox chk_pointerinsidearea;
  public buButton btn_pointeraddpoint;
  public buButton btn_pointerok;
  public static byte f001EEF;
  public static List<string> Captions;
  public marbleCutRemainMaterial Settings;
  public marbleMaterialPars SettingsMaterial;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  public buSpin spn_materialcutheight;
  public buSpin spn_matrialcutWidth;
  public buSpin spn_verticaloffset;
  public buSpin spn_horizontaloffset;
  public buButton btn_close;
  public buCheckBox chk_verticalcutenable;
  public buCheckBox chk_horizontalcutenable;
  public buCheckBox chk_pasueaftercut;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal buSeparator \u0001;
  public buSpin spn_materialheight;
  public buSpin spn_materialwidth;
  public buSpin spn_materialverlimit;
  public buSpin spn_materialhorlimit;
  public static byte f001F07;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleTapPars varSettings;
  public MarbleToolType ToolType;
  internal IContainer \u0001;
  internal ImageList \u0001;

  internal void \u0001([In] object obj0, [In] TreeViewCancelEventArgs obj1)
  {
    AppBool.TreeExpanding = true;
  }

  internal void \u0002([In] object obj0, [In] TreeViewCancelEventArgs obj1)
  {
    AppBool.TreeCollapsing = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleTap) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleTap) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileCam() => F_MarbleCutRemailMaterial.Captions = new List<string>();

  public F_MarbleProfileCam()
  {
    ((F_MarbleSawMillingCam) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleSawMillingCam) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleSawMillingCam) this).PropertiesForm = new FormProperties();
    ((F_MarbleSawMillingCam) this).Hole = (DiameterDepthPoint) new ShapeUpdateArg();
    ((F_MarbleSawMillingCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleHoleData) this);
  }

  public void Init()
  {
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSawMillingCam) this).PropertiesForm.Height;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSawMillingCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSawMillingCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSawMillingCam) this).PropertiesForm.FormPosition;
    ((F_MarbleSawMillingCam) this).spn_depth.Value = ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Depth;
    ((F_MarbleSawMillingCam) this).spn_dia.Value = ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Diameter;
    ((F_MarbleSawMillingCam) this).spn_x.Value = ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.X;
    ((F_MarbleSawMillingCam) this).spn_y.Value = ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.Y;
    ((F_MarbleSawMillingCam) this).spn_z.Value = ((SortResolutionSet) ((F_MarbleSawMillingCam) this).Hole).Position.Z;
    this.LoadLanguage();
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_MarbleSawMillingCam.Captions.Count <= 14)
        return;
      ((F_MarbleSawMillingCam) this).\u0001.Text = F_MarbleSawMillingCam.Captions[0];
      ((F_MarbleSawMillingCam) this).btn_ok.Text = F_MarbleSawMillingCam.Captions[13];
      ((F_MarbleSawMillingCam) this).btn_cancel.Text = F_MarbleSawMillingCam.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
