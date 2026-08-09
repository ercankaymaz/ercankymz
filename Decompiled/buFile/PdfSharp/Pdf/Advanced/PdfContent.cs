#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfContent : PdfDictionary
{
	internal sealed class Keys : PdfStream.Keys
	{
		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal XGraphicsPdfRenderer _pdfRenderer;

	public bool Compressed
	{
		set
		{
			if (value)
			{
				PdfItem pdfItem = base.Elements["/Filter"];
				if (pdfItem == null)
				{
					byte[] value2 = Filtering.FlateDecode.Encode(base.Stream.Value, _document.Options.FlateEncodeMode);
					base.Stream.Value = value2;
					base.Elements.SetInteger("/Length", base.Stream.Length);
					base.Elements.SetName("/Filter", "/FlateDecode");
				}
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfContent(PdfDocument document)
		: base(document)
	{
	}

	internal PdfContent(PdfPage page)
		: base(page?.Owner)
	{
	}

	public PdfContent(PdfDictionary dict)
		: base(dict)
	{
		Decode();
	}

	private void Decode()
	{
		if (base.Stream == null || base.Stream.Value == null)
		{
			return;
		}
		PdfItem pdfItem = base.Elements["/Filter"];
		if (pdfItem != null)
		{
			byte[] array = Filtering.Decode(base.Stream.Value, pdfItem);
			if (array != null)
			{
				base.Stream.Value = array;
				base.Elements.Remove("/Filter");
				base.Elements.SetInteger("/Length", base.Stream.Length);
			}
		}
	}

	internal void PreserveGraphicsState()
	{
		if (base.Stream != null)
		{
			byte[] value = base.Stream.Value;
			int num = value.Length;
			if (num != 0 && (value[0] != 113 || value[1] != 10))
			{
				byte[] array = new byte[num + 2 + 3];
				array[0] = 113;
				array[1] = 10;
				Array.Copy(value, 0, array, 2, num);
				array[num + 2] = 32;
				array[num + 3] = 81;
				array[num + 4] = 10;
				base.Stream.Value = array;
				base.Elements.SetInteger("/Length", base.Stream.Length);
			}
		}
	}

	internal override void WriteObject(PdfWriter writer)
	{
		if (_pdfRenderer != null)
		{
			_pdfRenderer.Close();
			Debug.Assert(_pdfRenderer == null);
		}
		if (base.Stream != null)
		{
			if (Owner.Options.CompressContentStreams && base.Elements.GetName("/Filter").Length == 0)
			{
				base.Stream.Value = Filtering.FlateDecode.Encode(base.Stream.Value, _document.Options.FlateEncodeMode);
				base.Elements.SetName("/Filter", "/FlateDecode");
			}
			base.Elements.SetInteger("/Length", base.Stream.Length);
		}
		base.WriteObject(writer);
	}
}
