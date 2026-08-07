// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPad
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public sealed class PgpPad
{
  private PgpPad()
  {
  }

  public static byte[] PadSessionData(byte[] sessionInfo)
  {
    return PgpPad.PadSessionData(sessionInfo, true);
  }

  public static byte[] PadSessionData(byte[] sessionInfo, bool obfuscate)
  {
    int length = sessionInfo.Length;
    int val2 = (length >> 3) + 1 << 3;
    if (obfuscate)
      val2 = Math.Max(40, val2);
    byte num = (byte) (val2 - length);
    byte[] destinationArray = new byte[val2];
    Array.Copy((Array) sessionInfo, 0, (Array) destinationArray, 0, length);
    for (int index = length; index < val2; ++index)
      destinationArray[index] = num;
    return destinationArray;
  }

  public static byte[] UnpadSessionData(byte[] encoded)
  {
    int length1 = encoded.Length;
    byte num1 = encoded[length1 - 1];
    int num2 = (int) num1;
    int length2 = length1 - num2;
    int num3 = length2 - 1;
    int num4 = 0;
    for (int index = 0; index < length1; ++index)
    {
      int num5 = num3 - index >> 31 /*0x1F*/;
      num4 |= ((int) num1 ^ (int) encoded[index]) & num5;
    }
    if ((num4 | length1 & 7 | 40 - length1 >> 31 /*0x1F*/) != 0)
      throw new PgpException("bad padding found in session data");
    byte[] destinationArray = new byte[length2];
    Array.Copy((Array) encoded, 0, (Array) destinationArray, 0, length2);
    return destinationArray;
  }
}
