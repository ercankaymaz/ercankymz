using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Crypto.IO;

public sealed class MacSink : BaseOutputStream
{
	private readonly IMac m_mac;

	public IMac Mac => m_mac;

	public MacSink(IMac mac)
	{
		m_mac = mac;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Streams.ValidateBufferArguments(buffer, offset, count);
		if (count > 0)
		{
			m_mac.BlockUpdate(buffer, offset, count);
		}
	}

	public override void WriteByte(byte value)
	{
		m_mac.Update(value);
	}
}
