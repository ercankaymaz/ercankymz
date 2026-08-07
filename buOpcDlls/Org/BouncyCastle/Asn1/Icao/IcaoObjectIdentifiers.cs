// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Icao.IcaoObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Icao;

public abstract class IcaoObjectIdentifiers
{
  public static readonly DerObjectIdentifier IdIcao = new DerObjectIdentifier("2.23.136");
  public static readonly DerObjectIdentifier IdIcaoMrtd = IcaoObjectIdentifiers.IdIcao.Branch("1");
  public static readonly DerObjectIdentifier IdIcaoMrtdSecurity = IcaoObjectIdentifiers.IdIcaoMrtd.Branch("1");
  public static readonly DerObjectIdentifier IdIcaoLdsSecurityObject = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("1");
  public static readonly DerObjectIdentifier IdIcaoCscaMasterList = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("2");
  public static readonly DerObjectIdentifier IdIcaoCscaMasterListSigningKey = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("3");
  public static readonly DerObjectIdentifier IdIcaoDocumentTypeList = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("4");
  public static readonly DerObjectIdentifier IdIcaoAAProtocolObject = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("5");
  public static readonly DerObjectIdentifier IdIcaoExtensions = IcaoObjectIdentifiers.IdIcaoMrtdSecurity.Branch("6");
  public static readonly DerObjectIdentifier IdIcaoExtensionsNamechangekeyrollover = IcaoObjectIdentifiers.IdIcaoExtensions.Branch("1");
}
