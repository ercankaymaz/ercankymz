// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDocument
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("(Name={Name})")]
public sealed class PdfDocument : PdfObject, IDisposable
{
  internal DocumentState _state;
  internal PdfDocumentOpenMode _openMode;
  private object _tag;
  private string _name = PdfDocument.NewName();
  private static int _nameCount;
  private PdfDocumentOptions _options;
  private PdfDocumentSettings _settings;
  internal int _version;
  internal long _fileSize;
  internal string _fullPath = string.Empty;
  private Guid _guid = Guid.NewGuid();
  private PdfDocument.DocumentHandle _handle;
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

  public PdfDocument()
  {
    this._creation = DateTime.Now;
    this._state = DocumentState.Created;
    this._version = 14;
    this.Initialize();
    this.Info.CreationDate = this._creation;
  }

  public PdfDocument(string filename)
  {
    this._creation = DateTime.Now;
    this._state = DocumentState.Created;
    this._version = 14;
    this.Initialize();
    this.Info.CreationDate = this._creation;
    this._outStream = (Stream) new FileStream(filename, FileMode.Create);
  }

  public PdfDocument(Stream outputStream)
  {
    this._creation = DateTime.Now;
    this._state = DocumentState.Created;
    this.Initialize();
    this.Info.CreationDate = this._creation;
    this._outStream = outputStream;
  }

  internal PdfDocument(Lexer lexer)
  {
    this._creation = DateTime.Now;
    this._state = DocumentState.Imported;
    this._irefTable = new PdfCrossReferenceTable(this);
    this._lexer = lexer;
  }

  private void Initialize()
  {
    this._fontTable = new PdfFontTable(this);
    this._imageTable = new PdfImageTable(this);
    this._trailer = new PdfTrailer(this);
    this._irefTable = new PdfCrossReferenceTable(this);
    this._trailer.CreateNewDocumentIDs();
  }

  public void Dispose() => this.Dispose(true);

  private void Dispose(bool disposing)
  {
    if (this._state == DocumentState.Disposed || disposing)
      ;
    this._state = DocumentState.Disposed;
  }

  public object Tag
  {
    get => this._tag;
    set => this._tag = value;
  }

  private string Name
  {
    get => this._name;
    set => this._name = value;
  }

  private static string NewName() => "Document " + PdfDocument._nameCount++.ToString();

  internal bool CanModify => true;

  public void Close()
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    if (this._outStream == null)
      return;
    PdfStandardSecurityHandler securityHandler = (PdfStandardSecurityHandler) null;
    if (this.SecuritySettings.DocumentSecurityLevel != 0)
      securityHandler = this.SecuritySettings.SecurityHandler;
    PdfWriter writer = new PdfWriter(this._outStream, securityHandler);
    try
    {
      this.DoSave(writer);
    }
    finally
    {
      writer.Close();
    }
  }

  public void Save(string path)
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    using (Stream stream = (Stream) new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      this.Save(stream);
  }

  public void Save(Stream stream, bool closeStream)
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    string message = "";
    if (!this.CanSave(ref message))
      throw new PdfSharpException(message);
    PdfStandardSecurityHandler securityHandler = (PdfStandardSecurityHandler) null;
    if (this.SecuritySettings.DocumentSecurityLevel != 0)
      securityHandler = this.SecuritySettings.SecurityHandler;
    PdfWriter writer = (PdfWriter) null;
    try
    {
      writer = new PdfWriter(stream, securityHandler);
      this.DoSave(writer);
    }
    finally
    {
      if (stream != null)
      {
        if (closeStream)
          stream.Close();
        else if ((!stream.CanRead ? 0 : (stream.CanSeek ? 1 : 0)) != 0)
          stream.Position = 0L;
      }
      writer?.Close(closeStream);
    }
  }

  public void Save(Stream stream) => this.Save(stream, false);

  private void DoSave(PdfWriter writer)
  {
    if ((this._pages == null ? 1 : (this._pages.Count == 0 ? 1 : 0)) != 0)
    {
      if (this._outStream != null)
        throw new InvalidOperationException("Cannot save a PDF document with no pages. Do not use \"public PdfDocument(string filename)\" or \"public PdfDocument(Stream outputStream)\" if you want to open an existing PDF document from a file or stream; use PdfReader.Open() for that purpose.");
      throw new InvalidOperationException("Cannot save a PDF document with no pages.");
    }
    try
    {
      if (this._trailer is PdfCrossReferenceStream)
      {
        PdfStandardSecurityHandler securityHandler = this._securitySettings.SecurityHandler;
        this._trailer = new PdfTrailer((PdfCrossReferenceStream) this._trailer);
        this._trailer._securityHandler = securityHandler;
      }
      bool flag;
      if (flag = this._securitySettings.DocumentSecurityLevel != 0)
      {
        PdfStandardSecurityHandler securityHandler = this._securitySettings.SecurityHandler;
        if (securityHandler.Reference == null)
          this._irefTable.Add((PdfObject) securityHandler);
        else
          Debug.Assert(this._irefTable.Contains(securityHandler.ObjectID));
        this._trailer.Elements["/Encrypt"] = (PdfItem) this._securitySettings.SecurityHandler.Reference;
      }
      else
        this._trailer.Elements.Remove("/Encrypt");
      this.PrepareForSave();
      if (flag)
        this._securitySettings.SecurityHandler.PrepareEncryption();
      writer.WriteFileHeader(this);
      PdfReference[] allReferences = this._irefTable.AllReferences;
      int length = allReferences.Length;
      for (int index = 0; index < length; ++index)
      {
        PdfReference pdfReference = allReferences[index];
        pdfReference.Position = writer.Position;
        pdfReference.Value.WriteObject(writer);
      }
      int position = writer.Position;
      this._irefTable.WriteObject(writer);
      writer.WriteRaw("trailer\n");
      this._trailer.Elements.SetInteger("/Size", length + 1);
      this._trailer.WriteObject(writer);
      writer.WriteEof(this, position);
    }
    finally
    {
      writer?.Stream.Flush();
    }
  }

  internal override void PrepareForSave()
  {
    PdfDocumentInformation info = this.Info;
    string str1 = "PDFsharp 1.50.4740 (www.pdfsharp.com)";
    if (!"0".Equals("0"))
      str1 = "PDFsharp 1.50.4740.0 (www.pdfsharp.com)";
    if (info.Elements["/Creator"] == null)
      info.Creator = str1;
    string str2 = info.Producer;
    if (str2.Length == 0)
      str2 = str1;
    else if (!str2.StartsWith("PDFsharp"))
      str2 = $"{str1} (Original: {str2})";
    info.Elements.SetString("/Producer", str2);
    if (this._fontTable != null)
      this._fontTable.PrepareForSave();
    this.Catalog.PrepareForSave();
    int num = this._irefTable.Compact();
    if (num != 0)
      Debug.WriteLine("PrepareForSave: Number of deleted unreachable objects: " + num.ToString());
    this._irefTable.Renumber();
  }

  public bool CanSave(ref string message) => this.SecuritySettings.CanSave(ref message);

  internal bool HasVersion(string version) => string.Compare(this.Catalog.Version, version) >= 0;

  public PdfDocumentOptions Options
  {
    get
    {
      if (this._options == null)
        this._options = new PdfDocumentOptions(this);
      return this._options;
    }
  }

  public PdfDocumentSettings Settings
  {
    get
    {
      if (this._settings == null)
        this._settings = new PdfDocumentSettings(this);
      return this._settings;
    }
  }

  internal bool EarlyWrite => false;

  public int Version
  {
    get => this._version;
    set
    {
      if (!this.CanModify)
        throw new InvalidOperationException(PSSR.CannotModify);
      this._version = (value < 12 ? 1 : (value > 17 ? 1 : 0)) == 0 ? value : throw new ArgumentException(PSSR.InvalidVersionNumber, nameof (value));
    }
  }

  public int PageCount
  {
    get
    {
      return !this.CanModify ? ((PdfDictionary) this.Catalog.Elements.GetObject("/Pages")).Elements.GetInteger("/Count") : this.Pages.Count;
    }
  }

  public long FileSize => this._fileSize;

  public string FullPath => this._fullPath;

  public Guid Guid => this._guid;

  internal PdfDocument.DocumentHandle Handle
  {
    get
    {
      if (this._handle == (PdfDocument.DocumentHandle) null)
        this._handle = new PdfDocument.DocumentHandle(this);
      return this._handle;
    }
  }

  public bool IsImported => (this._state & DocumentState.Imported) != 0;

  public bool IsReadOnly => this._openMode != 0;

  internal Exception DocumentNotImported()
  {
    return (Exception) new InvalidOperationException("Document not imported.");
  }

  public PdfDocumentInformation Info
  {
    get
    {
      if (this._info == null)
        this._info = this._trailer.Info;
      return this._info;
    }
  }

  public PdfCustomValues CustomValues
  {
    get
    {
      if (this._customValues == null)
        this._customValues = PdfCustomValues.Get(this.Catalog.Elements);
      return this._customValues;
    }
    set
    {
      if (value != null)
        throw new ArgumentException("Only null is allowed to clear all custom values.");
      PdfCustomValues.Remove(this.Catalog.Elements);
      this._customValues = (PdfCustomValues) null;
    }
  }

  public PdfPages Pages
  {
    get
    {
      if (this._pages == null)
        this._pages = this.Catalog.Pages;
      return this._pages;
    }
  }

  public PdfPageLayout PageLayout
  {
    get => this.Catalog.PageLayout;
    set
    {
      if (!this.CanModify)
        throw new InvalidOperationException(PSSR.CannotModify);
      this.Catalog.PageLayout = value;
    }
  }

  public PdfPageMode PageMode
  {
    get => this.Catalog.PageMode;
    set
    {
      if (!this.CanModify)
        throw new InvalidOperationException(PSSR.CannotModify);
      this.Catalog.PageMode = value;
    }
  }

  public PdfViewerPreferences ViewerPreferences => this.Catalog.ViewerPreferences;

  public PdfOutlineCollection Outlines => this.Catalog.Outlines;

  public PdfAcroForm AcroForm => this.Catalog.AcroForm;

  public string Language
  {
    get => this.Catalog.Language;
    set => this.Catalog.Language = value;
  }

  public PdfSecuritySettings SecuritySettings
  {
    get => this._securitySettings ?? (this._securitySettings = new PdfSecuritySettings(this));
  }

  internal PdfFontTable FontTable => this._fontTable ?? (this._fontTable = new PdfFontTable(this));

  internal PdfImageTable ImageTable
  {
    get
    {
      if (this._imageTable == null)
        this._imageTable = new PdfImageTable(this);
      return this._imageTable;
    }
  }

  internal PdfFormXObjectTable FormTable
  {
    get => this._formTable ?? (this._formTable = new PdfFormXObjectTable(this));
  }

  internal PdfExtGStateTable ExtGStateTable
  {
    get => this._extGStateTable ?? (this._extGStateTable = new PdfExtGStateTable(this));
  }

  internal PdfCatalog Catalog => this._catalog ?? (this._catalog = this._trailer.Root);

  public PdfInternals Internals => this._internals ?? (this._internals = new PdfInternals(this));

  public PdfPage AddPage()
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    return this.Catalog.Pages.Add();
  }

  public PdfPage AddPage(PdfPage page)
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    return this.Catalog.Pages.Add(page);
  }

  public PdfPage InsertPage(int index)
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    return this.Catalog.Pages.Insert(index);
  }

  public PdfPage InsertPage(int index, PdfPage page)
  {
    if (!this.CanModify)
      throw new InvalidOperationException(PSSR.CannotModify);
    return this.Catalog.Pages.Insert(index, page);
  }

  public void Flatten()
  {
    for (int index = 0; index < this.AcroForm.Fields.Count; ++index)
      this.AcroForm.Fields[index].ReadOnly = true;
  }

  public PdfStandardSecurityHandler SecurityHandler => this._trailer.SecurityHandler;

  internal void OnExternalDocumentFinalized(PdfDocument.DocumentHandle handle)
  {
    if (PdfDocument.tls != null)
      PdfDocument.tls.DetachDocument(handle);
    if (this._formTable == null)
      return;
    this._formTable.DetachDocument(handle);
  }

  internal static ThreadLocalStorage Tls
  {
    get => PdfDocument.tls ?? (PdfDocument.tls = new ThreadLocalStorage());
  }

  [DebuggerDisplay("(ID={ID}, alive={IsAlive})")]
  internal class DocumentHandle
  {
    private readonly WeakReference _weakRef;
    public string ID;

    public DocumentHandle(PdfDocument document)
    {
      this._weakRef = new WeakReference((object) document);
      this.ID = document._guid.ToString("B").ToUpper();
    }

    public bool IsAlive => this._weakRef.IsAlive;

    public PdfDocument Target => this._weakRef.Target as PdfDocument;

    public override bool Equals(object obj)
    {
      return obj is PdfDocument.DocumentHandle documentHandle && this.ID == documentHandle.ID;
    }

    public override int GetHashCode() => this.ID.GetHashCode();

    public static bool operator ==(
      PdfDocument.DocumentHandle left,
      PdfDocument.DocumentHandle right)
    {
      return (object) left != null ? left.Equals((object) right) : (object) right == null;
    }

    public static bool operator !=(
      PdfDocument.DocumentHandle left,
      PdfDocument.DocumentHandle right)
    {
      return !(left == right);
    }
  }
}
