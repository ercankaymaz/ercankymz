#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfCrossReferenceStream : PdfTrailer
{
	public struct CrossReferenceStreamEntry
	{
		public uint Type;

		public uint Field2;

		public uint Field3;
	}

	public new class Keys : PdfTrailer.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "XRef")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public new const string Size = "/Size";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Index = "/Index";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public new const string Prev = "/Prev";

		[KeyInfo(KeyType.Array | KeyType.Required)]
		public const string W = "/W";

		private static DictionaryMeta _meta;

		public new static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public readonly List<CrossReferenceStreamEntry> Entries = new List<CrossReferenceStreamEntry>();

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfCrossReferenceStream(PdfDocument document)
		: base(document)
	{
		if (PdfDiagnostics.TraceXrefStreams)
		{
			Debug.WriteLine("PdfCrossReferenceStream created.");
		}
	}
}
