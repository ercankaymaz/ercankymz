using System;

namespace Microsoft.Isam.Esent.Interop;

public enum JET_IdxInfo
{
	Default = 0,
	List = 1,
	[Obsolete("This value is not used, and is provided for completeness to match the published header in the SDK.")]
	SysTabCursor = 2,
	[Obsolete("This value is not used, and is provided for completeness to match the published header in the SDK.")]
	OLC = 3,
	[Obsolete("This value is not used, and is provided for completeness to match the published header in the SDK.")]
	ResetOLC = 4,
	SpaceAlloc = 5,
	LCID = 6,
	[Obsolete("Use JET_IdxInfo.LCID")]
	Langid = 6,
	Count = 7,
	VarSegMac = 8,
	IndexId = 9,
	KeyMost = 10
}
