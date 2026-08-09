using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum CertificateValidationOptions
{
	Default = 0,
	SuppressCertificateExpired = 1,
	SuppressHostNameInvalid = 2,
	SuppressRevocationStatusUnknown = 8,
	CheckRevocationStatusOnline = 0x10,
	CheckRevocationStatusOffine = 0x20,
	TreatAsInvalid = 0x40
}
