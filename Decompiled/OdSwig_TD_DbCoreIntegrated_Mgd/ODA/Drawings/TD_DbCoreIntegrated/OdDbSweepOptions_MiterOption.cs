using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSweepOptions_MiterOption
{
	kDefaultMiter = 0,
	kOldMiter = 1,
	kNewMiter = 2,
	kCrimpMiter = 3,
	kBendMiter = 4
}
