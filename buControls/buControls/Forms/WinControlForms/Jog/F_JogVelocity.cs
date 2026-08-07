// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jog.F_JogVelocity
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
namespace buControls.Forms.WinControlForms.Jog;

public class F_JogVelocity : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public EnableVisibleText AxisButton1Status = new EnableVisibleText(true, true, "X");
  public EnableVisibleText AxisButton2Status = new EnableVisibleText(true, true, "Y");
  public EnableVisibleText AxisButton3Status = new EnableVisibleText(true, true, "Z");
  public EnableVisibleText AxisButton4Status = new EnableVisibleText(true, false, "A");
  public EnableVisibleText AxisButton5Status = new EnableVisibleText(true, false, "B");
  public EnableVisibleText AxisButton6Status = new EnableVisibleText(true, false, "C");
  public EnableVisibleText AxisButton7Status = new EnableVisibleText(true, false, "U");
  public EnableVisibleText AxisButton8Status = new EnableVisibleText(true, false, "V");
  public EnableVisibleText AxisButton9Status = new EnableVisibleText(true, false, "W");
  public int SelectedAxis = 0;
  public Color colorSelected = Color.Blue;
  public Color colorUnSelected = Color.WhiteSmoke;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal ImageList imageList_0;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;

  public event JogAxisChangedEventHandler SelectedAxisChanged;

  public event JogCommandEventHandler JogCommand;

  public F_JogVelocity() => Class39.smethod_398(this);

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
    this.button_2.Enabled = this.AxisButton1Status.Enable;
    this.button_2.Visible = this.AxisButton1Status.Visible;
    this.button_2.Text = this.AxisButton1Status.Text;
    this.button_2.BackColor = this.colorUnSelected;
    this.button_3.Enabled = this.AxisButton2Status.Enable;
    this.button_3.Visible = this.AxisButton2Status.Visible;
    this.button_3.Text = this.AxisButton2Status.Text;
    this.button_3.BackColor = this.colorUnSelected;
    this.button_4.Enabled = this.AxisButton3Status.Enable;
    this.button_4.Visible = this.AxisButton3Status.Visible;
    this.button_4.Text = this.AxisButton3Status.Text;
    this.button_4.BackColor = this.colorUnSelected;
    this.button_7.Enabled = this.AxisButton4Status.Enable;
    this.button_7.Visible = this.AxisButton4Status.Visible;
    this.button_7.Text = this.AxisButton4Status.Text;
    this.button_7.BackColor = this.colorUnSelected;
    this.button_6.Enabled = this.AxisButton5Status.Enable;
    this.button_6.Visible = this.AxisButton5Status.Visible;
    this.button_6.Text = this.AxisButton5Status.Text;
    this.button_6.BackColor = this.colorUnSelected;
    this.button_5.Enabled = this.AxisButton6Status.Enable;
    this.button_5.Visible = this.AxisButton6Status.Visible;
    this.button_5.Text = this.AxisButton6Status.Text;
    this.button_5.BackColor = this.colorUnSelected;
    this.button_10.Enabled = this.AxisButton7Status.Enable;
    this.button_10.Visible = this.AxisButton7Status.Visible;
    this.button_10.Text = this.AxisButton7Status.Text;
    this.button_10.BackColor = this.colorUnSelected;
    this.button_9.Enabled = this.AxisButton8Status.Enable;
    this.button_9.Visible = this.AxisButton8Status.Visible;
    this.button_9.Text = this.AxisButton8Status.Text;
    this.button_9.BackColor = this.colorUnSelected;
    this.button_8.Enabled = this.AxisButton9Status.Enable;
    this.button_8.Visible = this.AxisButton9Status.Visible;
    this.button_8.Text = this.AxisButton9Status.Text;
    this.button_8.BackColor = this.colorUnSelected;
    if (this.SelectedAxis == 0)
      this.button_2.BackColor = this.colorSelected;
    if (this.SelectedAxis == 1)
      this.button_3.BackColor = this.colorSelected;
    if (this.SelectedAxis == 2)
      this.button_4.BackColor = this.colorSelected;
    if (this.SelectedAxis == 3)
      this.button_7.BackColor = this.colorSelected;
    if (this.SelectedAxis == 4)
      this.button_6.BackColor = this.colorSelected;
    if (this.SelectedAxis == 5)
      this.button_5.BackColor = this.colorSelected;
    if (this.SelectedAxis == 6)
      this.button_10.BackColor = this.colorSelected;
    if (this.SelectedAxis == 7)
      this.button_9.BackColor = this.colorSelected;
    if (this.SelectedAxis == 8)
      this.button_8.BackColor = this.colorSelected;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_2.BackColor = this.colorUnSelected;
    this.button_3.BackColor = this.colorUnSelected;
    this.button_4.BackColor = this.colorUnSelected;
    this.button_7.BackColor = this.colorUnSelected;
    this.button_6.BackColor = this.colorUnSelected;
    this.button_5.BackColor = this.colorUnSelected;
    this.button_10.BackColor = this.colorUnSelected;
    this.button_9.BackColor = this.colorUnSelected;
    this.button_8.BackColor = this.colorUnSelected;
    if (control2.Name == this.button_2.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0((object) this.button_2, 0);
      }
      this.button_2.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_3.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 1);
      }
      this.button_3.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_4.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 2);
      }
      this.button_4.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_7.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 3);
      }
      this.button_7.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_6.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 4);
      }
      this.button_6.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_5.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 5);
      }
      this.button_5.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_10.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 6);
      }
      this.button_10.BackColor = this.colorSelected;
    }
    if (control2.Name == this.button_9.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0(sender, 7);
      }
      this.button_9.BackColor = this.colorSelected;
    }
    if (!(control2.Name == this.button_8.Name))
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.jogAxisChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogAxisChangedEventHandler_0(sender, 8);
    }
    this.button_8.BackColor = this.colorSelected;
  }

  internal void method_2(object sender, MouseEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        SelectedAxis = this.SelectedAxis,
        Command = JogCommandType.VelocityPlus
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_0.Name) || this.jogCommandEventHandler_0 == null)
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
    if (control2.Name == this.button_1.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Command = JogCommandType.StopAll
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_0.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.StopAll
    });
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Command = JogCommandType.StopAll
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_0.Name) || this.jogCommandEventHandler_0 == null)
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
