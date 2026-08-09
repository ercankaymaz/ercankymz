#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf;

[DebuggerDisplay("(Name={Name})")]
public sealed class PdfDocument : PdfObject, IDisposable
{
	[DebuggerDisplay("(ID={ID}, alive={IsAlive})")]
	internal class DocumentHandle
	{
		private readonly WeakReference _weakRef;

		public string ID;

		public bool IsAlive => _weakRef.IsAlive;

		public PdfDocument Target => _weakRef.Target as PdfDocument;

		public DocumentHandle(PdfDocument document)
		{
			_weakRef = new WeakReference(document);
			ID = document._guid.ToString("B").ToUpper();
		}

		public override bool Equals(object obj)
		{
			if (obj is DocumentHandle documentHandle)
			{
				return ID == documentHandle.ID;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}

		public static bool operator ==(DocumentHandle left, DocumentHandle right)
		{
			return left?.Equals(right) ?? ((object)right == null);
		}

		public static bool operator !=(DocumentHandle left, DocumentHandle right)
		{
			return !(left == right);
		}
	}

	internal DocumentState _state;

	internal PdfDocumentOpenMode _openMode;

	private object _tag;

	private string _name = NewName();

	private static int _nameCount;

	private PdfDocumentOptions _options;

	private PdfDocumentSettings _settings;

	internal int _version;

	internal long _fileSize;

	internal string _fullPath = string.Empty;

	private Guid _guid = Guid.NewGuid();

	private DocumentHandle _handle;

	private PdfDocumentInformation _info;

	private PdfCustomValues _customValues;

	private PdfPages _pages;

	internal PdfSecuritySettings _securitySettings;

	private PdfFontTable _fontTable;

	private PdfImageTable _imageTable;

	private PdfFormXObjectTable _formTable;

	private PdfExtGStateTable _extGStateTable;

	private PdfCatalog _catalog;

	private PdfInternals _internals;

	internal PdfTrailer _trailer;

	internal PdfCrossReferenceTable _irefTable;

	internal Stream _outStream;

	internal Lexer _lexer;

	internal DateTime _creation;

	[ThreadStatic]
	private static ThreadLocalStorage tls;

	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	private string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	internal bool CanModify => true;

	public PdfDocumentOptions Options
	{
		get
		{
			if (_options == null)
			{
				_options = new PdfDocumentOptions(this);
			}
			return _options;
		}
	}

	public PdfDocumentSettings Settings
	{
		get
		{
			if (_settings == null)
			{
				_settings = new PdfDocumentSettings(this);
			}
			return _settings;
		}
	}

	internal bool EarlyWrite => false;

	public int Version
	{
		get
		{
			return _version;
		}
		set
		{
			if (!CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			if (value < 12 || value > 17)
			{
				throw new ArgumentException(PSSR.InvalidVersionNumber, "value");
			}
			_version = value;
		}
	}

	public int PageCount
	{
		get
		{
			if (CanModify)
			{
				return Pages.Count;
			}
			PdfDictionary pdfDictionary = (PdfDictionary)Catalog.Elements.GetObject("/Pages");
			return pdfDictionary.Elements.GetInteger("/Count");
		}
	}

	public long FileSize => _fileSize;

	public string FullPath => _fullPath;

	public Guid Guid => _guid;

	internal DocumentHandle Handle
	{
		get
		{
			if (_handle == null)
			{
				_handle = new DocumentHandle(this);
			}
			return _handle;
		}
	}

	public bool IsImported => (_state & DocumentState.Imported) != 0;

	public bool IsReadOnly => _openMode != PdfDocumentOpenMode.Modify;

	public PdfDocumentInformation Info
	{
		get
		{
			if (_info == null)
			{
				_info = _trailer.Info;
			}
			return _info;
		}
	}

	public PdfCustomValues CustomValues
	{
		get
		{
			if (_customValues == null)
			{
				_customValues = PdfCustomValues.Get(Catalog.Elements);
			}
			return _customValues;
		}
		set
		{
			if (value != null)
			{
				throw new ArgumentException("Only null is allowed to clear all custom values.");
			}
			PdfCustomValues.Remove(Catalog.Elements);
			_customValues = null;
		}
	}

	public PdfPages Pages
	{
		get
		{
			if (_pages == null)
			{
				_pages = Catalog.Pages;
			}
			return _pages;
		}
	}

	public PdfPageLayout PageLayout
	{
		get
		{
			return Catalog.PageLayout;
		}
		set
		{
			if (!CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			Catalog.PageLayout = value;
		}
	}

	public PdfPageMode PageMode
	{
		get
		{
			return Catalog.PageMode;
		}
		set
		{
			if (!CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			Catalog.PageMode = value;
		}
	}

	public PdfViewerPreferences ViewerPreferences => Catalog.ViewerPreferences;

	public PdfOutlineCollection Outlines => Catalog.Outlines;

	public PdfAcroForm AcroForm => Catalog.AcroForm;

	public string Language
	{
		get
		{
			return Catalog.Language;
		}
		set
		{
			Catalog.Language = value;
		}
	}

	public PdfSecuritySettings SecuritySettings => _securitySettings ?? (_securitySettings = new PdfSecuritySettings(this));

	internal PdfFontTable FontTable => _fontTable ?? (_fontTable = new PdfFontTable(this));

	internal PdfImageTable ImageTable
	{
		get
		{
			if (_imageTable == null)
			{
				_imageTable = new PdfImageTable(this);
			}
			return _imageTable;
		}
	}

	internal PdfFormXObjectTable FormTable => _formTable ?? (_formTable = new PdfFormXObjectTable(this));

	internal PdfExtGStateTable ExtGStateTable => _extGStateTable ?? (_extGStateTable = new PdfExtGStateTable(this));

	internal PdfCatalog Catalog => _catalog ?? (_catalog = _trailer.Root);

	public new PdfInternals Internals => _internals ?? (_internals = new PdfInternals(this));

	public PdfStandardSecurityHandler SecurityHandler => _trailer.SecurityHandler;

	internal static ThreadLocalStorage Tls => tls ?? (tls = new ThreadLocalStorage());

	public PdfDocument()
	{
		_creation = DateTime.Now;
		_state = DocumentState.Created;
		_version = 14;
		Initialize();
		Info.CreationDate = _creation;
	}

	public PdfDocument(string filename)
	{
		_creation = DateTime.Now;
		_state = DocumentState.Created;
		_version = 14;
		Initialize();
		Info.CreationDate = _creation;
		_outStream = new FileStream(filename, FileMode.Create);
	}

	public PdfDocument(Stream outputStream)
	{
		_creation = DateTime.Now;
		_state = DocumentState.Created;
		Initialize();
		Info.CreationDate = _creation;
		_outStream = outputStream;
	}

	internal PdfDocument(Lexer lexer)
	{
		_creation = DateTime.Now;
		_state = DocumentState.Imported;
		_irefTable = new PdfCrossReferenceTable(this);
		_lexer = lexer;
	}

	private void Initialize()
	{
		_fontTable = new PdfFontTable(this);
		_imageTable = new PdfImageTable(this);
		_trailer = new PdfTrailer(this);
		_irefTable = new PdfCrossReferenceTable(this);
		_trailer.CreateNewDocumentIDs();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	private void Dispose(bool disposing)
	{
		if (_state == DocumentState.Disposed || disposing)
		{
		}
		_state = DocumentState.Disposed;
	}

	private static string NewName()
	{
		return "Document " + _nameCount++;
	}

	public void Close()
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		if (_outStream != null)
		{
			PdfStandardSecurityHandler securityHandler = null;
			if (SecuritySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None)
			{
				securityHandler = SecuritySettings.SecurityHandler;
			}
			PdfWriter pdfWriter = new PdfWriter(_outStream, securityHandler);
			try
			{
				DoSave(pdfWriter);
			}
			finally
			{
				pdfWriter.Close();
			}
		}
	}

	public void Save(string path)
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		using Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
		Save(stream);
	}

	public void Save(Stream stream, bool closeStream)
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		string message = "";
		if (!CanSave(ref message))
		{
			throw new PdfSharpException(message);
		}
		PdfStandardSecurityHandler securityHandler = null;
		if (SecuritySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None)
		{
			securityHandler = SecuritySettings.SecurityHandler;
		}
		PdfWriter pdfWriter = null;
		try
		{
			pdfWriter = new PdfWriter(stream, securityHandler);
			DoSave(pdfWriter);
		}
		finally
		{
			if (stream != null)
			{
				if (closeStream)
				{
					stream.Close();
				}
				else if (stream.CanRead && stream.CanSeek)
				{
					stream.Position = 0L;
				}
			}
			pdfWriter?.Close(closeStream);
		}
	}

	public void Save(Stream stream)
	{
		Save(stream, closeStream: false);
	}

	private void DoSave(PdfWriter writer)
	{
		if (_pages == null || _pages.Count == 0)
		{
			if (_outStream != null)
			{
				throw new InvalidOperationException("Cannot save a PDF document with no pages. Do not use \"public PdfDocument(string filename)\" or \"public PdfDocument(Stream outputStream)\" if you want to open an existing PDF document from a file or stream; use PdfReader.Open() for that purpose.");
			}
			throw new InvalidOperationException("Cannot save a PDF document with no pages.");
		}
		try
		{
			if (_trailer is PdfCrossReferenceStream)
			{
				PdfStandardSecurityHandler securityHandler = _securitySettings.SecurityHandler;
				_trailer = new PdfTrailer((PdfCrossReferenceStream)_trailer);
				_trailer._securityHandler = securityHandler;
			}
			bool flag = _securitySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None;
			if (flag)
			{
				PdfStandardSecurityHandler securityHandler2 = _securitySettings.SecurityHandler;
				if (securityHandler2.Reference == null)
				{
					_irefTable.Add(securityHandler2);
				}
				else
				{
					Debug.Assert(_irefTable.Contains(securityHandler2.ObjectID));
				}
				_trailer.Elements["/Encrypt"] = _securitySettings.SecurityHandler.Reference;
			}
			else
			{
				_trailer.Elements.Remove("/Encrypt");
			}
			PrepareForSave();
			if (flag)
			{
				_securitySettings.SecurityHandler.PrepareEncryption();
			}
			writer.WriteFileHeader(this);
			PdfReference[] allReferences = _irefTable.AllReferences;
			int num = allReferences.Length;
			for (int i = 0; i < num; i++)
			{
				PdfReference pdfReference = allReferences[i];
				pdfReference.Position = writer.Position;
				pdfReference.Value.WriteObject(writer);
			}
			int position = writer.Position;
			_irefTable.WriteObject(writer);
			writer.WriteRaw("trailer\n");
			_trailer.Elements.SetInteger("/Size", num + 1);
			_trailer.WriteObject(writer);
			writer.WriteEof(this, position);
		}
		finally
		{
			writer?.Stream.Flush();
		}
	}

	internal override void PrepareForSave()
	{
		PdfDocumentInformation info = Info;
		string text = "PDFsharp 1.50.4740 (www.pdfsharp.com)";
		if (!"0".Equals("0"))
		{
			text = "PDFsharp 1.50.4740.0 (www.pdfsharp.com)";
		}
		if (info.Elements["/Creator"] == null)
		{
			info.Creator = text;
		}
		string text2 = info.Producer;
		if (text2.Length == 0)
		{
			text2 = text;
		}
		else if (!text2.StartsWith("PDFsharp"))
		{
			text2 = text + " (Original: " + text2 + ")";
		}
		info.Elements.SetString("/Producer", text2);
		if (_fontTable != null)
		{
			_fontTable.PrepareForSave();
		}
		Catalog.PrepareForSave();
		int num = _irefTable.Compact();
		if (num != 0)
		{
			Debug.WriteLine("PrepareForSave: Number of deleted unreachable objects: " + num);
		}
		_irefTable.Renumber();
	}

	public bool CanSave(ref string message)
	{
		if (!SecuritySettings.CanSave(ref message))
		{
			return false;
		}
		return true;
	}

	internal bool HasVersion(string version)
	{
		return string.Compare(Catalog.Version, version) >= 0;
	}

	internal Exception DocumentNotImported()
	{
		return new InvalidOperationException("Document not imported.");
	}

	public PdfPage AddPage()
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		return Catalog.Pages.Add();
	}

	public PdfPage AddPage(PdfPage page)
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		return Catalog.Pages.Add(page);
	}

	public PdfPage InsertPage(int index)
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		return Catalog.Pages.Insert(index);
	}

	public PdfPage InsertPage(int index, PdfPage page)
	{
		if (!CanModify)
		{
			throw new InvalidOperationException(PSSR.CannotModify);
		}
		return Catalog.Pages.Insert(index, page);
	}

	public void Flatten()
	{
		for (int i = 0; i < AcroForm.Fields.Count; i++)
		{
			AcroForm.Fields[i].ReadOnly = true;
		}
	}

	internal void OnExternalDocumentFinalized(DocumentHandle handle)
	{
		if (tls != null)
		{
			tls.DetachDocument(handle);
		}
		if (_formTable != null)
		{
			_formTable.DetachDocument(handle);
		}
	}
}
