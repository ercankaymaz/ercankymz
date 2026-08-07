// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_MoveRotateWith3Point
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
namespace buControls.Forms.WinControlForms.Events;

public class F_MoveRotateWith3Point : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public MoveAndRotateWith3PointData Data = new MoveAndRotateWith3PointData();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  public Button btn_selectmovepos;
  public Button btn_selectrotApos;
  public Button btn_selectrotCpos;
  public NumericUpDown spn_newArotatez;
  public NumericUpDown spn_newArotatey;
  public NumericUpDown spn_newArotatex;
  public NumericUpDown spn_newCrotatez;
  public NumericUpDown spn_newCrotatey;
  public NumericUpDown spn_newCrotatex;
  public NumericUpDown spn_selectedmovex;
  public NumericUpDown spn_selectedmovey;
  public NumericUpDown spn_selectedmovez;
  public NumericUpDown spn_selectedArotatez;
  public NumericUpDown spn_selectedArotatey;
  public NumericUpDown spn_selectedArotatex;
  public NumericUpDown spn_selectedCrotatez;
  public NumericUpDown spn_selectedCrotatey;
  public NumericUpDown spn_selectedCrotatex;
  public NumericUpDown spn_newmovez;
  public NumericUpDown spn_newmovey;
  public NumericUpDown spn_newmovex;
  public CheckBox chk_rotA;
  public CheckBox chk_rotC;

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public F_MoveRotateWith3Point() => Class39.smethod_190(this);

  public void Init()
  {
    this.Properties.Inited = false;
    this.Properties.Result = DialogResult.None;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.spn_selectedmovex.Value = (Decimal) this.Data.PntMoveSelected.X;
    this.spn_selectedmovey.Value = (Decimal) this.Data.PntMoveSelected.Y;
    this.spn_selectedmovez.Value = (Decimal) this.Data.PntMoveSelected.Z;
    this.spn_newmovex.Value = (Decimal) this.Data.PntMoveNew.X;
    this.spn_newmovey.Value = (Decimal) this.Data.PntMoveNew.Y;
    this.spn_newmovez.Value = (Decimal) this.Data.PntMoveNew.Z;
    this.spn_selectedArotatex.Value = (Decimal) this.Data.PntRotateASelected.X;
    this.spn_selectedArotatey.Value = (Decimal) this.Data.PntRotateASelected.Y;
    this.spn_selectedArotatez.Value = (Decimal) this.Data.PntRotateASelected.Z;
    this.spn_newArotatex.Value = (Decimal) this.Data.PntRotateANew.X;
    this.spn_newArotatey.Value = (Decimal) this.Data.PntRotateANew.Y;
    this.spn_newArotatez.Value = (Decimal) this.Data.PntRotateANew.Z;
    this.spn_selectedCrotatex.Value = (Decimal) this.Data.PntRotateCSelected.X;
    this.spn_selectedCrotatey.Value = (Decimal) this.Data.PntRotateCSelected.Y;
    this.spn_selectedCrotatez.Value = (Decimal) this.Data.PntRotateCSelected.Z;
    this.spn_newCrotatex.Value = (Decimal) this.Data.PntRotateCNew.X;
    this.spn_newCrotatey.Value = (Decimal) this.Data.PntRotateCNew.Y;
    this.spn_newCrotatez.Value = (Decimal) this.Data.PntRotateCNew.Z;
    this.chk_rotC.Checked = this.Data.PntRotateCSelected.Option > 0.0;
    this.chk_rotA.Checked = this.Data.PntRotateASelected.Option > 0.0;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_ok.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) null);
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_selectmovepos.Name)
      ;
    if (control2.Name == this.btn_selectrotApos.Name)
      ;
    if (control2.Name == this.btn_selectrotCpos.Name)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
