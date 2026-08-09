using System.IO;

namespace Org.BouncyCastle.Asn1;

internal class DerOutputStream : Asn1OutputStream
{
	internal override int Encoding => 2;

	internal DerOutputStream(Stream os, bool leaveOpen)
		: base(os, leaveOpen)
	{
	}
}
