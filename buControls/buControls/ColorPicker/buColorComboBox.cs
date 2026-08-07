// Decompiled with JetBrains decompiler
// Type: buControls.ColorPicker.buColorComboBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns22;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.ColorPicker;

public class buColorComboBox : UserControl
{
  private Color color_0;
  private IContainer icontainer_0 = (IContainer) null;
  internal Class71 class71_0;

  [Category("Appearance")]
  [DefaultValue(typeof (Color), "0, 0, 0")]
  public event colorChangedEventHandler ColorChanged;

  public virtual Color Color
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.class71_0.Text = this.color_0.Name;
    }
  }

  public buColorComboBox()
  {
    Class39.smethod_520(this);
    this.Height = 28;
  }

  internal void method_0(object sender, EventArgs e) => this.Height = 28;

  internal void method_1(object sender, EventArgs e)
  {
    Class71 class71 = sender as Class71;
    Color Color = Color.FromName(class71.Items[class71.SelectedIndex].ToString());
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.colorChangedEventHandler_0((object) this, Color);
    }
    this.Color = Color;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
