// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.G54.F_G54AxesXYZ
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.G54;

public class F_G54AxesXYZ : Form
{
  public FormProperties Properties = new FormProperties();
  public List<string> Captions = new List<string>();
  public List<Pnt9D> parG54List = new List<Pnt9D>();
  public Pnt9D Positions = new Pnt9D();
  public int parG54Index = 0;
  public int DecimalPoint = 2;
  public double IncrementStep = 0.1;
  public bool DisableSetAllButton = false;
  public AxesEnableWithUVW parG54OffsetAxisEnable = new AxesEnableWithUVW();
  public string[] parAxisString = new string[9]
  {
    "X",
    "Y",
    "Z",
    "A",
    "B",
    "C",
    "U",
    "V",
    "W"
  };
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public NumericUpDown spn_x;
  public NumericUpDown spn_y;
  public NumericUpDown spn_z;
  public Label lbl_readz;
  public Label lbl_ready;
  public Label lbl_readx;
  public Button btn_x;
  public Button btn_y;
  public Button btn_z;
  public NumericUpDown spn_index;

  public event G54GetPosEventHandler G54GetPos;

  public event G54ChangedEventHandler G54Changed;

  public event G54GetAllPosEventHandler G54GetPosAll;

  public event PageClosedEventHandler G54PageClosed;

  public F_G54AxesXYZ() => Class39.smethod_582(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    if (this.parG54List.Count > 0)
    {
      this.spn_x.Value = (Decimal) this.parG54List[0].X;
      this.spn_y.Value = (Decimal) this.parG54List[0].Y;
      this.spn_z.Value = (Decimal) this.parG54List[0].Z;
    }
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      Class39.smethod_536(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_x.Name)
    {
      this.spn_x.Value = (Decimal) this.Positions.X;
      if (this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1)
      {
        Pnt9D Pnt = new Pnt9D(this.parG54List[this.parG54Index]);
        Pnt.X = (double) this.spn_x.Value;
        this.parG54List[this.parG54Index] = new Pnt9D(Pnt);
      }
    }
    if (control2.Name == this.btn_y.Name)
    {
      this.spn_y.Value = (Decimal) this.Positions.Y;
      if (this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1)
      {
        Pnt9D Pnt = new Pnt9D(this.parG54List[this.parG54Index]);
        Pnt.Y = (double) this.spn_y.Value;
        this.parG54List[this.parG54Index] = new Pnt9D(Pnt);
      }
    }
    if (!(control2.Name == this.btn_z.Name))
      return;
    this.spn_z.Value = (Decimal) this.Positions.Z;
    if (!(this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1))
      return;
    Pnt9D Pnt1 = new Pnt9D(this.parG54List[this.parG54Index]);
    Pnt1.Z = (double) this.spn_z.Value;
    this.parG54List[this.parG54Index] = new Pnt9D(Pnt1);
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.Properties.Inited || this.parG54List.Count <= 0)
      return;
    int int32 = Convert.ToInt32(this.spn_index.Value);
    if (!(int32 >= 0 & int32 <= this.parG54List.Count - 1))
      return;
    this.parG54Index = int32;
    this.spn_x.Value = (Decimal) this.parG54List[int32].X;
    this.spn_y.Value = (Decimal) this.parG54List[int32].Y;
    this.spn_z.Value = (Decimal) this.parG54List[int32].Z;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
