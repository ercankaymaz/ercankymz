// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfInternals
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfInternals
{
  private readonly PdfDocument _document;
  public string CustomValueKey = "/PdfSharp.CustomValue";

  internal PdfInternals(PdfDocument document) => this._document = document;

  public string FirstDocumentID
  {
    get => this._document._trailer.GetDocumentID(0);
    set => this._document._trailer.SetDocumentID(0, value);
  }

  public Guid FirstDocumentGuid => this.GuidFromString(this._document._trailer.GetDocumentID(0));

  public string SecondDocumentID
  {
    get => this._document._trailer.GetDocumentID(1);
    set => this._document._trailer.SetDocumentID(1, value);
  }

  public Guid SecondDocumentGuid => this.GuidFromString(this._document._trailer.GetDocumentID(0));

  private Guid GuidFromString(string id)
  {
    Guid guid;
    if ((id == null ? 1 : (id.Length != 16 /*0x10*/ ? 1 : 0)) != 0)
    {
      guid = Guid.Empty;
    }
    else
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < 16 /*0x10*/; ++index)
        stringBuilder.AppendFormat("{0:X2}", (object) (byte) id[index]);
      guid = new Guid(stringBuilder.ToString());
    }
    return guid;
  }

  public PdfCatalog Catalog => this._document.Catalog;

  public PdfExtGStateTable ExtGStateTable => this._document.ExtGStateTable;

  public PdfObject GetObject(PdfObjectID objectID) => this._document._irefTable[objectID].Value;

  public PdfObject MapExternalObject(PdfObject externalObject)
  {
    PdfReference pdfReference = this._document.FormTable.GetImportedObjectTable(externalObject.Owner)[externalObject.ObjectID];
    return pdfReference == null ? (PdfObject) null : pdfReference.Value;
  }

  public static PdfReference GetReference(PdfObject obj)
  {
    return obj != null ? obj.Reference : throw new ArgumentNullException(nameof (obj));
  }

  public static PdfObjectID GetObjectID(PdfObject obj)
  {
    return obj != null ? obj.ObjectID : throw new ArgumentNullException(nameof (obj));
  }

  public static int GetObjectNumber(PdfObject obj)
  {
    return obj != null ? obj.ObjectNumber : throw new ArgumentNullException(nameof (obj));
  }

  public static int GenerationNumber(PdfObject obj)
  {
    return obj != null ? obj.GenerationNumber : throw new ArgumentNullException(nameof (obj));
  }

  public PdfObject[] GetAllObjects()
  {
    PdfReference[] allReferences = this._document._irefTable.AllReferences;
    int length = allReferences.Length;
    PdfObject[] allObjects = new PdfObject[length];
    for (int index = 0; index < length; ++index)
      allObjects[index] = allReferences[index].Value;
    return allObjects;
  }

  [Obsolete("Use GetAllObjects.")]
  public PdfObject[] AllObjects => this.GetAllObjects();

  public T CreateIndirectObject<T>() where T : PdfObject
  {
    T instance = Activator.CreateInstance<T>();
    this._document._irefTable.Add((PdfObject) instance);
    return instance;
  }

  public void AddObject(PdfObject obj)
  {
    if (obj == null)
      throw new ArgumentNullException(nameof (obj));
    if (obj.Owner == null)
      obj.Document = this._document;
    else if (obj.Owner != this._document)
      throw new InvalidOperationException("Object does not belong to this document.");
    this._document._irefTable.Add(obj);
  }

  public void RemoveObject(PdfObject obj)
  {
    if (obj == null)
      throw new ArgumentNullException(nameof (obj));
    if (obj.Reference == null)
      throw new InvalidOperationException("Only indirect objects can be removed.");
    if (obj.Owner != this._document)
      throw new InvalidOperationException("Object does not belong to this document.");
    this._document._irefTable.Remove(obj.Reference);
  }

  public PdfObject[] GetClosure(PdfObject obj) => this.GetClosure(obj, int.MaxValue);

  public PdfObject[] GetClosure(PdfObject obj, int depth)
  {
    PdfReference[] pdfReferenceArray = this._document._irefTable.TransitiveClosure(obj, depth);
    int length = pdfReferenceArray.Length + 1;
    PdfObject[] closure = new PdfObject[length];
    closure[0] = obj;
    for (int index = 1; index < length; ++index)
      closure[index] = pdfReferenceArray[index - 1].Value;
    return closure;
  }

  public void WriteObject(Stream stream, PdfItem item)
  {
    item.WriteObject(new PdfWriter(stream, (PdfStandardSecurityHandler) null)
    {
      Options = PdfWriterOptions.OmitStream
    });
  }
}
