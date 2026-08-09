using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDwfxSignatureHandler_SignatureValidationResult
{
	kSuccess = 0,
	kInvalidSignature = 1,
	kCertificateChainProblem = 2,
	kNotSigned = 3
}
