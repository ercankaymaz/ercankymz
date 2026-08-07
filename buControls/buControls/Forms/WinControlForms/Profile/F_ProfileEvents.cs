// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_ProfileEvents
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

public class F_ProfileEvents : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal Button button_0;
  internal ImageList imageList_1;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;

  public F_ProfileEvents() => Class39.smethod_142(this);

  public event OkCommandWithDataEventHandler CommandOk;

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
    this.Dispose();
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) actionTypeBU.eventCopy);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) actionTypeBU.eventMirrorX);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) actionTypeBU.eventMirrorY);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_3.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) actionTypeBU.eventLineerArray);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_4.Name) || this.okCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) actionTypeBU.eventPolarArray);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
