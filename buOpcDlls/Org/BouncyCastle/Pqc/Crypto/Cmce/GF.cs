// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.GF
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal interface GF
{
  void GFMulPoly(
    int length,
    int[] poly,
    ushort[] output,
    ushort[] left,
    ushort[] right,
    uint[] temp);

  void GFSqrPoly(int length, int[] poly, ushort[] output, ushort[] input, uint[] temp);

  ushort GFFrac(ushort den, ushort num);

  ushort GFInv(ushort input);

  ushort GFIsZero(ushort a);

  ushort GFMul(ushort left, ushort right);

  uint GFMulExt(ushort left, ushort right);

  ushort GFReduce(uint input);

  ushort GFSq(ushort input);

  uint GFSqExt(ushort input);
}
