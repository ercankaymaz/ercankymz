// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleSawCalcParameters
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleSawCalcParameters
{
  public bool TwistEnable;
  public double TwistStartAngle;
  public double TwistEndAngle;
  public double TwisStepAngle;
  public double TwistLengthDevideStep;
  public VectorXYType Direction;
  public CamAxisCountType CamTypeRough;
  public CamAxisCountType CamTypeFinish;
  public static List<string> Captions;
  public static byte f004D6D;
  public double Height;
  public double StepDistance;
  public double RapidDistance;
  public HorizontalVertical Direction;
  public MarbleAirDryPartType PartType;
  public static List<string> Captions;
  public static byte f004D74;
  public double CavityLength;
  public double CavityHeight;
  public double CavityDepth;
  public double CavityAngle;
  public double CavitySpace;
  public int CavityCount;
  public bool CavityZigzagMode;
  public static List<string> Captions;
  public static byte f004D7D;
  public double TapDiameter;
  public double TapLeftDiameter;

  public MarbleSawCalcParameters()
  {
    // ISSUE: unable to decompile the method.
  }

  public MarbleSawCalcParameters(MarbleRuntimeSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(MarbleRuntimeSettings Source, ref MarbleRuntimeSettings Target)
  {
    Target = (MarbleRuntimeSettings) new MarbleSawCalcParameters(Source);
  }
}
