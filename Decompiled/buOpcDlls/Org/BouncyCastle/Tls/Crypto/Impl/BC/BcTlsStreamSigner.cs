using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;

namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsStreamSigner : TlsStreamSigner
{
	private readonly SignerSink m_output;

	public Stream Stream => m_output;

	internal BcTlsStreamSigner(ISigner signer)
	{
		m_output = new SignerSink(signer);
	}

	public byte[] GetSignature()
	{
		try
		{
			return m_output.Signer.GenerateSignature();
		}
		catch (CryptoException alertCause)
		{
			throw new TlsFatalAlert(80, alertCause);
		}
	}
}
