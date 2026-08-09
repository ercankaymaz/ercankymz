using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEd_OdDbInputOptions
{
	kGptDefault = 0,
	kGdsDefault = 0,
	kGinDefault = 0,
	kGrlDefault = 0,
	kGanDefault = 0,
	kGptNoLimCheck = 1,
	kGptNoUCS = 2,
	kGptRubberBand = 4,
	kGptRectFrame = 8,
	kGptBeginDrag = 0x10,
	kGptEndDrag = 0x20,
	kGptNoOSnap = 0x40,
	kGanFromLastPoint = 0x80,
	kGdsFromLastPoint = 0x80,
	kGanNoAngBase = 0x100,
	kGds2d = 0x200,
	kGdsSignedDist = 0x400,
	kGdsPerpDist = 0x800,
	kGdsNoZero = 0x1000,
	kGinNoZero = 0x1000,
	kGrlNoZero = 0x1000,
	kGanNoZero = 0x1000,
	kGdsNoNeg = 0x2000,
	kGinNoNeg = 0x2000,
	kGrlNoNeg = 0x2000
}
