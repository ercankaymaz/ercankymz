// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.IsisMttObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt;

public abstract class IsisMttObjectIdentifiers
{
  public static readonly DerObjectIdentifier IdIsisMtt = new DerObjectIdentifier("1.3.36.8");
  public static readonly DerObjectIdentifier IdIsisMttCP = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMtt?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdIsisMttCPAccredited = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttCP?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdIsisMttAT = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMtt?.ToString() + ".3");
  public static readonly DerObjectIdentifier IdIsisMttATDateOfCertGen = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdIsisMttATProcuration = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".2");
  public static readonly DerObjectIdentifier IdIsisMttATAdmission = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".3");
  public static readonly DerObjectIdentifier IdIsisMttATMonetaryLimit = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".4");
  public static readonly DerObjectIdentifier IdIsisMttATDeclarationOfMajority = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".5");
  public static readonly DerObjectIdentifier IdIsisMttATIccsn = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".6");
  public static readonly DerObjectIdentifier IdIsisMttATPKReference = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".7");
  public static readonly DerObjectIdentifier IdIsisMttATRestriction = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".8");
  public static readonly DerObjectIdentifier IdIsisMttATRetrieveIfAllowed = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".9");
  public static readonly DerObjectIdentifier IdIsisMttATRequestedCertificate = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".10");
  public static readonly DerObjectIdentifier IdIsisMttATNamingAuthorities = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".11");
  public static readonly DerObjectIdentifier IdIsisMttATCertInDirSince = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".12");
  public static readonly DerObjectIdentifier IdIsisMttATCertHash = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".13");
  public static readonly DerObjectIdentifier IdIsisMttATNameAtBirth = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".14");
  public static readonly DerObjectIdentifier IdIsisMttATAdditionalInformation = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttAT?.ToString() + ".15");
  public static readonly DerObjectIdentifier IdIsisMttATLiabilityLimitationFlag = new DerObjectIdentifier("0.2.262.1.10.12.0");
}
