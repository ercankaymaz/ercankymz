// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace \u0082;

[CompilerGenerated]
internal class \u0001
{
  public static double RegenDeviation;
  internal static string \u0001;

  public double TimeFromVelocityDistanceAcceleration(
    double Vel,
    double Distance,
    double Acc,
    double Dec)
  {
    double num1;
    if (Vel <= 0.0 | Distance <= 0.0)
      num1 = 0.0;
    else if (Acc <= 0.0 | Dec <= 0.0)
    {
      num1 = Distance / Vel;
    }
    else
    {
      double num2 = Vel / Acc;
      double num3 = Vel / Dec;
      double num4 = 0.5 * num2 * Vel;
      double num5 = 0.5 * num3 * Vel;
      double num6 = Distance - num4 - num5;
      double num7 = num6 / Vel;
      if (num6 < 0.0)
      {
        num7 = 0.0;
        num2 = Math.Sqrt(Distance / 2.0 / Acc);
        num3 = Math.Sqrt(Distance / 2.0 / Acc);
      }
      num1 = num2 + num3 + num7;
    }
    return num1;
  }
}
