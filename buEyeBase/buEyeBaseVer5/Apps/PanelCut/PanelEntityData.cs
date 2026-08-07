// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelEntityData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelEntityData : buSerilization5
{
  public static byte f004530;
  public double SlotWidth;
  public double SlotDiameter;
  public double SlotAngle;
  public Color SlotColor;
  public double SlotThickness;

  public override string ToString() => ((ProfileSettings) this).Name.ToString();

  public abstract void m001DAE();
}
