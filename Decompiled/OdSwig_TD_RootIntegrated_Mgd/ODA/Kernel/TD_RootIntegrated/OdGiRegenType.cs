using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiRegenType
{
	eOdGiRegenTypeInvalid = 0,
	kOdGiStandardDisplay = 2,
	kOdGiHideOrShadeCommand = 3,
	kOdGiRenderCommand = 4,
	kOdGiForExplode = 5,
	kOdGiSaveWorldDrawForProxy = 6,
	kOdGiForExtents = 7
}
