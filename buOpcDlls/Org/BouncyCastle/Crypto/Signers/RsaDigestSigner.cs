// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.RsaDigestSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class RsaDigestSigner : ISigner
{
  private readonly IAsymmetricBlockCipher rsaEngine;
  private readonly AlgorithmIdentifier algId;
  private readonly IDigest digest;
  private bool forSigning;
  private static readonly IDictionary<string, DerObjectIdentifier> OidMap = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static RsaDigestSigner()
  {
    RsaDigestSigner.OidMap["RIPEMD128"] = TeleTrusTObjectIdentifiers.RipeMD128;
    RsaDigestSigner.OidMap["RIPEMD160"] = TeleTrusTObjectIdentifiers.RipeMD160;
    RsaDigestSigner.OidMap["RIPEMD256"] = TeleTrusTObjectIdentifiers.RipeMD256;
    RsaDigestSigner.OidMap["SHA-1"] = X509ObjectIdentifiers.IdSha1;
    RsaDigestSigner.OidMap["SHA-224"] = NistObjectIdentifiers.IdSha224;
    RsaDigestSigner.OidMap["SHA-256"] = NistObjectIdentifiers.IdSha256;
    RsaDigestSigner.OidMap["SHA-384"] = NistObjectIdentifiers.IdSha384;
    RsaDigestSigner.OidMap["SHA-512"] = NistObjectIdentifiers.IdSha512;
    RsaDigestSigner.OidMap["SHA-512/224"] = NistObjectIdentifiers.IdSha512_224;
    RsaDigestSigner.OidMap["SHA-512/256"] = NistObjectIdentifiers.IdSha512_256;
    RsaDigestSigner.OidMap["SHA3-224"] = NistObjectIdentifiers.IdSha3_224;
    RsaDigestSigner.OidMap["SHA3-256"] = NistObjectIdentifiers.IdSha3_256;
    RsaDigestSigner.OidMap["SHA3-384"] = NistObjectIdentifiers.IdSha3_384;
    RsaDigestSigner.OidMap["SHA3-512"] = NistObjectIdentifiers.IdSha3_512;
    RsaDigestSigner.OidMap["MD2"] = PkcsObjectIdentifiers.MD2;
    RsaDigestSigner.OidMap["MD4"] = PkcsObjectIdentifiers.MD4;
    RsaDigestSigner.OidMap["MD5"] = PkcsObjectIdentifiers.MD5;
  }

  public RsaDigestSigner(IDigest digest)
    : this(digest, CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>(RsaDigestSigner.OidMap, digest.AlgorithmName))
  {
  }

  public RsaDigestSigner(IDigest digest, DerObjectIdentifier digestOid)
    : this(digest, new AlgorithmIdentifier(digestOid, (Asn1Encodable) DerNull.Instance))
  {
  }

  public RsaDigestSigner(IDigest digest, AlgorithmIdentifier algId)
    : this((IRsa) new RsaCoreEngine(), digest, algId)
  {
  }

  public RsaDigestSigner(IRsa rsa, IDigest digest, DerObjectIdentifier digestOid)
    : this(rsa, digest, new AlgorithmIdentifier(digestOid, (Asn1Encodable) DerNull.Instance))
  {
  }

  public RsaDigestSigner(IRsa rsa, IDigest digest, AlgorithmIdentifier algId)
    : this((IAsymmetricBlockCipher) new RsaBlindedEngine(rsa), digest, algId)
  {
  }

  public RsaDigestSigner(
    IAsymmetricBlockCipher rsaEngine,
    IDigest digest,
    AlgorithmIdentifier algId)
  {
    this.rsaEngine = (IAsymmetricBlockCipher) new Pkcs1Encoding(rsaEngine);
    this.digest = digest;
    this.algId = algId;
  }

  public virtual string AlgorithmName => this.digest.AlgorithmName + "withRSA";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    AsymmetricKeyParameter asymmetricKeyParameter = !(parameters is ParametersWithRandom parametersWithRandom) ? (AsymmetricKeyParameter) parameters : (AsymmetricKeyParameter) parametersWithRandom.Parameters;
    if (forSigning && !asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Signing requires private key.");
    if (!forSigning && asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Verification requires public key.");
    this.Reset();
    this.rsaEngine.Init(forSigning, parameters);
  }

  public virtual void Update(byte input) => this.digest.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.rsaEngine.GetOutputBlockSize();

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning)
      throw new InvalidOperationException("RsaDigestSigner not initialised for signature generation.");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    byte[] inBuf = this.DerEncode(numArray);
    return this.rsaEngine.ProcessBlock(inBuf, 0, inBuf.Length);
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning)
      throw new InvalidOperationException("RsaDigestSigner not initialised for verification");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    byte[] a;
    byte[] b;
    try
    {
      a = this.rsaEngine.ProcessBlock(signature, 0, signature.Length);
      b = this.DerEncode(numArray);
    }
    catch (Exception ex)
    {
      return false;
    }
    if (a.Length == b.Length)
      return Arrays.FixedTimeEquals(a, b);
    if (a.Length != b.Length - 2)
      return false;
    int num1 = a.Length - numArray.Length - 2;
    int num2 = b.Length - numArray.Length - 2;
    b[1] -= (byte) 2;
    b[3] -= (byte) 2;
    int num3 = 0;
    for (int index = 0; index < numArray.Length; ++index)
      num3 |= (int) a[num1 + index] ^ (int) b[num2 + index];
    for (int index = 0; index < num1; ++index)
      num3 |= (int) a[index] ^ (int) b[index];
    return num3 == 0;
  }

  public virtual void Reset() => this.digest.Reset();

  private byte[] DerEncode(byte[] hash)
  {
    return this.algId == null ? hash : new DigestInfo(this.algId, hash).GetDerEncoded();
  }
}
