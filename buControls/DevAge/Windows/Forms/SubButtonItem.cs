// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.SubButtonItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class SubButtonItem
{
  internal MenuItem menuItem_0;
  private object object_0;
  private ButtonMultiSelection buttonMultiSelection_0;

  public SubButtonItem()
    : this("NewItem")
  {
  }

  public SubButtonItem(string p_Text)
    : this(p_Text, (EventHandler) null)
  {
  }

  public SubButtonItem(string p_Text, EventHandler p_Event)
    : this(p_Text, p_Event, (Image) null)
  {
  }

  public SubButtonItem(string p_Text, EventHandler p_Event, Image p_Image)
  {
    this.menuItem_0 = p_Image != null ? new MenuItem() : new MenuItem();
    Class39.smethod_822(this, p_Text, p_Event);
  }

  public SubButtonItem(
    string p_Text,
    EventHandler p_Event,
    ImageList p_ImageList,
    int p_ImageIndex)
  {
    this.menuItem_0 = p_ImageList != null ? new MenuItem() : new MenuItem();
    Class39.smethod_822(this, p_Text, p_Event);
  }

  public object Tag
  {
    get => this.object_0;
    set => this.object_0 = value;
  }

  public string Text
  {
    get => this.menuItem_0.Text;
    set => this.menuItem_0.Text = value;
  }

  public void InvokeItemClick(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
  }

  public event EventHandler Click
  {
    add => this.method_0(value);
    remove => this.method_1(value);
  }

  public ButtonMultiSelection Owner
  {
    get => this.buttonMultiSelection_0;
    set => this.buttonMultiSelection_0 = value;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (this.buttonMultiSelection_0 == null)
      return;
    this.buttonMultiSelection_0.method_2(new SubButtonItemEventArgs(this));
  }
}
