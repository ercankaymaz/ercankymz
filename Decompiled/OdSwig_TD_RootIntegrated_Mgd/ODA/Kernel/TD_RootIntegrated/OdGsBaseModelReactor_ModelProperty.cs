using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseModelReactor_ModelProperty
{
	kModelTransform = 0,
	kModelRenderType = 1,
	kModelBackground = 2,
	kModelVisualStyle = 3,
	kModelSectioning = 4,
	kNumModelProps = 5
}
