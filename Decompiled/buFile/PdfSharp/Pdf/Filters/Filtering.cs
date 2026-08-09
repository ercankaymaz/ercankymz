#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Filters;

public static class Filtering
{
	private static AsciiHexDecode _asciiHexDecode;

	private static Ascii85Decode _ascii85Decode;

	private static LzwDecode _lzwDecode;

	private static FlateDecode _flateDecode;

	public static AsciiHexDecode ASCIIHexDecode => _asciiHexDecode ?? (_asciiHexDecode = new AsciiHexDecode());

	public static Ascii85Decode ASCII85Decode => _ascii85Decode ?? (_ascii85Decode = new Ascii85Decode());

	public static LzwDecode LzwDecode => _lzwDecode ?? (_lzwDecode = new LzwDecode());

	public static FlateDecode FlateDecode => _flateDecode ?? (_flateDecode = new FlateDecode());

	public static Filter GetFilter(string filterName)
	{
		if (filterName.StartsWith("/"))
		{
			filterName = filterName.Substring(1);
		}
		switch (filterName)
		{
		case "ASCIIHexDecode":
		case "AHx":
			return _asciiHexDecode ?? (_asciiHexDecode = new AsciiHexDecode());
		case "ASCII85Decode":
		case "A85":
			return _ascii85Decode ?? (_ascii85Decode = new Ascii85Decode());
		case "LZWDecode":
		case "LZW":
			return _lzwDecode ?? (_lzwDecode = new LzwDecode());
		case "FlateDecode":
		case "Fl":
			return _flateDecode ?? (_flateDecode = new FlateDecode());
		case "RunLengthDecode":
		case "CCITTFaxDecode":
		case "JBIG2Decode":
		case "DCTDecode":
		case "JPXDecode":
		case "Crypt":
			Debug.WriteLine("Filter not implemented: " + filterName);
			return null;
		default:
			throw new NotImplementedException("Unknown filter: " + filterName);
		}
	}

	public static byte[] Encode(byte[] data, string filterName)
	{
		return GetFilter(filterName)?.Encode(data);
	}

	public static byte[] Encode(string rawString, string filterName)
	{
		return GetFilter(filterName)?.Encode(rawString);
	}

	public static byte[] Decode(byte[] data, string filterName, FilterParms parms)
	{
		return GetFilter(filterName)?.Decode(data, parms);
	}

	public static byte[] Decode(byte[] data, string filterName)
	{
		return GetFilter(filterName)?.Decode(data, null);
	}

	public static byte[] Decode(byte[] data, PdfItem filterItem)
	{
		byte[] result = null;
		if (filterItem is PdfName)
		{
			Filter filter = GetFilter(filterItem.ToString());
			if (filter != null)
			{
				result = filter.Decode(data);
			}
		}
		else if (filterItem is PdfArray)
		{
			PdfArray pdfArray = (PdfArray)filterItem;
			foreach (PdfItem item in pdfArray)
			{
				data = Decode(data, item);
			}
			result = data;
		}
		return result;
	}

	public static string DecodeToString(byte[] data, string filterName, FilterParms parms)
	{
		return GetFilter(filterName)?.DecodeToString(data, parms);
	}

	public static string DecodeToString(byte[] data, string filterName)
	{
		return GetFilter(filterName)?.DecodeToString(data, null);
	}
}
