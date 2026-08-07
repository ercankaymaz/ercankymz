// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1VerifierFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1VerifierFactory : IVerifierFactory
{
  private readonly AlgorithmIdentifier algID;
  private readonly AsymmetricKeyParameter publicKey;

  public Asn1VerifierFactory(string algorithm, AsymmetricKeyParameter publicKey)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("Key for verifying must be public", nameof (publicKey));
    DerObjectIdentifier algorithmOid = X509Utilities.GetAlgorithmOid(algorithm);
    this.publicKey = publicKey;
    this.algID = X509Utilities.GetSigAlgID(algorithmOid, algorithm);
  }

  public Asn1VerifierFactory(AlgorithmIdentifier algorithm, AsymmetricKeyParameter publicKey)
  {
    this.publicKey = publicKey;
    this.algID = algorithm;
  }

  public object AlgorithmDetails => (object) this.algID;

  public IStreamCalculator<IVerifier> CreateCalculator()
  {
    return (IStreamCalculator<IVerifier>) new DefaultVerifierCalculator(SignerUtilities.InitSigner(X509Utilities.GetSignatureName(this.algID), false, this.publicKey, (SecureRandom) null));
  }
}
