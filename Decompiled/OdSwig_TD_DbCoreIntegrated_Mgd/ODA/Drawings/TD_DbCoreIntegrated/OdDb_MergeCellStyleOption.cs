using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_MergeCellStyleOption
{
	kMergeCellStyleNone = 0,
	kMergeCellStyleCopyDuplicates = 1,
	kMergeCellStyleOverwriteDuplicates = 2,
	kMergeCellStyleConvertDuplicatesToOverrides = 4,
	kMergeCellStyleIgnoreNewStyles = 8
}
