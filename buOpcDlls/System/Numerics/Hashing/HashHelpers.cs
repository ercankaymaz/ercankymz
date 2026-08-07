// Decompiled with JetBrains decompiler
// Type: System.Numerics.Hashing.HashHelpers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Numerics.Hashing;

internal static class HashHelpers
{
  public static readonly int RandomSeed = Guid.NewGuid().GetHashCode();

  public static int Combine(int h1, int h2) => (h1 << 5 | h1 >>> 27) + h1 ^ h2;
}
