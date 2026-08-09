using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using UglyToad.PdfPig.AcroForms;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Encryption;
using UglyToad.PdfPig.Exceptions;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Outline;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig;

public class PdfDocument : IDisposable
{
	private bool isDisposed;

	private readonly Lazy<AcroForm> documentForm;

	private readonly HeaderVersion version;

	private readonly IInputBytes inputBytes;

	private readonly EncryptionDictionary? encryptionDictionary;

	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly BookmarksProvider bookmarksProvider;

	private readonly ParsingOptions parsingOptions;

	private readonly Pages pages;

	private readonly NamedDestinations namedDestinations;

	public DocumentInformation Information { get; }

	public Structure Structure { get; }

	public AdvancedPdfDocumentAccess Advanced { get; }

	public double Version => version.Version;

	public int NumberOfPages => pages.Count;

	[MemberNotNullWhen(true, "encryptionDictionary")]
	public bool IsEncrypted
	{
		[MemberNotNullWhen(true, "encryptionDictionary")]
		get
		{
			return encryptionDictionary != null;
		}
	}

	internal PdfDocument(IInputBytes inputBytes, HeaderVersion version, Catalog catalog, DocumentInformation information, EncryptionDictionary? encryptionDictionary, IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, AcroFormFactory acroFormFactory, BookmarksProvider bookmarksProvider, ParsingOptions parsingOptions)
	{
		this.inputBytes = inputBytes;
		this.version = version ?? throw new ArgumentNullException("version");
		this.encryptionDictionary = encryptionDictionary;
		this.pdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
		this.filterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		this.bookmarksProvider = bookmarksProvider ?? throw new ArgumentNullException("bookmarksProvider");
		this.parsingOptions = parsingOptions;
		Information = information ?? throw new ArgumentNullException("information");
		pages = catalog.Pages;
		namedDestinations = catalog.NamedDestinations;
		Structure = new Structure(catalog, pdfScanner);
		Advanced = new AdvancedPdfDocumentAccess(pdfScanner, filterProvider, catalog);
		documentForm = new Lazy<AcroForm>(() => acroFormFactory.GetAcroForm(catalog));
	}

	public static PdfDocument Open(byte[] fileBytes, ParsingOptions? options = null)
	{
		return PdfDocumentFactory.Open(fileBytes, options);
	}

	public static PdfDocument Open(ReadOnlyMemory<byte> memory, ParsingOptions? options = null)
	{
		return PdfDocumentFactory.Open(memory, options);
	}

	public static PdfDocument Open(string filePath, ParsingOptions? options = null)
	{
		return PdfDocumentFactory.Open(filePath, options);
	}

	public static PdfDocument Open(Stream stream, ParsingOptions? options = null)
	{
		return PdfDocumentFactory.Open(stream, options);
	}

	public void AddPageFactory<TPage>(IPageFactory<TPage> pageFactory)
	{
		pages.AddPageFactory(pageFactory);
	}

	public void AddPageFactory<TPage, TPageFactory>() where TPageFactory : IPageFactory<TPage>
	{
		pages.AddPageFactory<TPage, TPageFactory>();
	}

	public Page GetPage(int pageNumber)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("Cannot access page after the document is disposed.");
		}
		parsingOptions.Logger.Debug($"Accessing page {pageNumber}.");
		try
		{
			return pages.GetPage(pageNumber, namedDestinations, parsingOptions);
		}
		catch (Exception inner)
		{
			if (IsEncrypted)
			{
				throw new PdfDocumentEncryptedException("Document was encrypted which may have caused error when retrieving page.", encryptionDictionary, inner);
			}
			throw;
		}
	}

	public TPage GetPage<TPage>(int pageNumber)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("Cannot access page after the document is disposed.");
		}
		parsingOptions.Logger.Debug($"Accessing page {pageNumber}.");
		try
		{
			return pages.GetPage<TPage>(pageNumber, namedDestinations, parsingOptions);
		}
		catch (Exception inner)
		{
			if (IsEncrypted)
			{
				throw new PdfDocumentEncryptedException("Document was encrypted which may have caused error when retrieving page.", encryptionDictionary, inner);
			}
			throw;
		}
	}

	public IEnumerable<Page> GetPages()
	{
		for (int i = 0; i < NumberOfPages; i++)
		{
			yield return GetPage(i + 1);
		}
	}

	public IEnumerable<TPage> GetPages<TPage>()
	{
		for (int i = 0; i < NumberOfPages; i++)
		{
			yield return GetPage<TPage>(i + 1);
		}
	}

	public bool TryGetXmpMetadata([NotNullWhen(true)] out XmpMetadata? metadata)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("Cannot access the document metadata after the document is disposed.");
		}
		metadata = null;
		if (!Structure.Catalog.CatalogDictionary.TryGet<StreamToken>(NameToken.Metadata, pdfScanner, out StreamToken token))
		{
			return false;
		}
		metadata = new XmpMetadata(token, filterProvider, pdfScanner);
		return true;
	}

	public bool TryGetBookmarks([NotNullWhen(true)] out Bookmarks? bookmarks, bool allowContainerNode = false)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("Cannot access the bookmarks after the document is disposed.");
		}
		bookmarks = bookmarksProvider.GetBookmarks(Structure.Catalog, allowContainerNode);
		return bookmarks != null;
	}

	public bool TryGetForm(out AcroForm form)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("Cannot access the form after the document is disposed.");
		}
		form = documentForm.Value;
		return form != null;
	}

	public void Dispose()
	{
		try
		{
			Advanced.Dispose();
			pdfScanner.Dispose();
			inputBytes.Dispose();
			pages.Dispose();
		}
		catch (Exception ex)
		{
			parsingOptions.Logger.Error("Failed disposing the PdfDocument due to an error.", ex);
		}
		finally
		{
			isDisposed = true;
		}
	}
}
