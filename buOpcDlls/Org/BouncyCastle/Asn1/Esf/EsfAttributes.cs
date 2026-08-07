// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.EsfAttributes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public abstract class EsfAttributes
{
  public static readonly DerObjectIdentifier SigPolicyId = PkcsObjectIdentifiers.IdAAEtsSigPolicyID;
  public static readonly DerObjectIdentifier CommitmentType = PkcsObjectIdentifiers.IdAAEtsCommitmentType;
  public static readonly DerObjectIdentifier SignerLocation = PkcsObjectIdentifiers.IdAAEtsSignerLocation;
  public static readonly DerObjectIdentifier SignerAttr = PkcsObjectIdentifiers.IdAAEtsSignerAttr;
  public static readonly DerObjectIdentifier OtherSigCert = PkcsObjectIdentifiers.IdAAEtsOtherSigCert;
  public static readonly DerObjectIdentifier ContentTimestamp = PkcsObjectIdentifiers.IdAAEtsContentTimestamp;
  public static readonly DerObjectIdentifier CertificateRefs = PkcsObjectIdentifiers.IdAAEtsCertificateRefs;
  public static readonly DerObjectIdentifier RevocationRefs = PkcsObjectIdentifiers.IdAAEtsRevocationRefs;
  public static readonly DerObjectIdentifier CertValues = PkcsObjectIdentifiers.IdAAEtsCertValues;
  public static readonly DerObjectIdentifier RevocationValues = PkcsObjectIdentifiers.IdAAEtsRevocationValues;
  public static readonly DerObjectIdentifier EscTimeStamp = PkcsObjectIdentifiers.IdAAEtsEscTimeStamp;
  public static readonly DerObjectIdentifier CertCrlTimestamp = PkcsObjectIdentifiers.IdAAEtsCertCrlTimestamp;
  public static readonly DerObjectIdentifier ArchiveTimestamp = PkcsObjectIdentifiers.IdAAEtsArchiveTimestamp;
  public static readonly DerObjectIdentifier ArchiveTimestampV2 = new DerObjectIdentifier("1.2.840.113549.1.9.16.2.48");
}
