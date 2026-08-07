// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1KeyUnwrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1KeyUnwrapper : IKeyUnwrapper
{
  private string algorithm;
  private IKeyUnwrapper wrapper;

  public Asn1KeyUnwrapper(string algorithm, ICipherParameters key)
  {
    this.algorithm = algorithm;
    this.wrapper = KeyWrapperUtil.UnwrapperForName(algorithm, key);
  }

  public Asn1KeyUnwrapper(DerObjectIdentifier algorithm, ICipherParameters key)
    : this(algorithm, (Asn1Encodable) null, key)
  {
  }

  public Asn1KeyUnwrapper(
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
      this.wrapper = (IKeyUnwrapper) wrapperProvider.CreateWrapper(false, key);
    }
    else
    {
      if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RsaEncryption))
        throw new ArgumentException("unknown algorithm: " + algorithm.Id);
      RsaesOaepParameters instance3 = RsaesOaepParameters.GetInstance((object) parameters);
      if (instance3.MaskGenAlgorithm.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdMgf1))
      {
        AlgorithmIdentifier instance4 = AlgorithmIdentifier.GetInstance((object) instance3.MaskGenAlgorithm.Parameters);
        RsaOaepWrapperProvider oaepWrapperProvider = new RsaOaepWrapperProvider(instance3.HashAlgorithm.Algorithm, instance4.Algorithm);
      }
      else
      {
        RsaOaepWrapperProvider oaepWrapperProvider1 = new RsaOaepWrapperProvider(instance3.HashAlgorithm.Algorithm, instance3.MaskGenAlgorithm.Algorithm);
      }
      this.wrapper = (IKeyUnwrapper) new RsaPkcs1Wrapper(false, key);
    }
  }

  public object AlgorithmDetails => this.wrapper.AlgorithmDetails;

  public IBlockResult Unwrap(byte[] keyData, int offSet, int length)
  {
    return this.wrapper.Unwrap(keyData, offSet, length);
  }
}
