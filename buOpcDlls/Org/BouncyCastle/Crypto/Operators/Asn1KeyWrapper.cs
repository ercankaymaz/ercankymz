// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1KeyWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1KeyWrapper : IKeyWrapper
{
  private string algorithm;
  private IKeyWrapper wrapper;

  public Asn1KeyWrapper(string algorithm, X509Certificate cert)
  {
    this.algorithm = algorithm;
    this.wrapper = KeyWrapperUtil.WrapperForName(algorithm, (ICipherParameters) cert.GetPublicKey());
  }

  public Asn1KeyWrapper(DerObjectIdentifier algorithm, X509Certificate cert)
    : this(algorithm, (ICipherParameters) cert.GetPublicKey())
  {
  }

  public Asn1KeyWrapper(DerObjectIdentifier algorithm, ICipherParameters key)
    : this(algorithm, (Asn1Encodable) null, key)
  {
  }

  public Asn1KeyWrapper(
    DerObjectIdentifier algorithm,
    Asn1Encodable parameters,
    X509Certificate cert)
    : this(algorithm, parameters, (ICipherParameters) cert.GetPublicKey())
  {
  }

  public Asn1KeyWrapper(
    DerObjectIdentifier algorithm,
    Asn1Encodable parameters,
    ICipherParameters key)
  {
    this.algorithm = algorithm.Id;
    if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsaesOaep))
    {
      RsaesOaepParameters instance1 = RsaesOaepParameters.GetInstance((object) parameters);
      WrapperProvider wrapperProvider;
      if (instance1.MaskGenAlgorithm.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdMgf1))
      {
        AlgorithmIdentifier instance2 = AlgorithmIdentifier.GetInstance((object) instance1.MaskGenAlgorithm.Parameters);
        wrapperProvider = (WrapperProvider) new RsaOaepWrapperProvider(instance1.HashAlgorithm.Algorithm, instance2.Algorithm);
      }
      else
        wrapperProvider = (WrapperProvider) new RsaOaepWrapperProvider(instance1.HashAlgorithm.Algorithm, instance1.MaskGenAlgorithm.Algorithm);
      this.wrapper = (IKeyWrapper) wrapperProvider.CreateWrapper(true, key);
    }
    else
    {
      if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RsaEncryption))
        throw new ArgumentException("unknown algorithm: " + algorithm.Id);
      this.wrapper = (IKeyWrapper) new RsaPkcs1Wrapper(true, key);
    }
  }

  public object AlgorithmDetails => this.wrapper.AlgorithmDetails;

  public IBlockResult Wrap(byte[] keyData) => this.wrapper.Wrap(keyData);
}
