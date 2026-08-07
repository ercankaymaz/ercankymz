// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509ExtensionBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509;

public abstract class X509ExtensionBase : IX509Extension
{
  protected abstract X509Extensions GetX509Extensions();

  protected virtual ISet<string> GetExtensionOids(bool critical)
  {
    X509Extensions x509Extensions = this.GetX509Extensions();
    if (x509Extensions == null)
      return (ISet<string>) null;
    HashSet<string> extensionOids = new HashSet<string>();
    foreach (DerObjectIdentifier extensionOid in x509Extensions.ExtensionOids)
    {
      if (x509Extensions.GetExtension(extensionOid).IsCritical == critical)
        extensionOids.Add(extensionOid.Id);
    }
    return (ISet<string>) extensionOids;
  }

  public virtual ISet<string> GetNonCriticalExtensionOids() => this.GetExtensionOids(false);

  public virtual ISet<string> GetCriticalExtensionOids() => this.GetExtensionOids(true);

  public virtual Asn1OctetString GetExtensionValue(DerObjectIdentifier oid)
  {
    return this.GetX509Extensions()?.GetExtension(oid)?.Value;
  }
}
