using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum ENodeType
{
	kBlockNode = 0,
	kContainerNode = 1,
	kLayerNode = 2,
	kEntityNode = 3,
	kMaterialNode = 4,
	kLastNodeType = 5,
	kLightNode = 6,
	kBlockReferenceNode = 7,
	kMInsertBlockNode = 8
}
