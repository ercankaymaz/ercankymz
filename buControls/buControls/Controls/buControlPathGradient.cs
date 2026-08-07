// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlPathGradient
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns3;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class55))]
public class buControlPathGradient
{
  private Color color_0 = Color.LightGray;
  private Color color_1 = Color.Gray;
  public Control Parent = (Control) null;

  public event EventHandler Changed;

  public buControlPathGradient()
  {
  }

  public buControlPathGradient(Color centercolor, Color surroundcolor)
  {
    this.CenterColor = centercolor;
    this.SurroundColor = surroundcolor;
  }

  public buControlPathGradient(buControlPathGradient gradient)
  {
    this.CenterColor = gradient.CenterColor;
    this.SurroundColor = gradient.SurroundColor;
    this.Parent = gradient.Parent;
  }

  public static void Copy(buControlPathGradient Source, ref buControlPathGradient Target)
  {
    Target.CenterColor = Source.CenterColor;
    Target.SurroundColor = Source.SurroundColor;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color CenterColor
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

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color SurroundColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
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
    string str1 = this.CenterColor.ToString();
    string str2 = this.SurroundColor.ToString();
    KnownColor knownColor;
    if (this.CenterColor.IsKnownColor)
    {
      knownColor = this.CenterColor.ToKnownColor();
      str1 = knownColor.ToString();
    }
    Color surroundColor = this.SurroundColor;
    if (surroundColor.IsKnownColor)
    {
      surroundColor = this.SurroundColor;
      knownColor = surroundColor.ToKnownColor();
      str2 = knownColor.ToString();
    }
    return $"{str1} , {str2}";
  }
}
