using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbBlockRepresentationContext_EvaluationMode
{
	Init = 1,
	Eval = 2,
	Replay = 3
}
