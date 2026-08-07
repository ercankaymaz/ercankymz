// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Line
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

#nullable disable
namespace buMutliTextbox;

public class Line : IEnumerable, IEnumerable<Char>, IList<Char>, ICollection<Char>
{
  protected List<Char> chars;

  public string FoldingStartMarker { get; set; }

  public string FoldingEndMarker { get; set; }

  public bool IsChanged { get; set; }

  public DateTime LastVisit { get; set; }

  public Brush BackgroundBrush { get; set; }

  public int UniqueId { get; private set; }

  public int AutoIndentSpacesNeededCount { get; set; }

  internal Line(int int_2)
  {
    this.UniqueId = int_2;
    this.chars = new List<Char>();
  }

  public void ClearStyle(StyleIndex styleIndex)
  {
    this.FoldingStartMarker = (string) null;
    this.FoldingEndMarker = (string) null;
    for (int index = 0; index < this.Count; ++index)
    {
      Char @char = this[index];
      @char.style &= ~styleIndex;
      this[index] = @char;
    }
  }

  public virtual string Text
  {
    get
    {
      StringBuilder stringBuilder = new StringBuilder(this.Count);
      foreach (Char @char in this)
        stringBuilder.Append(@char.c);
      return stringBuilder.ToString();
    }
  }

  public void ClearFoldingMarkers()
  {
    this.FoldingStartMarker = (string) null;
    this.FoldingEndMarker = (string) null;
  }

  public int StartSpacesCount
  {
    get
    {
      int startSpacesCount = 0;
      for (int index = 0; index < this.Count && this[index].c == ' '; ++index)
        ++startSpacesCount;
      return startSpacesCount;
    }
  }

  public int IndexOf(Char item) => this.chars.IndexOf(item);

  public void Insert(int index, Char item) => this.chars.Insert(index, item);

  public void RemoveAt(int index) => this.chars.RemoveAt(index);

  public Char this[int index]
  {
    get => this.chars[index];
    set => this.chars[index] = value;
  }

  public void Add(Char item) => this.chars.Add(item);

  public void Clear() => this.chars.Clear();

  public bool Contains(Char item) => this.chars.Contains(item);

  public void CopyTo(Char[] array, int arrayIndex) => this.chars.CopyTo(array, arrayIndex);

  public int Count => this.chars.Count;

  public bool IsReadOnly => false;

  public bool Remove(Char item) => this.chars.Remove(item);

  public IEnumerator<Char> GetEnumerator() => (IEnumerator<Char>) this.chars.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.chars.GetEnumerator();

  public virtual void RemoveRange(int index, int count)
  {
    if (index >= this.Count)
      return;
    this.chars.RemoveRange(index, Math.Min(this.Count - index, count));
  }

  public virtual void TrimExcess() => this.chars.TrimExcess();

  public virtual void AddRange(IEnumerable<Char> collection) => this.chars.AddRange(collection);
}
