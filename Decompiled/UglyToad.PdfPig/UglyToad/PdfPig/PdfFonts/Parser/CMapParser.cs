using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser;

internal sealed class CMapParser
{
	private static readonly BaseFontRangeParser BaseFontRangeParser = new BaseFontRangeParser();

	private static readonly BaseFontCharacterParser BaseFontCharacterParser = new BaseFontCharacterParser();

	private static readonly CidRangeParser CidRangeParser = new CidRangeParser();

	private static readonly CidFontNameParser CidFontNameParser = new CidFontNameParser();

	private static readonly CodespaceRangeParser CodespaceRangeParser = new CodespaceRangeParser();

	private static readonly CidCharacterParser CidCharacterParser = new CidCharacterParser();

	public CMap Parse(IInputBytes inputBytes)
	{
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding: false, ScannerScope.None, new Dictionary<NameToken, IReadOnlyList<NameToken>> { 
		{
			NameToken.CidSystemInfo,
			new NameToken[3]
			{
				NameToken.Registry,
				NameToken.Ordering,
				NameToken.Supplement
			}
		} });
		CharacterMapBuilder characterMapBuilder = new CharacterMapBuilder();
		IToken token = null;
		while (coreTokenScanner.MoveNext())
		{
			IToken currentToken = coreTokenScanner.CurrentToken;
			if (currentToken is OperatorToken operatorToken)
			{
				switch (operatorToken.Data)
				{
				case "usecmap":
				{
					if (token is NameToken nameToken && TryParseExternal(nameToken.Data, out CMap result))
					{
						characterMapBuilder.UseCMap(result);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding external cmap call: " + token);
				}
				case "begincodespacerange":
					if (token is NumericToken numeric3)
					{
						CodespaceRangeParser.Parse(numeric3, coreTokenScanner, characterMapBuilder);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding start of codespace range: " + token);
				case "beginbfchar":
					if (token is NumericToken numeric4)
					{
						BaseFontCharacterParser.Parse(numeric4, coreTokenScanner, characterMapBuilder);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding start of base font characters: " + token);
				case "beginbfrange":
					if (token is NumericToken numberOfOperations)
					{
						BaseFontRangeParser.Parse(numberOfOperations, coreTokenScanner, characterMapBuilder);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding start of base font character ranges: " + token);
				case "begincidchar":
					if (token is NumericToken numeric2)
					{
						CidCharacterParser.Parse(numeric2, coreTokenScanner, characterMapBuilder);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding start of Cid character mapping: " + token);
				case "begincidrange":
					if (token is NumericToken numeric)
					{
						CidRangeParser.Parse(numeric, coreTokenScanner, characterMapBuilder);
						break;
					}
					throw new InvalidOperationException("Unexpected token preceding start of Cid ranges: " + token);
				}
			}
			else if (currentToken is NameToken nameToken2)
			{
				CidFontNameParser.Parse(nameToken2, coreTokenScanner, characterMapBuilder);
			}
			token = currentToken;
		}
		return characterMapBuilder.Build();
	}

	public bool TryParseExternal(string name, [NotNullWhen(true)] out CMap? result)
	{
		result = null;
		string text = typeof(CMapParser).Assembly.GetManifestResourceNames().FirstOrDefault((string x) => x.EndsWith("CMap." + name, StringComparison.InvariantCultureIgnoreCase));
		if (text == null)
		{
			return false;
		}
		ReadOnlyMemory<byte> memory;
		using (Stream stream = typeof(CMapParser).Assembly.GetManifestResourceStream(text))
		{
			if (stream == null)
			{
				return false;
			}
			using MemoryStream memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			memory = memoryStream.AsMemory();
		}
		result = Parse(new MemoryInputBytes(memory));
		return true;
	}
}
