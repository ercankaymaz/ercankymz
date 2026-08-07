// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfAnnotations
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

public sealed class PdfAnnotations : PdfArray
{
  private PdfPage _page;

  internal PdfAnnotations(PdfDocument document)
    : base(document)
  {
  }

  internal PdfAnnotations(PdfArray array)
    : base(array)
  {
  }

  public void Add(PdfAnnotation annotation)
  {
    annotation.Document = this.Owner;
    this.Owner._irefTable.Add((PdfObject) annotation);
    this.Elements.Add((PdfItem) annotation.Reference);
  }

  public void Remove(PdfAnnotation annotation)
  {
    if (annotation.Owner != this.Owner)
      throw new InvalidOperationException("The annotation does not belong to this document.");
    this.Owner.Internals.RemoveObject((PdfObject) annotation);
    this.Elements.Remove((PdfItem) annotation.Reference);
  }

  public void Clear()
  {
    for (int index = this.Count - 1; index >= 0; --index)
      this.Page.Annotations.Remove(this._page.Annotations[index]);
  }

  public int Count => this.Elements.Count;

  public PdfAnnotation this[int index]
  {
    get
    {
      PdfItem element = this.Elements[index];
      PdfDictionary dict;
      if (element is PdfReference pdfReference)
      {
        Debug.Assert(pdfReference.Value is PdfDictionary, "Reference to dictionary expected.");
        dict = (PdfDictionary) pdfReference.Value;
      }
      else
      {
        Debug.Assert(element is PdfDictionary, "Dictionary expected.");
        dict = (PdfDictionary) element;
      }
      if (!(dict is PdfAnnotation pdfAnnotation))
      {
        pdfAnnotation = (PdfAnnotation) new PdfGenericAnnotation(dict);
        if (pdfReference == null)
          this.Elements[index] = (PdfItem) pdfAnnotation;
      }
      return pdfAnnotation;
    }
  }

  internal PdfPage Page
  {
    get => this._page;
    set => this._page = value;
  }

  internal static void FixImportedAnnotation(PdfPage page)
  {
    PdfArray array = page.Elements.GetArray("/Annots");
    if (array == null)
      return;
    int count = array.Elements.Count;
    for (int index = 0; index < count; ++index)
    {
      PdfDictionary dictionary = array.Elements.GetDictionary(index);
      if ((dictionary == null ? 0 : (dictionary.Elements.ContainsKey("/P") ? 1 : 0)) != 0)
        dictionary.Elements["/P"] = (PdfItem) page.Reference;
    }
  }

  public override IEnumerator<PdfItem> GetEnumerator()
  {
    return (IEnumerator<PdfItem>) new PdfAnnotations.AnnotationsIterator(this);
  }

  private class AnnotationsIterator : IEnumerator<PdfItem>, IDisposable, IEnumerator
  {
    private readonly PdfAnnotations _annotations;
    private int _index;

    public AnnotationsIterator(PdfAnnotations annotations)
    {
      this._annotations = annotations;
      this._index = -1;
    }

    public PdfItem Current => (PdfItem) this._annotations[this._index];

    object IEnumerator.Current => (object) this.Current;

    public bool MoveNext() => ++this._index < this._annotations.Count;

    public void Reset() => this._index = -1;

    public void Dispose()
    {
    }
  }
}
