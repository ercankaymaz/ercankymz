// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingPartSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPartSettings : buSerilization5
{
  public double BottomDrillPressMinLimit;
  public double BottomKorukXMinusDistance;
  public double BottomKorukXPlusDistance;
  public double BottomKorukYMinusDistance;
  public double BottomKorukYPlusDistance;
  public double SpindlePensDiameter;
  public double TopSpindleYOffsetForBottomOperation;
  public double Press61_65YDistanceFromY1Center;
  public double Press66_71YDistanceFromY1Center;
  public double Press72_74YDistanceFromY1Center;
  public double Press77_79YDistanceFromY1Center;
  public double Press161_165YDistanceFromY2Center;
  public double Press166_171YDistanceFromY2Center;
  public double Press172_174YDistanceFromY2Center;
  public double Press177_179YDistanceFromY2Center;
  public double Y1AndY2MinDistance;
  public double Y1AndY2HorizontalToolMinDistance;
  public double Y1GroupToolVerticalXOffset;
  public double Y1GroupToolVerticalYOffset;
  public double Y1GroupToolVerticalZOffset;

  public override string ToString()
  {
    return $"PositionX : {((DrillCNCSettings) this).PositionX.ToString("f2")}, PositionY : {((DrillCNCSettings) this).PositionY.ToString("f2")}, PositionA : {((DrillCNCSettings) this).PositionA.ToString("f2")}, StitchStep : {((DrillCNCSettings) this).StitchStep.ToString("f2")}, HeadSpeed : {((DrillCNCSettings) this).HeadSpeed.ToString("f2")}, StitchedWay : {((DrillCNCSettings) this).StitchedWay.ToString()}, StitchCount : {((DrillCNCSettings) this).StitchCount.ToString("f0")}, Style : {((DrillCNCSettings) this).Style.ToString("f0")}, Code1 : {((DrillCNCSettings) this).Code1.ToString("f0")}, Code2 : {((DrillCNCSettings) this).Code2.ToString("f0")}, Code3 : {((DrillCNCSettings) this).Code3.ToString("f0")}, Code4 : {((DrillCNCSettings) this).Code4.ToString("f0")}, Code5 : {((DrillCNCSettings) this).Code5.ToString("f0")}";
  }

  public abstract void m001BEC();
}
