namespace UglyToad.PdfPig.Tokenization.Scanner;

public interface ISeekableTokenScanner : ITokenScanner
{
	long CurrentPosition { get; }

	long Length { get; }

	void Seek(long position);

	void RegisterCustomTokenizer(byte firstByte, ITokenizer tokenizer);

	void DeregisterCustomTokenizer(ITokenizer tokenizer);
}
