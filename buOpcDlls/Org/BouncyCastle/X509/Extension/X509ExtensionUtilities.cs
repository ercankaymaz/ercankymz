// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Extension.X509ExtensionUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;

#nullable disable
namespace Org.BouncyCastle.X509.Extension;

public class X509ExtensionUtilities
{
  public static Asn1Object FromExtensionValue(Asn1OctetString extensionValue)
  {
    return Asn1Object.FromByteArray(extensionValue.GetOctets());
  }

  public static Asn1Object FromExtensionValue(IX509Extension extensions, DerObjectIdentifier oid)
  {
    Asn1OctetString extensionValue = extensions.GetExtensionValue(oid);
    return extensionValue != null ? X509ExtensionUtilities.FromExtensionValue(extensionValue) : (Asn1Object) null;
  }
}
