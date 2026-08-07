// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Printer3DTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DTempVars
{
  public bool LockLayers;
  public bool ShowOperationInfo;
  public static List<string> Captions;
  public static byte f003B28;
  public double Length;
  public double Width;
  public double Angle;
  public bool Enable;

  public override string ToString() => "";

  public abstract void m001A8B();
}
