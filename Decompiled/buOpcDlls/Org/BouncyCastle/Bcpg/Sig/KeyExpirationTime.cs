using Org.BouncyCastle.Crypto.Utilities;

namespace Org.BouncyCastle.Bcpg.Sig;

public class KeyExpirationTime : SignatureSubpacket
{
	public long Time => Pack.BE_To_UInt32(data);

	protected static byte[] TimeToBytes(long t)
	{
		return Pack.UInt32_To_BE((uint)t);
	}

	public KeyExpirationTime(bool critical, bool isLongLength, byte[] data)
		: base(SignatureSubpacketTag.KeyExpireTime, critical, isLongLength, data)
	{
	}

	public KeyExpirationTime(bool critical, long seconds)
		: base(SignatureSubpacketTag.KeyExpireTime, critical, isLongLength: false, TimeToBytes(seconds))
	{
	}
}
