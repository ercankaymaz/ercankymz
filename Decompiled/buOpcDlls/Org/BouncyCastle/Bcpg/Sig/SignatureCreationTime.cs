using System;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities.Date;

namespace Org.BouncyCastle.Bcpg.Sig;

public class SignatureCreationTime : SignatureSubpacket
{
	protected static byte[] TimeToBytes(DateTime time)
	{
		return Pack.UInt32_To_BE((uint)(DateTimeUtilities.DateTimeToUnixMs(time) / 1000));
	}

	public SignatureCreationTime(bool critical, bool isLongLength, byte[] data)
		: base(SignatureSubpacketTag.CreationTime, critical, isLongLength, data)
	{
	}

	public SignatureCreationTime(bool critical, DateTime date)
		: base(SignatureSubpacketTag.CreationTime, critical, isLongLength: false, TimeToBytes(date))
	{
	}

	public DateTime GetTime()
	{
		return DateTimeUtilities.UnixMsToDateTime((long)Pack.BE_To_UInt32(data, 0) * 1000L);
	}
}
