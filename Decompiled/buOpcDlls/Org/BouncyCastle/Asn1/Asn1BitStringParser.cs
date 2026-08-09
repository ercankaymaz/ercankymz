using System.IO;

namespace Org.BouncyCastle.Asn1;

public interface Asn1BitStringParser : IAsn1Convertible
{
	int PadBits { get; }

	Stream GetBitStream();

	Stream GetOctetStream();
}
