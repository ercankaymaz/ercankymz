// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.EtsiQCObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public abstract class EtsiQCObjectIdentifiers
{
  public static readonly DerObjectIdentifier IdEtsiQcs = new DerObjectIdentifier("0.4.0.1862.1");
  public static readonly DerObjectIdentifier IdEtsiQcsQcCompliance = new DerObjectIdentifier(EtsiQCObjectIdentifiers.IdEtsiQcs?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdEtsiQcsLimitValue = new DerObjectIdentifier(EtsiQCObjectIdentifiers.IdEtsiQcs?.ToString() + ".2");
  public static readonly DerObjectIdentifier IdEtsiQcsRetentionPeriod = new DerObjectIdentifier(EtsiQCObjectIdentifiers.IdEtsiQcs?.ToString() + ".3");
  public static readonly DerObjectIdentifier IdEtsiQcsQcSscd = new DerObjectIdentifier(EtsiQCObjectIdentifiers.IdEtsiQcs?.ToString() + ".4");
}
