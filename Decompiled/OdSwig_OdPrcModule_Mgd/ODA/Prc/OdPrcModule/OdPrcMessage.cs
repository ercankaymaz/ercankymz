using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum OdPrcMessage
{
	sidPrcDummyFirstMessage = 0x3B5,
	sidPrcPmSavingTo = 0x3B6,
	sidPrcPmAuditing = 0x3B7,
	sidPrcPmLoadingPrcfile = 0x3B8,
	sidPrcDummyLastMessage = 0x3B9
}
