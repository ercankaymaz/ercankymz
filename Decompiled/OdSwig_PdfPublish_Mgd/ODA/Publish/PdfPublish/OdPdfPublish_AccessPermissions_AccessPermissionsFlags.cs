using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_AccessPermissions_AccessPermissionsFlags
{
	kAllowExtract = 1,
	kAllowAssemble = 2,
	kAllowAnnotateAndForm = 4,
	kAllowFormFilling = 8,
	kAllowModifyOther = 0x10,
	kAllowPrintAll = 0x20,
	kAllowPrintLow = 0x40,
	kDefaultPermissions = 0x29
}
