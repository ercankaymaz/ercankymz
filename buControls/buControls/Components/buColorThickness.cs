// Decompiled with JetBrains decompiler
// Type: buControls.Components.buColorThickness
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

public class buColorThickness : UserControl
{
  private Color color_0;
  private string string_0;
  private bool bool_0 = false;
  public double ItemThickness = 1.0;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal buSpin buSpin_0;

  public event buControlEvents.buColorChangedEventHandler ColorChanged;

  public event buControlEvents.buColorChangedEventHandler ColorDoubleClick;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (string), "Color Text")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string ItemText
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      this.label_0.Text = this.string_0;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color ItemColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.label_0.BackColor = this.color_0;
    }
  }

  public buColorThickness()
  {
    Class39.smethod_362(this);
    this.Height = 25;
    this.label_0.DoubleClick += new EventHandler(this.label_0_DoubleClick);
  }

  public void UpdateControl()
  {
    this.bool_0 = true;
    this.label_0.BackColor = this.ItemColor;
    this.label_0.Text = this.ItemText;
    this.label_0.ForeColor = buImage.InvertColorNoGray(this.label_0.BackColor);
    this.buSpin_0.Value = this.ItemThickness;
    this.bool_0 = false;
  }

  private void label_0_DoubleClick(object sender, EventArgs e)
  {
    if (this.bool_0)
      return;
    this.ItemColor = this.label_0.BackColor;
    // ISSUE: reference to a compiler-generated field
    if (this.buColorChangedEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buColorChangedEventHandler_1((object) this, this.ItemColor, this.ItemThickness, (int) byte.MaxValue);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buColorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buColorChangedEventHandler_0((object) this, this.ItemColor, this.ItemThickness, (int) byte.MaxValue);
  }

  internal void method_0(object object_0, double double_0)
  {
    if (this.bool_0)
      return;
    this.ItemColor = this.label_0.BackColor;
    // ISSUE: reference to a compiler-generated field
    if (this.buColorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buColorChangedEventHandler_0((object) this, this.ItemColor, this.ItemThickness, (int) byte.MaxValue);
  }

  internal void method_1(object sender, EventArgs e)
  {
    ColorDialogBox.ShowDialog(this.label_0.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    this.ItemColor = ColorDialogBox.Color;
    this.label_0.BackColor = ColorDialogBox.Color;
    this.label_0.ForeColor = buImage.InvertColorNoGray(this.label_0.BackColor);
    // ISSUE: reference to a compiler-generated field
    if (this.buColorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buColorChangedEventHandler_0((object) this, this.ItemColor, this.ItemThickness, (int) byte.MaxValue);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
