// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System;
using System.Collections.Generic;

#nullable disable
namespace \u0007;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
internal class \u0002 : Attribute
{
  static \u0002()
  {
    buMotionColors.LogFileName = "buMotionLog.csv";
    buMotionColors.ExceptionFileName = "buMotionException.csv";
    buMotionColors.SeasonFileName = "buMotionSeason.csv";
    TechnicianType.LogList = (List<string>) null;
  }
}
