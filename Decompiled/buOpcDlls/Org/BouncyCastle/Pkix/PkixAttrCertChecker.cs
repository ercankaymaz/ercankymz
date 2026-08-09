using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Pkix;

public abstract class PkixAttrCertChecker
{
	public abstract ISet<DerObjectIdentifier> GetSupportedExtensions();

	public abstract void Check(X509V2AttributeCertificate attrCert, PkixCertPath certPath, PkixCertPath holderCertPath, ICollection<string> unresolvedCritExts);

	public abstract PkixAttrCertChecker Clone();
}
