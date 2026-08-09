using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdCryptoServices_OdSignatureVerificationResult
{
	kSuccess = 0,
	kHasNoSignature = 1,
	kBadSignature = 2,
	kCertificateChainProblem = 3,
	kBadAlgId = 4,
	kNoSigner = 5,
	kUnexpectedMsgType = 6,
	kInvalidArg = 7,
	kUnknownError = 8
}
