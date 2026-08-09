using System;

namespace UglyToad.PdfPig.AcroForms;

[Flags]
public enum SignatureFlags
{
	SignaturesExist = 1,
	AppendOnly = 2
}
