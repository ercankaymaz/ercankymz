// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMOtsSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsSignature : IEncodable
{
  private readonly LMOtsParameters m_paramType;
  private readonly byte[] m_C;
  private readonly byte[] m_y;

  public LMOtsSignature(LMOtsParameters paramType, byte[] c, byte[] y)
  {
    this.m_paramType = paramType;
    this.m_C = c;
    this.m_y = y;
  }

  public static LMOtsSignature GetInstance(object src)
  {
    switch (src)
    {
      case LMOtsSignature instance:
        return instance;
      case BinaryReader binaryReader:
        LMOtsParameters parametersById = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        byte[] c = BinaryReaders.ReadBytesFully(binaryReader, parametersById.N);
        byte[] y = BinaryReaders.ReadBytesFully(binaryReader, parametersById.P * parametersById.N);
        return new LMOtsSignature(parametersById, c, y);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer, false));
          return LMOtsSignature.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return LMOtsSignature.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new Exception($"cannot parse {src}");
    }
  }

  public LMOtsParameters ParamType => this.m_paramType;

  public byte[] C => this.m_C;

  public byte[] Y => this.m_y;

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is LMOtsSignature lmOtsSignature && object.Equals((object) this.m_paramType, (object) lmOtsSignature.m_paramType) && Arrays.AreEqual(this.m_C, lmOtsSignature.m_C) && Arrays.AreEqual(this.m_y, lmOtsSignature.m_y);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * Objects.GetHashCode((object) this.m_paramType) + Arrays.GetHashCode(this.m_C)) + Arrays.GetHashCode(this.m_y);
  }

  public byte[] GetEncoded()
  {
    return Composer.Compose().U32Str(this.m_paramType.ID).Bytes(this.m_C).Bytes(this.m_y).Build();
  }
}
