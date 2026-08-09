using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdBrFace_AutoTransform
{
	kInheritAutoTransform = 0,
	kNone = 1,
	kObject = 2,
	kModel = 4,
	kPredefinedBim = 8
}
