using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_OdGeKnotParameterization
{
	kChord = 0,
	kSqrtChord = 1,
	kUniform = 2,
	kCustomParameterization = 0xF,
	kNotDefinedKnotParam = 0x10
}
