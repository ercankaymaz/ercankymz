using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdSignDataResult
{
	kSignData_Success = 0,
	kSignData_InvalidInput = 1,
	kSignData_CertificateContextError = 2,
	kSignData_PrivateKeyNotFound = 3,
	kSignData_ProviderError = 4,
	kSignData_AlgorithmNotSupported = 5,
	kSignData_HashCreationError = 6,
	kSignData_HashDataError = 7,
	kSignData_SignatureCreationError = 8,
	kSignData_InternalError = 9,
	kSignData_UnknownError = 0xA
}
