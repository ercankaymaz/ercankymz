using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.X509;

public abstract class X509ExtensionBase : IX509Extension
{
	protected abstract X509Extensions GetX509Extensions();

	protected virtual ISet<string> GetExtensionOids(bool critical)
	{
		X509Extensions x509Extensions = GetX509Extensions();
		if (x509Extensions == null)
		{
			return null;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (DerObjectIdentifier extensionOid in x509Extensions.ExtensionOids)
		{
			if (x509Extensions.GetExtension(extensionOid).IsCritical == critical)
			{
				hashSet.Add(extensionOid.Id);
			}
		}
		return hashSet;
	}

	public virtual ISet<string> GetNonCriticalExtensionOids()
	{
		return GetExtensionOids(critical: false);
	}

	public virtual ISet<string> GetCriticalExtensionOids()
	{
		return GetExtensionOids(critical: true);
	}

	public virtual Asn1OctetString GetExtensionValue(DerObjectIdentifier oid)
	{
		return GetX509Extensions()?.GetExtension(oid)?.Value;
	}
}
