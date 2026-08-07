// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlLineerGradient
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

[TypeConverter(typeof (Class54))]
public class buControlLineerGradient
{
  private Color color_0 = Color.WhiteSmoke;
  private Color color_1 = Color.DarkGray;
  private float float_0 = 90f;
  public Control Parent = (Control) null;

  public event EventHandler Changed;

  public buControlLineerGradient()
  {
  }

  public buControlLineerGradient(Color firstcolor, Color secondcolor, float angle)
  {
    this.FirstColor = firstcolor;
    this.SecondColor = secondcolor;
    this.GradientAngle = angle;
  }

  public buControlLineerGradient(buControlLineerGradient gradient)
  {
    this.FirstColor = gradient.FirstColor;
    this.SecondColor = gradient.SecondColor;
    this.GradientAngle = gradient.GradientAngle;
    this.Parent = gradient.Parent;
  }

  public static void Copy(buControlLineerGradient Source, ref buControlLineerGradient Target)
  {
    Target.FirstColor = Source.FirstColor;
    Target.SecondColor = Source.SecondColor;
    Target.GradientAngle = Source.GradientAngle;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(90f)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float GradientAngle
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
  [DefaultValue(typeof (Color), "WhiteSmoke")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color FirstColor
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
  [DefaultValue(typeof (Color), "DarkGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color SecondColor
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
    string str1 = this.FirstColor.ToString();
    string str2 = this.SecondColor.ToString();
    KnownColor knownColor;
    if (this.FirstColor.IsKnownColor)
    {
      knownColor = this.FirstColor.ToKnownColor();
      str1 = knownColor.ToString();
    }
    Color secondColor = this.SecondColor;
    if (secondColor.IsKnownColor)
    {
      secondColor = this.SecondColor;
      knownColor = secondColor.ToKnownColor();
      str2 = knownColor.ToString();
    }
    return $"{str1} , {str2} , {this.GradientAngle.ToString()}";
  }
}
