// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfContents
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfContents : PdfArray
{
  private bool _modified;

  public PdfContents(PdfDocument document)
    : base(document)
  {
  }

  internal PdfContents(PdfArray array)
    : base(array)
  {
    int count = this.Elements.Count;
    for (int index = 0; index < count; ++index)
    {
      if ((!(this.Elements[index] is PdfReference element) ? 0 : (element.Value is PdfDictionary ? 1 : 0)) == 0)
        throw new InvalidOperationException("Unexpected item in a content stream array.");
      PdfContent pdfContent = new PdfContent((PdfDictionary) element.Value);
    }
  }

  public PdfContent AppendContent()
  {
    Debug.Assert(this.Owner != null);
    this.SetModified();
    PdfContent pdfContent = new PdfContent(this.Owner);
    this.Owner._irefTable.Add((PdfObject) pdfContent);
    Debug.Assert(pdfContent.Reference != null);
    this.Elements.Add((PdfItem) pdfContent.Reference);
    return pdfContent;
  }

  public PdfContent PrependContent()
  {
    Debug.Assert(this.Owner != null);
    this.SetModified();
    PdfContent pdfContent = new PdfContent(this.Owner);
    this.Owner._irefTable.Add((PdfObject) pdfContent);
    Debug.Assert(pdfContent.Reference != null);
    this.Elements.Insert(0, (PdfItem) pdfContent.Reference);
    return pdfContent;
  }

  public PdfContent CreateSingleContent()
  {
    byte[] numArray1 = new byte[0];
    foreach (PdfReference element in this.Elements)
    {
      PdfDictionary pdfDictionary = (PdfDictionary) element.Value;
      byte[] numArray2 = numArray1;
      byte[] unfilteredValue = pdfDictionary.Stream.UnfilteredValue;
      numArray1 = new byte[numArray2.Length + unfilteredValue.Length + 1];
      numArray2.CopyTo((Array) numArray1, 0);
      numArray1[numArray2.Length] = (byte) 10;
      unfilteredValue.CopyTo((Array) numArray1, numArray2.Length + 1);
    }
    PdfContent owner = new PdfContent(this.Owner);
    owner.Stream = new PdfDictionary.PdfStream(numArray1, (PdfDictionary) owner);
    return owner;
  }

  public PdfContent ReplaceContent(CSequence cseq)
  {
    return cseq != null ? this.ReplaceContent(cseq.ToContent()) : throw new ArgumentNullException(nameof (cseq));
  }

  private PdfContent ReplaceContent(byte[] contentBytes)
  {
    Debug.Assert(this.Owner != null);
    PdfContent pdfContent = new PdfContent(this.Owner);
    pdfContent.CreateStream(contentBytes);
    this.Owner._irefTable.Add((PdfObject) pdfContent);
    this.Elements.Clear();
    this.Elements.Add((PdfItem) pdfContent.Reference);
    return pdfContent;
  }

  private void SetModified()
  {
    if (this._modified)
      return;
    this._modified = true;
    int count = this.Elements.Count;
    if (count == 1)
    {
      ((PdfContent) ((PdfReference) this.Elements[0]).Value).PreserveGraphicsState();
    }
    else
    {
      if (count <= 1)
        return;
      PdfContent pdfContent1 = (PdfContent) ((PdfReference) this.Elements[0]).Value;
      if ((pdfContent1 == null ? 0 : (pdfContent1.Stream != null ? 1 : 0)) != 0)
      {
        int length = pdfContent1.Stream.Length;
        byte[] destinationArray = new byte[length + 2];
        destinationArray[0] = (byte) 113;
        destinationArray[1] = (byte) 10;
        Array.Copy((Array) pdfContent1.Stream.Value, 0, (Array) destinationArray, 2, length);
        pdfContent1.Stream.Value = destinationArray;
        pdfContent1.Elements.SetInteger("/Length", length + 2);
      }
      PdfContent pdfContent2 = (PdfContent) ((PdfReference) this.Elements[count - 1]).Value;
      if ((pdfContent2 == null ? 0 : (pdfContent2.Stream != null ? 1 : 0)) == 0)
        return;
      int length1 = pdfContent2.Stream.Length;
      byte[] destinationArray1 = new byte[length1 + 3];
      Array.Copy((Array) pdfContent2.Stream.Value, 0, (Array) destinationArray1, 0, length1);
      destinationArray1[length1] = (byte) 32 /*0x20*/;
      destinationArray1[length1 + 1] = (byte) 81;
      destinationArray1[length1 + 2] = (byte) 10;
      pdfContent2.Stream.Value = destinationArray1;
      pdfContent2.Elements.SetInteger("/Length", length1 + 3);
    }
  }

  internal override void WriteObject(PdfWriter writer)
  {
    if (this.Elements.Count == 1)
      this.Elements[0].WriteObject(writer);
    else
      base.WriteObject(writer);
  }

  public IEnumerator<PdfContent> GetEnumerator()
  {
    return (IEnumerator<PdfContent>) new PdfContents.PdfPageContentEnumerator(this);
  }

  private class PdfPageContentEnumerator : IEnumerator<PdfContent>, IDisposable, IEnumerator
  {
    private PdfContent _currentElement;
    private int _index;
    private readonly PdfContents _contents;

    internal PdfPageContentEnumerator(PdfContents list)
    {
      this._contents = list;
      this._index = -1;
    }

    public bool MoveNext()
    {
      bool flag;
      if (this._index < this._contents.Elements.Count - 1)
      {
        ++this._index;
        this._currentElement = (PdfContent) ((PdfReference) this._contents.Elements[this._index]).Value;
        flag = true;
      }
      else
      {
        this._index = this._contents.Elements.Count;
        flag = false;
      }
      return flag;
    }

    public void Reset()
    {
      this._currentElement = (PdfContent) null;
      this._index = -1;
    }

    object IEnumerator.Current => (object) this.Current;

    public PdfContent Current
    {
      get
      {
        if ((this._index == -1 ? 1 : (this._index >= this._contents.Elements.Count ? 1 : 0)) != 0)
          throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
        return this._currentElement;
      }
    }

    public void Dispose()
    {
    }
  }
}
