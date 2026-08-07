// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.LowmcConstants
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal abstract class LowmcConstants
{
  internal Dictionary<string, string> _matrixToHex;
  internal uint[] linearMatrices;
  internal uint[] roundConstants;
  internal uint[] keyMatrices;
  internal KMatrices _LMatrix;
  internal KMatrices _KMatrix;
  internal KMatrices RConstants;
  internal uint[] linearMatrices_full;
  internal uint[] keyMatrices_full;
  internal uint[] keyMatrices_inv;
  internal uint[] linearMatrices_inv;
  internal uint[] roundConstants_full;
  internal KMatrices LMatrix_full;
  internal KMatrices LMatrix_inv;
  internal KMatrices KMatrix_full;
  internal KMatrices KMatrix_inv;
  internal KMatrices RConstants_full;

  internal static uint[] ReadFromProperty(string s, int intSize)
  {
    byte[] bs = Hex.Decode(s);
    uint[] numArray = new uint[intSize];
    for (int index = 0; index < bs.Length / 4; ++index)
      numArray[index] = Pack.LE_To_UInt32(bs, index * 4);
    return numArray;
  }

  private KMatricesWithPointer GET_MAT(KMatrices m, int r)
  {
    KMatricesWithPointer mat = new KMatricesWithPointer(m);
    mat.SetMatrixPointer(r * mat.GetSize());
    return mat;
  }

  internal KMatricesWithPointer LMatrix(PicnicEngine engine, int round)
  {
    if (engine.stateSizeBits == 128 /*0x80*/)
      return this.GET_MAT(this._LMatrix, round);
    if (engine.stateSizeBits == 129)
      return this.GET_MAT(this.LMatrix_full, round);
    if (engine.stateSizeBits == 192 /*0xC0*/)
      return engine.numRounds == 4 ? this.GET_MAT(this.LMatrix_full, round) : this.GET_MAT(this._LMatrix, round);
    if (engine.stateSizeBits == (int) byte.MaxValue)
      return this.GET_MAT(this.LMatrix_full, round);
    return engine.stateSizeBits == 256 /*0x0100*/ ? this.GET_MAT(this._LMatrix, round) : (KMatricesWithPointer) null;
  }

  internal KMatricesWithPointer LMatrixInv(PicnicEngine engine, int round)
  {
    return engine.stateSizeBits == 129 || engine.stateSizeBits == 192 /*0xC0*/ && engine.numRounds == 4 || engine.stateSizeBits == (int) byte.MaxValue ? this.GET_MAT(this.LMatrix_inv, round) : (KMatricesWithPointer) null;
  }

  internal KMatricesWithPointer KMatrix(PicnicEngine engine, int round)
  {
    if (engine.stateSizeBits == 128 /*0x80*/)
      return this.GET_MAT(this._KMatrix, round);
    if (engine.stateSizeBits == 129)
      return this.GET_MAT(this.KMatrix_full, round);
    if (engine.stateSizeBits == 192 /*0xC0*/)
      return engine.numRounds == 4 ? this.GET_MAT(this.KMatrix_full, round) : this.GET_MAT(this._KMatrix, round);
    if (engine.stateSizeBits == (int) byte.MaxValue)
      return this.GET_MAT(this.KMatrix_full, round);
    return engine.stateSizeBits == 256 /*0x0100*/ ? this.GET_MAT(this._KMatrix, round) : (KMatricesWithPointer) null;
  }

  internal KMatricesWithPointer KMatrixInv(PicnicEngine engine, int round)
  {
    return engine.stateSizeBits == 129 || engine.stateSizeBits == 192 /*0xC0*/ && engine.numRounds == 4 || engine.stateSizeBits == (int) byte.MaxValue ? this.GET_MAT(this.KMatrix_inv, round) : (KMatricesWithPointer) null;
  }

  internal KMatricesWithPointer RConstant(PicnicEngine engine, int round)
  {
    if (engine.stateSizeBits == 128 /*0x80*/)
      return this.GET_MAT(this.RConstants, round);
    if (engine.stateSizeBits == 129)
      return this.GET_MAT(this.RConstants_full, round);
    if (engine.stateSizeBits == 192 /*0xC0*/)
      return engine.numRounds == 4 ? this.GET_MAT(this.RConstants_full, round) : this.GET_MAT(this.RConstants, round);
    if (engine.stateSizeBits == (int) byte.MaxValue)
      return this.GET_MAT(this.RConstants_full, round);
    return engine.stateSizeBits == 256 /*0x0100*/ ? this.GET_MAT(this.RConstants, round) : (KMatricesWithPointer) null;
  }
}
