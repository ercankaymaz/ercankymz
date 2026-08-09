using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Crypto.IO;

public sealed class DigestSink : BaseOutputStream
{
	private readonly IDigest m_digest;

	public IDigest Digest => m_digest;

	public DigestSink(IDigest digest)
	{
		m_digest = digest;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Streams.ValidateBufferArguments(buffer, offset, count);
		if (count > 0)
		{
			m_digest.BlockUpdate(buffer, offset, count);
		}
	}

	public override void WriteByte(byte value)
	{
		m_digest.Update(value);
	}
}
