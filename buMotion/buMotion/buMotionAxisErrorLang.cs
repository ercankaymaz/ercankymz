// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionAxisErrorLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using \u0007;
using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionAxisErrorLang : buSerilization
{
  public string ClamperNotClosed;
  public string ClamperNotEmpty;
  public string ToolChangeFailure;
  public string CalculationError;
  public string FileOpenError;
  public string FileSaveError;
  public string NoProduct;
  public string PhaseError;
  public string EthercatInitFailure;
  public string AxesParameterUpdateFailure;
  public static byte f00016F;
  public string SoftwareLimitError;
  public string HardwareLimitError;
  public string DriveError;
  public string ErrorStop;
  public string FollowingError;
  public string HomingTimeout;
  public string AxisCommunicationError;
  public string PositiveDataLimitError;
  public string NegativeDataLimitError;
  public string PositiveSoftwareLimitError;
  public string NegativeSoftwareLimitError;
  public string MCStopFBError;
  public string MCResetFBError;
  public string MCPowerFBError;
  public string MCMoveAbsoluteFBError;
  public string MCMoveRelativeFBError;
  public string MCHomeFBError;
  public string MCSetPositionFBError;
  public string MCSetHomeFBError;
  public string MCJogFBError;

  static buMotionAxisErrorLang()
  {
    buMotionStatusLang.sClassName = "buMotionLangDefination";
    buMotionStatusLang.langStatus = (buMotionStatusLang) new buMotionAxisWarningLang();
    buMotionStatusLang.langError = (buMotionErrorLang) new \u0003();
    buMotionStatusLang.langWarning = (buMotionWarningLang) new \u0003();
    buMotionStatusLang.langAxisError = (buMotionAxisErrorLang) new \u0003();
    buMotionStatusLang.langAxisWarning = (buMotionAxisWarningLang) new \u0003();
    buMotionStatusLang.langMessage = (buMotionMessageLang) new \u0003();
  }
}
