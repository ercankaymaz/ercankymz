using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.PdfFonts.Parser.Handlers;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts;

internal class FontFactory : IFontFactory
{
	private readonly ILog log;

	private readonly IReadOnlyDictionary<NameToken, IFontHandler> handlers;

	public FontFactory(ILog log, Type0FontHandler type0FontHandler, TrueTypeFontHandler trueTypeFontHandler, Type1FontHandler type1FontHandler, Type3FontHandler type3FontHandler)
	{
		this.log = log;
		handlers = new Dictionary<NameToken, IFontHandler>
		{
			{
				NameToken.Type0,
				type0FontHandler
			},
			{
				NameToken.TrueType,
				trueTypeFontHandler
			},
			{
				NameToken.Type1,
				type1FontHandler
			},
			{
				NameToken.MmType1,
				type1FontHandler
			},
			{
				NameToken.Type3,
				type3FontHandler
			}
		};
	}

	public IFont Get(DictionaryToken dictionary)
	{
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.Type);
		if (nameOrDefault != null && !nameOrDefault.Equals(NameToken.Font))
		{
			string message = "The font dictionary did not have type 'Font'. " + dictionary;
			log?.Error(message);
		}
		NameToken nameOrDefault2 = dictionary.GetNameOrDefault(NameToken.Subtype);
		if (nameOrDefault2 != null && handlers.TryGetValue(nameOrDefault2, out IFontHandler value))
		{
			return value.Generate(dictionary);
		}
		NameToken[] array = new NameToken[2]
		{
			NameToken.Type1,
			NameToken.TrueType
		};
		foreach (NameToken nameToken in array)
		{
			if (handlers.TryGetValue(nameToken, out value))
			{
				try
				{
					return value.Generate(dictionary);
				}
				catch (Exception ex)
				{
					log?.Error($"Tried to parse font as fallback type: {nameToken}", ex);
				}
			}
		}
		throw new NotImplementedException($"Parsing not implemented for fonts of type: {nameOrDefault2}, please submit a pull request or an issue.");
	}
}
