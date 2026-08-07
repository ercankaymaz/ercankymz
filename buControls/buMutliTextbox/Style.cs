// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Style
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace buMutliTextbox;

public abstract class Style : IDisposable
{
  public virtual bool IsExportable { get; set; }

  public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

  public Style() => this.IsExportable = true;

  public abstract void Draw(Graphics gr, Point position, Range range);

  public virtual void OnVisualMarkerClick(buMultiTextBox tb, VisualMarkerEventArgs args)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) tb, args);
  }

  protected virtual void AddVisualMarker(buMultiTextBox tb, StyleVisualMarker marker)
  {
    tb.AddVisualMarker((VisualMarker) marker);
  }

  public static Size GetSizeOfRange(Range range)
  {
    return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
  }

  public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
  {
    GraphicsPath roundedRectangle = new GraphicsPath();
    roundedRectangle.AddArc(rect.X, rect.Y, d, d, 180f, 90f);
    roundedRectangle.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270f, 90f);
    roundedRectangle.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0.0f, 90f);
    roundedRectangle.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90f, 90f);
    roundedRectangle.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);
    return roundedRectangle;
  }

  public virtual void Dispose()
  {
  }

  public virtual string GetCSS() => "";

  public virtual RTFStyleDescriptor GetRTF() => new RTFStyleDescriptor();
}
