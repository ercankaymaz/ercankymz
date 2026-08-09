using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdPs_LineType
{
	kLtpSolid = 0,
	kLtpDashed = 1,
	kLtpDotted = 2,
	kLtpDashDot = 3,
	kLtpShortDash = 4,
	kLtpMediumDash = 5,
	kLtpLongDash = 6,
	kLtpShortDashX2 = 7,
	kLtpMediumDashX2 = 8,
	kLtpLongDashX2 = 9,
	kLtpMediumLongDash = 0xA,
	kLtpMediumDashShortDashShortDash = 0xB,
	kLtpLongDashShortDash = 0xC,
	kLtpLongDashDotDot = 0xD,
	kLtpLongDashDot = 0xE,
	kLtpMediumDashDotShortDashDot = 0xF,
	kLtpSparseDot = 0x10,
	kLtpISODash = 0x11,
	kLtpISODashSpace = 0x12,
	kLtpISOLongDashDot = 0x13,
	kLtpISOLongDashDoubleDot = 0x14,
	kLtpISOLongDashTripleDot = 0x15,
	kLtpISODot = 0x16,
	kLtpISOLongDashShortDash = 0x17,
	kLtpISOLongDashDoubleShortDash = 0x18,
	kLtpISODashDot = 0x19,
	kLtpISODoubleDashDot = 0x1A,
	kLtpISODashDoubleDot = 0x1B,
	kLtpISODoubleDashDoubleDot = 0x1C,
	kLtpISODashTripleDot = 0x1D,
	kLtpISODoubleDashTripleDot = 0x1E,
	kLtpUseObject = 0x1F,
	kLtpLast = 0x1F
}
