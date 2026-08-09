using System;

namespace UglyToad.PdfPig.Core;

public interface IInputBytes : IDisposable
{
	long CurrentOffset { get; }

	byte CurrentByte { get; }

	long Length { get; }

	bool MoveNext();

	byte? Peek();

	bool IsAtEnd();

	void Seek(long position);

	int Read(Span<byte> buffer);
}
