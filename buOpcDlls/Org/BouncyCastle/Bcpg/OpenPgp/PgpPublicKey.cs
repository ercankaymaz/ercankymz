// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cryptlib;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Gnu;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpPublicKey : PgpObject
{
  private static readonly PgpKdfParameters DefaultKdfParameters = new PgpKdfParameters(HashAlgorithmTag.Sha256, SymmetricKeyAlgorithmTag.Aes128);
  private static readonly int[] MasterKeyCertificationTypes = new int[5]
  {
    19,
    18,
    17,
    16 /*0x10*/,
    31 /*0x1F*/
  };
  internal PublicKeyPacket publicPk;
  internal TrustPacket trustPk;
  internal IList<PgpSignature> keySigs = (IList<PgpSignature>) new List<PgpSignature>();
  internal IList<IUserDataPacket> ids = (IList<IUserDataPacket>) new List<IUserDataPacket>();
  internal IList<TrustPacket> idTrusts = (IList<TrustPacket>) new List<TrustPacket>();
  internal IList<IList<PgpSignature>> idSigs = (IList<IList<PgpSignature>>) new List<IList<PgpSignature>>();
  internal IList<PgpSignature> subSigs;
  private long keyId;
  private byte[] fingerprint;
  private int keyStrength;

  public static byte[] CalculateFingerprint(PublicKeyPacket publicPk)
  {
    IBcpgKey key = publicPk.Key;
    IDigest digest;
    if (publicPk.Version <= 3)
    {
      RsaPublicBcpgKey rsaPublicBcpgKey = (RsaPublicBcpgKey) key;
      try
      {
        digest = PgpUtilities.CreateDigest(HashAlgorithmTag.MD5);
        PgpPublicKey.UpdateDigest(digest, rsaPublicBcpgKey.Modulus);
        PgpPublicKey.UpdateDigest(digest, rsaPublicBcpgKey.PublicExponent);
      }
      catch (Exception ex)
      {
        throw new PgpException("can't encode key components: " + ex.Message, ex);
      }
    }
    else
    {
      try
      {
        byte[] encodedContents = publicPk.GetEncodedContents();
        digest = PgpUtilities.CreateDigest(HashAlgorithmTag.Sha1);
        digest.Update((byte) 153);
        digest.Update((byte) (encodedContents.Length >> 8));
        digest.Update((byte) encodedContents.Length);
        digest.BlockUpdate(encodedContents, 0, encodedContents.Length);
      }
      catch (Exception ex)
      {
        throw new PgpException("can't encode key components: " + ex.Message, ex);
      }
    }
    return DigestUtilities.DoFinal(digest);
  }

  private static void UpdateDigest(IDigest d, BigInteger b)
  {
    byte[] byteArrayUnsigned = b.ToByteArrayUnsigned();
    d.BlockUpdate(byteArrayUnsigned, 0, byteArrayUnsigned.Length);
  }

  private void Init()
  {
    IBcpgKey key = this.publicPk.Key;
    this.fingerprint = PgpPublicKey.CalculateFingerprint(this.publicPk);
    if (this.publicPk.Version <= 3)
    {
      RsaPublicBcpgKey rsaPublicBcpgKey = (RsaPublicBcpgKey) key;
      this.keyId = rsaPublicBcpgKey.Modulus.LongValue;
      this.keyStrength = rsaPublicBcpgKey.Modulus.BitLength;
    }
    else
    {
      this.keyId = (long) this.fingerprint[this.fingerprint.Length - 8] << 56 | (long) this.fingerprint[this.fingerprint.Length - 7] << 48 /*0x30*/ | (long) this.fingerprint[this.fingerprint.Length - 6] << 40 | (long) this.fingerprint[this.fingerprint.Length - 5] << 32 /*0x20*/ | (long) this.fingerprint[this.fingerprint.Length - 4] << 24 | (long) this.fingerprint[this.fingerprint.Length - 3] << 16 /*0x10*/ | (long) this.fingerprint[this.fingerprint.Length - 2] << 8 | (long) this.fingerprint[this.fingerprint.Length - 1];
      switch (key)
      {
        case RsaPublicBcpgKey _:
          this.keyStrength = ((RsaPublicBcpgKey) key).Modulus.BitLength;
          break;
        case DsaPublicBcpgKey _:
          this.keyStrength = ((DsaPublicBcpgKey) key).P.BitLength;
          break;
        case ElGamalPublicBcpgKey _:
          this.keyStrength = ((ElGamalPublicBcpgKey) key).P.BitLength;
          break;
        case EdDsaPublicBcpgKey dsaPublicBcpgKey:
          DerObjectIdentifier curveOid = dsaPublicBcpgKey.CurveOid;
          if (!EdECObjectIdentifiers.id_Ed25519.Equals((Asn1Object) curveOid) && !GnuObjectIdentifiers.Ed25519.Equals((Asn1Object) curveOid) && !EdECObjectIdentifiers.id_X25519.Equals((Asn1Object) curveOid) && !CryptlibObjectIdentifiers.curvey25519.Equals((Asn1Object) curveOid))
          {
            if (!EdECObjectIdentifiers.id_Ed448.Equals((Asn1Object) curveOid) && !EdECObjectIdentifiers.id_X448.Equals((Asn1Object) curveOid))
            {
              this.keyStrength = -1;
              break;
            }
            this.keyStrength = 448;
            break;
          }
          this.keyStrength = 256 /*0x0100*/;
          break;
        case ECPublicBcpgKey ecPublicBcpgKey:
          X9ECParametersHolder ecCurveByOidLazy = ECKeyPairGenerator.FindECCurveByOidLazy(ecPublicBcpgKey.CurveOid);
          if (ecCurveByOidLazy != null)
          {
            this.keyStrength = ecCurveByOidLazy.Curve.FieldSize;
            break;
          }
          this.keyStrength = -1;
          break;
      }
    }
  }

  public PgpPublicKey(
    PublicKeyAlgorithmTag algorithm,
    AsymmetricKeyParameter pubKey,
    DateTime time)
  {
    if (pubKey.IsPrivate)
      throw new ArgumentException("Expected a public key", nameof (pubKey));
    IBcpgKey key;
    switch (pubKey)
    {
      case RsaKeyParameters rsaKeyParameters:
        key = (IBcpgKey) new RsaPublicBcpgKey(rsaKeyParameters.Modulus, rsaKeyParameters.Exponent);
        break;
      case DsaPublicKeyParameters publicKeyParameters1:
        DsaParameters parameters1 = publicKeyParameters1.Parameters;
        key = (IBcpgKey) new DsaPublicBcpgKey(parameters1.P, parameters1.Q, parameters1.G, publicKeyParameters1.Y);
        break;
      case ElGamalPublicKeyParameters publicKeyParameters2:
        ElGamalParameters parameters2 = publicKeyParameters2.Parameters;
        key = (IBcpgKey) new ElGamalPublicBcpgKey(parameters2.P, parameters2.G, publicKeyParameters2.Y);
        break;
      case ECPublicKeyParameters publicKeyParameters3:
        if (algorithm == PublicKeyAlgorithmTag.ECDH)
        {
          key = (IBcpgKey) new ECDHPublicBcpgKey(publicKeyParameters3.PublicKeyParamSet, publicKeyParameters3.Q, HashAlgorithmTag.Sha256, SymmetricKeyAlgorithmTag.Aes128);
          break;
        }
        if (algorithm != PublicKeyAlgorithmTag.ECDsa)
          throw new PgpException("unknown EC algorithm");
        key = (IBcpgKey) new ECDsaPublicBcpgKey(publicKeyParameters3.PublicKeyParamSet, publicKeyParameters3.Q);
        break;
      case Ed25519PublicKeyParameters publicKeyParameters4:
        byte[] numArray1 = new byte[1 + Ed25519PublicKeyParameters.KeySize];
        numArray1[0] = (byte) 64 /*0x40*/;
        publicKeyParameters4.Encode(numArray1, 1);
        key = (IBcpgKey) new EdDsaPublicBcpgKey(GnuObjectIdentifiers.Ed25519, new BigInteger(1, numArray1));
        break;
      case Ed448PublicKeyParameters publicKeyParameters5:
        byte[] numArray2 = new byte[Ed448PublicKeyParameters.KeySize];
        publicKeyParameters5.Encode(numArray2, 0);
        key = (IBcpgKey) new EdDsaPublicBcpgKey(EdECObjectIdentifiers.id_Ed448, new BigInteger(1, numArray2));
        break;
      case X25519PublicKeyParameters publicKeyParameters6:
        byte[] numArray3 = new byte[1 + X25519PublicKeyParameters.KeySize];
        numArray3[0] = (byte) 64 /*0x40*/;
        publicKeyParameters6.Encode(numArray3, 1);
        PgpKdfParameters defaultKdfParameters1 = PgpPublicKey.DefaultKdfParameters;
        key = (IBcpgKey) new ECDHPublicBcpgKey(CryptlibObjectIdentifiers.curvey25519, new BigInteger(1, numArray3), defaultKdfParameters1.HashAlgorithm, defaultKdfParameters1.SymmetricWrapAlgorithm);
        break;
      case X448PublicKeyParameters publicKeyParameters7:
        byte[] numArray4 = new byte[X448PublicKeyParameters.KeySize];
        publicKeyParameters7.Encode(numArray4, 0);
        PgpKdfParameters defaultKdfParameters2 = PgpPublicKey.DefaultKdfParameters;
        key = (IBcpgKey) new ECDHPublicBcpgKey(EdECObjectIdentifiers.id_X448, new BigInteger(1, numArray4), defaultKdfParameters2.HashAlgorithm, defaultKdfParameters2.SymmetricWrapAlgorithm);
        break;
      default:
        throw new PgpException("unknown key class");
    }
    this.publicPk = new PublicKeyPacket(algorithm, time, key);
    this.ids = (IList<IUserDataPacket>) new List<IUserDataPacket>();
    this.idSigs = (IList<IList<PgpSignature>>) new List<IList<PgpSignature>>();
    try
    {
      this.Init();
    }
    catch (IOException ex)
    {
      throw new PgpException("exception calculating keyId", (Exception) ex);
    }
  }

  public PgpPublicKey(PublicKeyPacket publicPk)
    : this(publicPk, (IList<IUserDataPacket>) new List<IUserDataPacket>(), (IList<IList<PgpSignature>>) new List<IList<PgpSignature>>())
  {
  }

  internal PgpPublicKey(PublicKeyPacket publicPk, TrustPacket trustPk, IList<PgpSignature> sigs)
  {
    this.publicPk = publicPk;
    this.trustPk = trustPk;
    this.subSigs = sigs;
    this.Init();
  }

  internal PgpPublicKey(PgpPublicKey key, TrustPacket trust, IList<PgpSignature> subSigs)
  {
    this.publicPk = key.publicPk;
    this.trustPk = trust;
    this.subSigs = subSigs;
    this.fingerprint = key.fingerprint;
    this.keyId = key.keyId;
    this.keyStrength = key.keyStrength;
  }

  internal PgpPublicKey(PgpPublicKey pubKey)
  {
    this.publicPk = pubKey.publicPk;
    this.keySigs = (IList<PgpSignature>) new List<PgpSignature>((IEnumerable<PgpSignature>) pubKey.keySigs);
    this.ids = (IList<IUserDataPacket>) new List<IUserDataPacket>((IEnumerable<IUserDataPacket>) pubKey.ids);
    this.idTrusts = (IList<TrustPacket>) new List<TrustPacket>((IEnumerable<TrustPacket>) pubKey.idTrusts);
    this.idSigs = (IList<IList<PgpSignature>>) new List<IList<PgpSignature>>(pubKey.idSigs.Count);
    for (int index = 0; index < pubKey.idSigs.Count; ++index)
      this.idSigs.Add((IList<PgpSignature>) new List<PgpSignature>((IEnumerable<PgpSignature>) pubKey.idSigs[index]));
    if (pubKey.subSigs != null)
      this.subSigs = (IList<PgpSignature>) new List<PgpSignature>((IEnumerable<PgpSignature>) pubKey.subSigs);
    this.fingerprint = pubKey.fingerprint;
    this.keyId = pubKey.keyId;
    this.keyStrength = pubKey.keyStrength;
  }

  internal PgpPublicKey(
    PublicKeyPacket publicPk,
    TrustPacket trustPk,
    IList<PgpSignature> keySigs,
    IList<IUserDataPacket> ids,
    IList<TrustPacket> idTrusts,
    IList<IList<PgpSignature>> idSigs)
  {
    this.publicPk = publicPk;
    this.trustPk = trustPk;
    this.keySigs = keySigs;
    this.ids = ids;
    this.idTrusts = idTrusts;
    this.idSigs = idSigs;
    this.Init();
  }

  internal PgpPublicKey(
    PublicKeyPacket publicPk,
    IList<IUserDataPacket> ids,
    IList<IList<PgpSignature>> idSigs)
  {
    this.publicPk = publicPk;
    this.ids = ids;
    this.idSigs = idSigs;
    this.Init();
  }

  internal PgpPublicKey(
    PgpPublicKey original,
    TrustPacket trustPk,
    List<PgpSignature> keySigs,
    List<IUserDataPacket> ids,
    List<TrustPacket> idTrusts,
    IList<IList<PgpSignature>> idSigs)
  {
    this.publicPk = original.publicPk;
    this.fingerprint = original.fingerprint;
    this.keyStrength = original.keyStrength;
    this.keyId = original.keyId;
    this.trustPk = trustPk;
    this.keySigs = (IList<PgpSignature>) keySigs;
    this.ids = (IList<IUserDataPacket>) ids;
    this.idTrusts = (IList<TrustPacket>) idTrusts;
    this.idSigs = idSigs;
  }

  public int Version => this.publicPk.Version;

  public DateTime CreationTime => this.publicPk.GetTime();

  public byte[] GetTrustData()
  {
    return this.trustPk == null ? (byte[]) null : Arrays.Clone(this.trustPk.GetLevelAndTrustAmount());
  }

  public long GetValidSeconds()
  {
    if (this.publicPk.Version <= 3)
      return (long) this.publicPk.ValidDays * 86400L;
    if (this.IsMasterKey)
    {
      for (int index = 0; index != PgpPublicKey.MasterKeyCertificationTypes.Length; ++index)
      {
        long expirationTimeFromSig = this.GetExpirationTimeFromSig(true, PgpPublicKey.MasterKeyCertificationTypes[index]);
        if (expirationTimeFromSig >= 0L)
          return expirationTimeFromSig;
      }
    }
    else
    {
      long expirationTimeFromSig1 = this.GetExpirationTimeFromSig(false, 24);
      if (expirationTimeFromSig1 >= 0L)
        return expirationTimeFromSig1;
      long expirationTimeFromSig2 = this.GetExpirationTimeFromSig(false, 31 /*0x1F*/);
      if (expirationTimeFromSig2 >= 0L)
        return expirationTimeFromSig2;
    }
    return 0;
  }

  private long GetExpirationTimeFromSig(bool selfSigned, int signatureType)
  {
    long expirationTimeFromSig = -1;
    long num = -1;
    foreach (PgpSignature pgpSignature in this.GetSignaturesOfType(signatureType))
    {
      if (!selfSigned || pgpSignature.KeyId == this.KeyId)
      {
        PgpSignatureSubpacketVector hashedSubPackets = pgpSignature.GetHashedSubPackets();
        if (hashedSubPackets != null && hashedSubPackets.HasSubpacket(SignatureSubpacketTag.KeyExpireTime))
        {
          long keyExpirationTime = hashedSubPackets.GetKeyExpirationTime();
          if (pgpSignature.KeyId == this.KeyId)
          {
            DateTime creationTime = pgpSignature.CreationTime;
            if (creationTime.Ticks > num)
            {
              creationTime = pgpSignature.CreationTime;
              num = creationTime.Ticks;
              expirationTimeFromSig = keyExpirationTime;
            }
          }
          else if (keyExpirationTime == 0L || keyExpirationTime > expirationTimeFromSig)
            expirationTimeFromSig = keyExpirationTime;
        }
      }
    }
    return expirationTimeFromSig;
  }

  public long KeyId => this.keyId;

  public byte[] GetFingerprint() => (byte[]) this.fingerprint.Clone();

  public bool IsEncryptionKey
  {
    get
    {
      switch (this.publicPk.Algorithm)
      {
        case PublicKeyAlgorithmTag.RsaGeneral:
        case PublicKeyAlgorithmTag.RsaEncrypt:
        case PublicKeyAlgorithmTag.ElGamalEncrypt:
        case PublicKeyAlgorithmTag.ECDH:
        case PublicKeyAlgorithmTag.ElGamalGeneral:
          return true;
        default:
          return false;
      }
    }
  }

  public bool IsMasterKey
  {
    get
    {
      if (this.publicPk is PublicSubkeyPacket)
        return false;
      return !this.IsEncryptionKey || this.publicPk.Algorithm == PublicKeyAlgorithmTag.RsaGeneral;
    }
  }

  public PublicKeyAlgorithmTag Algorithm => this.publicPk.Algorithm;

  public int BitStrength => this.keyStrength;

  public AsymmetricKeyParameter GetKey()
  {
    try
    {
      switch (this.publicPk.Algorithm)
      {
        case PublicKeyAlgorithmTag.RsaGeneral:
        case PublicKeyAlgorithmTag.RsaEncrypt:
        case PublicKeyAlgorithmTag.RsaSign:
          RsaPublicBcpgKey key1 = (RsaPublicBcpgKey) this.publicPk.Key;
          return (AsymmetricKeyParameter) new RsaKeyParameters(false, key1.Modulus, key1.PublicExponent);
        case PublicKeyAlgorithmTag.ElGamalEncrypt:
        case PublicKeyAlgorithmTag.ElGamalGeneral:
          ElGamalPublicBcpgKey key2 = (ElGamalPublicBcpgKey) this.publicPk.Key;
          return (AsymmetricKeyParameter) new ElGamalPublicKeyParameters(key2.Y, new ElGamalParameters(key2.P, key2.G));
        case PublicKeyAlgorithmTag.Dsa:
          DsaPublicBcpgKey key3 = (DsaPublicBcpgKey) this.publicPk.Key;
          return (AsymmetricKeyParameter) new DsaPublicKeyParameters(key3.Y, new DsaParameters(key3.P, key3.Q, key3.G));
        case PublicKeyAlgorithmTag.ECDH:
          ECDHPublicBcpgKey key4 = (ECDHPublicBcpgKey) this.publicPk.Key;
          DerObjectIdentifier curveOid1 = key4.CurveOid;
          if (!EdECObjectIdentifiers.id_X25519.Equals((Asn1Object) curveOid1) && !CryptlibObjectIdentifiers.curvey25519.Equals((Asn1Object) curveOid1))
          {
            if (!EdECObjectIdentifiers.id_X448.Equals((Asn1Object) curveOid1))
              return (AsymmetricKeyParameter) this.GetECKey("ECDH", (ECPublicBcpgKey) key4);
            byte[] data = BigIntegers.AsUnsignedByteArray(57, key4.EncodedPoint);
            if (data[0] != (byte) 64 /*0x40*/)
              throw new ArgumentException("Invalid X448 public key");
            return PublicKeyFactory.CreateKey(new SubjectPublicKeyInfo(new AlgorithmIdentifier(curveOid1), Arrays.CopyOfRange(data, 1, data.Length)));
          }
          byte[] data1 = BigIntegers.AsUnsignedByteArray(33, key4.EncodedPoint);
          if (data1[0] != (byte) 64 /*0x40*/)
            throw new ArgumentException("Invalid X25519 public key");
          return PublicKeyFactory.CreateKey(new SubjectPublicKeyInfo(new AlgorithmIdentifier(curveOid1), Arrays.CopyOfRange(data1, 1, data1.Length)));
        case PublicKeyAlgorithmTag.ECDsa:
          return (AsymmetricKeyParameter) this.GetECKey("ECDSA", (ECPublicBcpgKey) this.publicPk.Key);
        case PublicKeyAlgorithmTag.EdDsa:
          EdDsaPublicBcpgKey key5 = (EdDsaPublicBcpgKey) this.publicPk.Key;
          DerObjectIdentifier curveOid2 = key5.CurveOid;
          if (!EdECObjectIdentifiers.id_Ed25519.Equals((Asn1Object) curveOid2) && !GnuObjectIdentifiers.Ed25519.Equals((Asn1Object) curveOid2))
          {
            if (!EdECObjectIdentifiers.id_Ed448.Equals((Asn1Object) curveOid2))
              throw new InvalidOperationException();
            byte[] data2 = BigIntegers.AsUnsignedByteArray(1 + Ed448.PublicKeySize, key5.EncodedPoint);
            if (data2[0] != (byte) 64 /*0x40*/)
              throw new ArgumentException("Invalid Ed448 public key");
            return PublicKeyFactory.CreateKey(new SubjectPublicKeyInfo(new AlgorithmIdentifier(curveOid2), Arrays.CopyOfRange(data2, 1, data2.Length)));
          }
          byte[] data3 = BigIntegers.AsUnsignedByteArray(1 + Ed25519.PublicKeySize, key5.EncodedPoint);
          if (data3[0] != (byte) 64 /*0x40*/)
            throw new ArgumentException("Invalid Ed25519 public key");
          return PublicKeyFactory.CreateKey(new SubjectPublicKeyInfo(new AlgorithmIdentifier(curveOid2), Arrays.CopyOfRange(data3, 1, data3.Length)));
        default:
          throw new PgpException("unknown public key algorithm encountered");
      }
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("exception constructing public key", ex);
    }
  }

  private ECPublicKeyParameters GetECKey(string algorithm, ECPublicBcpgKey ecK)
  {
    ECPoint q = ECKeyPairGenerator.FindECCurveByOid(ecK.CurveOid).Curve.DecodePoint(BigIntegers.AsUnsignedByteArray(ecK.EncodedPoint));
    return new ECPublicKeyParameters(algorithm, q, ecK.CurveOid);
  }

  public IEnumerable<string> GetUserIds()
  {
    List<string> e = new List<string>();
    foreach (IUserDataPacket id in (IEnumerable<IUserDataPacket>) this.ids)
    {
      if (id is UserIdPacket userIdPacket)
        e.Add(userIdPacket.GetId());
    }
    return CollectionUtilities.Proxy<string>((IEnumerable<string>) e);
  }

  public IEnumerable<byte[]> GetRawUserIds()
  {
    List<byte[]> e = new List<byte[]>();
    foreach (IUserDataPacket id in (IEnumerable<IUserDataPacket>) this.ids)
    {
      if (id is UserIdPacket userIdPacket)
        e.Add(userIdPacket.GetRawId());
    }
    return CollectionUtilities.Proxy<byte[]>((IEnumerable<byte[]>) e);
  }

  public IEnumerable<PgpUserAttributeSubpacketVector> GetUserAttributes()
  {
    List<PgpUserAttributeSubpacketVector> e = new List<PgpUserAttributeSubpacketVector>();
    foreach (IUserDataPacket id in (IEnumerable<IUserDataPacket>) this.ids)
    {
      if (id is PgpUserAttributeSubpacketVector attributeSubpacketVector)
        e.Add(attributeSubpacketVector);
    }
    return CollectionUtilities.Proxy<PgpUserAttributeSubpacketVector>((IEnumerable<PgpUserAttributeSubpacketVector>) e);
  }

  public IEnumerable<PgpSignature> GetSignaturesForId(string id)
  {
    return id != null ? this.GetSignaturesForId(new UserIdPacket(id)) : throw new ArgumentNullException(nameof (id));
  }

  public IEnumerable<PgpSignature> GetSignaturesForId(byte[] rawId)
  {
    return rawId != null ? this.GetSignaturesForId(new UserIdPacket(rawId)) : throw new ArgumentNullException(nameof (rawId));
  }

  private IEnumerable<PgpSignature> GetSignaturesForId(UserIdPacket id)
  {
    List<PgpSignature> pgpSignatureList = new List<PgpSignature>();
    bool flag = false;
    for (int index = 0; index != this.ids.Count; ++index)
    {
      if (id.Equals((object) this.ids[index]))
      {
        flag = true;
        pgpSignatureList.AddRange((IEnumerable<PgpSignature>) this.idSigs[index]);
      }
    }
    return !flag ? (IEnumerable<PgpSignature>) null : (IEnumerable<PgpSignature>) pgpSignatureList;
  }

  public IEnumerable<PgpSignature> GetSignaturesForKeyID(long keyID)
  {
    List<PgpSignature> e = new List<PgpSignature>();
    foreach (PgpSignature signature in this.GetSignatures())
    {
      if (signature.KeyId == keyID)
        e.Add(signature);
    }
    return CollectionUtilities.Proxy<PgpSignature>((IEnumerable<PgpSignature>) e);
  }

  public IEnumerable<PgpSignature> GetSignaturesForUserAttribute(
    PgpUserAttributeSubpacketVector userAttributes)
  {
    if (userAttributes == null)
      throw new ArgumentNullException(nameof (userAttributes));
    List<PgpSignature> e = new List<PgpSignature>();
    bool flag = false;
    for (int index = 0; index != this.ids.Count; ++index)
    {
      if (userAttributes.Equals((object) this.ids[index]))
      {
        flag = true;
        e.AddRange((IEnumerable<PgpSignature>) this.idSigs[index]);
      }
    }
    return !flag ? (IEnumerable<PgpSignature>) null : CollectionUtilities.Proxy<PgpSignature>((IEnumerable<PgpSignature>) e);
  }

  public IEnumerable<PgpSignature> GetSignaturesOfType(int signatureType)
  {
    List<PgpSignature> e = new List<PgpSignature>();
    foreach (PgpSignature signature in this.GetSignatures())
    {
      if (signature.SignatureType == signatureType)
        e.Add(signature);
    }
    return CollectionUtilities.Proxy<PgpSignature>((IEnumerable<PgpSignature>) e);
  }

  public IEnumerable<PgpSignature> GetSignatures()
  {
    IList<PgpSignature> e = this.subSigs;
    if (e == null)
    {
      List<PgpSignature> pgpSignatureList = new List<PgpSignature>((IEnumerable<PgpSignature>) this.keySigs);
      foreach (IList<PgpSignature> idSig in (IEnumerable<IList<PgpSignature>>) this.idSigs)
        pgpSignatureList.AddRange((IEnumerable<PgpSignature>) idSig);
      e = (IList<PgpSignature>) pgpSignatureList;
    }
    return CollectionUtilities.Proxy<PgpSignature>((IEnumerable<PgpSignature>) e);
  }

  public IEnumerable<PgpSignature> GetKeySignatures()
  {
    return CollectionUtilities.Proxy<PgpSignature>((IEnumerable<PgpSignature>) (this.subSigs ?? (IList<PgpSignature>) new List<PgpSignature>((IEnumerable<PgpSignature>) this.keySigs)));
  }

  public PublicKeyPacket PublicKeyPacket => this.publicPk;

  public byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    this.Encode((Stream) outStr);
    return outStr.ToArray();
  }

  public void Encode(Stream outStr) => this.Encode(outStr, false);

  public void Encode(Stream outStr, bool forTransfer)
  {
    BcpgOutputStream outStream = BcpgOutputStream.Wrap(outStr);
    outStream.WritePacket((ContainedPacket) this.publicPk);
    if (!forTransfer && this.trustPk != null)
      outStream.WritePacket((ContainedPacket) this.trustPk);
    if (this.subSigs == null)
    {
      foreach (PgpSignature keySig in (IEnumerable<PgpSignature>) this.keySigs)
        keySig.Encode((Stream) outStream);
      for (int index = 0; index != this.ids.Count; ++index)
      {
        if (this.ids[index] is UserIdPacket id1)
        {
          outStream.WritePacket((ContainedPacket) id1);
        }
        else
        {
          PgpUserAttributeSubpacketVector id = (PgpUserAttributeSubpacketVector) this.ids[index];
          outStream.WritePacket((ContainedPacket) new UserAttributePacket(id.ToSubpacketArray()));
        }
        if (!forTransfer && this.idTrusts[index] != null)
          outStream.WritePacket((ContainedPacket) this.idTrusts[index]);
        foreach (PgpSignature pgpSignature in (IEnumerable<PgpSignature>) this.idSigs[index])
          pgpSignature.Encode((Stream) outStream, forTransfer);
      }
    }
    else
    {
      foreach (PgpSignature subSig in (IEnumerable<PgpSignature>) this.subSigs)
        subSig.Encode((Stream) outStream);
    }
  }

  public bool IsRevoked()
  {
    int num = 0;
    bool flag = false;
    if (this.IsMasterKey)
    {
      while (!flag && num < this.keySigs.Count)
      {
        if (this.keySigs[num++].SignatureType == 32 /*0x20*/)
          flag = true;
      }
    }
    else
    {
      while (!flag && num < this.subSigs.Count)
      {
        if (this.subSigs[num++].SignatureType == 40)
          flag = true;
      }
    }
    return flag;
  }

  public static PgpPublicKey AddCertification(
    PgpPublicKey key,
    string id,
    PgpSignature certification)
  {
    return PgpPublicKey.AddCert(key, (IUserDataPacket) new UserIdPacket(id), certification);
  }

  public static PgpPublicKey AddCertification(
    PgpPublicKey key,
    PgpUserAttributeSubpacketVector userAttributes,
    PgpSignature certification)
  {
    return PgpPublicKey.AddCert(key, (IUserDataPacket) userAttributes, certification);
  }

  private static PgpPublicKey AddCert(
    PgpPublicKey key,
    IUserDataPacket id,
    PgpSignature certification)
  {
    PgpPublicKey pgpPublicKey = new PgpPublicKey(key);
    IList<PgpSignature> pgpSignatureList1 = (IList<PgpSignature>) null;
    for (int index = 0; index != pgpPublicKey.ids.Count; ++index)
    {
      if (id.Equals((object) pgpPublicKey.ids[index]))
        pgpSignatureList1 = pgpPublicKey.idSigs[index];
    }
    if (pgpSignatureList1 != null)
    {
      pgpSignatureList1.Add(certification);
    }
    else
    {
      IList<PgpSignature> pgpSignatureList2 = (IList<PgpSignature>) new List<PgpSignature>();
      pgpSignatureList2.Add(certification);
      pgpPublicKey.ids.Add(id);
      pgpPublicKey.idTrusts.Add((TrustPacket) null);
      pgpPublicKey.idSigs.Add(pgpSignatureList2);
    }
    return pgpPublicKey;
  }

  public static PgpPublicKey RemoveCertification(
    PgpPublicKey key,
    PgpUserAttributeSubpacketVector userAttributes)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) userAttributes);
  }

  public static PgpPublicKey RemoveCertification(PgpPublicKey key, string id)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) new UserIdPacket(id));
  }

  public static PgpPublicKey RemoveCertification(PgpPublicKey key, byte[] rawId)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) new UserIdPacket(rawId));
  }

  private static PgpPublicKey RemoveCert(PgpPublicKey key, IUserDataPacket id)
  {
    PgpPublicKey pgpPublicKey = new PgpPublicKey(key);
    bool flag = false;
    for (int index = 0; index < pgpPublicKey.ids.Count; ++index)
    {
      if (id.Equals((object) pgpPublicKey.ids[index]))
      {
        flag = true;
        pgpPublicKey.ids.RemoveAt(index);
        pgpPublicKey.idTrusts.RemoveAt(index);
        pgpPublicKey.idSigs.RemoveAt(index);
      }
    }
    return !flag ? (PgpPublicKey) null : pgpPublicKey;
  }

  public static PgpPublicKey RemoveCertification(
    PgpPublicKey key,
    byte[] id,
    PgpSignature certification)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) new UserIdPacket(id), certification);
  }

  public static PgpPublicKey RemoveCertification(
    PgpPublicKey key,
    string id,
    PgpSignature certification)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) new UserIdPacket(id), certification);
  }

  public static PgpPublicKey RemoveCertification(
    PgpPublicKey key,
    PgpUserAttributeSubpacketVector userAttributes,
    PgpSignature certification)
  {
    return PgpPublicKey.RemoveCert(key, (IUserDataPacket) userAttributes, certification);
  }

  private static PgpPublicKey RemoveCert(
    PgpPublicKey key,
    IUserDataPacket id,
    PgpSignature certification)
  {
    PgpPublicKey pgpPublicKey = new PgpPublicKey(key);
    bool flag = false;
    for (int index = 0; index < pgpPublicKey.ids.Count; ++index)
    {
      if (id.Equals((object) pgpPublicKey.ids[index]))
        flag |= pgpPublicKey.idSigs[index].Remove(certification);
    }
    return !flag ? (PgpPublicKey) null : pgpPublicKey;
  }

  public static PgpPublicKey AddCertification(PgpPublicKey key, PgpSignature certification)
  {
    if (key.IsMasterKey)
    {
      if (certification.SignatureType == 40)
        throw new ArgumentException("signature type incorrect for master key revocation.");
    }
    else if (certification.SignatureType == 32 /*0x20*/)
      throw new ArgumentException("signature type incorrect for sub-key revocation.");
    PgpPublicKey pgpPublicKey = new PgpPublicKey(key);
    (pgpPublicKey.subSigs ?? pgpPublicKey.keySigs).Add(certification);
    return pgpPublicKey;
  }

  public static PgpPublicKey RemoveCertification(PgpPublicKey key, PgpSignature certification)
  {
    PgpPublicKey pgpPublicKey = new PgpPublicKey(key);
    bool flag = (pgpPublicKey.subSigs ?? pgpPublicKey.keySigs).Remove(certification);
    foreach (IList<PgpSignature> idSig in (IEnumerable<IList<PgpSignature>>) pgpPublicKey.idSigs)
      flag |= idSig.Remove(certification);
    return !flag ? (PgpPublicKey) null : pgpPublicKey;
  }

  public static PgpPublicKey Join(
    PgpPublicKey key,
    PgpPublicKey copy,
    bool joinTrustPackets,
    bool allowSubkeySigsOnNonSubkey)
  {
    if (key.KeyId != copy.keyId)
      throw new ArgumentException("Key-ID mismatch.");
    TrustPacket trustPk = key.trustPk;
    List<PgpSignature> keySigs = new List<PgpSignature>((IEnumerable<PgpSignature>) key.keySigs);
    List<IUserDataPacket> ids = new List<IUserDataPacket>((IEnumerable<IUserDataPacket>) key.ids);
    List<TrustPacket> idTrusts = new List<TrustPacket>((IEnumerable<TrustPacket>) key.idTrusts);
    List<IList<PgpSignature>> idSigs = new List<IList<PgpSignature>>((IEnumerable<IList<PgpSignature>>) key.idSigs);
    List<PgpSignature> pgpSignatureList1 = key.subSigs == null ? (List<PgpSignature>) null : new List<PgpSignature>((IEnumerable<PgpSignature>) key.subSigs);
    if (joinTrustPackets && copy.trustPk != null)
      trustPk = copy.trustPk;
    foreach (PgpSignature keySig in (IEnumerable<PgpSignature>) copy.keySigs)
    {
      bool flag = false;
      for (int index = 0; index < keySigs.Count; ++index)
      {
        PgpSignature sig1 = keySigs[index];
        if (PgpSignature.IsSignatureEncodingEqual(sig1, keySig))
        {
          flag = true;
          PgpSignature pgpSignature = PgpSignature.Join(sig1, keySig);
          keySigs[index] = pgpSignature;
          break;
        }
      }
      if (!flag)
        keySigs.Add(keySig);
      else
        break;
    }
    for (int index1 = 0; index1 < copy.ids.Count; ++index1)
    {
      IUserDataPacket id = copy.ids[index1];
      List<PgpSignature> pgpSignatureList2 = new List<PgpSignature>((IEnumerable<PgpSignature>) copy.idSigs[index1]);
      TrustPacket idTrust = copy.idTrusts[index1];
      int index2 = -1;
      for (int index3 = 0; index3 < ids.Count; ++index3)
      {
        if (ids[index3].Equals((object) id))
        {
          index2 = index3;
          break;
        }
      }
      if (index2 == -1)
      {
        ids.Add(id);
        idSigs.Add((IList<PgpSignature>) pgpSignatureList2);
        idTrusts.Add(joinTrustPackets ? idTrust : (TrustPacket) null);
      }
      else
      {
        if (joinTrustPackets && idTrust != null)
        {
          TrustPacket trustPacket = idTrusts[index2];
          if (trustPacket == null || Arrays.AreEqual(idTrust.GetLevelAndTrustAmount(), trustPacket.GetLevelAndTrustAmount()))
            idTrusts[index2] = idTrust;
        }
        IList<PgpSignature> pgpSignatureList3 = idSigs[index2];
        foreach (PgpSignature pgpSignature1 in pgpSignatureList2)
        {
          bool flag = false;
          for (int index4 = 0; index4 < pgpSignatureList3.Count; ++index4)
          {
            PgpSignature pgpSignature2 = pgpSignatureList3[index4];
            if (PgpSignature.IsSignatureEncodingEqual(pgpSignature1, pgpSignature2))
            {
              flag = true;
              PgpSignature pgpSignature3 = PgpSignature.Join(pgpSignature2, pgpSignature1);
              pgpSignatureList3[index4] = pgpSignature3;
              break;
            }
          }
          if (!flag)
            pgpSignatureList3.Add(pgpSignature1);
        }
      }
    }
    if (copy.subSigs != null)
    {
      if (pgpSignatureList1 == null & allowSubkeySigsOnNonSubkey)
      {
        pgpSignatureList1 = new List<PgpSignature>((IEnumerable<PgpSignature>) copy.subSigs);
      }
      else
      {
        foreach (PgpSignature subSig in (IEnumerable<PgpSignature>) copy.subSigs)
        {
          bool flag = false;
          for (int index = 0; pgpSignatureList1 != null && index < pgpSignatureList1.Count; ++index)
          {
            PgpSignature sig1 = pgpSignatureList1[index];
            if (PgpSignature.IsSignatureEncodingEqual(sig1, subSig))
            {
              flag = true;
              PgpSignature pgpSignature = PgpSignature.Join(sig1, subSig);
              pgpSignatureList1[index] = pgpSignature;
              break;
            }
          }
          if (!flag && pgpSignatureList1 != null)
            pgpSignatureList1.Add(subSig);
        }
      }
    }
    return new PgpPublicKey(key, trustPk, keySigs, ids, idTrusts, (IList<IList<PgpSignature>>) idSigs)
    {
      subSigs = (IList<PgpSignature>) pgpSignatureList1
    };
  }
}
