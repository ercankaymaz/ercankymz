// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.Reduce
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal static class Reduce
{
  internal static short MontgomeryReduce(int a)
  {
    int num = (int) (short) (a * 62209) * 3329;
    return (short) (a - num >> 16 /*0x10*/);
  }

  internal static short BarrettReduce(short a)
  {
    short num = (short) ((int) (short) (20159 * (int) a >> 26) * 3329);
    return (short) ((int) a - (int) num);
  }

  internal static short CondSubQ(short a)
  {
    a -= (short) 3329;
    a += (short) ((int) a >> 15 & 3329);
    return a;
  }
}
