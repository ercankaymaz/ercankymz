// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMOtsPrivateKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsPrivateKey
{
  private readonly LMOtsParameters m_parameters;
  private readonly byte[] m_I;
  private readonly int m_q;
  private readonly byte[] m_masterSecret;

  public LMOtsPrivateKey(LMOtsParameters parameters, byte[] i, int q, byte[] masterSecret)
  {
    this.m_parameters = parameters;
    this.m_I = i;
    this.m_q = q;
    this.m_masterSecret = masterSecret;
  }

  public LmsContext GetSignatureContext(LMSigParameters sigParams, byte[][] path)
  {
    byte[] numArray = new byte[LMOts.SEED_LEN];
    SeedDerive derivationFunction = this.GetDerivationFunction();
    derivationFunction.J = LMOts.SEED_RANDOMISER_INDEX;
    derivationFunction.DeriveSeed(false, numArray, 0);
    IDigest digest = DigestUtilities.GetDigest(this.m_parameters.DigestOid);
    LmsUtilities.ByteArray(this.m_I, digest);
    LmsUtilities.U32Str(this.m_q, digest);
    LmsUtilities.U16Str((short) LMOts.D_MESG, digest);
    LmsUtilities.ByteArray(numArray, digest);
    return new LmsContext(this, sigParams, digest, numArray, path);
  }

  internal SeedDerive GetDerivationFunction()
  {
    return new SeedDerive(this.m_I, this.m_masterSecret, DigestUtilities.GetDigest(this.m_parameters.DigestOid))
    {
      Q = this.m_q,
      J = 0
    };
  }

  public LMOtsParameters Parameters => this.m_parameters;

  public byte[] I => this.m_I;

  public int Q => this.m_q;

  public byte[] MasterSecret => this.m_masterSecret;
}
