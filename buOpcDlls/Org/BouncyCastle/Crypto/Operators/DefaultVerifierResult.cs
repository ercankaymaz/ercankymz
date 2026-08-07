// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.DefaultVerifierResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class DefaultVerifierResult : IVerifier
{
  private readonly ISigner mSigner;

  public DefaultVerifierResult(ISigner signer) => this.mSigner = signer;

  public bool IsVerified(byte[] signature) => this.mSigner.VerifySignature(signature);

  public bool IsVerified(byte[] sig, int sigOff, int sigLen)
  {
    return this.IsVerified(Arrays.CopyOfRange(sig, sigOff, sigOff + sigLen));
  }
}
