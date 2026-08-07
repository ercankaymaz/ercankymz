// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Bytes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Bytes
{
  public const int NumBits = 8;
  public const int NumBytes = 1;

  public static void Xor(int len, byte[] x, byte[] y, byte[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = (byte) ((uint) x[index] ^ (uint) y[index]);
  }

  public static void Xor(int len, byte[] x, int xOff, byte[] y, int yOff, byte[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] = (byte) ((uint) x[xOff + index] ^ (uint) y[yOff + index]);
  }

  public static void XorTo(int len, byte[] x, byte[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] ^= x[index];
  }

  public static void XorTo(int len, byte[] x, int xOff, byte[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] ^= x[xOff + index];
  }
}
