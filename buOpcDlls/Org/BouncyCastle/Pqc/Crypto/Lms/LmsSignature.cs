// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class LmsSignature : IEncodable
{
  private int q;
  private LMOtsSignature otsSignature;
  private LMSigParameters parameter;
  private byte[][] y;

  public LmsSignature(int q, LMOtsSignature otsSignature, LMSigParameters parameter, byte[][] y)
  {
    this.q = q;
    this.otsSignature = otsSignature;
    this.parameter = parameter;
    this.y = y;
  }

  public static LmsSignature GetInstance(object src)
  {
    switch (src)
    {
      case LmsSignature instance2:
        return instance2;
      case BinaryReader binaryReader:
        int q = BinaryReaders.ReadInt32BigEndian(binaryReader);
        LMOtsSignature instance1 = LMOtsSignature.GetInstance(src);
        LMSigParameters parametersById = LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        byte[][] y = new byte[parametersById.H][];
        for (int index = 0; index < y.Length; ++index)
        {
          y[index] = new byte[parametersById.M];
          binaryReader.Read(y[index], 0, y[index].Length);
        }
        return new LmsSignature(q, instance1, parametersById, y);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer, false));
          return LmsSignature.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return LmsSignature.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new Exception($"cannot parse {src}");
    }
  }

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    LmsSignature lmsSignature = (LmsSignature) o;
    return this.q == lmsSignature.q && (this.otsSignature != null ? (!this.otsSignature.Equals((object) lmsSignature.otsSignature) ? 1 : 0) : (lmsSignature.otsSignature != null ? 1 : 0)) == 0 && (this.parameter != null ? (!this.parameter.Equals((object) lmsSignature.parameter) ? 1 : 0) : (lmsSignature.parameter != null ? 1 : 0)) == 0 && this.Compare2DArrays(this.y, lmsSignature.y);
  }

  private bool Compare2DArrays(byte[][] a, byte[][] b)
  {
    for (int index1 = 0; index1 < a.Length; ++index1)
    {
      for (int index2 = 0; index2 < a[0].Length; ++index2)
      {
        if (!a[index1][index2].Equals(b[index1][index2]))
          return false;
      }
    }
    return true;
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * this.q + (this.otsSignature != null ? this.otsSignature.GetHashCode() : 0)) + (this.parameter != null ? this.parameter.GetHashCode() : 0);
  }

  public byte[] GetEncoded()
  {
    return Composer.Compose().U32Str(this.q).Bytes(this.otsSignature.GetEncoded()).U32Str(this.parameter.ID).Bytes2(this.y).Build();
  }

  public int Q => this.q;

  public LMOtsSignature OtsSignature => this.otsSignature;

  public LMSigParameters SigParameters => this.parameter;

  public byte[][] Y => this.y;
}
