// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_ProfileCommands
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
namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileCommands : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Button button_0;
  internal ImageList imageList_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal ImageList imageList_1;
  internal Label label_8;
  internal Button button_8;
  internal Label label_9;
  internal Label label_10;
  internal Button button_9;
  internal Button button_10;
  internal Label label_11;
  internal Button button_11;

  public event OkCommandWithDataEventHandler CommandOk;

  public F_ProfileCommands() => Class39.smethod_283(this);

  public void Init()
  {
    this.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.Properties.Inited = false;
    this.Properties.Result = DialogResult.None;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.Properties.Inited = true;
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

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_3.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Text);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Circle);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_6.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Ellipse);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_5.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.FreeDraw);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Hole);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Barrel);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_4.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Notch);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_7.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Rectangle);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_8.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Slot);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_11.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.Cut);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_10.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.FromFile);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_9.Name) || this.okCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) ProfileOperationTypes.FromFileList);
  }

  internal void method_2(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
