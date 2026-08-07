// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKeyRingGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpKeyRingGenerator
{
  private IList<PgpSecretKey> keys = (IList<PgpSecretKey>) new List<PgpSecretKey>();
  private string id;
  private SymmetricKeyAlgorithmTag encAlgorithm;
  private HashAlgorithmTag hashAlgorithm;
  private int certificationLevel;
  private byte[] rawPassPhrase;
  private bool useSha1;
  private PgpKeyPair masterKey;
  private PgpSignatureSubpacketVector hashedPacketVector;
  private PgpSignatureSubpacketVector unhashedPacketVector;
  private SecureRandom rand;

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    char[] passPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
    : this(certificationLevel, masterKey, id, encAlgorithm, false, passPhrase, useSha1, hashedPackets, unhashedPackets, rand)
  {
  }

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    bool utf8PassPhrase,
    char[] passPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
    : this(certificationLevel, masterKey, id, encAlgorithm, PgpUtilities.EncodePassPhrase(passPhrase, utf8PassPhrase), useSha1, hashedPackets, unhashedPackets, rand)
  {
  }

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    byte[] rawPassPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
  {
    this.certificationLevel = certificationLevel;
    this.masterKey = masterKey;
    this.id = id;
    this.encAlgorithm = encAlgorithm;
    this.rawPassPhrase = rawPassPhrase;
    this.useSha1 = useSha1;
    this.hashedPacketVector = hashedPackets;
    this.unhashedPacketVector = unhashedPackets;
    this.rand = rand;
    this.keys.Add(new PgpSecretKey(certificationLevel, masterKey, id, encAlgorithm, rawPassPhrase, false, useSha1, hashedPackets, unhashedPackets, rand));
  }

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    char[] passPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
    : this(certificationLevel, masterKey, id, encAlgorithm, hashAlgorithm, false, passPhrase, useSha1, hashedPackets, unhashedPackets, rand)
  {
  }

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    bool utf8PassPhrase,
    char[] passPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
    : this(certificationLevel, masterKey, id, encAlgorithm, hashAlgorithm, PgpUtilities.EncodePassPhrase(passPhrase, utf8PassPhrase), useSha1, hashedPackets, unhashedPackets, rand)
  {
  }

  public PgpKeyRingGenerator(
    int certificationLevel,
    PgpKeyPair masterKey,
    string id,
    SymmetricKeyAlgorithmTag encAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    byte[] rawPassPhrase,
    bool useSha1,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    SecureRandom rand)
  {
    this.certificationLevel = certificationLevel;
    this.masterKey = masterKey;
    this.id = id;
    this.encAlgorithm = encAlgorithm;
    this.rawPassPhrase = rawPassPhrase;
    this.useSha1 = useSha1;
    this.hashedPacketVector = hashedPackets;
    this.unhashedPacketVector = unhashedPackets;
    this.rand = rand;
    this.hashAlgorithm = hashAlgorithm;
    this.keys.Add(new PgpSecretKey(certificationLevel, masterKey, id, encAlgorithm, hashAlgorithm, rawPassPhrase, false, useSha1, hashedPackets, unhashedPackets, rand));
  }

  public void AddSubKey(PgpKeyPair keyPair)
  {
    this.AddSubKey(keyPair, this.hashedPacketVector, this.unhashedPacketVector);
  }

  public void AddSubKey(PgpKeyPair keyPair, HashAlgorithmTag hashAlgorithm)
  {
    this.AddSubKey(keyPair, this.hashedPacketVector, this.unhashedPacketVector, hashAlgorithm);
  }

  public void AddSubKey(
    PgpKeyPair keyPair,
    HashAlgorithmTag hashAlgorithm,
    HashAlgorithmTag primaryKeyBindingHashAlgorithm)
  {
    this.AddSubKey(keyPair, this.hashedPacketVector, this.unhashedPacketVector, hashAlgorithm, primaryKeyBindingHashAlgorithm);
  }

  public void AddSubKey(
    PgpKeyPair keyPair,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets)
  {
    this.AddSubKey(keyPair, hashedPackets, unhashedPackets, HashAlgorithmTag.Sha1);
  }

  public void AddSubKey(
    PgpKeyPair keyPair,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    HashAlgorithmTag hashAlgorithm)
  {
    try
    {
      PgpSignatureGenerator signatureGenerator = new PgpSignatureGenerator(this.masterKey.PublicKey.Algorithm, hashAlgorithm);
      signatureGenerator.InitSign(24, this.masterKey.PrivateKey);
      signatureGenerator.SetHashedSubpackets(hashedPackets);
      signatureGenerator.SetUnhashedSubpackets(unhashedPackets);
      this.keys.Add(new PgpSecretKey(keyPair.PrivateKey, new PgpPublicKey(keyPair.PublicKey, (TrustPacket) null, (IList<PgpSignature>) new List<PgpSignature>()
      {
        signatureGenerator.GenerateCertification(this.masterKey.PublicKey, keyPair.PublicKey)
      }), this.encAlgorithm, this.rawPassPhrase, false, this.useSha1, this.rand, false));
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("exception adding subkey: ", ex);
    }
  }

  public void AddSubKey(
    PgpKeyPair keyPair,
    PgpSignatureSubpacketVector hashedPackets,
    PgpSignatureSubpacketVector unhashedPackets,
    HashAlgorithmTag hashAlgorithm,
    HashAlgorithmTag primaryKeyBindingHashAlgorithm)
  {
    try
    {
      PgpSignatureGenerator signatureGenerator1 = new PgpSignatureGenerator(this.masterKey.PublicKey.Algorithm, hashAlgorithm);
      signatureGenerator1.InitSign(24, this.masterKey.PrivateKey);
      PgpSignatureGenerator signatureGenerator2 = new PgpSignatureGenerator(keyPair.PublicKey.Algorithm, primaryKeyBindingHashAlgorithm);
      signatureGenerator2.InitSign(25, keyPair.PrivateKey);
      PgpSignatureSubpacketGenerator subpacketGenerator = new PgpSignatureSubpacketGenerator(hashedPackets);
      subpacketGenerator.AddEmbeddedSignature(false, signatureGenerator2.GenerateCertification(this.masterKey.PublicKey, keyPair.PublicKey));
      signatureGenerator1.SetHashedSubpackets(subpacketGenerator.Generate());
      signatureGenerator1.SetUnhashedSubpackets(unhashedPackets);
      this.keys.Add(new PgpSecretKey(keyPair.PrivateKey, new PgpPublicKey(keyPair.PublicKey, (TrustPacket) null, (IList<PgpSignature>) new List<PgpSignature>()
      {
        signatureGenerator1.GenerateCertification(this.masterKey.PublicKey, keyPair.PublicKey)
      }), this.encAlgorithm, this.rawPassPhrase, false, this.useSha1, this.rand, false));
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("exception adding subkey: ", ex);
    }
  }

  public PgpSecretKeyRing GenerateSecretKeyRing() => new PgpSecretKeyRing(this.keys);

  public PgpPublicKeyRing GeneratePublicKeyRing()
  {
    List<PgpPublicKey> pubKeys = new List<PgpPublicKey>();
    IEnumerator<PgpSecretKey> enumerator = this.keys.GetEnumerator();
    enumerator.MoveNext();
    PgpSecretKey current = enumerator.Current;
    pubKeys.Add(current.PublicKey);
    while (enumerator.MoveNext())
    {
      PgpPublicKey pgpPublicKey = new PgpPublicKey(enumerator.Current.PublicKey);
      pgpPublicKey.publicPk = (PublicKeyPacket) new PublicSubkeyPacket(pgpPublicKey.Algorithm, pgpPublicKey.CreationTime, pgpPublicKey.publicPk.Key);
      pubKeys.Add(pgpPublicKey);
    }
    return new PgpPublicKeyRing((IList<PgpPublicKey>) pubKeys);
  }
}
