using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdaApp_LoadReasons
{
	kOnProxyDetection = 1,
	kOnTeighaStartup = 2,
	kOnCommandInvocation = 4,
	kOnLoadRequest = 8,
	kLoadDisabled = 0x10,
	kTransparentlyLoadable = 0x20
}
