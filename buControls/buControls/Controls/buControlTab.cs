// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlTab
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns19;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class67))]
public class buControlTab
{
  public Control Parent;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private Color color_0 = Color.Gray;
  private int int_0 = 0;

  public buControlTab()
  {
    this.Header.Parent = this.Parent;
    this.HeaderSelected.Parent = this.Parent;
  }

  public buControlTab(buControlTab tab)
  {
    this.Header = new buControlDisplay(tab.Header);
    this.HeaderSelected = new buControlDisplay(tab.HeaderSelected);
    this.TabPageColor = tab.TabPageColor;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay Header
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay HeaderSelected
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "Gray")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color TabPageColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int HeaderXOffset
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => this.TabPageColor.ToString();
}
