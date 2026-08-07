// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Bookmarks
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class Bookmarks : BaseBookmarks
{
  protected buMultiTextBox tb;
  protected List<Bookmark> items = new List<Bookmark>();
  protected int counter;

  public Bookmarks(buMultiTextBox tb)
  {
    this.tb = tb;
    tb.LineInserted += new EventHandler<LineInsertedEventArgs>(this.tb_LineInserted);
    tb.LineRemoved += new EventHandler<LineRemovedEventArgs>(this.tb_LineRemoved);
  }

  protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
  {
    for (int index = 0; index < this.Count; ++index)
    {
      if (this.items[index].LineIndex >= e.Index)
      {
        if (this.items[index].LineIndex >= e.Index + e.Count)
        {
          this.items[index].LineIndex -= e.Count;
        }
        else
        {
          bool flag = e.Index <= 0;
          foreach (Bookmark bookmark in this.items)
          {
            if (bookmark.LineIndex == e.Index - 1)
              flag = true;
          }
          if (flag)
          {
            this.items.RemoveAt(index);
            --index;
          }
          else
            this.items[index].LineIndex = e.Index - 1;
        }
      }
    }
  }

  protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
  {
    for (int index = 0; index < this.Count; ++index)
    {
      if (this.items[index].LineIndex >= e.Index)
        this.items[index].LineIndex += e.Count;
      else if ((this.items[index].LineIndex != e.Index - 1 ? 0 : (e.Count == 1 ? 1 : 0)) != 0 && this.tb[e.Index - 1].StartSpacesCount == this.tb[e.Index - 1].Count)
        this.items[index].LineIndex += e.Count;
    }
  }

  public override void Dispose()
  {
    this.tb.LineInserted -= new EventHandler<LineInsertedEventArgs>(this.tb_LineInserted);
    this.tb.LineRemoved -= new EventHandler<LineRemovedEventArgs>(this.tb_LineRemoved);
  }

  public override IEnumerator<Bookmark> GetEnumerator()
  {
    List<Bookmark>.Enumerator enumerator = this.items.GetEnumerator();
    while (enumerator.MoveNext())
    {
      Bookmark bookmark = enumerator.Current;
      yield return bookmark;
      bookmark = (Bookmark) null;
    }
    Class39.smethod_8(this);
    enumerator = new List<Bookmark>.Enumerator();
  }

  public override void Add(int lineIndex, string bookmarkName)
  {
    this.Add(new Bookmark(this.tb, bookmarkName ?? "Bookmark " + this.counter.ToString(), lineIndex));
  }

  public override void Add(int lineIndex)
  {
    this.Add(new Bookmark(this.tb, "Bookmark " + this.counter.ToString(), lineIndex));
  }

  public override void Clear()
  {
    this.items.Clear();
    this.counter = 0;
  }

  public override void Add(Bookmark bookmark)
  {
    foreach (Bookmark bookmark1 in this.items)
    {
      if (bookmark1.LineIndex == bookmark.LineIndex)
        return;
    }
    this.items.Add(bookmark);
    ++this.counter;
    this.tb.Invalidate();
  }

  public override bool Contains(Bookmark item) => this.items.Contains(item);

  public override bool Contains(int lineIndex)
  {
    bool flag;
    foreach (Bookmark bookmark in this.items)
    {
      if (bookmark.LineIndex == lineIndex)
      {
        flag = true;
        goto label_7;
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public override void CopyTo(Bookmark[] array, int arrayIndex)
  {
    this.items.CopyTo(array, arrayIndex);
  }

  public override int Count => this.items.Count;

  public override bool IsReadOnly => false;

  public override bool Remove(Bookmark item)
  {
    this.tb.Invalidate();
    return this.items.Remove(item);
  }

  public override bool Remove(int lineIndex)
  {
    bool flag = false;
    for (int index = 0; index < this.Count; ++index)
    {
      if (this.items[index].LineIndex == lineIndex)
      {
        this.items.RemoveAt(index);
        --index;
        flag = true;
      }
    }
    this.tb.Invalidate();
    return flag;
  }

  public override Bookmark GetBookmark(int i) => this.items[i];
}
