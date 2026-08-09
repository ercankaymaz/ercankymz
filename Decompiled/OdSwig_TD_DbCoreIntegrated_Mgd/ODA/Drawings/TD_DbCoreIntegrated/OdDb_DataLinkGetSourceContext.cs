using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_DataLinkGetSourceContext
{
	kDataLinkGetSourceContextUnknown = 0,
	kDataLinkGetSourceContextEtransmit = 1,
	kDataLinkGetSourceContextXrefManager = 2,
	kDataLinkGetSourceContextFileWatcher = 3,
	kDataLinkGetSourceContextOther = 4
}
