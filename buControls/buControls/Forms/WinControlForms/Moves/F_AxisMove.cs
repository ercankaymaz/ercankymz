// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Moves.F_AxisMove
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
namespace buControls.Forms.WinControlForms.Moves;

public class F_AxisMove : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public int SelectedAxis = 0;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Panel panel_0;
  internal Label label_5;
  internal Panel panel_1;
  internal Label label_6;
  internal Button button_8;
  internal Button button_9;
  internal PictureBox pictureBox_0;
  public Label lbl_axisvalue;
  public Label lbl_selaxistext;
  public NumericUpDown spn_pos1;
  public NumericUpDown spn_pos2;
  public NumericUpDown spn_inc;
  public NumericUpDown spn_velmove;
  public NumericUpDown spn_veljog;

  public event JogCommandEventHandler JogCommand;

  public F_AxisMove() => Class39.smethod_652(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Command = JogCommandType.StopAll
      });
    }
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
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_1(object sender, MouseEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_2.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value,
        Command = JogCommandType.VelocityPlus
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_3.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      SelectedAxis = this.SelectedAxis,
      Position1 = (double) this.spn_pos1.Value,
      Position2 = (double) this.spn_pos2.Value,
      IncrementalPosition = (double) this.spn_inc.Value,
      VelocityMove = (double) this.spn_velmove.Value,
      VelocityJog = (double) this.spn_veljog.Value,
      Command = JogCommandType.VelocityMinus
    });
  }

  internal void method_2(object sender, MouseEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_2.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value,
        Command = JogCommandType.StopAll
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_3.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Position1 = (double) this.spn_pos1.Value,
      Position2 = (double) this.spn_pos2.Value,
      IncrementalPosition = (double) this.spn_inc.Value,
      VelocityMove = (double) this.spn_velmove.Value,
      VelocityJog = (double) this.spn_veljog.Value,
      Command = JogCommandType.StopAll
    });
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control = new Control();
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.Position1,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.Position2,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_4.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.Incremental,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_5.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.Home
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_7.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.Stop,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_6.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.AutoTest,
        Position1 = (double) this.spn_pos1.Value,
        Position2 = (double) this.spn_pos2.Value,
        IncrementalPosition = (double) this.spn_inc.Value,
        VelocityMove = (double) this.spn_velmove.Value,
        VelocityJog = (double) this.spn_veljog.Value
      });
    }
    if (control2.Name == this.button_9.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_8.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      SelectedAxis = this.SelectedAxis,
      Command = JogCommandType.Settings
    });
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
