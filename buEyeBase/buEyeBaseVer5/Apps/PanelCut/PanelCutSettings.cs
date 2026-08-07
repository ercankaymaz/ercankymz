// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelCutSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutSettings : buSerilization5
{
  public ProfileScaleCenterType TextScaleCenter;
  public ContentAlignment TextAlignment;
  public Color TextColor;
  public double TextThickness;
  public static byte f00456D;
  public double distanceSafe;
  public double distanceRapid;
  public double distanceFirstApproach;
  public double velPlunge;
  public double velFeed;
  public double velFinish;

  public override string ToString() => ((ProfileSettings) this).Name.ToString();

  public abstract void m001DBB();
}
