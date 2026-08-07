// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.MaxFragmentLength
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class MaxFragmentLength
{
  public const short pow2_9 = 1;
  public const short pow2_10 = 2;
  public const short pow2_11 = 3;
  public const short pow2_12 = 4;

  public static bool IsValid(short maxFragmentLength)
  {
    return maxFragmentLength >= (short) 1 && maxFragmentLength <= (short) 4;
  }
}
