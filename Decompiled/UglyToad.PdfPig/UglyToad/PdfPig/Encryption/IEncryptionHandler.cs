using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Encryption;

internal interface IEncryptionHandler
{
	IToken Decrypt(IndirectReference reference, IToken token);
}
