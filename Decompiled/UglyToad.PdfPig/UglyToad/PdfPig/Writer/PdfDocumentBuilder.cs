using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Outline;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer.Fonts;

namespace UglyToad.PdfPig.Writer;

public class PdfDocumentBuilder : IDisposable
{
	private sealed class PageInfo(DictionaryToken page, IReadOnlyList<DictionaryToken> parents)
	{
		public DictionaryToken Page { get; } = page;

		public IReadOnlyList<DictionaryToken> Parents { get; } = parents;
	}

	internal class FontStored
	{
		public AddedFont FontKey { get; }

		public IWritingFont FontProgram { get; }

		public FontStored(AddedFont fontKey, IWritingFont fontProgram)
		{
			FontKey = fontKey ?? throw new ArgumentNullException("fontKey");
			FontProgram = fontProgram ?? throw new ArgumentNullException("fontProgram");
		}
	}

	public class AddedFont
	{
		internal Guid Id { get; }

		internal IndirectReferenceToken Reference { get; }

		internal AddedFont(Guid id, IndirectReferenceToken reference)
		{
			Id = id;
			Reference = reference;
		}
	}

	public class DocumentInformationBuilder
	{
		public Dictionary<string, string> CustomMetadata { get; } = new Dictionary<string, string>();

		public string? Title { get; set; }

		public string? Author { get; set; }

		public string? Subject { get; set; }

		public string? Keywords { get; set; }

		public string? Creator { get; set; }

		public string Producer { get; set; } = "PdfPig";

		public string? CreationDate { get; set; }

		public string? ModifiedDate { get; set; }

		internal Dictionary<NameToken, IToken> ToDictionary()
		{
			Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
			foreach (KeyValuePair<string, string> customMetadatum in CustomMetadata)
			{
				if (customMetadatum.Key != null && customMetadatum.Value != null)
				{
					dictionary[NameToken.Create(customMetadatum.Key)] = new StringToken(customMetadatum.Value);
				}
			}
			if (Title != null)
			{
				dictionary[NameToken.Title] = new StringToken(Title);
			}
			if (Author != null)
			{
				dictionary[NameToken.Author] = new StringToken(Author);
			}
			if (Subject != null)
			{
				dictionary[NameToken.Subject] = new StringToken(Subject);
			}
			if (Keywords != null)
			{
				dictionary[NameToken.Keywords] = new StringToken(Keywords);
			}
			if (Creator != null)
			{
				dictionary[NameToken.Creator] = new StringToken(Creator);
			}
			if (Producer != null)
			{
				dictionary[NameToken.Producer] = new StringToken(Producer);
			}
			if (CreationDate != null)
			{
				dictionary[NameToken.CreationDate] = new StringToken(CreationDate);
			}
			if (ModifiedDate != null)
			{
				dictionary[NameToken.ModDate] = new StringToken(ModifiedDate);
			}
			return dictionary;
		}
	}

	public class AddPageOptions
	{
		public bool KeepAnnotations { get; set; } = true;

		public Func<PdfAction, PdfAction?>? CopyLinkFunc { get; set; }
	}

	private readonly IPdfStreamWriter context;

	private readonly Dictionary<int, PdfPageBuilder> pages = new Dictionary<int, PdfPageBuilder>();

	private readonly Dictionary<Guid, FontStored> fonts = new Dictionary<Guid, FontStored>();

	private bool completed;

	private int fontId;

	private double version = 1.7;

	private static readonly ArrayToken DefaultProcSet = new ArrayToken(new List<NameToken>
	{
		NameToken.Create("PDF"),
		NameToken.Text,
		NameToken.ImageB,
		NameToken.ImageC,
		NameToken.ImageI
	});

	private readonly ConditionalWeakTable<IPdfTokenScanner, Dictionary<IndirectReference, IndirectReferenceToken>> existingCopies = new ConditionalWeakTable<IPdfTokenScanner, Dictionary<IndirectReference, IndirectReferenceToken>>();

	private readonly ConditionalWeakTable<PdfDocument, Dictionary<int, PageInfo>> existingTrees = new ConditionalWeakTable<PdfDocument, Dictionary<int, PageInfo>>();

	public PdfAStandard ArchiveStandard { get; set; }

	public bool IncludeDocumentInformation { get; set; } = true;

	public DocumentInformationBuilder DocumentInformation { get; set; } = new DocumentInformationBuilder();

	public Bookmarks? Bookmarks { get; set; }

	public XDocument? XmpMetadata { get; set; }

	public IReadOnlyDictionary<int, PdfPageBuilder> Pages => pages;

	internal IReadOnlyDictionary<Guid, FontStored> Fonts => fonts;

	public PdfDocumentBuilder()
	{
		context = new PdfStreamWriter(new MemoryStream(), disposeStream: true, null, delegate(double x)
		{
			version = x;
		});
		context.InitializePdf(1.7);
	}

	public PdfDocumentBuilder(double version)
	{
		context = new PdfStreamWriter(new MemoryStream(), disposeStream: true, null, delegate(double x)
		{
			version = x;
		});
		context.InitializePdf(version);
	}

	public PdfDocumentBuilder(Stream stream, bool disposeStream = false, PdfWriterType type = PdfWriterType.Default, double version = 1.7, ITokenWriter? tokenWriter = null)
	{
		if (type == PdfWriterType.ObjectInMemoryDedup)
		{
			context = new PdfDedupStreamWriter(stream, disposeStream, tokenWriter, delegate(double x)
			{
				version = x;
			});
		}
		else
		{
			context = new PdfStreamWriter(stream, disposeStream, tokenWriter, delegate(double x)
			{
				version = x;
			});
		}
		context.InitializePdf(version);
	}

	public bool CanUseTrueTypeFont(ReadOnlyMemory<byte> fontFileBytes, out IReadOnlyList<string> reasons)
	{
		List<string> list = (List<string>)(reasons = new List<string>());
		try
		{
			if (fontFileBytes.IsEmpty)
			{
				list.Add("Provided bytes were empty.");
				return false;
			}
			TrueTypeFont trueTypeFont = TrueTypeFontParser.Parse(new TrueTypeDataBytes(new MemoryInputBytes(fontFileBytes)));
			if (trueTypeFont.TableRegister.CMapTable == null)
			{
				list.Add("The provided font did not contain a cmap table, used to map character codes to glyph codes.");
				return false;
			}
			if (trueTypeFont.TableRegister.Os2Table == null)
			{
				list.Add("The provided font did not contain an OS/2 table, used to fill in the font descriptor dictionary.");
				return false;
			}
			if (trueTypeFont.TableRegister.PostScriptTable == null)
			{
				list.Add("The provided font did not contain a post PostScript table, used to map character codes to glyph codes.");
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			list.Add(ex.Message);
			return false;
		}
	}

	public AddedFont AddTrueTypeFont(ReadOnlyMemory<byte> fontFileBytes)
	{
		try
		{
			TrueTypeFont font = TrueTypeFontParser.Parse(new TrueTypeDataBytes(new MemoryInputBytes(fontFileBytes)));
			Guid guid = Guid.NewGuid();
			AddedFont addedFont = new AddedFont(guid, context.ReserveObjectNumber());
			fonts[guid] = new FontStored(addedFont, new TrueTypeWritingFont(font, fontFileBytes));
			return addedFont;
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Writing only supports TrueType fonts, please provide a valid TrueType font.", innerException);
		}
	}

	public AddedFont AddStandard14Font(Standard14Font type)
	{
		if (ArchiveStandard != PdfAStandard.None)
		{
			throw new NotSupportedException(string.Format("PDF/A {0} requires the font to be embedded in the file, only {1} is supported.", ArchiveStandard, "AddTrueTypeFont"));
		}
		Guid guid = Guid.NewGuid();
		NameToken.Create($"F{fontId++}");
		AddedFont addedFont = new AddedFont(guid, context.ReserveObjectNumber());
		fonts[guid] = new FontStored(addedFont, new Standard14WritingFont(Standard14.GetAdobeFontMetrics(type)));
		return addedFont;
	}

	internal IndirectReferenceToken AddImage(DictionaryToken dictionary, byte[] bytes)
	{
		StreamToken token = new StreamToken(dictionary, bytes);
		return context.WriteToken(token);
	}

	public PdfPageBuilder AddPage(double width, double height)
	{
		if (width < 0.0)
		{
			throw new ArgumentOutOfRangeException("width", $"Width cannot be negative, got: {width}.");
		}
		if (height < 0.0)
		{
			throw new ArgumentOutOfRangeException("height", $"Height cannot be negative, got: {height}.");
		}
		PdfPageBuilder pdfPageBuilder = null;
		for (int i = 0; i < pages.Count; i++)
		{
			if (!pages.ContainsKey(i + 1))
			{
				pdfPageBuilder = new PdfPageBuilder(i + 1, this);
				break;
			}
		}
		if (pdfPageBuilder == null)
		{
			pdfPageBuilder = new PdfPageBuilder(pages.Count + 1, this);
		}
		pdfPageBuilder.PageSize = new PdfRectangle(0.0, 0.0, width, height);
		pages[pdfPageBuilder.PageNumber] = pdfPageBuilder;
		return pdfPageBuilder;
	}

	public PdfPageBuilder AddPage(PageSize size, bool isPortrait = true)
	{
		if (size == PageSize.Custom)
		{
			throw new ArgumentException("Cannot use $Custom for $AddPage using the $PageSize enum, call the overload with width and height instead.", "size");
		}
		if (!size.TryGetPdfRectangle(out var rectangle))
		{
			throw new ArgumentException($"No rectangle found for Page Size {size}.");
		}
		if (!isPortrait)
		{
			return AddPage(rectangle.Height, rectangle.Width);
		}
		return AddPage(rectangle.Width, rectangle.Height);
	}

	internal IToken CopyToken(IPdfTokenScanner source, IToken token)
	{
		if (!existingCopies.TryGetValue(source, out Dictionary<IndirectReference, IndirectReferenceToken> value))
		{
			value = new Dictionary<IndirectReference, IndirectReferenceToken>();
			existingCopies.Add(source, value);
		}
		return WriterUtil.CopyToken(context, token, source, value);
	}

	public PdfPageBuilder AddPage(PdfDocument document, int pageNumber)
	{
		return AddPage(document, pageNumber, new AddPageOptions());
	}

	public PdfPageBuilder AddPage(PdfDocument document, int pageNumber, AddPageOptions options)
	{
		if (!existingCopies.TryGetValue(document.Structure.TokenScanner, out Dictionary<IndirectReference, IndirectReferenceToken> refs))
		{
			refs = new Dictionary<IndirectReference, IndirectReferenceToken>();
			existingCopies.Add(document.Structure.TokenScanner, refs);
		}
		if (!existingTrees.TryGetValue(document, out Dictionary<int, PageInfo> value))
		{
			value = new Dictionary<int, PageInfo>();
			int num = 1;
			foreach (var item5 in WriterUtil.WalkTree(document.Structure.Catalog.Pages.PageTree))
			{
				DictionaryToken item = item5.Item1;
				IReadOnlyList<DictionaryToken> item2 = item5.Item2;
				value[num] = new PageInfo(item, item2);
				num++;
			}
			existingTrees.Add(document, value);
		}
		if (!value.TryGetValue(pageNumber, out var value2))
		{
			throw new KeyNotFoundException($"Page {pageNumber} was not found in the source document.");
		}
		Page page = document.GetPage(pageNumber);
		PageContentParser pageContentParser = new PageContentParser(ReflectionGraphicsStateOperationFactory.Instance, useLenientParsing: true);
		List<PdfPageBuilder.CopiedContentStream> list = new List<PdfPageBuilder.CopiedContentStream>();
		if (value2.Page.TryGet(NameToken.Contents, out var token))
		{
			bool attemptDeduplication = context.AttemptDeduplication;
			context.AttemptDeduplication = false;
			context.WritingPageContents = true;
			List<IndirectReferenceToken> list2 = new List<IndirectReferenceToken>();
			if (token is ArrayToken arrayToken)
			{
				foreach (IToken datum in arrayToken.Data)
				{
					if (datum is IndirectReferenceToken item3)
					{
						list2.Add(item3);
					}
				}
			}
			else if (token is IndirectReferenceToken item4)
			{
				list2.Add(item4);
			}
			foreach (IndirectReferenceToken item6 in list2)
			{
				TransformationMatrix? globalTransform = null;
				try
				{
					if (DirectObjectFinder.TryGet<StreamToken>(item6, document.Structure.TokenScanner, out StreamToken tokenResult))
					{
						Memory<byte> memory = tokenResult.Decode(DefaultFilterProvider.Instance);
						globalTransform = PdfContentTransformationReader.GetGlobalTransform(pageContentParser.Parse(0, new MemoryInputBytes(memory), new NoOpLog()));
					}
				}
				catch
				{
				}
				IndirectReferenceToken indirectReferenceToken = (IndirectReferenceToken)WriterUtil.CopyToken(context, item6, document.Structure.TokenScanner, refs);
				list.Add(new PdfPageBuilder.CopiedContentStream(indirectReferenceToken, globalTransform));
			}
			context.AttemptDeduplication = attemptDeduplication;
			context.WritingPageContents = false;
		}
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		List<(DictionaryToken token, PdfAction action)> links = new List<(DictionaryToken, PdfAction)>();
		Dictionary<NameToken, IToken> dictionary2 = new Dictionary<NameToken, IToken>();
		foreach (DictionaryToken parent in value2.Parents)
		{
			if (parent.TryGet(NameToken.Resources, out var token2))
			{
				CopyResourceDict(token2, dictionary2);
			}
			if (parent.TryGet(NameToken.MediaBox, out var token3))
			{
				dictionary[NameToken.MediaBox] = WriterUtil.CopyToken(context, token3, document.Structure.TokenScanner, refs);
			}
			if (parent.TryGet(NameToken.CropBox, out var token4))
			{
				dictionary[NameToken.CropBox] = WriterUtil.CopyToken(context, token4, document.Structure.TokenScanner, refs);
			}
			if (parent.TryGet(NameToken.Rotate, out var token5))
			{
				dictionary[NameToken.Rotate] = WriterUtil.CopyToken(context, token5, document.Structure.TokenScanner, refs);
			}
		}
		foreach (KeyValuePair<string, IToken> datum2 in value2.Page.Data)
		{
			if (datum2.Key == NameToken.Contents || datum2.Key == NameToken.Parent || datum2.Key == NameToken.Type)
			{
				continue;
			}
			if (datum2.Key == NameToken.Resources)
			{
				CopyResourceDict(datum2.Value, dictionary2);
			}
			else if (datum2.Key == NameToken.Annots)
			{
				if (options.KeepAnnotations)
				{
					IReadOnlyList<IToken> data = CopyAnnotationsFromPageSource(datum2.Value, document.Structure.TokenScanner, refs, page, options.CopyLinkFunc, delegate((DictionaryToken, PdfAction) x)
					{
						links.Add(x);
					});
					dictionary[NameToken.Annots] = new ArrayToken(data);
				}
			}
			else
			{
				dictionary[NameToken.Create(datum2.Key)] = WriterUtil.CopyToken(context, datum2.Value, document.Structure.TokenScanner, refs);
			}
		}
		dictionary[NameToken.Resources] = new DictionaryToken(dictionary2);
		PdfPageBuilder pdfPageBuilder = new PdfPageBuilder(pages.Count + 1, this, list, dictionary, links);
		pages[pdfPageBuilder.PageNumber] = pdfPageBuilder;
		return pdfPageBuilder;
		void CopyResourceDict(IToken token6, Dictionary<NameToken, IToken> destinationDict)
		{
			DictionaryToken dictionaryToken = GetRemoteDict(token6);
			if (dictionaryToken == null)
			{
				return;
			}
			foreach (KeyValuePair<string, IToken> datum3 in dictionaryToken.Data)
			{
				NameToken key = NameToken.Create(datum3.Key);
				if (!destinationDict.ContainsKey(key))
				{
					if (datum3.Value is IndirectReferenceToken indirectReferenceToken2)
					{
						ObjectToken objectToken = document.Structure.TokenScanner.Get(indirectReferenceToken2.Data);
						if (objectToken.Data is StreamToken)
						{
							destinationDict[key] = WriterUtil.CopyToken(context, datum3.Value, document.Structure.TokenScanner, refs);
						}
						else
						{
							destinationDict[key] = WriterUtil.CopyToken(context, objectToken.Data, document.Structure.TokenScanner, refs);
						}
					}
					else
					{
						destinationDict[key] = WriterUtil.CopyToken(context, datum3.Value, document.Structure.TokenScanner, refs);
					}
				}
				else
				{
					DictionaryToken dictionaryToken2 = GetRemoteDict(datum3.Value);
					if (!(destinationDict[key] is DictionaryToken dictionaryToken3) || dictionaryToken2 == null)
					{
						if (datum3.Value is IndirectReferenceToken indirectReferenceToken3)
						{
							destinationDict[key] = WriterUtil.CopyToken(context, document.Structure.TokenScanner.Get(indirectReferenceToken3.Data).Data, document.Structure.TokenScanner, refs);
						}
						else
						{
							destinationDict[key] = WriterUtil.CopyToken(context, datum3.Value, document.Structure.TokenScanner, refs);
						}
					}
					else
					{
						Dictionary<NameToken, IToken> dictionary3 = new Dictionary<NameToken, IToken>();
						foreach (KeyValuePair<string, IToken> datum4 in dictionaryToken3.Data)
						{
							dictionary3[NameToken.Create(datum4.Key)] = datum4.Value;
						}
						foreach (KeyValuePair<string, IToken> datum5 in dictionaryToken2.Data)
						{
							dictionary3[NameToken.Create(datum5.Key)] = WriterUtil.CopyToken(context, datum5.Value, document.Structure.TokenScanner, refs);
						}
						destinationDict[key] = new DictionaryToken(dictionary3);
					}
				}
			}
		}
		DictionaryToken? GetRemoteDict(IToken token6)
		{
			DictionaryToken result = null;
			if (token6 is IndirectReferenceToken indirectReferenceToken2)
			{
				result = document.Structure.TokenScanner.Get(indirectReferenceToken2.Data).Data as DictionaryToken;
			}
			else if (token6 is DictionaryToken dictionaryToken)
			{
				result = dictionaryToken;
			}
			return result;
		}
	}

	private IReadOnlyList<IToken> CopyAnnotationsFromPageSource(IToken val, IPdfTokenScanner sourceScanner, IDictionary<IndirectReference, IndirectReferenceToken> refs, Page page, Func<PdfAction, PdfAction?>? linkCopyFunc = null, Action<(DictionaryToken, PdfAction)>? deferredActionUpdate = null)
	{
		HashSet<NameToken> hashSet = new HashSet<NameToken>
		{
			NameToken.Uri,
			NameToken.GoToR,
			NameToken.Launch
		};
		if (!DirectObjectFinder.TryGet<ArrayToken>(val, sourceScanner, out ArrayToken tokenResult))
		{
			return Array.Empty<IToken>();
		}
		List<IToken> list = new List<IToken>();
		foreach (IToken datum in tokenResult.Data)
		{
			if (!DirectObjectFinder.TryGet<DictionaryToken>(datum, sourceScanner, out DictionaryToken tokenResult2))
			{
				continue;
			}
			List<NameToken> list2 = new List<NameToken>();
			if (tokenResult2.TryGet(NameToken.P, out var token))
			{
				list2.Add(NameToken.P);
			}
			if (tokenResult2.TryGet(NameToken.StructParent, out token))
			{
				list2.Add(NameToken.StructParent);
			}
			if (!tokenResult2.TryGet<NameToken>(NameToken.Subtype, sourceScanner, out NameToken token2) || token2 != NameToken.Link)
			{
				IToken item = WriterUtil.CopyToken(context, CopyWithSkippedKeys(tokenResult2, list2), sourceScanner, refs);
				list.Add(item);
				continue;
			}
			if (linkCopyFunc != null && deferredActionUpdate != null)
			{
				PdfAction action = page.annotationProvider.GetAction(tokenResult2);
				if (action != null)
				{
					PdfAction pdfAction = linkCopyFunc(action);
					if (pdfAction != action && pdfAction != null)
					{
						DictionaryToken item2 = (DictionaryToken)WriterUtil.CopyToken(context, tokenResult2, sourceScanner, refs);
						deferredActionUpdate((item2, pdfAction));
						continue;
					}
				}
			}
			if (tokenResult2.TryGet<DictionaryToken>(NameToken.A, sourceScanner, out DictionaryToken token3))
			{
				if (token3.TryGet<NameToken>(NameToken.S, sourceScanner, out NameToken token4) && hashSet.Contains(token4))
				{
					IToken item3 = WriterUtil.CopyToken(context, CopyWithSkippedKeys(tokenResult2, list2), sourceScanner, refs);
					list.Add(item3);
				}
			}
			else if (!tokenResult2.TryGet(NameToken.Dest, out token))
			{
				IToken item4 = WriterUtil.CopyToken(context, CopyWithSkippedKeys(tokenResult2, list2), sourceScanner, refs);
				list.Add(item4);
			}
		}
		return list;
	}

	private static DictionaryToken CopyWithSkippedKeys(DictionaryToken source, IReadOnlyList<NameToken> skipped)
	{
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		foreach (KeyValuePair<string, IToken> datum in source.Data)
		{
			NameToken nameToken = NameToken.Create(datum.Key);
			bool flag = false;
			foreach (NameToken item in skipped)
			{
				if (item == nameToken)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				dictionary[nameToken] = datum.Value;
			}
		}
		return new DictionaryToken(dictionary);
	}

	private void CompleteDocument()
	{
		foreach (KeyValuePair<Guid, FontStored> font in fonts)
		{
			font.Value.FontProgram.WriteFont(context, font.Value.FontKey.Reference);
		}
		int num = (int)Math.Ceiling((double)Pages.Count / 25.0);
		List<IndirectReferenceToken> list = new List<IndirectReferenceToken>();
		List<List<IndirectReferenceToken>> list2 = new List<List<IndirectReferenceToken>>();
		List<Dictionary<NameToken, IToken>> list3 = new List<Dictionary<NameToken, IToken>>();
		for (int i = 0; i < num; i++)
		{
			list3.Add(new Dictionary<NameToken, IToken> { 
			{
				NameToken.Type,
				NameToken.Pages
			} });
			list2.Add(new List<IndirectReferenceToken>());
			list.Add(context.ReserveObjectNumber());
		}
		int num2 = 0;
		Dictionary<int, IndirectReferenceToken> dictionary = pages.ToDictionary<KeyValuePair<int, PdfPageBuilder>, int, IndirectReferenceToken>((KeyValuePair<int, PdfPageBuilder> p) => p.Key, (KeyValuePair<int, PdfPageBuilder> p) => context.ReserveObjectNumber());
		foreach (KeyValuePair<int, PdfPageBuilder> page in pages)
		{
			Dictionary<NameToken, IToken> pageDictionary = page.Value.pageDictionary;
			pageDictionary[NameToken.Type] = NameToken.Page;
			pageDictionary[NameToken.Parent] = list[num2];
			pageDictionary[NameToken.ProcSet] = DefaultProcSet;
			if (!pageDictionary.ContainsKey(NameToken.MediaBox))
			{
				pageDictionary[NameToken.MediaBox] = RectangleToArray(page.Value.PageSize);
			}
			if (page.Value.rotation.HasValue)
			{
				pageDictionary[NameToken.Rotate] = new NumericToken(page.Value.rotation.Value);
			}
			bool attemptDeduplication = context.AttemptDeduplication;
			context.AttemptDeduplication = false;
			List<PdfPageBuilder.IPageContentStream> list4 = page.Value.contentStreams.Where((PdfPageBuilder.IPageContentStream x) => x.HasContent).ToList();
			if (list4.Count == 0)
			{
				pageDictionary[NameToken.Contents] = new PdfPageBuilder.DefaultContentStream().Write(context);
			}
			else if (list4.Count == 1)
			{
				pageDictionary[NameToken.Contents] = list4[0].Write(context);
			}
			else
			{
				List<IToken> list5 = new List<IToken>();
				foreach (PdfPageBuilder.IPageContentStream item in list4)
				{
					list5.Add(item.Write(context));
				}
				pageDictionary[NameToken.Contents] = new ArrayToken(list5);
			}
			context.AttemptDeduplication = attemptDeduplication;
			if (page.Value.links != null && page.Value.links.Count > 0)
			{
				List<IToken> list6 = new List<IToken>();
				if (pageDictionary.TryGetValue(NameToken.Annots, out var value))
				{
					list6.AddRange(((ArrayToken)value).Data);
				}
				foreach (var (token, action) in page.Value.links)
				{
					list6.Add(CreateLinkAnnotationToken(token, action, dictionary));
				}
				pageDictionary[NameToken.Annots] = new ArrayToken(list6);
			}
			list2[num2].Add(context.WriteToken(new DictionaryToken(pageDictionary), dictionary[page.Key]));
			if (list2[num2].Count >= 25)
			{
				num2++;
			}
		}
		NameToken dummyName = NameToken.Create("ObjIdToUse");
		for (int num3 = 0; num3 < list3.Count; num3++)
		{
			list3[num3][NameToken.Kids] = new ArrayToken(list2[num3]);
			list3[num3][NameToken.Count] = new NumericToken(list2[num3].Count);
			list3[num3][dummyName] = list[num3];
		}
		Dictionary<NameToken, IToken> dictionary2 = new Dictionary<NameToken, IToken> { 
		{
			NameToken.Type,
			NameToken.Catalog
		} };
		if (list3.Count == 1)
		{
			Dictionary<NameToken, IToken> dictionary3 = list3[0];
			IndirectReferenceToken indirectReference = dictionary3[dummyName] as IndirectReferenceToken;
			dictionary3.Remove(dummyName);
			dictionary2[NameToken.Pages] = context.WriteToken(new DictionaryToken(dictionary3), indirectReference);
		}
		else
		{
			(int, IndirectReferenceToken) tuple2 = CreatePageTree(list3, null);
			dictionary2[NameToken.Pages] = tuple2.Item2;
		}
		if (Bookmarks != null && Bookmarks.Roots.Count > 0)
		{
			IndirectReferenceToken[] array = CreateBookmarkTree(Bookmarks.Roots, dictionary, null);
			Dictionary<NameToken, IToken> data = new Dictionary<NameToken, IToken>
			{
				{
					NameToken.Type,
					NameToken.Outlines
				},
				{
					NameToken.Count,
					new NumericToken(Bookmarks.Roots.Count)
				},
				{
					NameToken.First,
					array[0]
				},
				{
					NameToken.Last,
					array[array.Length - 1]
				}
			};
			dictionary2[NameToken.Outlines] = context.WriteToken(new DictionaryToken(data));
		}
		if (ArchiveStandard != PdfAStandard.None)
		{
			Func<IToken, IndirectReferenceToken> writerFunc = (IToken x) => context.WriteToken(x);
			PdfABaselineRuleBuilder.Obey(dictionary2, writerFunc, DocumentInformation, ArchiveStandard, version, XmpMetadata);
			switch (ArchiveStandard)
			{
			case PdfAStandard.A1A:
				PdfA1ARuleBuilder.Obey(dictionary2);
				break;
			case PdfAStandard.A2A:
				PdfA1ARuleBuilder.Obey(dictionary2);
				break;
			case PdfAStandard.A3A:
				PdfA1ARuleBuilder.Obey(dictionary2);
				break;
			}
		}
		DictionaryToken token2 = new DictionaryToken(dictionary2);
		IndirectReferenceToken catalogReference = context.WriteToken(token2);
		IndirectReferenceToken documentInformationReference = null;
		if (IncludeDocumentInformation)
		{
			Dictionary<NameToken, IToken> dictionary4 = DocumentInformation.ToDictionary();
			if (dictionary4.Count > 0)
			{
				DictionaryToken token3 = new DictionaryToken(dictionary4);
				documentInformationReference = context.WriteToken(token3);
			}
		}
		context.CompletePdf(catalogReference, documentInformationReference);
		completed = true;
		(int Count, IndirectReferenceToken Ref) CreatePageTree(List<Dictionary<NameToken, IToken>> pagesNodes, IndirectReferenceToken? parent)
		{
			int num4 = 0;
			IndirectReferenceToken indirectReferenceToken = context.ReserveObjectNumber();
			List<IndirectReferenceToken> list7 = new List<IndirectReferenceToken>();
			if (pagesNodes.Count > 25)
			{
				int num5 = (int)Math.Ceiling(Math.Log(pagesNodes.Count, 25.0));
				int num6 = (int)Math.Ceiling(Math.Pow(25.0, num5 - 1));
				int num7 = (int)Math.Ceiling((double)pagesNodes.Count / (double)num6);
				for (int j = 0; j < num7; j++)
				{
					List<Dictionary<NameToken, IToken>> pagesNodes2 = pagesNodes.Skip(j * num6).Take(num6).ToList();
					(int, IndirectReferenceToken) tuple3 = CreatePageTree(pagesNodes2, indirectReferenceToken);
					num4 += tuple3.Item1;
					list7.Add(tuple3.Item2);
				}
			}
			else
			{
				foreach (Dictionary<NameToken, IToken> pagesNode in pagesNodes)
				{
					pagesNode[NameToken.Parent] = indirectReferenceToken;
					IndirectReferenceToken indirectReference2 = pagesNode[dummyName] as IndirectReferenceToken;
					pagesNode.Remove(dummyName);
					num4 += ((NumericToken)pagesNode[NameToken.Count]).Int;
					list7.Add(context.WriteToken(new DictionaryToken(pagesNode), indirectReference2));
				}
			}
			Dictionary<NameToken, IToken> dictionary5 = new Dictionary<NameToken, IToken>
			{
				{
					NameToken.Type,
					NameToken.Pages
				},
				{
					NameToken.Kids,
					new ArrayToken(list7)
				},
				{
					NameToken.Count,
					new NumericToken(num4)
				}
			};
			if (parent != null)
			{
				dictionary5[NameToken.Parent] = parent;
			}
			return (Count: num4, Ref: context.WriteToken(new DictionaryToken(dictionary5), indirectReferenceToken));
		}
	}

	public byte[] Build()
	{
		CompleteDocument();
		if (context.Stream is MemoryStream memoryStream)
		{
			return memoryStream.ToArray();
		}
		if (!context.Stream.CanSeek)
		{
			throw new InvalidOperationException("PdfDocument.Build() called with non-seekable stream.");
		}
		using MemoryStream memoryStream2 = new MemoryStream();
		context.Stream.Seek(0L, SeekOrigin.Begin);
		context.Stream.CopyTo(memoryStream2);
		return memoryStream2.ToArray();
	}

	private static ArrayToken RectangleToArray(PdfRectangle rectangle)
	{
		return new ArrayToken(new global::_003C_003Ez__ReadOnlyArray<IToken>(new IToken[4]
		{
			new NumericToken(rectangle.BottomLeft.X),
			new NumericToken(rectangle.BottomLeft.Y),
			new NumericToken(rectangle.TopRight.X),
			new NumericToken(rectangle.TopRight.Y)
		}));
	}

	private IndirectReferenceToken[] CreateBookmarkTree(IReadOnlyList<BookmarkNode> nodes, Dictionary<int, IndirectReferenceToken> pageReferences, IndirectReferenceToken? parent)
	{
		IndirectReferenceToken[] array = new IndirectReferenceToken[nodes.Count];
		for (int i = 0; i < nodes.Count; i++)
		{
			array[i] = context.ReserveObjectNumber();
		}
		for (int j = 0; j < nodes.Count; j++)
		{
			BookmarkNode bookmarkNode = nodes[j];
			IndirectReferenceToken indirectReferenceToken = array[j];
			Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>
			{
				{
					NameToken.Title,
					new StringToken(bookmarkNode.Title)
				},
				{
					NameToken.Count,
					new NumericToken(bookmarkNode.Children.Count)
				}
			};
			if (parent != null)
			{
				dictionary[NameToken.Parent] = parent;
			}
			if (j > 0)
			{
				dictionary[NameToken.Prev] = array[j - 1];
			}
			if (j < array.Length - 1)
			{
				dictionary[NameToken.Next] = array[j + 1];
			}
			if (bookmarkNode.Children.Count > 0)
			{
				IndirectReferenceToken[] array2 = CreateBookmarkTree(bookmarkNode.Children, pageReferences, indirectReferenceToken);
				dictionary[NameToken.First] = array2[0];
				dictionary[NameToken.Last] = array2[array2.Length - 1];
			}
			if (!(bookmarkNode is DocumentBookmarkNode documentBookmarkNode))
			{
				if (!(bookmarkNode is UriBookmarkNode uriBookmarkNode))
				{
					throw new NotSupportedException(bookmarkNode.GetType().Name + " is not a supported bookmark node type.");
				}
				dictionary[NameToken.A] = new DictionaryToken(new Dictionary<NameToken, IToken>
				{
					[NameToken.S] = NameToken.Uri,
					[NameToken.Uri] = new StringToken(uriBookmarkNode.Uri)
				});
			}
			else
			{
				dictionary[NameToken.Dest] = CreateExplicitDestinationToken(documentBookmarkNode.Destination, pageReferences);
			}
			context.WriteToken(new DictionaryToken(dictionary), indirectReferenceToken);
		}
		return array;
	}

	private static ArrayToken CreateExplicitDestinationToken(ExplicitDestination destination, Dictionary<int, IndirectReferenceToken> pageReferences)
	{
		if (!pageReferences.TryGetValue(destination.PageNumber, out IndirectReferenceToken value))
		{
			throw new KeyNotFoundException($"Page {destination.PageNumber} was not found in the source document.");
		}
		return destination.Type switch
		{
			ExplicitDestinationType.XyzCoordinates => new ArrayToken(new IToken[5]
			{
				value,
				NameToken.XYZ,
				new NumericToken(destination.Coordinates.Left.GetValueOrDefault()),
				new NumericToken(destination.Coordinates.Top.GetValueOrDefault()),
				new NumericToken(0)
			}), 
			ExplicitDestinationType.FitPage => new ArrayToken(new IToken[2]
			{
				value,
				NameToken.Fit
			}), 
			ExplicitDestinationType.FitHorizontally => new ArrayToken(new IToken[3]
			{
				value,
				NameToken.FitH,
				new NumericToken(destination.Coordinates.Top.GetValueOrDefault())
			}), 
			ExplicitDestinationType.FitVertically => new ArrayToken(new IToken[3]
			{
				value,
				NameToken.FitV,
				new NumericToken(destination.Coordinates.Left.GetValueOrDefault())
			}), 
			ExplicitDestinationType.FitRectangle => new ArrayToken(new IToken[6]
			{
				value,
				NameToken.FitR,
				new NumericToken(destination.Coordinates.Left.GetValueOrDefault()),
				new NumericToken(destination.Coordinates.Top.GetValueOrDefault()),
				new NumericToken(destination.Coordinates.Right.GetValueOrDefault()),
				new NumericToken(destination.Coordinates.Bottom.GetValueOrDefault())
			}), 
			ExplicitDestinationType.FitBoundingBox => new ArrayToken(new global::_003C_003Ez__ReadOnlyArray<IToken>(new IToken[2]
			{
				value,
				NameToken.FitB
			})), 
			ExplicitDestinationType.FitBoundingBoxHorizontally => new ArrayToken(new global::_003C_003Ez__ReadOnlyArray<IToken>(new IToken[3]
			{
				value,
				NameToken.FitBH,
				new NumericToken(destination.Coordinates.Left.GetValueOrDefault())
			})), 
			ExplicitDestinationType.FitBoundingBoxVertically => new ArrayToken(new global::_003C_003Ez__ReadOnlyArray<IToken>(new IToken[3]
			{
				value,
				NameToken.FitBV,
				new NumericToken(destination.Coordinates.Left.GetValueOrDefault())
			})), 
			_ => throw new NotSupportedException($"{destination.Type} is not a supported bookmark destination type."), 
		};
	}

	private static DictionaryToken CreateLinkAnnotationToken(DictionaryToken token, PdfAction action, Dictionary<int, IndirectReferenceToken> pageReferences)
	{
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		foreach (KeyValuePair<string, IToken> datum in token.Data)
		{
			NameToken nameToken = NameToken.Create(datum.Key);
			if (!(nameToken == NameToken.A) && !(nameToken == NameToken.Dest))
			{
				dictionary[nameToken] = datum.Value;
			}
		}
		dictionary[NameToken.A] = CreateActionToken(action, pageReferences);
		return new DictionaryToken(dictionary);
	}

	private static DictionaryToken CreateActionToken(PdfAction action, Dictionary<int, IndirectReferenceToken> pageReferences)
	{
		if (!(action is UriAction uriAction))
		{
			if (!(action is GoToAction goToAction))
			{
				if (!(action is GoToEAction goToEAction))
				{
					if (action is GoToRAction goToRAction)
					{
						return new DictionaryToken(new Dictionary<NameToken, IToken>
						{
							[NameToken.S] = NameToken.GoToR,
							[NameToken.F] = new StringToken(goToRAction.Filename),
							[NameToken.D] = CreateExplicitDestinationToken(goToRAction.Destination, pageReferences)
						});
					}
					throw new NotSupportedException(action.GetType().Name + " is not a supported PDF action type.");
				}
				return new DictionaryToken(new Dictionary<NameToken, IToken>
				{
					[NameToken.S] = NameToken.GoToE,
					[NameToken.F] = new StringToken(goToEAction.FileSpecification),
					[NameToken.D] = CreateExplicitDestinationToken(goToEAction.Destination, pageReferences)
				});
			}
			return new DictionaryToken(new Dictionary<NameToken, IToken>
			{
				[NameToken.S] = NameToken.GoTo,
				[NameToken.D] = CreateExplicitDestinationToken(goToAction.Destination, pageReferences)
			});
		}
		return new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			[NameToken.S] = NameToken.Uri,
			[NameToken.Uri] = new StringToken(uriAction.Uri)
		});
	}

	public void Dispose()
	{
		if (!completed)
		{
			CompleteDocument();
		}
		context.Dispose();
	}
}
