// Decompiled with JetBrains decompiler
// Type: buClass.FreeDraw
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class FreeDraw : buSerilization
{
  public FreeDrawMouseModeType MouseMode = FreeDrawMouseModeType.DownDown;
  public bool ConverToSpline = true;
  public double Length = 1.0;
  public entitySplineType SplineType = entitySplineType.SplineCubic;
  public static List<string> Captions = new List<string>();
}
