// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CommitmentTypeIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public abstract class CommitmentTypeIdentifier
{
  public static readonly DerObjectIdentifier ProofOfOrigin = PkcsObjectIdentifiers.IdCtiEtsProofOfOrigin;
  public static readonly DerObjectIdentifier ProofOfReceipt = PkcsObjectIdentifiers.IdCtiEtsProofOfReceipt;
  public static readonly DerObjectIdentifier ProofOfDelivery = PkcsObjectIdentifiers.IdCtiEtsProofOfDelivery;
  public static readonly DerObjectIdentifier ProofOfSender = PkcsObjectIdentifiers.IdCtiEtsProofOfSender;
  public static readonly DerObjectIdentifier ProofOfApproval = PkcsObjectIdentifiers.IdCtiEtsProofOfApproval;
  public static readonly DerObjectIdentifier ProofOfCreation = PkcsObjectIdentifiers.IdCtiEtsProofOfCreation;
}
