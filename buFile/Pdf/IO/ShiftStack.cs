// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.ShiftStack
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.IO;

internal class ShiftStack
{
  private int _sp;
  private readonly List<PdfItem> _items;

  public ShiftStack() => this._items = new List<PdfItem>();

  public PdfItem[] ToArray(int start, int length)
  {
    PdfItem[] array = new PdfItem[length];
    int index1 = 0;
    int index2 = start;
    while (index1 < length)
    {
      array[index1] = this._items[index2];
      ++index1;
      ++index2;
    }
    return array;
  }

  public int SP => this._sp;

  public PdfItem this[int index]
  {
    get
    {
      return index < this._sp ? this._items[index] : throw new ArgumentOutOfRangeException(nameof (index), (object) index, "Value greater than stack index.");
    }
  }

  public PdfItem GetItem(int relativeIndex)
  {
    if ((relativeIndex >= 0 ? 1 : (-relativeIndex > this._sp ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (relativeIndex), (object) relativeIndex, "Value out of stack range.");
    return this._items[this._sp + relativeIndex];
  }

  public int GetInteger(int relativeIndex)
  {
    if ((relativeIndex >= 0 ? 1 : (-relativeIndex > this._sp ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (relativeIndex), (object) relativeIndex, "Value out of stack range.");
    return ((PdfInteger) this._items[this._sp + relativeIndex]).Value;
  }

  public void Shift(PdfItem item)
  {
    Debug.Assert(item != null);
    this._items.Add(item);
    ++this._sp;
  }

  public void Reduce(int count)
  {
    if (count > this._sp)
      throw new ArgumentException("count causes stack underflow.");
    this._items.RemoveRange(this._sp - count, count);
    this._sp -= count;
  }

  public void Reduce(PdfItem item, int count)
  {
    Debug.Assert(item != null);
    this.Reduce(count);
    this._items.Add(item);
    ++this._sp;
  }
}
