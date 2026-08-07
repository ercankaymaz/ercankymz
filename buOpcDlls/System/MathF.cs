// Decompiled with JetBrains decompiler
// Type: System.MathF
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System;

internal static class MathF
{
  public const float PI = 3.14159274f;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Abs(float x) => Math.Abs(x);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Acos(float x) => (float) Math.Acos((double) x);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Cos(float x) => (float) Math.Cos((double) x);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float IEEERemainder(float x, float y)
  {
    return (float) Math.IEEERemainder((double) x, (double) y);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Pow(float x, float y) => (float) Math.Pow((double) x, (double) y);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Sin(float x) => (float) Math.Sin((double) x);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Sqrt(float x) => (float) Math.Sqrt((double) x);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static float Tan(float x) => (float) Math.Tan((double) x);
}
