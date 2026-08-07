// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.Reduce
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class Reduce
{
  public static int MontgomeryReduce(long a)
  {
    int num = (int) (a * 58728449L);
    return (int) (a - (long) num * 8380417L >> 32 /*0x20*/);
  }

  public static int Reduce32(int a)
  {
    int num = a + 4194304 /*0x400000*/ >> 23;
    return a - num * 8380417;
  }

  public static int ConditionalAddQ(int a)
  {
    a += a >> 31 /*0x1F*/ & 8380417;
    return a;
  }
}
