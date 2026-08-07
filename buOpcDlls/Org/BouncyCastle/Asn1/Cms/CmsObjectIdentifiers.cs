// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.CmsObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public abstract class CmsObjectIdentifiers
{
  public static readonly DerObjectIdentifier Data = PkcsObjectIdentifiers.Data;
  public static readonly DerObjectIdentifier SignedData = PkcsObjectIdentifiers.SignedData;
  public static readonly DerObjectIdentifier EnvelopedData = PkcsObjectIdentifiers.EnvelopedData;
  public static readonly DerObjectIdentifier SignedAndEnvelopedData = PkcsObjectIdentifiers.SignedAndEnvelopedData;
  public static readonly DerObjectIdentifier DigestedData = PkcsObjectIdentifiers.DigestedData;
  public static readonly DerObjectIdentifier EncryptedData = PkcsObjectIdentifiers.EncryptedData;
  public static readonly DerObjectIdentifier AuthenticatedData = PkcsObjectIdentifiers.IdCTAuthData;
  public static readonly DerObjectIdentifier CompressedData = PkcsObjectIdentifiers.IdCTCompressedData;
  public static readonly DerObjectIdentifier AuthEnvelopedData = PkcsObjectIdentifiers.IdCTAuthEnvelopedData;
  public static readonly DerObjectIdentifier TimestampedData = PkcsObjectIdentifiers.IdCTTimestampedData;
  public static readonly DerObjectIdentifier ZlibCompress = PkcsObjectIdentifiers.IdAlgZlibCompress;
  public static readonly DerObjectIdentifier id_ri = new DerObjectIdentifier("1.3.6.1.5.5.7.16");
  public static readonly DerObjectIdentifier id_ri_ocsp_response = CmsObjectIdentifiers.id_ri.Branch("2");
  public static readonly DerObjectIdentifier id_ri_scvp = CmsObjectIdentifiers.id_ri.Branch("4");
}
