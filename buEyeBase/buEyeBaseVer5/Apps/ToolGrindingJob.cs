// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ToolGrindingJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ToolGrindingJob : buSerilization5
{
  public double xRot;
  public double yRot;
  public double zRot;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoRadius() => ((Router3AXDisplaySettings) this).\u000E;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoRadius(double value) => ((Router3AXDisplaySettings) this).\u000E = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoWidth() => ((Router3AXRuntimeSettings) this).\u000F;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoWidth(double value) => ((Router3AXRuntimeSettings) this).\u000F = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoDepth() => ((Router3AXRuntimeSettings) this).\u0010;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoDepth(double value) => ((Router3AXRuntimeSettings) this).\u0010 = value;
}
