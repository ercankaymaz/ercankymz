using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_ErrorCondition
{
	kOk = 0,
	k0This = 1,
	k0Arg1 = 2,
	k0Arg2 = 3,
	kPerpendicularArg1Arg2 = 4,
	kEqualArg1Arg2 = 5,
	kEqualArg1Arg3 = 6,
	kEqualArg2Arg3 = 7,
	kLinearlyDependentArg1Arg2Arg3 = 8,
	kArg1TooBig = 9,
	kArg1OnThis = 0xA,
	kArg1InsideThis = 0xB,
	kNonCoplanarGeometry = 0xC,
	kDegenerateGeometry = 0xD,
	kSingularPoint = 0xE
}
