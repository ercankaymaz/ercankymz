// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionStatusLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionStatusLang : buSerilization
{
  private static string sClassName;
  public static buMotionStatusLang langStatus;
  public static buMotionErrorLang langError;
  public static buMotionWarningLang langWarning;
  public static buMotionAxisErrorLang langAxisError;
  public static buMotionAxisWarningLang langAxisWarning;
  public static buMotionMessageLang langMessage;
  public static byte f000113;
  public string SystemisReady;

  public static void LoadAxisError(List<string> SL)
  {
    string str = nameof (LoadAxisError);
    try
    {
      if (SL.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionStatusLang.sClassName, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }
}
