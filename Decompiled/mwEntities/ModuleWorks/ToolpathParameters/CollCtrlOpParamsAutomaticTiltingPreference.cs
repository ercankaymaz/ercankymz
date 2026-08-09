using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpParamsAutomaticTiltingPreference
{
	AtPrefEqTiltingAndRotary,
	AtPrefPreferTilting,
	AtPrefPreferRotary,
	AtPrefPreferTiltingStrict,
	AtPrefPreferRotaryStrict
}
