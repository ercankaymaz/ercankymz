// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssPublicKeyParameters : LmsKeyParameters, ILmsContextBasedVerifier
{
  private readonly int m_l;
  private readonly LmsPublicKeyParameters m_lmsPublicKey;

  public HssPublicKeyParameters(int l, LmsPublicKeyParameters lmsPublicKey)
    : base(false)
  {
    this.m_l = l;
    this.m_lmsPublicKey = lmsPublicKey;
  }

  public static HssPublicKeyParameters GetInstance(object src)
  {
    switch (src)
    {
      case HssPublicKeyParameters instance:
        return instance;
      case BinaryReader binaryReader:
        return new HssPublicKeyParameters(BinaryReaders.ReadInt32BigEndian(binaryReader), LmsPublicKeyParameters.GetInstance(src));
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer));
          return HssPublicKeyParameters.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return HssPublicKeyParameters.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new ArgumentException($"cannot parse {src}");
    }
  }

  public int L => this.m_l;

  public LmsPublicKeyParameters LmsPublicKey => this.m_lmsPublicKey;

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    HssPublicKeyParameters publicKeyParameters = (HssPublicKeyParameters) o;
    return this.m_l == publicKeyParameters.m_l && this.m_lmsPublicKey.Equals((object) publicKeyParameters.m_lmsPublicKey);
  }

  public override int GetHashCode() => 31 /*0x1F*/ * this.m_l + this.m_lmsPublicKey.GetHashCode();

  public override byte[] GetEncoded()
  {
    return Composer.Compose().U32Str(this.m_l).Bytes(this.m_lmsPublicKey.GetEncoded()).Build();
  }

  public LmsContext GenerateLmsContext(byte[] sigEnc)
  {
    HssSignature instance;
    try
    {
      instance = HssSignature.GetInstance((object) sigEnc, this.L);
    }
    catch (IOException ex)
    {
      throw new Exception("cannot parse signature: " + ex.Message);
    }
    LmsSignedPubKey[] signedPubKeys = instance.GetSignedPubKeys();
    return signedPubKeys[signedPubKeys.Length - 1].GetPublicKey().GenerateOtsContext(instance.Signature).WithSignedPublicKeys(signedPubKeys);
  }

  public bool Verify(LmsContext context)
  {
    LmsSignedPubKey[] signedPubKeys = context.SignedPubKeys;
    if (signedPubKeys.Length != this.L - 1)
      return false;
    LmsPublicKeyParameters publicKey = this.LmsPublicKey;
    bool flag = false;
    for (int index = 0; index < signedPubKeys.Length; ++index)
    {
      LmsSignature signature = signedPubKeys[index].GetSignature();
      byte[] byteArray = signedPubKeys[index].GetPublicKey().ToByteArray();
      if (!Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(publicKey, signature, byteArray))
        flag = true;
      publicKey = signedPubKeys[index].GetPublicKey();
    }
    return !flag & publicKey.Verify(context);
  }
}
