using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeDash_ShapeInfo_Flags
{
	kFlagSymbolAtElementOrigin = 1,
	kFlagSymbolAtElementEnd = 2,
	kFlagSymbolAtEachVertex = 4,
	kFlagMirrorSymbolForReversedLines = 8,
	kFlagAbsoluteRotationAngle = 0x10,
	kFlagDoNotScaleElement = 0x20,
	kFlagDoNotClipElement = 0x40,
	kFlagNoPartialStrokes = 0x80,
	kFlagPartialOriginBeyondEnd = 0x100,
	kFlagUseSymbolColor = 0x200,
	kFlagUseSymbolWeight = 0x400
}
