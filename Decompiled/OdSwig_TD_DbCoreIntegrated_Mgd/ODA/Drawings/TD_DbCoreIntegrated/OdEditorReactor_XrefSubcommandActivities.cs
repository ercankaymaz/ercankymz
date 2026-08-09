using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdEditorReactor_XrefSubcommandActivities
{
	kStart = 0,
	kStartItem = 2,
	kEndItem = 3,
	kEnd = 4,
	kWillAbort = 5,
	kAborted = 6,
	kStartXBindBlock = 7,
	kStartXBindSymbol = 8
}
