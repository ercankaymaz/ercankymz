using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEd_CommonInputOptions : long
{
	kInpDefault = 0L,
	kInpDisallowEmpty = 0L,
	kInpDisallowOther = 0L,
	kInpThrowEmpty = -2147483648L,
	kInpThrowOther = 0x40000000L,
	kInpNonZero = 0x20000000L,
	kInpNonNeg = 0x10000000L,
	kInpThrowEmptyInQuotes = 0x2000000L
}
