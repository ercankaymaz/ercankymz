#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.Advanced;

internal class PdfTrailer : PdfDictionary
{
	internal class Keys : KeysBase
	{
		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string Size = "/Size";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string Prev = "/Prev";

		[KeyInfo(KeyType.Dictionary | KeyType.Required, typeof(PdfCatalog))]
		public const string Root = "/Root";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfStandardSecurityHandler))]
		public const string Encrypt = "/Encrypt";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfDocumentInformation))]
		public const string Info = "/Info";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string ID = "/ID";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string XRefStm = "/XRefStm";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal PdfStandardSecurityHandler _securityHandler;

	public int Size
	{
		get
		{
			return base.Elements.GetInteger("/Size");
		}
		set
		{
			base.Elements.SetInteger("/Size", value);
		}
	}

	public PdfDocumentInformation Info => (PdfDocumentInformation)base.Elements.GetValue("/Info", VCF.CreateIndirect);

	public PdfCatalog Root => (PdfCatalog)base.Elements.GetValue("/Root", VCF.CreateIndirect);

	public PdfStandardSecurityHandler SecurityHandler
	{
		get
		{
			if (_securityHandler == null)
			{
				_securityHandler = (PdfStandardSecurityHandler)base.Elements.GetValue("/Encrypt", VCF.CreateIndirect);
			}
			return _securityHandler;
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfTrailer(PdfDocument document)
		: base(document)
	{
		_document = document;
	}

	public PdfTrailer(PdfCrossReferenceStream trailer)
		: base(trailer._document)
	{
		_document = trailer._document;
		PdfReference reference = trailer.Elements.GetReference("/Info");
		if (reference != null)
		{
			base.Elements.SetReference("/Info", reference);
		}
		base.Elements.SetReference("/Root", trailer.Elements.GetReference("/Root"));
		base.Elements.SetInteger("/Size", trailer.Elements.GetInteger("/Size"));
		PdfArray array = trailer.Elements.GetArray("/ID");
		if (array != null)
		{
			base.Elements.SetValue("/ID", array);
		}
	}

	public string GetDocumentID(int index)
	{
		if (index < 0 || index > 1)
		{
			throw new ArgumentOutOfRangeException("index", index, "Index must be 0 or 1.");
		}
		if (!(base.Elements["/ID"] is PdfArray pdfArray) || pdfArray.Elements.Count < 2)
		{
			return "";
		}
		PdfItem pdfItem = pdfArray.Elements[index];
		if (pdfItem is PdfString)
		{
			return ((PdfString)pdfItem).Value;
		}
		return "";
	}

	public void SetDocumentID(int index, string value)
	{
		if (index < 0 || index > 1)
		{
			throw new ArgumentOutOfRangeException("index", index, "Index must be 0 or 1.");
		}
		PdfArray pdfArray = base.Elements["/ID"] as PdfArray;
		if (pdfArray == null || pdfArray.Elements.Count < 2)
		{
			pdfArray = CreateNewDocumentIDs();
		}
		pdfArray.Elements[index] = new PdfString(value, PdfStringFlags.HexLiteral);
	}

	internal PdfArray CreateNewDocumentIDs()
	{
		PdfArray pdfArray = new PdfArray(_document);
		byte[] array = Guid.NewGuid().ToByteArray();
		string value = PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
		pdfArray.Elements.Add(new PdfString(value, PdfStringFlags.HexLiteral));
		pdfArray.Elements.Add(new PdfString(value, PdfStringFlags.HexLiteral));
		base.Elements["/ID"] = pdfArray;
		return pdfArray;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		_elements.Remove("/XRefStm");
		PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
		writer.SecurityHandler = null;
		base.WriteObject(writer);
		writer.SecurityHandler = securityHandler;
	}

	internal void Finish()
	{
		if (_document._trailer.Elements["/Root"] is PdfReference { Value: null } pdfReference)
		{
			PdfReference pdfReference2 = _document._irefTable[pdfReference.ObjectID];
			Debug.Assert(pdfReference2.Value != null);
			_document._trailer.Elements["/Root"] = pdfReference2;
		}
		if (_document._trailer.Elements["/Info"] is PdfReference { Value: null } pdfReference3)
		{
			PdfReference pdfReference2 = _document._irefTable[pdfReference3.ObjectID];
			Debug.Assert(pdfReference2.Value != null);
			_document._trailer.Elements["/Info"] = pdfReference2;
		}
		if (_document._trailer.Elements["/Encrypt"] is PdfReference pdfReference4)
		{
			PdfReference pdfReference2 = _document._irefTable[pdfReference4.ObjectID];
			Debug.Assert(pdfReference2.Value != null);
			_document._trailer.Elements["/Encrypt"] = pdfReference2;
			pdfReference2.Value = _document._trailer._securityHandler;
			_document._trailer._securityHandler.Reference = pdfReference2;
			pdfReference2.Value.Reference = pdfReference2;
		}
		base.Elements.Remove("/Prev");
		Debug.Assert(!_document._irefTable.IsUnderConstruction);
		_document._irefTable.IsUnderConstruction = false;
	}
}
