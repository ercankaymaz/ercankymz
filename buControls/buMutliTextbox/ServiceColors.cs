// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ServiceColors
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace buMutliTextbox;

[Serializable]
public class ServiceColors
{
  public Color CollapseMarkerForeColor { get; set; }

  public Color CollapseMarkerBackColor { get; set; }

  public Color CollapseMarkerBorderColor { get; set; }

  public Color ExpandMarkerForeColor { get; set; }

  public Color ExpandMarkerBackColor { get; set; }

  public Color ExpandMarkerBorderColor { get; set; }

  public ServiceColors()
  {
    this.CollapseMarkerForeColor = Color.Silver;
    this.CollapseMarkerBackColor = Color.White;
    this.CollapseMarkerBorderColor = Color.Silver;
    this.ExpandMarkerForeColor = Color.Red;
    this.ExpandMarkerBackColor = Color.White;
    this.ExpandMarkerBorderColor = Color.Silver;
  }
}
