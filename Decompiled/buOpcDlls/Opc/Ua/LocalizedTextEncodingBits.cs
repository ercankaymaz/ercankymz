using System;

namespace Opc.Ua;

[Flags]
internal enum LocalizedTextEncodingBits
{
	Locale = 1,
	Text = 2
}
