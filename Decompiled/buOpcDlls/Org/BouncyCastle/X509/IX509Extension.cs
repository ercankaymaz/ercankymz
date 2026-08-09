using System.Collections.Generic;
using Org.BouncyCastle.Asn1;

namespace Org.BouncyCastle.X509;

public interface IX509Extension
{
	ISet<string> GetCriticalExtensionOids();

	ISet<string> GetNonCriticalExtensionOids();

	Asn1OctetString GetExtensionValue(DerObjectIdentifier oid);
}
