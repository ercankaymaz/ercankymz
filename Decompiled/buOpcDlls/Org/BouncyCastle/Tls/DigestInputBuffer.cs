using System.IO;
using Org.BouncyCastle.Tls.Crypto;

namespace Org.BouncyCastle.Tls;

internal class DigestInputBuffer : MemoryStream
{
	internal void UpdateDigest(TlsHash hash)
	{
		WriteTo(new TlsHashSink(hash));
	}

	internal void CopyInputTo(Stream output)
	{
		WriteTo(output);
	}
}
