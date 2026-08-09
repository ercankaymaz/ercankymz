using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Crmf;

internal sealed class DefaultPKMacResult : IBlockResult
{
	private readonly IMac mac;

	public DefaultPKMacResult(IMac mac)
	{
		this.mac = mac;
	}

	public byte[] Collect()
	{
		byte[] array = new byte[mac.GetMacSize()];
		mac.DoFinal(array, 0);
		return array;
	}

	public int Collect(byte[] buf, int off)
	{
		return mac.DoFinal(buf, off);
	}

	public int GetMaxResultLength()
	{
		return mac.GetMacSize();
	}
}
