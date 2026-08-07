// Decompiled with JetBrains decompiler
// Type: buClass.SplineDrawVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class SplineDrawVar : buSerilization
{
  public entitySplineType Type = entitySplineType.SplineCubic;
  public bool Closed = false;
  public static List<string> Captions = new List<string>();
}
