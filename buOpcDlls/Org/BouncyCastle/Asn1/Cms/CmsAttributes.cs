// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.CmsAttributes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public abstract class CmsAttributes
{
  public static readonly DerObjectIdentifier ContentType = PkcsObjectIdentifiers.Pkcs9AtContentType;
  public static readonly DerObjectIdentifier MessageDigest = PkcsObjectIdentifiers.Pkcs9AtMessageDigest;
  public static readonly DerObjectIdentifier SigningTime = PkcsObjectIdentifiers.Pkcs9AtSigningTime;
  public static readonly DerObjectIdentifier CounterSignature = PkcsObjectIdentifiers.Pkcs9AtCounterSignature;
  public static readonly DerObjectIdentifier ContentHint = PkcsObjectIdentifiers.IdAAContentHint;
  public static readonly DerObjectIdentifier CmsAlgorithmProtect = PkcsObjectIdentifiers.id_aa_cmsAlgorithmProtect;
}
