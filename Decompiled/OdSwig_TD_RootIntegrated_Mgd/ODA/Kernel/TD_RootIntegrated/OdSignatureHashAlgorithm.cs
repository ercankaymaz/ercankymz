using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdSignatureHashAlgorithm
{
	kSHA1 = 0,
	kSHA256 = 1,
	kSHA384 = 2,
	kSHA512 = 3
}
