using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Writer.Fonts;

internal static class ToUnicodeCMapBuilder
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	private static ReadOnlySpan<byte> BeginToken => "begin"u8;

	private static ReadOnlySpan<byte> BeginCMapToken => "begincmap"u8;

	private static ReadOnlySpan<byte> DefToken => "def"u8;

	private static ReadOnlySpan<byte> DictToken => "dict"u8;

	private static ReadOnlySpan<byte> FindResourceToken => "findresource"u8;

	public static byte[] ConvertToCMapStream(IReadOnlyDictionary<char, byte> unicodeToCharacterCode)
	{
		using MemoryStream memoryStream = new MemoryStream();
		TokenWriter.WriteToken(NameToken.CidInit, memoryStream);
		TokenWriter.WriteToken(NameToken.ProcSet, memoryStream);
		memoryStream.WriteText(FindResourceToken, appendWhitespace: true);
		memoryStream.WriteText(BeginToken);
		memoryStream.WriteNewLine();
		memoryStream.WriteDouble(12.0);
		memoryStream.WriteWhiteSpace();
		memoryStream.WriteText(DictToken, appendWhitespace: true);
		memoryStream.WriteText(BeginToken);
		memoryStream.WriteNewLine();
		memoryStream.WriteText(BeginCMapToken);
		memoryStream.WriteNewLine();
		TokenWriter.WriteToken(NameToken.CidSystemInfo, memoryStream);
		DictionaryToken token = new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Registry,
				new StringToken("Adobe")
			},
			{
				NameToken.Ordering,
				new StringToken("UCS")
			},
			{
				NameToken.Supplement,
				new NumericToken(0)
			}
		});
		TokenWriter.WriteToken(token, memoryStream);
		memoryStream.WriteWhiteSpace();
		memoryStream.WriteText(DefToken);
		memoryStream.WriteNewLine();
		TokenWriter.WriteToken(NameToken.Cmapname, memoryStream);
		TokenWriter.WriteToken(NameToken.Create("Adobe-Identity-UCS"), memoryStream);
		memoryStream.WriteText(DefToken);
		memoryStream.WriteNewLine();
		TokenWriter.WriteToken(NameToken.CmapType, memoryStream);
		memoryStream.WriteNumberText(2, DefToken);
		memoryStream.WriteNumberText(1, "begincodespacerange"u8);
		TokenWriter tokenWriter = TokenWriter;
		object obj = global::_003CPrivateImplementationDetails_003E.B72F53758D812FBCAEF2F5BF9906F627EE6D5D5775EBF1DD62A9A10F7EDD8359_A1;
		if (obj == null)
		{
			obj = new char[2] { '0', '0' };
			global::_003CPrivateImplementationDetails_003E.B72F53758D812FBCAEF2F5BF9906F627EE6D5D5775EBF1DD62A9A10F7EDD8359_A1 = (char[])obj;
		}
		tokenWriter.WriteToken(new HexToken(new ReadOnlySpan<char>((char[])obj)), memoryStream);
		TokenWriter tokenWriter2 = TokenWriter;
		object obj2 = global::_003CPrivateImplementationDetails_003E.E9E52A7B2E3E5613A67FF690E25B83CD4E267492335F1A96E81F294D51607552_A1;
		if (obj2 == null)
		{
			obj2 = new char[2] { 'F', 'F' };
			global::_003CPrivateImplementationDetails_003E.E9E52A7B2E3E5613A67FF690E25B83CD4E267492335F1A96E81F294D51607552_A1 = (char[])obj2;
		}
		tokenWriter2.WriteToken(new HexToken(new ReadOnlySpan<char>((char[])obj2)), memoryStream);
		memoryStream.WriteNewLine();
		memoryStream.WriteText("endcodespacerange"u8);
		memoryStream.WriteNewLine();
		memoryStream.WriteNumberText(unicodeToCharacterCode.Count, "beginbfchar"u8);
		foreach (KeyValuePair<char, byte> item in unicodeToCharacterCode)
		{
			char key = item.Key;
			byte b = (byte)key;
			byte b2 = (byte)((int)key >> 8);
			string text = Hex.GetString(new ReadOnlySpan<byte>(new byte[1] { item.Value }));
			string text2 = Hex.GetString(new ReadOnlySpan<byte>(new byte[2] { b2, b }));
			TokenWriter.WriteToken(new HexToken(text.AsSpan()), memoryStream);
			TokenWriter.WriteToken(new HexToken(text2.AsSpan()), memoryStream);
			memoryStream.WriteNewLine();
		}
		memoryStream.WriteText("endbfchar"u8);
		memoryStream.WriteNewLine();
		memoryStream.WriteText("endcmap"u8);
		memoryStream.WriteNewLine();
		memoryStream.WriteText("CMapName currentdict /CMap defineresource pop"u8);
		memoryStream.WriteNewLine();
		memoryStream.WriteText("end"u8);
		memoryStream.WriteNewLine();
		memoryStream.WriteText("end"u8);
		memoryStream.WriteNewLine();
		return memoryStream.ToArray();
	}
}
