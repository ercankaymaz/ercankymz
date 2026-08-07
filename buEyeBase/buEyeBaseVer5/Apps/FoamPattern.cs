// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamPattern
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamPattern : buSerilization5
{
  public double RectangleLength;
  public double RectangleThickness;
  public double TopBottomCylinderDistance;
  public double LeftCylinderAngle;
  public double RightCylinderAngle;
  public double LeftCylinderDiameter;
  public double RightCylinderDiameter;
  public double UpCylinderDiameter;
  public double DownCylinderDiameter;
  public double LeftCylinderXOffset;
  public double LeftCylinderZOffset;
  public double RightCylinderXOffset;
  public double RightCylinderZOffset;
  public int SimulationIntervalMs;
  [SpecialName]
  public int value__;
  public const RollerBendMoveCommand None = ; // Unable to render the field
  public const RollerBendMoveCommand MoveFree = ; // Unable to render the field
  public const RollerBendMoveCommand MoveBend = ; // Unable to render the field
  public const RollerBendMoveCommand MoveMaterial = ; // Unable to render the field
  public const RollerBendMoveCommand CreateMaterial = ; // Unable to render the field
  public static List<string> LangRouterStatus;
  public static List<string> LangRouterMessage;
  public static List<string> LangRouterCaptions;

  public FoamPattern(
    double xPosition,
    double leftDistance,
    double leftAngle,
    double rightDistance,
    double rightAngle,
    double upDistance,
    RollerBendMoveCommand Cmd,
    int index = -1)
  {
    // ISSUE: unable to decompile the method.
  }

  public FoamPattern(
    double xPosition,
    double leftDistance,
    double rightDistance,
    double upDistance,
    RollerBendMoveCommand Cmd,
    int index = -1)
  {
    // ISSUE: unable to decompile the method.
  }

  public FoamPattern(RollerBendMove data)
  {
    // ISSUE: unable to decompile the method.
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }
}
