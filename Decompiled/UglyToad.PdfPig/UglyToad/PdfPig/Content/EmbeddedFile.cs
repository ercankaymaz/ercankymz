using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class EmbeddedFile
{
	public string Name { get; }

	public string FileSpecification { get; }

	public ReadOnlyMemory<byte> Memory { get; }

	public ReadOnlySpan<byte> Bytes => Memory.Span;

	public StreamToken Stream { get; }

	internal EmbeddedFile(string name, string fileSpecification, ReadOnlyMemory<byte> bytes, StreamToken stream)
	{
		Name = name ?? throw new ArgumentNullException("name");
		FileSpecification = fileSpecification;
		Memory = bytes;
		Stream = stream ?? throw new ArgumentNullException("stream");
	}

	public override string ToString()
	{
		return $"{Name}: {Stream.StreamDictionary}.";
	}
}
