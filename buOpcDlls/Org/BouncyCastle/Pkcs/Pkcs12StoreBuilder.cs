// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs12StoreBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs12StoreBuilder
{
  private DerObjectIdentifier keyAlgorithm = PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc;
  private DerObjectIdentifier certAlgorithm = PkcsObjectIdentifiers.PbewithShaAnd40BitRC2Cbc;
  private DerObjectIdentifier keyPrfAlgorithm;
  private bool useDerEncoding;

  public Pkcs12Store Build()
  {
    return new Pkcs12Store(this.keyAlgorithm, this.keyPrfAlgorithm, this.certAlgorithm, this.useDerEncoding);
  }

  public Pkcs12StoreBuilder SetCertAlgorithm(DerObjectIdentifier certAlgorithm)
  {
    this.certAlgorithm = certAlgorithm;
    return this;
  }

  public Pkcs12StoreBuilder SetKeyAlgorithm(DerObjectIdentifier keyAlgorithm)
  {
    this.keyAlgorithm = keyAlgorithm;
    return this;
  }

  public Pkcs12StoreBuilder SetKeyAlgorithm(
    DerObjectIdentifier keyAlgorithm,
    DerObjectIdentifier keyPrfAlgorithm)
  {
    this.keyAlgorithm = keyAlgorithm;
    this.keyPrfAlgorithm = keyPrfAlgorithm;
    return this;
  }

  public Pkcs12StoreBuilder SetUseDerEncoding(bool useDerEncoding)
  {
    this.useDerEncoding = useDerEncoding;
    return this;
  }
}
