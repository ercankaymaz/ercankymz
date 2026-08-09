using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

internal class ResourceStore : IResourceStore
{
	private readonly IPdfTokenScanner scanner;

	private readonly IFontFactory fontFactory;

	private readonly ILookupFilterProvider filterProvider;

	private readonly ParsingOptions parsingOptions;

	private readonly Dictionary<IndirectReference, IFont> loadedFonts = new Dictionary<IndirectReference, IFont>();

	private readonly Dictionary<NameToken, IFont> loadedDirectFonts = new Dictionary<NameToken, IFont>();

	private readonly StackDictionary<NameToken, IndirectReference> currentFontState = new StackDictionary<NameToken, IndirectReference>();

	private readonly StackDictionary<NameToken, IndirectReference> currentXObjectState = new StackDictionary<NameToken, IndirectReference>();

	private readonly Dictionary<NameToken, DictionaryToken> extendedGraphicsStates = new Dictionary<NameToken, DictionaryToken>();

	private readonly StackDictionary<NameToken, ResourceColorSpace> namedColorSpaces = new StackDictionary<NameToken, ResourceColorSpace>();

	private readonly Dictionary<NameToken, ColorSpaceDetails> loadedNamedColorSpaceDetails = new Dictionary<NameToken, ColorSpaceDetails>();

	private readonly Dictionary<NameToken, DictionaryToken> markedContentProperties = new Dictionary<NameToken, DictionaryToken>();

	private readonly Dictionary<NameToken, Shading> shadingsProperties = new Dictionary<NameToken, Shading>();

	private readonly Dictionary<NameToken, PatternColor> patternsProperties = new Dictionary<NameToken, PatternColor>();

	private (NameToken? name, IFont? font) lastLoadedFont;

	public ResourceStore(IPdfTokenScanner scanner, IFontFactory fontFactory, ILookupFilterProvider filterProvider, ParsingOptions parsingOptions)
	{
		this.scanner = scanner;
		this.fontFactory = fontFactory;
		this.filterProvider = filterProvider;
		this.parsingOptions = parsingOptions;
	}

	public void LoadResourceDictionary(DictionaryToken resourceDictionary)
	{
		lastLoadedFont = (name: null, font: null);
		loadedNamedColorSpaceDetails.Clear();
		namedColorSpaces.Push();
		currentFontState.Push();
		currentXObjectState.Push();
		if (resourceDictionary.TryGet(NameToken.Font, out var token))
		{
			DictionaryToken fontDictionary = DirectObjectFinder.Get<DictionaryToken>(token, scanner);
			LoadFontDictionary(fontDictionary);
		}
		if (resourceDictionary.TryGet(NameToken.Xobject, out var token2))
		{
			foreach (KeyValuePair<string, IToken> datum in DirectObjectFinder.Get<DictionaryToken>(token2, scanner).Data)
			{
				if (!(datum.Value is NullToken))
				{
					if (!(datum.Value is IndirectReferenceToken indirectReferenceToken))
					{
						throw new InvalidOperationException($"Expected the XObject dictionary value for key /{datum.Key} to be an indirect reference, instead got: {datum.Value}.");
					}
					currentXObjectState[NameToken.Create(datum.Key)] = indirectReferenceToken.Data;
				}
			}
		}
		if (resourceDictionary.TryGet<DictionaryToken>(NameToken.ExtGState, scanner, out DictionaryToken token3))
		{
			foreach (KeyValuePair<string, IToken> datum2 in token3.Data)
			{
				NameToken key = NameToken.Create(datum2.Key);
				DictionaryToken value = DirectObjectFinder.Get<DictionaryToken>(datum2.Value, scanner);
				extendedGraphicsStates[key] = value;
			}
		}
		if (resourceDictionary.TryGet<DictionaryToken>(NameToken.ColorSpace, scanner, out DictionaryToken token4))
		{
			foreach (KeyValuePair<string, IToken> datum3 in token4.Data)
			{
				NameToken key2 = NameToken.Create(datum3.Key);
				ArrayToken tokenResult2;
				if (DirectObjectFinder.TryGet<NameToken>(datum3.Value, scanner, out NameToken tokenResult))
				{
					namedColorSpaces[key2] = new ResourceColorSpace(tokenResult);
				}
				else if (DirectObjectFinder.TryGet<ArrayToken>(datum3.Value, scanner, out tokenResult2))
				{
					if (tokenResult2.Length == 0)
					{
						throw new PdfDocumentFormatException($"Empty ColorSpace array encountered in page resource dictionary: {resourceDictionary}.");
					}
					if (!(tokenResult2.Data[0] is NameToken name))
					{
						throw new PdfDocumentFormatException($"Invalid ColorSpace array encountered in page resource dictionary: {tokenResult2}.");
					}
					namedColorSpaces[key2] = new ResourceColorSpace(name, tokenResult2);
				}
				else
				{
					if (!parsingOptions.UseLenientParsing || !DirectObjectFinder.TryGet<DictionaryToken>(datum3.Value, scanner, out DictionaryToken tokenResult3) || !tokenResult3.TryGet<NameToken>(NameToken.ColorSpace, scanner, out NameToken token5))
					{
						throw new PdfDocumentFormatException($"Invalid ColorSpace token encountered in page resource dictionary: {datum3.Value}.");
					}
					namedColorSpaces[key2] = new ResourceColorSpace(token5);
				}
			}
		}
		if (resourceDictionary.TryGet<DictionaryToken>(NameToken.Pattern, scanner, out DictionaryToken token6))
		{
			foreach (KeyValuePair<string, IToken> datum4 in token6.Data)
			{
				NameToken key3 = NameToken.Create(datum4.Key);
				patternsProperties[key3] = PatternParser.Create(datum4.Value, scanner, this, filterProvider);
			}
		}
		if (resourceDictionary.TryGet<DictionaryToken>(NameToken.Properties, scanner, out DictionaryToken token7))
		{
			foreach (KeyValuePair<string, IToken> datum5 in token7.Data)
			{
				NameToken key4 = NameToken.Create(datum5.Key);
				if (DirectObjectFinder.TryGet<DictionaryToken>(datum5.Value, scanner, out DictionaryToken tokenResult4))
				{
					markedContentProperties[key4] = tokenResult4;
				}
			}
		}
		if (!resourceDictionary.TryGet<DictionaryToken>(NameToken.Shading, scanner, out DictionaryToken token8))
		{
			return;
		}
		foreach (KeyValuePair<string, IToken> datum6 in token8.Data)
		{
			NameToken key5 = NameToken.Create(datum6.Key);
			if (DirectObjectFinder.TryGet<DictionaryToken>(datum6.Value, scanner, out DictionaryToken tokenResult5))
			{
				shadingsProperties[key5] = ShadingParser.Create(tokenResult5, scanner, this, filterProvider);
				continue;
			}
			if (DirectObjectFinder.TryGet<StreamToken>(datum6.Value, scanner, out StreamToken tokenResult6))
			{
				shadingsProperties[key5] = ShadingParser.Create(tokenResult6, scanner, this, filterProvider);
				continue;
			}
			throw new NotImplementedException("Shading");
		}
	}

	public void UnloadResourceDictionary()
	{
		lastLoadedFont = (name: null, font: null);
		loadedNamedColorSpaceDetails.Clear();
		currentFontState.Pop();
		currentXObjectState.Pop();
		namedColorSpaces.Pop();
	}

	private void LoadFontDictionary(DictionaryToken fontDictionary)
	{
		lastLoadedFont = (name: null, font: null);
		foreach (KeyValuePair<string, IToken> datum in fontDictionary.Data)
		{
			if (datum.Value is IndirectReferenceToken { Data: var data } indirectReferenceToken)
			{
				currentFontState[NameToken.Create(datum.Key)] = data;
				if (loadedFonts.ContainsKey(data))
				{
					continue;
				}
				DictionaryToken dictionaryToken = DirectObjectFinder.Get<DictionaryToken>(indirectReferenceToken, scanner);
				if (dictionaryToken == null)
				{
					continue;
				}
				try
				{
					loadedFonts[data] = fontFactory.Get(dictionaryToken);
				}
				catch
				{
					if (!parsingOptions.SkipMissingFonts)
					{
						throw;
					}
				}
			}
			else if (datum.Value is DictionaryToken dictionary)
			{
				loadedDirectFonts[NameToken.Create(datum.Key)] = fontFactory.Get(dictionary);
			}
		}
	}

	public IFont? GetFont(NameToken name)
	{
		if (lastLoadedFont.name == name)
		{
			return lastLoadedFont.font;
		}
		IFont value;
		if (currentFontState.TryGetValue(name, out var result))
		{
			loadedFonts.TryGetValue(result, out value);
		}
		else if (!loadedDirectFonts.TryGetValue(name, out value))
		{
			return null;
		}
		lastLoadedFont = (name: name, font: value);
		return value;
	}

	public IFont GetFontDirectly(IndirectReferenceToken fontReferenceToken)
	{
		lastLoadedFont = (name: null, font: null);
		if (!DirectObjectFinder.TryGet<DictionaryToken>(fontReferenceToken, scanner, out DictionaryToken tokenResult))
		{
			throw new PdfDocumentFormatException($"The requested font reference token {fontReferenceToken} wasn't a font.");
		}
		return fontFactory.Get(tokenResult);
	}

	public bool TryGetNamedColorSpace(NameToken? name, out ResourceColorSpace namedToken)
	{
		namedToken = default(ResourceColorSpace);
		if ((object)name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (!namedColorSpaces.TryGetValue(name, out var result))
		{
			return false;
		}
		namedToken = result;
		return true;
	}

	public ColorSpaceDetails GetColorSpaceDetails(NameToken? name, DictionaryToken? dictionary)
	{
		if (dictionary == null)
		{
			dictionary = new DictionaryToken(new Dictionary<NameToken, IToken>());
		}
		if ((object)name == null)
		{
			return ColorSpaceDetailsParser.GetColorSpaceDetails(null, dictionary, scanner, this, filterProvider);
		}
		if (name.TryMapToColorSpace(out var colorspace))
		{
			return ColorSpaceDetailsParser.GetColorSpaceDetails(colorspace, dictionary, scanner, this, filterProvider);
		}
		if (loadedNamedColorSpaceDetails.TryGetValue(name, out ColorSpaceDetails value))
		{
			return value;
		}
		if (TryGetNamedColorSpace(name, out var namedToken) && namedToken.Name.TryMapToColorSpace(out var colorspace2))
		{
			if (namedToken.Data == null)
			{
				return ColorSpaceDetailsParser.GetColorSpaceDetails(colorspace2, dictionary, scanner, this, filterProvider);
			}
			if (namedToken.Data is ArrayToken value2)
			{
				ColorSpaceDetails colorSpaceDetails = ColorSpaceDetailsParser.GetColorSpaceDetails(colorspace2, dictionary.With(NameToken.ColorSpace, value2), scanner, this, filterProvider);
				loadedNamedColorSpaceDetails[name] = colorSpaceDetails;
				return colorSpaceDetails;
			}
		}
		throw new InvalidOperationException($"Could not find color space for token '{name}'.");
	}

	public bool TryGetXObject(NameToken name, [NotNullWhen(true)] out StreamToken? stream)
	{
		stream = null;
		if (!currentXObjectState.TryGetValue(name, out var result))
		{
			return false;
		}
		return DirectObjectFinder.TryGet<StreamToken>(new IndirectReferenceToken(result), scanner, out stream);
	}

	public DictionaryToken? GetExtendedGraphicsStateDictionary(NameToken name)
	{
		if (parsingOptions.UseLenientParsing && !extendedGraphicsStates.ContainsKey(name))
		{
			parsingOptions.Logger.Error($"The graphic state dictionary does not contain the key '{name}'.");
			return null;
		}
		return extendedGraphicsStates[name];
	}

	public DictionaryToken? GetMarkedContentPropertiesDictionary(NameToken name)
	{
		if (!markedContentProperties.TryGetValue(name, out DictionaryToken value))
		{
			return null;
		}
		return value;
	}

	public Shading GetShading(NameToken name)
	{
		return shadingsProperties[name];
	}

	public IReadOnlyDictionary<NameToken, PatternColor> GetPatterns()
	{
		return patternsProperties;
	}
}
