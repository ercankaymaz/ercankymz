using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum ShaderRequiresFlags
{
	ShaderRequiresDoubles = 1,
	ShaderRequiresEarlyDepthStencil = 2,
	ShaderRequiresUnorderedAccessViewsAtEveryStage = 4,
	ShaderRequires64UnorderedAccessViews = 8,
	ShaderRequiresMinimumPrecision = 0x10,
	ShaderRequires111DoubleExtensionS = 0x20,
	ShaderRequires111ShaderExtensionS = 0x40,
	ShaderRequiresLevel9ComparisonFiltering = 0x80,
	ShaderRequiresTiledResources = 0x100,
	ShaderRequiresStencilRef = 0x200,
	ShaderRequiresInnerCoverage = 0x400,
	ShaderRequiresTypedUnorderedAccessViewLoadAdditionalFormatS = 0x800,
	ShaderRequiresRovs = 0x1000,
	ShaderRequiresViewportAndRtArrayIndexFromAnyShaderFeedingRasterizer = 0x2000,
	None = 0
}
