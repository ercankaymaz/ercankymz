using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSection_SubItem
{
	kNone = 0,
	kSectionLine = 1,
	kSectionLineTop = 2,
	kSectionLineBottom = 4,
	kBackLine = 8,
	kBackLineTop = 0x10,
	kBackLineBottom = 0x20,
	kVerticalLineTop = 0x40,
	kVerticalLineBottom = 0x80
}
