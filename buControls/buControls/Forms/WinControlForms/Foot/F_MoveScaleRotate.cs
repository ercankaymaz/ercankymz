// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Foot.F_MoveScaleRotate
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
namespace buControls.Forms.WinControlForms.Foot;

public class F_MoveScaleRotate : Form
{
  public MoveScaleRotateStretchVar Data = new MoveScaleRotateStretchVar();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public bool ShowExtent = true;
  public static List<string> Captions = new List<string>();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_movexminus;
  public Button btn_movexplus;
  public Button btn_moveyplus;
  public Button btn_moveyminus;
  public Button btn_rotateminus;
  public Button btn_scalex;
  public Button btn_rotateplus;
  public Button btn_scaley;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  public Button btn_extentxplus;
  public Button btn_extentxminus;
  internal NumericUpDown numericUpDown_5;
  public Button btn_extentyplus;
  public Button btn_extentyminus;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList imageList_1;
  internal NumericUpDown numericUpDown_6;
  public Button btn_movezminus;
  public Button btn_movezplus;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal Label label_0;
  internal Label label_1;
  internal Panel panel_0;
  internal Label label_2;
  internal Panel panel_1;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  public Button btn_getminmaxY;
  public Button btn_getminmaxX;
  public NumericUpDown spn_xconstantval;
  public NumericUpDown spn_yconstantval;
  public NumericUpDown spn_rangeminy;
  public NumericUpDown spn_rangemaxy;
  public NumericUpDown spn_rangemaxx;
  public NumericUpDown spn_rangeminx;

  public event MoveScaleRotateExtentEventHandler EventExecuted;

  public event OkCommandEventHandler OkExecuted;

  public event CancelCommandEventHandler CancelExecuted;

  public F_MoveScaleRotate() => Class39.smethod_69(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init(MoveScaleRotateStretchVar data)
  {
    this.Data = new MoveScaleRotateStretchVar(data);
    this.Init();
  }

  public void Init()
  {
    this.bool_0 = false;
    this.numericUpDown_4.Value = (Decimal) this.Data.StretchX;
    this.numericUpDown_5.Value = (Decimal) this.Data.StretchY;
    this.numericUpDown_0.Value = (Decimal) this.Data.MoveX;
    this.numericUpDown_1.Value = (Decimal) this.Data.MoveY;
    this.numericUpDown_6.Value = (Decimal) this.Data.MoveZ;
    this.numericUpDown_2.Value = (Decimal) this.Data.Rotate;
    this.numericUpDown_3.Value = (Decimal) this.Data.Scale;
    this.spn_xconstantval.Value = (Decimal) this.Data.XConstantValue;
    this.spn_yconstantval.Value = (Decimal) this.Data.YConstantValue;
    this.spn_rangeminx.Value = (Decimal) this.Data.RangeMinX;
    this.spn_rangeminy.Value = (Decimal) this.Data.RangeMinY;
    this.spn_rangemaxx.Value = (Decimal) this.Data.RangeMaxX;
    this.spn_rangemaxy.Value = (Decimal) this.Data.RangeMaxY;
    this.checkBox_0.Checked = this.Data.XConstantEnable;
    this.checkBox_1.Checked = this.Data.YConstantEnable;
    this.numericUpDown_4.Visible = this.ShowExtent;
    this.numericUpDown_5.Visible = this.ShowExtent;
    this.btn_extentxminus.Visible = this.ShowExtent;
    this.btn_extentxplus.Visible = this.ShowExtent;
    this.btn_extentyminus.Visible = this.ShowExtent;
    this.btn_extentyplus.Visible = this.ShowExtent;
    if (!this.ShowExtent)
      this.Width -= 190;
    this.bool_0 = true;
    Class39.smethod_789(this);
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Apply();
    this.Result = DialogResult.OK;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandEventHandler_0();
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.cancelCommandEventHandler_0();
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    if (!this.bool_0)
      return;
    this.Data.StretchX = (double) this.numericUpDown_4.Value;
    this.Data.StretchY = (double) this.numericUpDown_5.Value;
    this.Data.MoveX = (double) this.numericUpDown_0.Value;
    this.Data.MoveY = (double) this.numericUpDown_1.Value;
    this.Data.MoveZ = (double) this.numericUpDown_6.Value;
    this.Data.Rotate = (double) this.numericUpDown_2.Value;
    this.Data.Scale = (double) this.numericUpDown_3.Value;
    this.Data.XConstantValue = (double) this.spn_xconstantval.Value;
    this.Data.YConstantValue = (double) this.spn_yconstantval.Value;
    this.Data.XConstantEnable = this.checkBox_0.Checked;
    this.Data.YConstantEnable = this.checkBox_1.Checked;
    this.Data.RangeMinX = (double) this.spn_rangeminx.Value;
    this.Data.RangeMinY = (double) this.spn_rangeminy.Value;
    this.Data.RangeMaxX = (double) this.spn_rangemaxx.Value;
    this.Data.RangeMaxY = (double) this.spn_rangemaxy.Value;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_movexplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveXPlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_movexminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveXMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_moveyplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveYPlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_moveyminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveYMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_movezplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveZPlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_movezminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.MoveZMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_scalex.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.ScaleX,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_scaley.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.ScaleY,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_rotateminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.RotateMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_rotateplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.RotatePlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_extentxminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.StretchXMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_extentxplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.StretchXPlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_extentyminus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.StretchYMinus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_extentyplus.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.StretchYPlus,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_getminmaxX.Name && this.moveScaleRotateExtentEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
      {
        Type = MoveScaleRotateStretchType.GetMinMaxX,
        Data = new MoveScaleRotateStretchVar(this.Data)
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.btn_getminmaxY.Name) || this.moveScaleRotateExtentEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.moveScaleRotateExtentEventHandler_0(new MoveScaleRotateExtentEventArg()
    {
      Type = MoveScaleRotateStretchType.GetMinMaxY,
      Data = new MoveScaleRotateStretchVar(this.Data)
    });
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
