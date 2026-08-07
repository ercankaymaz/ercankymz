// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.BaseBookmarks
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public abstract class BaseBookmarks : 
  ICollection<Bookmark>,
  IEnumerable<Bookmark>,
  IDisposable,
  IEnumerable
{
  public abstract void Add(Bookmark item);

  public abstract void Clear();

  public abstract bool Contains(Bookmark item);

  public abstract void CopyTo(Bookmark[] array, int arrayIndex);

  public abstract int Count { get; }

  public abstract bool IsReadOnly { get; }

  public abstract bool Remove(Bookmark item);

  public abstract IEnumerator<Bookmark> GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public abstract void Dispose();

  public abstract void Add(int lineIndex, string bookmarkName);

  public abstract void Add(int lineIndex);

  public abstract bool Contains(int lineIndex);

  public abstract bool Remove(int lineIndex);

  public abstract Bookmark GetBookmark(int i);
}
