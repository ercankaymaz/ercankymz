// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSignatureSubpacketGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSignatureSubpacketGenerator
{
  private readonly List<SignatureSubpacket> list = new List<SignatureSubpacket>();

  public PgpSignatureSubpacketGenerator()
  {
  }

  public PgpSignatureSubpacketGenerator(PgpSignatureSubpacketVector sigSubV)
  {
    if (sigSubV == null)
      return;
    SignatureSubpacket[] subpacketArray = sigSubV.ToSubpacketArray();
    for (int index = 0; index != sigSubV.Count; ++index)
      this.list.Add(subpacketArray[index]);
  }

  public void SetRevocable(bool isCritical, bool isRevocable)
  {
    this.list.Add((SignatureSubpacket) new Revocable(isCritical, isRevocable));
  }

  public void SetExportable(bool isCritical, bool isExportable)
  {
    this.list.Add((SignatureSubpacket) new Exportable(isCritical, isExportable));
  }

  public void SetFeature(bool isCritical, byte feature)
  {
    this.list.Add((SignatureSubpacket) new Features(isCritical, feature));
  }

  public void SetTrust(bool isCritical, int depth, int trustAmount)
  {
    this.list.Add((SignatureSubpacket) new TrustSignature(isCritical, depth, trustAmount));
  }

  public void SetKeyExpirationTime(bool isCritical, long seconds)
  {
    this.list.Add((SignatureSubpacket) new KeyExpirationTime(isCritical, seconds));
  }

  public void SetSignatureExpirationTime(bool isCritical, long seconds)
  {
    this.list.Add((SignatureSubpacket) new SignatureExpirationTime(isCritical, seconds));
  }

  public void SetSignatureCreationTime(bool isCritical, DateTime date)
  {
    this.list.Add((SignatureSubpacket) new SignatureCreationTime(isCritical, date));
  }

  public void SetPreferredHashAlgorithms(bool isCritical, int[] algorithms)
  {
    this.list.Add((SignatureSubpacket) new PreferredAlgorithms(SignatureSubpacketTag.PreferredHashAlgorithms, isCritical, algorithms));
  }

  public void SetPreferredSymmetricAlgorithms(bool isCritical, int[] algorithms)
  {
    this.list.Add((SignatureSubpacket) new PreferredAlgorithms(SignatureSubpacketTag.PreferredSymmetricAlgorithms, isCritical, algorithms));
  }

  public void SetPreferredCompressionAlgorithms(bool isCritical, int[] algorithms)
  {
    this.list.Add((SignatureSubpacket) new PreferredAlgorithms(SignatureSubpacketTag.PreferredCompressionAlgorithms, isCritical, algorithms));
  }

  public void SetPreferredAeadAlgorithms(bool isCritical, int[] algorithms)
  {
    this.list.Add((SignatureSubpacket) new PreferredAlgorithms(SignatureSubpacketTag.PreferredAeadAlgorithms, isCritical, algorithms));
  }

  public void AddPolicyUrl(bool isCritical, string policyUrl)
  {
    this.list.Add((SignatureSubpacket) new PolicyUrl(isCritical, policyUrl));
  }

  public void SetKeyFlags(bool isCritical, int flags)
  {
    this.list.Add((SignatureSubpacket) new KeyFlags(isCritical, flags));
  }

  [Obsolete("Use 'AddSignerUserId' instead")]
  public void SetSignerUserId(bool isCritical, string userId)
  {
    this.AddSignerUserId(isCritical, userId);
  }

  public void AddSignerUserId(bool isCritical, string userId)
  {
    if (userId == null)
      throw new ArgumentNullException(nameof (userId));
    this.list.Add((SignatureSubpacket) new SignerUserId(isCritical, userId));
  }

  public void SetSignerUserId(bool isCritical, byte[] rawUserId)
  {
    if (rawUserId == null)
      throw new ArgumentNullException(nameof (rawUserId));
    this.list.Add((SignatureSubpacket) new SignerUserId(isCritical, false, rawUserId));
  }

  [Obsolete("Use 'AddEmbeddedSignature' instead")]
  public void SetEmbeddedSignature(bool isCritical, PgpSignature pgpSignature)
  {
    this.AddEmbeddedSignature(isCritical, pgpSignature);
  }

  public void AddEmbeddedSignature(bool isCritical, PgpSignature pgpSignature)
  {
    byte[] encoded = pgpSignature.GetEncoded();
    byte[] numArray = encoded.Length - 1 <= 256 /*0x0100*/ ? new byte[encoded.Length - 2] : new byte[encoded.Length - 3];
    Array.Copy((Array) encoded, encoded.Length - numArray.Length, (Array) numArray, 0, numArray.Length);
    this.list.Add((SignatureSubpacket) new EmbeddedSignature(isCritical, false, numArray));
  }

  public void SetPrimaryUserId(bool isCritical, bool isPrimaryUserId)
  {
    this.list.Add((SignatureSubpacket) new PrimaryUserId(isCritical, isPrimaryUserId));
  }

  [Obsolete("Use 'AddNotationData' instead")]
  public void SetNotationData(
    bool isCritical,
    bool isHumanReadable,
    string notationName,
    string notationValue)
  {
    this.AddNotationData(isCritical, isHumanReadable, notationName, notationValue);
  }

  public void AddNotationData(
    bool isCritical,
    bool isHumanReadable,
    string notationName,
    string notationValue)
  {
    this.list.Add((SignatureSubpacket) new NotationData(isCritical, isHumanReadable, notationName, notationValue));
  }

  public void SetRevocationReason(bool isCritical, RevocationReasonTag reason, string description)
  {
    this.list.Add((SignatureSubpacket) new RevocationReason(isCritical, reason, description));
  }

  [Obsolete("Use 'AddRevocationKey' instead")]
  public void SetRevocationKey(
    bool isCritical,
    PublicKeyAlgorithmTag keyAlgorithm,
    byte[] fingerprint)
  {
    this.AddRevocationKey(isCritical, keyAlgorithm, fingerprint);
  }

  public void AddRevocationKey(
    bool isCritical,
    PublicKeyAlgorithmTag keyAlgorithm,
    byte[] fingerprint)
  {
    this.list.Add((SignatureSubpacket) new RevocationKey(isCritical, RevocationKeyTag.ClassDefault, keyAlgorithm, fingerprint));
  }

  public void SetIssuerKeyID(bool isCritical, long keyID)
  {
    this.list.Add((SignatureSubpacket) new IssuerKeyId(isCritical, keyID));
  }

  public void SetSignatureTarget(
    bool isCritical,
    int publicKeyAlgorithm,
    int hashAlgorithm,
    byte[] hashData)
  {
    this.list.Add((SignatureSubpacket) new SignatureTarget(isCritical, publicKeyAlgorithm, hashAlgorithm, hashData));
  }

  public void SetIssuerFingerprint(bool isCritical, PgpSecretKey secretKey)
  {
    this.SetIssuerFingerprint(isCritical, secretKey.PublicKey);
  }

  public void SetIssuerFingerprint(bool isCritical, PgpPublicKey publicKey)
  {
    this.list.Add((SignatureSubpacket) new IssuerFingerprint(isCritical, publicKey.Version, publicKey.GetFingerprint()));
  }

  public void AddIntendedRecipientFingerprint(bool isCritical, PgpPublicKey publicKey)
  {
    this.list.Add((SignatureSubpacket) new IntendedRecipientFingerprint(isCritical, publicKey.Version, publicKey.GetFingerprint()));
  }

  public void AddCustomSubpacket(SignatureSubpacket subpacket) => this.list.Add(subpacket);

  public bool RemovePacket(SignatureSubpacket packet) => this.list.Remove(packet);

  public bool HasSubpacket(SignatureSubpacketTag type)
  {
    return this.list.Find((Predicate<SignatureSubpacket>) (subpacket => subpacket.SubpacketType == type)) != null;
  }

  public SignatureSubpacket[] GetSubpackets(SignatureSubpacketTag type)
  {
    return this.list.FindAll((Predicate<SignatureSubpacket>) (subpacket => subpacket.SubpacketType == type)).ToArray();
  }

  public PgpSignatureSubpacketVector Generate()
  {
    return new PgpSignatureSubpacketVector(this.list.ToArray());
  }
}
