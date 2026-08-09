using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;

namespace Org.BouncyCastle.Crmf;

internal class PKMacStreamCalculator : IStreamCalculator<DefaultPKMacResult>
{
	private readonly MacSink _stream;

	public Stream Stream => _stream;

	public PKMacStreamCalculator(IMac mac)
	{
		_stream = new MacSink(mac);
	}

	public DefaultPKMacResult GetResult()
	{
		return new DefaultPKMacResult(_stream.Mac);
	}
}
