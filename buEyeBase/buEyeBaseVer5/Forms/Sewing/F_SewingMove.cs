// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Shape;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingMove : Form
{
  internal Panel \u0005;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0006;
  internal Panel \u0007;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal NumericUpDown \u0008;
  internal Label \u0008;
  internal RadioButton \u0007;
  internal Panel \u0008;
  public static byte f0012F3;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_SewingTable) this).Apply();
    ((F_ShapeList) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ShapeList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_ShapeList) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_ShapeList) this).SpinBaseColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ShapeList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ShapeList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingMove() => F_ShapeList.Captions = new List<string>();

  public F_SewingMove()
  {
    ((F_SewingSpeed) this).Properties = new FormProperties();
    ((F_SewingFootHeight) this).ShowPolar = true;
    ((F_SewingFootHeight) this).refPlane = planeBoxNames.Top;
    ((F_SewingFootHeight) this).\u0001 = Color.LightBlue;
    ((F_SewingFootHeight) this).\u0002 = Color.Gainsboro;
    ((F_SewingFootHeight) this).Edit = (ShapeEdit) new ColorType();
    ((F_SewingFootHeight) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeEdit) this);
  }

  public void Init()
  {
    ((F_SewingSpeed) this).Properties.Inited = false;
    ((F_SewingSpeed) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_SewingSpeed) this).Properties.TopMost;
    this.StartPosition = ((F_SewingSpeed) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_SewingSpeed) this).Properties.ScaleFromMode;
    if (((F_SewingSpeed) this).Properties.Height > 10)
      this.Height = ((F_SewingSpeed) this).Properties.Height;
    if (((F_SewingSpeed) this).Properties.Width > 10)
      this.Width = ((F_SewingSpeed) this).Properties.Width;
    ((F_SewingRotate) this).\u0005.Value = (Decimal) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).RotateDegree;
    ((F_SewingRotate) this).\u0004.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerXCount;
    ((F_SewingRotate) this).\u0003.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerXDistance;
    ((F_SewingSelectVertex) this).\u0002.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerYCount;
    ((F_SewingSelectVertex) this).\u0001.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerYDistance;
    ((F_SewingTable) this).\u0007.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularCount;
    ((F_SewingTable) this).\u0006.Value = (Decimal) ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularAngle;
    ((F_SewingRotate) this).\u0002.Checked = ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerEnable;
    ((F_SewingTable) this).\u0003.Checked = ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularEnable;
    ((F_SewingSelectVertex) this).\u0001.Checked = ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorEnable;
    ((F_SewingRotate) this).\u0004.Visible = ((F_SewingFootHeight) this).ShowPolar;
    if (!((F_SewingFootHeight) this).ShowPolar)
      ((F_SewingTable) this).\u0003.Checked = false;
    if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis == MirrorAxisXYType.X)
      ((F_SewingSelectVertex) this).\u0002.Checked = true;
    else
      ((F_SewingSelectVertex) this).\u0001.Checked = true;
    if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation == MinCenterMaxType.Min)
    {
      this.\u0005.Checked = true;
      this.\u0006.Checked = false;
      this.\u0007.Checked = false;
    }
    else if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation == MinCenterMaxType.Center)
    {
      this.\u0005.Checked = false;
      this.\u0006.Checked = true;
      this.\u0007.Checked = false;
    }
    else if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation == MinCenterMaxType.Max)
    {
      this.\u0005.Checked = false;
      this.\u0006.Checked = false;
      this.\u0007.Checked = true;
    }
    if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorMode == MirrorModeType.FromCenter)
    {
      this.\u0003.Checked = true;
      this.\u0004.Checked = false;
    }
    else
    {
      this.\u0003.Checked = false;
      this.\u0004.Checked = true;
    }
    this.LangueageSet();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeEdit) this);
    ((F_SewingSpeed) this).Properties.Inited = true;
  }

  public void LangueageSet()
  {
    this.Text = buLangTranslate.preDef.Edit;
    ((F_SewingRotate) this).\u0005.Text = buLangTranslate.preDef.Degree;
    if (((F_SewingFootHeight) this).refPlane == planeBoxNames.Top | ((F_SewingFootHeight) this).refPlane == planeBoxNames.Bottom | ((F_SewingFootHeight) this).refPlane == planeBoxNames.Free)
    {
      ((F_SewingRotate) this).\u0004.Text = "X " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0003.Text = "X " + buLangTranslate.preDef.Distance;
      ((F_SewingSelectVertex) this).\u0002.Text = "Y " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0001.Text = "Y " + buLangTranslate.preDef.Distance;
    }
    if (((F_SewingFootHeight) this).refPlane == planeBoxNames.Front | ((F_SewingFootHeight) this).refPlane == planeBoxNames.Back)
    {
      ((F_SewingRotate) this).\u0004.Text = "X " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0003.Text = "X " + buLangTranslate.preDef.Distance;
      ((F_SewingSelectVertex) this).\u0002.Text = "Z " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0001.Text = "Z " + buLangTranslate.preDef.Distance;
    }
    if (((F_SewingFootHeight) this).refPlane == planeBoxNames.Left | ((F_SewingFootHeight) this).refPlane == planeBoxNames.Right)
    {
      ((F_SewingRotate) this).\u0004.Text = "Y " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0003.Text = "Y " + buLangTranslate.preDef.Distance;
      ((F_SewingSelectVertex) this).\u0002.Text = "Z " + buLangTranslate.preDef.Count;
      ((F_SewingSelectVertex) this).\u0001.Text = "Z " + buLangTranslate.preDef.Distance;
    }
    this.\u0008.Text = buLangTranslate.preDef.Distance;
    ((F_SewingTable) this).\u0007.Text = buLangTranslate.preDef.Count;
    ((F_SewingRotate) this).\u0006.Text = buLangTranslate.preDef.Degree;
    this.\u0003.Text = buLangTranslate.preDef.Center;
    this.\u0004.Text = buLangTranslate.preDef.Free;
    ((F_SewingSelectVertex) this).\u0002.Text = buLangTranslate.preDef.Horizontal;
    this.\u0007.Text = buLangTranslate.preDef.Max;
    this.\u0006.Text = buLangTranslate.preDef.Mid;
    this.\u0005.Text = buLangTranslate.preDef.Min;
    ((F_SewingSelectVertex) this).\u0001.Text = buLangTranslate.preDef.Vertical;
    ((F_SewingRotate) this).\u0002.Text = $"{buLangTranslate.preDef.Linear} {buLangTranslate.preDef.Array}";
    ((F_SewingSelectVertex) this).\u0001.Text = buLangTranslate.preDef.Mirror;
    ((F_SewingTable) this).\u0003.Text = $"{buLangTranslate.preDef.Polar} {buLangTranslate.preDef.Array}";
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SewingSpeed) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SewingSpeed) this).Properties.Result = DialogResult.Cancel;
    if (((F_SewingSpeed) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SewingSpeed) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).RotateDegree = (double) ((F_SewingRotate) this).\u0005.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerXCount = (int) ((F_SewingRotate) this).\u0004.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerXDistance = (double) ((F_SewingRotate) this).\u0003.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerYCount = (int) ((F_SewingSelectVertex) this).\u0002.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerYDistance = (double) ((F_SewingSelectVertex) this).\u0001.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularCount = (int) ((F_SewingTable) this).\u0007.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularAngle = (double) ((F_SewingTable) this).\u0006.Value;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerEnable = ((F_SewingRotate) this).\u0002.Checked;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularEnable = ((F_SewingTable) this).\u0003.Checked;
    ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorEnable = ((F_SewingSelectVertex) this).\u0001.Checked;
    if (this.\u0004.Checked)
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorMode = MirrorModeType.FreeMirror;
    else
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorMode = MirrorModeType.FromCenter;
    if (((F_SewingSelectVertex) this).\u0002.Checked)
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis = MirrorAxisXYType.Y;
    else
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis = MirrorAxisXYType.X;
    if (this.\u0005.Checked)
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation = MinCenterMaxType.Min;
    else if (this.\u0006.Checked)
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation = MinCenterMaxType.Center;
    else
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorLocation = MinCenterMaxType.Max;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_SewingFootHeight) this).btn_mirrorhor.Name)
    {
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis = MirrorAxisXYType.X;
      if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis == MirrorAxisXYType.X)
        ((F_SewingSelectVertex) this).\u0002.Checked = true;
      else
        ((F_SewingSelectVertex) this).\u0001.Checked = true;
    }
    if (control2.Name == ((F_SewingFootHeight) this).btn_mirrorver.Name)
    {
      ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis = MirrorAxisXYType.Y;
      if (((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).MirrorData).MirrorAxis == MirrorAxisXYType.X)
        ((F_SewingSelectVertex) this).\u0002.Checked = true;
      else
        ((F_SewingSelectVertex) this).\u0001.Checked = true;
    }
    if (control2.Name == ((F_SewingFootHeight) this).btn_lineararray.Name)
    {
      if (!((F_SewingRotate) this).\u0002.Checked)
      {
        ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerEnable = true;
        ((F_SewingRotate) this).\u0002.Checked = true;
      }
      else
      {
        ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).LineerEnable = false;
        ((F_SewingRotate) this).\u0002.Checked = false;
      }
    }
    if (control2.Name == ((F_SewingFootHeight) this).btn_polararray.Name)
    {
      if (!((F_SewingTable) this).\u0003.Checked)
      {
        ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularEnable = true;
        ((F_SewingTable) this).\u0003.Checked = true;
      }
      else
      {
        ((ShapeRuntimeData) ((ShapeRuntimeData) ((F_SewingFootHeight) this).Edit).ArrayData).CircularEnable = false;
        ((F_SewingTable) this).\u0003.Checked = false;
      }
    }
    if (control2.Name == ((F_SewingTable) this).btn_ok.Name)
    {
      this.Apply();
      ((F_SewingSpeed) this).Properties.Result = DialogResult.OK;
      if (((F_SewingSpeed) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SewingSpeed) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_SewingTable) this).btn_cancel.Name))
      return;
    ((F_SewingSpeed) this).Properties.Result = DialogResult.Cancel;
    if (((F_SewingSpeed) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SewingSpeed) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithTwoDataEventHandler MoveCommad;

  public event CancelCommandEventHandler CancelCommad;
}
