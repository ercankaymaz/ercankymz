using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class CertificateUpdateEventArgs : EventArgs
{
	public SecurityConfiguration SecurityConfiguration { get; private set; }

	public ICertificateValidator CertificateValidator { get; private set; }

	public CertificateUpdateEventArgs(SecurityConfiguration configuration, ICertificateValidator validator)
	{
		SecurityConfiguration = configuration;
		CertificateValidator = validator;
	}
}
