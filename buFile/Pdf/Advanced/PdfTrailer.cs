// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfTrailer
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class PdfTrailer : PdfDictionary
{
  internal PdfStandardSecurityHandler _securityHandler;

  public PdfTrailer(PdfDocument document)
    : base(document)
  {
    this._document = document;
  }

  public PdfTrailer(PdfCrossReferenceStream trailer)
    : base(trailer._document)
  {
    this._document = trailer._document;
    PdfReference reference = trailer.Elements.GetReference("/Info");
    if (reference != null)
      this.Elements.SetReference("/Info", reference);
    this.Elements.SetReference("/Root", trailer.Elements.GetReference("/Root"));
    this.Elements.SetInteger("/Size", trailer.Elements.GetInteger("/Size"));
    PdfArray array = trailer.Elements.GetArray("/ID");
    if (array == null)
      return;
    this.Elements.SetValue("/ID", (PdfItem) array);
  }

  public int Size
  {
    get => this.Elements.GetInteger("/Size");
    set => this.Elements.SetInteger("/Size", value);
  }

  public PdfDocumentInformation Info
  {
    get => (PdfDocumentInformation) this.Elements.GetValue("/Info", VCF.CreateIndirect);
  }

  public PdfCatalog Root => (PdfCatalog) this.Elements.GetValue("/Root", VCF.CreateIndirect);

  public string GetDocumentID(int index)
  {
    if ((index < 0 ? 1 : (index > 1 ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (index), (object) index, "Index must be 0 or 1.");
    string documentId;
    if ((!(this.Elements["/ID"] is PdfArray element1) ? 1 : (element1.Elements.Count < 2 ? 1 : 0)) != 0)
    {
      documentId = "";
    }
    else
    {
      PdfItem element = element1.Elements[index];
      documentId = !(element is PdfString) ? "" : ((PdfString) element).Value;
    }
    return documentId;
  }

  public void SetDocumentID(int index, string value)
  {
    if ((index < 0 ? 1 : (index > 1 ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (index), (object) index, "Index must be 0 or 1.");
    if ((!(this.Elements["/ID"] is PdfArray pdfArray) ? 1 : (pdfArray.Elements.Count < 2 ? 1 : 0)) != 0)
      pdfArray = this.CreateNewDocumentIDs();
    pdfArray.Elements[index] = (PdfItem) new PdfString(value, PdfStringFlags.HexLiteral);
  }

  internal PdfArray CreateNewDocumentIDs()
  {
    PdfArray newDocumentIds = new PdfArray(this._document);
    byte[] byteArray = Guid.NewGuid().ToByteArray();
    string str = PdfEncoders.RawEncoding.GetString(byteArray, 0, byteArray.Length);
    newDocumentIds.Elements.Add((PdfItem) new PdfString(str, PdfStringFlags.HexLiteral));
    newDocumentIds.Elements.Add((PdfItem) new PdfString(str, PdfStringFlags.HexLiteral));
    this.Elements["/ID"] = (PdfItem) newDocumentIds;
    return newDocumentIds;
  }

  public PdfStandardSecurityHandler SecurityHandler
  {
    get
    {
      if (this._securityHandler == null)
        this._securityHandler = (PdfStandardSecurityHandler) this.Elements.GetValue("/Encrypt", VCF.CreateIndirect);
      return this._securityHandler;
    }
  }

  internal override void WriteObject(PdfWriter writer)
  {
    this._elements.Remove("/XRefStm");
    PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
    writer.SecurityHandler = (PdfStandardSecurityHandler) null;
    base.WriteObject(writer);
    writer.SecurityHandler = securityHandler;
  }

  internal void Finish()
  {
    if ((!(this._document._trailer.Elements["/Root"] is PdfReference element1) ? 0 : (element1.Value == null ? 1 : 0)) != 0)
    {
      PdfReference pdfReference = this._document._irefTable[element1.ObjectID];
      Debug.Assert(pdfReference.Value != null);
      this._document._trailer.Elements["/Root"] = (PdfItem) pdfReference;
    }
    if ((!(this._document._trailer.Elements["/Info"] is PdfReference element2) ? 0 : (element2.Value == null ? 1 : 0)) != 0)
    {
      PdfReference pdfReference = this._document._irefTable[element2.ObjectID];
      Debug.Assert(pdfReference.Value != null);
      this._document._trailer.Elements["/Info"] = (PdfItem) pdfReference;
    }
    if (this._document._trailer.Elements["/Encrypt"] is PdfReference element3)
    {
      PdfReference pdfReference = this._document._irefTable[element3.ObjectID];
      Debug.Assert(pdfReference.Value != null);
      this._document._trailer.Elements["/Encrypt"] = (PdfItem) pdfReference;
      pdfReference.Value = (PdfObject) this._document._trailer._securityHandler;
      this._document._trailer._securityHandler.Reference = pdfReference;
      pdfReference.Value.Reference = pdfReference;
    }
    this.Elements.Remove("/Prev");
    Debug.Assert(!this._document._irefTable.IsUnderConstruction);
    this._document._irefTable.IsUnderConstruction = false;
  }

  internal override DictionaryMeta Meta => PdfTrailer.Keys.Meta;

  internal class Keys : KeysBase
  {
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string Size = "/Size";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string Prev = "/Prev";
    [KeyInfo(KeyType.Dictionary | KeyType.Required, typeof (PdfCatalog))]
    public const string Root = "/Root";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfStandardSecurityHandler))]
    public const string Encrypt = "/Encrypt";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfDocumentInformation))]
    public const string Info = "/Info";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string ID = "/ID";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string XRefStm = "/XRefStm";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfTrailer.Keys._meta ?? (PdfTrailer.Keys._meta = KeysBase.CreateMeta(typeof (PdfTrailer.Keys)));
      }
    }
  }
}
