using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbField_EvalStatus
{
	kNotYetEvaluated = 1,
	kSuccess = 2,
	kEvaluatorNotFound = 4,
	kSyntaxError = 8,
	kInvalidCode = 0x10,
	kInvalidContext = 0x20,
	kOtherError = 0x40
}
