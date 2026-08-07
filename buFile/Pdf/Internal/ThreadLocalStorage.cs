// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.ThreadLocalStorage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Internal;

internal class ThreadLocalStorage
{
  private readonly Dictionary<string, PdfDocument.DocumentHandle> _importedDocuments;

  public ThreadLocalStorage()
  {
    this._importedDocuments = new Dictionary<string, PdfDocument.DocumentHandle>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  }

  public void AddDocument(string path, PdfDocument document)
  {
    this._importedDocuments.Add(path, document.Handle);
  }

  public void RemoveDocument(string path) => this._importedDocuments.Remove(path);

  public PdfDocument GetDocument(string path)
  {
    Debug.Assert(path.StartsWith("*") || Path.IsPathRooted(path), "Path must be full qualified.");
    PdfDocument document = (PdfDocument) null;
    PdfDocument.DocumentHandle documentHandle;
    if (this._importedDocuments.TryGetValue(path, out documentHandle))
    {
      document = documentHandle.Target;
      if (document == null)
        this.RemoveDocument(path);
    }
    if (document == null)
    {
      document = PdfReader.Open(path, PdfDocumentOpenMode.Import);
      this._importedDocuments.Add(path, document.Handle);
    }
    return document;
  }

  public PdfDocument[] Documents
  {
    get
    {
      List<PdfDocument> pdfDocumentList = new List<PdfDocument>();
      foreach (PdfDocument.DocumentHandle documentHandle in this._importedDocuments.Values)
      {
        if (documentHandle.IsAlive)
          pdfDocumentList.Add(documentHandle.Target);
      }
      return pdfDocumentList.ToArray();
    }
  }

  public void DetachDocument(PdfDocument.DocumentHandle handle)
  {
    if (handle.IsAlive)
    {
      foreach (string key in this._importedDocuments.Keys)
      {
        if (this._importedDocuments[key] == handle)
        {
          this._importedDocuments.Remove(key);
          break;
        }
      }
    }
    bool flag = true;
    while (flag)
    {
      flag = false;
      foreach (string key in this._importedDocuments.Keys)
      {
        if (!this._importedDocuments[key].IsAlive)
        {
          this._importedDocuments.Remove(key);
          flag = true;
          break;
        }
      }
    }
  }
}
