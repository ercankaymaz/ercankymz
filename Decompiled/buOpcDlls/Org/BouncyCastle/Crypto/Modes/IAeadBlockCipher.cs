namespace Org.BouncyCastle.Crypto.Modes;

public interface IAeadBlockCipher : IAeadCipher
{
	IBlockCipher UnderlyingCipher { get; }

	int GetBlockSize();
}
