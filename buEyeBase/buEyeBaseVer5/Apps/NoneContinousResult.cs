// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.NoneContinousResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class NoneContinousResult
{
  public double ExecutedPipe;
  public double YPos;
  public double YPreasurePos;
  public double ZPos;

  public static ArrayList ToDef(FoamBlock refItem, int Space) => new ArrayList();
}
