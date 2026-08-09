using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public sealed class PicnicSigner : IMessageSigner
{
	private PicnicPrivateKeyParameters privKey;

	private PicnicPublicKeyParameters pubKey;

	public void Init(bool forSigning, ICipherParameters param)
	{
		if (forSigning)
		{
			privKey = (PicnicPrivateKeyParameters)param;
		}
		else
		{
			pubKey = (PicnicPublicKeyParameters)param;
		}
	}

	public byte[] GenerateSignature(byte[] message)
	{
		PicnicEngine engine = privKey.Parameters.GetEngine();
		byte[] array = new byte[engine.GetSignatureSize(message.Length)];
		engine.crypto_sign(array, message, privKey.GetEncoded());
		return Arrays.CopyOfRange(array, message.Length + 4, engine.GetTrueSignatureSize() + message.Length);
	}

	public bool VerifySignature(byte[] message, byte[] signature)
	{
		PicnicEngine engine = pubKey.Parameters.GetEngine();
		byte[] array = new byte[message.Length];
		bool result = engine.crypto_sign_open(array, signature, pubKey.GetEncoded());
		if (!Arrays.AreEqual(message, array))
		{
			return false;
		}
		return result;
	}
}
