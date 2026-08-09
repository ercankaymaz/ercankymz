namespace Org.BouncyCastle.Crypto.Operators;

public sealed class DefaultSignatureResult : IBlockResult
{
	private readonly ISigner mSigner;

	public DefaultSignatureResult(ISigner signer)
	{
		mSigner = signer;
	}

	public byte[] Collect()
	{
		return mSigner.GenerateSignature();
	}

	public int Collect(byte[] buf, int off)
	{
		byte[] array = Collect();
		array.CopyTo(buf, off);
		return array.Length;
	}

	public int GetMaxResultLength()
	{
		return mSigner.GetMaxSignatureSize();
	}
}
