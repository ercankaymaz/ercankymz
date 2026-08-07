// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.VisualMarkerEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class VisualMarkerEventArgs : MouseEventArgs
{
  public Style Style { get; private set; }

  public StyleVisualMarker Marker { get; private set; }

  public VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args)
    : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
  {
    this.Style = style;
    this.Marker = marker;
  }
}
