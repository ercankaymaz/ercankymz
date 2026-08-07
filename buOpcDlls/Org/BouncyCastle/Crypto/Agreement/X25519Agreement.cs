// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.X25519Agreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public sealed class X25519Agreement : IRawAgreement
{
  private X25519PrivateKeyParameters m_privateKey;

  public void Init(ICipherParameters parameters)
  {
    this.m_privateKey = (X25519PrivateKeyParameters) parameters;
  }

  public int AgreementSize => X25519PrivateKeyParameters.SecretSize;

  public void CalculateAgreement(ICipherParameters publicKey, byte[] buf, int off)
  {
    this.m_privateKey.GenerateSecret((X25519PublicKeyParameters) publicKey, buf, off);
  }
}
