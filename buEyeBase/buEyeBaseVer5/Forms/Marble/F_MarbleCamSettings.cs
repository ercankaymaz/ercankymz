// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCamSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
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

public class F_MarbleCamSettings : Form
{
  public buCheckBox chk_keepratio;
  public buSpin spn_baseheight;
  public buSpin spn_minz;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleCamMode CamMode;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_startzoffset;
  public buSpin spn_endzoffset;
  public buSpin spn_scaleheight;
  public buSpin spn_scalewidth;
  public buCheckBox chk_keepratio;
  public buSpin spn_baseheight;
  public buSpin spn_minz;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buTab buTab_shape;
  public TabPage tabPage_circle;
  public buSpin spn_rotation;
  public buSpin spn_circlediameter;
  internal PictureBox \u0001;
  public buSpin spn_roundrectrad;
  public buSpin spn_roundrectheight;
  public buSpin spn_roundrectwidth;
  internal PictureBox \u0002;
  public buSpin spn_ellipseheight;
  public buSpin spn_ellipsewidth;
  internal PictureBox \u0003;
  public buSpin spn_polygondiameter;
  public buSpin spn_polygonside;
  internal PictureBox \u0004;
  public buSpin spn_trianglewidth;
  public buSpin spn_triangleheight;
  internal PictureBox \u0005;
  public buSpin spn_trapezlength1;
  public buSpin spn_trapezlength2;
  public buSpin spn_trapezheight;
  internal PictureBox \u0006;
  public TabPage tabPage_roundrect;
  public TabPage tabPage_ellipse;
  public TabPage tabPage_polygon;
  public TabPage tabPage_triangle;
  public TabPage tabPage_trapez;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  internal PictureBox \u0007;
  public TabPage tabPage_slot;
  public buSpin spn_archeight;
  public buSpin spn_arcthickns;
  internal PictureBox \u0008;
  public buSpin spn_arcoutsidelength;
  public TabPage tabPage_arc;
  public buButton btn_close;
  public buSpin spn_roundrectangle;
  public buSpin spn_circleangle;
  public buSpin spn_ellipseangle;
  public buSpin spn_polygonangle;
  public buSpin spn_trianglecrossagnle;
  public buSpin spn_trianglebottomagnle;
  public buSpin spn_triangleleftangle;
  public buSpin spn_trapezbottomangle;
  public buSpin spn_trapezrightangle;
  public buSpin spn_trapezleftangle;
  public buSpin spn_trapeztopangle;
  public buSpin spn_slotangl;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal TabPage \u0005;
  public buSpin spn_rectbottomangle;
  public buSpin spn_rectrightangle;
  public buSpin spn_rectleftangle;
  public buSpin spn_recttopangle;
  public buSpin spn_rectheight;
  public buSpin spn_rectwidth;
  internal PictureBox \u000E;
  public buSpin spn_chamferrectangle;
  public buSpin spn_chamferrectlength;
  public buSpin spn_chamferrectheight;
  public buSpin spn_chamferrectwidth;
  internal PictureBox \u000F;
  public buSpin spn_crossrectbottomangle;
  public buSpin spn_crossrectrightangl;
  public buSpin spn_crossrectleftangle;
  public buSpin spn_crossrecttopangle;
  public buSpin spn_crossrectheight;
  public buSpin spn_crossrectwidth;
  internal PictureBox \u0010;
  public buSpin spn_arcpieangle;
  public buSpin spn_arcpieradius;
  internal PictureBox \u0011;
  public buSpin spn_shiipnosebottomangl;
  public buSpin spn_shiipnoserightangle;
  public buSpin spn_shiipnoseleftangle;
  public buSpin spn_shiipnosetopangle;
  public buSpin spn_shiipnoseheight;
  public buSpin spn_shiipnosewidth;
  internal PictureBox \u0012;
  public buSpin spn_arcpiesweepangle;
  internal buPanel \u0001;
  public buSpin spn_yoffset;
  public buSpin spn_ycount;
  public buSpin spn_xoffset;
  public buSpin spn_xcount;
  internal buLabel \u0001;
  public buCheckBox chk_copyenable;
  public buButton btn_closeevent;
  public buButton btn_events;
  internal TabPage \u0006;
  public buSpin spn_ellipsearcheight;
  public buSpin spn_ellipsearcsweepangle;
  public buSpin spn_ellipsearcangle;
  public buSpin spn_ellipsearcwidth;
  internal PictureBox \u0013;
  public buSpin spn_shiipnosearcydis;
  public buSpin spn_shiipnosearcxdis;
  internal buLabel \u0002;
  public buButton btn_applyAngleA;
  internal buLabel \u0003;
  public buSpin spn_angleA;
  public buSpin spn_shiipnoseradius;
  public static byte f002282;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public int SelectedRow;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  public buButton btn_close;
  internal DataGridView \u0001;
  public buButton btn_remove;
  public buButton btn_add;
  public static byte f00228E;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public int SelectedRow;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  public buButton btn_close;
  internal DataGridView \u0001;
  public buButton btn_remove;
  public buButton btn_add;
  public static byte f00229A;
  public static List<string> Captions;
  public List<MarbleOperationSequence> Sequences;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  public buButton btn_close;
  internal buListBox \u0001;
  internal buButton \u0003;
  internal buButton \u0004;
  internal buLabel \u0001;
  internal buListBox \u0002;
  internal buLabel \u0002;
  internal buButton \u0005;
  internal buButton \u0006;
  public static byte f0022AB;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public MarbleItemSettings Settings;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  public buSpin spn_bwdvel;
  public buSpin spn_fwdvel;
  public buSpin spn_plungevel;
  public buSpin spn_matthickness;
  public buSpin spn_leavevel;
  public buSpin spn_forwardcutstep;
  public buSpin spn_safedistance;
  public buButton btn_close;
  internal RadioButton \u0001;
  internal buLabel \u0001;
  internal RadioButton \u0002;
  public buSpin spn_sliceoffset;
  public buCheckBox chk_RotateCForReverseDirection;
  internal Panel \u0001;
  internal buLabel \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  public static byte f0022C6;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleChamferBothSidePars Chamfer;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_chamfertopangle;
  public buButton btn_okVer;
  public buSpin spn_chamferbottomheiht;
  public buSpin spn_chamferbottomangle;
  public buSpin spn_chamfertopheight;
  public buButton btn_cancel;
  public buCheckBox chk_bottomchamfer;
  public buCheckBox chk_topchamfer;
  public static List<string> Captions;
  public FormProperties Properties;
  public bool isHorizontal;
  private IContainer \u0001;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleLanguageMenu) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingHorizontal) this);
        ((F_MarbleLanguageMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleLanguageMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleLanguageMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleLanguageMenu) this).btn_cancel.Name | control2.Name == ((F_MarbleLanguageMenu) this).\u0001.Name))
        return;
      ((F_MarbleLanguageMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleLanguageMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleLanguageMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleLanguageMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleLanguageMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCamSettings() => F_MarbleLanguageMenu.Captions = new List<string>();

  public F_MarbleCamSettings()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == this.btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleSawMillingVertical) this);
        this.Properties.Result = DialogResult.OK;
        if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == this.btn_cancel.Name | control2.Name == this.\u0001.Name))
        return;
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }
}
