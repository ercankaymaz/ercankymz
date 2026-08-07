// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.BackgroundLinearGradient
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class BackgroundLinearGradient : VisualElementBase
{
  private Color mFirstColor = Color.Empty;
  private Color mSecondColor = Color.Empty;
  private float mAngle = 0.0f;
  private float[] mBlendFactors = (float[]) null;
  private float[] mBlendPositions = (float[]) null;

  public BackgroundLinearGradient()
  {
  }

  public BackgroundLinearGradient(Color firstColor, Color secondColor, float angle)
  {
    this.FirstColor = firstColor;
    this.SecondColor = secondColor;
    this.Angle = angle;
  }

  public BackgroundLinearGradient(BackgroundLinearGradient other)
    : base((VisualElementBase) other)
  {
    this.FirstColor = other.FirstColor;
    this.SecondColor = other.SecondColor;
    this.Angle = other.Angle;
    this.BlendFactors = other.BlendFactors;
    this.BlendPositions = other.BlendPositions;
  }

  public virtual Color FirstColor
  {
    get => this.mFirstColor;
    set => this.mFirstColor = value;
  }

  protected virtual bool ShouldSerializeFirstColor() => this.FirstColor != Color.Empty;

  public virtual Color SecondColor
  {
    get => this.mSecondColor;
    set => this.mSecondColor = value;
  }

  protected virtual bool ShouldSerializeSecondColor() => this.SecondColor != Color.Empty;

  public virtual float Angle
  {
    get => this.mAngle;
    set => this.mAngle = value;
  }

  protected virtual bool ShouldSerializeAngle() => (double) this.Angle != 0.0;

  public virtual float[] BlendFactors
  {
    get => this.mBlendFactors;
    set => this.mBlendFactors = value;
  }

  protected virtual bool ShouldSerializeBlendFactors() => this.BlendFactors != null;

  public virtual float[] BlendPositions
  {
    get => this.mBlendPositions;
    set => this.mBlendPositions = value;
  }

  protected virtual bool ShouldSerializeBlendPositions() => this.BlendPositions != null;

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((this.FirstColor != Color.Empty ? 1 : (this.SecondColor != Color.Empty ? 1 : 0)) == 0)
      return;
    if (this.FirstColor == this.SecondColor)
    {
      SolidBrush brush = graphics.BrushsCache.GetBrush(this.FirstColor);
      graphics.Graphics.FillRectangle((Brush) brush, area);
    }
    else
    {
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(area, this.FirstColor, this.SecondColor, this.Angle))
      {
        if ((this.BlendFactors == null || this.BlendPositions == null ? 0 : (this.BlendFactors.Length == this.BlendPositions.Length ? 1 : 0)) != 0)
          linearGradientBrush.Blend = new Blend()
          {
            Factors = this.BlendFactors,
            Positions = this.BlendPositions
          };
        graphics.Graphics.FillRectangle((Brush) linearGradientBrush, area);
      }
    }
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize) => SizeF.Empty;

  public override object Clone() => (object) new BackgroundLinearGradient(this);
}
