using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Fonts;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfToUnicodeMap : PdfDictionary
{
	public sealed class Keys : PdfStream.Keys
	{
	}

	private CMapInfo _cmapInfo;

	public CMapInfo CMapInfo
	{
		get
		{
			return _cmapInfo;
		}
		set
		{
			_cmapInfo = value;
		}
	}

	public PdfToUnicodeMap(PdfDocument document)
		: base(document)
	{
	}

	public PdfToUnicodeMap(PdfDocument document, CMapInfo cmapInfo)
		: base(document)
	{
		_cmapInfo = cmapInfo;
	}

	internal override void PrepareForSave()
	{
		base.PrepareForSave();
		string value = "/CIDInit /ProcSet findresource begin\n12 dict begin\nbegincmap\n/CIDSystemInfo << /Registry (Adobe)/Ordering (UCS)/Supplement 0>> def\n/CMapName /Adobe-Identity-UCS def /CMapType 2 def\n";
		string value2 = "endcmap CMapName currentdict /CMap defineresource pop end end";
		Dictionary<int, char> dictionary = new Dictionary<int, char>();
		int num = 65536;
		int num2 = -1;
		foreach (KeyValuePair<char, int> item in _cmapInfo.CharacterToGlyphIndex)
		{
			int value3 = item.Value;
			num = Math.Min(num, value3);
			num2 = Math.Max(num2, value3);
			dictionary[value3] = item.Key;
		}
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII);
		streamWriter.Write(value);
		streamWriter.WriteLine("1 begincodespacerange");
		streamWriter.WriteLine($"<{num:X4}><{num2:X4}>");
		streamWriter.WriteLine("endcodespacerange");
		streamWriter.WriteLine($"{dictionary.Count} beginbfrange");
		foreach (KeyValuePair<int, char> item2 in dictionary)
		{
			streamWriter.WriteLine(string.Format("<{0:X4}><{0:X4}><{1:X4}>", item2.Key, (int)item2.Value));
		}
		streamWriter.WriteLine("endbfrange");
		streamWriter.Write(value2);
		streamWriter.Close();
		byte[] array = memoryStream.ToArray();
		memoryStream.Close();
		if (Owner.Options.CompressContentStreams)
		{
			base.Elements.SetName("/Filter", "/FlateDecode");
			array = Filtering.FlateDecode.Encode(array, _document.Options.FlateEncodeMode);
		}
		else
		{
			base.Elements.Remove("/Filter");
		}
		if (base.Stream == null)
		{
			CreateStream(array);
			return;
		}
		base.Stream.Value = array;
		base.Elements.SetInteger("/Length", base.Stream.Length);
	}
}
