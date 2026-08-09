using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMetafiler_EOptions
{
	kTextAsText = 1,
	kNurbsAsNurbs = 2,
	kPlineAsPline = 4,
	kDisableImageConversion = 8
}
