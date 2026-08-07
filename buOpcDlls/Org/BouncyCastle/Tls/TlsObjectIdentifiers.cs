// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsObjectIdentifiers
{
  public static readonly DerObjectIdentifier id_pe_tlsfeature = X509ObjectIdentifiers.IdPE.Branch("24");
}
