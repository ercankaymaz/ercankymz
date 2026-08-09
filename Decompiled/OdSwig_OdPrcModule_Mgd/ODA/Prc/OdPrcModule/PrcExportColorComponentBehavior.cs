using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum PrcExportColorComponentBehavior
{
	kExportAsIs = 0,
	kExportWhite = 1,
	kExportNotInited = 2
}
