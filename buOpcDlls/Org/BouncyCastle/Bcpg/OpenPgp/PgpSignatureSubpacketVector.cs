// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSignatureSubpacketVector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSignatureSubpacketVector
{
  private readonly SignatureSubpacket[] packets;

  public static PgpSignatureSubpacketVector FromSubpackets(SignatureSubpacket[] packets)
  {
    return new PgpSignatureSubpacketVector(packets ?? new SignatureSubpacket[0]);
  }

  internal PgpSignatureSubpacketVector(SignatureSubpacket[] packets) => this.packets = packets;

  public SignatureSubpacket GetSubpacket(SignatureSubpacketTag type)
  {
    for (int index = 0; index != this.packets.Length; ++index)
    {
      if (this.packets[index].SubpacketType == type)
        return this.packets[index];
    }
    return (SignatureSubpacket) null;
  }

  public bool HasSubpacket(SignatureSubpacketTag type) => this.GetSubpacket(type) != null;

  public SignatureSubpacket[] GetSubpackets(SignatureSubpacketTag type)
  {
    int length = 0;
    for (int index = 0; index < this.packets.Length; ++index)
    {
      if (this.packets[index].SubpacketType == type)
        ++length;
    }
    SignatureSubpacket[] subpackets = new SignatureSubpacket[length];
    int num = 0;
    for (int index = 0; index < this.packets.Length; ++index)
    {
      if (this.packets[index].SubpacketType == type)
        subpackets[num++] = this.packets[index];
    }
    return subpackets;
  }

  public PgpSignatureList GetEmbeddedSignatures()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.EmbeddedSignature);
    PgpSignature[] sigs = new PgpSignature[subpackets.Length];
    for (int index = 0; index < subpackets.Length; ++index)
    {
      try
      {
        sigs[index] = new PgpSignature(SignaturePacket.FromByteArray(subpackets[index].GetData()));
      }
      catch (IOException ex)
      {
        throw new PgpException("Unable to parse signature packet: " + ex.Message, (Exception) ex);
      }
    }
    return new PgpSignatureList(sigs);
  }

  public NotationData[] GetNotationDataOccurrences()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.NotationData);
    NotationData[] notationDataOccurrences = new NotationData[subpackets.Length];
    for (int index = 0; index < subpackets.Length; ++index)
      notationDataOccurrences[index] = (NotationData) subpackets[index];
    return notationDataOccurrences;
  }

  public NotationData[] GetNotationDataOccurrences(string notationName)
  {
    NotationData[] notationDataOccurrences = this.GetNotationDataOccurrences();
    List<NotationData> notationDataList = new List<NotationData>();
    for (int index = 0; index != notationDataOccurrences.Length; ++index)
    {
      NotationData notationData = notationDataOccurrences[index];
      if (notationData.GetNotationName().Equals(notationName))
        notationDataList.Add(notationData);
    }
    return notationDataList.ToArray();
  }

  public long GetIssuerKeyId()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.IssuerKeyId);
    return subpacket != null ? ((IssuerKeyId) subpacket).KeyId : 0L;
  }

  public bool HasSignatureCreationTime()
  {
    return this.GetSubpacket(SignatureSubpacketTag.CreationTime) != null;
  }

  public DateTime GetSignatureCreationTime()
  {
    return ((SignatureCreationTime) (this.GetSubpacket(SignatureSubpacketTag.CreationTime) ?? throw new PgpException("SignatureCreationTime not available"))).GetTime();
  }

  public bool HasSignatureExpirationTime()
  {
    return this.GetSubpacket(SignatureSubpacketTag.ExpireTime) != null;
  }

  public long GetSignatureExpirationTime()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.ExpireTime);
    return subpacket != null ? ((SignatureExpirationTime) subpacket).Time : 0L;
  }

  public long GetKeyExpirationTime()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.KeyExpireTime);
    return subpacket != null ? ((KeyExpirationTime) subpacket).Time : 0L;
  }

  public int[] GetPreferredHashAlgorithms()
  {
    return ((PreferredAlgorithms) this.GetSubpacket(SignatureSubpacketTag.PreferredHashAlgorithms))?.GetPreferences();
  }

  public int[] GetPreferredSymmetricAlgorithms()
  {
    return ((PreferredAlgorithms) this.GetSubpacket(SignatureSubpacketTag.PreferredSymmetricAlgorithms))?.GetPreferences();
  }

  public int[] GetPreferredCompressionAlgorithms()
  {
    return ((PreferredAlgorithms) this.GetSubpacket(SignatureSubpacketTag.PreferredCompressionAlgorithms))?.GetPreferences();
  }

  public int[] GetPreferredAeadAlgorithms()
  {
    return ((PreferredAlgorithms) this.GetSubpacket(SignatureSubpacketTag.PreferredAeadAlgorithms))?.GetPreferences();
  }

  public int GetKeyFlags()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.KeyFlags);
    return subpacket != null ? ((KeyFlags) subpacket).Flags : 0;
  }

  public string GetSignerUserId()
  {
    return ((SignerUserId) this.GetSubpacket(SignatureSubpacketTag.SignerUserId))?.GetId();
  }

  public bool IsPrimaryUserId()
  {
    PrimaryUserId subpacket = (PrimaryUserId) this.GetSubpacket(SignatureSubpacketTag.PrimaryUserId);
    return subpacket != null && subpacket.IsPrimaryUserId();
  }

  public SignatureSubpacketTag[] GetCriticalTags()
  {
    int length = 0;
    for (int index = 0; index != this.packets.Length; ++index)
    {
      if (this.packets[index].IsCritical())
        ++length;
    }
    SignatureSubpacketTag[] criticalTags = new SignatureSubpacketTag[length];
    int num = 0;
    for (int index = 0; index != this.packets.Length; ++index)
    {
      if (this.packets[index].IsCritical())
        criticalTags[num++] = this.packets[index].SubpacketType;
    }
    return criticalTags;
  }

  public SignatureTarget GetSignatureTarget()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.SignatureTarget);
    return subpacket != null ? new SignatureTarget(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (SignatureTarget) null;
  }

  public Features GetFeatures()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.Features);
    return subpacket != null ? new Features(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (Features) null;
  }

  public IssuerFingerprint GetIssuerFingerprint()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.IssuerFingerprint);
    return subpacket != null ? new IssuerFingerprint(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (IssuerFingerprint) null;
  }

  public IntendedRecipientFingerprint GetIntendedRecipientFingerprint()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.IntendedRecipientFingerprint);
    return subpacket != null ? new IntendedRecipientFingerprint(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (IntendedRecipientFingerprint) null;
  }

  public IntendedRecipientFingerprint[] GetIntendedRecipientFingerprints()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.IntendedRecipientFingerprint);
    IntendedRecipientFingerprint[] recipientFingerprints = new IntendedRecipientFingerprint[subpackets.Length];
    for (int index = 0; index < recipientFingerprints.Length; ++index)
    {
      SignatureSubpacket signatureSubpacket = subpackets[index];
      recipientFingerprints[index] = new IntendedRecipientFingerprint(signatureSubpacket.IsCritical(), signatureSubpacket.IsLongLength(), signatureSubpacket.GetData());
    }
    return recipientFingerprints;
  }

  public Exportable GetExportable()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.Exportable);
    return subpacket != null ? new Exportable(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (Exportable) null;
  }

  public bool IsExportable()
  {
    Exportable exportable = this.GetExportable();
    return exportable == null || exportable.IsExportable();
  }

  public PolicyUrl GetPolicyUrl()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.PolicyUrl);
    return subpacket != null ? new PolicyUrl(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (PolicyUrl) null;
  }

  public PolicyUrl[] GetPolicyUrls()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.PolicyUrl);
    PolicyUrl[] policyUrls = new PolicyUrl[subpackets.Length];
    for (int index = 0; index < subpackets.Length; ++index)
    {
      SignatureSubpacket signatureSubpacket = subpackets[index];
      policyUrls[index] = new PolicyUrl(signatureSubpacket.IsCritical(), signatureSubpacket.IsLongLength(), signatureSubpacket.GetData());
    }
    return policyUrls;
  }

  public RegularExpression GetRegularExpression()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.RegExp);
    return subpacket != null ? new RegularExpression(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (RegularExpression) null;
  }

  public RegularExpression[] GetRegularExpressions()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.RegExp);
    RegularExpression[] regularExpressions = new RegularExpression[subpackets.Length];
    for (int index = 0; index < regularExpressions.Length; ++index)
    {
      SignatureSubpacket signatureSubpacket = subpackets[index];
      regularExpressions[index] = new RegularExpression(signatureSubpacket.IsCritical(), signatureSubpacket.IsLongLength(), signatureSubpacket.GetData());
    }
    return regularExpressions;
  }

  public Revocable GetRevocable()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.Revocable);
    return subpacket != null ? new Revocable(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (Revocable) null;
  }

  public bool IsRevocable()
  {
    Revocable revocable = this.GetRevocable();
    return revocable == null || revocable.IsRevocable();
  }

  public RevocationKey[] GetRevocationKeys()
  {
    SignatureSubpacket[] subpackets = this.GetSubpackets(SignatureSubpacketTag.RevocationKey);
    RevocationKey[] revocationKeys = new RevocationKey[subpackets.Length];
    for (int index = 0; index < revocationKeys.Length; ++index)
    {
      SignatureSubpacket signatureSubpacket = subpackets[index];
      revocationKeys[index] = new RevocationKey(signatureSubpacket.IsCritical(), signatureSubpacket.IsLongLength(), signatureSubpacket.GetData());
    }
    return revocationKeys;
  }

  public RevocationReason GetRevocationReason()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.RevocationReason);
    return subpacket != null ? new RevocationReason(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (RevocationReason) null;
  }

  public TrustSignature GetTrust()
  {
    SignatureSubpacket subpacket = this.GetSubpacket(SignatureSubpacketTag.TrustSig);
    return subpacket != null ? new TrustSignature(subpacket.IsCritical(), subpacket.IsLongLength(), subpacket.GetData()) : (TrustSignature) null;
  }

  public int Count => this.packets.Length;

  internal SignatureSubpacket[] ToSubpacketArray() => this.packets;

  public SignatureSubpacket[] ToArray() => (SignatureSubpacket[]) this.packets.Clone();
}
