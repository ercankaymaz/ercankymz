// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CSequence
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("(count={Count})")]
public class CSequence : 
  CObject,
  IList<CObject>,
  ICollection<CObject>,
  IEnumerable<CObject>,
  IEnumerable
{
  private List<CObject> _items = new List<CObject>();

  public CSequence Clone() => (CSequence) this.Copy();

  protected override CObject Copy()
  {
    CObject cobject = base.Copy();
    this._items = new List<CObject>((IEnumerable<CObject>) this._items);
    for (int index = 0; index < this._items.Count; ++index)
      this._items[index] = this._items[index].Clone();
    return cobject;
  }

  public void Add(CSequence sequence)
  {
    int count = sequence.Count;
    for (int index = 0; index < count; ++index)
      this._items.Add(sequence[index]);
  }

  public void Add(CObject value) => this._items.Add(value);

  public void Clear() => this._items.Clear();

  public bool Contains(CObject value) => this._items.Contains(value);

  public int IndexOf(CObject value) => this._items.IndexOf(value);

  public void Insert(int index, CObject value) => this._items.Insert(index, value);

  public bool Remove(CObject value) => this._items.Remove(value);

  public void RemoveAt(int index) => this._items.RemoveAt(index);

  public CObject this[int index]
  {
    get => this._items[index];
    set => this._items[index] = value;
  }

  public void CopyTo(CObject[] array, int index) => this._items.CopyTo(array, index);

  public int Count => this._items.Count;

  public IEnumerator<CObject> GetEnumerator() => (IEnumerator<CObject>) this._items.GetEnumerator();

  public byte[] ToContent()
  {
    Stream contentStream = (Stream) new MemoryStream();
    ContentWriter writer = new ContentWriter(contentStream);
    this.WriteObject(writer);
    writer.Close(false);
    contentStream.Position = 0L;
    int length = (int) contentStream.Length;
    byte[] buffer = new byte[length];
    contentStream.Read(buffer, 0, length);
    contentStream.Close();
    return buffer;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < this._items.Count; ++index)
      stringBuilder.Append((object) this._items[index]);
    return stringBuilder.ToString();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  internal override void WriteObject(ContentWriter writer)
  {
    for (int index = 0; index < this._items.Count; ++index)
      this._items[index].WriteObject(writer);
  }

  int IList<CObject>.IndexOf(CObject item) => throw new NotImplementedException();

  void IList<CObject>.Insert(int index, CObject item) => throw new NotImplementedException();

  void IList<CObject>.RemoveAt(int index) => throw new NotImplementedException();

  CObject IList<CObject>.this[int index]
  {
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
  }

  void ICollection<CObject>.Add(CObject item) => throw new NotImplementedException();

  void ICollection<CObject>.Clear() => throw new NotImplementedException();

  bool ICollection<CObject>.Contains(CObject item) => throw new NotImplementedException();

  void ICollection<CObject>.CopyTo(CObject[] array, int arrayIndex)
  {
    throw new NotImplementedException();
  }

  int ICollection<CObject>.Count => throw new NotImplementedException();

  bool ICollection<CObject>.IsReadOnly => throw new NotImplementedException();

  bool ICollection<CObject>.Remove(CObject item) => throw new NotImplementedException();

  IEnumerator<CObject> IEnumerable<CObject>.GetEnumerator() => throw new NotImplementedException();
}
