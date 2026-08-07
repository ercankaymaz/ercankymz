// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.RsaOaepWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class RsaOaepWrapper : IKeyWrapper, IKeyUnwrapper
{
  private readonly AlgorithmIdentifier algId;
  private readonly IAsymmetricBlockCipher engine;

  public RsaOaepWrapper(
    bool forWrapping,
    ICipherParameters parameters,
    DerObjectIdentifier digestOid)
    : this(forWrapping, parameters, digestOid, digestOid)
  {
  }

  public RsaOaepWrapper(
    bool forWrapping,
    ICipherParameters parameters,
    DerObjectIdentifier digestOid,
    DerObjectIdentifier mgfOid)
  {
    AlgorithmIdentifier hashAlgorithm = new AlgorithmIdentifier(digestOid, (Asn1Encodable) DerNull.Instance);
    this.algId = mgfOid.Equals((Asn1Object) NistObjectIdentifiers.IdShake128) || mgfOid.Equals((Asn1Object) NistObjectIdentifiers.IdShake256) ? new AlgorithmIdentifier(PkcsObjectIdentifiers.IdRsaesOaep, (Asn1Encodable) new RsaesOaepParameters(hashAlgorithm, new AlgorithmIdentifier(mgfOid), RsaesOaepParameters.DefaultPSourceAlgorithm)) : new AlgorithmIdentifier(PkcsObjectIdentifiers.IdRsaesOaep, (Asn1Encodable) new RsaesOaepParameters(hashAlgorithm, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) new AlgorithmIdentifier(mgfOid, (Asn1Encodable) DerNull.Instance)), RsaesOaepParameters.DefaultPSourceAlgorithm));
    this.engine = (IAsymmetricBlockCipher) new OaepEncoding((IAsymmetricBlockCipher) new RsaBlindedEngine(), DigestUtilities.GetDigest(digestOid), DigestUtilities.GetDigest(mgfOid), (byte[]) null);
    this.engine.Init(forWrapping, parameters);
  }

  public object AlgorithmDetails => (object) this.algId;

  public IBlockResult Unwrap(byte[] cipherText, int offset, int length)
  {
    return (IBlockResult) new SimpleBlockResult(this.engine.ProcessBlock(cipherText, offset, length));
  }

  public IBlockResult Wrap(byte[] keyData)
  {
    return (IBlockResult) new SimpleBlockResult(this.engine.ProcessBlock(keyData, 0, keyData.Length));
  }
}
