using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum ShaderFlags
{
	Debug = 1,
	SkipValidation = 2,
	SkipOptimization = 4,
	PackMatrixRowMajor = 8,
	PackMatrixColumnMajor = 0x10,
	PartialPrecision = 0x20,
	ForceVertexShaderSoftwareNoOptimization = 0x40,
	ForcePixelShaderSoftwareNoOptimization = 0x80,
	NoPreshader = 0x100,
	AvoidFlowControl = 0x200,
	PreferFlowControl = 0x400,
	EnableStrictness = 0x800,
	EnableBackwardsCompatibility = 0x1000,
	IeeeStrictness = 0x2000,
	OptimizationLevel0 = 0x4000,
	OptimizationLevel1 = 0,
	OptimizationLevel2 = 0xC000,
	OptimizationLevel3 = 0x8000,
	Reserved16 = 0x10000,
	Reserved17 = 0x20000,
	WarningsAreErrors = 0x40000,
	DebugNameForSource = 0x400000,
	DebugNameForBinary = 0x800000,
	None = 0
}
