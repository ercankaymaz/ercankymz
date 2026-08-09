using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum RotaryMachiningBasedTpCalcParamsSlicesPattern
{
	RmbSlpRadiusConstant,
	RmbSlpOffsetFromHub,
	RmbSlpMorphBetwHubAndShroud,
	RmbSlpRadiusAxialConstant,
	RmbSlpCylindricalConical
}
