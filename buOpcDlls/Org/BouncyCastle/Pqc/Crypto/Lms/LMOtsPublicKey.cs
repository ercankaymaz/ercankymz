// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMOtsPublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsPublicKey
{
  private readonly LMOtsParameters m_parameters;
  private readonly byte[] m_I;
  private readonly int m_q;
  private readonly byte[] m_K;

  public LMOtsPublicKey(LMOtsParameters parameters, byte[] i, int q, byte[] k)
  {
    this.m_parameters = parameters;
    this.m_I = i;
    this.m_q = q;
    this.m_K = k;
  }

  public static LMOtsPublicKey GetInstance(object src)
  {
    switch (src)
    {
      case LMOtsPublicKey instance:
        return instance;
      case BinaryReader binaryReader:
        LMOtsParameters parametersById = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        byte[] i = BinaryReaders.ReadBytesFully(binaryReader, 16 /*0x10*/);
        int q = BinaryReaders.ReadInt32BigEndian(binaryReader);
        byte[] k = BinaryReaders.ReadBytesFully(binaryReader, parametersById.N);
        return new LMOtsPublicKey(parametersById, i, q, k);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer, false));
          return LMOtsPublicKey.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return LMOtsPublicKey.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new Exception($"cannot parse {src}");
    }
  }

  public LMOtsParameters Parameters => this.m_parameters;

  public byte[] I => this.m_I;

  public int Q => this.m_q;

  public byte[] K => this.m_K;

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is LMOtsPublicKey lmOtsPublicKey && this.m_q == lmOtsPublicKey.m_q && object.Equals((object) this.m_parameters, (object) lmOtsPublicKey.m_parameters) && Arrays.AreEqual(this.m_I, lmOtsPublicKey.m_I) && Arrays.AreEqual(this.m_K, lmOtsPublicKey.m_K);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * Objects.GetHashCode((object) this.m_parameters) + Arrays.GetHashCode(this.m_I)) + this.m_q) + Arrays.GetHashCode(this.m_K);
  }

  public byte[] GetEncoded()
  {
    return Composer.Compose().U32Str(this.m_parameters.ID).Bytes(this.m_I).U32Str(this.m_q).Bytes(this.m_K).Build();
  }

  internal LmsContext CreateOtsContext(LMOtsSignature signature)
  {
    IDigest digest = DigestUtilities.GetDigest(this.m_parameters.DigestOid);
    LmsUtilities.ByteArray(this.m_I, digest);
    LmsUtilities.U32Str(this.m_q, digest);
    LmsUtilities.U16Str((short) LMOts.D_MESG, digest);
    LmsUtilities.ByteArray(signature.C, digest);
    return new LmsContext(this, (object) signature, digest);
  }

  internal LmsContext CreateOtsContext(LmsSignature signature)
  {
    IDigest digest = DigestUtilities.GetDigest(this.m_parameters.DigestOid);
    LmsUtilities.ByteArray(this.m_I, digest);
    LmsUtilities.U32Str(this.m_q, digest);
    LmsUtilities.U16Str((short) LMOts.D_MESG, digest);
    LmsUtilities.ByteArray(signature.OtsSignature.C, digest);
    return new LmsContext(this, (object) signature, digest);
  }
}
