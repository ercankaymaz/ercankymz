// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Header
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Header : HeaderBase
{
  private Color mBackColor;
  private RectangleBorder mBorder;
  private float mGradientAngle = 45f;
  private BackgroundColorStyle mBackgroundColorStyle = BackgroundColorStyle.Linear;
  private BackgroundLinearGradient mBackground;

  public Header()
    : this(45f)
  {
  }

  public Header(float gradientAngle)
  {
    this.GradientAngle = gradientAngle;
    this.mBackground = new BackgroundLinearGradient(Color.Empty, Color.Empty, this.GradientAngle);
    this.BackColor = Color.FromKnownColor(KnownColor.Control);
    BorderLine borderLine = new BorderLine(Utilities.CalculateLightDarkColor(this.BackColor, -0.2f), 1f);
    this.mBorder = new RectangleBorder(borderLine, borderLine);
  }

  public Header(Header other)
    : base((HeaderBase) other)
  {
    this.BackColor = other.BackColor;
    this.Border = other.Border;
    this.GradientAngle = other.GradientAngle;
  }

  public Color BackColor
  {
    get => this.mBackColor;
    set => this.mBackColor = value;
  }

  public RectangleBorder Border
  {
    get => this.mBorder;
    set => this.mBorder = value;
  }

  public float GradientAngle
  {
    get => this.mGradientAngle;
    set => this.mGradientAngle = value;
  }

  public BackgroundColorStyle BackgroundColorStyle
  {
    get => this.mBackgroundColorStyle;
    set => this.mBackgroundColorStyle = value;
  }

  public override object Clone() => (object) new Header(this);

  public override RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    backGroundArea = this.mBorder.GetContentRectangle(backGroundArea);
    return base.GetBackgroundContentRectangle(measure, backGroundArea);
  }

  public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
  {
    base.GetBackgroundExtent(measure, contentSize);
    return this.mBorder.GetExtent(contentSize);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    this.OnDrawBackground(graphics, area);
    this.OnDrawBorder(graphics, area);
  }

  protected virtual void OnDrawBorder(GraphicsCache graphics, RectangleF area)
  {
    this.mBorder.Draw(graphics, area);
  }

  protected virtual void OnDrawBackground(GraphicsCache graphics, RectangleF area)
  {
    Color lightDarkColor1 = Utilities.CalculateLightDarkColor(this.BackColor, -0.2f);
    Color lightDarkColor2 = Utilities.CalculateLightDarkColor(this.BackColor, 0.5f);
    Color middleColor = Utilities.CalculateMiddleColor(Color.FromKnownColor(KnownColor.Highlight), lightDarkColor2);
    if (this.Style == ControlDrawStyle.Hot)
    {
      this.mBackground.FirstColor = middleColor;
      this.mBackground.SecondColor = middleColor;
    }
    else if (this.Style == ControlDrawStyle.Pressed)
    {
      this.mBackground.FirstColor = lightDarkColor1;
      this.mBackground.SecondColor = lightDarkColor2;
    }
    else if (this.BackgroundColorStyle == BackgroundColorStyle.Linear)
    {
      this.mBackground.FirstColor = lightDarkColor2;
      this.mBackground.SecondColor = lightDarkColor1;
    }
    else if (this.BackgroundColorStyle == BackgroundColorStyle.Solid)
    {
      this.mBackground.FirstColor = this.BackColor;
      this.mBackground.SecondColor = this.BackColor;
    }
    else
    {
      this.mBackground.FirstColor = Color.Empty;
      this.mBackground.SecondColor = Color.Empty;
    }
    this.mBackground.Angle = this.GradientAngle;
    this.mBackground.Draw(graphics, area);
  }
}
