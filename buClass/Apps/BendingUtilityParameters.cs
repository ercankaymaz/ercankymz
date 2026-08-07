// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingUtilityParameters
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingUtilityParameters : buSerilization
{
  public List<ArcDevideByRadius> ArcDevide1Pt = new List<ArcDevideByRadius>();
  public List<ArcDevideByRadius> ArcDevide2Pt = new List<ArcDevideByRadius>();
  public List<ArcDevideByRadius> ArcDevide3Pt = new List<ArcDevideByRadius>();
  public List<ArcDevideByRadius> ArcDevide4Pt = new List<ArcDevideByRadius>();
  public List<BendXOffset> Bend1PtXOffset = new List<BendXOffset>();
  public List<BendXOffset> Bend2PtXOffset = new List<BendXOffset>();
  public List<BendXOffset> Bend3PtXOffset = new List<BendXOffset>();
  public List<BendXOffset> Bend4PtXOffset = new List<BendXOffset>();
  public List<RadiusBendCorrection> RadiusCorrection1Pt = new List<RadiusBendCorrection>();
  public List<RadiusBendCorrection> RadiusCorrection2Pt = new List<RadiusBendCorrection>();
  public List<RadiusBendCorrection> RadiusCorrection3Pt = new List<RadiusBendCorrection>();
  public List<RadiusBendCorrection> RadiusCorrection4Pt = new List<RadiusBendCorrection>();
  public List<AngleBendCorrection> AngleCorrection1Pt = new List<AngleBendCorrection>();
  public List<AngleBendCorrection> AngleCorrection2Pt = new List<AngleBendCorrection>();
  public List<AngleBendCorrection> AngleCorrection3Pt = new List<AngleBendCorrection>();
  public List<AngleBendCorrection> AngleCorrection4Pt = new List<AngleBendCorrection>();
  public List<double> DefaultCornerAngles = new List<double>();
  public List<double> DefaultRadius = new List<double>();
}
