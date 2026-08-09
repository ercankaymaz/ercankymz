using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_PagingType
{
	kUnload = 1,
	kPage = 2,
	kDoNotEnqueuePagingOnClose = 4
}
