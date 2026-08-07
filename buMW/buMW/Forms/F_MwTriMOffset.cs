// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMOffset
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMOffset : Form
{
  internal System.Windows.Forms.Label \u0007;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal CheckBox \u0001;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  private IContainer \u0001 = (IContainer) null;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;

  public void Apply()
  {
    ((F_MwTriMMirror) this).Par.RoughingParams.MirrorTpRoughParams.ToolpathCopyFlg = this.\u0001.Checked;
    ((F_MwTriMMirror) this).Par.RoughingParams.MirrorTpRoughParams.MirrorPlaneBasePoint = new Point3d<double>((double) ((F_MwTriMMirror) this).\u0001.Value, (double) ((F_MwTriMMirror) this).\u0003.Value, (double) ((F_MwTriMMirror) this).\u0002.Value);
    if (((F_MwTriMMirror) this).combo_direction.SelectedIndex == 0)
      ((F_MwTriMMirror) this).Par.RoughingParams.MirrorTpRoughParams.MirrorPlaneNormal = new Vectord(1.0, 0.0, 0.0);
    if (((F_MwTriMMirror) this).combo_direction.SelectedIndex == 1)
      ((F_MwTriMMirror) this).Par.RoughingParams.MirrorTpRoughParams.MirrorPlaneNormal = new Vectord(0.0, 1.0, 0.0);
    if (((F_MwTriMMirror) this).combo_direction.SelectedIndex != 2)
      return;
    ((F_MwTriMMirror) this).Par.RoughingParams.MirrorTpRoughParams.MirrorPlaneNormal = new Vectord(0.0, 0.0, 1.0);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMMirror) this).Properties.Inited)
      return;
    ((F_MwTriMMirror) this).Properties.Inited = false;
    this.Apply();
    ((F_MwTriMMirror) this).UpdateControlFromType();
    ((F_MwTriMMirror) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMMirror) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMMirror) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMOffset() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0001.Value = (Decimal) this.Par.AxialOffset;
    this.\u0002.Value = (Decimal) this.Par.RadialOffset;
    ((F_MwTriMConstantZ) this).\u0003.Value = (Decimal) this.Par.StockRemain;
    if (this.Par.StockRemainType == MachiningParamsStockRemainType.SrtGlobal)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
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
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    if (this.\u0002.Checked)
    {
      ((F_MwTriMConstantZ) this).\u0004.Enabled = true;
      ((F_MwTriMConstantZ) this).\u0003.Enabled = true;
      this.\u0002.Enabled = false;
      this.\u0001.Enabled = false;
      this.\u0003.Enabled = false;
      this.\u0002.Enabled = false;
    }
    else
    {
      ((F_MwTriMConstantZ) this).\u0004.Enabled = false;
      ((F_MwTriMConstantZ) this).\u0003.Enabled = false;
      this.\u0002.Enabled = true;
      this.\u0001.Enabled = true;
      this.\u0003.Enabled = true;
      this.\u0002.Enabled = true;
    }
  }

  public void Apply()
  {
    this.Par.AxialOffset = (double) this.\u0001.Value;
    this.Par.RadialOffset = (double) this.\u0002.Value;
    this.Par.StockRemain = (double) ((F_MwTriMConstantZ) this).\u0003.Value;
    if (this.\u0002.Checked)
      this.Par.StockRemainType = MachiningParamsStockRemainType.SrtGlobal;
    else
      this.Par.StockRemainType = MachiningParamsStockRemainType.SrtRadialAndAxial;
  }
}
