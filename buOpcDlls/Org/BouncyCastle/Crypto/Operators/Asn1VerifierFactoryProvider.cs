// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1VerifierFactoryProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1VerifierFactoryProvider : IVerifierFactoryProvider
{
  private readonly AsymmetricKeyParameter publicKey;

  public Asn1VerifierFactoryProvider(AsymmetricKeyParameter publicKey)
  {
    this.publicKey = publicKey;
  }

  public IVerifierFactory CreateVerifierFactory(object algorithmDetails)
  {
    return (IVerifierFactory) new Asn1VerifierFactory((AlgorithmIdentifier) algorithmDetails, this.publicKey);
  }

  public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();
}
