using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_DataLinkOption
{
	kDataLinkOptionNone = 0,
	kDataLinkOptionAnonymous = 1,
	kDataLinkOptionPersistCache = 2,
	kDataLinkOptionDisableInLongTransaction = 4,
	kDataLinkHasCustomData = 8
}
