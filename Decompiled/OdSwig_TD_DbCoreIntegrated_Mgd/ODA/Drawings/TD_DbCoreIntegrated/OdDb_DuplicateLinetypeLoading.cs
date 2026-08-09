using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_DuplicateLinetypeLoading
{
	kDltNotApplicable = 0,
	kDltIgnore = 1,
	kDltReplace = 2
}
