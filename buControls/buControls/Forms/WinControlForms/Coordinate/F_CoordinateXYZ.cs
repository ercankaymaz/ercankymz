// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Coordinate.F_CoordinateXYZ
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Coordinate;

public class F_CoordinateXYZ : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public Pnt3D RefPoint = new Pnt3D();
  public bool ShowZ = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal Label label_0;
  internal Label label_1;
  public Button btn_cancel;
  public Button btn_ok;
  public NumericUpDown spn_y;
  public NumericUpDown spn_x;
  internal Label label_2;
  public NumericUpDown spn_z;

  public F_CoordinateXYZ() => Class39.smethod_397(this);

  public event Pnt3DValueChangedEventHandler PointValueChanged;

  public event OkCommandEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.spn_x.Value = (Decimal) this.RefPoint.X;
    this.spn_y.Value = (Decimal) this.RefPoint.Y;
    this.spn_z.Value = (Decimal) this.RefPoint.Z;
    this.spn_z.Visible = this.ShowZ;
    this.label_2.Visible = this.ShowZ;
    this.spn_x.Focus();
    this.spn_x.Select(0, 100);
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "F_FreeLineerDraw LoadLanguage";
    try
    {
      if (F_CoordinateXYZ.Captions.Count < 67)
        return;
      this.Text = F_CoordinateXYZ.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

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

  internal void method_1(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.spn_x.Name && e.KeyCode == Keys.Return)
    {
      this.spn_y.Focus();
      this.spn_y.Select(0, 100);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_y.Name && this.pnt3DValueChangedEventHandler_0 != null && e.KeyCode == Keys.Return)
    {
      if (!this.ShowZ)
      {
        // ISSUE: reference to a compiler-generated field
        this.pnt3DValueChangedEventHandler_0(new Pnt3DValueChangedEventArg()
        {
          Point = new Pnt3D((double) this.spn_x.Value, (double) this.spn_y.Value, this.RefPoint.Z)
        });
        this.spn_x.Focus();
        this.spn_x.Select(0, 100);
      }
      else
      {
        this.spn_z.Focus();
        this.spn_z.Select(0, 100);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.spn_z.Name) || this.pnt3DValueChangedEventHandler_0 == null || e.KeyCode != Keys.Return)
      return;
    // ISSUE: reference to a compiler-generated field
    this.pnt3DValueChangedEventHandler_0(new Pnt3DValueChangedEventArg()
    {
      Point = new Pnt3D((double) this.spn_x.Value, (double) this.spn_y.Value, (double) this.spn_z.Value)
    });
    this.spn_x.Focus();
    this.spn_x.Select(0, 100);
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.cancelCommandEventHandler_0();
    }
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.OK;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandEventHandler_0();
    }
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
