// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendRuntimeSettings : buSerilization5
{
  private static string \u0001;
  private static string \u0002;

  public PipeBendRuntimeSettings()
  {
    if (!buVector5.\u0001("buFlexoCalc"))
      throw new RegisterException("buFlexoCalc");
  }

  static PipeBendRuntimeSettings() => PipeBendTempVars.UnlockString = "";
}
