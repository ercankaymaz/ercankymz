// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.TextSource
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

#nullable disable
namespace buMutliTextbox;

public class TextSource : IDisposable, IEnumerable, IList<Line>, ICollection<Line>, IEnumerable<Line>
{
  protected internal readonly List<Line> lines = new List<Line>();
  protected LinesAccessor linesAccessor;
  private int int_0;
  private buMultiTextBox buMultiTextBox_0;
  public readonly Style[] Styles;

  public CommandManager Manager { get; set; }

  public event EventHandler<LineInsertedEventArgs> LineInserted;

  public event EventHandler<LineRemovedEventArgs> LineRemoved;

  public event EventHandler<TextSource.TextChangedEventArgs> TextChanged;

  public event EventHandler<TextSource.TextChangedEventArgs> RecalcNeeded;

  public event EventHandler<TextSource.TextChangedEventArgs> RecalcWordWrap;

  public event EventHandler<TextChangingEventArgs> TextChanging;

  public event EventHandler CurrentTBChanged;

  public buMultiTextBox CurrentTB
  {
    get => this.buMultiTextBox_0;
    set
    {
      if (this.buMultiTextBox_0 == value)
        return;
      this.buMultiTextBox_0 = value;
      Class39.smethod_252(this);
    }
  }

  public virtual void ClearIsChanged()
  {
    foreach (Line line in this.lines)
      line.IsChanged = false;
  }

  public virtual Line CreateLine() => new Line(this.GenerateUniqueLineId());

  public TextStyle DefaultStyle { get; set; }

  public TextSource(buMultiTextBox currentTB)
  {
    this.CurrentTB = currentTB;
    this.linesAccessor = new LinesAccessor((IList<Line>) this);
    this.Manager = new CommandManager(this);
    this.Styles = !(Enum.GetUnderlyingType(typeof (StyleIndex)) == typeof (uint)) ? new Style[16 /*0x10*/] : new Style[32 /*0x20*/];
    this.InitDefaultStyle();
  }

  public virtual void InitDefaultStyle()
  {
    this.DefaultStyle = new TextStyle((Brush) null, (Brush) null, FontStyle.Regular);
  }

  public virtual Line this[int i]
  {
    get => this.lines[i];
    set => throw new NotImplementedException();
  }

  public virtual bool IsLineLoaded(int iLine) => this.lines[iLine] != null;

  public virtual IList<string> GetLines() => (IList<string>) this.linesAccessor;

  public IEnumerator<Line> GetEnumerator() => (IEnumerator<Line>) this.lines.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => this.lines as IEnumerator;

  public virtual int BinarySearch(Line item, IComparer<Line> comparer)
  {
    return this.lines.BinarySearch(item, comparer);
  }

  public virtual int GenerateUniqueLineId() => this.int_0++;

  public virtual void InsertLine(int index, Line line)
  {
    this.lines.Insert(index, line);
    this.OnLineInserted(index);
  }

  public virtual void OnLineInserted(int index) => this.OnLineInserted(index, 1);

  public virtual void OnLineInserted(int index, int count)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new LineInsertedEventArgs(index, count));
  }

  public virtual void RemoveLine(int index) => this.RemoveLine(index, 1);

  public virtual bool IsNeedBuildRemovedLineIds => this.eventHandler_1 != null;

  public virtual void RemoveLine(int index, int count)
  {
    List<int> removedLineIds = new List<int>();
    if (count > 0 && this.IsNeedBuildRemovedLineIds)
    {
      for (int index1 = 0; index1 < count; ++index1)
        removedLineIds.Add(this[index + index1].UniqueId);
    }
    this.lines.RemoveRange(index, count);
    this.OnLineRemoved(index, count, removedLineIds);
  }

  public virtual void OnLineRemoved(int index, int count, List<int> removedLineIds)
  {
    // ISSUE: reference to a compiler-generated field
    if (count <= 0 || this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, new LineRemovedEventArgs(index, count, removedLineIds));
  }

  public virtual void OnTextChanged(int fromLine, int toLine)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_2((object) this, new TextSource.TextChangedEventArgs(Math.Min(fromLine, toLine), Math.Max(fromLine, toLine)));
  }

  public virtual int IndexOf(Line item) => this.lines.IndexOf(item);

  public virtual void Insert(int index, Line item) => this.InsertLine(index, item);

  public virtual void RemoveAt(int index) => this.RemoveLine(index);

  public virtual void Add(Line item) => this.InsertLine(this.Count, item);

  public virtual void Clear() => this.RemoveLine(0, this.Count);

  public virtual bool Contains(Line item) => this.lines.Contains(item);

  public virtual void CopyTo(Line[] array, int arrayIndex) => this.lines.CopyTo(array, arrayIndex);

  public virtual int Count => this.lines.Count;

  public virtual bool IsReadOnly => false;

  public virtual bool Remove(Line item)
  {
    int index = this.IndexOf(item);
    bool flag;
    if (index >= 0)
    {
      this.RemoveLine(index);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public virtual void NeedRecalc(TextSource.TextChangedEventArgs args)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_3 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_3((object) this, args);
  }

  public virtual void OnRecalcWordWrap(TextSource.TextChangedEventArgs args)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_4 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_4((object) this, args);
  }

  public virtual void OnTextChanging()
  {
    string text = (string) null;
    this.OnTextChanging(ref text);
  }

  public virtual void OnTextChanging(ref string text)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_5 == null)
      return;
    TextChangingEventArgs e = new TextChangingEventArgs()
    {
      InsertingText = text
    };
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_5((object) this, e);
    text = e.InsertingText;
    if (!e.Cancel)
      return;
    text = string.Empty;
  }

  public virtual int GetLineLength(int i) => this.lines[i].Count;

  public virtual bool LineHasFoldingStartMarker(int iLine)
  {
    return !string.IsNullOrEmpty(this.lines[iLine].FoldingStartMarker);
  }

  public virtual bool LineHasFoldingEndMarker(int iLine)
  {
    return !string.IsNullOrEmpty(this.lines[iLine].FoldingEndMarker);
  }

  public virtual void Dispose()
  {
  }

  public virtual void SaveToFile(string fileName, Encoding enc)
  {
    using (StreamWriter streamWriter = new StreamWriter(fileName, false, enc))
    {
      for (int index = 0; index < this.Count - 1; ++index)
        streamWriter.WriteLine(this.lines[index].Text);
      streamWriter.Write(this.lines[this.Count - 1].Text);
    }
  }

  public class TextChangedEventArgs : EventArgs
  {
    public int iFromLine;
    public int iToLine;

    public TextChangedEventArgs(int iFromLine, int iToLine)
    {
      this.iFromLine = iFromLine;
      this.iToLine = iToLine;
    }
  }
}
