// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlSeparator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns19;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class51))]
public class buControlSeparator
{
  private bool bool_0 = true;
  private Color color_0 = Color.Black;
  private float float_0 = 1f;
  public Control Parent = (Control) null;

  public event EventHandler Changed;

  public buControlSeparator()
  {
  }

  public buControlSeparator(Color color, float thickness, bool visible)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Visible = visible;
  }

  public buControlSeparator(buControlSeparator separator)
  {
    this.Color = separator.Color;
    this.Thickness = separator.Thickness;
    this.Visible = separator.Visible;
  }

  public static void Copy(buControlSeparator Source, ref buControlSeparator Target)
  {
    Target.Color = Source.Color;
    Target.Thickness = Source.Thickness;
    Target.Visible = Source.Visible;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(true)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Visible
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(1f)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float Thickness
  {
    get => this.float_0;
    set
    {
      this.float_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color Color
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  protected void OnChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler0 = this.eventHandler_0;
    if (eventHandler0 == null)
      return;
    eventHandler0((object) this, EventArgs.Empty);
  }

  public override string ToString()
  {
    string str = this.Color.ToString();
    if (this.Color.IsKnownColor)
      str = this.Color.ToKnownColor().ToString();
    return $"{this.Visible.ToString()} , {this.Thickness.ToString()} , {str}";
  }
}
