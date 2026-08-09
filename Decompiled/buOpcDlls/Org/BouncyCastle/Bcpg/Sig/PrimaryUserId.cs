using System;

namespace Org.BouncyCastle.Bcpg.Sig;

public class PrimaryUserId : SignatureSubpacket
{
	private static byte[] BooleanToByteArray(bool val)
	{
		return new byte[1] { Convert.ToByte(val) };
	}

	public PrimaryUserId(bool critical, bool isLongLength, byte[] data)
		: base(SignatureSubpacketTag.PrimaryUserId, critical, isLongLength, data)
	{
	}

	public PrimaryUserId(bool critical, bool isPrimaryUserId)
		: base(SignatureSubpacketTag.PrimaryUserId, critical, isLongLength: false, BooleanToByteArray(isPrimaryUserId))
	{
	}

	public bool IsPrimaryUserId()
	{
		return data[0] != 0;
	}
}
