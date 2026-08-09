using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal class PdfStreamWriter : IPdfStreamWriter, IDisposable
{
	private readonly Action<double>? recordVersion;

	protected const double DefaultVersion = 1.2;

	protected Dictionary<IndirectReference, long> offsets = new Dictionary<IndirectReference, long>();

	protected readonly ITokenWriter TokenWriter;

	protected bool DisposeStream { get; set; }

	protected bool Initialized { get; set; }

	protected int CurrentNumber { get; set; } = 1;

	public Stream Stream { get; protected set; }

	public bool AttemptDeduplication { get; set; } = true;

	public bool WritingPageContents
	{
		get
		{
			return TokenWriter.WritingPageContents;
		}
		set
		{
			TokenWriter.WritingPageContents = value;
		}
	}

	internal PdfStreamWriter(Stream baseStream, bool disposeStream = true, ITokenWriter? tokenWriter = null, Action<double>? recordVersion = null)
	{
		Stream = baseStream ?? throw new ArgumentNullException("baseStream");
		if (!baseStream.CanWrite)
		{
			throw new ArgumentException("Output stream must be writable");
		}
		this.recordVersion = recordVersion;
		DisposeStream = disposeStream;
		TokenWriter = tokenWriter ?? new TokenWriter();
	}

	public virtual IndirectReferenceToken WriteToken(IToken token)
	{
		if (!Initialized)
		{
			InitializePdf(1.2);
		}
		IndirectReferenceToken indirectReferenceToken = ReserveObjectNumber();
		offsets.Add(indirectReferenceToken.Data, Stream.Position);
		ObjectToken token2 = new ObjectToken(Stream.Position, indirectReferenceToken.Data, token);
		TokenWriter.WriteToken(token2, Stream);
		return indirectReferenceToken;
	}

	public virtual IndirectReferenceToken WriteToken(IToken token, IndirectReferenceToken indirectReference)
	{
		if (!Initialized)
		{
			InitializePdf(1.2);
		}
		offsets.Add(indirectReference.Data, Stream.Position);
		ObjectToken token2 = new ObjectToken(Stream.Position, indirectReference.Data, token);
		TokenWriter.WriteToken(token2, Stream);
		return indirectReference;
	}

	public IndirectReferenceToken ReserveObjectNumber()
	{
		return new IndirectReferenceToken(new IndirectReference(CurrentNumber++, 0));
	}

	public void InitializePdf(double version)
	{
		recordVersion?.Invoke(version);
		Stream.WriteText("%PDF-" + version.ToString("0.0", CultureInfo.InvariantCulture));
		Stream.WriteNewLine();
		Stream.WriteText("%"u8);
		Stream.Write(new byte[4] { 169, 205, 196, 210 });
		Stream.WriteNewLine();
		Initialized = true;
	}

	public void CompletePdf(IndirectReferenceToken catalogReference, IndirectReferenceToken? documentInformationReference = null)
	{
		TokenWriter.WriteCrossReferenceTable(offsets, catalogReference.Data, Stream, documentInformationReference?.Data);
	}

	public void Dispose()
	{
		if (DisposeStream)
		{
			Stream?.Dispose();
		}
		Stream = null;
	}
}
