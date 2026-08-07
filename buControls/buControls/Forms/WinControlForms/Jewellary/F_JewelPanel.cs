// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelPanel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelPanel : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public int SelectedAxis = 0;
  public Color colorSelected = Color.Blue;
  public Color colorUnSelected = Color.WhiteSmoke;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal Button button_0;
  internal Button button_1;
  public Button btn_handwheelenable;
  public Button btn_spindlepsitondown;
  public Button btn_spindlepistonup;
  public Button btn_diameterpistonup;
  public Button btn_diameterpistondown;
  public Button btn_magazineclose;
  public Button btn_magazineopen;
  public Button btn_stop;
  public Button btn_pensclose;
  public Button btn_pensopen;
  public Button btn_spindlestop;
  public Button btn_spindlestart;
  public Button btn_diacut1stop;
  public Button btn_diacut1start;
  public Button btn_diacut2stop;
  public Button btn_diacut2start;
  public Button btn_engravestop;
  public Button btn_engravestart;
  public Button btn_lathestop;
  public Button btn_lathestart;
  public Button btn_laserstop;
  public Button btn_laserstart;
  public Label label1;
  public NumericUpDown spn_spindlespeed;
  public NumericUpDown spn_diacut1speed;
  public Label label2;
  public NumericUpDown spn_diacut2speed;
  public Label label3;
  public NumericUpDown spn_engravespeed;
  public Label label4;
  public NumericUpDown spn_lathespeed;
  public Label label5;
  public Button btn_spindlewarmup;
  public Button btn_aircleanstop;
  public Button btn_aircleanstart;
  public Button btn_oilstop;
  public Button btn_oilstart;
  public Button btn_spindlepark;
  public Button btn_dia1park;
  public Button btn_engravepark;
  public Button btn_dia2park;
  public Button btn_lathepark;
  public Button btn_laserpark;
  public Button btn_x;
  public Button btn_y;
  public Button btn_z;
  public Button btn_c;
  public Button btn_b;
  public Button btn_a;
  public Button btn_w;
  public Button btn_v;
  public Button btn_u;
  public Button btn_homing;
  public Button btn_j;
  public Button btn_i;
  public Button btn_pistondown;
  public Button btn_pistonup;

  public event JogAxisChangedEventHandler SelectedAxisChanged;

  public event JogCommandEventHandler JogCommand;

  public event OkCommandEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public F_JewelPanel() => Class39.smethod_560(this);

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
    this.btn_x.BackColor = this.colorUnSelected;
    this.btn_y.BackColor = this.colorUnSelected;
    this.btn_z.BackColor = this.colorUnSelected;
    this.btn_a.BackColor = this.colorUnSelected;
    this.btn_b.BackColor = this.colorUnSelected;
    this.btn_c.BackColor = this.colorUnSelected;
    this.btn_u.BackColor = this.colorUnSelected;
    this.btn_v.BackColor = this.colorUnSelected;
    this.btn_w.BackColor = this.colorUnSelected;
    if (this.SelectedAxis == 0)
      this.btn_x.BackColor = this.colorSelected;
    if (this.SelectedAxis == 1)
      this.btn_y.BackColor = this.colorSelected;
    if (this.SelectedAxis == 2)
      this.btn_z.BackColor = this.colorSelected;
    if (this.SelectedAxis == 3)
      this.btn_a.BackColor = this.colorSelected;
    if (this.SelectedAxis == 4)
      this.btn_b.BackColor = this.colorSelected;
    if (this.SelectedAxis == 5)
      this.btn_c.BackColor = this.colorSelected;
    if (this.SelectedAxis == 6)
      this.btn_u.BackColor = this.colorSelected;
    if (this.SelectedAxis == 7)
      this.btn_v.BackColor = this.colorSelected;
    if (this.SelectedAxis == 8)
      this.btn_w.BackColor = this.colorSelected;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.cancelCommandEventHandler_0();
    }
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.btn_x.BackColor = this.colorUnSelected;
    this.btn_y.BackColor = this.colorUnSelected;
    this.btn_z.BackColor = this.colorUnSelected;
    this.btn_a.BackColor = this.colorUnSelected;
    this.btn_b.BackColor = this.colorUnSelected;
    this.btn_c.BackColor = this.colorUnSelected;
    this.btn_u.BackColor = this.colorUnSelected;
    this.btn_v.BackColor = this.colorUnSelected;
    this.btn_w.BackColor = this.colorUnSelected;
    this.btn_i.BackColor = this.colorUnSelected;
    this.btn_j.BackColor = this.colorUnSelected;
    if (control2.Name == this.btn_x.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0((object) this.btn_x, 0);
      }
      this.btn_x.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_y.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 1);
      }
      this.btn_y.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_z.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 2);
      }
      this.btn_z.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_a.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 3);
      }
      this.btn_a.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_b.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 4);
      }
      this.btn_b.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_c.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 5);
      }
      this.btn_c.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_u.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 6);
      }
      this.btn_u.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_v.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 7);
      }
      this.btn_v.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_w.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 8);
      }
      this.btn_w.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_i.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 9);
      }
      this.btn_i.BackColor = this.colorSelected;
    }
    if (control2.Name == this.btn_j.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 10);
      }
      this.btn_j.BackColor = this.colorSelected;
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.btn_stop.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      SelectedAxis = this.SelectedAxis,
      Command = JogCommandType.Stop
    });
  }

  internal void method_2(object sender, MouseEventArgs e)
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
        Command = JogCommandType.VelocityPlus
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_1.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      SelectedAxis = this.SelectedAxis,
      Command = JogCommandType.VelocityMinus
    });
  }

  internal void method_3(object sender, MouseEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Command = JogCommandType.StopAll
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_1.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.StopAll
    });
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
