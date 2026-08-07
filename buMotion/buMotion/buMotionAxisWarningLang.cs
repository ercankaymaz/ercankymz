// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionAxisWarningLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionAxisWarningLang : buSerilization
{
  public string MCLimitDynamicsFBError;
  public string MCGearInFBError;
  public string MCGearOutFBError;
  public string AxisOutofLimits;
  public string SMCChangeDynamicLimitsFBError;
  public string SMCChangeRatioFBError;
  public string SMCHomeFBError;
  public string SMCSoftLimitFBError;
  public string SMCRampTypeFBError;
  public string SMCMoveTypeFBError;
  public string ReInitFBError;
  public static byte f00018F;
  public string AxisDisable;
  public string AxisinError;
  public string AxisNeedHoming;
  public string AxisinMove;
  public string AxisFeedoverrideZero;
  public string AxisVelocityZero;
  public string AxisAccelerationZero;
  public string AxisDecelerationZero;
  public string AxisJerkZero;
  public string AxisHoming;
  public string AxisinAction;
  public string GainError;
  public string DriveError;
  public string ScaleParameterError;
  public string UnitParameterNotCorrect;
  public string EncoderParamterNotCorrect;
  public string MaxAccelerationParameterNotCorrect;
  public string MaxDecelerationParameterNotCorrect;
  public string MaxVelocityParameterNotCorrect;
  public string GantryModeError;
  public string NotMoveableAxis;
  public string MaxJerkParameterNotCorrect;
  public string DriveSetEnocderModeError;
  public string DriveSetAbsoluteSetError;
  public string DriveSetControlModeError;
  public string DriveSetVelocityModeError;

  public buMotionAxisWarningLang()
  {
    ((buMotionStatusLang) this).SystemisReady = "System Ready";
    ((buMotionWarningLang) this).SystemisRunning = "System Running";
    ((buMotionWarningLang) this).SysteminAlarm = "System Alarm";
    ((buMotionWarningLang) this).ToolMeasure = "Tool Measure";
    ((buMotionWarningLang) this).ToolChange = "Tool Change";
    ((buMotionWarningLang) this).GoingPark = "Going Park";
    ((buMotionWarningLang) this).GoingHoming = "Going Homing";
    ((buMotionWarningLang) this).SystemPaused = "System Paused";
    ((buMotionWarningLang) this).Calculating = "Calculating";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
