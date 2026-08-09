using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Encryption;

internal class NoOpEncryptionHandler : IEncryptionHandler
{
	public static NoOpEncryptionHandler Instance { get; } = new NoOpEncryptionHandler();

	private NoOpEncryptionHandler()
	{
	}

	public IToken Decrypt(IndirectReference reference, IToken token)
	{
		return token;
	}
}
