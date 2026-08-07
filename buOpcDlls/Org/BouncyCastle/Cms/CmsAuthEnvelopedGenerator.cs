// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthEnvelopedGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Nist;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class CmsAuthEnvelopedGenerator
{
  public static readonly string Aes128Ccm = NistObjectIdentifiers.IdAes128Ccm.Id;
  public static readonly string Aes192Ccm = NistObjectIdentifiers.IdAes192Ccm.Id;
  public static readonly string Aes256Ccm = NistObjectIdentifiers.IdAes256Ccm.Id;
  public static readonly string Aes128Gcm = NistObjectIdentifiers.IdAes128Gcm.Id;
  public static readonly string Aes192Gcm = NistObjectIdentifiers.IdAes192Gcm.Id;
  public static readonly string Aes256Gcm = NistObjectIdentifiers.IdAes256Gcm.Id;
}
