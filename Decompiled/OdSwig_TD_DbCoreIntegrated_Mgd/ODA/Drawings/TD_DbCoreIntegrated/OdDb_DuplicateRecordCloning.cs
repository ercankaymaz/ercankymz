using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_DuplicateRecordCloning
{
	kDrcNotApplicable = 0,
	kDrcIgnore = 1,
	kDrcReplace = 2,
	kDrcXrefMangleName = 3,
	kDrcMangleName = 4,
	kDrcUnmangleName = 5,
	kDrcMax = 5
}
