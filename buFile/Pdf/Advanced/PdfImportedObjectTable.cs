// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfImportedObjectTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfImportedObjectTable
{
  private readonly PdfFormXObject[] _xObjects;
  private readonly PdfDocument _owner;
  private readonly PdfDocument.DocumentHandle _externalDocumentHandle;
  private readonly Dictionary<string, PdfReference> _externalIDs = new Dictionary<string, PdfReference>();

  public PdfImportedObjectTable(PdfDocument owner, PdfDocument externalDocument)
  {
    if (owner == null)
      throw new ArgumentNullException(nameof (owner));
    if (externalDocument == null)
      throw new ArgumentNullException(nameof (externalDocument));
    this._owner = owner;
    this._externalDocumentHandle = externalDocument.Handle;
    this._xObjects = new PdfFormXObject[externalDocument.PageCount];
  }

  public PdfDocument Owner => this._owner;

  public PdfDocument ExternalDocument
  {
    get
    {
      return this._externalDocumentHandle.IsAlive ? this._externalDocumentHandle.Target : (PdfDocument) null;
    }
  }

  public PdfFormXObject GetXObject(int pageNumber) => this._xObjects[pageNumber - 1];

  public void SetXObject(int pageNumber, PdfFormXObject xObject)
  {
    this._xObjects[pageNumber - 1] = xObject;
  }

  public bool Contains(PdfObjectID externalID)
  {
    return this._externalIDs.ContainsKey(externalID.ToString());
  }

  public void Add(PdfObjectID externalID, PdfReference iref)
  {
    this._externalIDs[externalID.ToString()] = iref;
  }

  public PdfReference this[PdfObjectID externalID] => this._externalIDs[externalID.ToString()];
}
