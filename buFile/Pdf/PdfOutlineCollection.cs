// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfOutlineCollection
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf;

public class PdfOutlineCollection : 
  PdfObject,
  ICollection<PdfOutline>,
  IEnumerable<PdfOutline>,
  IEnumerable,
  IList<PdfOutline>
{
  private readonly PdfOutline _parent;
  private readonly List<PdfOutline> _outlines = new List<PdfOutline>();

  internal PdfOutlineCollection(PdfDocument document, PdfOutline parent)
    : base(document)
  {
    this._parent = parent;
  }

  [Obsolete("Use 'Count > 0' - HasOutline will throw exception.")]
  public bool HasOutline => throw new InvalidOperationException("Use 'Count > 0'");

  public bool Remove(PdfOutline item)
  {
    bool flag;
    if (this._outlines.Remove(item))
    {
      this.RemoveFromOutlinesTree(item);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public int Count => this._outlines.Count;

  public bool IsReadOnly => false;

  public void Add(PdfOutline outline)
  {
    if (outline == null)
      throw new ArgumentNullException(nameof (outline));
    if ((outline.DestinationPage == null ? 0 : (this.Owner != outline.DestinationPage.Owner ? 1 : 0)) != 0)
      throw new ArgumentException("Destination page must belong to this document.");
    this.AddToOutlinesTree(outline);
    this._outlines.Add(outline);
    if (!outline.Opened)
      return;
    for (outline = this._parent; outline != null; outline = outline.Parent)
      ++outline.OpenCount;
  }

  public void Clear()
  {
    if (this.Count <= 0)
      return;
    PdfOutline[] array = new PdfOutline[this.Count];
    this._outlines.CopyTo(array);
    this._outlines.Clear();
    foreach (PdfOutline outline in array)
      this.RemoveFromOutlinesTree(outline);
  }

  public bool Contains(PdfOutline item) => this._outlines.Contains(item);

  public void CopyTo(PdfOutline[] array, int arrayIndex)
  {
    this._outlines.CopyTo(array, arrayIndex);
  }

  public PdfOutline Add(
    string title,
    PdfPage destinationPage,
    bool opened,
    PdfOutlineStyle style,
    XColor textColor)
  {
    PdfOutline outline = new PdfOutline(title, destinationPage, opened, style, textColor);
    this.Add(outline);
    return outline;
  }

  public PdfOutline Add(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style)
  {
    PdfOutline outline = new PdfOutline(title, destinationPage, opened, style);
    this.Add(outline);
    return outline;
  }

  public PdfOutline Add(string title, PdfPage destinationPage, bool opened)
  {
    PdfOutline outline = new PdfOutline(title, destinationPage, opened);
    this.Add(outline);
    return outline;
  }

  public PdfOutline Add(string title, PdfPage destinationPage)
  {
    PdfOutline outline = new PdfOutline(title, destinationPage);
    this.Add(outline);
    return outline;
  }

  public int IndexOf(PdfOutline item) => this._outlines.IndexOf(item);

  public void Insert(int index, PdfOutline outline)
  {
    if (outline == null)
      throw new ArgumentNullException(nameof (outline));
    if ((index < 0 ? 1 : (index >= this._outlines.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.OutlineIndexOutOfRange);
    this.AddToOutlinesTree(outline);
    this._outlines.Insert(index, outline);
  }

  public void RemoveAt(int index)
  {
    PdfOutline outline = this._outlines[index];
    this._outlines.RemoveAt(index);
    this.RemoveFromOutlinesTree(outline);
  }

  public PdfOutline this[int index]
  {
    get
    {
      if ((index < 0 ? 1 : (index >= this._outlines.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.OutlineIndexOutOfRange);
      return this._outlines[index];
    }
    set
    {
      if ((index < 0 ? 1 : (index >= this._outlines.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.OutlineIndexOutOfRange);
      if (value == null)
        throw new ArgumentOutOfRangeException(nameof (value), (object) null, PSSR.SetValueMustNotBeNull);
      this.AddToOutlinesTree(value);
      this._outlines[index] = value;
    }
  }

  public IEnumerator<PdfOutline> GetEnumerator()
  {
    return (IEnumerator<PdfOutline>) this._outlines.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  internal int CountOpen() => 0;

  private void AddToOutlinesTree(PdfOutline outline)
  {
    if (outline == null)
      throw new ArgumentNullException(nameof (outline));
    if ((outline.DestinationPage == null ? 0 : (this.Owner != outline.DestinationPage.Owner ? 1 : 0)) != 0)
      throw new ArgumentException("Destination page must belong to this document.");
    outline.Document = this.Owner;
    outline.Parent = this._parent;
    if (!this.Owner._irefTable.Contains(outline.ObjectID))
      this.Owner._irefTable.Add((PdfObject) outline);
    else
      outline.GetType();
  }

  private void RemoveFromOutlinesTree(PdfOutline outline)
  {
    if (outline == null)
      throw new ArgumentNullException(nameof (outline));
    outline.Parent = (PdfOutline) null;
    this.Owner._irefTable.Remove(outline.Reference);
  }
}
