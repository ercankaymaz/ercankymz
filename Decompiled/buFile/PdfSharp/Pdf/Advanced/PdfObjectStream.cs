#define DEBUG
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Advanced;

public class PdfObjectStream : PdfDictionary
{
	public class Keys : PdfStream.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "ObjStm")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string N = "/N";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string First = "/First";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string Extends = "/Extends";
	}

	private readonly int[][] _header;

	public PdfObjectStream(PdfDocument document)
		: base(document)
	{
		if (PdfDiagnostics.TraceObjectStreams)
		{
			Debug.WriteLine("PdfObjectStream(document) created.");
		}
	}

	internal PdfObjectStream(PdfDictionary dict)
		: base(dict)
	{
		int integer = base.Elements.GetInteger("/N");
		int integer2 = base.Elements.GetInteger("/First");
		base.Stream.TryUnfilter();
		Parser parser = new Parser(null, new MemoryStream(base.Stream.Value));
		_header = parser.ReadObjectStreamHeader(integer, integer2);
		if (PdfDiagnostics.TraceObjectStreams)
		{
			Debug.WriteLine($"PdfObjectStream(document) created. Header item count: {_header.GetLength(0)}");
		}
	}

	internal void ReadReferences(PdfCrossReferenceTable xrefTable)
	{
		for (int i = 0; i < _header.Length; i++)
		{
			int objectNumber = _header[i][0];
			int num = _header[i][1];
			PdfObjectID objectID = new PdfObjectID(objectNumber);
			PdfReference pdfReference = new PdfReference(objectID, -1);
			if (!xrefTable.Contains(pdfReference.ObjectID))
			{
				xrefTable.Add(pdfReference);
			}
			else
			{
				GetType();
			}
		}
	}

	internal PdfReference ReadCompressedObject(int index)
	{
		Parser parser = new Parser(_document, new MemoryStream(base.Stream.Value));
		int objectNumber = _header[index][0];
		int offset = _header[index][1];
		return parser.ReadCompressedObject(objectNumber, offset);
	}
}
