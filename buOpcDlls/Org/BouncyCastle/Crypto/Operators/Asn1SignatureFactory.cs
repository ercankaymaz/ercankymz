// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1SignatureFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1SignatureFactory : ISignatureFactory
{
  private readonly AlgorithmIdentifier algID;
  private readonly string algorithm;
  private readonly AsymmetricKeyParameter privateKey;
  private readonly SecureRandom random;

  public Asn1SignatureFactory(string algorithm, AsymmetricKeyParameter privateKey)
    : this(algorithm, privateKey, (SecureRandom) null)
  {
  }

  public Asn1SignatureFactory(
    string algorithm,
    AsymmetricKeyParameter privateKey,
    SecureRandom random)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (privateKey == null)
      throw new ArgumentNullException(nameof (privateKey));
    if (!privateKey.IsPrivate)
      throw new ArgumentException("Key for signing must be private", nameof (privateKey));
    DerObjectIdentifier algorithmOid = X509Utilities.GetAlgorithmOid(algorithm);
    this.algorithm = algorithm;
    this.privateKey = privateKey;
    this.random = random;
    this.algID = X509Utilities.GetSigAlgID(algorithmOid, algorithm);
  }

  public object AlgorithmDetails => (object) this.algID;

  public IStreamCalculator<IBlockResult> CreateCalculator()
  {
    return (IStreamCalculator<IBlockResult>) new DefaultSignatureCalculator(SignerUtilities.InitSigner(this.algorithm, true, this.privateKey, this.random));
  }

  public static IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();
}
