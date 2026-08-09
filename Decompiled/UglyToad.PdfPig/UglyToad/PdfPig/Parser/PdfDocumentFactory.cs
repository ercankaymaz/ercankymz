using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.AcroForms;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.CrossReference;
using UglyToad.PdfPig.Encryption;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Fonts.SystemFonts;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Outline;
using UglyToad.PdfPig.Parser.FileStructure;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Parser;
using UglyToad.PdfPig.PdfFonts.Parser.Handlers;
using UglyToad.PdfPig.PdfFonts.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser;

internal static class PdfDocumentFactory
{
	public static PdfDocument Open(ReadOnlyMemory<byte> memory, ParsingOptions? options = null)
	{
		return Open(new MemoryInputBytes(memory), options);
	}

	public static PdfDocument Open(string filename, ParsingOptions? options = null)
	{
		if (!File.Exists(filename))
		{
			throw new InvalidOperationException("No file exists at: " + filename);
		}
		return Open(File.ReadAllBytes(filename), options);
	}

	internal static PdfDocument Open(Stream stream, ParsingOptions? options)
	{
		StreamInputBytes inputBytes;
		long position;
		if (stream != null && stream.CanRead && !stream.CanSeek)
		{
			MemoryStream memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			memoryStream.Position = 0L;
			inputBytes = new StreamInputBytes(memoryStream);
			position = memoryStream.Position;
		}
		else
		{
			inputBytes = new StreamInputBytes(stream, shouldDispose: false);
			position = stream.Position;
		}
		try
		{
			return Open(inputBytes, options);
		}
		catch (Exception innerException)
		{
			if (position != 0L)
			{
				throw new InvalidOperationException("Could not parse document due to an error, the input stream was not at position zero when provided to the Open method.", innerException);
			}
			throw;
		}
	}

	private static PdfDocument Open(IInputBytes inputBytes, ParsingOptions? options = null)
	{
		if (options == null)
		{
			options = new ParsingOptions
			{
				UseLenientParsing = true,
				ClipPaths = false,
				SkipMissingFonts = false
			};
		}
		CoreTokenScanner scanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding: true, ScannerScope.None, null, options.UseLenientParsing);
		List<string> list = new List<string>();
		if (options.Password != null)
		{
			list.Add(options.Password);
		}
		if (options.Passwords != null)
		{
			list.AddRange(options.Passwords.Where((string x) => x != null));
		}
		if (!list.Contains(string.Empty))
		{
			list.Add(string.Empty);
		}
		options.Passwords = list;
		return OpenDocument(inputBytes, scanner, options);
	}

	private static PdfDocument OpenDocument(IInputBytes inputBytes, ISeekableTokenScanner scanner, ParsingOptions parsingOptions)
	{
		FilterProviderWithLookup filterProvider = new FilterProviderWithLookup(parsingOptions.FilterProvider ?? DefaultFilterProvider.Instance);
		HeaderVersion headerVersion = FileHeaderParser.Parse(scanner, inputBytes, parsingOptions.UseLenientParsing, parsingOptions.Logger);
		FileHeaderOffset fileHeaderOffset = new FileHeaderOffset((int)headerVersion.OffsetInFile);
		FirstPassResults firstPassResults = FirstPassParser.Parse(fileHeaderOffset, inputBytes, scanner, parsingOptions.Logger);
		if (firstPassResults.Trailer == null)
		{
			throw new PdfDocumentFormatException("Could not find an xref trailer or stream dictionary in the input file.");
		}
		TrailerDictionary trailerDictionary = new TrailerDictionary(firstPassResults.Trailer, parsingOptions.UseLenientParsing);
		ObjectLocationProvider objectLocationProvider = new ObjectLocationProvider(firstPassResults.XrefOffsets, firstPassResults.BruteForceOffsets, inputBytes);
		PdfTokenScanner pdfTokenScanner = new PdfTokenScanner(inputBytes, objectLocationProvider, filterProvider, NoOpEncryptionHandler.Instance, fileHeaderOffset, parsingOptions);
		var (rootReference, dictionary) = ParseTrailer(trailerDictionary, parsingOptions.UseLenientParsing, pdfTokenScanner, out EncryptionDictionary encryptionDictionary);
		IEncryptionHandler encryptionHandler;
		if (encryptionDictionary == null)
		{
			IEncryptionHandler instance = NoOpEncryptionHandler.Instance;
			encryptionHandler = instance;
		}
		else
		{
			IEncryptionHandler instance = new EncryptionHandler(encryptionDictionary, trailerDictionary, parsingOptions.Passwords);
			encryptionHandler = instance;
		}
		IEncryptionHandler newHandler = encryptionHandler;
		pdfTokenScanner.UpdateEncryptionHandler(newHandler);
		CidFontFactory cidFontFactory = new CidFontFactory(parsingOptions.Logger, pdfTokenScanner, filterProvider);
		EncodingReader encodingReader = new EncodingReader(pdfTokenScanner);
		CMapLocalCache cMapLocalCache = new CMapLocalCache(filterProvider, pdfTokenScanner);
		Type0FontHandler type0FontHandler = new Type0FontHandler(cidFontFactory, pdfTokenScanner, cMapLocalCache, parsingOptions);
		Type1FontHandler type1FontHandler = new Type1FontHandler(pdfTokenScanner, filterProvider, encodingReader, cMapLocalCache, parsingOptions.UseLenientParsing);
		TrueTypeFontHandler trueTypeFontHandler = new TrueTypeFontHandler(parsingOptions.Logger, pdfTokenScanner, filterProvider, encodingReader, cMapLocalCache, SystemFontFinder.Instance, type1FontHandler);
		FontFactory fontFactory = new FontFactory(parsingOptions.Logger, type0FontHandler, trueTypeFontHandler, type1FontHandler, new Type3FontHandler(pdfTokenScanner, encodingReader, cMapLocalCache));
		ResourceStore resourceStore = new ResourceStore(pdfTokenScanner, fontFactory, filterProvider, parsingOptions);
		DocumentInformation information = DocumentInformationFactory.Create(pdfTokenScanner, trailerDictionary, parsingOptions.UseLenientParsing);
		PageFactory pageFactory = new PageFactory(pdfTokenScanner, resourceStore, filterProvider, new PageContentParser(ReflectionGraphicsStateOperationFactory.Instance, parsingOptions.UseLenientParsing), parsingOptions);
		Catalog catalog = CatalogFactory.Create(rootReference, dictionary, pdfTokenScanner, pageFactory, parsingOptions.Logger, parsingOptions.UseLenientParsing);
		AcroFormFactory acroFormFactory = new AcroFormFactory(pdfTokenScanner, filterProvider, firstPassResults.BruteForceOffsets ?? firstPassResults.XrefOffsets);
		BookmarksProvider bookmarksProvider = new BookmarksProvider(parsingOptions.Logger, pdfTokenScanner);
		return new PdfDocument(inputBytes, headerVersion, catalog, information, encryptionDictionary, pdfTokenScanner, filterProvider, acroFormFactory, bookmarksProvider, parsingOptions);
	}

	private static (IndirectReference, DictionaryToken) ParseTrailer(TrailerDictionary trailer, bool isLenientParsing, IPdfTokenScanner pdfTokenScanner, [NotNullWhen(true)] out EncryptionDictionary? encryptionDictionary)
	{
		encryptionDictionary = GetEncryptionDictionary(trailer, pdfTokenScanner);
		DictionaryToken dictionaryToken = DirectObjectFinder.Get<DictionaryToken>(trailer.Root, pdfTokenScanner);
		if (dictionaryToken == null)
		{
			throw new PdfDocumentFormatException("The root object in the trailer did not resolve to a readable dictionary.");
		}
		if (!dictionaryToken.ContainsKey(NameToken.Type) && isLenientParsing)
		{
			dictionaryToken = dictionaryToken.With(NameToken.Type, NameToken.Catalog);
		}
		return (trailer.Root, dictionaryToken);
	}

	private static EncryptionDictionary? GetEncryptionDictionary(TrailerDictionary trailer, IPdfTokenScanner pdfTokenScanner)
	{
		if (trailer.EncryptionToken == null)
		{
			return null;
		}
		if (!DirectObjectFinder.TryGet<DictionaryToken>(trailer.EncryptionToken, pdfTokenScanner, out DictionaryToken tokenResult))
		{
			if (DirectObjectFinder.TryGet<NullToken>(trailer.EncryptionToken, pdfTokenScanner, out NullToken _))
			{
				return null;
			}
			throw new PdfDocumentFormatException($"Unrecognized encryption token in trailer: {trailer.EncryptionToken}.");
		}
		return EncryptionDictionaryFactory.Read(tokenResult, pdfTokenScanner);
	}
}
