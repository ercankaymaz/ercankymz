// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssSignature : IEncodable
{
  private readonly int m_lMinus1;
  private readonly LmsSignedPubKey[] m_signedPubKey;
  private readonly LmsSignature m_signature;

  public HssSignature(int lMinus1, LmsSignedPubKey[] signedPubKey, LmsSignature signature)
  {
    this.m_lMinus1 = lMinus1;
    this.m_signedPubKey = signedPubKey;
    this.m_signature = signature;
  }

  public static HssSignature GetInstance(object src, int L)
  {
    switch (src)
    {
      case HssSignature instance2:
        return instance2;
      case BinaryReader binaryReader:
        int lMinus1 = BinaryReaders.ReadInt32BigEndian(binaryReader);
        LmsSignedPubKey[] signedPubKey = lMinus1 == L - 1 ? new LmsSignedPubKey[lMinus1] : throw new Exception("nspk exceeded maxNspk");
        if (lMinus1 != 0)
        {
          for (int index = 0; index < signedPubKey.Length; ++index)
            signedPubKey[index] = new LmsSignedPubKey(LmsSignature.GetInstance(src), LmsPublicKeyParameters.GetInstance(src));
        }
        LmsSignature instance1 = LmsSignature.GetInstance(src);
        return new HssSignature(lMinus1, signedPubKey, instance1);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer));
          return HssSignature.GetInstance((object) src1, L);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return HssSignature.GetInstance((object) Streams.ReadAll(inStr), L);
      default:
        throw new ArgumentException($"cannot parse {src}");
    }
  }

  public int GetLMinus1() => this.m_lMinus1;

  public LmsSignedPubKey[] GetSignedPubKeys() => this.m_signedPubKey;

  public LmsSignature Signature => this.m_signature;

  public override bool Equals(object other)
  {
    if (this == other)
      return true;
    if (!(other is HssSignature hssSignature) || this.m_lMinus1 != hssSignature.m_lMinus1 || this.m_signedPubKey.Length != hssSignature.m_signedPubKey.Length)
      return false;
    for (int index = 0; index < this.m_signedPubKey.Length; ++index)
    {
      if (!this.m_signedPubKey[index].Equals((object) hssSignature.m_signedPubKey[index]))
        return false;
    }
    return object.Equals((object) this.m_signature, (object) hssSignature.m_signature);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * this.m_lMinus1 + this.m_signedPubKey.GetHashCode()) + (this.m_signature != null ? this.m_signature.GetHashCode() : 0);
  }

  public byte[] GetEncoded()
  {
    Composer composer = Composer.Compose();
    composer.U32Str(this.m_lMinus1);
    if (this.m_signedPubKey != null)
    {
      foreach (LmsSignedPubKey lmsSignedPubKey in this.m_signedPubKey)
        composer.Bytes((IEncodable) lmsSignedPubKey);
    }
    composer.Bytes((IEncodable) this.m_signature);
    return composer.Build();
  }
}
