// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleVerticalCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleVerticalCut : Form
{
  public buButton btn_settings;
  public buButton btn_close;
  public buButton btn_arc;
  public buButton btn_shipnose;
  public buButton btn_rectanglecross;
  public buButton btn_rectanglechamfer;
  public buButton btn_rectangleround;
  public buButton btn_ellipsepie;
  public buButton btn_arcpie;
  public buButton btn_objectlocation;
  public buCheckBox chk_rotate90plus;
  public buCheckBox chk_rotate180plus;
  public buCheckBox chk_rotate90minus;
  public buCheckBox chk_rotate180minus;
  public buCheckBox chk_mirroY;
  public buCheckBox chk_mirrorX;
  internal buSeparator \u0002;
  public buLabel lbl_events;
  internal ImageList \u0003;
  public static byte f00299F;
  public static List<string> Captions;
  private IContainer \u0001;
  public buButton ntn_minimize;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public Panel pnl_cutting_viewport;
  public buButton btn_scale;
  public TabPage tabPage_alignment;
  public buButton btn_alignmentleft;
  public buButton btn_alignmenttop;
  public buButton btn_alignmentcenter;
  public buButton btn_alignmentright;
  public buButton btn_alignmentbottom;
  public PictureBox pictureBox1;
  public buPanel buPanel2;
  public buTab buTab_commands;
  public TabPage tabPage_shape;
  public buButton btn_rectangle;
  public buButton btn_polygon;
  public buButton btn_circle;
  public buButton btn_trapez;
  public buButton btn_triangle;
  public buButton btn_ellipse;
  public TabPage tabPage_drawing;
  public buButton btn_line;
  public buButton btn_arc;
  public buButton btn_spline;
  public TabPage tabPage_events;
  public buButton btn_copy;
  public buButton btn_mirror;
  public buButton btn_rotate;
  public buButton btn_lineararray;
  public buButton btn_circulararray;
  public buPanel buPanel1;
  public buButton btn_events;
  public buButton btn_import;
  public buButton btn_vacuum;
  public buButton btn_bench;
  public buButton btn_alignments;
  public buButton btn_shape;
  public buButton btn_drawings;
  public buButton btn_roundrect;
  public buButton btn_keyhole;
  public buButton btn_slot;
  public buButton btn_profiling;
  public buButton btn_engraving;
  public buButton btn_sweep;
  public buButton btn_drill;
  public buButton btn_text;
  public static List<string> Captions;
  private IContainer \u0001;
  public buSpin spn_lengthHor;
  public buSpin spn_itemEA5;

  public F_MarbleVerticalCut()
  {
    ((F_MarbleProfileCut) this).Properties = new FormProperties();
    ((F_MarbleProfileCut) this).varMaterialClean = (marbleMatrialCleanPars) new \u0007.\u0001();
    ((F_MarbleProfileCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleBaseMatClear) this);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCut) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCut) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCut) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCut) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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
}
